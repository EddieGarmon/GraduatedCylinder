using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Frequency))]
public enum FrequencyUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("Hz")]
    [Scale(1.0)]
    [Extension("Hertz")]
    Hertz = 0,

    [UnitAbbreviation("MHz")]
    [Scale(1e6)]
    [Extension("MegaHertz")]
    MegaHertz = 6,

    [UnitAbbreviation("GHz")]
    [Scale(1e9)]
    [Extension("GigaHertz")]
    GigaHertz = 9,

    [UnitAbbreviation("rad/s")]
    [Scale(0.159154943274)]
    RadiansPerSecond = 101,

    [UnitAbbreviation("n/s")]
    [Scale(1.0)]
    CyclePerSecond = -100,

    [UnitAbbreviation("r/s")]
    [Scale(1.0)]
    RevolutionPerSecond = -101,

    [UnitAbbreviation("r/min")]
    //[AlternateUnitAbbreviation("rpm")]
    [Scale(0.0166666666667)]
    [Extension("RevolutionsPerMinute")]
    RevolutionsPerMinute = 102,

    BaseUnit = Hertz

}