using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(VolumetricFlowRate))]
public enum VolumetricFlowRateUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = LitersPerSecond,

    [UnitAbbreviation("L/s")]
    [Scale(1.0)]
    LitersPerSecond = 0,

    [UnitAbbreviation("L/min")]
    [Scale(1.0f / 60.0)]
    LitersPerMinute = 1,

    [UnitAbbreviation("L/h")]
    [Scale(1.0f / 3600.0)]
    LitersPerHour = 2,

    [UnitAbbreviation("m³/s")]
    [Scale(1000)]
    CubicMetersPerSecond = 3,

    [UnitAbbreviation("gal/s")]
    [Scale(3.785411784)]
    GallonsUsPerSecond = 4,

    [UnitAbbreviation("gal/h")]
    [Scale(3.785411784 / 3600.0)]
    GallonsUsPerHour = 5

}