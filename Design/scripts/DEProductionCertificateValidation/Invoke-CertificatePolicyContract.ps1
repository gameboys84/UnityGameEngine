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
$taskData = Join-Path $Editor 'Editor\Data'
$taskProfile = Join-Path $taskData 'MonoBleedingEdge\lib\mono\unityjit-win32'
$taskCompiler = Join-Path $taskData 'DotNetSdkRoslyn\csc.dll'
$taskMono = Join-Path $taskData 'MonoBleedingEdge\bin\mono.exe'
if (-not $NetworkSource) { $NetworkSource = Join-Path $taskRepository 'UnityProject2\Assets\DE\Infrastructure\Network' }
if (-not $OutputDirectory) { $OutputDirectory = Join-Path $taskRepository 'Design\reports\de-certificate-policy' }
$taskNewtonsoft = Get-ChildItem -LiteralPath (Join-Path $taskRepository 'UnityProject2\Library\PackageCache') -Directory -Filter 'com.unity.nuget.newtonsoft-json@*' |
    ForEach-Object { Join-Path $_.FullName 'Runtime\Newtonsoft.Json.dll' } | Where-Object { Test-Path -LiteralPath $_ } | Select-Object -First 1
if (-not $taskNewtonsoft) { throw 'Resolved project Newtonsoft package is required.' }
$taskReferences = @('mscorlib.dll', 'System.dll', 'System.Core.dll', 'System.Net.Http.dll', 'System.IO.Compression.dll', 'Facades\netstandard.dll') | ForEach-Object { Join-Path $taskProfile $_ }
$taskReferences += Join-Path $taskData 'Managed\UnityEngine\UnityEngine.CoreModule.dll'
$taskReferences += $taskNewtonsoft
$taskSources = @(Get-ChildItem -LiteralPath $NetworkSource -Recurse -File -Filter '*.cs' | ForEach-Object FullName)
foreach ($taskMode in @('Player', 'Editor')) {
    $taskOutput = Join-Path ([IO.Path]::GetFullPath($OutputDirectory)) $taskMode
    New-Item -ItemType Directory -Path $taskOutput -Force | Out-Null
    $taskLibrary = Join-Path $taskOutput 'DE.Production.Network.dll'
    $taskBase = @('/nologo', '/langversion:9.0', '/nostdlib+') + @($taskReferences | ForEach-Object { '/reference:' + $_ })
    $taskProductArguments = $taskBase + @('/target:library', ('/out:' + $taskLibrary)) + $taskSources
    if ($taskMode -eq 'Editor') { $taskProductArguments += '/define:UNITY_EDITOR,UNITY_EDITOR_WIN,UNITY_2022_3' }
    $taskResponse = Join-Path $taskOutput 'production.rsp'
    [IO.File]::WriteAllLines($taskResponse, @($taskProductArguments | ForEach-Object { '"' + $_.Replace('"', '\"') + '"' }), [Text.UTF8Encoding]::new($false))
    & dotnet $taskCompiler ('@' + $taskResponse)
    if ($LASTEXITCODE -ne 0) { throw "Product $taskMode compilation failed." }
    $taskExe = Join-Path $taskOutput 'CertificatePolicyContract.exe'
    $taskTestArguments = $taskBase + @('/target:exe', ('/out:' + $taskExe), (Join-Path $PSScriptRoot 'CertificatePolicyContract.cs'))
    $taskTestResponse = Join-Path $taskOutput 'contract.rsp'
    [IO.File]::WriteAllLines($taskTestResponse, @($taskTestArguments | ForEach-Object { '"' + $_.Replace('"', '\"') + '"' }), [Text.UTF8Encoding]::new($false))
    & dotnet $taskCompiler ('@' + $taskTestResponse)
    if ($LASTEXITCODE -ne 0) { throw "Contract $taskMode compilation failed." }
    Copy-Item -LiteralPath $taskNewtonsoft -Destination (Join-Path $taskOutput 'Newtonsoft.Json.dll') -Force
    Copy-Item -LiteralPath (Join-Path $taskProfile 'System.Net.Http.dll') -Destination (Join-Path $taskOutput 'System.Net.Http.dll') -Force
    & $taskMono $taskExe $taskLibrary $taskMode
    if ($LASTEXITCODE -ne 0) { throw "Certificate $taskMode isolation contract failed." }

}

