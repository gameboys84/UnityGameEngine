using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace DE.Infrastructure.Network
{
    // Reproduces the legacy Editor certificate allowance only for this dedicated dev-auth instance.
    // No ServicePointManager/global callback or TLS-protocol override is installed.
    internal sealed class DevelopmentCertificatePolicy
    {
        private readonly object gate = new object();
#if UNITY_EDITOR
        private readonly bool eligibleDevelopmentContext;
#endif
        private Dictionary<string, int> authenticationAuthorities = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        private bool disposed;
        private bool attached = false;
        private int validationCount, rejectionCount;
        private int compatibilityCount = 0;
        private string lastErrors = "NotObserved", lastDecision = "NotObserved";
        private string decisionContext = "";
#if UNITY_EDITOR
        private const bool editorBuild = true;
#else
        private const bool editorBuild = false;
#endif
        internal DevelopmentCertificatePolicy(ProductionSessionOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));
#if UNITY_EDITOR
            eligibleDevelopmentContext = options.DedicatedDeviceId.StartsWith("de-rewrite-test-", StringComparison.Ordinal) &&
                options.StartupUri.GetLeftPart(UriPartial.Path) == ProductionSessionOptions.DevelopmentStartupAddress + options.VersionKey &&
                options.StartupUri.Scheme == Uri.UriSchemeHttp && options.StartupUri.Host == "dev-global.de.t4f.cn" && options.StartupUri.Port == 2000;
#endif
        }
        internal IDisposable Attach(HttpClientHandler handler, Uri boundRequestUri = null, CancellationToken cancellationToken = default)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));
            if (boundRequestUri != null && (!boundRequestUri.IsAbsoluteUri || boundRequestUri.Scheme != Uri.UriSchemeHttps || !string.IsNullOrEmpty(boundRequestUri.UserInfo)))
                throw new ArgumentException("TLS handler binding requires an absolute HTTPS request without credentials.");
            var binding = new RequestBinding(cancellationToken);
#if UNITY_EDITOR
            // One immutable URI per handler/request: never borrow a mutable "current host" from another attempt.
            handler.ServerCertificateCustomValidationCallback = (request, certificate, chain, errors) =>
                EvaluateBoundCore(request?.RequestUri, boundRequestUri, certificate != null, errors,
                    request == null ? "NoHttpRequest" : RequestShape(request.RequestUri), binding.IsInvalid);
            lock (gate) attached = true;
