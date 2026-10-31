using System;
using System.Collections.Generic;

namespace DE.Infrastructure.Network
{
    public enum ProductionConnectionPhase
    {
        Created, FetchingStartup, Authenticating, ConnectingGateway, WaitingSessionToken,
        LoggingIn, LoginAck, DataLoading, CityReady, Disconnected, Faulted, Disposed
    }
    public sealed class ProductionConnectionStatus
    {
        public ProductionConnectionPhase Phase { get; }
        public string Message { get; }
        public bool IsLoggedIn { get; }
        public int ErrorCode { get; }
        public long SessionGeneration { get; }
        internal ProductionConnectionStatus(ProductionConnectionPhase phase, string message, bool loggedIn, int errorCode = 0, long sessionGeneration = 0)
        { Phase = phase; Message = message; IsLoggedIn = loggedIn; ErrorCode = errorCode; SessionGeneration = sessionGeneration; }
    }
    public sealed class ProductionDiagnostics
    {
        public int ProtocolVersion => Protocol.Ver;
        public string Environment => "dev";
        public long ReceivedPackets { get; internal set; }
        public long SentPackets { get; internal set; }
        public long ReceivedBytes { get; internal set; }
        public long SentBytes { get; internal set; }
        public int PendingMessages { get; internal set; }
        public int ReconnectAttempts { get; internal set; }
        public bool EncryptionActive { get; internal set; }
        public ProductionHttpAttempt[] HttpAttempts { get; internal set; } = new ProductionHttpAttempt[0];
        public string LastHttpSummary => HttpAttempts.Length == 0 ? "" : HttpAttempts[HttpAttempts.Length - 1].SafeSummary;
        public string CertificatePolicy { get; internal set; }
        public bool CertificatePolicyAttached { get; internal set; }
        public string LastSslPolicyErrors { get; internal set; }
        public string LastCertificateDecision { get; internal set; }
        public int CertificateValidationCount { get; internal set; }
        public int CertificateCompatibilityCount { get; internal set; }
        public int CertificateRejectionCount { get; internal set; }
    }
    public sealed class ProductionHttpAttempt
    {
        public ProductionConnectionPhase Phase { get; }
        public int EndpointIndex { get; }
        public int Attempt { get; }
        public string Method { get; }
        public int HttpStatus { get; }
        public string Outcome { get; }
        public string ExceptionTypes { get; }
        public string SocketError { get; }
        public long ElapsedMilliseconds { get; }
        public string CertificatePolicy { get; }
        public string SslPolicyErrors { get; }
        public int CertificateValidationCount { get; }
        public int CertificateCompatibilityCount { get; }
        public string SafeSummary => Phase + " endpoint#" + EndpointIndex + " attempt#" + Attempt + " " + Method +
            " " + Outcome + " HTTP=" + HttpStatus + (string.IsNullOrEmpty(ExceptionTypes) ? "" : " [" + ExceptionTypes + "]") +
            (string.IsNullOrEmpty(SocketError) ? "" : " socket=" + SocketError) +
            (string.IsNullOrEmpty(CertificatePolicy) ? "" : " certPolicy=" + CertificatePolicy + " ssl=" + SslPolicyErrors + " certChecks=" + CertificateValidationCount + " compat=" + CertificateCompatibilityCount);
        internal ProductionHttpAttempt(ProductionConnectionPhase phase, int endpointIndex, int attempt, string method,
            int httpStatus, string outcome, string exceptionTypes, string socketError, long elapsedMilliseconds,
            string certificatePolicy = "", string sslPolicyErrors = "NotObserved", int certificateValidationCount = 0, int certificateCompatibilityCount = 0)
        { Phase = phase; EndpointIndex = endpointIndex; Attempt = attempt; Method = method; HttpStatus = httpStatus;
            Outcome = outcome; ExceptionTypes = exceptionTypes; SocketError = socketError; ElapsedMilliseconds = elapsedMilliseconds;
            CertificatePolicy = certificatePolicy; SslPolicyErrors = sslPolicyErrors; CertificateValidationCount = certificateValidationCount; CertificateCompatibilityCount = certificateCompatibilityCount; }
    }
    public sealed class ProductionSessionOptions
    {
        public const string DevelopmentStartupAddress = "http://dev-global.de.t4f.cn:2000/urls/get/";
        public string DedicatedDeviceId { get; }
        public string VersionKey { get; }
        public string ClientVersion { get; }
        public string BundleId { get; }
        public short PlatformId { get; }
        public string Locale { get; }
        public int ChannelId { get; }
        public int StartupVersionNumber { get; }
        public Uri StartupUri { get; }
        public ProductionSessionOptions(string dedicatedDeviceId, string versionKey, string clientVersion, string locale = "en")
        {
            if (string.IsNullOrWhiteSpace(dedicatedDeviceId) || !dedicatedDeviceId.StartsWith("de-rewrite-test-", StringComparison.Ordinal) || dedicatedDeviceId.Length > 96)
                throw new ArgumentException("A separate de-rewrite-test-* device identity is required; existing player accounts are not used.");
            foreach (char c in dedicatedDeviceId) if (!(char.IsLetterOrDigit(c) || c == '-')) throw new ArgumentException("Invalid dedicated test device id.");
            string[] parts = (clientVersion ?? "").Split('.');
            if (parts.Length != 3 || !int.TryParse(parts[0], out int major) || !int.TryParse(parts[1], out int minor) || !int.TryParse(parts[2], out int patch) || major < 0 || minor < 0 || patch < 0)
                throw new ArgumentException("A three-part source client version is required.");
            StartupVersionNumber = checked((major * 1000 + minor) * 100 + patch);
            if (versionKey != "IOS_" + StartupVersionNumber && versionKey != "ANDROID_" + StartupVersionNumber)
                throw new ArgumentException("Version key must match the source platform/version contract.");
            DedicatedDeviceId = dedicatedDeviceId; VersionKey = versionKey; ClientVersion = clientVersion;
            PlatformId = (short)(versionKey.StartsWith("ANDROID_", StringComparison.Ordinal) ? 1 : 2);
            BundleId = PlatformId == 1 ? "com.tap4fun.invasion_zombie.gplay" : "com.tap4fun.bz.appstore";
            // Original LoginMgr.GetLoginChannelId in UNITY_EDITOR uses debugChanelId(0)+APP_PUBLISH_AREA_W(0).
            ChannelId = 0; Locale = string.IsNullOrWhiteSpace(locale) ? "en" : locale;
            StartupUri = new Uri(DevelopmentStartupAddress + versionKey + "?appVersion=" + StartupVersionNumber + "&udid=" + Uri.EscapeDataString(dedicatedDeviceId));
        }
        internal string LoginName => "anonymous:name" + DedicatedDeviceId + "." + ChannelId;
        internal string Password => "pass" + DedicatedDeviceId;
    }
    public sealed class ProductionConnectionException : Exception
    {
        public ProductionConnectionPhase Phase { get; }
        public int ErrorCode { get; }
        public ProductionConnectionException(ProductionConnectionPhase phase, string safeMessage, int errorCode = 0)
            : base(safeMessage) { Phase = phase; ErrorCode = errorCode; }
    }
    public sealed class ProtocolReceipt
    {
        public long Sequence { get; } public Protocol.MsgType Type { get; } public int NodeId { get; }
        public DateTime ReceivedUtc { get; } public NetworkMessage Message { get; }
        internal ProtocolReceipt(long sequence, NetworkMessage message)
        { Sequence = sequence; Type = message.GetMessageType(); NodeId = message.m_nodId; Message = message; ReceivedUtc = DateTime.UtcNow; }
    }
    // Raw typed ingress, not a replacement for original module-specific reducers.
    // Keeps full payloads instead of projecting into a small fake SLG snapshot.
    public sealed class ProtocolStateStore
    {
        private readonly Dictionary<string, ProtocolReceipt> latest = new Dictionary<string, ProtocolReceipt>(StringComparer.Ordinal);
        private readonly Queue<ProtocolReceipt> history = new Queue<ProtocolReceipt>();
        private long sequence;
        public long Generation { get; private set; }
        public int Count => latest.Count;
        internal void Reset(long generation) { latest.Clear(); history.Clear(); sequence = 0; Generation = generation; }
        internal void Receive(NetworkMessage message)
        {
            var receipt = new ProtocolReceipt(++sequence, message);
            latest[((int)receipt.Type) + "/" + receipt.NodeId] = receipt;
            history.Enqueue(receipt); while (history.Count > 512) history.Dequeue();
        }
        public ProtocolReceipt[] History => history.ToArray();
        public NetworkMessage GetLatest(Protocol.MsgType type, int nodeId = 0)
        { return latest.TryGetValue(((int)type) + "/" + nodeId, out var receipt) ? receipt.Message : null; }
        public T GetLatest<T>(Protocol.MsgType type, int nodeId = 0) where T : NetworkMessage
        { return GetLatest(type, nodeId) as T; }
    }
}
