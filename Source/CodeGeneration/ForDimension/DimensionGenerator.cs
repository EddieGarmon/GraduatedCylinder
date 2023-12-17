using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeGeneration.ForDimension;

[Generator]
public class DimensionGenerator : IIncrementalGenerator
{

    public void Initialize(IncrementalGeneratorInitializationContext context) {
        //determine what project we are running in
        IncrementalValueProvider<string?> assemblyName = context.CompilationProvider.Select((provider, _) => provider.AssemblyName);

        // register source transforms/extractions
        IncrementalValuesProvider<DimensionInfo> dimensions = //
            context.SyntaxProvider
                   .CreateSyntaxProvider(static (node, _) => node is StructDeclarationSyntax,
                                         static (genContext, _) => genContext.GetDimensionInfo())
                   .Where(static dimensionInfo => dimensionInfo is not null)!;

        IncrementalValueProvider<(string? AssemblyName, ImmutableArray<DimensionInfo> Dimensions)> valueProvider =
            assemblyName.Combine(dimensions.Collect());

        context.RegisterSourceOutput(valueProvider,
                                     (output, tuple) => {
                                         switch (tuple.AssemblyName) {
                                             case Names.GraduatedCylinder:
                                             case Names.Pipette:
                                                 foreach (DimensionInfo info in tuple.Dimensions) {
                                                     output.AddSource($"{info.DimensionType}.Core", GenerateDimensionFor(info));
                                                 }
                                                 break;

                                             default:
                                                 return;
                                         }
                                     });
    }

