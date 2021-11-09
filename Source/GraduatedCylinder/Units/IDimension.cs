namespace GraduatedCylinder
{
    public interface IDimension<out TDimension, TUnits>
    {

#if !IOT
        TUnits Units { get; set; }
#else
        TUnits Units { get; }
#endif

        double Value { get; }

        TDimension In(TUnits units);

    }
}