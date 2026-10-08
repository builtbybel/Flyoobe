# Microsoft Defender maintenance (update signatures, repair, show status)
# Options: Update signatures; Repair definitions and update; Show Defender status

param([string]$choice)

function Get-MpCmdPath {
    $candidates = @(
        "$env:ProgramFiles\Windows Defender\MpCmdRun.exe",
        "$env:ProgramFiles\Microsoft Defender\MpCmdRun.exe"
    )
    foreach ($p in $candidates) { if (Test-Path $p) { return $p } }
    return $null
}

function Is-Admin {
    $id = [Security.Principal.WindowsIdentity]::GetCurrent()
    $pr = New-Object Security.Principal.WindowsPrincipal($id)
    return $pr.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
}

function Show-Status {
    try {
        $s = Get-MpComputerStatus
        Write-Output "=== Microsoft Defender Status ==="
        Write-Output ("Engine version:           {0}" -f $s.AMEngineVersion)
        Write-Output ("Platform version:         {0}" -f $s.AMProductVersion)
        Write-Output ("AV signature version:     {0}" -f $s.AntivirusSignatureVersion)
        Write-Output ("AV signature last update: {0}" -f $s.AntivirusSignatureLastUpdated)
        Write-Output ("AS signature version:     {0}" -f $s.AntispywareSignatureVersion)
        Write-Output ("Real-time protection:     {0}" -f $s.RealTimeProtectionEnabled)
        Write-Output ("NIS enabled:              {0}" -f $s.NISEnabled)
        Write-Output ("Service enabled:          {0}" -f $s.AMServiceEnabled)
    } catch {
        Write-Output "✘ Failed to read Defender status: $($_.Exception.Message)"
    }
}

switch ($choice) {

    "Update signatures" {
        if (-not (Is-Admin)) {
            Write-Output "ℹ Tip: Run as Administrator for the most reliable results."
        }

        try {
            # Primary: PowerShell cmdlet
            Update-MpSignature -ErrorAction Stop
            Write-Output "✔ Signatures updated via Update-MpSignature."
        } catch {
            # Fallback: MpCmdRun
            $mp = Get-MpCmdPath
            if ($mp) {
                Write-Output "↻ Falling back to MpCmdRun.exe ..."
                & $mp -SignatureUpdate | Out-String | Write-Output
            } else {
                Write-Output "✘ MpCmdRun.exe not found and Update-MpSignature failed."
            }
        }

        Show-Status
    }

    "Repair definitions and update" {
        if (-not (Is-Admin)) {
            Write-Output "✘ Please run this action as Administrator (required to reset definitions)."
            break
        }

        $mp = Get-MpCmdPath
        if (-not $mp) {
            Write-Output "✘ MpCmdRun.exe not found."
            break
        }

        try {
            Write-Output "↻ Removing all definitions (repair) ..."
            & $mp -RemoveDefinitions -All | Out-String | Write-Output
        } catch {
            Write-Output "✘ Failed to remove definitions: $($_.Exception.Message)"
        }

        try {
            Write-Output "↻ Updating signatures ..."
            Update-MpSignature -ErrorAction Stop
            Write-Output "✔ Signatures updated."
        } catch {
            Write-Output "↻ Fallback: MpCmdRun signature update ..."
            & $mp -SignatureUpdate | Out-String | Write-Output
        }

        Show-Status
    }

    "Show Defender status" {
        Show-Status
    }

    default {
        Write-Output "✘ Unknown option: $choice"
    }
}
