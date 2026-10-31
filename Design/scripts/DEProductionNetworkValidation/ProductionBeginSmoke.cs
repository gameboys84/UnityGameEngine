using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using DE.Infrastructure.Network;

internal static class ProductionBeginSmoke
{
    private static int passed;
    private static void Check(bool value, string name) { if (!value) throw new Exception(name); Interlocked.Increment(ref passed); Console.WriteLine("PASS production " + name); }
    public static async Task Run()
    {
        await RunCase(42, false).ConfigureAwait(false);
        await RunCase(0, true).ConfigureAwait(false);
        await RunCase(43, true).ConfigureAwait(false);
        Console.WriteLine("PRODUCTION CONTRACT " + passed + " checks passed (offline HTTP contract handler + real loopback TCP)");
    }
    private static async Task RunCase(long returnedRole, bool expectRejection)
    {
        var listener = new TcpListener(IPAddress.Loopback, 0); listener.Start();
        int port = ((IPEndPoint)listener.LocalEndpoint).Port;
        using (var timeout = new CancellationTokenSource(10000))
        using (var http = new HttpClient(new ContractHttpHandler(port)))
        using (var connection = new DeProductionConnection(new ProductionSessionOptions("de-rewrite-test-contract", "IOS_6900", "0.69.0"), http))
        {
            var done = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            Task server = Task.Run(async () => {
                using (var socket = await listener.AcceptTcpClientAsync().ConfigureAwait(false))
                using (var stream = socket.GetStream())
                {
                    var token = new Protocol.SessionTokenInfo { m_key1 = 0x12345678, m_key2 = 0x87654321, m_id = 321 };
                    byte[] frame = DeWireCodec.FrameBody(DeWireCodec.EncodeBody(Protocol.MsgType.SESSION_TOKEN_NTF, token));
                    await stream.WriteAsync(frame, 0, frame.Length, timeout.Token).ConfigureAwait(false);
                    uint key = DeWireCodec.DerivePikeKey(token.m_key1, token.m_key2);
                    var writeCipher = new Pike(key);
                    byte[] timeBody = DeWireCodec.EncodeBody(Protocol.MsgType.TIME_NTF, new Protocol.TimeNtfInfo { m_t = 123456 });
                    writeCipher.Codec(timeBody, 0, timeBody.Length); frame = DeWireCodec.FrameBody(timeBody);
                    await stream.WriteAsync(frame, 0, frame.Length, timeout.Token).ConfigureAwait(false);
                    byte[] head = await Read(stream, 2, timeout.Token); int position = 0;
                    byte[] loginBytes = await Read(stream, NetworkSerialization.ReadUInt16(head, ref position), timeout.Token);
                    new Pike(key).Codec(loginBytes, 0, loginBytes.Length);
                    var login = (Protocol.LoginInfo)DeWireCodec.DecodeBody(loginBytes, out var type);
                    Check(type == Protocol.MsgType.LOGIN_REQ && login.m_pvc_ver == 72 && login.m_platform_id == 2 && login.m_publisher_channel == 0 && login.m_user_id == 42, "original LOGIN_REQ fields");
                    Check(login.m_login_name == "anonymous:namede-rewrite-test-contract.0" && login.m_token == "contract-test-jwt" && login.m_device_id_type == 1 && login.m_device_id == "", "dedicated identity with source Editor channel/device semantics");
                    byte[] userBody = DeWireCodec.EncodeBody(Protocol.MsgType.LOGIN_ACK, new Protocol.UserInfo { m_id = returnedRole });
                    writeCipher.Codec(userBody, 0, userBody.Length); frame = DeWireCodec.FrameBody(userBody);
                    await stream.WriteAsync(frame, 0, frame.Length, timeout.Token).ConfigureAwait(false);
                    await done.Task.WaitAsync(timeout.Token).ConfigureAwait(false);
                    Check(!stream.DataAvailable, "network sends no duplicated loading/economic requests");
                }
            });
            if (expectRejection)
            {
                try { await connection.BeginSessionAsync(timeout.Token).ConfigureAwait(false); Check(false, "invalid role LOGIN_ACK must fail"); }
                catch (ProductionConnectionException failure) { Check(failure.Phase == ProductionConnectionPhase.LoggingIn, "rejects invalid LOGIN_ACK role " + returnedRole); }
                Check(!connection.Status.IsLoggedIn && connection.CurrentUser == null, "rejected role cannot become logged-in state");
                connection.Pump();
                Check(connection.RawState.GetLatest(Protocol.MsgType.LOGIN_ACK) == null, "rejected role is never published to business reducers");
            }
            else
            {
                await connection.BeginSessionAsync(timeout.Token).ConfigureAwait(false);
                Check(connection.Status.IsLoggedIn && connection.CurrentUser.m_id == 42 && connection.Status.Phase == ProductionConnectionPhase.LoginAck, "verified LOGIN_ACK is the final login phase, without gameplay loading");
                try { await connection.BeginSessionAsync(timeout.Token).ConfigureAwait(false); Check(false, "duplicate Begin must refuse without disconnect"); }
                catch (InvalidOperationException) { Check(connection.Status.IsLoggedIn && connection.CurrentUser.m_id == 42, "duplicate Begin cannot tear down a valid login"); }
                connection.Pump();
                Check(connection.RawState.GetLatest<Protocol.TimeNtfInfo>(Protocol.MsgType.TIME_NTF).m_t == 123456, "early TIME_NTF retained before loading coordinator");
            }
            done.TrySetResult(true); await server.ConfigureAwait(false);
        }
        listener.Stop();
    }
    private sealed class ContractHttpHandler : HttpMessageHandler
    {
        private readonly int port;
        public ContractHttpHandler(int port) { this.port = port; }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Check((request.Method == HttpMethod.Get ? request.Content == null : request.Content != null && request.Content.Headers.ContentType == null) && request.Headers.UserAgent.ToString() == "BestHTTP",
                "source RawData and BestHTTP header parity without invented Content-Type");
            string response;
            if (request.Method == HttpMethod.Get)
            {
                Check(request.RequestUri.Host == "dev-global.de.t4f.cn" && request.RequestUri.AbsolutePath.EndsWith("IOS_6900"), "startup uses approved dev source path");
                response = "{\"AppVersion\":\"0.69.0\",\"AuthAddrList\":[\"localhost:443\"],\"AddrList\":{\"addr_orig\":\"127.0.0.1:" + port + "\"}}";
            }
            else
            {
                Check(request.RequestUri.Scheme == "https" && request.RequestUri.Host == "localhost" && request.RequestUri.AbsolutePath == "/auth", "authentication comes from startup HTTPS address");
                using (var json = JsonDocument.Parse(await request.Content.ReadAsStringAsync().ConfigureAwait(false)))
                {
                    if (json.RootElement.GetProperty("login_name").GetString() != "anonymous:namede-rewrite-test-contract.0" || json.RootElement.GetProperty("platform_id").GetInt32() != 2) throw new Exception("HTTP authorization source fields");
                }
                response = "{\"code\":0,\"jwt\":\"contract-test-jwt\",\"user_id\":42,\"server_id\":1,\"roleState\":0,\"gate_ip\":\"must-not-use-auth-gate\"}";
            }
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(response, Encoding.UTF8, "application/json") };
        }
    }
    private static async Task<byte[]> Read(NetworkStream stream, int count, CancellationToken token)
    { byte[] bytes = new byte[count]; int offset = 0; while (offset < count) { int n = await stream.ReadAsync(bytes, offset, count - offset, token).ConfigureAwait(false); if (n == 0) throw new EndOfStreamException(); offset += n; } return bytes; }
}
