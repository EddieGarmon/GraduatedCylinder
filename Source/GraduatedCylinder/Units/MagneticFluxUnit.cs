using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(MagneticFlux))]
public enum MagneticFluxUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("pWb")]
    [Scale(1e-12)]
    PicoWeber = -12,

    [UnitAbbreviation("nWb")]
    [Scale(1e-9)]
    NanoWeber = -9,

    [UnitAbbreviation("µWb")]
    [Scale(1e-6)]
    MicroWeber = -6,

    [UnitAbbreviation("mWb")]
    [Scale(1e-3)]
    MilliWeber = -3,

    [BaseUnit]
    [UnitAbbreviation("Wb")]
    [Scale(1.0)]
    Weber = 0,

    [UnitAbbreviation("kWb")]
    [Scale(1e3)]
    KiloWeber = 3,

    [UnitAbbreviation("MWb")]
    [Scale(1e6)]
    MegaWeber = 6

}