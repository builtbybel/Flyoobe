# Post-install Essentials – quick launcher for Windows tools (+ .NET 3.5)
# Options: Open Windows Features (classic); Open Optional features (Settings); Install .NET Framework 3.5; Open Programs & Features; Open Device Manager; Open Windows Update; Open Default Apps; List features via DISM (table); Open PowerShell (Admin)

param([string]$choice)

function Is-Admin {
    $id = [Security.Principal.WindowsIdentity]::GetCurrent()
    $pr = New-Object Security.Principal.WindowsPrincipal($id)
    return $pr.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
}

switch ($choice) {

    "Open Windows Features (classic)" {
        Start-Process "optionalfeatures.exe"
        Write-Output "Opened: Windows Features (classic)."
    }

    "Open Optional features (Settings)" {
        Start-Process "ms-settings:optionalfeatures"
        Write-Output "Opened: Settings → Optional features."
    }

    "Install .NET Framework 3.5" {
        if (-not (Is-Admin)) {
            Write-Output "✘ Administrator required to enable .NET Framework 3.5."
            break
        }
        Write-Output "Enabling .NET Framework 3.5… (this may take a few minutes)"
        Start-Process -FilePath "dism.exe" -ArgumentList "/Online /Enable-Feature /FeatureName:NetFx3 /All /NoRestart" -Wait
        Write-Output "✔ .NET Framework 3.5 command completed. A restart may be required."
    }

    "Open Programs & Features" {
        Start-Process "control.exe" "appwiz.cpl"
        Write-Output "Opened: Programs & Features."
    }

    "Open Device Manager" {
        Start-Process "devmgmt.msc"
        Write-Output "Opened: Device Manager."
    }

    "Open Windows Update" {
        Start-Process "ms-settings:windowsupdate"
        Write-Output "Opened: Windows Update."
    }

    "Open Default Apps" {
        Start-Process "ms-settings:defaultapps"
        Write-Output "Opened: Default Apps."
    }

    "List features via DISM (table)" {
        Write-Output "Listing optional features via DISM…"
        Start-Process -FilePath "dism.exe" -ArgumentList "/Online /Get-Features /Format:Table" -Wait -NoNewWindow
        Write-Output "Finished listing features."
    }

    "Open PowerShell (Admin)" {
        Write-Output "Opening PowerShell as Administrator…"
        Start-Process -FilePath "powershell.exe" -ArgumentList "-NoExit" -Verb RunAs
    }

    default {
        Write-Output "✘ Unknown option: $choice"
    }
}
