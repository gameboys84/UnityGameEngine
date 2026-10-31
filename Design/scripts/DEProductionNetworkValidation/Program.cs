using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using DE.Infrastructure.Network;

internal static class Program
{
    private static int passed;
    private static void Check(bool value, string name) { if (!value) throw new Exception(name); passed++; Console.WriteLine("PASS " + name); }
    private static async Task Main()
    {
        DeWireCodec.Initialize();
        Check(Protocol.Ver == 72 && Protocol.RunVer == 72, "original protocol v72 initialized");
        var options = new ProductionSessionOptions("de-rewrite-test-wire", "IOS_6900", "0.69.0");
        Check(options.StartupUri.Host == "dev-global.de.t4f.cn" && options.PlatformId == 2 && options.ChannelId == 0 && options.StartupVersionNumber == 6900, "source Editor version/platform contract");
        try { new ProductionSessionOptions("existing-account", "IOS_6900", "0.69.0"); Check(false, "dedicated identity required"); } catch (ArgumentException) { Check(true, "dedicated identity required"); }
        try { new ProductionSessionOptions("de-rewrite-test-wire", "IOS_6800", "0.69.0"); Check(false, "mismatched version rejected"); } catch (ArgumentException) { Check(true, "mismatched version rejected"); }
        byte[] body = DeWireCodec.EncodeBody(Protocol.MsgType.CONST_REQ, new Protocol.ConstReq { m_keyword = "max_building_level" }, 23);
        var frame = DeWireCodec.FrameBody(body); int offset = 0;
        Check(NetworkSerialization.ReadUInt16(frame, ref offset) == body.Length && frame[2] == 0 && frame[3] == 23 && frame[4] == 1 && frame[5] == 54, "original node/type big-endian framing");
        var constant = (Protocol.ConstReq)DeWireCodec.DecodeBody(body, out var type);
        Check(type == Protocol.MsgType.CONST_REQ && constant.m_keyword == "max_building_level" && constant.m_nodId == 23, "original SPack generated string roundtrip");
        foreach (var malformedType in new[] { Protocol.MsgType.TIME_NTF, Protocol.MsgType.LOGIN_ACK, Protocol.MsgType.COMMON_ACK })
        {
            byte[] malformed = new byte[4]; int malformedOffset = 0;
            NetworkSerialization.Write(ref malformed, ref malformedOffset, (ushort)0); NetworkSerialization.Write(ref malformed, ref malformedOffset, (ushort)malformedType);
            try { DeWireCodec.DecodeBody(malformed, out _); Check(false, "known payload rejects header-only " + malformedType); }
            catch (Exception error) when (error is InvalidDataException || error is ArgumentException || error is IndexOutOfRangeException) { Check(true, "known payload rejects header-only " + malformedType); }
        }
        var token = new Protocol.SessionTokenInfo { m_key1 = 0x83456789, m_key2 = 0xfedcba98, m_id = 123 };
        var decodedToken = (Protocol.SessionTokenInfo)DeWireCodec.DecodeBody(DeWireCodec.EncodeBody(Protocol.MsgType.SESSION_TOKEN_NTF, token), out _);
        Check(decodedToken.m_key1 == token.m_key1 && decodedToken.m_key2 == token.m_key2 && decodedToken.m_id == token.m_id, "original token field order");
        uint key = DeWireCodec.DerivePikeKey(token.m_key1, token.m_key2);
        var original = Enumerable.Range(0, 10000).Select(i => (byte)i).ToArray(); var one = (byte[])original.Clone(); var split = (byte[])original.Clone();
        new Pike(key).Codec(one, 0, one.Length); var state = new Pike(key); state.Codec(split, 0, 3); state.Codec(split, 3, 5000); state.Codec(split, 5003, split.Length - 5003);
        Check(one.SequenceEqual(split), "Pike stream independent of socket chunk boundaries"); new Pike(key).Codec(one, 0, one.Length);
        Check(one.SequenceEqual(original), "independent directional Pike instance decodes original bytes");
        var large = new byte[70000]; offset = 0; NetworkSerialization.Write(ref large, ref offset, (ushort)10023); NetworkSerialization.Write(ref large, ref offset, (ushort)60000);
        var largeFrame = DeWireCodec.FrameBody(large); offset = 0;
        Check(NetworkSerialization.ReadUInt16(largeFrame, ref offset) == 65535 && NetworkSerialization.ReadInt32(largeFrame, ref offset) == large.Length, "original extended-length frame");
        var unknown = (UnknownProtocolMessage)DeWireCodec.DecodeBody(large, out _);
        Check(unknown.m_nodId == 23 && unknown.RawBody.SequenceEqual(large), "unknown full payload retained and source node normalized");
        await CheckTcp(token, key, large).ConfigureAwait(false);
        await ProductionBeginSmoke.Run().ConfigureAwait(false);
        await ProductionFailureSmoke.Run().ConfigureAwait(false);
        Console.WriteLine("TOTAL " + passed + " passed");
    }
    private static async Task CheckTcp(Protocol.SessionTokenInfo token, uint key, byte[] large)
    {
        using (var timeout = new CancellationTokenSource(10000))
        {
            var listener = new TcpListener(IPAddress.Loopback, 0); listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            var tokenSeen = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var allSeen = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            int acknowledgements = 0; bool largeReceived = false;
            using (var client = new DeTcpSession())
            {
                client.MessageReceived += (message, bytes) => {
                    if (message is Protocol.SessionTokenInfo) tokenSeen.TrySetResult(true);
                    if (message is Protocol.CommonAckInfo ack && ack.m_api == (short)Protocol.MsgType.HEART_BEAT_REQ) Interlocked.Increment(ref acknowledgements);
                    if (message is UnknownProtocolMessage unknown && unknown.RawBody.Length == 70000) largeReceived = true;
                    if (acknowledgements == 2 && largeReceived) allSeen.TrySetResult(true);
                };
                Task server = Task.Run(async () => {
                    using (var accepted = await listener.AcceptTcpClientAsync().ConfigureAwait(false))
                    using (var stream = accepted.GetStream())
                    {
                        byte[] clearToken = DeWireCodec.FrameBody(DeWireCodec.EncodeBody(Protocol.MsgType.SESSION_TOKEN_NTF, token));
                        await stream.WriteAsync(clearToken, 0, 1, timeout.Token).ConfigureAwait(false);
                        await stream.WriteAsync(clearToken, 1, 4, timeout.Token).ConfigureAwait(false);
                        await stream.WriteAsync(clearToken, 5, clearToken.Length - 5, timeout.Token).ConfigureAwait(false);
                        byte[] head = await Read(stream, 2, timeout.Token); int position = 0;
                        byte[] heartbeat = await Read(stream, NetworkSerialization.ReadUInt16(head, ref position), timeout.Token);
                        new Pike(key).Codec(heartbeat, 0, heartbeat.Length);
                        var decoded = DeWireCodec.DecodeBody(heartbeat, out var heartbeatType);
                        Check(heartbeatType == Protocol.MsgType.HEART_BEAT_REQ && decoded.m_nodId == 0, "client sends original encrypted heartbeat");
                        var cipher = new Pike(key);
                        foreach (bool four in new[] { false, true })
                        {
                            byte[] inner = DeWireCodec.EncodeBody(Protocol.MsgType.COMMON_ACK, new Protocol.CommonAckInfo { m_api = (short)Protocol.MsgType.HEART_BEAT_REQ, m_code = 0 });
                            byte[] compressed = LZ4ps.LZ4Codec.Encode64(inner, 0, inner.Length);
                            byte[] outer = new byte[(four ? 12 : 10) + compressed.Length]; position = 0;
                            NetworkSerialization.Write(ref outer, ref position, (ushort)0);
                            NetworkSerialization.Write(ref outer, ref position, (ushort)(four ? Protocol.MsgType.COMPRESSED4B_NTF : Protocol.MsgType.COMPRESSED_NTF));
                            NetworkSerialization.Write(ref outer, ref position, inner.Length);
                            if (four) NetworkSerialization.Write(ref outer, ref position, compressed.Length); else NetworkSerialization.Write(ref outer, ref position, (ushort)compressed.Length);
                            Buffer.BlockCopy(compressed, 0, outer, position, compressed.Length); cipher.Codec(outer, 0, outer.Length);
                            byte[] framed = DeWireCodec.FrameBody(outer);
                            await stream.WriteAsync(framed, 0, framed.Length, timeout.Token).ConfigureAwait(false);
                        }
                        byte[] encryptedLarge = (byte[])large.Clone(); cipher.Codec(encryptedLarge, 0, encryptedLarge.Length);
                        byte[] bigFrame = DeWireCodec.FrameBody(encryptedLarge);
                        await stream.WriteAsync(bigFrame, 0, 3, timeout.Token).ConfigureAwait(false);
                        await stream.WriteAsync(bigFrame, 3, bigFrame.Length - 3, timeout.Token).ConfigureAwait(false);
                        await allSeen.Task.WaitAsync(timeout.Token).ConfigureAwait(false);
                    }
                });
                await client.ConnectAsync("127.0.0.1", port, timeout.Token).ConfigureAwait(false);
                await tokenSeen.Task.WaitAsync(timeout.Token).ConfigureAwait(false);
                Check(client.EncryptionActive, "token switches both directional ciphers before next packet");
                await client.SendAsync(Protocol.MsgType.HEART_BEAT_REQ, null, 0, timeout.Token).ConfigureAwait(false);
                await allSeen.Task.WaitAsync(timeout.Token).ConfigureAwait(false);
                Check(acknowledgements == 2 && largeReceived, "fragmented token, both LZ4 wrappers, combined stream and extended frame decoded");
                await server.ConfigureAwait(false);
            }
            listener.Stop();
        }
    }
    private static async Task<byte[]> Read(NetworkStream stream, int count, CancellationToken token)
    { byte[] bytes = new byte[count]; int offset = 0; while (offset < count) { int n = await stream.ReadAsync(bytes, offset, count - offset, token).ConfigureAwait(false); if (n == 0) throw new EndOfStreamException(); offset += n; } return bytes; }
}
