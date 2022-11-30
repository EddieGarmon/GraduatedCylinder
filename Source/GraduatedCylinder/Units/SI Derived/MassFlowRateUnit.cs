using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum MassFlowRateUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = KiloGramsPerSecond,

    [UnitAbbreviation("g/s")]
    [Scale(1e-3)]
    GramsPerSecond = -3,

    [UnitAbbreviation("kg/s")]
    [Scale(1.0)]
    KiloGramsPerSecond = 0,

    [UnitAbbreviation("kg/min")]
    [Scale(1.0f / 60.0)]
    KiloGramsPerMinute = 100,

    [UnitAbbreviation("kg/h")]
    [Scale(1.0f / 3600.0)]
    KiloGramsPerHour = 101,

    [UnitAbbreviation("lbs/s")]
    [Scale(0.45359237)]
    PoundsPerSecond = 200

}