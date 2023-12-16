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
        return $@"using System.Runtime.InteropServices;
using {info.Namespace}.Converters;
using {info.Namespace}.Text;

namespace {info.Namespace};

[StructLayout(LayoutKind.Sequential)]
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
        get => _units;
        set {{
            if (_units == value) {{
                return;
            }}
            _value = {info.DimensionType}Converter.FromBase(_baseValue, value);
            _units = value; 
        }}
    }}

    public {info.ValueType} Value => _value;

    public int CompareTo({info.DimensionType} other) {{
        {info.ValueType} otherBase = other._baseValue;
        {info.ValueType} delta = _baseValue - otherBase;
        if (delta < 0) {{
            delta = -delta;
        }}
        if (delta < Equality.Tolerance) {{
            return 0;
        }}
        return _baseValue > otherBase ? 1 : -1;
    }}

    public bool Equals({info.DimensionType} other) {{
        return CompareTo(other) == 0;
    }}

    public override bool Equals(object? obj) {{
        return obj is {info.DimensionType} other && Equals(other);
    }}

    public override int GetHashCode() {{
        return _baseValue.GetHashCode();
    }}

    public {info.DimensionType} In({info.UnitsType} units) {{
        if ((Units == units) || (units == {info.UnitsType}.Unspecified)) {{
            return this;
        }}
        return new {info.DimensionType}({info.DimensionType}Converter.FromBase(_baseValue, units), units);
    }}

    public override string ToString() {{
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