using GraduatedCylinder.Scales;

namespace GraduatedCylinder.Units
{
    public enum FrequencyUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Hertz,

        [UnitAbbreviation("Hz")]
        [Scale(1.0f)]
        Hertz = 0,

        [UnitAbbreviation("MHz")]
        [Scale(1e6f)]
        Megahertz = 6,

        [UnitAbbreviation("GHz")]
        [Scale(1e9f)]
        Gigahertz = 9,

        [UnitAbbreviation("rad/s")]
        [Scale(0.159154943274f)]
        RadiansPerSecond = 101,

        [UnitAbbreviation("n/s")]
        [Scale(1.0f)]
        CyclePerSecond = 102,

        [UnitAbbreviation("r/s")]
        [Scale(1.0f)]
        RevolutionPerSecond = 103,

        [UnitAbbreviation("rpm")]
        [Scale(0.0166666666667f)]
        RevolutionsPerMinute = 104

    }
}