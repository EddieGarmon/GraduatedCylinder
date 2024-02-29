using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(ElectricInductance))]
public enum ElectricInductanceUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("pH")]
    [Scale(1e-12)]
    PicoHenry = -12,

    [UnitAbbreviation("nH")]
    [Scale(1e-9)]
    NanoHenry = -9,

    [UnitAbbreviation("µH")]
    [Scale(1e-6)]
    MicroHenry = -6,

    [UnitAbbreviation("mH")]
    [Scale(1e-3)]
    MilliHenry = -3,

    [BaseUnit]
    [UnitAbbreviation("H")]
    [Scale(1.0)]
    Henry = 0,

    [UnitAbbreviation("kH")]
    [Scale(1e3)]
    KiloHenry = 3,

    [UnitAbbreviation("MH")]
    [Scale(1e6)]
    MegaHenry = 6

}