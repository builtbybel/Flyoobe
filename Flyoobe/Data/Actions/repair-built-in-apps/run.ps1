$ErrorActionPreference = 'Continue'
$packages = @(Get-AppxPackage -AllUsers | Where-Object {
    $_.InstallLocation -and (Test-Path (Join-Path $_.InstallLocation 'AppxManifest.xml'))
})
if ($packages.Count -eq 0) { throw 'No installed app manifests were found.' }

$registered = 0
foreach ($package in $packages) {
    try {
        Add-AppxPackage -DisableDevelopmentMode -Register (Join-Path $package.InstallLocation 'AppxManifest.xml') -ErrorAction Stop
        $registered++
    }
    catch {
        Write-Warning "$($package.Name): $($_.Exception.Message)"
    }
}
if ($registered -eq 0) { throw 'Windows could not re-register any built-in app.' }
Write-Output "Re-registered $registered of $($packages.Count) app packages."
