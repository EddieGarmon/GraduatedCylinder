using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(AmountOfSubstance))]
public enum AmountOfSubstanceUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("ymol")]
    [Scale(1e-24)]
    YoctoMole = -24,

    [UnitAbbreviation("zmol")]
    [Scale(1e-21)]
    ZeptoMole = -21,

    [UnitAbbreviation("amol")]
    [Scale(1e-18)]
    AttoMole = -18,

    [UnitAbbreviation("fmol")]
    [Scale(1e-15)]
    FemtoMole = -15,

    [UnitAbbreviation("pmol")]
    [Scale(1e-12)]
    PicoMole = -12,

    [UnitAbbreviation("nmol")]
    [Scale(1e-9)]
    NanoMole = -9,

    [UnitAbbreviation("µmol")]
    [Scale(1e-6)]
    MicroMole = -6,

    [UnitAbbreviation("mmol")]
    [Scale(1e-3)]
    MilliMole = -3,

    [UnitAbbreviation("cmol")]
    [Scale(1e-2)]
    CentiMole = -2,

    [UnitAbbreviation("dmol")]
    [Scale(1e-1)]
    DeciMole = -1,

    [BaseUnit]
    [UnitAbbreviation("mol")]
    [Scale(1.0)]
    [Extension("Moles")]
    Mole = 0,

    [UnitAbbreviation("damol")]
    [Scale(10)]
    DekaMole = 1,

    [UnitAbbreviation("hmol")]
    [Scale(1e2)]
    HectoMole = 2,

    [UnitAbbreviation("kmol")]
    [Scale(1e3)]
    KiloMole = 3,

    [UnitAbbreviation("Mmol")]
    [Scale(1e6)]
    MegaMole = 6,

    [UnitAbbreviation("Gmol")]
    [Scale(1e9)]
    GigaMole = 9,

    [UnitAbbreviation("Tmol")]
    [Scale(1e12)]
    TeraMole = 12,

    [UnitAbbreviation("Pmol")]
    [Scale(1e15)]
    PetaMole = 15,

    [UnitAbbreviation("Emol")]
    [Scale(1e18)]
    ExaMole = 18,

    [UnitAbbreviation("Zmol")]
    [Scale(1e21)]
    ZettaMole = 21,

    [UnitAbbreviation("Ymol")]
    [Scale(1e24)]
    YottaMole = 24

}