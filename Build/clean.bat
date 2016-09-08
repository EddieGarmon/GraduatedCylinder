@echo off

powershell.exe -NoProfile -ExecutionPolicy unrestricted -Command "& {Import-Module .\Psake\psake.psm1; Invoke-psake .\Psake\build_script.ps1 Clean;}" 

Pause