using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(RelativeHumidity))]
public enum RelativeHumidityUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("")]
    [Scale(1)]
    Value = 0,

    [UnitAbbreviation("%")]
    [Scale(100)]
    Percent = 1,

    BaseUnit = Value

}