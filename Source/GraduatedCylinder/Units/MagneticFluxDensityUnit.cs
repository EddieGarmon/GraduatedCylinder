using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(MagneticFluxDensity))]
public enum MagneticFluxDensityUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("pT")]
    [Scale(1e-12)]
    PicoTesla = -12,

    [UnitAbbreviation("nT")]
    [Scale(1e-9)]
    NanoTesla = -9,

    [UnitAbbreviation("µT")]
    [Scale(1e-6)]
    MicroTesla = -6,

    [UnitAbbreviation("mT")]
    [Scale(1e-3)]
    MilliTesla = -3,

    [BaseUnit]
    [UnitAbbreviation("T")]
    [Scale(1.0)]
    Tesla = 0,

    [UnitAbbreviation("kT")]
    [Scale(1e3)]
    KiloTesla = 3,

    [UnitAbbreviation("MT")]
    [Scale(1e6)]
    MegaTesla = 6,

    [UnitAbbreviation("G")]
    [Scale(10000.0)]
    Gauss = 100

}