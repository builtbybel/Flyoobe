$ErrorActionPreference = 'Stop'
try {
    & ie4uinit.exe -ClearIconCache
    Stop-Process -Name explorer -Force -ErrorAction SilentlyContinue
    Remove-Item "$env:LOCALAPPDATA\IconCache.db" -Force -ErrorAction SilentlyContinue
    Get-ChildItem "$env:LOCALAPPDATA\Microsoft\Windows\Explorer" -Filter 'iconcache*' -File -ErrorAction SilentlyContinue |
        Remove-Item -Force -ErrorAction SilentlyContinue
    Start-Process explorer.exe
    exit 0
}
catch {
    Start-Process explorer.exe -ErrorAction SilentlyContinue
    Write-Error $_
    exit 1
}
