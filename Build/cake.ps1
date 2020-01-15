##########################################################################
# This is the Cake bootstrapper script for PowerShell.
# Modified by Eddie Garmon
##########################################################################

<#
.SYNOPSIS
This is a Powershell script to bootstrap a Cake build.

.DESCRIPTION
This Powershell script will download NuGet if missing, restore NuGet tools (including Cake)
and execute your Cake build script with the parameters you provide.

.PARAMETER Target
The build script target to run.
.PARAMETER Configuration
The build configuration to use.
.PARAMETER Verbosity
Specifies the amount of information to be displayed.
.PARAMETER WhatIf
Performs a dry run of the build script.
No tasks will be executed.
.PARAMETER DebugCake
Allows debugging of the cake script by attaching a debugger.
.PARAMETER ScriptArgs
Remaining arguments are added here.

.LINK
https://cakebuild.net
#>

[CmdletBinding()]
Param(
    [string]$Target = "Help",
    [ValidateSet("Release", "Debug")]
    [string]$Configuration = "Release",
    [ValidateSet("Quiet", "Minimal", "Normal", "Verbose", "Diagnostic")]
    [string]$Verbosity = "Verbose",
    [Alias("DryRun","Noop")]
    [switch]$WhatIf,
    [switch]$DebugCake,
    [Parameter(Position=0,Mandatory=$false,ValueFromRemainingArguments=$true)]
    [string[]]$ScriptArgs
)

function GetProxyEnabledWebClient {
    $wc = New-Object System.Net.WebClient
    $proxy = [System.Net.WebRequest]::GetSystemWebProxy()
    $proxy.Credentials = [System.Net.CredentialCache]::DefaultCredentials        
    $wc.Proxy = $proxy
    return $wc
}

Write-Host "Preparing environment to run build script..."

$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

# Make sure tools folder exists
$ToolsPath = Join-Path $PSScriptRoot "..\Tools"
if (!(Test-Path $ToolsPath)) {
    Write-Host "Creating Tools directory..."
    New-Item -Path $ToolsPath -Type directory | out-null
}

# Make sure NuGet.exe is installed.
$NuGetExePath = Join-Path $ToolsPath "NuGet.exe"
$NuGetSourceUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
if (!(Test-Path $NuGetExePath)) {
    Write-Host "Installing NuGet.exe..."
    try {
        $wc = GetProxyEnabledWebClient
        $wc.DownloadFile($NuGetSourceUrl, $NuGetExePath)
    } catch {
        Throw "Could not download NuGet.exe."
    }
}

# Make sure that Cake has been installed.
$CakeVersion = "0.36.0"
Write-Host "Cake Version: $CakeVersion"
$CakeExePath = Join-Path $ToolsPath "Cake.$CakeVersion/Cake.exe"
if (!(Test-Path $CakeExePath)) {
    Write-Host "Installing Cake..."
    Invoke-Expression "&`"$NuGetExePath`" install Cake -Version $CakeVersion -OutputDirectory `"$ToolsPath`"" | Out-Null;
    if ($LASTEXITCODE -ne 0) {
        Throw "An error occurred while restoring Cake from NuGet."
    }
}

# Build Cake arguments
$bootstrapArguments = @();
$cakeArguments = @();
if ($ScriptArgs.Count -gt 0) {
    $first = $ScriptArgs.Get(0);
    if ($first.EndsWith(".cake")) {
        $bootstrapArguments = @($first);
        $cakeArguments = @($first);
        $ScriptArgs = $ScriptArgs | Where {$_ -ne $first};
    }
}
if ($cakeArguments.Length -eq 0) {
    $bootstrapArguments += "build.cake";
    $cakeArguments += "build.cake";
}
$bootstrapArguments += "--bootstrap";
if ($Target) { $cakeArguments += "-target=$Target" }
if ($Configuration) { $cakeArguments += "-configuration=$Configuration" }
if ($Verbosity) { $cakeArguments += "-verbosity=$Verbosity" }
if ($WhatIf) { $cakeArguments += "-dryrun" }
if ($DebugCake) { $cakeArguments += "--debug" }
$cakeArguments += $args

Write-Host ""

# Bootstrap Cake - module support via cake
Write-Host "Bootstraping build script..."
Write-Host $CakeExePath $bootstrapArguments
Write-Host ""
&$CakeExePath $bootstrapArguments
if ($LASTEXITCODE) { exit $LASTEXITCODE }

# Start Cake
Write-Host "Processing build script..."
Write-Host $CakeExePath $cakeArguments
Write-Host ""
&$CakeExePath $cakeArguments
exit $LASTEXITCODE
