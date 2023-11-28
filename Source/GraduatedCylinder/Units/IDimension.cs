namespace GraduatedCylinder;

public interface IDimension
{

    //this is a marker interface, no implementation expected

}

public interface IDimension<out TDimension, TUnits> : IDimension
{

#if !IOT
    TUnits Units { get; set; }
#else
    TUnits Units { get; }
#endif

    double Value { get; }

    TDimension In(TUnits units);

}