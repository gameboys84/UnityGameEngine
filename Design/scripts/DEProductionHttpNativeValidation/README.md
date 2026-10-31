# Unity Mono native HTTP request regression

From repository root, with the Editor version used by UnityProject2:

```powershell
pwsh -File Design/scripts/DEProductionHttpNativeValidation/Invoke-MonoHttpNativeContract.ps1
```

This compiles the actual production Network sources against installed Editor references, runs Unity's bundled `mono.exe`, and loads the Editor's exact `unityjit-win32/System.Net.Http.dll` beside the executable. The runtime library location and SHA256 are asserted. Mono's default `4.5` HTTP implementation behaves differently and does not reproduce the Editor's empty-GET-content rejection, so it is deliberately excluded.

An actual local `HttpListener` receives the production `ProductionHttpBootstrap.GetTextAsync` requests through the native `HttpClientHandler`; no fake HTTP handler is used. The test verifies GET has no entity body, POST preserves the original raw UTF8/no Content-Type contract, gzip is decoded, and the previous GET-with-empty-Content code actually throws `ProtocolViolationException` under the Editor HTTP library. It performs 18 assertions.

Only `127.0.0.1` is contacted. No development, production, authentication or payment service is contacted. No Editor process is started or controlled. Build/output files remain under ignored `Design/reports/de-production-http-native` by default.

Requires PowerShell 7, installed .NET host, Unity 2022.3.62f2 and its resolved Newtonsoft package. Set `-Editor`, `-Repository`, or `-OutputDirectory` when those local paths differ.
