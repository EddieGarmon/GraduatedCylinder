using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeGeneration.ForUnits;

[Generator]
public class UnitConverterGenerator : IIncrementalGenerator
{

    public void Initialize(IncrementalGeneratorInitializationContext context) {
        //determine what project we are running in
        IncrementalValueProvider<string?> assemblyName = context.CompilationProvider.Select((provider, _) => provider.AssemblyName);

        //match unit enums
        IncrementalValuesProvider<UnitsInfo> units = //
            context.SyntaxProvider
                   .CreateSyntaxProvider(static (node, _) => node is EnumDeclarationSyntax,
                                         static (genContext, _) => genContext.GetUnitsInfo())
                   .Where(unitsInfo => unitsInfo is not null)!;

        IncrementalValueProvider<(string? AssemblyName, ImmutableArray<UnitsInfo> Units)> valueProvider =
            assemblyName.Combine(units.Collect());

        context.RegisterSourceOutput(valueProvider,
                                     (output, tuple) => {
                                         switch (tuple.AssemblyName) {
                                             case Names.GraduatedCylinder:
                                             case Names.Pipette:
                                                 foreach (UnitsInfo unit in tuple.Units) {
                                                     output.AddSource($"{unit.Enum.Identifier}.Converter.g", GenerateConverterFor(unit));
                                                 }
                                                 break;
                                         }
                                     });
    }

    private const string PercentGradeAttribute = "PercentGradeAttribute";
    private const string ScaleAndOffsetAttribute = "ScaleAndOffsetAttribute";
    private const string ScaleAttribute = "ScaleAttribute";

    private static string GenerateConverterFor(UnitsInfo info) {
        return $@"namespace {info.Namespace}.Converters;

internal static class {info.NameSet.ConverterTypeName}
{{
    public static {info.ValueType} FromBase({info.ValueType} baseValue, {info.NameSet.UnitsTypeName} wantedUnits) {{
        switch (wantedUnits) {{
{GenerateFromBaseSwitchCases(info)}
            default:
                throw new NotSupportedException(""Unsupported conversion."");
        }}
    }}

    public static {info.ValueType} ToBase({info.NameSet.DimensionTypeName} dimension) {{
        return ToBase(dimension.Value, dimension.Units);
    }}

    public static {info.ValueType} ToBase(double value, {info.NameSet.UnitsTypeName} units) {{
        switch (units) {{
{GenerateToBaseSwitchCases(info)}
            default:
                throw new NotSupportedException(""Unsupported conversion."");
        }}
    }}
}}";
    }

    private static string GenerateFromBaseSwitchCases(UnitsInfo info) {
        StringBuilder buffer = new(0x1000);
        foreach ((EnumMemberDeclarationSyntax member, ISymbol? symbol) in info.Members) {
            ImmutableArray<AttributeData>? attributes = symbol?.GetAttributes();
            if (attributes is null || attributes.Value.IsEmpty) {
                continue;
            }

            List<AttributeData> scaleAttributes = attributes.Value
                                                            .Where(data => data.AttributeClass?.Name.ToString() is ScaleAttribute
                                                                               or ScaleAndOffsetAttribute or PercentGradeAttribute)
                                                            .ToList();

            switch (scaleAttributes.Count) {
                case 0:
                    continue;
                case 1:
                    buffer.AppendLine($"\t\t\tcase {info.Enum.Identifier}.{member.Identifier}:");
                    AttributeData attribute = scaleAttributes[0];
                    switch (attribute.AttributeClass?.Name) {
                        case ScaleAttribute:
                            //return value / scaleFactor
                            buffer.AppendLine($"\t\t\t\treturn ({info.ValueType})(baseValue / {attribute.ConstructorArguments[0].Value});");
                            break;

                        case ScaleAndOffsetAttribute:
                            //return (value * _scaleFactor) + _translatingFactor;
                            buffer.AppendLine(
                                $"\t\t\t\treturn ({info.ValueType})((baseValue * {attribute.ConstructorArguments[0].Value}) + {attribute.ConstructorArguments[1].Value});");
                            break;

                        case PercentGradeAttribute:
                            //return Math.Tan(value) * 100;
                            buffer.AppendLine($"\t\t\t\treturn ({info.ValueType})(Math.Tan(baseValue) * 100);");
                            break;
                    }
                    break;
                default:
                    //todo: Add diagnostic, don't throw
                    throw new Exception(">1 scale attribute");
            }
        }
        return buffer.ToString();
    }

    private static string GenerateToBaseSwitchCases(UnitsInfo info) {
        StringBuilder buffer = new(0x1000);
        foreach ((EnumMemberDeclarationSyntax member, ISymbol? symbol) in info.Members) {
            ImmutableArray<AttributeData>? attributes = symbol?.GetAttributes();
            if (attributes is null || attributes.Value.IsEmpty) {
                continue;
            }

            List<AttributeData> scaleAttributes = attributes.Value
                                                            .Where(data => data.AttributeClass?.Name is ScaleAttribute
                                                                               or ScaleAndOffsetAttribute or PercentGradeAttribute)
                                                            .ToList();

            switch (scaleAttributes.Count) {
                case 0:
                    continue;
                case 1:
                    buffer.AppendLine($"\t\t\tcase {info.Enum.Identifier}.{member.Identifier}:");
                    AttributeData attribute = scaleAttributes[0];
                    switch (attribute.AttributeClass?.Name) {
                        case ScaleAttribute:
                            //return value * scaleFactor
                            buffer.AppendLine($"\t\t\t\treturn ({info.ValueType})(value * {attribute.ConstructorArguments[0].Value});");
                            break;

                        case ScaleAndOffsetAttribute:
                            //return (value - _translatingFactor) / _scaleFactor;
                            buffer.AppendLine(
                                $"\t\t\t\treturn ({info.ValueType})((value - {attribute.ConstructorArguments[1].Value}) / {attribute.ConstructorArguments[0].Value});");
                            break;

                        case PercentGradeAttribute:
                            //return Math.Atan(value / 100);
                            buffer.AppendLine($"\t\t\t\treturn ({info.ValueType})Math.Atan(value / 100);");
                            break;
                    }
                    break;
                default:
                    throw new Exception(">1 scale attribute");
            }
        }
        return buffer.ToString();
    }

}