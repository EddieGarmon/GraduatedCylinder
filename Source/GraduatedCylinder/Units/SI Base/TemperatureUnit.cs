using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum TemperatureUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Celsius,

        [UnitAbbreviation("�C")]
        [ScaleAndOffset(1.0f, 0.0f)]
        Celsius = 0,

        [UnitAbbreviation("�K")]
        [ScaleAndOffset(1.0f, 273.15f)]
        Kelvin = 1,

        [UnitAbbreviation("�F")]
        [ScaleAndOffset(9.0f / 5.0f, 32.0f)]
        Fahrenheit = 2

    }
}