// ReSharper disable InconsistentNaming

#pragma warning disable IDE1006 // Naming Styles
using System.Collections.Generic;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Utilities.Collections;
using Serilog;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.ReportGenerator.ReportGeneratorTasks;

[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{

    [Parameter]
    [Secret]
    readonly string NugetApiKey;

    [Parameter]
    readonly string NugetApiUrl = "https://api.nuget.org/v3/index.json";

    [Solution]
    readonly Solution Solution;

    [Parameter("Configuration to build - Default is 'Release'")]
    Configuration Configuration = Configuration.Release;

    Target Clean =>
        def => def.Before(Restore)
                  .Executes(() => {
                                PathToSources.GlobDirectories("**/bin", "**/obj").ForEach(path => path.DeleteDirectory());
                                PathToTests.GlobDirectories("**/bin", "**/obj").ForEach(path => path.DeleteDirectory());
                                PathToArtifacts.CreateOrCleanDirectory();
                            });

    Target Compile =>
        def => def.DependsOn(Restore)
                  .Executes(() => {
                                DotNetBuild(s => s.SetProjectFile(Solution)
                                                  .SetConfiguration(Configuration)
                                                  .EnableNoLogo()
                                                  .EnableNoRestore()
                                                  .EnableDeterministic()
                                                  .EnableContinuousIntegrationBuild());
                            });

    Target Debug => def => def.Before(Compile).Executes(() => Configuration = Configuration.Debug);

    Target Pack =>
        def => def.DependsOn(Compile)
                  .After(Test)
                  .Produces(PathToGeneratedPackages)
                  .Executes(() => {
                                DotNetPack(s => s.SetProject(Solution)
                                                 .SetConfiguration(Configuration)
                                                 .SetOutputDirectory(PathToGeneratedPackages)
                                                 .EnableNoLogo()
                                                 .EnableNoRestore()
                                                 .EnableNoBuild()
                                                 .EnableContinuousIntegrationBuild());
                            });

    AbsolutePath PathToArtifacts => RootDirectory / "Artifacts";

    AbsolutePath PathToCoverageReport => PathToArtifacts / "04.Coverage.Report";

    AbsolutePath PathToCoverageResults => PathToArtifacts / "03.Coverage.Results";

    AbsolutePath PathToGeneratedPackages => PathToArtifacts / "05.Packages";

    AbsolutePath PathToSources => RootDirectory / "Source";

    AbsolutePath PathToTestOutput => PathToArtifacts / "01.Test.Output";

    AbsolutePath PathToTestResults => PathToArtifacts / "02.Test.Results";

    AbsolutePath PathToTests => RootDirectory / "Tests";

    Target Publish =>
        def => def.DependsOn(Clean)
                  .DependsOn(Test)
                  .DependsOn(Pack)
                  .Requires(() => NugetApiUrl)
                  .Requires(() => NugetApiKey)
                  .Requires(() => Configuration.Equals(Configuration.Release))
                  .WhenSkipped(DependencyBehavior.Execute)
                  .Executes(() => {
                                DotNetNuGetPush(s => s.SetSource(NugetApiUrl)
                                                      .SetApiKey(NugetApiKey)
                                                      .EnableNoServiceEndpoint()
                                                      .EnableSkipDuplicate()
                                                      .CombineWith(PathToGeneratedPackages.GlobFiles("*.nupkg"),
                                                                   (s, package) => s.SetTargetPath(package)));
                            });

    Target Restore => def => def.Executes(() => { DotNetRestore(s => s.SetProjectFile(Solution)); });

    Target Test =>
        def => def.DependsOn(Compile)
                  .Produces(PathToTestOutput, PathToTestResults, PathToCoverageResults, PathToCoverageReport)
                  .Executes(() => {
                                PathToTestOutput.CreateOrCleanDirectory();
                                PathToTestResults.CreateOrCleanDirectory();
                                PathToCoverageResults.CreateOrCleanDirectory();
                                PathToCoverageReport.CreateOrCleanDirectory();

                                IEnumerable<Project> testProjects = Solution.GetAllProjects("*.Tests");

                                foreach (Project project in testProjects) {
                                    // Execute the test executable directly (bypasses VSTest overhead)
                                    DotNetRun(s => s.SetProjectFile(project)
                                                    .SetConfiguration(Configuration)
                                                    .EnableNoRestore()
                                                    .EnableNoBuild()
                                                    // Native switches feed directly into the built-in coverage engine
                                                    .SetApplicationArguments("--coverage",
                                                                             "--coverage-output-format",
                                                                             "cobertura",
                                                                             "--results-directory",
                                                                             $"{PathToCoverageResults}"));
                                }

                                ReportGenerator(s => s.SetTargetDirectory(PathToCoverageReport)
                                                      .SetFramework("net10.0")
                                                      .SetReports(PathToCoverageResults / "*.xml")
                                                      .SetReportTypes(ReportTypes.HtmlInline, ReportTypes.Badges));

                                Log.Information("Coverage report generated at {Path}", PathToCoverageReport / "index.html");
                            });

    public static int Main() => Execute<Build>(x => x.Test, x => x.Pack);

}