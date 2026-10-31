using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Linq;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using DE.Infrastructure.Network;

internal static class ProductionFailureSmoke
{
    public static async Task Run()
    {
        foreach (string mode in new[] { "missing-key", "startup-http", "startup-timeout", "auth-http", "auth-rejected", "auth-tls", "auth-dns", "auth-connect", "auth-timeout" })
        {
            using (var handler = new FailureHandler(mode))
            using (var http = new HttpClient(handler))
            using (var connection = new DeProductionConnection(new ProductionSessionOptions("de-rewrite-test-failure", "IOS_6900", "0.69.0"), http))
            {
                try { await connection.BeginSessionAsync().ConfigureAwait(false); throw new Exception("Invalid startup/auth succeeded: " + mode); }
                catch (ProductionConnectionException failure)
                {
                    if (connection.Status.IsLoggedIn || connection.CurrentUser != null || connection.Status.Phase != ProductionConnectionPhase.Faulted) throw new Exception("Failure was not visible: " + mode);
                    if (mode == "startup-timeout" && failure.Message.IndexOf("timed out", StringComparison.Ordinal) < 0) throw new Exception("Internal timeout was reported as caller cancellation.");
                    if (mode == "auth-http" && (handler.AuthCalls != 1 || failure.ErrorCode != 403)) throw new Exception("HTTP failure did not follow source endpoint rotation.");
                    if (mode == "auth-rejected" && failure.ErrorCode != 1126) throw new Exception("Authentication failure lost its actual server code.");
                    if (mode == "auth-tls" || mode == "auth-dns" || mode == "auth-connect" || mode == "auth-timeout")
                    {
                        string expected = mode == "auth-tls" ? "TlsFailure" : mode == "auth-dns" ? "DnsFailure" : mode == "auth-connect" ? "ConnectFailure" : "Timeout";
                        var attempts = connection.Diagnostics.HttpAttempts.Where(a => a.Phase == ProductionConnectionPhase.Authenticating).ToArray();
                        if (attempts.Length != 4 || attempts[3].EndpointIndex != 1 || attempts[3].Attempt != 4 || attempts.Any(a => a.Outcome != expected))
                            throw new Exception("Per-endpoint sanitized transport diagnostics are incomplete: " + mode);
                        string summary = connection.Diagnostics.LastHttpSummary + failure.Message;
                        if (!summary.Contains(expected) || summary.Contains("DO-NOT-LOG") || summary.Contains("https://") || summary.Contains("contract-test-jwt"))
                            throw new Exception("HTTP diagnostic either lost its category or exposed forbidden details.");
                    }
                    Console.WriteLine("PASS failure visible without login or account fallback: " + mode);
                }
            }
        }
        using (var cancellation = new CancellationTokenSource())
        using (var http = new HttpClient(new FailureHandler("must-not-send")))
        using (var connection = new DeProductionConnection(new ProductionSessionOptions("de-rewrite-test-cancelled", "IOS_6900", "0.69.0"), http))
        {
            cancellation.Cancel();
            try { await connection.BeginSessionAsync(cancellation.Token).ConfigureAwait(false); throw new Exception("Cancelled request succeeded."); }
            catch (OperationCanceledException)
            { if (connection.Status.Phase != ProductionConnectionPhase.Disconnected || connection.Status.IsLoggedIn) throw new Exception("Caller cancellation was not visible."); Console.WriteLine("PASS caller cancellation visible before any HTTP request"); }
        }
        Console.WriteLine("FAILURE CONTRACT 10 cases passed (HTTP handlers only, no real endpoints)");
    }
    private sealed class FailureHandler : HttpMessageHandler
    {
        private readonly string mode;
        public int AuthCalls { get; private set; }
        public FailureHandler(string mode) { this.mode = mode; }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (mode == "must-not-send") throw new Exception("Cancelled login attempted network I/O.");
            if (request.Method == HttpMethod.Get)
            {
                if (mode == "startup-timeout") throw new TaskCanceledException("Contract-injected local timeout.");
                if (mode == "startup-http") return Task.FromResult(Response(HttpStatusCode.BadGateway, "unavailable"));
                if (mode == "missing-key") return Task.FromResult(Response(HttpStatusCode.OK, "{\"Error\":\"can not find\"}"));
                return Task.FromResult(Response(HttpStatusCode.OK, "{\"AuthAddrList\":[\"localhost:443\"],\"AddrList\":{\"addr_orig\":\"127.0.0.1:1\"}}"));
            }
            AuthCalls++;
            if (mode == "auth-tls") throw new HttpRequestException("DO-NOT-LOG endpoint or credentials", new AuthenticationException("DO-NOT-LOG token"));
            if (mode == "auth-dns") throw new HttpRequestException("DO-NOT-LOG private hostname", new SocketException((int)SocketError.HostNotFound));
            if (mode == "auth-connect") throw new HttpRequestException("DO-NOT-LOG private endpoint", new SocketException((int)SocketError.ConnectionRefused));
            if (mode == "auth-timeout") throw new TaskCanceledException("DO-NOT-LOG private address");
            return Task.FromResult(mode == "auth-http" ? Response(HttpStatusCode.Forbidden, "forbidden") : Response(HttpStatusCode.OK, "{\"code\":1126}"));
        }
        private static HttpResponseMessage Response(HttpStatusCode status, string body)
        { return new HttpResponseMessage(status) { Content = new StringContent(body, Encoding.UTF8, "application/json") }; }
    }
}
