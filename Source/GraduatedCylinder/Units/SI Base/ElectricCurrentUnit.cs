using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum ElectricCurrentUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Ampere,

    [UnitAbbreviation("yA")]
    [Scale(1e-24)]
    Yoctoampere = -24,

    [UnitAbbreviation("zA")]
    [Scale(1e-21)]
    Zeptoampere = -21,

    [UnitAbbreviation("aA")]
    [Scale(1e-18)]
    Attoampere = -18,

    [UnitAbbreviation("fA")]
    [Scale(1e-15)]
    Femtoampere = -15,

    [UnitAbbreviation("pA")]
    [Scale(1e-12)]
    Picoampere = -12,

    [UnitAbbreviation("nA")]
    [Scale(1e-9)]
    Nanoampere = -9,

    [UnitAbbreviation("µA")]
    [Scale(1e-6)]
    Microampere = -6,

    [UnitAbbreviation("mA")]
    [Scale(1e-3)]
    Milliampere = -3,

    [UnitAbbreviation("cA")]
    [Scale(1e-2)]
    Centiampere = -2,

    [UnitAbbreviation("dA")]
    [Scale(1e-1)]
    Deciampere = -1,

    [UnitAbbreviation("A")]
    [Scale(1.0)]
    Ampere = 0,

    [UnitAbbreviation("daA")]
    [Scale(10)]
    Dekaampere = 1,

    [UnitAbbreviation("hA")]
    [Scale(100)]
    Hectoampere = 2,

    [UnitAbbreviation("kA")]
    [Scale(1e3)]
    Kiloampere = 3,

    [UnitAbbreviation("MA")]
    [Scale(1e6)]
    Megaampere = 6,

    [UnitAbbreviation("GA")]
    [Scale(1e9)]
    Gigaampere = 9,

    [UnitAbbreviation("TA")]
    [Scale(1e12)]
    Teraampere = 12,

    [UnitAbbreviation("PA")]
    [Scale(1e15)]
    Petaampere = 15,

    [UnitAbbreviation("EA")]
    [Scale(1e18)]
    Exaampere = 18,

    [UnitAbbreviation("ZA")]
    [Scale(1e21)]
    Zetaampere = 21,

    [UnitAbbreviation("YA")]
    [Scale(1e24)]
    Yottaampere = 24,

}