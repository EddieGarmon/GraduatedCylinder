using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn.IoT
{
    [Generator]
    public class JsonConverterGenerator : BaseGenerator
    {

        public JsonConverterGenerator()
            : base("GraduatedCylinder.IoT") { }

        protected override void ExecuteInternal(GeneratorExecutionContext context) {
            if (context.SyntaxReceiver is not DimensionReceiver receiver) {
                return;
            }
            //Debugger.Launch();

            string sourceRoot = @"C:\GSP-Projects\GraduatedCylinder\Source\GraduatedCylinder.IoT.Json";
            GenerateJsonHelper(sourceRoot, receiver, context.Compilation);
            foreach (StructDeclarationSyntax @struct in receiver.GetDimensions(context.Compilation)) {
                GenerateJsonConverter(sourceRoot, @struct);
            }
        }

        protected override void InitializeInternal(GeneratorInitializationContext context) {
            context.RegisterForSyntaxNotifications(() => new DimensionReceiver());
        }

        private void GenerateJsonConverter(string sourceRoot, StructDeclarationSyntax @struct) {
            string filename = $"{sourceRoot}\\{@struct.Identifier}JsonConverter.g.cs";

            Buffer.AppendLine("#nullable enable");
            Buffer.AppendLine("using System;");
            Buffer.AppendLine("using System.Text.Json;");
            Buffer.AppendLine("using System.Text.Json.Serialization;");
            Buffer.AppendLine("using GraduatedCylinder.IoT.Text;");
            Buffer.AppendLine("");
            Buffer.AppendLine("namespace GraduatedCylinder.IoT.Json");
            Buffer.AppendLine("{");
            Buffer.AppendLine(
                $"\tpublic class {@struct.Identifier}JsonConverter : JsonConverter<{@struct.Identifier}>");
            Buffer.AppendLine("\t{");
            Buffer.AppendLine("");
            Buffer.AppendLine("\t\tpublic int Precision { get; set; } = 2;");
            Buffer.AppendLine("");
            Buffer.AppendLine(
                $"\t\tpublic {@struct.Identifier}Unit Units {{ get; set; }} = {@struct.Identifier}Unit.Unspecified;");
            Buffer.AppendLine("");
            Buffer.AppendLine(
                $"\t\tpublic override {@struct.Identifier} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {{");
            Buffer.AppendLine("\t\t\tstring? value = reader.GetString();");
            Buffer.AppendLine("\t\t\tif (value is null) {");
            Buffer.AppendLine(
                "\t\t\t\tthrow new NullReferenceException(\"Null returned from Utf8JsonReader.GetString()\");");
            Buffer.AppendLine("\t\t\t}");
            Buffer.AppendLine($"\t\t\treturn Parser.Parse{@struct.Identifier}(value, Units);");
            Buffer.AppendLine("\t\t}");
            Buffer.AppendLine("");
            Buffer.AppendLine(
                $"\t\tpublic override void Write(Utf8JsonWriter writer, {@struct.Identifier} value, JsonSerializerOptions options) {{");
            Buffer.AppendLine("\t\t\twriter.WriteStringValue(value.Print(Units, Precision));");
            Buffer.AppendLine("\t\t}");
            Buffer.AppendLine();
            Buffer.AppendLine("\t}");
            Buffer.AppendLine("}");

            //don't add to the IoT.dll
            GeneratedFile generatedFile = BufferToGeneratedFile(filename);
            File.WriteAllText(generatedFile.FileName, generatedFile.Content);
        }

        private void GenerateJsonHelper(string sourceRoot, DimensionReceiver receiver, Compilation compilation) {
            string filename = $"{sourceRoot}\\JsonHelper.g.cs";

            Buffer.AppendLine("using System.Text.Json;");
            Buffer.AppendLine("");
            Buffer.AppendLine("namespace GraduatedCylinder.IoT.Json");
            Buffer.AppendLine("{");
            Buffer.AppendLine("\tpublic static class JsonHelper");
            Buffer.AppendLine("\t{");
            Buffer.AppendLine();

            List<StructDeclarationSyntax>? dimensions = receiver.GetDimensions(compilation).ToList();
            foreach (StructDeclarationSyntax @struct in dimensions) {
                Buffer.AppendLine(
                    $"\t\tpublic static {@struct.Identifier}JsonConverter {@struct.Identifier}JsonConverter {{ get; }} = new {@struct.Identifier}JsonConverter();");
            }
            Buffer.AppendLine("");

            Buffer.AppendLine("\t\tpublic static JsonSerializerOptions Options { get; } = new JsonSerializerOptions {");
            Buffer.AppendLine("\t\t\tConverters = {");
            foreach (StructDeclarationSyntax @struct in dimensions) {
                Buffer.AppendLine($"\t\t\t\t{@struct.Identifier}JsonConverter,");
            }
            Buffer.AppendLine("\t\t\t}");
            Buffer.AppendLine("\t\t};");
            Buffer.AppendLine("");

            Buffer.AppendLine("\t\tpublic static void SetPrecision(int value) {");
            foreach (StructDeclarationSyntax @struct in dimensions) {
                Buffer.AppendLine($"\t\t\t{@struct.Identifier}JsonConverter.Precision = value;");
            }
            Buffer.AppendLine("\t\t}");
            Buffer.AppendLine("");

            Buffer.AppendLine("\t}");
            Buffer.AppendLine("}");

            //don't add to the IoT.dll
            GeneratedFile generatedFile = BufferToGeneratedFile(filename);
            File.WriteAllText(generatedFile.FileName, generatedFile.Content);
        }

    }
}