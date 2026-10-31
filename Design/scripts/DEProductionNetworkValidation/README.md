# Original DE network contract validation

Run from repository root with .NET SDK 10:

```powershell
dotnet run --project Design/scripts/DEProductionNetworkValidation/DEProductionNetworkValidation.csproj
```

Requires the installed Unity 2022.3.62f2 reference assembly and resolved Newtonsoft package already used by UnityProject2. Adjust the reference paths if the local Editor/cache differs. Product sources are compiled by reference to the actual new Network directory; no alternate copied implementation is tested.

This executable uses only local loopback TCP listeners. Its HTTP contract handler intercepts all requests in the full-login test, so it never contacts development, online or payment services. These are protocol tests, not substitute gameplay or a runtime Mock session.

Checks cover original MVC/Protocol v72 initialization, source version/channel/device fields, original SPack encoding, node normalization, ordinary/extended frame lengths, rejected header-only known payloads, directional Pike streams across chunks, both original LZ4 wrappers, fragmented/coalesced TCP input, complete original LOGIN_REQ/LOGIN_ACK exchange, early TIME_NTF buffering and exclusive loading-coordinator request ownership.

The wire group reports 17 assertions, the full-login contract group reports 30 checks, and the failure group covers ten startup/authentication/cancellation cases. They include source RawData/header parity, rejection of zero/mismatched role IDs without publishing a false LOGIN_ACK, duplicate-start isolation, source HTTP-status retry behavior, and sanitized TLS/DNS/connect/timeout diagnostics that never copy exception messages or credentials. Actual development-service connectivity still requires separate Unity/server verification.

The current increment ends at verified LOGIN_ACK. It does not start the 21-step gameplay loading coordinator, load a city or invoke later gameplay functions.
