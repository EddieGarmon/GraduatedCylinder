using GraduatedCylinder.Scales;

namespace GraduatedCylinder.Units
{
    public enum ElectricCurrentUnits : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Ampere,

        [UnitAbbreviation("yA")]
        [Scale(1e-24f)]
        Yoctoampere = -24,

        [UnitAbbreviation("zA")]
        [Scale(1e-21f)]
        Zeptoampere = -21,

        [UnitAbbreviation("aA")]
        [Scale(1e-18f)]
        Attoampere = -18,

        [UnitAbbreviation("fA")]
        [Scale(1e-15f)]
        Femtoampere = -15,

        [UnitAbbreviation("pA")]
        [Scale(1e-12f)]
        Picoampere = -12,

        [UnitAbbreviation("nA")]
        [Scale(1e-9f)]
        Nanoampere = -9,

        [UnitAbbreviation("µA")]
        [Scale(1e-6f)]
        Microampere = -6,

        [UnitAbbreviation("mA")]
        [Scale(1e-3f)]
        Milliampere = -3,

        [UnitAbbreviation("cA")]
        [Scale(1e-2f)]
        Centiampere = -2,

        [UnitAbbreviation("dA")]
        [Scale(1e-1f)]
        Deciampere = -1,

        [UnitAbbreviation("A")]
        [Scale(1.0f)]
        Ampere = 0,

        [UnitAbbreviation("daA")]
        [Scale(10f)]
        Dekaampere = 1,

        [UnitAbbreviation("hA")]
        [Scale(100f)]
        Hectoampere = 2,

        [UnitAbbreviation("kA")]
        [Scale(1e3f)]
        KiloAmpere = 3,

        [UnitAbbreviation("MA")]
        [Scale(1e6f)]
        Megaampere = 6,

        [UnitAbbreviation("GA")]
        [Scale(1e9f)]
        Gigaampere = 9,

        [UnitAbbreviation("TA")]
        [Scale(1e12f)]
        Teraampere = 12,

        [UnitAbbreviation("PA")]
        [Scale(1e15f)]
        Petaampere = 15,

        [UnitAbbreviation("EA")]
        [Scale(1e18f)]
        Exaampere = 18,

        [UnitAbbreviation("ZA")]
        [Scale(1e21f)]
        Zetaampere = 21,

        [UnitAbbreviation("YA")]
        [Scale(1e24f)]
        Yottaampere = 24,

    }
}