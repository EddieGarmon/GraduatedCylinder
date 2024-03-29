using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(ElectricResistance))]
public enum ElectricResistanceUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("yΩ")]
    [Scale(1e-24)]
    YoctoOhm = -24,

    [UnitAbbreviation("zΩ")]
    [Scale(1e-21)]
    ZeptoOhm = -21,

    [UnitAbbreviation("aΩ")]
    [Scale(1e-18)]
    AttoOhm = -18,

    [UnitAbbreviation("fΩ")]
    [Scale(1e-15)]
    FemtoOhm = -15,

    [UnitAbbreviation("pΩ")]
    [Scale(1e-12)]
    PicoOhm = -12,

    [UnitAbbreviation("nΩ")]
    [Scale(1e-9)]
    NanoOhm = -9,

    [UnitAbbreviation("µΩ")]
    [Scale(1e-6)]
    MicroOhm = -6,

    [UnitAbbreviation("mΩ")]
    [Scale(1e-3)]
    MilliOhm = -3,

    [UnitAbbreviation("cΩ")]
    [Scale(1e-2)]
    CentiOhm = -2,

    [UnitAbbreviation("dΩ")]
    [Scale(1e-1)]
    DeciOhm = -1,

    [BaseUnit]
    [UnitAbbreviation("Ω")]
    [Scale(1.0)]
    [Extension("Ohms")]
    Ohm = 0,

    [UnitAbbreviation("daΩ")]
    [Scale(10)]
    DekaOhm = 1,

    [UnitAbbreviation("hΩ")]
    [Scale(1e2)]
    HectoOhm = 2,

    [UnitAbbreviation("kΩ")]
    [Scale(1e3)]
    [Extension("KiloOhms")]
    KiloOhm = 3,

    [UnitAbbreviation("MΩ")]
    [Scale(1e6)]
    [Extension("MegaOhms")]
    MegaOhm = 6,

    [UnitAbbreviation("GΩ")]
    [Scale(1e9)]
    GigaOhm = 9,

    [UnitAbbreviation("TΩ")]
    [Scale(1e12)]
    TeraOhm = 12,

    [UnitAbbreviation("PΩ")]
    [Scale(1e15)]
    PetaOhm = 15,

    [UnitAbbreviation("EΩ")]
    [Scale(1e18)]
    ExaOhm = 18,

    [UnitAbbreviation("ZΩ")]
    [Scale(1e21)]
    ZettaOhm = 21,

    [UnitAbbreviation("YΩ")]
    [Scale(1e24)]
    YottaOhm = 24

}