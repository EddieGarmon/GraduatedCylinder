# Psake (https://github.com/psake/psake) build script

framework 4.0x86

properties {	
	$script:newPackagesPath = $psake.build_script_dir + '\Artifacts\Packages';
}

task default -depends Test # ?

task ? -Description "Helper to display task info" {
	'Supported tasks are: PackageRestore, Clean, Build, Rebuild, Test, Package, and Release'
	# 'Samples'
}

task PackageRestore {
	Write-Host '>>> Restoring packages';
		
	Get-ChildItem ($psake.build_script_dir + "\..\Libs\") -Recurse | 
		Where-Object { (!$_.PsIsContainer) } |
		Where-Object { ($_.Name -eq "packages.config") } | 
		ForEach-Object { 
			Write-Host "> " $_.FullName
			exec { & '.\NuGet\NuGet.exe' install $_.FullName -Verbosity detailed -NonInteractive }
		}
}

task Clean {
	Write-Host '>>> Cleaning bin and obj directories';

	Get-ChildItem ($psake.build_script_dir + "\..\Libs\") -Recurse | 
		Where-Object { ($_.PsIsContainer) } |
		Where-Object { ($_.Name -eq "obj") -or ($_.Name -eq "bin") } | 
		ForEach-Object { 
			Write-Host "> " $_.FullName
			Remove-Item -LiteralPath $_.FullName -Recurse -Force
		}
}

task Build -depends PackageRestore {
	Write-Host '>>> Building assemblies';

	Get-ChildItem ($psake.build_script_dir + "\..\Libs\") -Recurse | 
		Where-Object { (!$_.PsIsContainer) } |
		Where-Object { ($_.Name -like "*.csproj") } | 
		ForEach-Object { 
			Write-Host "> " $_.FullName
			exec { msbuild /nologo /v:m /p:Configuration=Release /t:Build $_.FullName }
		}
}

task Rebuild -depends Clean, Build

task Test -depends Build { 
	Write-Host '>>> Running tests';
	
	Get-ChildItem ($psake.build_script_dir + "\..\Libs\") -Recurse | 
		Where-Object { (!$_.PsIsContainer) } |
		Where-Object { ($_.FullName -like "*\bin\Release\Specs.*.dll") } | 
		ForEach-Object { 
			Write-Host "> " $_.FullName
			if ($_.FullName -like "*F35*") {
				exec { & '.\XUnit\xunit.console.exe' $_.FullName /silent }
			} else {
				exec { & '.\XUnit\xunit.console.clr4.exe' $_.FullName /silent }
			}
		}
}

task Package -depends Build {
	Write-Host '>>> Building packages';

	if (!(Test-Path $newPackagesPath)) { mkdir $newPackagesPath }
	
	Get-ChildItem ($psake.build_script_dir + "\..\Libs\") -Recurse | 
		Where-Object { (!$_.PsIsContainer) } |
		Where-Object { ($_.Name -like "*.nuspec") } | 
		ForEach-Object { 
			Write-Host "> " $_.FullName
			exec { & '.\NuGet\NuGet.exe' pack ($_.FullName) -OutputDirectory $newPackagesPath -Verbosity detailed -NonInteractive }
		}
}

task Release -depends Clean, Test, Package
