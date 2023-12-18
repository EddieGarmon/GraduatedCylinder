namespace CodeGeneration;

internal class DimensionInfo
{

    public DimensionInfo(string @namespace, string dimensionType) {
        Namespace = @namespace;
        DimensionType = dimensionType;
        UnitsType = $"{dimensionType}Unit";
        JsonConverterType = $"{dimensionType}JsonConverter";
        ValueType = Namespace switch {
            Names.GraduatedCylinder => "double",
            Names.Pipette => "float",
            _ => throw new Exception($"unsupported namespace: {@namespace}")
        };
    }

    public string DimensionType { get; }

    public string JsonConverterType { get; }

    public string Namespace { get; }

    public string UnitsType { get; }

    public string ValueType { get; }

}