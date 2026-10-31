# DE source data importer

Read-only import helper, separate from Unity product code. Requires .NET SDK 10.

From the MyUnityFramework root:

```powershell
dotnet run --project Design/scripts/LegacyImport/LegacyImport.csproj -- "E:\TAP\DE\DeadEmpire-DEV" "UnityProject2/Assets/DE/Infrastructure/Resources/DE/Legacy"
```

The helper reads the source pack index and encryption parameters from source AES.cs without embedding parameters in the new client. It extracts building, building_pos, researchlab, training and items dictionaries, normalizes their JSON and emits a tab-separated LegacyRules.txt. SourceManifest.json records pack/table hashes and row counts. The source JSON permits trailing commas; normalization removes them.

LegacyProtocol.json and LegacyProtocol.txt describe message IDs, payload class names and declared fields from ProtocolTypeEnum, ProtocolCreator and ProtocolDefine0-5. This does not implement SPack, encryption/compression, authentication, transport or legacy server compatibility. No source file is modified, no account is used and no service is contacted.

Current product runtime still uses the explicitly labelled MockDeSession fixtures. The extracted source data is not yet connected to a production rule evaluator or protocol reducer. Raw base values omit dynamic server constants, buffs and operation-specific calculations. Import success is not gameplay parity.

Observed source snapshot: building 536 rows, building_pos 69, researchlab 914, training 24, items 3867; protocol version 72, 1722 message declarations and 1885 payload structure declarations. Re-run to verify a changed source snapshot.
