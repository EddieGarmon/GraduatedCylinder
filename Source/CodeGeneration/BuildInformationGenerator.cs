using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CodeGeneration;

[Generator]
public class BuildInformationGenerator : IIncrementalGenerator
{

    public void Initialize(IncrementalGeneratorInitializationContext context) {
        IncrementalValueProvider<CompilationOptions> compilerOptions =
            context.CompilationProvider.Select((provider, _) => provider.Options);

        IncrementalValueProvider<AnalyzerConfigOptions> configOptions =
            context.AnalyzerConfigOptionsProvider.Select((provider, _) => provider.GlobalOptions);

        IncrementalValueProvider<(CompilationOptions CompilationOptions, AnalyzerConfigOptions AnalyzerConfigOptions)> valueProvider =
            compilerOptions.Combine(configOptions);

        context.RegisterSourceOutput(valueProvider,
                                     static (productionContext, tuple) => {
                                         //extract namespace
                                         tuple.AnalyzerConfigOptions.TryGetValue("build_property.RootNamespace", out string? rootNamespace);

                                         //build model for code generator
                                         BuildInfo buildInfo = new(DateTime.UtcNow.ToString("O"),
                                                                   tuple.CompilationOptions.Platform.ToString(),
                                                                   tuple.CompilationOptions.OptimizationLevel.ToString(),
                                                                   tuple.CompilationOptions.WarningLevel,
                                                                   rootNamespace ?? string.Empty);

                                         //generate
                                         productionContext.AddSource("BuildInfo.g", GenerateFor(buildInfo));
                                     });
    }

    private static string GenerateFor(BuildInfo buildInfo) {
        return $@"using System.Globalization;

namespace {buildInfo.Namespace};

public static class BuildInformation
{{
    /// <summary>
    /// Returns the build date (UTC).
    /// </summary>
    /// <remarks>Value is: {buildInfo.BuildTime}</remarks>
    public static readonly DateTime BuildTime = DateTime.ParseExact(""{buildInfo.BuildTime}"", ""O"", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);

    /// <summary>
    /// Returns the platform.
    /// </summary>
    /// <remarks>Value is: {buildInfo.Platform}</remarks>
    public const string Platform = ""{buildInfo.Platform}"";

    /// <summary>
    /// Returns the warning level.
    /// </summary>
    /// <remarks>Value is: {buildInfo.WarningLevel}</remarks>
    public const int WarningLevel = {buildInfo.WarningLevel};

    /// <summary>
    /// Returns the configuration.
    /// </summary>
    /// <remarks>Value is: {buildInfo.Configuration}</remarks>
    public const string Configuration = ""{buildInfo.Configuration}"";
}}
";
    }

    private sealed class BuildInfo
    {

        public BuildInfo(string buildTime, string platform, string configuration, int warningLevel, string @namespace) {
            BuildTime = buildTime;
            Platform = platform;
            Configuration = configuration;
            WarningLevel = warningLevel;
            Namespace = @namespace;
        }

        public string BuildTime { get; }

        public string Configuration { get; }

        public string Namespace { get; }

        public string Platform { get; }

        public int WarningLevel { get; }

    }

}