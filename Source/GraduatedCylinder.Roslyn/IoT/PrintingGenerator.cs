using System;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn.IoT
{
    [Generator]
    public class PrintingGenerator : BaseGenerator
    {

        public PrintingGenerator()
            : base("GraduatedCylinder.IoT") { }

        protected override void ExecuteInternal(GeneratorExecutionContext context) {
            if (context.SyntaxReceiver is not DimensionReceiver receiver) {
                return;
            }
            //Debugger.Launch();

            string sourceRoot = @"C:\GSP-Projects\GraduatedCylinder\Source\GraduatedCylinder.IoT.Text";
            string filename = $"{sourceRoot}\\PrintExtensions.g.cs";

            Buffer.AppendLine();
            Buffer.AppendLine("namespace GraduatedCylinder.IoT.Text");
            Buffer.AppendLine("{");
            Buffer.AppendLine("\tpublic static partial class PrintExtensions");
            Buffer.AppendLine("\t{");

            foreach (StructDeclarationSyntax @struct in receiver.Structs) {
                Log($"Generating for {@struct.Identifier}");
                NameSet names = NameSet.FromDimensionType(@struct.Identifier.ToString());

                Buffer.AppendLine();
                Buffer.AppendLine(
                    $"\t\tpublic static string Print(this {names.DimensionTypeName} value, {names.UnitsTypeName} units = {names.UnitsTypeName}.Unspecified, int precision = 4) {{");
                Buffer.AppendLine(
                    $"\t\t\t{names.DimensionTypeName} inUnits = value.In(units);");
                Buffer.AppendLine(
                    "\t\t\treturn string.Format(GetPrecisionFormat(precision), inUnits.Value, inUnits.Units.GetAbbreviation());");
                Buffer.AppendLine("\t\t}");
            }

            Buffer.AppendLine("\t}");
            Buffer.AppendLine("}");

            //don't add to the IoT.dll
            GeneratedFile generatedFile = BufferToGeneratedFile(filename);
            File.WriteAllText(generatedFile.FileName, generatedFile.Content);

        }

        protected override void InitializeInternal(GeneratorInitializationContext context) {
            context.RegisterForSyntaxNotifications(() => new DimensionReceiver());
        }

    }
}