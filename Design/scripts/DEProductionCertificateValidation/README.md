# Development Editor TLS certificate isolation

```powershell
pwsh -File Design/scripts/DEProductionCertificateValidation/Invoke-CertificatePolicyContract.ps1
```

Compiles the same production Network source twice against the installed Unity references: once without UNITY_EDITOR (Player), once with it (Editor). Each binary runs under Unity's Mono with the Editor HTTP implementation. The 30 Player assertions and 35 Editor assertions check startup-host registration, fixed development bootstrap, dedicated identity, exact authority/port isolation, absent certificate refusal, strict valid TLS, no global callback changes, per-instance callback attachment, diagnostics and disposal. No network requests are made.

The Editor compatibility path is compiled only under UNITY_EDITOR and applies solely to chain/name certificate errors from the authentication authorities returned by the fixed development bootstrap for a dedicated de-rewrite-test-* identity. RemoteCertificateNotAvailable and missing certificates are always rejected. Player builds never install the compatibility callback; other authorities remain strict. It does not modify ServicePointManager or enable any legacy TLS protocol globally.

Use the actual login diagnostic fields CertificatePolicy, CertificatePolicyAttached, LastSslPolicyErrors, LastCertificateDecision, CertificateValidationCount and CertificateCompatibilityCount to distinguish a certificate decision from a TLS failure that happened before certificate validation. A TLS failure with certChecks=0/NotObserved has not exercised the certificate allowance and is not evidence that certificate checks should be weakened further.

Set -Editor, -Repository, -NetworkSource or -OutputDirectory for alternate local paths. Outputs default to ignored Design/reports/de-certificate-policy. This does not replace the separately controlled real development-server login verification.

The handler now captures an immutable outbound HTTPS URI per authentication request. Some Unity Mono callbacks omit HttpRequestMessage/RequestUri or provide a synthetic relative URI; only that handler's captured URI can supply the missing identity. A conflicting callback authority is rejected. Each retry receives a separate handler and cancellation binding. Cancellation invalidates the old binding; client disposal expires it before disposing the handler. Tests invoke the installed callback with a certificate-presence fixture to check lifecycle decisions; these are policy tests, not TLS handshakes.

Standalone Unity mono.exe cannot initialize the Editor UnityTLS provider (`TLS Support not available`), so an attempted loopback TLS handshake did not execute a certificate callback. Real callback semantics and final authentication remain verified only by the main agent inside the real Editor. No policy pass is reported as real TLS success. Existing LastCertificateDecision adds safe identity-source/callback-shape labels without hostname, URL or credentials.

Binary source evidence: installed unityjit System.Net.Http.dll SHA256 85f6d618b5df944d2271e2d028b94a93cd371c6134507997441475b1700623cf, MVID 81a53b27-5575-45fe-94d7-1df32265c99f. REA managed inspection identifies CertificateCallbackMapper.<.ctor>b__2_0 (0x06000006): get HttpMethod.Get, cast sender, new HttpRequestMessage(HttpMethod,string) (0x0600014e), then invoke the custom callback. This is a synthetic GET wrapper around TLS sender identity, not the original HTTP request. Actual Editor evidence reports RelativeUri; no claim is made about the exact live host string because live diagnostic intentionally does not log it. Relative host/path callbacks cannot confer authority. They use only the immutable captured outbound URI, while absolute callback authority conflicts remain rejected.
