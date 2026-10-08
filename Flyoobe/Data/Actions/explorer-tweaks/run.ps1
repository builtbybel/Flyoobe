# File Explorer tweaks
# Options: Show file extensions; Hide file extensions; Show hidden files; Hide hidden files; Open This PC; Open Quick Access

param([string]$choice)

switch ($choice) {
  "Show file extensions" { Set-ItemProperty "HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name HideFileExt -Value 0; Write-Output "File extensions: visible" }
  "Hide file extensions" { Set-ItemProperty "HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name HideFileExt -Value 1; Write-Output "File extensions: hidden" }
  "Show hidden files"    { Set-ItemProperty "HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name Hidden -Value 1; Write-Output "Hidden files: shown" }
  "Hide hidden files"    { Set-ItemProperty "HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name Hidden -Value 2; Write-Output "Hidden files: hidden" }
  "Open This PC"         { Set-ItemProperty "HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name LaunchTo -Value 1; Write-Output "Open: This PC" }
  "Open Quick Access"    { Set-ItemProperty "HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name LaunchTo -Value 2; Write-Output "Open: Quick Access" }
  default { Write-Output "Unknown option: $choice" }
}
