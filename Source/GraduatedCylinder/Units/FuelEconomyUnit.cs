using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(FuelEconomy))]
public enum FuelEconomyUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("km/L")]
    [Scale(1.0)]
    [Extension("KiloMetersPerLiter")]
    KiloMetersPerLiter = 0,

    [UnitAbbreviation("L/100km")]
    //100/(X L/100km) = Y km/L
    //[Scale(100)]
    //InverseScale
    LitersPer100KiloMeters = 1,

    [UnitAbbreviation("mpg(US)")]
    [Scale(0.425144)]
    [Extension("MilesPerGallonUS")]
    MilesPerGallonUS = 2,

    [UnitAbbreviation("mpg(UK)")]
    [Scale(0.354006)]
    MilesPerGallonUK = 3,

    BaseUnit = KiloMetersPerLiter

}