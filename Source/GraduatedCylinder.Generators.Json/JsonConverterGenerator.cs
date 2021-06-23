using System;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace GraduatedCylinder.Generators.Json
{
    [Generator]
    public class JsonConverterGenerator : ISourceGenerator
    {

        public void Execute(GeneratorExecutionContext context) {
            try {
                ExecuteInternal(context);
            } catch (Exception e) {
                DiagnosticDescriptor descriptor =
                    new(nameof(JsonConverterGenerator), "Error", e.ToString(), "Error", DiagnosticSeverity.Error, true);
                Diagnostic diagnostic = Diagnostic.Create(descriptor, Location.None);
                context.ReportDiagnostic(diagnostic);
            }
        }

        public void Initialize(GeneratorInitializationContext context) {
            //context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        private void ExecuteInternal(GeneratorExecutionContext context) {
            SourceText converterText = SourceText.From(@"
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GraduatedCylinder.Json {
    public class LengthConverter : JsonConverter<Length> {
        public int Precision { get; set; } = 2;
        public LengthUnit Units { get; set; } = LengthUnit.Meter;

        public override Length Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            string value = reader.GetString();
            return Length.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, Length value, JsonSerializerOptions options) {
            writer.WriteStringValue(value.ToString(Units, Precision));
        }
    }
}",
                                                       Encoding.UTF8);
            context.AddSource("LengthConverter.cs", converterText);

            SourceText listText = SourceText.From(@"
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GraduatedCylinder.Json {
    public static class UnitsJsonOptions {
        public static JsonSerializerOptions Defaults { get; } =
            new JsonSerializerOptions { Converters = { new LengthConverter() } };
    }
}",
                                                  Encoding.UTF8);
            context.AddSource("UnitsJsonOptions.cs", listText);
        }

    }
}