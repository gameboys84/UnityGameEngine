using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DE.Infrastructure.Network
{
    internal sealed class GatewayAddress
    {
        public string Host; public int Port; public int Retries;
    }
    internal sealed class DevelopmentStartup
    {
        public string[] AuthenticationAddresses;
        public GatewayAddress[] Gateways;
        public string UserIp;
        public JObject Source;
    }
    internal sealed class DevelopmentAuthorization
    {
        public int code { get; set; }
        public string jwt { get; set; }
        public string token { get; set; }
        public long user_id { get; set; }
        public int server_id { get; set; }
        public int roleState { get; set; }
        public int open_sec { get; set; }
        public string user_ip { get; set; }
        public string client_id { get; set; }
        public string account_id { get; set; }
    }
    internal sealed class ProductionHttpBootstrap
    {
        private sealed class DevelopmentHttpStatusException : HttpRequestException
        {
            public int StatusCode { get; }
            public DevelopmentHttpStatusException(int statusCode) : base("Development endpoint HTTP " + statusCode + ".") { StatusCode = statusCode; }
        }
        private readonly HttpClient http;
        private readonly ProductionSessionOptions options;
        private readonly Action<ProductionHttpAttempt> diagnostic;
        private readonly Func<CertificatePolicySnapshot> certificateDiagnostics;
        private readonly Func<Uri, CancellationToken, HttpClient> boundAuthenticationClientFactory;
        private ProductionHttpAttempt lastHttpAttempt;
        public ProductionHttpBootstrap(HttpClient http, ProductionSessionOptions options, Action<ProductionHttpAttempt> diagnostic = null, Func<CertificatePolicySnapshot> certificateDiagnostics = null,
            Func<Uri, CancellationToken, HttpClient> boundAuthenticationClientFactory = null)
        { this.http = http; this.options = options; this.diagnostic = diagnostic; this.certificateDiagnostics = certificateDiagnostics; this.boundAuthenticationClientFactory = boundAuthenticationClientFactory; }
        public async Task<DevelopmentStartup> FetchStartupAsync(CancellationToken cancellationToken)
        {
            JObject source;
            try { source = JObject.Parse(await GetTextAsync(options.StartupUri, null, cancellationToken, ProductionConnectionPhase.FetchingStartup, 1, 1).ConfigureAwait(false)); }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            { throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development startup request timed out."); }
            catch (OperationCanceledException) { throw; }
            catch (DevelopmentHttpStatusException error)
            { throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development startup returned HTTP " + error.StatusCode + ".", error.StatusCode); }
            catch (Exception error) { throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development startup request failed (" + error.GetType().Name + ")."); }
            if (source["Error"] != null) throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development server has no startup configuration for this source version key.");
            if ((long?)source["OpenTime"] > 0) throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development environment is under maintenance.");
            if ((int?)source["NeedUpdate"] > 0) throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development startup requires a client update.");
            string serverVersion = (string)source["AppVersion"];
            if (!string.IsNullOrEmpty(serverVersion) && Version.TryParse(serverVersion, out var required) && Version.TryParse(options.ClientVersion, out var current) && required > current)
                throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development startup requires a newer source client version.");
            var auth = source["AuthAddrList"]?.ToObject<string[]>() ?? new string[0];
            if (auth.Length == 0 && !string.IsNullOrWhiteSpace((string)source["AuthAddr"])) auth = new[] { (string)source["AuthAddr"] };
            if (auth.Length == 0) throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development startup did not supply authentication addresses.");
            foreach (string address in auth) ValidateDevelopmentAddress(address);
            JObject addresses = source["AddrList"] as JObject;
            if (addresses == null) throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development startup did not supply AddrList gateways.");
            var gateways = new List<GatewayAddress>();
            bool china = (int?)source["IsChina"] == 1;
            AddGateway(gateways, (string)addresses[china ? "addr_cn" : "addr_orig"], china ? 4 : 2);
            AddGateway(gateways, (string)addresses["addr_en"], china ? 1 : 2);
            AddGateway(gateways, (string)addresses[china ? "addr_orig" : "addr_cn"], 1);
            if (gateways.Count == 0) throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development startup gateway list is empty.");
            return new DevelopmentStartup { AuthenticationAddresses = auth, Gateways = gateways.ToArray(), UserIp = (string)source["UserIP"], Source = source };
        }
        public async Task<DevelopmentAuthorization> AuthorizeAsync(DevelopmentStartup startup, CancellationToken cancellationToken)
        {
            var request = new {
                action_type = 0, login_name = options.LoginName, pwd = options.Password,
                device_id = options.PlatformId == 2 ? "" : options.DedicatedDeviceId, open_udid = options.DedicatedDeviceId,
                platform_id = (int)options.PlatformId, locale = options.Locale, server_id = 0, user_id = 0L,
                mode = 0, appid = "661646854280321", captcha = "", bit_flag = 1,
                os_version = Environment.OSVersion.VersionString, device_name = "DE rewrite dedicated Editor validation",
                device_id_type = options.PlatformId == 2 ? 1 : 5, ask_verify = true, last_vtime = 0, bundle_id = options.BundleId,
                appChan = options.ChannelId, publishArea = ""
            };
            string body = JsonConvert.SerializeObject(request);
            int lastHttpStatus = 0;
            int endpointIndex = 0;
            foreach (string address in startup.AuthenticationAddresses)
            {
                endpointIndex++;
                ValidateDevelopmentAddress(address);
                // The original authorization route always uses HTTPS, regardless of startup HTTP.
                var uri = new Uri("https://" + address + "/auth");
                for (int attempt = 0; attempt < 4; attempt++)
                {
                    string response;
                    try { response = await GetTextAsync(uri, body, cancellationToken, ProductionConnectionPhase.Authenticating, endpointIndex, attempt + 1).ConfigureAwait(false); }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested) { throw; }
                    // Source CallbackWSAuthorizePoll retries a host only for transport failure (-999), not HTTP status errors.
                    catch (DevelopmentHttpStatusException error) { lastHttpStatus = error.StatusCode; break; }
                    catch { if (attempt == 3) break; continue; }
                    DevelopmentAuthorization authorization;
                    try { authorization = JsonConvert.DeserializeObject<DevelopmentAuthorization>(response); }
                    catch { throw new ProductionConnectionException(ProductionConnectionPhase.Authenticating, "Development authentication response is not a valid source contract."); }
                    if (authorization == null) throw new ProductionConnectionException(ProductionConnectionPhase.Authenticating, "Development authentication returned an empty response.");
                    if (authorization.code != 0) throw new ProductionConnectionException(ProductionConnectionPhase.Authenticating, "Development authentication rejected the request; server code " + authorization.code + ".", authorization.code);
                    if (authorization.user_id <= 0 || string.IsNullOrEmpty(authorization.jwt)) throw new ProductionConnectionException(ProductionConnectionPhase.Authenticating, "Development authentication response lacks user identity or JWT.");
                    return authorization;
                }
            }
            throw new ProductionConnectionException(ProductionConnectionPhase.Authenticating,
                lastHttpStatus != 0 ? "Development authentication endpoints returned HTTP " + lastHttpStatus + "; no account fallback was attempted." :
                "Development authentication failed: " + (lastHttpAttempt?.SafeSummary ?? "no response diagnostic available") + "; no account fallback was attempted.", lastHttpStatus);
        }
        private async Task<string> GetTextAsync(Uri uri, string jsonBody, CancellationToken cancellationToken,
            ProductionConnectionPhase phase, int endpointIndex, int attempt)
        {
            var stopwatch = Stopwatch.StartNew();
            string method = jsonBody == null ? "GET" : "POST";
            int statusCode = 0;
            HttpClient ownedClient = null;
            try
            {
            using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            using (var request = new HttpRequestMessage(jsonBody == null ? HttpMethod.Get : HttpMethod.Post, uri))
            {
                timeout.CancelAfter(TimeSpan.FromSeconds(10));
                if (uri.Scheme == Uri.UriSchemeHttps && boundAuthenticationClientFactory != null) ownedClient = boundAuthenticationClientFactory(uri, timeout.Token);
                // Source LoginMgr sets raw UTF8 bytes only. BestHTTP's RawData branch does NOT set Content-Type.
                // It defaults User-Agent to BestHTTP and Accept-Encoding to gzip, identity.
                if (jsonBody != null) request.Content = new ByteArrayContent(Encoding.UTF8.GetBytes(jsonBody));
                request.Headers.TryAddWithoutValidation("User-Agent", "BestHTTP");
                request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, identity");
                request.Headers.TryAddWithoutValidation("Connection", "Keep-Alive, TE");
                request.Headers.TryAddWithoutValidation("TE", "identity");
                using (var response = await (ownedClient ?? http).SendAsync(request, HttpCompletionOption.ResponseHeadersRead, timeout.Token).ConfigureAwait(false))
                {
                    statusCode = (int)response.StatusCode;
                    if (!response.IsSuccessStatusCode) throw new DevelopmentHttpStatusException((int)response.StatusCode);
                    // Bound buffering and preserve full cancellation, including a server that stalls after headers.
                    using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var memory = new System.IO.MemoryStream())
                    {
                        byte[] buffer = new byte[8192]; int count;
                        while ((count = await stream.ReadAsync(buffer, 0, buffer.Length, timeout.Token).ConfigureAwait(false)) != 0)
                        { if (memory.Length + count > 2 * 1024 * 1024) throw new System.IO.InvalidDataException("Development HTTP response exceeds limit."); memory.Write(buffer, 0, count); }
                        string result = new UTF8Encoding(false, true).GetString(memory.ToArray());
                        Record(CreateAttempt(phase, endpointIndex, attempt, method, statusCode, "Success", "", "", stopwatch.ElapsedMilliseconds));
                        return result;
                    }
                }
            }
            }
            catch (Exception error)
            {
                string category = error is OperationCanceledException ? (cancellationToken.IsCancellationRequested ? "Cancelled" : "Timeout") :
                    error is DevelopmentHttpStatusException ? "HttpError" : "TransportFailure";
                var types = new List<string>(); string socketError = "";
                for (Exception current = error; current != null && types.Count < 8; current = current.InnerException)
                {
                    types.Add(current.GetType().Name);
                    if (current is AuthenticationException || current.GetType().Name.IndexOf("Tls", StringComparison.OrdinalIgnoreCase) >= 0)
                        category = "TlsFailure";
                    if (current is WebException web && (web.Status == WebExceptionStatus.TrustFailure || web.Status == WebExceptionStatus.SecureChannelFailure)) category = "TlsFailure";
                    if (current is SocketException socket)
                    {
                        socketError = socket.SocketErrorCode.ToString();
                        if (category != "TlsFailure") category = socket.SocketErrorCode == SocketError.HostNotFound || socket.SocketErrorCode == SocketError.NoData || socket.SocketErrorCode == SocketError.TryAgain ? "DnsFailure" : "ConnectFailure";
                    }
                }
                Record(CreateAttempt(phase, endpointIndex, attempt, method, statusCode, category, string.Join(">", types), socketError, stopwatch.ElapsedMilliseconds));
                throw;
            }
            finally { ownedClient?.Dispose(); }
        }
        private void Record(ProductionHttpAttempt attempt) { lastHttpAttempt = attempt; diagnostic?.Invoke(attempt); }
        private ProductionHttpAttempt CreateAttempt(ProductionConnectionPhase phase, int endpointIndex, int attempt, string method,
            int status, string outcome, string types, string socketError, long elapsed)
        {
            var certificate = certificateDiagnostics?.Invoke();
            return new ProductionHttpAttempt(phase, endpointIndex, attempt, method, status, outcome, types, socketError, elapsed,
                certificate?.Policy ?? "ExternalHttpClient", certificate?.Errors ?? "NotObserved", certificate?.ValidationCount ?? 0, certificate?.CompatibilityCount ?? 0);
        }
        private static void AddGateway(List<GatewayAddress> gateways, string address, int retries)
        {
            if (string.IsNullOrWhiteSpace(address)) return;
            ValidateDevelopmentAddress(address);
            if (!Uri.TryCreate("tcp://" + address, UriKind.Absolute, out var uri) || uri.Port < 1 || uri.Port > 65535)
                throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development gateway address is invalid.");
            gateways.Add(new GatewayAddress { Host = uri.Host, Port = uri.Port, Retries = retries });
        }
        private static void ValidateDevelopmentAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address) || address.IndexOf('/') >= 0 || address.IndexOf('@') >= 0 ||
                address.IndexOf("online", StringComparison.OrdinalIgnoreCase) >= 0 || address.IndexOf("portal-platform", StringComparison.OrdinalIgnoreCase) >= 0 ||
                address.IndexOf("c60206", StringComparison.OrdinalIgnoreCase) >= 0)
                throw new ProductionConnectionException(ProductionConnectionPhase.FetchingStartup, "Development startup supplied a forbidden or invalid endpoint.");
        }
    }
}
