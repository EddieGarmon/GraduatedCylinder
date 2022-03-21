using System;
using System.Linq;
using System.Text.RegularExpressions;
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
// NB: To trigger manual generation invoke:
//     nuke --generate-configuration GitHubActions_BuildAndPack --host GitHubActions
[GitHubActions("BuildAndPack",
               GitHubActionsImage.WindowsLatest,
               //todo: GitHubActionsImage.UbuntuLatest,
               CacheExcludePatterns = new [] {"~/.nuget/packages/GraduatedCylinder"},
               OnPushBranches = new [] {"master"},
               OnPullRequestBranches = new [] {"*"},
               AutoGenerate = false,
               ImportSecrets = new [] {nameof(NugetApiKey)},
               InvokedTargets = new [] {nameof(Clean), nameof(Test), nameof(Pack)}
               )]
// NB: To trigger manual generation invoke:
//     nuke --generate-configuration GitHubActions_Publish --host GitHubActions
[GitHubActions("Publish",
               GitHubActionsImage.WindowsLatest,
               CacheExcludePatterns = new [] {"~/.nuget/packages/GraduatedCylinder"},
               OnPushTags = new [] {"v*"},
               AutoGenerate = false,
               ImportSecrets = new [] {nameof(NugetApiKey)},
               InvokedTargets = new [] {nameof(Clean), nameof(Test), nameof(PushToNuGet)}
)]
class Build : NukeBuild
{

    public static int Main () => Execute<Build>(x => x.Pack);

    [GitRepository] readonly GitRepository GitRepository;

    [Parameter("Configuration to build - Default is 'Release'")]
    readonly Configuration Configuration = Configuration.Release;

    //[Parameter] readonly string GitHubToken;

    [Parameter] readonly string NugetApiUrl = "https://api.nuget.org/v3/index.json";
    [Parameter] [Secret] readonly string NugetApiKey;

    [Solution] readonly Solution Solution;
    
    AbsolutePath SourceDirectory => RootDirectory / "Source";
    AbsolutePath TestsDirectory => RootDirectory / "Tests";
    AbsolutePath ArtifactsDirectory => RootDirectory / "Artifacts";

    bool IsOriginalRepository => GitRepository.Identifier == "EddieGarmon/GraduatedCylinder";

    bool IsTag => GitRepository.Tags.Any(tag => TagRegex.IsMatch(tag));
    Regex TagRegex = new Regex(@"v\d+\.\d+.\d+");

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
                .EnableNoLogo()
                .EnableDisableParallel()
                .EnableDeterministic()
                .When(IsServerBuild, x => x.EnableContinuousIntegrationBuild())
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
                .EnableNoLogo()
                .EnableNoRestore()
                .EnableNoBuild()
                .When(IsServerBuild , x => x.EnableContinuousIntegrationBuild())
                .SetProject(Solution));
        });

    Target PushToNuGet => _ => _
        .DependsOn(Pack)
        .Requires(() => NugetApiUrl)
        .Requires(() => NugetApiKey)
        .Requires(() => Configuration.Equals(Configuration.Release))
        .Requires(() => IsTag)
        .Requires(() => IsWin)
        .WhenSkipped(DependencyBehavior.Execute)
        .Executes(() =>
        {
            GlobFiles(ArtifactsDirectory, "*.nupkg")
                .Where(name => !name.EndsWith("symbols.nupkg"))
                .ForEach(packageName => DotNetNuGetPush(s => s.SetTargetPath(packageName)
                                                              .SetSource(NugetApiUrl)
                                                              .SetApiKey(NugetApiKey)
                                                              .EnableSkipDuplicate()));
        });

}
