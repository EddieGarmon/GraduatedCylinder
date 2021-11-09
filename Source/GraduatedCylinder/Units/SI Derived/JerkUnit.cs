using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum JerkUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = MetersPerSecondCubed,

        [UnitAbbreviation("m/s³")]
        [Scale(1.0f)]
        MetersPerSecondCubed = 0,

        [UnitAbbreviation("km/s³")]
        [Scale(1e3f)]
        KiloMetersPerSecondCubed = 1,

        [UnitAbbreviation("miles/s³")]
        [Scale(1609.344f)]
        MilesPerSecondCubed = 2

    }
}