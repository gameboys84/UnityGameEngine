using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace DE.Infrastructure.Network
{
    public static class DeProductionClientFactory
    {
        public static DeProductionConnection CreateDevelopment(string dedicatedDeviceId, string versionKey, string clientVersion)
        { return new DeProductionConnection(new ProductionSessionOptions(dedicatedDeviceId, versionKey, clientVersion)); }
    }

    public sealed class DeProductionConnection : IDisposable
    {
        private sealed class QueuedMessage { public long Generation; public NetworkMessage Message; public int Bytes; }
        private readonly ProductionSessionOptions options;
        private readonly HttpClient http;
        private readonly bool ownsHttp;
        private readonly DevelopmentCertificatePolicy certificatePolicy;
        private readonly CancellationTokenSource lifetime = new CancellationTokenSource();
        private readonly SemaphoreSlim lifecycleLock = new SemaphoreSlim(1, 1);
        private readonly ConcurrentQueue<QueuedMessage> incoming = new ConcurrentQueue<QueuedMessage>();
        private readonly ConcurrentQueue<ProductionConnectionStatus> statuses = new ConcurrentQueue<ProductionConnectionStatus>();
        private readonly ConcurrentQueue<ProductionHttpAttempt> httpAttempts = new ConcurrentQueue<ProductionHttpAttempt>();
        private readonly object transportLock = new object();
        private DeTcpSession transport;
        private DevelopmentStartup startup;
        private DevelopmentAuthorization authorization;
        private CancellationToken activeLoginCancellation;
        private long generation;
        private int pendingCount, reconnecting, beginRequested;
        private long pendingBytes;
        private volatile bool disposed, isLoggedIn, heartbeatOutstanding;
        private long lastHeartbeatTimestamp;
        private int reconnectAttempts;
        private volatile ProductionConnectionStatus status = new ProductionConnectionStatus(ProductionConnectionPhase.Created, "Real DE development connection; not connected.", false);
        private Protocol.UserInfo currentUser;
        public ProductionConnectionStatus Status => status;
        public long CurrentSessionGeneration => Interlocked.Read(ref generation);
        public Protocol.UserInfo CurrentUser => Volatile.Read(ref currentUser);
        public ProtocolStateStore RawState { get; } = new ProtocolStateStore();
        public event Action<ProductionConnectionStatus> StatusChanged;
        public event Action<NetworkMessage> MessageReceived;
        public event Action SessionInvalidated;
        public DeProductionConnection(ProductionSessionOptions options, HttpClient httpClient = null)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
            ownsHttp = httpClient == null;
            certificatePolicy = new DevelopmentCertificatePolicy(options);
            // Original BestHTTP HTTPManager.Proxy is null and HTTPRequest copies that value.
            // The fixed dev route must not inherit tool-process placeholder HTTP(S)_PROXY values.
            if (httpClient != null) http = httpClient;
            else
            {
                var handler = new HttpClientHandler { AllowAutoRedirect = false, UseProxy = false, AutomaticDecompression = DecompressionMethods.GZip };
                http = new HttpClient(handler);
            }
        }
        public ProductionDiagnostics Diagnostics
        {
            get
            {
                var active = transport;
                var certificate = certificatePolicy.Snapshot();
                return new ProductionDiagnostics { ReceivedPackets = active?.ReceivedPackets ?? 0, SentPackets = active?.SentPackets ?? 0,
                    ReceivedBytes = active?.ReceivedBytes ?? 0, SentBytes = active?.SentBytes ?? 0,
                    PendingMessages = Volatile.Read(ref pendingCount), ReconnectAttempts = reconnectAttempts, EncryptionActive = active?.EncryptionActive ?? false,
                    HttpAttempts = httpAttempts.ToArray(), CertificatePolicy = certificate.Policy, CertificatePolicyAttached = certificate.Attached,
                    LastSslPolicyErrors = certificate.Errors, LastCertificateDecision = certificate.Decision,
                    CertificateValidationCount = certificate.ValidationCount, CertificateCompatibilityCount = certificate.CompatibilityCount,
                    CertificateRejectionCount = certificate.RejectionCount };
            }
        }
        public async Task BeginSessionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureAlive();
            // A duplicate UI click must not enter the failure cleanup and tear down a valid login.
            if (Interlocked.CompareExchange(ref beginRequested, 1, 0) != 0)
                throw new InvalidOperationException("This production connection already started. Dispose it before starting another identity.");
            if (cancellationToken.IsCancellationRequested)
            { SetStatus(ProductionConnectionPhase.Disconnected, "Connection attempt cancelled."); cancellationToken.ThrowIfCancellationRequested(); }
            using (var linked = CancellationTokenSource.CreateLinkedTokenSource(lifetime.Token, cancellationToken))
            {
                await lifecycleLock.WaitAsync(linked.Token).ConfigureAwait(false);
                try
                {
                    DeWireCodec.Initialize();
                    var bootstrap = new ProductionHttpBootstrap(http, options, RecordHttpAttempt, certificatePolicy.Snapshot,
                        ownsHttp ? (Func<Uri, CancellationToken, HttpClient>)CreateBoundAuthenticationClient : null);
                    SetStatus(ProductionConnectionPhase.FetchingStartup, "Fetching original DE development startup configuration.");
                    startup = await bootstrap.FetchStartupAsync(linked.Token).ConfigureAwait(false);
                    certificatePolicy.RegisterAuthenticationAuthorities(startup.AuthenticationAddresses);
                    SetStatus(ProductionConnectionPhase.Authenticating, "Authenticating the dedicated development test identity.");
                    authorization = await bootstrap.AuthorizeAsync(startup, linked.Token).ConfigureAwait(false);
                    await LoginGatewaysAsync(linked.Token).ConfigureAwait(false);
                    linked.Token.ThrowIfCancellationRequested();
                    // This increment ends at verified LOGIN_ACK. No loading coordinator, city or gameplay entry runs here.
                }
                catch (OperationCanceledException) { if (!disposed) SetStatus(ProductionConnectionPhase.Disconnected, "Connection attempt cancelled."); CloseTransport(); throw; }
                catch (Exception error)
                {
                    CloseTransport();
                    var failure = error as ProductionConnectionException;
                    SetStatus(ProductionConnectionPhase.Faulted, failure?.Message ?? "DE connection failed (" + error.GetType().Name + ").", failure?.ErrorCode ?? 0);
                    throw;
                }
                finally { lifecycleLock.Release(); }
            }
        }
        private async Task LoginGatewaysAsync(CancellationToken cancellationToken)
        {
            foreach (var gateway in startup.Gateways)
            {
                for (int attempt = 0; attempt <= gateway.Retries; attempt++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    CloseTransport();
                    long attemptGeneration = Interlocked.Increment(ref generation);
                    activeLoginCancellation = cancellationToken;
                    var session = new DeTcpSession();
                    var tokenReady = new TaskCompletionSource<Protocol.SessionTokenInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
                    var loginReady = new TaskCompletionSource<Protocol.UserInfo>(TaskCreationOptions.RunContinuationsAsynchronously);
                    lock (transportLock) transport = session;
                    session.MessageReceived += (message, bytes) => Receive(session, attemptGeneration, message, bytes, tokenReady, loginReady);
                    session.Disconnected += safeReason =>
                    {
                        if (!ReferenceEquals(transport, session) || disposed) return;
                        var failure = new ProductionConnectionException(ProductionConnectionPhase.Disconnected, safeReason);
                        tokenReady.TrySetException(failure); loginReady.TrySetException(failure);
                        bool wasLoggedIn = isLoggedIn;
                        CloseTransport();
                        SetStatus(ProductionConnectionPhase.Disconnected, safeReason);
                        if (wasLoggedIn) _ = ReconnectAsync();
                    };
                    try
                    {
                        SetStatus(ProductionConnectionPhase.ConnectingGateway, "Connecting to a gateway supplied by development AddrList.");
                        var stopwatch = Stopwatch.StartNew();
                        await session.ConnectAsync(gateway.Host, gateway.Port, cancellationToken).ConfigureAwait(false);
                        SetStatus(ProductionConnectionPhase.WaitingSessionToken, "TCP connected; waiting for the original session token.");
                        int remaining = Math.Max(1, 5000 - (int)stopwatch.ElapsedMilliseconds);
                        await AwaitWithTimeout(tokenReady.Task, remaining, cancellationToken).ConfigureAwait(false);
                        SetStatus(ProductionConnectionPhase.LoggingIn, "Sending original LOGIN_REQ with protocol version " + Protocol.Ver + ".");
                        await session.SendAsync(Protocol.MsgType.LOGIN_REQ, BuildLoginRequest(), 0, cancellationToken).ConfigureAwait(false);
                        await AwaitWithTimeout(loginReady.Task, 30000, cancellationToken).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested();
                        if (!ReferenceEquals(transport, session) || !isLoggedIn || !session.IsConnected)
                            throw new ProductionConnectionException(ProductionConnectionPhase.Disconnected, "Gateway closed before login completion could be confirmed.");
                        return;
                    }
                    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested) { session.Dispose(); throw; }
                    catch (ProductionConnectionException failure) when (failure.ErrorCode != 0 || failure.Phase == ProductionConnectionPhase.LoggingIn) { session.Dispose(); throw; }
                    catch
                    {
                        session.Dispose(); Interlocked.Increment(ref reconnectAttempts);
                        if (attempt < gateway.Retries) await Task.Delay(1000 + Math.Min(10000, reconnectAttempts * 500), cancellationToken).ConfigureAwait(false);
                    }
                }
            }
            throw new ProductionConnectionException(ProductionConnectionPhase.ConnectingGateway, "All development AddrList gateways failed or did not complete the original session-token/login exchange.");
        }
        private void Receive(DeTcpSession source, long messageGeneration, NetworkMessage message, int bytes,
            TaskCompletionSource<Protocol.SessionTokenInfo> tokenReady, TaskCompletionSource<Protocol.UserInfo> loginReady)
        {
            if (disposed || !ReferenceEquals(transport, source) || messageGeneration != Interlocked.Read(ref generation)) return;
            Protocol.MsgType type = message.GetMessageType();
            if (message is Protocol.SessionTokenInfo token) tokenReady.TrySetResult(token);
            else if (type == Protocol.MsgType.LOGIN_ACK && message is Protocol.UserInfo user)
            {
                if (activeLoginCancellation.IsCancellationRequested) return;
                if (authorization == null || user.m_id <= 0 || user.m_id != authorization.user_id)
                {
                    isLoggedIn = false;
                    loginReady.TrySetException(new ProductionConnectionException(ProductionConnectionPhase.LoggingIn,
                        "Gateway LOGIN_ACK does not identify the role selected by development authentication."));
                    source.Dispose();
                    return; // Rejected identity is never published to business reducers or RawState.
                }
                Volatile.Write(ref currentUser, user); isLoggedIn = true; heartbeatOutstanding = false;
                Interlocked.Exchange(ref lastHeartbeatTimestamp, Stopwatch.GetTimestamp());
                SetStatus(ProductionConnectionPhase.LoginAck, "Real DE LOGIN_ACK received and verified against development authentication. Login completed.");
                loginReady.TrySetResult(user);
            }
            else if (message is Protocol.CommonAckInfo ack)
            {
                if (ack.m_api == (short)Protocol.MsgType.LOGIN_REQ && ack.m_code != 0)
                    loginReady.TrySetException(new ProductionConnectionException(ProductionConnectionPhase.LoggingIn, "Development LOGIN_REQ rejected; server code " + ack.m_code + ".", ack.m_code));
                if (ack.m_api == (short)Protocol.MsgType.HEART_BEAT_REQ) heartbeatOutstanding = false;
            }
            if (type == Protocol.MsgType.CONNECT_KICK_NTF || type == Protocol.MsgType.SHUT_DOWN_NTF)
            {
                CloseTransport();
                SetStatus(ProductionConnectionPhase.Faulted, "Development server sent " + type + "; automatic account fallback is disabled.");
                return;
            }
            int queuedCount = Interlocked.Increment(ref pendingCount);
            long queuedBytes = Interlocked.Add(ref pendingBytes, bytes);
            if (queuedCount > 1024 || queuedBytes > 16 * 1024 * 1024)
            {
                Interlocked.Decrement(ref pendingCount); Interlocked.Add(ref pendingBytes, -bytes);
                throw new InvalidOperationException("DE incoming message budget exceeded; connection closed instead of dropping state.");
            }
            incoming.Enqueue(new QueuedMessage { Generation = messageGeneration, Message = message, Bytes = bytes });
        }
        private Protocol.LoginInfo BuildLoginRequest()
        {
            string ip = !string.IsNullOrWhiteSpace(startup.UserIp) ? startup.UserIp : authorization.user_ip;
            if (string.IsNullOrWhiteSpace(ip) || ip.Length > 46) ip = "0.0.0.0";
            return new Protocol.LoginInfo {
                m_pvc_ver = (uint)Protocol.Ver, m_account_type = 1, m_token = authorization.jwt,
                m_login_name = options.LoginName, m_ip = ip, m_client_version = options.ClientVersion,
                m_os_version = Environment.OSVersion.VersionString, m_device_name = "DE rewrite dedicated Editor validation",
                m_device_id = options.PlatformId == 2 ? "" : options.DedicatedDeviceId, m_device_id_type = options.PlatformId == 2 ? 1 : 5, m_locale = options.Locale,
                m_open_udid = options.DedicatedDeviceId, m_platform_id = options.PlatformId,
                m_user_id = authorization.user_id, m_mode = checked((sbyte)authorization.roleState),
                m_server_id = checked((short)authorization.server_id), m_device_id_type_str = options.PlatformId == 1 ? "ANDROID" : "IOS",
                m_bundle_id = options.BundleId, m_publisher_channel = options.ChannelId, m_locale_lang = options.Locale,
                m_device_state = -1, m_is_simulator = -1, m_latitude = 999900, m_longitude = 999900, m_altitude = 999900,
                m_network_type = "WIFI", m_attribute = ""
            };
        }
        public async Task SendAsync(Protocol.MsgType type, NetworkMessage payload, short nodeId = 0, CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureAlive();
            var active = transport;
            if (!isLoggedIn || active == null) throw new InvalidOperationException("DE gameplay commands require a real LOGIN_ACK.");
            await active.SendAsync(type, payload, nodeId, cancellationToken).ConfigureAwait(false);
        }
        // All public message and status callbacks are dispatched only here, on the caller's Unity main thread.
        public void Pump(int maximumMessages = 45)
        {
            if (disposed) return;
            if (maximumMessages < 1 || maximumMessages > 1024) throw new ArgumentOutOfRangeException(nameof(maximumMessages));
            // Close invalidates logical ownership immediately; dictionary mutation and notifications remain on this host thread.
            if (RawState.Generation != CurrentSessionGeneration)
            { RawState.Reset(CurrentSessionGeneration); SessionInvalidated?.Invoke(); }
            for (int i = 0; i < maximumMessages && incoming.TryDequeue(out var item); i++)
            {
                Interlocked.Decrement(ref pendingCount); Interlocked.Add(ref pendingBytes, -item.Bytes);
                if (item.Generation != Interlocked.Read(ref generation)) continue;
                if (RawState.Generation != item.Generation) { RawState.Reset(item.Generation); SessionInvalidated?.Invoke(); }
                RawState.Receive(item.Message); MessageReceived?.Invoke(item.Message);
            }
            while (statuses.TryDequeue(out var update))
                if (update.SessionGeneration == 0 || update.SessionGeneration == CurrentSessionGeneration) StatusChanged?.Invoke(update);
            if (!isLoggedIn || transport == null) return;
            double elapsed = (Stopwatch.GetTimestamp() - Interlocked.Read(ref lastHeartbeatTimestamp)) / (double)Stopwatch.Frequency;
            if (elapsed < 15) return;
            if (heartbeatOutstanding)
            {
                SetStatus(ProductionConnectionPhase.Disconnected, "Original heartbeat acknowledgement timed out.");
                _ = ReconnectAsync(); return;
            }
            heartbeatOutstanding = true; Interlocked.Exchange(ref lastHeartbeatTimestamp, Stopwatch.GetTimestamp());
            _ = SendHeartbeatAsync();
        }
        private async Task SendHeartbeatAsync()
        {
            try { await SendAsync(Protocol.MsgType.HEART_BEAT_REQ, null, 0, lifetime.Token).ConfigureAwait(false); }
            catch { if (!disposed) await ReconnectAsync().ConfigureAwait(false); }
        }
        public async Task ReconnectAsync()
        {
            if (disposed || authorization == null || startup == null || Interlocked.Exchange(ref reconnecting, 1) != 0) return;
            isLoggedIn = false;
            try
            {
                await lifecycleLock.WaitAsync(lifetime.Token).ConfigureAwait(false);
                try
                {
                    CloseTransport();
                    int count = Interlocked.Increment(ref reconnectAttempts);
                    await Task.Delay(1000 + Math.Min(10000, count * 500), lifetime.Token).ConfigureAwait(false);
                    await LoginGatewaysAsync(lifetime.Token).ConfigureAwait(false);
                    // LoginAck remains the final phase; later gameplay loading is outside this increment.
                }
                finally { lifecycleLock.Release(); }
            }
            catch (OperationCanceledException) { }
            catch (Exception error) { if (!disposed) SetStatus(ProductionConnectionPhase.Faulted, "Development reconnect failed (" + error.GetType().Name + "); no account or offline fallback was used."); }
            finally { Interlocked.Exchange(ref reconnecting, 0); }
        }
        private static async Task<T> AwaitWithTimeout<T>(Task<T> task, int milliseconds, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                var delay = Task.Delay(milliseconds, timeout.Token);
                if (await Task.WhenAny(task, delay).ConfigureAwait(false) != task)
                { cancellationToken.ThrowIfCancellationRequested(); throw new TimeoutException("DE source handshake phase timed out."); }
                timeout.Cancel();
                T result = await task.ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return result;
            }
        }
        private void SetStatus(ProductionConnectionPhase phase, string safeMessage, int errorCode = 0)
        { var update = new ProductionConnectionStatus(phase, safeMessage, isLoggedIn, errorCode, CurrentSessionGeneration); status = update; statuses.Enqueue(update); }
        private void RecordHttpAttempt(ProductionHttpAttempt attempt)
        { httpAttempts.Enqueue(attempt); while (httpAttempts.Count > 64) httpAttempts.TryDequeue(out _); }
        private HttpClient CreateBoundAuthenticationClient(Uri requestUri, CancellationToken cancellationToken)
        {
            EnsureAlive();
            var handler = new HttpClientHandler { AllowAutoRedirect = false, UseProxy = false, AutomaticDecompression = DecompressionMethods.GZip };
            var binding = certificatePolicy.Attach(handler, requestUri, cancellationToken);
            return new BoundAuthenticationClient(handler, binding);
        }
        private sealed class BoundAuthenticationClient : HttpClient
        {
            private readonly IDisposable binding;
            internal BoundAuthenticationClient(HttpClientHandler handler, IDisposable binding) : base(handler) { this.binding = binding; }
            protected override void Dispose(bool disposing)
            { if (disposing) binding.Dispose(); base.Dispose(disposing); }
        }
        private void CloseTransport()
        {
            DeTcpSession active;
            lock (transportLock)
            {
                active = transport; transport = null;
                if (active != null) Interlocked.Increment(ref generation);
            }
            isLoggedIn = false; heartbeatOutstanding = false; Volatile.Write(ref currentUser, null); active?.Dispose();
        }
        public void Dispose()
        {
            if (disposed) return; disposed = true; lifetime.Cancel(); CloseTransport();
            Volatile.Write(ref currentUser, null); authorization = null; startup = null;
            while (incoming.TryDequeue(out _)) { }
            pendingCount = 0; pendingBytes = 0; RawState.Reset(Interlocked.Increment(ref generation));
            status = new ProductionConnectionStatus(ProductionConnectionPhase.Disposed, "DE connection disposed.", false);
            if (ownsHttp) http.Dispose();
            certificatePolicy.Dispose();
            StatusChanged = null; MessageReceived = null; SessionInvalidated = null;
        }
        private void EnsureAlive() { if (disposed) throw new ObjectDisposedException(nameof(DeProductionConnection)); }
    }
}
