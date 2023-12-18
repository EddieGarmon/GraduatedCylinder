using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Angle))]
public enum AngleUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Radian,

    [UnitAbbreviation("yrad")]
    [Scale(1e-24)]
    YoctoRadian = -24,

    [UnitAbbreviation("zrad")]
    [Scale(1e-21)]
    ZeptoRadian = -21,

    [UnitAbbreviation("arad")]
    [Scale(1e-18)]
    AttoRadian = -18,

    [UnitAbbreviation("frad")]
    [Scale(1e-15)]
    FemtoRadian = -15,

    [UnitAbbreviation("prad")]
    [Scale(1e-12)]
    PicoRadian = -12,

    [UnitAbbreviation("nrad")]
    [Scale(1e-9)]
    NanoRadian = -9,

    [UnitAbbreviation("µrad")]
    [Scale(1e-6)]
    MicroRadian = -6,

    [UnitAbbreviation("mrad")]
    [Scale(1e-3)]
    MilliRadian = -3,

    [UnitAbbreviation("crad")]
    [Scale(1e-2)]
    CentiRadian = -2,

    [UnitAbbreviation("drad")]
    [Scale(1e-1)]
    DeciRadian = -1,

    [UnitAbbreviation("rad")]
    [Scale(1)]
    [Extension("Radians")]
    Radian = 0,

    [UnitAbbreviation("darad")]
    [Scale(10)]
    DekaRadian = 1,

    [UnitAbbreviation("hrad")]
    [Scale(1e2)]
    HectoRadian = 2,

    [UnitAbbreviation("krad")]
    [Scale(1e3)]
    KiloRadian = 3,

    [UnitAbbreviation("Mrad")]
    [Scale(1e6)]
    MegaRadian = 6,

    [UnitAbbreviation("Grad")]
    [Scale(1e9)]
    GigaRadian = 9,

    [UnitAbbreviation("Trad")]
    [Scale(1e12)]
    TeraRadian = 12,

    [UnitAbbreviation("Prad")]
    [Scale(1e15)]
    PetaRadian = 15,

    [UnitAbbreviation("Erad")]
    [Scale(1e18)]
    ExaRadian = 18,

    [UnitAbbreviation("Zrad")]
    [Scale(1e21)]
    ZettaRadian = 21,

    [UnitAbbreviation("Yrad")]
    [Scale(1e24)]
    YottaRadian = 24,

    [UnitAbbreviation("°")]
    [Scale(Math.PI / 180)]
    [Extension("Degrees")]
    Degree = 101,

    [UnitAbbreviation("'")]
    [Scale(Math.PI / 10800)]
    Minute = 102,

    //todo: this abbreviation generates invalid code and kills the build
    //[UnitAbbreviation("\"")]
    //[Scale(Math.PI / 648000)]
    //Second = 103,

    [UnitAbbreviation("grads")]
    [Scale(0.015707963267949)]
    Grad = 110,

    [UnitAbbreviation("%grade")]
    [PercentGrade]
    PercentGrade = 111,

    [UnitAbbreviation("rev")]
    [Scale(6.28318530717959)]
    [Extension("Revolutions")]
    Revolutions = 120

}