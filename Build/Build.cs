using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[ShutdownDotNetAfterServerBuild]
[GitHubActions("BuildAndPack",
               GitHubActionsImage.WindowsLatest,
               GitHubActionsImage.UbuntuLatest,
               CacheExcludePatterns = new [] {"~/.nuget/packages/GraduatedCylinder"},
               OnPushBranches = new [] {"master", "main"},
               OnPushTags = new [] {"*"},
               OnPullRequestBranches = new [] {"*"},
               AutoGenerate = true,
               ImportSecrets = new [] {nameof(NuGetToken)},
               InvokedTargets = new [] {nameof(Clean), nameof(Test), nameof(PushToNuGet)}
               )]
class Build : NukeBuild
{

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;

    AbsolutePath SourceDirectory => RootDirectory / "Source";
    AbsolutePath TestsDirectory => RootDirectory / "Tests";
    AbsolutePath ArtifactsDirectory => RootDirectory / "Artifacts";

    [Parameter] readonly string GitHubToken;
    [Parameter] readonly string NuGetToken;
    //[Parameter] readonly string PackagesDirectory = RootDirectory / "Packages";

    const string NugetOrgUrl = "https://api.nuget.org/v3/index.json";
    //bool IsTag => GitHubActions.Instance?.GitHubRef?.StartsWith("refs/tags/") ?? false;

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .When(IsServerBuild, x => x.SetProperty("ContinuousIntegrationBuild", "true"))
                .EnableNoRestore());
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTest(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore()
                .EnableNoBuild());
        });

    Target Pack => _ => _
        .DependsOn(Compile)
        .After(Test)
        .Produces(ArtifactsDirectory)
        .Executes(() =>
        {
            DotNetPack(s => s
                .SetConfiguration(Configuration)
                .SetOutputDirectory(ArtifactsDirectory)
                .EnableNoRestore()
                .EnableNoBuild()
                .When(IsServerBuild, x => x.SetProperty("ContinuousIntegrationBuild", "true"))
                .SetProject(Solution));
        });

    Target PushToNuGet => _ => _
        .DependsOn(Pack)
        .OnlyWhenStatic(() => /* IsTag && */ IsServerBuild && IsWin)
        .Requires(() => NuGetToken)
        .Executes(() =>
        {
            var packages = ArtifactsDirectory.GlobFiles("*.nupkg");
            DotNetNuGetPush(s => s
                .SetApiKey(NuGetToken)
                .SetSource(NugetOrgUrl)
                .EnableSkipDuplicate()
                .CombineWith(packages, (x, package) => x.SetTargetPath(package)));
        });

}
