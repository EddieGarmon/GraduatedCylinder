using System.Text;
using Microsoft.CodeAnalysis;

namespace CodeGeneration.ForDimension;

[Generator]
public class JsonConverterGenerator : IIncrementalGenerator
{

    public void Initialize(IncrementalGeneratorInitializationContext context) {
        //determine what project we are running in
        IncrementalValueProvider<string?> assemblyName = context.CompilationProvider.Select((provider, _) => provider.AssemblyName);

        //get UoM assembly
        IncrementalValueProvider<List<DimensionInfo>> dimensions = //
            context.CompilationProvider.Select((compilation, _) => {
                                                   List<IAssemblySymbol> assemblies = compilation.SourceModule.ReferencedAssemblySymbols
                                                       .Where(assembly => assembly.Name is Names.GraduatedCylinder or Names.Pipette)
                                                       .ToList();

                                                   switch (assemblies.Count) {
                                                       case 0:
                                                           return [];
                                                       case 1:
                                                           //get the namespace
                                                           IAssemblySymbol assembly = assemblies[0];
                                                           INamespaceSymbol @namespace = assembly.Identity.Name.Split('.')
                                                               .Aggregate(assembly.GlobalNamespace,
                                                                          (s, c) => s.GetNamespaceMembers().Single(m => m.Name.Equals(c)));

                                                           return @namespace.GetTypeMembers()
                                                                            .Where(typeSymbol => typeSymbol.IsDimension())
                                                                            .Select(typeSymbol => typeSymbol.GetDimensionInfo()!)
                                                                            .OrderBy(dimension => dimension.DimensionType)
                                                                            .ToList();
                                                       default:
                                                           throw new Exception("How did we get here?");
                                                   }
                                               });

        IncrementalValueProvider<(string? AssemblyName, List<DimensionInfo> Dimensions)> valueProvider = assemblyName.Combine(dimensions);

        context.RegisterSourceOutput(valueProvider,
                                     (productionContext, tuple) => {
                                         switch (tuple.AssemblyName) {
                                             case "GraduatedCylinder.Json":
                                             case "Pipette.Json":
                                                 //converters
                                                 foreach (DimensionInfo? info in tuple.Dimensions) {
                                                     productionContext.AddSource($"{info.DimensionType}.JsonConverter",
                                                                                 GenerateJsonConverter(info));
                                                 }
                                                 productionContext.AddSource("JsonHelper", GenerateJsonHelper(tuple.Dimensions));
                                                 break;
                                         }
                                     });
    }

    private static string GenerateJsonConverter(DimensionInfo dimension) {
        return $@"using System.Text.Json;
using System.Text.Json.Serialization;
using {dimension.Namespace}.Text;

namespace {dimension.Namespace}.Json;

public class {dimension.JsonConverterType} : JsonConverter<{dimension.DimensionType}> {{

    public int Precision {{ get; set; }} = 2;

    public {dimension.UnitsType} Units {{ get; set; }} = {dimension.UnitsType}.Unspecified;

    public override {dimension.DimensionType} Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {{
        string value = reader.GetString() ?? throw new NullReferenceException(""Null returned from Utf8JsonReader.GetString()"");
        return UnitParser.Parse{dimension.DimensionType}(value);
    }}

    public override void Write(Utf8JsonWriter writer, {dimension.DimensionType} value, JsonSerializerOptions options) {{
        writer.WriteStringValue(value.ToString(Units, Precision));
    }}
}}";
    }

    private static string GenerateJsonHelper(List<DimensionInfo> dimensions) {
        StringBuilder buffer = new(0x1000);

        buffer.AppendLine($@"using System.Text.Json;

namespace {dimensions[0].Namespace}.Json;

public static class JsonHelper {{
");

        foreach (DimensionInfo dimension in dimensions) {
            buffer.AppendLine(
                $"\tpublic static {dimension.JsonConverterType} {dimension.JsonConverterType} {{ get; }} = new {dimension.JsonConverterType}();");
        }

        buffer.AppendLine(@"
    public static JsonSerializerOptions Options { get; } = new JsonSerializerOptions {
        Converters = {");
        foreach (DimensionInfo dimension in dimensions) {
            buffer.AppendLine($"\t\t\t{dimension.JsonConverterType},");
        }
        buffer.AppendLine(@"        }
    };
");

        buffer.AppendLine("\tpublic static void SetPrecision(int value) {");
        foreach (DimensionInfo dimension in dimensions) {
            buffer.AppendLine($"\t\t{dimension.JsonConverterType}.Precision = value;");
        }
        buffer.AppendLine(@"    }
}");

        return buffer.ToString();
    }

}