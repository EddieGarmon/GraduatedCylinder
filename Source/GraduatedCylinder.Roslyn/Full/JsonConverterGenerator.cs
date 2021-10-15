using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace GraduatedCylinder.Roslyn.Full
{
    [Generator]
    public class JsonConverterGenerator : BaseGenerator
    {

        public JsonConverterGenerator()
            : base("GraduatedCylinder.Json") { }

        protected override void ExecuteInternal(GeneratorExecutionContext context) {
            AttributeData attributeData = context.Compilation.Assembly.GetAttributes()
                                                 .Single(x => !string.IsNullOrEmpty(x.AttributeClass?.Name) &&
                                                              x.AttributeClass?.Name ==
                                                              nameof(AssemblyConfigurationAttribute));
            string? configuration = (string?)attributeData.ConstructorArguments[0].Value;

            string path = $"C:\\GSP-Projects\\GraduatedCylinder\\Source\\GraduatedCylinder\\bin\\{configuration}\\netstandard2.0\\GraduatedCylinder.dll";
            byte[] contents = File.ReadAllBytes(path);
            Assembly assembly = Assembly.Load(contents);

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

        protected override void InitializeInternal(GeneratorInitializationContext context) { }

    }
}