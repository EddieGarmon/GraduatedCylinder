using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GraduatedCylinder.Roslyn.IoT
{
    [Generator]
    public class DimensionGenerator : BaseGenerator
    {

        public DimensionGenerator()
            : base("GraduatedCylinder.IoT") { }

        protected override void ExecuteInternal(GeneratorExecutionContext context) {
            if (context.SyntaxReceiver is not DimensionReceiver receiver) {
                return;
            }
            //Debugger.Launch();

            foreach (StructDeclarationSyntax @struct in receiver.Structs) {
                Log($"Generating for {@struct.Identifier}");
                string source = GenerateFor(@struct);
                context.AddSource($"{@struct.Identifier}.g.cs", source);
            }
        }

        protected override void InitializeInternal(GeneratorInitializationContext context) {
            context.RegisterForSyntaxNotifications(() => new DimensionReceiver());
        }

        private static string GenerateFor(StructDeclarationSyntax @struct) {
            //todo: add IsCloseTo() implementation
            string format = @"//Generated {1}
using System;
using GraduatedCylinder.Converters;

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

        public override bool Equals(object obj) {{
            return obj is {0} other && Equals(other);
        }}

        public override int GetHashCode() {{
            //todo: should this be dimension type and value in base?
            return HashCode.Combine((int)_units, _value);
        }}

        public {0} In({0}Unit units) {{
            if ((Units == units) || (units == {0}Unit.Unspecified)) {{
                return this;
            }}
            float baseValue = {0}Converter.ToBase(this);
            return {0}Converter.FromBase(baseValue, units);
        }}

        public static bool operator ==({0} left, {0} right) {{
            return Equals(left, right);
        }}

        public static bool operator >({0} left, {0} right) {{
            return left.CompareTo(right) > 0;
        }}

        public static bool operator >=({0} left, {0} right) {{
            return left.CompareTo(right) >= 0;
        }}

        public static bool operator !=({0} left, {0} right) {{
            return !Equals(left, right);
        }}

        public static bool operator <({0} left, {0} right) {{
            return left.CompareTo(right) < 0;
        }}

        public static bool operator <=({0} left, {0} right) {{
            return left.CompareTo(right) <= 0;
        }}

    }}
}}";
            return string.Format(format, @struct.Identifier, DateTime.Now);
        }

    }
}