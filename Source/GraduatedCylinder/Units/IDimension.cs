namespace GraduatedCylinder
{
    public interface IDimension<out TDimension, TUnits>
    {

        TUnits Units { get; set; }

        double Value { get; }

        TDimension In(TUnits units);

    }
}