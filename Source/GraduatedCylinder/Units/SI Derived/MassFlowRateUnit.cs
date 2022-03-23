using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum MassFlowRateUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = KiloGramsPerSecond,

    [UnitAbbreviation("kg/s")]
    [Scale(1.0)]
    KiloGramsPerSecond = 0,

    [UnitAbbreviation("g/s")]
    [Scale(1e-3)]
    GramsPerSecond = 1,

    [UnitAbbreviation("kg/min")]
    [Scale(1.0f / 60.0)]
    KiloGramsPerMinute = 2,

    [UnitAbbreviation("kg/h")]
    [Scale(1.0f / 3600.0)]
    KiloGramsPerHour = 3,

    [UnitAbbreviation("lbs/s")]
    [Scale(0.45359237)]
    PoundsPerSecond = 4

}