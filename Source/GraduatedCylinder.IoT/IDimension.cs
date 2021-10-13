namespace GraduatedCylinder
{
    public interface IDimension<out TDimension, TUnits>
    {
        TUnits Units { get; }

        float Value { get; }

        TDimension In(TUnits units);

    }
}