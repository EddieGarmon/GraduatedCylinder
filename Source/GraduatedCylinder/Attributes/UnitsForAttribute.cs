namespace CodeGeneration.Attributes;

[AttributeUsage(AttributeTargets.Enum)]
internal sealed class UnitsForAttribute : Attribute
{

    public UnitsForAttribute(Type dimensionType) {
        DimensionType = dimensionType;
    }

    public Type DimensionType { get; }

}