using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(MassFlowRate))]
public enum MassFlowRateUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("g/s")]
    [Scale(1e-3)]
    GramsPerSecond = -3,

    [BaseUnit]
    [UnitAbbreviation("kg/s")]
    [Scale(1.0)]
    [Extension("KiloGramsPerSecond")]
    KiloGramsPerSecond = 0,

    [UnitAbbreviation("kg/min")]
    [Scale(1.0f / 60.0)]
    [Extension("KiloGramsPerMinute")]
    KiloGramsPerMinute = 100,

    [UnitAbbreviation("kg/h")]
    [Scale(1.0f / 3600.0)]
    [Extension("KiloGramsPerHour")]
    KiloGramsPerHour = 101,

    [UnitAbbreviation("lbs/s")]
    [Scale(0.45359237)]
    PoundsPerSecond = 200

}