using System;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Reflection;

internal static class CertificatePolicyContract
{
    private static int passed;
    private static Type optionsType, policyType;
    private static void Check(bool value, string label) { if (!value) throw new Exception(label); passed++; Console.WriteLine("PASS certificate policy " + label); }
    private static object Options()
    { return Activator.CreateInstance(optionsType, new object[] { "de-rewrite-test-certificate", "IOS_6900", "0.69.0", "en" }); }
    private static object Policy(object options)
    { return Activator.CreateInstance(policyType, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { options }, null); }
    private static object Invoke(object policy, string method, params object[] args)
    { return policyType.GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic).Invoke(policy, args); }
    private static bool Evaluate(object policy, string uri, bool certificate, SslPolicyErrors errors)
    { return (bool)Invoke(policy, "Evaluate", uri == null ? null : new Uri(uri), certificate, errors); }
    private static object Property(object value, string name)
    { return value.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(value, null); }
    private static void Main(string[] args)
    {
        if (args.Length != 2) throw new ArgumentException("Expected product assembly path and Editor/Player mode.");
        var assembly = Assembly.LoadFrom(args[0]);
        optionsType = assembly.GetType("DE.Infrastructure.Network.ProductionSessionOptions", true);
        policyType = assembly.GetType("DE.Infrastructure.Network.DevelopmentCertificatePolicy", true);
        bool editor = args[1] == "Editor";
        object policy = Policy(Options());
        Check((string)Property(Invoke(policy, "Snapshot"), "Policy") == (editor ? "EditorDevelopmentScoped" : "StrictPlayer"), "actual compilation mode is " + args[1]);
        string approved = "https://auth.dev-contract.invalid:8443/auth";
        Check(!Evaluate(policy, approved, true, SslPolicyErrors.RemoteCertificateChainErrors), "no compatibility before this session's startup authority registration");
        Invoke(policy, "RegisterAuthenticationAuthorities", (object)new[] { "auth.dev-contract.invalid:8443" });
        Check(Evaluate(policy, approved, true, SslPolicyErrors.RemoteCertificateChainErrors) == editor, "chain error compatibility is Editor-only and registered-authority-only");
        Check(Evaluate(policy, approved, true, SslPolicyErrors.RemoteCertificateNameMismatch | SslPolicyErrors.RemoteCertificateChainErrors) == editor, "name/chain errors remain strict in Player");
        Check(!Evaluate(policy, "https://other.invalid:8443/auth", true, SslPolicyErrors.RemoteCertificateChainErrors), "other host is strict");
        Check(!Evaluate(policy, "https://auth.dev-contract.invalid:443/auth", true, SslPolicyErrors.RemoteCertificateChainErrors), "other port is strict");
        Check(!Evaluate(policy, "https://auth.dev-contract.invalid.evil.invalid:8443/auth", true, SslPolicyErrors.RemoteCertificateChainErrors), "suffix lookalike is strict");
        Check(!Evaluate(policy, "https://credentials@auth.dev-contract.invalid:8443/auth", true, SslPolicyErrors.RemoteCertificateChainErrors), "credential-bearing URI never receives compatibility");
        Check(!Evaluate(policy, approved, true, SslPolicyErrors.RemoteCertificateNotAvailable | SslPolicyErrors.RemoteCertificateChainErrors), "RemoteCertificateNotAvailable is never allowed");
        Check(!Evaluate(policy, approved, false, SslPolicyErrors.None), "missing certificate is never allowed even if error flags are inconsistent");
        Check(!Evaluate(policy, "http://auth.dev-contract.invalid:8443/auth", true, SslPolicyErrors.RemoteCertificateChainErrors), "non-TLS URI is never allowed");
        Check(!Evaluate(policy, null, true, SslPolicyErrors.RemoteCertificateChainErrors), "missing request identity is never allowed");
        Check(!Evaluate(policy, approved, true, (SslPolicyErrors)8), "unknown TLS error flags never receive compatibility");
        int compatibilityBefore = (int)Property(Invoke(policy, "Snapshot"), "CompatibilityCount");
        Check(Evaluate(policy, approved, true, SslPolicyErrors.None), "valid certificate remains standard TLS success");
        Check(Evaluate(policy, "https://other.invalid:8443/auth", true, SslPolicyErrors.None), "other host can pass only standard valid TLS");
        Check((int)Property(Invoke(policy, "Snapshot"), "CompatibilityCount") == compatibilityBefore && compatibilityBefore == (editor ? 2 : 0), "compatibility count excludes strict successes and refusals");
        object invalidBootstrap = Options();
        optionsType.GetField("<StartupUri>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(invalidBootstrap, new Uri("https://not-the-development-bootstrap.invalid/"));
        object invalidPolicy = Policy(invalidBootstrap); Invoke(invalidPolicy, "RegisterAuthenticationAuthorities", (object)new[] { "auth.dev-contract.invalid:8443" });
        Check(!Evaluate(invalidPolicy, approved, true, SslPolicyErrors.RemoteCertificateChainErrors), "a different bootstrap cannot enable compatibility");
        object wrongIdentity = Options();
        optionsType.GetField("<DedicatedDeviceId>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(wrongIdentity, "existing-player");
        object wrongPolicy = Policy(wrongIdentity); Invoke(wrongPolicy, "RegisterAuthenticationAuthorities", (object)new[] { "auth.dev-contract.invalid:8443" });
        Check(!Evaluate(wrongPolicy, approved, true, SslPolicyErrors.RemoteCertificateChainErrors), "a non-dedicated identity cannot enable compatibility");
        var globalBefore = ServicePointManager.ServerCertificateValidationCallback;
        using (var handler = new HttpClientHandler())
        using (var unrelated = new HttpClientHandler())
        {
            Invoke(policy, "Attach", handler, null, System.Threading.CancellationToken.None);
            Check((handler.ServerCertificateCustomValidationCallback != null) == editor, "only Editor attaches a per-instance certificate callback");
            Check(unrelated.ServerCertificateCustomValidationCallback == null && ReferenceEquals(globalBefore, ServicePointManager.ServerCertificateValidationCallback), "unrelated handlers and global ServicePointManager remain untouched");
        }
        Check((string)Property(Invoke(policy, "Snapshot"), "Errors") == SslPolicyErrors.None.ToString(), "diagnostics expose error flags without certificate contents");
        Check((bool)Invoke(policy, "EvaluateBound", null, new Uri(approved), true, SslPolicyErrors.RemoteCertificateChainErrors) == editor, "missing Mono callback URI uses only the immutable registered outbound binding");
        Check(!(bool)Invoke(policy, "EvaluateBound", null, new Uri("https://other.invalid:8443/auth"), true, SslPolicyErrors.RemoteCertificateChainErrors), "missing Mono callback URI cannot authorize another bound host");
        Check(!(bool)Invoke(policy, "EvaluateBound", new Uri("https://other.invalid:8443/auth"), new Uri(approved), true, SslPolicyErrors.RemoteCertificateChainErrors), "a conflicting callback URI cannot borrow the approved binding");
        Check(!(bool)Invoke(policy, "EvaluateBound", null, null, true, SslPolicyErrors.RemoteCertificateChainErrors), "no callback URI and no captured binding is rejected");
        using (var certificate = new System.Security.Cryptography.X509Certificates.X509Certificate2())
        {
            using (var oldHandler = new HttpClientHandler())
            using (var cancelled = new System.Threading.CancellationTokenSource())
            using (var oldBinding = (IDisposable)Invoke(policy, "Attach", oldHandler, new Uri(approved), cancelled.Token))
            {
                var oldCallback = oldHandler.ServerCertificateCustomValidationCallback;
                if (editor) Check(oldCallback(new HttpRequestMessage(HttpMethod.Get, "auth.dev-contract.invalid"), certificate, null, SslPolicyErrors.RemoteCertificateChainErrors), "installed callback accepts only its immutable approved URI");
                cancelled.Cancel();
                if (editor) Check(!oldCallback(new HttpRequestMessage(HttpMethod.Get, "auth.dev-contract.invalid"), certificate, null, SslPolicyErrors.RemoteCertificateChainErrors), "cancelled installed callback rejects immediately");
                using (var nextHandler = new HttpClientHandler())
                using (var nextBinding = (IDisposable)Invoke(policy, "Attach", nextHandler, new Uri("https://other.invalid:8443/auth"), System.Threading.CancellationToken.None))
                {
                    if (editor) Check(!nextHandler.ServerCertificateCustomValidationCallback(null, certificate, null, SslPolicyErrors.RemoteCertificateChainErrors), "new handler cannot borrow old approved authority");
                    if (editor) Check(!oldCallback(null, certificate, null, SslPolicyErrors.None), "cancelled old callback stays invalid after new request");
                }
                using (var disposedHandler = new HttpClientHandler())
                {
                    var disposedBinding = (IDisposable)Invoke(policy, "Attach", disposedHandler, new Uri(approved), System.Threading.CancellationToken.None);
                    disposedBinding.Dispose();
                    if (editor) Check(!disposedHandler.ServerCertificateCustomValidationCallback(null, certificate, null, SslPolicyErrors.None), "disposed binding rejects before handler disposal");
                }
            }
        }
        Check((bool)Invoke(policy, "EvaluateBound", new Uri("auth.dev-contract.invalid", UriKind.Relative), new Uri(approved), true, SslPolicyErrors.RemoteCertificateChainErrors) == editor, "synthetic Mono host-only relative URI uses immutable outbound authority");
        Check((bool)Invoke(policy, "EvaluateBound", new Uri("/auth", UriKind.Relative), new Uri(approved), true, SslPolicyErrors.RemoteCertificateChainErrors) == editor, "relative path carries no authority and uses immutable outbound authority");
        Check(!(bool)Invoke(policy, "EvaluateBound", new Uri("auth.dev-contract.invalid", UriKind.Relative), new Uri("https://other.invalid:8443/auth"), true, SslPolicyErrors.RemoteCertificateChainErrors), "relative callback cannot confer authority on unapproved outbound request");
        Check(!(bool)Invoke(policy, "EvaluateBound", new Uri("auth.dev-contract.invalid", UriKind.Relative), null, true, SslPolicyErrors.RemoteCertificateChainErrors), "relative callback without outbound binding is refused");
        Invoke(policy, "Dispose");
        Check(!Evaluate(policy, approved, true, SslPolicyErrors.None), "disposed policy cannot approve another connection");
        Console.WriteLine("CERTIFICATE " + args[1] + " " + passed + " assertions passed; no network requests made.");
    }
}
