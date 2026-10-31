param(
    [string]$UnityEditor = 'C:\Program Files\Unity\Hub\Editor\2022.3.62f2\Editor\Unity.exe',
    [switch]$BatchMode,
    [string]$ExecuteMethod,
    [string]$LogPath
)
$ErrorActionPreference = 'Stop'
$projectPath = (Resolve-Path -LiteralPath (Join-Path $PSScriptRoot '..')).Path
if (!(Test-Path -LiteralPath $UnityEditor)) { throw "Unity Editor does not exist: $UnityEditor" }
# Agent shells may intentionally omit these variables. UPM needs standard Windows user directories.
if (!$env:USERPROFILE) { $env:USERPROFILE = [Environment]::GetFolderPath('UserProfile') }
if (!$env:LOCALAPPDATA) { $env:LOCALAPPDATA = [Environment]::GetFolderPath('LocalApplicationData') }
if (!$env:APPDATA) { $env:APPDATA = [Environment]::GetFolderPath('ApplicationData') }
if (!$env:ProgramData) { $env:ProgramData = [Environment]::GetFolderPath('CommonApplicationData') }
if (!$env:ALLUSERSPROFILE) { $env:ALLUSERSPROFILE = [Environment]::GetFolderPath('CommonApplicationData') }
if (!$LogPath) {
    $reportPath = Join-Path $projectPath '..\Design\reports\de-rebuild'
    New-Item -ItemType Directory -Path $reportPath -Force | Out-Null
    $LogPath = Join-Path $reportPath 'editor.log'
}
$arguments = @('-projectPath', ('"' + $projectPath + '"'), '-logFile', ('"' + $LogPath + '"'))
if ($BatchMode) { $arguments += @('-batchmode', '-nographics') }
if ($ExecuteMethod) { $arguments += @('-executeMethod', $ExecuteMethod) }
if ($BatchMode -and $ExecuteMethod) { $arguments += '-quit' }
# The Editor is interactive; batch verification is a hidden background process.
$windowStyle = if ($BatchMode) { 'Hidden' } else { 'Normal' }
$process = Start-Process -FilePath $UnityEditor -WorkingDirectory $projectPath -ArgumentList $arguments -WindowStyle $windowStyle -PassThru
if ($BatchMode) { $process.WaitForExit(); exit $process.ExitCode }
$process | Select-Object Id, ProcessName

