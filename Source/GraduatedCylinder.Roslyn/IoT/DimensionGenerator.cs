using Microsoft.CodeAnalysis;

namespace GraduatedCylinder.Roslyn.IoT
{
    [Generator]
    public class DimensionGenerator : BaseGenerator
    {

        public DimensionGenerator()
            : base("GraduatedCylinder.IoT") { }

        protected override void ExecuteInternal(GeneratorExecutionContext context) {
            string format = @"
using System;
using GraduatedCylinder.Converters;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{{
    public partial struct {0} : IComparable<{0}>, IEquatable<{0}>
    {{

         public int CompareTo({0} other) {{
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {{
                float thisInBase = {0}Converter.ToBase(this);
                float otherInBase = {0}Converter.ToBase(other);
                return thisInBase.CompareTo(otherInBase);
            }}
            return _value.CompareTo(other._value);
        }}

        public bool Equals({0} other) {{
            return CompareTo(other) == 0;
        }}

        public override bool Equals(object? obj) {{
            return obj is {0} other && Equals(other);
        }}

        public override int GetHashCode() {{
            //todo: should this be dimension type and value in base?
            return HashCode.Combine((int)_units, _value);
        }}

        public {0} In({0}Unit units) {{
            if (Units == units) {{
                return this;
            }}
            float baseValue = {0}Converter.ToBase(this);
            return {0}Converter.FromBase(baseValue, units);
        }}

    }}
}}";

            string[] dimensions = { "Length", "Mass", "Time" };
            foreach (string dimension in dimensions) {
                string source = string.Format(format, dimension);
                context.AddSource($"{dimension}.g.cs", source);
            }
        }

        protected override void InitializeInternal(GeneratorInitializationContext context) { }

    }
}