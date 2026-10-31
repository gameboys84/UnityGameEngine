#requires -Version 7.0
[CmdletBinding()]
param(
    [ValidateSet('check', 'status', 'commands', 'exec', 'eval')]
    [string] $Action = 'status',
    [string] $CommandName = '',
    [string] $DataJson = '{}',
    [string] $Code = '',
    [string] $CodeFile = '',
    [ValidateRange(100, 300000)] [int] $TimeoutMs = 15000,
    [string] $ProjectPath = (Split-Path -Parent $PSScriptRoot),
    [string] $CliPath = ''
)

$ErrorActionPreference = 'Stop'
$taskProject = [IO.Path]::GetFullPath($ProjectPath).TrimEnd('\', '/')
if (-not (Test-Path -LiteralPath (Join-Path $taskProject 'Assets') -PathType Container)) {
    throw 'Target is not a Unity project: Assets is missing.'
}
if ([string]::IsNullOrWhiteSpace($CliPath)) {
    $CliPath = Join-Path (Split-Path -Parent $taskProject) 'Design\local\UniCli-1.7.0\unicli.exe'
}
if (-not (Test-Path -LiteralPath $CliPath -PathType Leaf)) { throw "Pinned UniCli binary is missing: $CliPath" }
$taskVersion = (& $CliPath --version | Out-String).Trim()
if ($LASTEXITCODE -ne 0 -or $taskVersion -ne '1.7.0') { throw "Expected UniCli 1.7.0, received '$taskVersion'." }

$taskOldFocus = $env:UNICLI_FOCUS
$taskOldProject = $env:UNICLI_PROJECT
$env:UNICLI_FOCUS = '0'
$env:UNICLI_PROJECT = $taskProject
try {
    # These upstream commands only probe a pipe. They neither launch nor activate the Editor.
    if ($Action -in @('check', 'status')) {
        & $CliPath $Action --json
        if ($LASTEXITCODE -ne 0) { throw "UniCli $Action returned exit code $LASTEXITCODE." }
        return
    }

    $taskPidPath = Join-Path $taskProject 'Library\UniCli\server.pid'
    if (-not (Test-Path -LiteralPath $taskPidPath -PathType Leaf)) {
        throw 'UniCli server.pid is missing. The bridge has not loaded. This wrapper never opens an Editor.'
    }
    [int] $taskServerPid = 0
    if (-not [int]::TryParse((Get-Content -LiteralPath $taskPidPath -Raw).Trim(), [ref]$taskServerPid) -or $taskServerPid -le 0) {
        throw 'UniCli server.pid is invalid.'
    }
    # Fail closed if process identity cannot be inspected. No fallback to blind invocation.
    $taskProcess = Get-CimInstance Win32_Process -Filter "ProcessId=$taskServerPid"
    if ($null -eq $taskProcess -or [string]::IsNullOrWhiteSpace($taskProcess.ExecutablePath) -or
        [IO.Path]::GetFileName($taskProcess.ExecutablePath) -ne 'Unity.exe') {
        throw 'UniCli PID does not identify a readable Unity.exe process.'
    }
    $taskProjectArgument = [regex]::Match($taskProcess.CommandLine, '(?i)(?:^|\s)-projectPath\s+(?:"([^"]+)"|(\S+))')
    if (-not $taskProjectArgument.Success) { throw 'Unity process has no verifiable -projectPath argument.' }
    $taskProcessProject = if ($taskProjectArgument.Groups[1].Success) { $taskProjectArgument.Groups[1].Value } else { $taskProjectArgument.Groups[2].Value }
    $taskProcessProject = [IO.Path]::GetFullPath($taskProcessProject).TrimEnd('\', '/')
    if (-not [string]::Equals($taskProject, $taskProcessProject, [StringComparison]::OrdinalIgnoreCase)) {
        throw 'UniCli PID belongs to a different Unity project.'
    }
    $taskVersionText = Get-Content -LiteralPath (Join-Path $taskProject 'ProjectSettings\ProjectVersion.txt') -Raw
    $taskExpectedEditor = [regex]::Match($taskVersionText, '(?m)^m_EditorVersion:\s*(\S+)').Groups[1].Value
    $taskEditorVersion = [Diagnostics.FileVersionInfo]::GetVersionInfo($taskProcess.ExecutablePath).ProductVersion
    if (-not $taskExpectedEditor -or -not $taskEditorVersion.StartsWith($taskExpectedEditor, [StringComparison]::OrdinalIgnoreCase)) {
        throw 'Running Editor executable version does not match ProjectVersion.txt.'
    }

    if ($Action -eq 'commands') { $CommandName = 'Commands.List'; $DataJson = '{}' }
    if ($Action -eq 'eval') {
        if ($CodeFile) { $Code = Get-Content -LiteralPath $CodeFile -Raw }
        if ([string]::IsNullOrWhiteSpace($Code)) { throw 'eval requires -Code or -CodeFile.' }
        if ($Code -match '(?i)SetForegroundWindow|BringWindowToTop|\.Focus\s*\(|DisplayDialog|OpenFilePanel|SaveFilePanel') {
            throw 'Focus activation and modal dialog APIs are disabled in this automation wrapper.'
        }
        $CommandName = 'Eval'
        $DataJson = @{ code = $Code } | ConvertTo-Json -Compress
    }
    if ([string]::IsNullOrWhiteSpace($CommandName)) { throw 'exec requires -CommandName.' }
    if ($CommandName -match '(?i)^Window\.Focus$') { throw 'Window.Focus is disabled.' }
    $null = ConvertFrom-Json -InputObject $DataJson -ErrorAction Stop

    # Never call upstream exec/eval: CommandExecutor would auto-launch if the Editor exited between checks.
    # Its documented v1 protocol has no focus or process-launch operations in this client implementation.
    $taskDataPath = ((Join-Path $taskProject 'Assets') -replace '\\', '/').ToLowerInvariant()
    $taskSha = [Security.Cryptography.SHA256]::Create()
    try { $taskHash = [BitConverter]::ToString($taskSha.ComputeHash([Text.Encoding]::UTF8.GetBytes($taskDataPath))).Replace('-', '').ToLowerInvariant().Substring(0, 8) }
    finally { $taskSha.Dispose() }
    $taskPipe = [IO.Pipes.NamedPipeClientStream]::new('.', "unicli-$taskHash", [IO.Pipes.PipeDirection]::InOut, [IO.Pipes.PipeOptions]::Asynchronous)
    $taskCancellation = [Threading.CancellationTokenSource]::new($TimeoutMs)
    function Read-UniCliExact([int] $Count) {
        $taskBuffer = [byte[]]::new($Count)
        $taskRead = 0
        while ($taskRead -lt $Count) {
            $taskStep = $taskPipe.ReadAsync($taskBuffer, $taskRead, $Count - $taskRead, $taskCancellation.Token).GetAwaiter().GetResult()
            if ($taskStep -le 0) { throw 'UniCli closed the pipe before the response completed.' }
            $taskRead += $taskStep
        }
        return ,$taskBuffer
    }
    function Write-UniCliBytes([byte[]] $Bytes) {
        $null = $taskPipe.WriteAsync($Bytes, 0, $Bytes.Length, $taskCancellation.Token).GetAwaiter().GetResult()
    }
    try {
        $null = $taskPipe.ConnectAsync([Math]::Min(3000, $TimeoutMs), $taskCancellation.Token).GetAwaiter().GetResult()
        Write-UniCliBytes ([byte[]]@(0x55, 0x43, 0x4c, 0x49, 1, 0))
        $taskHandshake = Read-UniCliExact 6
        if ([BitConverter]::ToString($taskHandshake) -ne '55-43-4C-49-01-00') { throw 'UniCli handshake mismatch.' }
        $taskRequest = @{ command = $CommandName; data = $DataJson; format = 'json'; cwd = $taskProject; clientVersion = '1.7.0' } | ConvertTo-Json -Compress
        $taskBytes = [Text.Encoding]::UTF8.GetBytes($taskRequest)
        if ($taskBytes.Length -gt 1048576) { throw 'Command exceeds the UniCli protocol size limit.' }
        Write-UniCliBytes ([BitConverter]::GetBytes([int]$taskBytes.Length))
        Write-UniCliBytes $taskBytes
        $null = $taskPipe.FlushAsync($taskCancellation.Token).GetAwaiter().GetResult()
        $taskAck = Read-UniCliExact 1
        if ($taskAck[0] -ne 1) { throw 'UniCli returned an invalid acknowledgement.' }
        $taskLength = [BitConverter]::ToInt32((Read-UniCliExact 4), 0)
        if ($taskLength -le 0 -or $taskLength -gt 1048576) { throw 'UniCli response size is invalid.' }
        $taskResponseText = [Text.Encoding]::UTF8.GetString((Read-UniCliExact $taskLength))
        $taskResponse = ConvertFrom-Json -InputObject $taskResponseText
        if ($taskResponse.serverVersion -ne '1.7.0') { throw 'UniCli bridge version is not 1.7.0.' }
        $taskResponseText
        if (-not $taskResponse.success) { throw "UniCli command failed: $($taskResponse.message)" }
    }
    finally { $taskPipe.Dispose(); $taskCancellation.Dispose() }
}
finally {
    $env:UNICLI_FOCUS = $taskOldFocus
    $env:UNICLI_PROJECT = $taskOldProject
}
