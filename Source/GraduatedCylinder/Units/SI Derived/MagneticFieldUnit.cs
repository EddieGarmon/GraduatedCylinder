using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum MagneticFieldUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Tesla,

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
    Gauss = 100,

}