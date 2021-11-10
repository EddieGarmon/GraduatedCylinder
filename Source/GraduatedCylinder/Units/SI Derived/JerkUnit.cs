using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum JerkUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = MetersPerSecondCubed,

    [UnitAbbreviation("m/s³")]
    [Scale(1.0)]
    MetersPerSecondCubed = 0,

    [UnitAbbreviation("km/s³")]
    [Scale(1e3)]
    KiloMetersPerSecondCubed = 1,

    [UnitAbbreviation("miles/s³")]
    [Scale(1609.344)]
    MilesPerSecondCubed = 2

}