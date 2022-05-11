namespace GraduatedCylinder.Roslyn;

public class NameSet
{

    private NameSet(string dimensionTypeName, string unitsTypeName, string converterTypeName, string extensionsTypeName) {
        DimensionTypeName = dimensionTypeName;
        UnitsTypeName = unitsTypeName;
        ConverterTypeName = converterTypeName;
        ExtensionsTypeName = extensionsTypeName;
    }

    public string ConverterTypeName { get; }

    public string DimensionTypeName { get; }

    public string ExtensionsTypeName { get; }

    public string UnitsTypeName { get; }

    public static NameSet FromDimensionType(string dimensionTypeName) {
        string unitsTypeName = $"{dimensionTypeName}Unit";
        string converterTypeName = $"{dimensionTypeName}Converter";
        string extensionsTypeName = $"{dimensionTypeName}Extensions";
        return new NameSet(dimensionTypeName, unitsTypeName, converterTypeName, extensionsTypeName);
    }

    public static NameSet FromUnitsType(string unitsTypeName) {
        string dimensionTypeName = unitsTypeName.Substring(0, unitsTypeName.Length - 4);
        string converterTypeName = $"{dimensionTypeName}Converter";
        string extensionsTypeName = $"{dimensionTypeName}Extensions";
        return new NameSet(dimensionTypeName, unitsTypeName, converterTypeName, extensionsTypeName);
    }

}