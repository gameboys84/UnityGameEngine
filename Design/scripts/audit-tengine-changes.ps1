param([string]$SourceRoot = 'E:/Git/TEngineNi/UnityProject')
$ErrorActionPreference = 'Stop'
$workspace = (Resolve-Path (Join-Path $PSScriptRoot '../..')).Path
$targetRoot = Join-Path $workspace 'UnityProject1'
$SourceRoot = (Resolve-Path -LiteralPath $SourceRoot).Path
$sourceRepository = Split-Path $SourceRoot
$packageRepository = Join-Path $sourceRepository 'FrameworkPackages'
$packageHead = (& git -C $packageRepository rev-parse HEAD).Trim()
$packageStatus = @(& git -C $packageRepository status --porcelain)
$reportRoot = Join-Path $workspace 'Design/reports'
$diffRoot = Join-Path $reportRoot 'TEngineNi-diff'
New-Item -ItemType Directory -Path $diffRoot -Force | Out-Null
$targetManifest = Get-Content -LiteralPath (Join-Path $targetRoot 'Packages/manifest.json') -Raw -Encoding UTF8 | ConvertFrom-Json
$sourceManifest = Get-Content -LiteralPath (Join-Path $SourceRoot 'Packages/manifest.json') -Raw -Encoding UTF8 | ConvertFrom-Json
$records = @()
foreach ($name in @('com.ni.tengine', 'com.ni.gamecore')) {
    $folder = Join-Path $sourceRepository "FrameworkPackages/$name"
    $metadata = Get-Content -LiteralPath (Join-Path $folder 'package.json') -Raw -Encoding UTF8 | ConvertFrom-Json
    $targetReference = [string]$targetManifest.dependencies.PSObject.Properties[$name].Value
    $sourceReference = [string]$sourceManifest.dependencies.PSObject.Properties[$name].Value
    $targetResolved = if ($targetReference.StartsWith('file:')) { [IO.Path]::GetFullPath((Join-Path (Join-Path $targetRoot 'Packages') $targetReference.Substring(5))) } else { $null }
    $sourceResolved = if ($sourceReference.StartsWith('file:')) { [IO.Path]::GetFullPath((Join-Path (Join-Path $SourceRoot 'Packages') $sourceReference.Substring(5))) } else { $null }
    $files = @(Get-ChildItem -LiteralPath $folder -Recurse -File | ForEach-Object {
        [pscustomobject]@{Path=$_.FullName.Substring($folder.Length + 1).Replace('\','/');SHA256=(Get-FileHash -LiteralPath $_.FullName -Algorithm SHA256).Hash}
    })
    $records += [pscustomobject]@{
        Package=$name;Version=$metadata.version;Source=$folder;SourceReference=$sourceReference;TargetReference=$targetReference
        SourceUsesOwnedPackage=($sourceResolved -eq $folder);TargetUsesSharedWorkingTree=($targetResolved -eq $folder)
        Mode=$(if ($targetResolved) {'local'} else {'git-or-missing'});Files=$files
        SyncState=$(if ($sourceResolved -eq $folder -and $targetResolved -eq $folder) {'shared-source-working-tree'} elseif ($targetReference.EndsWith('#'+$packageHead) -and $packageStatus.Count -eq 0) {'pinned-package-commit'} else {'inspect-reference'})
    }
}
$head = (& git -C $sourceRepository rev-parse HEAD).Trim()
$status = @(& git -C $sourceRepository status --porcelain -- README.md update-tengine.bat FrameworkPackages UnityProject/Packages UnityProject/Assets/TEngine UnityProject/Assets/Scripts/Hotfix/GameCore UnityProject/Assets/Scripts/Hotfix/Runtime/GameRuntime.asmdef UnityProject/Assets/Scripts/Editor/UIScriptGenerator UnityProject/Assets/Editor/TEngineSettingsProvider)
$patchName = 'TEngineNi-package-worktree.diff'
$diffPaths = @('README.md','update-tengine.bat','FrameworkPackages','UnityProject/Packages/manifest.json','UnityProject/Packages/packages-lock.json','UnityProject/Assets/TEngine','UnityProject/Assets/Scripts/Hotfix/GameCore','UnityProject/Assets/Scripts/Hotfix/Runtime/GameRuntime.asmdef','UnityProject/Assets/Scripts/Editor/UIScriptGenerator','UnityProject/Assets/Editor/TEngineSettingsProvider')
$patch = & git -C $sourceRepository -c core.quotepath=false diff --binary HEAD -- @diffPaths
if ($LASTEXITCODE -ne 0) { throw 'Source Git diff failed.' }
$patch | Set-Content -LiteralPath (Join-Path $diffRoot $patchName) -Encoding UTF8
$manifest = [pscustomobject]@{
    SchemaVersion=3;AuditedAt=(Get-Date -Format o);SourceRoot=$SourceRoot;SourceHeadAtAudit=$head
    PackageHeadAtAudit=$packageHead;PackageWorkingTreeStatus=$packageStatus
    BaselineNote='Package ownership audit. Ni FrameworkPackages is the independent UPM repository submodule; consumers may pin its Git SHA. A matching SHA is only current when the package working tree is clean. Not a historical import baseline.'
    SourceWorkingTreeStatus=$status;Diff=('Design/reports/TEngineNi-diff/'+$patchName);Records=$records
}
$manifest | ConvertTo-Json -Depth 12 | Set-Content -LiteralPath (Join-Path $reportRoot 'TEngineNi-change-inventory.json') -Encoding UTF8
$archive = Join-Path $reportRoot ('TEngineNi-audits/' + (Get-Date -Format 'yyyyMMdd-HHmmssfff'))
New-Item -ItemType Directory -Path $archive -Force | Out-Null
Copy-Item -LiteralPath (Join-Path $diffRoot $patchName) -Destination (Join-Path $archive $patchName)
$manifest | ConvertTo-Json -Depth 12 | Set-Content -LiteralPath (Join-Path $archive 'inventory.json') -Encoding UTF8
Write-Output "Audited $($records.Count) packages. Both projects use shared local source: $(@($records | Where-Object {$_.SourceUsesOwnedPackage -and $_.TargetUsesSharedWorkingTree}).Count -eq 2). No source changes, commits or sync performed by this audit."
