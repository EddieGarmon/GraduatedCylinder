using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum AngleUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Radian,

    [UnitAbbreviation("yrad")]
    [Scale(1e-24)]
    Yoctoradian = -24,

    [UnitAbbreviation("zrad")]
    [Scale(1e-21)]
    Zeptoradian = -21,

    [UnitAbbreviation("arad")]
    [Scale(1e-18)]
    Attoradian = -18,

    [UnitAbbreviation("frad")]
    [Scale(1e-15)]
    Femtoradian = -15,

    [UnitAbbreviation("prad")]
    [Scale(1e-12)]
    Picoradian = -12,

    [UnitAbbreviation("nrad")]
    [Scale(1e-9)]
    Nanoradian = -9,

    [UnitAbbreviation("µrad")]
    [Scale(1e-6)]
    Microradian = -6,

    [UnitAbbreviation("mrad")]
    [Scale(1e-3)]
    Milliradian = -3,

    [UnitAbbreviation("crad")]
    [Scale(1e-2)]
    Centiradian = -2,

    [UnitAbbreviation("drad")]
    [Scale(1e-1)]
    Deciradian = -1,

    [UnitAbbreviation("rad")]
    [Scale(1)]
    Radian = 0,

    [UnitAbbreviation("darad")]
    [Scale(10)]
    Dekaradian = 1,

    [UnitAbbreviation("hrad")]
    [Scale(1e2)]
    Hectoradian = 2,

    [UnitAbbreviation("krad")]
    [Scale(1e3)]
    Kiloradian = 3,

    [UnitAbbreviation("Mrad")]
    [Scale(1e6)]
    Megaradian = 6,

    [UnitAbbreviation("Grad")]
    [Scale(1e9)]
    Gigaradian = 9,

    [UnitAbbreviation("Trad")]
    [Scale(1e12)]
    Teraradian = 12,

    [UnitAbbreviation("Prad")]
    [Scale(1e15)]
    Petaradian = 15,

    [UnitAbbreviation("Erad")]
    [Scale(1e18)]
    Exaradian = 18,

    [UnitAbbreviation("Zrad")]
    [Scale(1e21)]
    Zettaradian = 21,

    [UnitAbbreviation("Yrad")]
    [Scale(1e24)]
    Yottaradian = 24,

    [UnitAbbreviation("°")]
    [Scale(0.0174532925199433)]
    Degree = 101,

    [UnitAbbreviation("grads")]
    [Scale(0.0157079632679)]
    Grad = 102,

    [UnitAbbreviation("%grade")]
    [PercentGrade]
    PercentGrade = 103,

    [UnitAbbreviation("rev")]
    [Scale(6.283185307179586476925286766559)]
    Revolutions = 104,

}