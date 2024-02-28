using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(AbsoluteHumidity))]
public enum AbsoluteHumidityUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("g/m³")]
    [Scale(1)]
    GramsPerCubicMeter = 0,

    [UnitAbbreviation("kg/m³")]
    [Scale(0.001)]
    KiloGramsPerCubicMeter,

    BaseUnit = GramsPerCubicMeter

}