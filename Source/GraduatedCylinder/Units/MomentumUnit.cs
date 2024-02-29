using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Momentum))]
public enum MomentumUnit : short
{

    Unspecified = short.MinValue,

    [BaseUnit]
    [UnitAbbreviation("kgm/s")]
    [Scale(1.0)]
    KiloGramMetersPerSecond = 0,

    [UnitAbbreviation("gcm/s")]
    [Scale(1e-5)]
    GramCentiMetersPerSecond = 1,

    [UnitAbbreviation("kgm/min")]
    [Scale(1.0f / 60.0)]
    KiloGramsMetersPerMinute = 2,

    [UnitAbbreviation("kgkm/h")]
    [Scale(1.0f / 3.6)]
    KiloGramsKiloMetersPerHour = 3,

    [UnitAbbreviation("lbm/h")]
    [Scale(0.2027739)]
    PoundsMilesPerHour = 4

}