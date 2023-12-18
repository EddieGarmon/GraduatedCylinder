using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeGeneration.ForUnits;

[Generator]
public class ExtensionApiGenerator : IIncrementalGenerator
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
                                             case "GraduatedCylinder":
                                             case "Pipette":
                                                 foreach (UnitsInfo unit in tuple.Units) {
                                                     string? extensionsFor = GenerateExtensionsFor(unit);
                                                     if (extensionsFor is not null) {
                                                         output.AddSource(unit.NameSet.ExtensionsTypeName, extensionsFor);
                                                     }
                                                 }
                                                 break;
                                         }
                                     });
    }

    private static string? GenerateExtensionsFor(UnitsInfo unit) {
        StringBuilder buffer = new(0x1000);
        bool hasExtension = false;

        buffer.AppendLine($@"using System.Runtime.CompilerServices;

namespace {unit.Namespace}.Extensions;

public static class {unit.NameSet.ExtensionsTypeName} {{");

        foreach ((EnumMemberDeclarationSyntax member, ISymbol symbol) in unit.Members) {
            AttributeData? attribute = symbol.GetAttributes().SingleOrDefault(a => a.AttributeClass?.Name == "ExtensionAttribute");
            if (attribute is null) {
                continue;
            }

            hasExtension = true;
            string methodName = attribute.ConstructorArguments[0].Value!.ToString();

            buffer.AppendLine($@"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static {unit.NameSet.DimensionTypeName} {methodName}(this int value) {{
        return new {unit.NameSet.DimensionTypeName}(({unit.ValueType})value, {unit.NameSet.UnitsTypeName}.{symbol?.Name});
    }}


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static {unit.NameSet.DimensionTypeName} {methodName}(this long value) {{
        return new {unit.NameSet.DimensionTypeName}(({unit.ValueType})value, {unit.NameSet.UnitsTypeName}.{symbol?.Name});
    }}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static {unit.NameSet.DimensionTypeName} {methodName}(this float value) {{
            return new {unit.NameSet.DimensionTypeName}(({unit.ValueType})value, {unit.NameSet.UnitsTypeName}.{symbol?.Name});
    }}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static {unit.NameSet.DimensionTypeName} {methodName}(this double value) {{
        return new {unit.NameSet.DimensionTypeName}(({unit.ValueType})value, {unit.NameSet.UnitsTypeName}.{symbol?.Name});
    }}
");
        }

        buffer.AppendLine("}");

        return hasExtension ? buffer.ToString() : null;
    }

}