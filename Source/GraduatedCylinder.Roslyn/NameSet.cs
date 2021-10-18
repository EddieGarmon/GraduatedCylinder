namespace GraduatedCylinder.Roslyn
{
    public class NameSet
    {

        public NameSet(string dimensionTypeName, string unitsTypeName, string converterTypeName) {
            DimensionTypeName = dimensionTypeName;
            UnitsTypeName = unitsTypeName;
            ConverterTypeName = converterTypeName;
        }

        public string ConverterTypeName { get; }

        public string DimensionTypeName { get; }

        public string UnitsTypeName { get; }

        public static NameSet FromDimensionType(string dimensionTypeName) {
            string unitsTypeName = $"{dimensionTypeName}Unit";
            string converterTypeName = $"{dimensionTypeName}Converter";
            return new NameSet(dimensionTypeName, unitsTypeName, converterTypeName);
        }

        public static NameSet FromUnitsType(string unitsTypeName) {
            string dimensionTypeName = unitsTypeName.Substring(0, unitsTypeName.Length - 4);
            string converterTypeName = $@"{dimensionTypeName}Converter";
            return new NameSet(dimensionTypeName, unitsTypeName, converterTypeName);
        }

    }
}