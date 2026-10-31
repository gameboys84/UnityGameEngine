#requires -Version 7.0
[CmdletBinding()]
param(
    [string] $Repository = (Join-Path $PSScriptRoot '..\..\..'),
    [string] $Editor = 'C:\Program Files\Unity\Hub\Editor\2022.3.62f2',
    [string] $NetworkSource = '',
    [string] $OutputDirectory = ''
)
$ErrorActionPreference = 'Stop'
$taskRepository = [IO.Path]::GetFullPath($Repository)
$taskEditorData = Join-Path $Editor 'Editor\Data'
$taskProfile = Join-Path $taskEditorData 'MonoBleedingEdge\lib\mono\unityjit-win32'
$taskCompiler = Join-Path $taskEditorData 'DotNetSdkRoslyn\csc.dll'
$taskMono = Join-Path $taskEditorData 'MonoBleedingEdge\bin\mono.exe'
$taskProduct = if ($NetworkSource) { [IO.Path]::GetFullPath($NetworkSource) } else { Join-Path $taskRepository 'UnityProject2\Assets\DE\Infrastructure\Network' }
if (-not $OutputDirectory) { $OutputDirectory = Join-Path $taskRepository 'Design\reports\de-production-http-native' }
$taskOutput = [IO.Path]::GetFullPath($OutputDirectory)
New-Item -ItemType Directory -Path $taskOutput -Force | Out-Null
$taskNewtonsoft = Get-ChildItem -LiteralPath (Join-Path $taskRepository 'UnityProject2\Library\PackageCache') -Directory -Filter 'com.unity.nuget.newtonsoft-json@*' |
    ForEach-Object { Join-Path $_.FullName 'Runtime\Newtonsoft.Json.dll' } | Where-Object { Test-Path -LiteralPath $_ } | Select-Object -First 1
if (-not $taskNewtonsoft) { throw 'Resolve the project Newtonsoft package before running this offline native validation.' }
$taskReferences = @('mscorlib.dll', 'System.dll', 'System.Core.dll', 'System.Net.Http.dll', 'System.IO.Compression.dll', 'Facades\netstandard.dll') |
    ForEach-Object { Join-Path $taskProfile $_ }
$taskReferences += Join-Path $taskEditorData 'Managed\UnityEngine\UnityEngine.CoreModule.dll'
$taskReferences += $taskNewtonsoft
foreach ($taskRequired in (@($taskCompiler, $taskMono) + $taskReferences)) {
    if (-not (Test-Path -LiteralPath $taskRequired -PathType Leaf)) { throw "Missing required Editor reference: $taskRequired" }
}
function Invoke-ContractCompiler([string] $Name, [string[]] $CompilerArguments) {
    $taskResponse = Join-Path $taskOutput ($Name + '.rsp')
    $taskLines = $CompilerArguments | ForEach-Object { '"' + $_.Replace('"', '\"') + '"' }
    [IO.File]::WriteAllLines($taskResponse, $taskLines, [Text.UTF8Encoding]::new($false))
    & dotnet $taskCompiler ('@' + $taskResponse)
    if ($LASTEXITCODE -ne 0) { throw "Native contract compilation failed: $Name" }
}
$taskLibrary = Join-Path $taskOutput 'DE.Production.Network.dll'
$taskCommon = @('/nologo', '/langversion:9.0', '/nostdlib+') + @($taskReferences | ForEach-Object { '/reference:' + $_ })
$taskProductFiles = @(Get-ChildItem -LiteralPath $taskProduct -Recurse -File -Filter '*.cs' | ForEach-Object FullName)
Invoke-ContractCompiler 'production-network' ($taskCommon + @('/target:library', ('/out:' + $taskLibrary)) + $taskProductFiles)
$taskExe = Join-Path $taskOutput 'MonoHttpNativeContract.exe'
Invoke-ContractCompiler 'mono-http-contract' ($taskCommon + @('/target:exe', ('/out:' + $taskExe), ('/reference:' + $taskLibrary), (Join-Path $PSScriptRoot 'MonoHttpNativeContract.cs')))
Copy-Item -LiteralPath $taskNewtonsoft -Destination (Join-Path $taskOutput 'Newtonsoft.Json.dll') -Force
# Essential: mono.exe defaults to its 4.5 HTTP library, whose GET semantics differ from the embedded Unity Editor.
$taskHttp = Join-Path $taskProfile 'System.Net.Http.dll'
Copy-Item -LiteralPath $taskHttp -Destination (Join-Path $taskOutput 'System.Net.Http.dll') -Force
$taskExpectedHash = (Get-FileHash -LiteralPath $taskHttp -Algorithm SHA256).Hash
& $taskMono $taskExe $taskExpectedHash
if ($LASTEXITCODE -ne 0) { throw 'Mono native HTTP contract failed.' }
