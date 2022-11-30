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
using static Nuke.Common.IO.PathConstruction;
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

    AbsolutePath ArtifactsDirectory => RootDirectory / "Artifacts";

    Target Clean =>
        _ => _.Before(Restore)
              .Executes(() => {
                            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
                            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
                            EnsureCleanDirectory(ArtifactsDirectory);
                            SourceDirectory.GlobFiles("**/*.g.cs").ForEach(DeleteFile);
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

                            foreach (string project in buildOrder) {
                                DotNetBuild(s => s.SetProjectFile(Solution.GetProject(project))
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
              .Produces(ArtifactsDirectory)
              .Executes(() => {
                            DotNetPack(s => s.SetConfiguration(Configuration)
                                             .SetOutputDirectory(ArtifactsDirectory)
                                             .EnableNoLogo()
                                             .EnableNoRestore()
                                             .EnableNoBuild()
                                             .EnableContinuousIntegrationBuild()
                                             .SetProject(Solution));
                        });

    Target Publish =>
        _ => _.DependsOn(Clean)
              .DependsOn(Test)
              .DependsOn(Pack)
              .Requires(() => NugetApiUrl)
              .Requires(() => NugetApiKey)
              .Requires(() => Configuration.Equals(Configuration.Release))
              .WhenSkipped(DependencyBehavior.Execute)
              .Executes(() => {
                            GlobFiles(ArtifactsDirectory, "*.nupkg")
                                .ForEach(packageName => DotNetNuGetPush(s => s.SetTargetPath(packageName)
                                                                              .SetSource(NugetApiUrl)
                                                                              .SetApiKey(NugetApiKey)
                                                                              .EnableSkipDuplicate()));
                        });

    Target Restore => _ => _.Executes(() => { DotNetRestore(s => s.SetProjectFile(Solution)); });

    AbsolutePath SourceDirectory => RootDirectory / "Source";

    Target Test =>
        _ => _.DependsOn(Compile)
              .Produces(TestResultsDirectory, TestCoverageResultsDirectory, TestCoverageReportDirectory)
              .Executes(() => {
                            EnsureCleanDirectory(TestResultsDirectory);
                            EnsureCleanDirectory(TestCoverageResultsDirectory);
                            EnsureCleanDirectory(TestCoverageReportDirectory);

                            List<Project> testProjects = Solution.GetProjects("*.Tests").ToList();

                            DotNetTest(_ => _.EnableNoLogo()
                                             .EnableNoBuild()
                                             .SetConfiguration(Configuration)
                                             .SetResultsDirectory(TestResultsDirectory)
                                             .SetDataCollector("XPlat Code Coverage")
                                             .CombineWith(testProjects,
                                                          (s, p) => s.SetProjectFile(p).SetLoggers($"trx;LogFileName={p.Name}.trx")));

                            foreach (AbsolutePath path in TestResultsDirectory.GlobFiles("*.trx")) {
                                TrxHelper helper = new(path);
                                //move coverage file
                                MoveFile(helper.CoverageSource, TestCoverageResultsDirectory / helper.CoverageDestination);
                            }

                            ReportGenerator(s => s.SetTargetDirectory(TestCoverageReportDirectory)
                                                  .SetFramework("net6.0")
                                                  .SetReportTypes(ReportTypes.Html) //xml?
                                                  .SetReports(TestCoverageResultsDirectory / "*.xml"));
                        });

    AbsolutePath TestCoverageReportDirectory => ArtifactsDirectory / "Coverage" / "Report";

    AbsolutePath TestCoverageResultsDirectory => ArtifactsDirectory / "Coverage" / "Results";

    AbsolutePath TestResultsDirectory => ArtifactsDirectory / "TestResults";

    AbsolutePath TestsDirectory => RootDirectory / "Tests";

    public static int Main() => Execute<Build>(x => x.Test, x => x.Pack);

}