using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Length))]
public enum LengthUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("ym")]
    [Scale(1e-24)]
    YoctoMeter = -24,

    [UnitAbbreviation("zm")]
    [Scale(1e-21)]
    ZeptoMeter = -21,

    [UnitAbbreviation("am")]
    [Scale(1e-18)]
    AttoMeter = -18,

    [UnitAbbreviation("fm")]
    [Scale(1e-15)]
    FemtoMeter = -15,

    [UnitAbbreviation("pm")]
    [Scale(1e-12)]
    PicoMeter = -12,

    [UnitAbbreviation("nm")]
    [Scale(1e-9)]
    NanoMeter = -9,

    [UnitAbbreviation("µm")]
    [Scale(1e-6)]
    MicroMeter = -6,

    [UnitAbbreviation("mm")]
    [Scale(1e-3)]
    [Extension("MilliMeters")]
    MilliMeter = -3,

    [UnitAbbreviation("cm")]
    [Scale(1e-2)]
    [Extension("CentiMeters")]
    CentiMeter = -2,

    [UnitAbbreviation("dm")]
    [Scale(1e-1)]
    DeciMeter = -1,

    [BaseUnit]
    [UnitAbbreviation("m")]
    [Scale(1.0)]
    [Extension("Meters")]
    Meter = 0,

    [UnitAbbreviation("dam")]
    [Scale(10)]
    DekaMeter = 1,

    [UnitAbbreviation("hm")]
    [Scale(100)]
    HectoMeter = 2,

    [UnitAbbreviation("km")]
    [Scale(1e3)]
    [Extension("KiloMeters")]
    KiloMeter = 3,

    [UnitAbbreviation("Mm")]
    [Scale(1e6)]
    MegaMeter = 6,

    [UnitAbbreviation("Gm")]
    [Scale(1e9)]
    GigaMeter = 9,

    [UnitAbbreviation("Tm")]
    [Scale(1e12)]
    TeraMeter = 12,

    [UnitAbbreviation("Pm")]
    [Scale(1e15)]
    PetaMeter = 15,

    [UnitAbbreviation("Em")]
    [Scale(1e18)]
    ExaMeter = 18,

    [UnitAbbreviation("Zm")]
    [Scale(1e21)]
    ZettaMeter = 21,

    [UnitAbbreviation("Ym")]
    [Scale(1e24)]
    YottaMeter = 24,

    [UnitAbbreviation("in")]
    [Scale(0.0254)]
    [Extension("Inches")]
    Inch = 101,

    [UnitAbbreviation("ft")]
    [Scale(0.3048)]
    [Extension("Feet")]
    Foot = 102,

    [UnitAbbreviation("yd")]
    [Scale(0.9144)]
    [Extension("Yards")]
    Yard = 103,

    [UnitAbbreviation("fath")]
    [Scale(1.8288)]
    Fathom = 104,

    [UnitAbbreviation("mi")]
    [Scale(1609.344)]
    [Extension("Miles")]
    Mile = 105,

    [UnitAbbreviation("nmi")]
    [Scale(1852.0)]
    NauticalMile = 106

}