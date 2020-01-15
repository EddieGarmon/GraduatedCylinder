@echo off
powershell.exe -NoProfile -ExecutionPolicy unrestricted -Command "./Cake.ps1 -verbosity \"Verbose\" -Target \"Clean\""
pause