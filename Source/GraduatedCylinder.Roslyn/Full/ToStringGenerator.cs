﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn.Full;

[Generator]
public class ToStringGenerator : BaseGenerator
{

    public ToStringGenerator()
        : base("GraduatedCylinder") { }

    protected override void ExecuteInternal(GeneratorExecutionContext context) {
        if (context.SyntaxReceiver is not DimensionReceiver receiver) {
            return;
        }
        //Debugger.Launch();

        foreach (StructDeclarationSyntax @struct in receiver.GetDimensions(context.Compilation)) {
            Log($"Generating for {@struct.Identifier}");
            NameSet names = NameSet.FromDimensionType(@struct.Identifier.ToString());

            WriteAutoGeneratedNotification();

            Buffer.AppendLine("using GraduatedCylinder.Text;");
            Buffer.AppendLine();
            Buffer.AppendLine("namespace GraduatedCylinder;");
            Buffer.AppendLine();
            Buffer.AppendLine($"public partial struct {names.DimensionTypeName}");
            Buffer.AppendLine("{");

            Buffer.AppendLine();
            Buffer.AppendLine("\tpublic override string ToString() {");
            Buffer.AppendLine("\t\tstring format = Formats.GetPrecisionFormat(2);");
            Buffer.AppendLine("\t\treturn string.Format(format, Value, Units.GetAbbreviation());");
            Buffer.AppendLine("\t}");

            Buffer.AppendLine();
            Buffer.AppendLine(
                $"\tpublic string ToString({names.UnitsTypeName} units = {names.UnitsTypeName}.Unspecified, int precision = 2) {{");
            Buffer.AppendLine($"\t\t{names.DimensionTypeName} inUnits = In(units);");
            Buffer.AppendLine("\t\tstring format = Formats.GetPrecisionFormat(precision);");
            Buffer.AppendLine("\t\treturn string.Format(format, inUnits.Value, inUnits.Units.GetAbbreviation());");
            Buffer.AppendLine("\t}");

            Buffer.AppendLine();
            Buffer.AppendLine("\tpublic string ToString(UnitPreferences preferences) {");
            Buffer.AppendLine($"\t\treturn ToString(preferences.{names.UnitsTypeName}, preferences.Precision);");
            Buffer.AppendLine("\t}");

            Buffer.AppendLine();
            Buffer.AppendLine("}");

            string filename = $"{names.DimensionTypeName}.ToString.g.cs";
            BufferToGeneratedFile(filename).AddToContext(context);
        }
    }

    protected override void InitializeInternal(GeneratorInitializationContext context) {
        context.RegisterForSyntaxNotifications(() => new DimensionReceiver());
    }

}