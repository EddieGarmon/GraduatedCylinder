using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Acceleration))]
public enum AccelerationUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("ym/s²")]
    [Scale(1e-24)]
    YoctoMeterPerSquareSecond = -24,

    [UnitAbbreviation("zm/s²")]
    [Scale(1e-21)]
    ZeptoMeterPerSquareSecond = -21,

    [UnitAbbreviation("am/s²")]
    [Scale(1e-18)]
    AttoMeterPerSquareSecond = -18,

    [UnitAbbreviation("fm/s²")]
    [Scale(1e-15)]
    FemtoMeterPerSquareSecond = -15,

    [UnitAbbreviation("pm/s²")]
    [Scale(1e-12)]
    PicoMeterPerSquareSecond = -12,

    [UnitAbbreviation("nm/s²")]
    [Scale(1e-9)]
    NanoMeterPerSquareSecond = -9,

    [UnitAbbreviation("µm/s²")]
    [Scale(1e-6)]
    MicroMeterPerSquareSecond = -6,

    [UnitAbbreviation("mm/s²")]
    [Scale(1e-3)]
    MilliMeterPerSquareSecond = -3,

    [UnitAbbreviation("cm/s²")]
    [Scale(1e-2)]
    CentiMeterPerSquareSecond = -2,

    [UnitAbbreviation("dm/s²")]
    [Scale(1e-1)]
    DeciMeterPerSquareSecond = -1,

    [BaseUnit]
    [UnitAbbreviation("m/s²")]
    [Scale(1.0)]
    MeterPerSquareSecond = 0,

    [UnitAbbreviation("dam/s²")]
    [Scale(10)]
    DekaMeterPerSquareSecond = 1,

    [UnitAbbreviation("hm/s²")]
    [Scale(1e2)]
    HectoMeterPerSquareSecond = 2,

    [UnitAbbreviation("km/s²")]
    [Scale(1e3)]
    KiloMeterPerSquareSecond = 3,

    [UnitAbbreviation("Mm/s²")]
    [Scale(1e6)]
    MegaMeterPerSquareSecond = 6,

    [UnitAbbreviation("Gm/s²")]
    [Scale(1e9)]
    GigaMeterPerSquareSecond = 9,

    [UnitAbbreviation("Tm/s²")]
    [Scale(1e12)]
    TeraMeterPerSquareSecond = 12,

    [UnitAbbreviation("Pm/s²")]
    [Scale(1e15)]
    PetaMeterPerSquareSecond = 15,

    [UnitAbbreviation("Em/s²")]
    [Scale(1e18)]
    ExaMeterPerSquareSecond = 18,

    [UnitAbbreviation("Zm/s²")]
    [Scale(1e21)]
    ZettaMeterPerSquareSecond = 21,

    [UnitAbbreviation("Ym/s²")]
    [Scale(1e24)]
    YottaMeterPerSquareSecond = 24,

    [UnitAbbreviation("km/h/s")]
    [Scale(1.0f / 3.6)]
    KiloMeterPerHourPerSecond = 101,

    [UnitAbbreviation("mph/s")]
    [Scale(0.44704)]
    MilePerHourPerSecond = 102,

    [UnitAbbreviation("ft/s²")]
    [Scale(0.3048)]
    FeetPerSquareSecond = 103

}