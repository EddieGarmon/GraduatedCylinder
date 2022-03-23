using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum TorqueUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = NewtonMeters,

    [UnitAbbreviation("Nm")]
    [Scale(1.0)]
    NewtonMeters = 0,

    [UnitAbbreviation("kgf-m")]
    [Scale(9.81)]
    KiloGramForceMeters = 1,

    [UnitAbbreviation("ft-lbs")]
    [Scale(1.35581795)]
    FootPounds = 2

}