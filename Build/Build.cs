// ReSharper disable InconsistentNaming

#pragma warning disable IDE1006 // Naming Styles
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.ReportGenerator.ReportGeneratorTasks;

[ShutdownDotNetAfterServerBuild]
class Build : NukeBuild
{

    [Parameter("Configuration to build - Default is 'Release'")]
    readonly Configuration Configuration = Configuration.Release;

    [Parameter]
    [Secret]
    readonly string NugetApiKey;

    [Parameter]
    readonly string NugetApiUrl = "https://api.nuget.org/v3/index.json";

    [Solution]
    readonly Solution Solution;

    Target Clean =>
        _ => _.Before(Restore)
              .Executes(() => {
                            PathToSources.GlobDirectories("**/bin", "**/obj").ForEach(path => path.DeleteDirectory());
                            PathToTests.GlobDirectories("**/bin", "**/obj").ForEach(path => path.DeleteDirectory());
                            PathToSources.GlobFiles("**/*.g.cs").ForEach(path => path.DeleteFile());
                            PathToArtifacts.CreateOrCleanDirectory();
                        });

    Target Compile =>
        _ => _.DependsOn(Restore)
              .Executes(() => {
                            // The build depends on massive code generation, so project build order matters
                            // therefore we cannot just build the solution, unfortunately

                            string[] buildOrder = {
                                //Libraries
                                "GraduatedCylinder.Roslyn",
                                "Nmea.Core0183",
                                "GraduatedCylinder",
                                "GraduatedCylinder.Geo",
                                "GraduatedCylinder.Geo.Gps",
                                "GraduatedCylinder.Geo.Laser",
                                "GraduatedCylinder.Json",
                                "GraduatedCylinder.IoT",
                                "GraduatedCylinder.IoT.Text",
                                "GraduatedCylinder.IoT.Json",

                                //Tests
                                "Nmea.Core0183.Tests",
                                "GraduatedCylinder.Tests",
                                "GraduatedCylinder.Geo.Tests",
                                "GraduatedCylinder.Geo.Gps.Tests",
                                "GraduatedCylinder.Geo.Laser.Tests",
                                "GraduatedCylinder.Json.Tests",
                                "GraduatedCylinder.IoT.Tests"
                            };

                            foreach (string name in buildOrder) {
                                Project project = Solution.AllProjects.Single(p => p.Name == name);
                                DotNetBuild(s => s.SetProjectFile(project.Path)
                                                  .SetConfiguration(Configuration)
                                                  .EnableNoLogo()
                                                  .EnableNoRestore()
                                                  .EnableDeterministic()
                                                  .EnableContinuousIntegrationBuild());
                            }
                        });

    Target Pack =>
        _ => _.DependsOn(Compile)
              .After(Test)
              .Produces(PathToArtifacts)
              .Executes(() => {
                            DotNetPack(s => s.SetConfiguration(Configuration)
                                             .SetOutputDirectory(PathToArtifacts)
                                             .EnableNoLogo()
                                             .EnableNoRestore()
                                             .EnableNoBuild()
                                             .EnableContinuousIntegrationBuild()
                                             .SetProject(Solution));
                        });

    AbsolutePath PathToArtifacts => RootDirectory / "Artifacts";

    AbsolutePath PathToCoverageReport => PathToArtifacts / "04 Coverage Report";

    AbsolutePath PathToCoverageResults => PathToArtifacts / "03 Coverage Results";

    AbsolutePath PathToGeneratedPackages => PathToArtifacts / "05 Packages";

    AbsolutePath PathToSources => RootDirectory / "Source";

    AbsolutePath PathToTestOutput => PathToArtifacts / "01 Test Output";

    AbsolutePath PathToTestResults => PathToArtifacts / "02 Test Results";

    AbsolutePath PathToTests => RootDirectory / "Tests";

    Target Publish =>
        _ => _.DependsOn(Clean)
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

    Target Restore => _ => _.Executes(() => { DotNetRestore(s => s.SetProjectFile(Solution)); });

    Target Test =>
        _ => _.DependsOn(Compile)
              .Produces(PathToTestOutput, PathToTestResults, PathToCoverageResults, PathToCoverageReport)
              .Executes(() => {
                            PathToTestOutput.CreateOrCleanDirectory();
                            PathToTestResults.CreateOrCleanDirectory();
                            PathToCoverageResults.CreateOrCleanDirectory();
                            PathToCoverageReport.CreateOrCleanDirectory();

                            List<Project> testProjects = Solution.GetAllProjects("*.Tests").ToList();

                            DotNetTest(_ => _.EnableNoLogo()
                                             .EnableNoBuild()
                                             .SetConfiguration(Configuration)
                                             .SetResultsDirectory(PathToTestOutput)
                                             .SetDataCollector("XPlat Code Coverage")
                                             .CombineWith(testProjects,
                                                          (s, p) => s.SetProjectFile(p).SetLoggers($"trx;LogFileName={p.Name}.trx")));

                            foreach (AbsolutePath path in PathToTestResults.GlobFiles("*.trx")) {
                                TrxHelper helper = new(path);
                                //move results.trx file to test results
                                MoveFileToDirectory(helper.TrxFilepath, PathToTestResults);
                                //move coverage.xml file to coverage results folder
                                MoveFile(helper.CoverageSource, PathToCoverageResults / helper.CoverageDestination);
                            }

                            ReportGenerator(s => s.SetTargetDirectory(PathToCoverageReport)
                                                  .SetFramework("net8.0")
                                                  .SetReportTypes(ReportTypes.Html)
                                                  .SetReports(PathToCoverageResults / "*.xml"));
                        });

    public static int Main() => Execute<Build>(x => x.Test, x => x.Pack);

}