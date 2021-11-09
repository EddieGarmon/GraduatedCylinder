using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum LuminousIntensityUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Candela,

        [UnitAbbreviation("ycd")]
        [Scale(1e-24f)]
        Yoctocandela = -24,

        [UnitAbbreviation("zcd")]
        [Scale(1e-21f)]
        Zeptocandela = -21,

        [UnitAbbreviation("acd")]
        [Scale(1e-18f)]
        Attocandela = -18,

        [UnitAbbreviation("fcd")]
        [Scale(1e-15f)]
        Femtocandela = -15,

        [UnitAbbreviation("pcd")]
        [Scale(1e-12f)]
        Picocandela = -12,

        [UnitAbbreviation("ncd")]
        [Scale(1e-9f)]
        Nanocandela = -9,

        [UnitAbbreviation("µcd")]
        [Scale(1e-6f)]
        Microcandela = -6,

        [UnitAbbreviation("mcd")]
        [Scale(1e-3f)]
        Millicandela = -3,

        [UnitAbbreviation("ccd")]
        [Scale(1e-2f)]
        Centicandela = -2,

        [UnitAbbreviation("dcd")]
        [Scale(1e-1f)]
        Decicandela = -1,

        [UnitAbbreviation("cd")]
        [Scale(1.0f)]
        Candela = 0,

        [UnitAbbreviation("dacd")]
        [Scale(10f)]
        Dekacandela = 1,

        [UnitAbbreviation("hcd")]
        [Scale(1e2f)]
        Hectocandela = 2,

        [UnitAbbreviation("kcd")]
        [Scale(1e3f)]
        Kilocandela = 3,

        [UnitAbbreviation("Mcd")]
        [Scale(1e6f)]
        Megacandela = 6,

        [UnitAbbreviation("Gcd")]
        [Scale(1e9f)]
        Gigacandela = 9,

        [UnitAbbreviation("Tcd")]
        [Scale(1e12f)]
        Teracandela = 12,

        [UnitAbbreviation("Pcd")]
        [Scale(1e15f)]
        Petacandela = 15,

        [UnitAbbreviation("Ecd")]
        [Scale(1e18f)]
        Exacandela = 18,

        [UnitAbbreviation("Zcd")]
        [Scale(1e21f)]
        Zetacandela = 21,

        [UnitAbbreviation("Ycd")]
        [Scale(1e24f)]
        Yottacandela = 24

    }
}