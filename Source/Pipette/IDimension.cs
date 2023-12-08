namespace Pipette;

public interface IDimension
{

    //this is a marker interface, no implementation expected

}

public interface IDimension<out TDimension, TUnits> : IDimension
{

    TUnits Units { get; set; }

    float Value { get; }

    TDimension In(TUnits units);

}