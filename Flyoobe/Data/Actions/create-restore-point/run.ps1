$ErrorActionPreference = 'Stop'
try {
    Enable-ComputerRestore -Drive "$env:SystemDrive\"
    Checkpoint-Computer -Description 'Before Flyoobe setup' -RestorePointType 'MODIFY_SETTINGS'
    exit 0
}
catch {
    Write-Error $_
    exit 1
}
