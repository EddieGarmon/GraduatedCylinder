using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeGeneration.ForDimension;

[Generator]
public class UnitParserGenerator : IIncrementalGenerator
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
                                                 output.AddSource("UnitParser", GenerateUnitsParser(tuple.Dimensions));
                                                 break;

                                             default:
                                                 return;
                                         }
                                     });
    }

    private static string GenerateUnitsParser(ImmutableArray<DimensionInfo> dimensions) {
        StringBuilder buffer = new(0x1000);

        buffer.AppendLine($@"using System;
using System.Text.RegularExpressions;

namespace {dimensions[0].Namespace}.Text;

internal static class UnitParser {{");

        foreach (DimensionInfo dimension in dimensions) {
            buffer.AppendLine($@"
    public static {dimension.DimensionType} Parse{dimension.DimensionType}(string valueWithUnits) {{
        Match match = Regexs.Pair.Match(valueWithUnits);
        if (match.Success) {{
            if ({dimension.ValueType}.TryParse(match.Groups[""value""].Value, out {dimension.ValueType} parsedValue)) {{
                {dimension.UnitsType} units = ShortNames.Get{dimension.UnitsType}(match.Groups[""units""].Value);
                return new {dimension.DimensionType}(parsedValue, units);
            }}
        }}
        throw new Exception($""Error parsing: {{valueWithUnits}}"");
    }}

    public static {dimension.DimensionType} Parse{dimension.DimensionType}(string value, {dimension.UnitsType} units) {{
		Match match = Regexs.ValueOnly.Match(value);
		if (match.Success) {{
			if ({dimension.ValueType}.TryParse(match.Groups[0].Value, out {dimension.ValueType} parsedValue)) {{
				return new {dimension.DimensionType}(parsedValue, units);
			}}
		}}
		throw new Exception($""Error parsing: {{value}}"");
    }}");
        }

        buffer.AppendLine();
        buffer.AppendLine("}");

        return buffer.ToString();
    }

}