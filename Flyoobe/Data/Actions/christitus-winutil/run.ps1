# Options: Run utility

param([string]$choice)

$ErrorActionPreference = 'Stop'
if ($choice -ne 'Run utility') { throw "Unknown option: $choice" }

$uri = 'https://christitus.com/win'
Write-Output "Downloading the current Chris Titus Tech WinUtil script from $uri ..."
$source = Invoke-RestMethod -Uri $uri -UseBasicParsing -ErrorAction Stop
if ([string]::IsNullOrWhiteSpace($source)) { throw 'The WinUtil endpoint returned an empty script.' }

Write-Output 'Starting WinUtil...'
& ([scriptblock]::Create($source))
