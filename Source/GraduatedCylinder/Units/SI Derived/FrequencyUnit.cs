using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum FrequencyUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Hertz,

    [UnitAbbreviation("Hz")]
    [Scale(1.0)]
    Hertz = 0,

    [UnitAbbreviation("MHz")]
    [Scale(1e6)]
    Megahertz = 6,

    [UnitAbbreviation("GHz")]
    [Scale(1e9)]
    Gigahertz = 9,

    [UnitAbbreviation("rad/s")]
    [Scale(0.159154943274)]
    RadiansPerSecond = 101,

    [UnitAbbreviation("n/s")]
    [Scale(1.0)]
    CyclePerSecond = -100,

    [UnitAbbreviation("r/s")]
    [Scale(1.0)]
    RevolutionPerSecond = -101,

    [UnitAbbreviation("rpm")]
    [Scale(0.0166666666667)]
    RevolutionsPerMinute = 102

}