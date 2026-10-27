param(
    [string]$FrameworkSource = 'E:/Git/TEngineNi/UnityProject',
    [string]$LegacySource = 'E:/TAP/DE/DeadEmpire-DEV',
    [string]$Target = 'E:/Git/MyUnityFramework/UnityProject1'
)
$ErrorActionPreference = 'Stop'
$workspace = (Resolve-Path (Join-Path $PSScriptRoot '../..')).Path
$targetRoot = (Resolve-Path -LiteralPath $Target).Path
if (-not $targetRoot.StartsWith($workspace + '\', [StringComparison]::OrdinalIgnoreCase)) {
    throw 'Target must be inside the current workspace.'
}
function Import-Directory([string]$source, [string]$destination) {
    if (Test-Path -LiteralPath $destination) { throw "Refusing to overwrite: $destination" }
    New-Item -ItemType Directory -Path (Split-Path $destination) -Force | Out-Null
    Copy-Item -LiteralPath $source -Destination $destination -Recurse
    if (Test-Path -LiteralPath ($source + '.meta')) { Copy-Item -LiteralPath ($source + '.meta') -Destination ($destination + '.meta') }
}
Import-Directory "$FrameworkSource/Assets/TEngine" "$targetRoot/Assets/TEngine"
Import-Directory "$FrameworkSource/Packages/UniTask" "$targetRoot/Packages/UniTask"
Import-Directory "$FrameworkSource/Packages/YooAsset" "$targetRoot/Packages/YooAsset"
$hybrid = Get-ChildItem -LiteralPath "$FrameworkSource/Library/PackageCache" -Directory -Filter 'com.code-philosophy.hybridclr@*' | Select-Object -First 1
if (-not $hybrid) { throw 'Local HybridCLR package cache is required.' }
Import-Directory $hybrid.FullName "$targetRoot/Packages/com.code-philosophy.hybridclr"
$coreRoot = "$targetRoot/Assets/Scripts/Hotfix/GameCore"
Import-Directory "$FrameworkSource/Assets/Scripts/Hotfix/GameCore/SingletonSystem" "$coreRoot/SingletonSystem"
Import-Directory "$FrameworkSource/Assets/Scripts/Hotfix/GameCore/Module/UIModule" "$coreRoot/Module/UIModule"
Import-Directory "$FrameworkSource/Assets/Scripts/Hotfix/GameCore/Module/LocalSaveModule" "$coreRoot/Module/LocalSaveModule"
Import-Directory "$FrameworkSource/Assets/Scripts/Editor/UIScriptGenerator" "$targetRoot/Assets/Scripts/Editor/UIScriptGenerator"
Import-Directory "$FrameworkSource/Assets/Editor/TEngineSettingsProvider" "$targetRoot/Assets/Editor/TEngineSettingsProvider"
# Avoid duplicate Unsafe.dll already imported by Unity MCP's Roslyn support.
$copiedUnsafe = "$targetRoot/Assets/TEngine/Libraries/System.Runtime.CompilerServices.Unsafe.dll"
if (Test-Path "$targetRoot/Assets/Plugins/Roslyn/System.Runtime.CompilerServices.Unsafe.dll") {
    Remove-Item -LiteralPath $copiedUnsafe,($copiedUnsafe + '.meta')
}
$migration = @(
    @('Assets/Scripts/HVScrollRect/HVScrollRect.cs', 'Module/UIModule/Extensions/HVScrollRect.cs'),
    @('Assets/Scripts/CustomUI/T4fContentSizeFitter.cs', 'Module/UIModule/Extensions/T4fContentSizeFitter.cs'),
    @('Assets/Scripts/CustomUI/HoleImage.cs', 'Module/UIModule/Extensions/HoleImage.cs'),
    @('Assets/Scripts/UI/TextGradientColor.cs', 'Module/UIModule/Extensions/TextGradientColor.cs'),
    @('Assets/Scripts/Utils/UnityEngineObjectExtention.cs', 'Module/Foundation/UnityEngineObjectExtention.cs'),
    @('Assets/T4F-BJ-Lib/Common/Util/TimeUtility.cs', 'Module/Foundation/TimeUtility.cs'),
    @('Assets/T4F-BJ-Lib/Common/Util/BezierUtils.cs', 'Module/Foundation/BezierUtils.cs')
)
$manifest = @()
foreach ($entry in $migration) {
    $sourceFile = Join-Path $LegacySource $entry[0]
    $targetFile = Join-Path $coreRoot $entry[1]
    New-Item -ItemType Directory -Force -Path (Split-Path $targetFile) | Out-Null
    if (Test-Path -LiteralPath $targetFile) { throw "Refusing to overwrite $targetFile" }
    Copy-Item -LiteralPath $sourceFile -Destination $targetFile
    # Imported scripts retain their original identity; later edits happen only in target.
    if (Test-Path ($sourceFile + '.meta')) { Copy-Item -LiteralPath ($sourceFile + '.meta') -Destination ($targetFile + '.meta') }
    $manifest += [pscustomobject]@{Source=$sourceFile;Target=$targetFile;SourceSHA256=(Get-FileHash -LiteralPath $sourceFile -Algorithm SHA256).Hash}
}
$manifest | ConvertTo-Json | Set-Content -LiteralPath (Join-Path $PSScriptRoot '../reports/imported-source-manifest.json') -Encoding UTF8
Write-Output 'Foundation sources imported; configuration and compilation still required.'
