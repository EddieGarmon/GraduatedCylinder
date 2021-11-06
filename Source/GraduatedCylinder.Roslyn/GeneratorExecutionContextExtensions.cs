using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace GraduatedCylinder.Roslyn;

public static class GeneratorExecutionContextExtensions
{

    public static void AddSource(this GeneratorExecutionContext context, GeneratedFile file) {
        context.AddSource(file.FileName, file.Content);
    }

    public static string? GetBuildConfiguration(this GeneratorExecutionContext context) {
        AttributeData attributeData = context.Compilation.Assembly.GetAttributes()
                                             .Single(x => !string.IsNullOrEmpty(x.AttributeClass?.Name) &&
                                                          x.AttributeClass?.Name ==
                                                          nameof(AssemblyConfigurationAttribute));
        return (string?)attributeData.ConstructorArguments[0].Value;
    }

}