#endif
            return binding;
        }
        private sealed class RequestBinding : IDisposable
        {
            private readonly CancellationToken cancellation; private int disposed;
            internal RequestBinding(CancellationToken cancellation) { this.cancellation = cancellation; }
            internal bool IsInvalid => cancellation.IsCancellationRequested || Volatile.Read(ref disposed) != 0;
            public void Dispose() { Interlocked.Exchange(ref disposed, 1); }
        }
        internal void RegisterAuthenticationAuthorities(string[] addresses)
        {
            if (addresses == null || addresses.Length == 0) throw new ArgumentException("Development authentication authorities are required.");
            var replacement = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < addresses.Length; i++)
            {
                string address = addresses[i];
                if (string.IsNullOrWhiteSpace(address) || address.IndexOf('/') >= 0 || address.IndexOf('@') >= 0 ||
                    !Uri.TryCreate("https://" + address, UriKind.Absolute, out var uri) || uri.Port < 1 || uri.Port > 65535)
                    throw new ArgumentException("Development authentication authority is invalid.");
                string key = AuthorityKey(uri);
                if (!replacement.ContainsKey(key)) replacement.Add(key, i + 1);
            }
            lock (gate)
            {
                if (disposed) throw new ObjectDisposedException(nameof(DevelopmentCertificatePolicy));
                authenticationAuthorities = replacement;
            }
        }
        // Kept internal for offline policy verification; production always derives certificatePresent from the real TLS callback.
        internal bool Evaluate(Uri requestUri, bool certificatePresent, SslPolicyErrors errors)
        { return EvaluateBoundCore(requestUri, null, certificatePresent, errors, RequestShape(requestUri)); }
        internal bool EvaluateBound(Uri requestUri, Uri boundRequestUri, bool certificatePresent, SslPolicyErrors errors)
        { return EvaluateBoundCore(requestUri, boundRequestUri, certificatePresent, errors, RequestShape(requestUri)); }
        private bool EvaluateBoundCore(Uri requestUri, Uri boundRequestUri, bool certificatePresent, SslPolicyErrors errors, string callbackShape, bool invalidBinding = false)
        {
            lock (gate)
            {
                validationCount++;
                lastErrors = errors.ToString();
                bool callbackHasAbsoluteIdentity = requestUri != null && requestUri.IsAbsoluteUri;
                string identitySource = !callbackHasAbsoluteIdentity && boundRequestUri != null ? "CapturedOutboundRequestUri" : requestUri == null ? "Unavailable" : "CallbackRequestUri";
                decisionContext = " [identity=" + identitySource + ";callback=" + callbackShape + "]";
                if (disposed) return Reject("RejectedDisposed");
                if (invalidBinding) return Reject("RejectedExpiredRequestBinding");
                if (!certificatePresent || (errors & SslPolicyErrors.RemoteCertificateNotAvailable) != 0) return Reject("RejectedMissingCertificate");
                if (boundRequestUri != null && (!boundRequestUri.IsAbsoluteUri || boundRequestUri.Scheme != Uri.UriSchemeHttps || !string.IsNullOrEmpty(boundRequestUri.UserInfo))) return Reject("RejectedInvalidRequestBinding");
                if (requestUri != null && boundRequestUri != null && requestUri.IsAbsoluteUri && AuthorityKey(requestUri) != AuthorityKey(boundRequestUri)) return Reject("RejectedBoundAuthorityMismatch");
                // Mono CertificateCallbackMapper constructs a synthetic GET from the TLS sender string.
                // A relative URI carries no authority: use only this handler's immutable outbound identity.
                if (!callbackHasAbsoluteIdentity) requestUri = boundRequestUri;
                if (requestUri == null || !requestUri.IsAbsoluteUri || requestUri.Scheme != Uri.UriSchemeHttps || !string.IsNullOrEmpty(requestUri.UserInfo)) return Reject("RejectedInvalidTlsRequest");
                if (errors == SslPolicyErrors.None) { lastDecision = "StrictValid" + decisionContext; return true; }
                const SslPolicyErrors compatibleErrors = SslPolicyErrors.RemoteCertificateChainErrors | SslPolicyErrors.RemoteCertificateNameMismatch;
                if ((errors & ~compatibleErrors) != 0) return Reject("RejectedUnsupportedCertificateError");
#if UNITY_EDITOR
                if (!eligibleDevelopmentContext) return Reject("RejectedUnapprovedDevelopmentContext");
                if (!authenticationAuthorities.ContainsKey(AuthorityKey(requestUri))) return Reject("RejectedUnapprovedAuthority");
                compatibilityCount++;
                lastDecision = "ScopedEditorDevelopmentCompatibility" + decisionContext;
                return true;
#else
                return Reject("RejectedStrictPlayer");
#endif
            }
        }
        private bool Reject(string decision) { rejectionCount++; lastDecision = decision + decisionContext; return false; }
        private static string RequestShape(Uri uri)
        { return uri == null ? "NoRequestUri" : !uri.IsAbsoluteUri ? "RelativeUri" : uri.Scheme != Uri.UriSchemeHttps ? "NonHttpsUri" : !string.IsNullOrEmpty(uri.UserInfo) ? "CredentialUri" : "HttpsUri"; }
        private static string AuthorityKey(Uri uri) { return uri.IdnHost.ToLowerInvariant() + ":" + uri.Port; }
        internal CertificatePolicySnapshot Snapshot()
        {
            lock (gate) return new CertificatePolicySnapshot(editorBuild ? "EditorDevelopmentScoped" : "StrictPlayer", attached,
                lastErrors, lastDecision, validationCount, compatibilityCount, rejectionCount);
        }
        internal void Dispose()
        { lock (gate) { disposed = true; authenticationAuthorities.Clear(); } }
    }
    internal sealed class CertificatePolicySnapshot
    {
        internal string Policy { get; } internal bool Attached { get; }
        internal string Errors { get; } internal string Decision { get; }
        internal int ValidationCount { get; } internal int CompatibilityCount { get; } internal int RejectionCount { get; }
        internal CertificatePolicySnapshot(string policy, bool attached, string errors, string decision, int validations, int compatibilities, int rejections)
        { Policy = policy; Attached = attached; Errors = errors; Decision = decision; ValidationCount = validations; CompatibilityCount = compatibilities; RejectionCount = rejections; }
    }
}
