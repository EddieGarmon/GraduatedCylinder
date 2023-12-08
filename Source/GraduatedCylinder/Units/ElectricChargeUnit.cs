using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(ElectricCharge))]
public enum ElectricChargeUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Coulomb,

    [UnitAbbreviation("mC")]
    [Scale(0.001)]
    MilliCoulomb = -3,

    [UnitAbbreviation("C")]
    [Scale(1.0)]
    Coulomb = 0,

    [UnitAbbreviation("kC")]
    [Scale(1000)]
    KiloCoulomb = 3,

    [UnitAbbreviation("MC")]
    [Scale(1E6)]
    MegaCoulomb = 6,

    [UnitAbbreviation("As")]
    [Scale(1.0)]
    AmpereSecond = -100,

    [UnitAbbreviation("mAh")]
    [Scale(3.6)]
    MilliAmpereHour,

    [UnitAbbreviation("Ah")]
    [Scale(3600)]
    AmpereHour

}