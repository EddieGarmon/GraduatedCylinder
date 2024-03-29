﻿using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeGeneration.ForUnits;

[Generator]
public class AbbreviationGenerator : IIncrementalGenerator
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
                                                 output.AddSource("Abbreviations", GenerateAbbreviations(tuple.Units));
                                                 break;

                                             default:
                                                 return;
                                         }
                                     });
    }

    private static string GenerateAbbreviations(ImmutableArray<UnitsInfo> units) {
        StringBuilder buffer = new(0x1000);

        buffer.AppendLine($@"namespace {units[0].Namespace};

public static class Abbreviations {{");

        StringBuilder getUnits = new();
        StringBuilder getBase = new();

        foreach (UnitsInfo unit in units.OrderBy(info => info.Enum.Identifier.ToString())) {
            buffer.AppendLine();
            buffer.AppendLine($"\tpublic static string GetAbbreviation(this {unit.NameSet.UnitsTypeName} unit) {{");
            buffer.AppendLine("\t\treturn unit switch {");

            getUnits.AppendLine();
            getUnits.AppendLine($"\tpublic static {unit.NameSet.UnitsTypeName} Get{unit.NameSet.UnitsTypeName}(string abbreviation) {{");
            getUnits.AppendLine("\t\treturn abbreviation switch {");

            foreach ((EnumMemberDeclarationSyntax member, ISymbol? symbol) in unit.Members) {
                ImmutableArray<AttributeData> attributes = symbol.GetAttributes();
                AttributeData? abbreviation = attributes.SingleOrDefault(a => a.AttributeClass?.Name == "UnitAbbreviationAttribute");
                if (abbreviation is null) {
                    continue;
                }

                buffer.AppendLine(
                    $"\t\t\t{unit.NameSet.UnitsTypeName}.{member.Identifier} =>  \"{abbreviation.ConstructorArguments[0].Value}\",");

                bool isBase = attributes.SingleOrDefault(a => a.AttributeClass?.Name == "BaseUnitAttribute") is not null;
                if (isBase) {
                    getBase.AppendLine();
                    getBase.AppendLine($"\tpublic static string GetBaseAbbreviation(this {unit.NameSet.UnitsTypeName} unit) {{");
                    getBase.AppendLine($"\t\treturn \"{abbreviation.ConstructorArguments[0].Value}\";");
                    getBase.AppendLine("\t}");
                }

                getUnits.AppendLine(
                    $"\t\t\t\"{abbreviation.ConstructorArguments[0].Value}\" => {unit.NameSet.UnitsTypeName}.{member.Identifier},");
            }

            buffer.AppendLine(@"           _ => throw new Exception(""Unknown unit type"")
        };
    }");

            getUnits.AppendLine(@"              _ => throw new Exception(""Unknown abbreviation"")
        };
    }");
        }

        buffer.AppendLine(getBase.ToString());
        buffer.AppendLine(getUnits.ToString());
        buffer.AppendLine();
        buffer.AppendLine(@"}");

        return buffer.ToString();
    }

}