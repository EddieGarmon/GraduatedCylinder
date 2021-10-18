using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn.IoT
{
    [Generator]
    public class UnitConverterGenerator : BaseGenerator
    {

        public UnitConverterGenerator()
            : base("GraduatedCylinder.IoT") { }

        protected override void ExecuteInternal(GeneratorExecutionContext context) {
            if (context.SyntaxReceiver is not UnitReceiver receiver) {
                return;
            }
            //Debugger.Launch();

            foreach (EnumDeclarationSyntax @enum in receiver.Enums) {
                //todo: ensure enum has base type of short

                Log($"Generating for {@enum.Identifier}");
                SemanticModel semanticModel = context.Compilation.GetSemanticModel(@enum.SyntaxTree);
                context.AddSource(GenerateConverterFor(@enum, semanticModel));
            }
        }

        protected override void InitializeInternal(GeneratorInitializationContext context) {
            context.RegisterForSyntaxNotifications(() => new UnitReceiver());
        }

        private void Generate_FromBase(NameSet names, EnumDeclarationSyntax @enum, SemanticModel semanticModel) {
            Buffer.AppendLine($@"
{"\t\t"}public static {names.DimensionTypeName} FromBase(float baseValue, {names.UnitsTypeName} wantedUnits) {{
{"\t\t\t"}float newValue = 0;
{"\t\t\t"}switch (wantedUnits) {{");

            foreach (EnumMemberDeclarationSyntax enumMember in @enum.Members) {
                ISymbol? enumValue = semanticModel.GetDeclaredSymbol(enumMember);
                if (enumValue is null) {
                    continue;
                }

                AttributeData? attribute = enumValue.GetAttributes()
                                                    .SingleOrDefault(
                                                        a => a.AttributeClass?.ContainingNamespace.ToDisplayString() ==
                                                             "GraduatedCylinder.Scales");
                if (attribute is null) {
                    continue;
                }

                Buffer.AppendLine($"\t\t\t\tcase {names.UnitsTypeName}.{enumMember.Identifier}:");
                switch (attribute.AttributeClass?.Name) {
                    case "ScaleAttribute":
                        //return value / scaleFactor
                        Buffer.AppendLine(
                            $"\t\t\t\t\tnewValue = baseValue / {attribute.ConstructorArguments[0].Value}f;");
                        break;

                    case "ScaleAndOffsetAttribute":
                        //return (value * _scaleFactor) + _translatingFactor;
                        Buffer.AppendLine(
                            $"\t\t\t\t\tnewValue = (baseValue * {attribute.ConstructorArguments[0].Value}f) + {attribute.ConstructorArguments[1].Value}f;");
                        break;

                    case "ScaleInverselyAttribute":
                        //return _inverseScaleFactor / (value / _scaleFactor);
                        Buffer.AppendLine(
                            $"\t\t\t\t\tnewValue = {attribute.ConstructorArguments[0].Value}f / (baseValue / {attribute.ConstructorArguments[1].Value}f);");
                        break;

                    case "PercentGradeAttribute":
                        //return Math.Tan(value) * 100;
                        Buffer.AppendLine("\t\t\t\t\tnewValue = (float)Math.Tan(baseValue) * 100;");
                        break;
                }
                Buffer.AppendLine("\t\t\t\t\tbreak;");
            }

            Buffer.AppendLine("\t\t\t\tdefault:");
            Buffer.AppendLine("\t\t\t\t\tthrow new NotSupportedException(\"Unsupported conversion.\");");
            Buffer.AppendLine("\t\t\t} //end switch");
            Buffer.AppendLine($"\t\t\treturn new {names.DimensionTypeName}(newValue, wantedUnits);");
            Buffer.AppendLine("\t\t} //end method");
        }

        private void Generate_ToBase(NameSet names, EnumDeclarationSyntax @enum, SemanticModel semanticModel) {
            Buffer.AppendLine($@"
{"\t\t"}public static float ToBase({names.DimensionTypeName} dimension) {{
{"\t\t\t"}switch (dimension.Units) {{");

            foreach (EnumMemberDeclarationSyntax enumMember in @enum.Members) {
                ISymbol? enumValue = semanticModel.GetDeclaredSymbol(enumMember);
                if (enumValue is null) {
                    continue;
                }

                AttributeData? attribute = enumValue.GetAttributes()
                                                    .SingleOrDefault(
                                                        a => a.AttributeClass?.ContainingNamespace.ToDisplayString() ==
                                                             "GraduatedCylinder.Scales");
                if (attribute is null) {
                    continue;
                }

                Buffer.AppendLine($"\t\t\t\tcase {names.UnitsTypeName}.{enumMember.Identifier}:");
                switch (attribute.AttributeClass?.Name) {
                    case "ScaleAttribute":
                        //return value * scaleFactor
                        Buffer.AppendLine(
                            $"\t\t\t\t\treturn dimension.Value * {attribute.ConstructorArguments[0].Value}f;");
                        break;

                    case "ScaleAndOffsetAttribute":
                        //return (value - _translatingFactor) / _scaleFactor;
                        Buffer.AppendLine(
                            $"\t\t\t\t\treturn (dimension.Value - {attribute.ConstructorArguments[1].Value}f) / {attribute.ConstructorArguments[0].Value}f;");
                        break;

                    case "ScaleInverselyAttribute":
                        //return (_inverseScaleFactor / value) * _scaleFactor;
                        Buffer.AppendLine(
                            $"\t\t\t\t\treturn ({attribute.ConstructorArguments[0].Value}f / dimension.Value) * {attribute.ConstructorArguments[1].Value}f);");
                        break;

                    case "PercentGradeAttribute":
                        //return Math.Atan(value / 100);
                        Buffer.AppendLine("\t\t\t\t\treturn (float)Math.Atan(dimension.Value / 100);");
                        break;
                }
            }

            Buffer.AppendLine("\t\t\t\tdefault:");
            Buffer.AppendLine("\t\t\t\t\tthrow new NotSupportedException(\"Unsupported conversion.\");");
            Buffer.AppendLine("\t\t\t} //end switch");
            Buffer.AppendLine("\t\t} //end method");
        }

        private GeneratedFile GenerateConverterFor(EnumDeclarationSyntax @enum, SemanticModel semanticModel) {
            NameSet names = NameSet.FromUnitsType(@enum.Identifier.Text);
            string filename = $"{names.ConverterTypeName}.g.cs";

            Buffer.AppendLine(@$"//Generated {DateTime.Now}
using System;

namespace GraduatedCylinder.Converters
{{
    internal static class {names.ConverterTypeName}
    {{");

            Generate_FromBase(names, @enum, semanticModel);
            Generate_ToBase(names, @enum, semanticModel);

            Buffer.AppendLine(@"    }
}");

            Buffer.AppendLine($"// Buffer.Capacity: {Buffer.Capacity}");
            Buffer.AppendLine($"// Buffer.Length: {Buffer.Length}");
            Log($"//File: {filename}; Buffer.Length: {Buffer.Length}; Buffer.Capacity: {Buffer.Capacity}");

            return BufferToGeneratedFile(filename);
        }

    }
}