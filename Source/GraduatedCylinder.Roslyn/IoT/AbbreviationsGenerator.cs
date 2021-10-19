using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn.IoT
{
    [Generator]
    public class AbbreviationsGenerator : BaseGenerator
    {

        public AbbreviationsGenerator()
            : base("GraduatedCylinder.IoT") { }

        protected override void ExecuteInternal(GeneratorExecutionContext context) {
            if (context.SyntaxReceiver is not UnitReceiver receiver) {
                return;
            }
            //Debugger.Launch();

            string sourceRoot = @"C:\GSP-Projects\GraduatedCylinder\Source\GraduatedCylinder.IoT.Text";
            string filename = $"{sourceRoot}\\ShortNames.g.cs";

            Buffer.AppendLine("using System;");
            Buffer.AppendLine();
            Buffer.AppendLine("namespace GraduatedCylinder.IoT.Text");
            Buffer.AppendLine("{");
            Buffer.AppendLine("\tpublic static class ShortNames");
            Buffer.AppendLine("\t{");

            StringBuilder getAbbreviation = Buffer;
            StringBuilder getUnits = new StringBuilder();

            foreach (EnumDeclarationSyntax @enum in receiver.GetUnits(context.Compilation)) {
                Log($"Generating Abbreviations for {@enum.Identifier}");
                NameSet names = NameSet.FromUnitsType(@enum.Identifier.ToString());
                SemanticModel semanticModel = context.Compilation.GetSemanticModel(@enum.SyntaxTree);

                getAbbreviation.AppendLine();
                getAbbreviation.AppendLine(
                    $"\t\tpublic static string GetAbbreviation(this {names.UnitsTypeName} unit) {{");
                getAbbreviation.AppendLine("\t\t\tswitch (unit) {");

                getUnits.AppendLine();
                getUnits.AppendLine(
                    $"\t\tpublic static {names.UnitsTypeName} Get{names.UnitsTypeName}(string abbreviation) {{");
                getUnits.AppendLine("\t\t\tswitch (abbreviation) {");

                foreach (EnumMemberDeclarationSyntax enumMember in @enum.Members) {
                    Log($"Processing: {names.UnitsTypeName}.{enumMember.Identifier}");
                    ISymbol? enumValue = semanticModel.GetDeclaredSymbol(enumMember);
                    if (enumValue is null) {
                        continue;
                    }

                    AttributeData? attribute = enumValue.GetAttributes()
                                                        .SingleOrDefault(
                                                            a =>
                                                                a.AttributeClass?.ContainingNamespace
                                                                 .ToDisplayString() ==
                                                                "GraduatedCylinder.Abbreviations");
                    if (attribute is null) {
                        continue;
                    }

                    getAbbreviation.AppendLine($"\t\t\t\tcase {names.UnitsTypeName}.{enumMember.Identifier}:");
                    getAbbreviation.AppendLine($"\t\t\t\t\treturn \"{attribute.ConstructorArguments[0].Value}\";");

                    getUnits.AppendLine($"\t\t\t\tcase \"{attribute.ConstructorArguments[0].Value}\":");
                    getUnits.AppendLine($"\t\t\t\t\treturn {names.UnitsTypeName}.{enumMember.Identifier};");
                }

                getAbbreviation.AppendLine("\t\t\t\tdefault:");
                getAbbreviation.AppendLine("\t\t\t\t\tthrow new Exception(\"Unknown unit type\");");
                getAbbreviation.AppendLine("\t\t\t} // end switch");
                getAbbreviation.AppendLine("\t\t}");

                getUnits.AppendLine("\t\t\t\tdefault:");
                getUnits.AppendLine("\t\t\t\t\tthrow new Exception(\"Unknown abbreviation\");");
                getUnits.AppendLine("\t\t\t} // end switch");
                getUnits.AppendLine("\t\t}");
            }
            Buffer.AppendLine(getUnits.ToString());
            Buffer.AppendLine(@"    }
}");

            //don't add to the IoT.dll
            GeneratedFile generatedFile = BufferToGeneratedFile(filename);
            //context.AddSource(generatedFile);
            File.WriteAllText(generatedFile.FileName, generatedFile.Content);
        }

        protected override void InitializeInternal(GeneratorInitializationContext context) {
            //Debugger.Launch();
            context.RegisterForSyntaxNotifications(() => new UnitReceiver());
        }

    }
}