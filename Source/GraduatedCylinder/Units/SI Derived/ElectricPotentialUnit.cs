using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum ElectricPotentialUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Volt,

        [UnitAbbreviation("yV")]
        [Scale(1e-24f)]
        Yoctovolt = -24,

        [UnitAbbreviation("zV")]
        [Scale(1e-21f)]
        Zeptovolt = -21,

        [UnitAbbreviation("aV")]
        [Scale(1e-18f)]
        Attovolt = -18,

        [UnitAbbreviation("fV")]
        [Scale(1e-15f)]
        Femtovolt = -15,

        [UnitAbbreviation("pV")]
        [Scale(1e-12f)]
        Picovolt = -12,

        [UnitAbbreviation("nV")]
        [Scale(1e-9f)]
        Nanovolt = -9,

        [UnitAbbreviation("µV")]
        [Scale(1e-6f)]
        Microvolt = -6,

        [UnitAbbreviation("mV")]
        [Scale(1e-3f)]
        Millivolt = -3,

        [UnitAbbreviation("cV")]
        [Scale(1e-2f)]
        Centivolt = -2,

        [UnitAbbreviation("dV")]
        [Scale(1e-1f)]
        Decivolt = -1,

        [UnitAbbreviation("V")]
        [Scale(1.0f)]
        Volt = 0,

        [UnitAbbreviation("daV")]
        [Scale(10f)]
        Dekavolt = 1,

        [UnitAbbreviation("hV")]
        [Scale(1e2f)]
        Hectovolt = 2,

        [UnitAbbreviation("kV")]
        [Scale(1e3f)]
        Kilovolt = 3,

        [UnitAbbreviation("MV")]
        [Scale(1e6f)]
        Megavolt = 6,

        [UnitAbbreviation("GV")]
        [Scale(1e9f)]
        Gigavolt = 9,

        [UnitAbbreviation("TV")]
        [Scale(1e12f)]
        Teravolt = 12,

        [UnitAbbreviation("PV")]
        [Scale(1e15f)]
        Petavolt = 15,

        [UnitAbbreviation("EV")]
        [Scale(1e18f)]
        Exavolt = 18,

        [UnitAbbreviation("ZV")]
        [Scale(1e21f)]
        Zettavolt = 21,

        [UnitAbbreviation("YV")]
        [Scale(1e24f)]
        Yottavolt = 24

    }
}