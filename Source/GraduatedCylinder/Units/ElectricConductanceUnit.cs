using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(ElectricConductance))]
public enum ElectricConductanceUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("pS")]
    [Scale(1e-12)]
    PicoSiemens = -12,

    [UnitAbbreviation("nS")]
    [Scale(1e-9)]
    NanoSiemens = -9,

    [UnitAbbreviation("µS")]
    [Scale(1e-6)]
    MicroSiemens = -6,

    [UnitAbbreviation("mS")]
    [Scale(1e-3)]
    MilliSiemens = -3,

    [BaseUnit]
    [UnitAbbreviation("S")]
    [Scale(1.0)]
    Siemens = 0,

    [UnitAbbreviation("kS")]
    [Scale(1e3)]
    KiloSiemens = 3,

    [UnitAbbreviation("MS")]
    [Scale(1e6)]
    MegaSiemens = 6

}