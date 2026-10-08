# Choose your default power plan
# Options: Balanced; High Performance; Power Saver

param([string]$choice)

if ($choice -eq "High Performance") {
    powercfg -setactive SCHEME_MIN
}
elseif ($choice -eq "Balanced") {
    powercfg -setactive SCHEME_BALANCED
}
elseif ($choice -eq "Power Saver") {
    powercfg -setactive SCHEME_MAX
}
else {
    Write-Error "Unknown choice: $choice"
}
