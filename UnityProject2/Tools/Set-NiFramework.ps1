[CmdletBinding(SupportsShouldProcess = $true)]
param(
    [ValidateSet('Local', 'Git')][string]$Mode = 'Local',
    [string]$SourceRoot,
    [string]$RepositoryUrl = 'https://github.com/gameboys84/TEngineNi_UPM.git',
    [string]$Revision
)

$ErrorActionPreference = 'Stop'
$projectRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$packageRoot = Join-Path $projectRoot 'Packages'
$manifestPath = Join-Path $packageRoot 'manifest.json'
if (-not $SourceRoot) {
    $SourceRoot = Join-Path (Split-Path (Split-Path $projectRoot)) 'TEngineNi_UPM'
}
$SourceRoot = [IO.Path]::GetFullPath($SourceRoot)
$names = @('com.ni.tengine', 'com.ni.gamecore')
$values = @{}

if ($Mode -eq 'Git') {
    if ($Revision -notmatch '^[0-9a-fA-F]{40}$') {
        throw 'Git mode requires a full 40-character commit SHA. Commit and push the packages first; this script never commits or pushes.'
    }
    if ([string]::IsNullOrWhiteSpace($RepositoryUrl) -or $RepositoryUrl -match '[?#]') {
        throw 'Provide a repository URL without a query or revision suffix.'
    }
}

foreach ($name in $names) {
    $relative = $name
    if ($Mode -eq 'Local') {
        $folder = Join-Path $SourceRoot $relative
        $metadata = Join-Path $folder 'package.json'
        if (-not (Test-Path -LiteralPath $metadata -PathType Leaf)) { throw "Missing package: $metadata" }
        $identity = Get-Content -LiteralPath $metadata -Raw -Encoding UTF8 | ConvertFrom-Json
        if ($identity.name -ne $name) { throw "Unexpected package identity: $metadata" }
        $baseUri = [Uri]($packageRoot.TrimEnd('\', '/') + [IO.Path]::DirectorySeparatorChar)
        $folderUri = [Uri]([IO.Path]::GetFullPath($folder).TrimEnd('\', '/') + [IO.Path]::DirectorySeparatorChar)
        $path = [Uri]::UnescapeDataString($baseUri.MakeRelativeUri($folderUri).ToString()).TrimEnd('/')
        if ($path -match '^file:' -or $path -match '^[a-zA-Z]:') {
            throw 'Local mode requires source and project on the same volume so a portable relative path can be recorded.'
        }
        $values[$name] = 'file:' + $path
    }
    else {
        $metadata = & git -C $SourceRoot show "${Revision}:${relative}/package.json" 2>$null
        if ($LASTEXITCODE -ne 0) { throw "Commit $Revision does not contain $relative/package.json in $SourceRoot" }
        $identity = ($metadata -join "`n") | ConvertFrom-Json
        if ($identity.name -ne $name) { throw "Unexpected package identity at commit: $name" }
        $values[$name] = "${RepositoryUrl}?path=/${relative}#${Revision}"
    }
}

$manifest = Get-Content -LiteralPath $manifestPath -Raw -Encoding UTF8 | ConvertFrom-Json
foreach ($name in $names) {
    $manifest.dependencies | Add-Member -MemberType NoteProperty -Name $name -Value $values[$name] -Force
    Write-Output "$name = $($values[$name])"
}
if ($PSCmdlet.ShouldProcess($manifestPath, "Set both Ni framework dependencies to $Mode mode")) {
    $encoding = [Text.UTF8Encoding]::new($false)
    [IO.File]::WriteAllText($manifestPath, ($manifest | ConvertTo-Json -Depth 20) + "`n", $encoding)
    Write-Output 'Reopen/focus Unity to resolve packages and refresh packages-lock.json. Review both files before committing.'
    if ($Mode -eq 'Git') { Write-Output 'The commit was checked locally. Ensure it is reachable in the remote repository before resolving on other machines.' }
}
