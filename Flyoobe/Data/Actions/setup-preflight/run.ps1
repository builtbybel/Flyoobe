$ErrorActionPreference = 'Stop'

# This action is deliberately read-only. Hard blockers fail the recipe;
# things that may be perfectly normal on some PCs are reported as warnings.
$blockers = [System.Collections.Generic.List[string]]::new()
$warnings = [System.Collections.Generic.List[string]]::new()

function Write-CheckResult([string]$State, [string]$Message) {
    Write-Output ("[{0}] {1}" -f $State, $Message)
}

function Test-Administrator {
    $identity = [Security.Principal.WindowsIdentity]::GetCurrent()
    $principal = [Security.Principal.WindowsPrincipal]::new($identity)
    return $principal.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
}

function Get-PendingRestartReasons {
    $reasons = [System.Collections.Generic.List[string]]::new()

    if (Test-Path 'Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Component Based Servicing\RebootPending') {
        $reasons.Add('Component Based Servicing')
    }
    if (Test-Path 'Registry::HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update\RebootRequired') {
        $reasons.Add('Windows Update')
    }

    $sessionManager = Get-ItemProperty -LiteralPath 'Registry::HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager' -Name PendingFileRenameOperations -ErrorAction SilentlyContinue
    $pendingFileOperations = @($sessionManager.PendingFileRenameOperations) | Where-Object { -not [string]::IsNullOrWhiteSpace($_) }
    if ($pendingFileOperations.Count -gt 0) {
        $reasons.Add('pending file operations')
    }

    $activeName = (Get-ItemProperty -LiteralPath 'Registry::HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\ComputerName\ActiveComputerName' -Name ComputerName -ErrorAction SilentlyContinue).ComputerName
    $configuredName = (Get-ItemProperty -LiteralPath 'Registry::HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\ComputerName\ComputerName' -Name ComputerName -ErrorAction SilentlyContinue).ComputerName
    if ($activeName -and $configuredName -and $activeName -ne $configuredName) {
        $reasons.Add('pending computer rename')
    }

    return $reasons
}

try {
    Write-Output '=== Flyoobe setup preflight ==='
    Write-Output 'This check does not change Windows.'

    if (Test-Administrator) {
        Write-CheckResult 'OK' 'Flyoobe is running as administrator.'
    }
    else {
        $blockers.Add('Flyoobe is not running as administrator.')
        Write-CheckResult 'BLOCKED' $blockers[$blockers.Count - 1]
    }

    $restartReasons = @(Get-PendingRestartReasons)
    if ($restartReasons.Count -eq 0) {
        Write-CheckResult 'OK' 'No pending restart was found.'
    }
    else {
        $message = 'Restart Windows first. Pending: ' + ($restartReasons -join ', ') + '.'
        $blockers.Add($message)
        Write-CheckResult 'BLOCKED' $message
    }

    $systemDrive = [System.IO.DriveInfo]::new($env:SystemDrive + '\')
    if (-not $systemDrive.IsReady) { throw "$($env:SystemDrive) is not ready." }
    $freeGiB = [math]::Round($systemDrive.AvailableFreeSpace / 1GB, 1)
    if ($freeGiB -lt 5) {
        $message = "Only $freeGiB GB are free on $($env:SystemDrive). At least 5 GB are required."
        $blockers.Add($message)
        Write-CheckResult 'BLOCKED' $message
    }
    elseif ($freeGiB -lt 15) {
        $message = "Only $freeGiB GB are free on $($env:SystemDrive). Larger app installs or Windows servicing may need more room."
        $warnings.Add($message)
        Write-CheckResult 'WARN' $message
    }
    else {
        Write-CheckResult 'OK' "$freeGiB GB are free on $($env:SystemDrive)."
    }

    try {
        $battery = Get-CimInstance Win32_Battery -ErrorAction Stop | Select-Object -First 1
        if ($null -eq $battery) {
            Write-CheckResult 'OK' 'No battery was detected.'
        }
        elseif ($battery.BatteryStatus -in 1, 4, 5 -and $battery.EstimatedChargeRemaining -lt 20) {
            $message = "Battery is at $($battery.EstimatedChargeRemaining)% and appears to be discharging. Connect the charger before a long setup."
            $warnings.Add($message)
            Write-CheckResult 'WARN' $message
        }
        else {
            Write-CheckResult 'OK' "Battery level is $($battery.EstimatedChargeRemaining)%."
        }
    }
    catch {
        $message = 'Battery state could not be read; continuing.'
        $warnings.Add($message)
        Write-CheckResult 'WARN' $message
    }

    try {
        $online = Get-NetConnectionProfile -ErrorAction Stop | Where-Object {
            $_.IPv4Connectivity -eq 'Internet' -or $_.IPv6Connectivity -eq 'Internet'
        } | Select-Object -First 1
        if ($null -ne $online) {
            Write-CheckResult 'OK' 'Windows reports an active internet connection.'
        }
        else {
            $message = 'Windows does not report an internet connection. App installs may fail.'
            $warnings.Add($message)
            Write-CheckResult 'WARN' $message
        }
    }
    catch {
        $message = 'Network state could not be read; continuing.'
        $warnings.Add($message)
        Write-CheckResult 'WARN' $message
    }

    Write-Output ''
    if ($blockers.Count -gt 0) {
        Write-Output ("Preflight stopped setup: {0} blocker(s), {1} warning(s)." -f $blockers.Count, $warnings.Count)
        exit 1
    }

    Write-Output ("Preflight passed with {0} warning(s)." -f $warnings.Count)
    exit 0
}
catch {
    Write-Error $_
    exit 1
}
