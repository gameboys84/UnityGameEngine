param([string]$Method, [string]$ParamsJson = '{}', [string]$OutputPath)
$ErrorActionPreference = 'Stop'
$headers = @{Accept='application/json, text/event-stream'}
$sessionFile = Join-Path $PSScriptRoot 'mcp-session.txt'
if (Test-Path $sessionFile) { $headers['Mcp-Session-Id'] = (Get-Content $sessionFile -Raw).Trim() }
$payload = @{jsonrpc='2.0';id=([Guid]::NewGuid().ToString('N'));method=$Method;params=($ParamsJson | ConvertFrom-Json)} | ConvertTo-Json -Depth 30 -Compress
$response = Invoke-WebRequest -Uri 'http://127.0.0.1:8080/mcp' -Method Post -Headers $headers -ContentType 'application/json' -Body ([Text.Encoding]::UTF8.GetBytes($payload)) -UseBasicParsing -TimeoutSec 45
$dataLine = ($response.Content -split "`n" | Where-Object { $_.StartsWith('data: ') } | Select-Object -Last 1)
$result = if ($dataLine) { $dataLine.Substring(6) | ConvertFrom-Json } else { $response.Content | ConvertFrom-Json }
if ($result.error) { throw ($result.error | ConvertTo-Json -Compress) }
$value = $result.result
if ($value.structuredContent) { $value = $value.structuredContent }
elseif ($value.contents -and $value.contents[0].text) { $value = $value.contents[0].text | ConvertFrom-Json }
elseif ($value.content -and $value.content[0].type -eq 'text') {
    try { $value = $value.content[0].text | ConvertFrom-Json } catch { }
}
if ($value.result -and $value.result.PSObject.Properties['success']) { $value = $value.result }
$json = $value | ConvertTo-Json -Depth 35
if ($OutputPath) { $json | Set-Content -LiteralPath $OutputPath -Encoding UTF8 } else { $json }
