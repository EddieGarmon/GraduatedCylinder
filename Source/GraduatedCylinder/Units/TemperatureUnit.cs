using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Temperature))]
public enum TemperatureUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Celsius,

    [UnitAbbreviation("°C")]
    [ScaleAndOffset(1.0, 0.0)]
    [Extension("Celsius")]
    Celsius = 0,

    [UnitAbbreviation("°K")]
    [ScaleAndOffset(1.0, 273.15)]
    Kelvin = 1,

    [UnitAbbreviation("°F")]
    [ScaleAndOffset(9.0 / 5.0, 32.0)]
    [Extension("Fahrenheit")]
    Fahrenheit = 2

}