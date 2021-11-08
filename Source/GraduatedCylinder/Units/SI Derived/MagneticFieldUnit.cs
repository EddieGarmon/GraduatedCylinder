using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum MagneticFieldUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Tesla,

        [UnitAbbreviation("pT")]
        [Scale(1e-12f)]
        PicoTesla = -12,

        [UnitAbbreviation("nT")]
        [Scale(1e-9f)]
        NanoTesla = -9,

        [UnitAbbreviation("µT")]
        [Scale(1e-6f)]
        MicroTesla = -6,

        [UnitAbbreviation("mT")]
        [Scale(1e-3f)]
        MilliTesla = -3,

        [UnitAbbreviation("T")]
        [Scale(1.0f)]
        Tesla = 0,

        [UnitAbbreviation("kT")]
        [Scale(1e3f)]
        KiloTesla = 3,

        [UnitAbbreviation("MT")]
        [Scale(1e6f)]
        MegaTesla = 6,

        [UnitAbbreviation("G")]
        [Scale(10000.0f)]
        Gauss = 100,

    }
}