    private static string GenerateDimensionFor(DimensionInfo info) {
        return $@"using System.Diagnostics;
using System.Runtime.InteropServices;
using {info.Namespace}.Converters;
using {info.Namespace}.Text;

namespace {info.Namespace};

[StructLayout(LayoutKind.Sequential)]
[DebuggerDisplay(""{{ToDebugString()}}"")]
public partial struct {info.DimensionType} : IComparable<{info.DimensionType}>, IEquatable<{info.DimensionType}>
{{
    private readonly {info.ValueType} _baseValue;
    private {info.ValueType} _value;
    private {info.UnitsType} _units;

    public {info.DimensionType}(float value, {info.UnitsType} units) {{
        _value = value;
        _units = units;
        _baseValue = {info.DimensionType}Converter.ToBase(value, units);
    }}

    public {info.DimensionType}(double value, {info.UnitsType} units) {{
        _value = ({info.ValueType})value;
        _units = units;
        _baseValue = {info.DimensionType}Converter.ToBase(value, units);
    }}

    public {info.UnitsType} Units {{
        readonly get => _units;
        set {{
            if (_units == value) {{
                return;
            }}
            _value = {info.DimensionType}Converter.FromBase(_baseValue, value);
            _units = value; 
        }}
    }}

    public readonly {info.ValueType} Value => _value;

    public readonly int CompareTo({info.DimensionType} other) {{
        {info.ValueType} delta;
        switch (Equality.Units) {{
            case Equality.CompareInUnits.Base:
                delta = _baseValue - other._baseValue;
                if (delta < 0) {{
                    delta = -delta;
                }}
                if (delta <= Equality.Tolerance) {{
                    return 0;
                }}
                return _baseValue > other._baseValue ? 1 : -1;

            case Equality.CompareInUnits.LeftHandSide:
                {info.ValueType} otherValue = other.Units == Units ? other.Value : {info.DimensionType}Converter.FromBase(other._baseValue, Units);
                delta = _value - otherValue;
                if (delta < 0) {{
                    delta = -delta;
                }}
                if (delta <= Equality.Tolerance) {{
                    return 0;
                }}
                return _value > otherValue ? 1 : -1;

            default:
                throw new NotSupportedException();
        }}
    }}

    public readonly bool Equals({info.DimensionType} other) {{
        return CompareTo(other) == 0;
    }}

    public override bool Equals(object? obj) {{
        return obj is {info.DimensionType} other && Equals(other);
    }}

    public override readonly int GetHashCode() {{
        return _baseValue.GetHashCode();
    }}

    public readonly {info.DimensionType} In({info.UnitsType} units) {{
        if ((Units == units) || (units == {info.UnitsType}.Unspecified)) {{
            return this;
        }}
        return new {info.DimensionType}({info.DimensionType}Converter.FromBase(_baseValue, units), units);
    }}

    public readonly string ToDebugString() {{
        string format = Formats.GetPrecisionFormat(UnitPreferences.Default.Precision);
        string baseString = string.Format(format, _baseValue, EnergyUnit.BaseUnit.GetAbbreviation());
        string current = string.Format(format, _value, _units.GetAbbreviation());
        return $""{{current}} [{{baseString}}]"";
    }}

    public override readonly string ToString() {{
        string format = Formats.GetPrecisionFormat(UnitPreferences.Default.Precision);
        return string.Format(format, Value, Units.GetAbbreviation());
    }}

    public string ToString({info.UnitsType} units = {info.UnitsType}.Unspecified, int precision = 2) {{
        {info.DimensionType} inUnits = In(units);
        string format = Formats.GetPrecisionFormat(precision);
        return string.Format(format, inUnits.Value, inUnits.Units.GetAbbreviation());
    }}

    public string ToString(UnitPreferences preferences) {{
        return ToString(preferences.{info.UnitsType}, preferences.Precision);
    }}

    public static {info.DimensionType} Unknown {{ get; }} = new {info.DimensionType}({info.ValueType}.NaN, {info.UnitsType}.BaseUnit);

    public static {info.DimensionType} Zero {{ get; }} = new {info.DimensionType}(0, {info.UnitsType}.BaseUnit);

	public static {info.DimensionType} Parse(string valueWithUnits) {{
		return UnitParser.Parse{info.DimensionType}(valueWithUnits);
    }}

	public static {info.DimensionType} Parse(string value, {info.UnitsType} units) {{
		return UnitParser.Parse{info.DimensionType}(value, units);
    }}

    public static bool operator ==({info.DimensionType} left, {info.DimensionType} right) {{
        return left.CompareTo(right) == 0;
    }}

    public static bool operator >({info.DimensionType} left, {info.DimensionType} right) {{
        return left.CompareTo(right) > 0;
    }}

    public static bool operator >=({info.DimensionType} left, {info.DimensionType} right) {{
        return left.CompareTo(right) >= 0;
    }}

    public static bool operator !=({info.DimensionType} left, {info.DimensionType} right) {{
        return left.CompareTo(right) != 0;
    }}

    public static bool operator <({info.DimensionType} left, {info.DimensionType} right) {{
        return left.CompareTo(right) < 0;
    }}

    public static bool operator <=({info.DimensionType} left, {info.DimensionType} right) {{
        return left.CompareTo(right) <= 0;
    }}

    public static {info.DimensionType} operator +({info.DimensionType} left, {info.DimensionType} right) {{
        right = right.In(left.Units);
        return new {info.DimensionType}(left.Value + right.Value, left.Units);
    }}

    public static {info.DimensionType} operator -({info.DimensionType} left, {info.DimensionType} right) {{
        right = right.In(left.Units);
        return new {info.DimensionType}(left.Value - right.Value, left.Units);
    }}

    public static {info.DimensionType} operator -({info.DimensionType} source) {{
        return new {info.DimensionType}(-source.Value, source.Units);
    }}

    public static {info.DimensionType} operator *({info.DimensionType} left, float right) {{
        return new {info.DimensionType}(left.Value * right, left.Units);
    }}

    public static {info.DimensionType} operator *({info.DimensionType} left, double right) {{
        return new {info.DimensionType}(({info.ValueType})(left.Value * right), left.Units);
    }}

    public static {info.DimensionType} operator *(float left, {info.DimensionType} right) {{
        return new {info.DimensionType}(left * right.Value, right.Units);
    }}

    public static {info.DimensionType} operator *(double left, {info.DimensionType} right) {{
        return new {info.DimensionType}(({info.ValueType})(left * right.Value), right.Units);
    }}

    public static {info.DimensionType} operator /({info.DimensionType} left, float right) {{
        return new {info.DimensionType}(left.Value / right, left.Units);
    }}

    public static {info.DimensionType} operator /({info.DimensionType} left, double right) {{
        return new {info.DimensionType}(({info.ValueType})(left.Value / right), left.Units);
    }}

    public static {info.ValueType} operator /({info.DimensionType} left, {info.DimensionType} right) {{
        right = right.In(left.Units);
        return left.Value / right.Value;
    }}

}}";
    }

}