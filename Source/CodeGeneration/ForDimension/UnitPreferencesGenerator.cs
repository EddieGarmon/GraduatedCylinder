using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeGeneration.ForDimension;

[Generator]
public class UnitPreferencesGenerator : IIncrementalGenerator
{

    public void Initialize(IncrementalGeneratorInitializationContext context) {
        //determine what project we are running in
        IncrementalValueProvider<string?> assemblyName = context.CompilationProvider.Select((provider, _) => provider.AssemblyName);

        // register source transforms/extractions
        IncrementalValuesProvider<DimensionInfo> dimensions = //
            context.SyntaxProvider
                   .CreateSyntaxProvider(static (node, _) => node is StructDeclarationSyntax,
                                         static (genContext, _) => genContext.GetDimensionInfo())
                   .Where(static dimensionInfo => dimensionInfo is not null)!;

        IncrementalValueProvider<(string? AssemblyName, ImmutableArray<DimensionInfo> Dimensions)> valueProvider =
            assemblyName.Combine(dimensions.Collect());

        context.RegisterSourceOutput(valueProvider,
                                     (output, tuple) => {
                                         switch (tuple.AssemblyName) {
                                             case Names.GraduatedCylinder:
                                             case Names.Pipette:
                                                 output.AddSource("UnitPreferences", GenerateUnitPreferences(tuple.Dimensions));
                                                 break;

                                             default:
                                                 return;
                                         }
                                     });
    }

    private static string GenerateUnitPreferences(ImmutableArray<DimensionInfo> dimensions) {
        StringBuilder buffer = new(0x1000);
        buffer.AppendLine("using System;");
        buffer.AppendLine();
        buffer.AppendLine($"namespace {dimensions[0].Namespace};");
        buffer.AppendLine();
        buffer.AppendLine("public partial class UnitPreferences {");
        buffer.AppendLine();

        foreach (DimensionInfo dimension in dimensions) {
            buffer.AppendLine($"\tpublic {dimension.UnitsType} {dimension.UnitsType} {{ get; set; }}");
            buffer.AppendLine();
        }

        foreach (DimensionInfo dimension in dimensions) {
            buffer.AppendLine($"\tpublic void Fix(ref {dimension.DimensionType} value) {{");
            buffer.AppendLine($"\t\tvalue.Units = {dimension.UnitsType};");
            buffer.AppendLine("\t}");
            buffer.AppendLine();
        }

        buffer.AppendLine();
        buffer.AppendLine("}");

        return buffer.ToString();
    }

}