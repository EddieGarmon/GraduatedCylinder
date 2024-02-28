using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Jerk))]
public enum JerkUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("m/s�")]
    [Scale(1.0)]
    MetersPerSecondCubed = 0,

    [UnitAbbreviation("km/s�")]
    [Scale(1e3)]
    KiloMetersPerSecondCubed = 1,

    [UnitAbbreviation("miles/s�")]
    [Scale(1609.344)]
    MilesPerSecondCubed = 2,

    BaseUnit = MetersPerSecondCubed

}