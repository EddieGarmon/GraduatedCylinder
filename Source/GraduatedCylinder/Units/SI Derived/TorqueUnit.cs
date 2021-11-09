using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum TorqueUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = NewtonMeters,

        [UnitAbbreviation("Nm")]
        [Scale(1.0f)]
        NewtonMeters = 0,

        [UnitAbbreviation("kgf-m")]
        [Scale(9.81f)]
        KilogramForceMeters = 1,

        [UnitAbbreviation("ft-lbs")]
        [Scale(1.35581795f)]
        FootPounds = 2

    }
}