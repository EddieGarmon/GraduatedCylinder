// INSTALL ADDINS
//////////////////////////////////

// INSTALL TOOLS
//////////////////////////////////
#tool "nuget:?package=xunit.runner.console&version=2.4.1"

// Reference Local Helper Assemblies
//////////////////////////////////


// PATHS
//////////////////////////////////
DirectoryPath buildDir = MakeAbsolute(Directory("."));
DirectoryPath rootDir = buildDir.Combine(Directory("../")).Collapse();
DirectoryPath sourceDir = rootDir.Combine(Directory("./Source"));
DirectoryPath testsDir = rootDir.Combine(Directory("./Tests"));
DirectoryPath deployDir = rootDir.Combine(Directory("./Deploy"));
FilePath solutionFile = rootDir.CombineWithFilePath(File("./GraduatedCylinder.sln"));

Information(""); // just a blank line for easy output reading
Information("Working Paths:");
Information("  Root: {0}", rootDir.FullPath);
Information(" Build: {0}", buildDir.FullPath);
Information("Source: {0}", sourceDir.FullPath);
Information(" Tests: {0}", testsDir.FullPath);
Information("Deploy: {0}", deployDir.FullPath);
Information(""); // just a blank line for easy output reading
Information("Build Solution: {0}", solutionFile.FullPath);
Information(""); // just a blank line for easy output reading

// SETUP - Occurs no matter what 'Task' is targeted.
//////////////////////////////////
/* Setup(context => {
    //prep version information?
}); */

/*TaskSetup(
    taskSetupContext => {
        ICakeTaskInfo task = taskSetupContext.Task;
        Information("Executing (Name: {0}, Description: {1})",
            task.Name,
            task.Description);
    }); */

// TEARDOWN - Occurs no matter what 'Task' is targeted.
//////////////////////////////////
/* Teardown(context => {
    Information("Starting Teardown...");
    if (context.Successful) {
        var shouldPublish = false;
        if (shouldPublish) {
            Information("Publishing...");
        }
    }
    Information("Finished running tasks.");
}); */

// Helper Functions
//////////////////////////////////
string GetRunnableTarget() {
    string target = Argument("target", "Help");
    if (target.Equals("?", StringComparison.OrdinalIgnoreCase)) {
        target = "Help";
    }

    // validate Target is valid - otherwise default to 'Help'
    if (Tasks.SingleOrDefault(t => t.Name == target) == null) {
        Warning("****  WARNING   WARNING   WARNING   WARNING  ****");
        Warning("The requested target '{0}' was not available.", target);
        Warning("");
        return "Help";
    }

    return target;
}

void CleanSourceTree(DirectoryPath rootToClean) {
    string[] removeThese = new[] { "bin", "Bin", "obj", "Obj" };
    foreach( var dir in GetSubDirectories(rootToClean) ) {
        bool clean = false;
        if (removeThese.Contains(dir.GetDirectoryName())) {
            clean = true;
        }
        if (clean) {
            CleanDirectory(dir);
        } else {
            CleanSourceTree(dir);
        }
    }
}


// TASKS
//////////////////////////////////

Task("Help")
    .Description("Show all available Tasks and their descriptions.")
    .Does(context => {
        Information("");
        foreach (var iTask in Tasks) {
            CakeTask task = ((CakeTask)iTask);
            bool isMeta = task.Actions.Count == 0;
            string name = string.Format("{0}{1}", task.Name, isMeta ? "*" : null);
            Information("{0} - {1}", name.PadRight(18), task.Description);

            if (task.Dependencies.Count >= 1) {
                bool isFirst = true;
                StringBuilder builder = new StringBuilder("\tDependencies: ");
                foreach (var dependency in task.Dependencies) {
                    if (isFirst) {
                        isFirst = false;
                    } else {
                        builder.Append(", ");
                    }
                    builder.Append(dependency.Name);
                }
                Information(builder.ToString());
            }
        }
        Information("");
    });    

Task("Clean")
    .Description("Clean up all build artifacts.")
    .IsDependentOn("Clean-Source")
    .IsDependentOn("Clean-Tests")
    .IsDependentOn("Clean-Deploy");

Task("Clean-Source")
    .Description("Removes all bin and obj directories in the Source tree.")
    .Does(() => {
        CleanSourceTree(sourceDir);
    });

Task("Clean-Tests")
    .Description("Removes all bin and obj directories in the Tests tree.")
    .Does(() => {
        CleanSourceTree(testsDir);
    });

Task("Clean-Deploy")
    .Description("Empties the Deploy directory.")
    .Does(() => {
        CleanDirectory(deployDir);
    });

Task("Restore")
    .Description("Restores all project dependencies locally to satisfy build.")
    .IsDependentOn("Clean")
    .Does(() => {
        DotNetCoreRestore(solutionFile.FullPath);
    });

Task("Build")
    .Description("Compiles all projects in the build solution.")
    .IsDependentOn("Restore")
    .Does(() => {
        DotNetCoreBuild(
            solutionFile.FullPath,
            new DotNetCoreBuildSettings() {
                Configuration = configuration,
                Verbosity = DotNetCoreVerbosity.Minimal,
                ArgumentCustomization = args => args.Append("--no-restore"),
            }
        );
    });

Task("RunTests")
    .Description("Runs all the automated xUnit tests.")
    .IsDependentOn("Build")
    .Does(() => {
		var testProjects = GetFiles(testsDir.FullPath + "/**/*.csproj");
		foreach (var testProject in testProjects) {
			DotNetCoreTest(
				testProject.FullPath,
				new DotNetCoreTestSettings() {
					Configuration = configuration,
					Verbosity = DotNetCoreVerbosity.Minimal,
					NoBuild = true,
					ArgumentCustomization = args => args.Append("--no-restore"),
				}
			);
		}
    });

Task("Package")
    .Description("Prepared Deploy tree with all NuGet packages in the build solution.")
    .IsDependentOn("RunTests")
    .Does(() => {
		var sourceProjects = GetFiles(sourceDir.FullPath + "/**/*.csproj");
		foreach (var sourceProject in sourceProjects) {
			DotNetCorePack(
				sourceProject.FullPath,
				new DotNetCorePackSettings() {
					Configuration = configuration,
					OutputDirectory = deployDir,
					NoBuild = true,
					ArgumentCustomization = args => args.Append("--no-restore"),
				}
			);
		}
    });

var target = GetRunnableTarget();
Information("Target: {0}", target);

var configuration = Argument("configuration", "Release");
Information("Configuration: {0}", configuration);

RunTarget(target);

