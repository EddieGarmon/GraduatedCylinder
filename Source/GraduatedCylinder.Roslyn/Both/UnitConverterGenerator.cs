using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn.Both;

[Generator]
public class UnitConverterGenerator : BaseGenerator
{

    public UnitConverterGenerator()
        : base("GraduatedCylinder", "GraduatedCylinder.IoT") { }

    protected override void ExecuteInternal(GeneratorExecutionContext context) {
        if (context.SyntaxReceiver is not UnitReceiver receiver) {
            return;
        }
        //Debugger.Launch();

        foreach (EnumDeclarationSyntax @enum in receiver.GetUnits(context.Compilation)) {
            Log($"Generating for {@enum.Identifier}");
            SemanticModel semanticModel = context.Compilation.GetSemanticModel(@enum.SyntaxTree);
            GenerateConverterFor(@enum, semanticModel).AddToContext(context);
        }
    }

    protected override void InitializeInternal(GeneratorInitializationContext context) {
        context.RegisterForSyntaxNotifications(() => new UnitReceiver());
    }

    private void Generate_FromBase(NameSet names, EnumDeclarationSyntax @enum, SemanticModel semanticModel) {
        Buffer.AppendLine();
        Buffer.AppendLine($"\tpublic static {names.DimensionTypeName} FromBase(double baseValue, {names.UnitsTypeName} wantedUnits) {{");
        Buffer.AppendLine("\t\tdouble newValue = 0;");
        Buffer.AppendLine("\t\tswitch (wantedUnits) {");

        foreach (EnumMemberDeclarationSyntax enumMember in @enum.Members) {
            ISymbol? enumValue = semanticModel.GetDeclaredSymbol(enumMember);
            AttributeData? attribute = enumValue?.GetAttributes()
                                                .SingleOrDefault(a => a.AttributeClass?.ContainingNamespace.ToDisplayString() ==
                                                                      "GraduatedCylinder.Scales");
            if (attribute is null) {
                continue;
            }

            Buffer.AppendLine($"\t\t\tcase {names.UnitsTypeName}.{enumMember.Identifier}:");
            switch (attribute.AttributeClass?.Name) {
                case "ScaleAttribute":
                    //return value / scaleFactor
                    Buffer.AppendLine($"\t\t\t\tnewValue = baseValue / {attribute.ConstructorArguments[0].Value};");
                    break;

                case "ScaleAndOffsetAttribute":
                    //return (value * _scaleFactor) + _translatingFactor;
                    Buffer.AppendLine(
                        $"\t\t\t\tnewValue = (baseValue * {attribute.ConstructorArguments[0].Value}) + {attribute.ConstructorArguments[1].Value};");
                    break;

                case "PercentGradeAttribute":
                    //return Math.Tan(value) * 100;
                    Buffer.AppendLine("\t\t\t\tnewValue = Math.Tan(baseValue) * 100;");
                    break;
            }
            Buffer.AppendLine("\t\t\t\tbreak;");
        }

        Buffer.AppendLine("\t\t\tdefault:");
        Buffer.AppendLine("\t\t\t\tthrow new NotSupportedException(\"Unsupported conversion.\");");
        Buffer.AppendLine("\t\t}");
        Buffer.AppendLine($"\t\treturn new {names.DimensionTypeName}(newValue, wantedUnits);");
        Buffer.AppendLine("\t}");
    }

    private void Generate_ToBase(NameSet names, EnumDeclarationSyntax @enum, SemanticModel semanticModel) {
        Buffer.AppendLine();
        Buffer.AppendLine($"\tpublic static double ToBase({names.DimensionTypeName} dimension) {{");
        Buffer.AppendLine("\t\treturn ToBase(dimension.Value, dimension.Units);");
        Buffer.AppendLine("\t}");
        Buffer.AppendLine();
        Buffer.AppendLine($"\tpublic static double ToBase(double value, {names.UnitsTypeName} units) {{");
        Buffer.AppendLine("\t\tswitch (units) {");

        foreach (EnumMemberDeclarationSyntax enumMember in @enum.Members) {
            ISymbol? enumValue = semanticModel.GetDeclaredSymbol(enumMember);
            AttributeData? attribute = enumValue?.GetAttributes()
                                                .SingleOrDefault(a => a.AttributeClass?.ContainingNamespace.ToDisplayString() ==
                                                                      "GraduatedCylinder.Scales");
            if (attribute is null) {
                continue;
            }

            Buffer.AppendLine($"\t\t\tcase {names.UnitsTypeName}.{enumMember.Identifier}:");
            switch (attribute.AttributeClass?.Name) {
                case "ScaleAttribute":
                    //return value * scaleFactor
                    Buffer.AppendLine($"\t\t\t\treturn value * {attribute.ConstructorArguments[0].Value};");
                    break;

                case "ScaleAndOffsetAttribute":
                    //return (value - _translatingFactor) / _scaleFactor;
                    Buffer.AppendLine(
                        $"\t\t\t\treturn (value - {attribute.ConstructorArguments[1].Value}) / {attribute.ConstructorArguments[0].Value};");
                    break;

                case "PercentGradeAttribute":
                    //return Math.Atan(value / 100);
                    Buffer.AppendLine("\t\t\t\treturn Math.Atan(value / 100);");
                    break;
            }
        }

        Buffer.AppendLine("\t\t\tdefault:");
        Buffer.AppendLine("\t\t\t\tthrow new NotSupportedException(\"Unsupported conversion.\");");
        Buffer.AppendLine("\t\t}");
        Buffer.AppendLine("\t}");
    }

    private GeneratedFile GenerateConverterFor(EnumDeclarationSyntax @enum, SemanticModel semanticModel) {
        NameSet names = NameSet.FromUnitsType(@enum.Identifier.Text);
        string filename = $"{names.ConverterTypeName}.g.cs";

        WriteAutoGeneratedNotification();

        Buffer.AppendLine("using System;");
        Buffer.AppendLine();
        Buffer.AppendLine("namespace GraduatedCylinder.Converters;");
        Buffer.AppendLine();
        Buffer.AppendLine($"internal static class {names.ConverterTypeName}");
        Buffer.AppendLine("{");

        Generate_FromBase(names, @enum, semanticModel);
        Generate_ToBase(names, @enum, semanticModel);

        Buffer.AppendLine("}");
        Buffer.AppendLine();
        Buffer.AppendLine($"// Buffer.Capacity: {Buffer.Capacity}");
        Buffer.AppendLine($"// Buffer.Length: {Buffer.Length}");

        return BufferToGeneratedFile(filename);
    }

}