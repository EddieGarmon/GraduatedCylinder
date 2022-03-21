using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum TemperatureUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Celsius,

    [UnitAbbreviation("�C")]
    [ScaleAndOffset(1.0, 0.0)]
    Celsius = 0,

    [UnitAbbreviation("�K")]
    [ScaleAndOffset(1.0, 273.15)]
    Kelvin = 1,

    [UnitAbbreviation("�F")]
    [ScaleAndOffset(9.0 / 5.0, 32.0)]
    Fahrenheit = 2

}