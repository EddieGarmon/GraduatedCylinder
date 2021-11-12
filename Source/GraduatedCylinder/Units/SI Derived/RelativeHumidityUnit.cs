using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum RelativeHumidityUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Value,

    [UnitAbbreviation("")]
    [Scale(1)]
    Value = 0,

    [UnitAbbreviation("%")]
    [Scale(100)]
    Percent = 1,

}