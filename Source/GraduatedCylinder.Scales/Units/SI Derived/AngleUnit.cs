using GraduatedCylinder.Scales;

namespace GraduatedCylinder.Units
{
    public enum AngleUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Radian,

        [UnitAbbreviation("yrad")]
        [Scale(1e-24f)]
        Yoctoradian = -24,

        [UnitAbbreviation("zrad")]
        [Scale(1e-21f)]
        Zeptoradian = -21,

        [UnitAbbreviation("arad")]
        [Scale(1e-18f)]
        Attoradian = -18,

        [UnitAbbreviation("frad")]
        [Scale(1e-15f)]
        Femtoradian = -15,

        [UnitAbbreviation("prad")]
        [Scale(1e-12f)]
        Picoradian = -12,

        [UnitAbbreviation("nrad")]
        [Scale(1e-9f)]
        Nanoradian = -9,

        [UnitAbbreviation("µrad")]
        [Scale(1e-6f)]
        Microradian = -6,

        [UnitAbbreviation("mrad")]
        [Scale(1e-3f)]
        Milliradian = -3,

        [UnitAbbreviation("crad")]
        [Scale(1e-2f)]
        Centiradian = -2,

        [UnitAbbreviation("drad")]
        [Scale(1e-1f)]
        Deciradian = -1,

        [UnitAbbreviation("rad")]
        [Scale(1f)]
        Radian = 0,

        [UnitAbbreviation("darad")]
        [Scale(10f)]
        Dekaradian = 1,

        [UnitAbbreviation("hrad")]
        [Scale(1e2f)]
        Hectoradian = 2,

        [UnitAbbreviation("krad")]
        [Scale(1e3f)]
        Kiloradian = 3,

        [UnitAbbreviation("Mrad")]
        [Scale(1e6f)]
        Megaradian = 6,

        [UnitAbbreviation("Grad")]
        [Scale(1e9f)]
        Gigaradian = 9,

        [UnitAbbreviation("Trad")]
        [Scale(1e12f)]
        Teraradian = 12,

        [UnitAbbreviation("Prad")]
        [Scale(1e15f)]
        Petaradian = 15,

        [UnitAbbreviation("Erad")]
        [Scale(1e18f)]
        Exaradian = 18,

        [UnitAbbreviation("Zrad")]
        [Scale(1e21f)]
        Zettaradian = 21,

        [UnitAbbreviation("Yrad")]
        [Scale(1e24f)]
        Yottaradian = 24,

        [UnitAbbreviation("°")]
        [Scale(0.0174532925199f)]
        Degree = 101,

        [UnitAbbreviation("grads")]
        [Scale(0.0157079632679f)]
        Grad = 102,

        [UnitAbbreviation("%grade")]
        [PercentGrade]
        PercentGrade = 103

    }
}