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

    [UnitAbbreviation("ym/s�")]
    [Scale(1e-24)]
    YoctoMeterPerSquareSecond = -24,

    [UnitAbbreviation("zm/s�")]
    [Scale(1e-21)]
    ZeptoMeterPerSquareSecond = -21,

    [UnitAbbreviation("am/s�")]
    [Scale(1e-18)]
    AttoMeterPerSquareSecond = -18,

    [UnitAbbreviation("fm/s�")]
    [Scale(1e-15)]
    FemtoMeterPerSquareSecond = -15,

    [UnitAbbreviation("pm/s�")]
    [Scale(1e-12)]
    PicoMeterPerSquareSecond = -12,

    [UnitAbbreviation("nm/s�")]
    [Scale(1e-9)]
    NanoMeterPerSquareSecond = -9,

    [UnitAbbreviation("�m/s�")]
    [Scale(1e-6)]
    MicroMeterPerSquareSecond = -6,

    [UnitAbbreviation("mm/s�")]
    [Scale(1e-3)]
    MilliMeterPerSquareSecond = -3,

    [UnitAbbreviation("cm/s�")]
    [Scale(1e-2)]
    CentiMeterPerSquareSecond = -2,

    [UnitAbbreviation("dm/s�")]
    [Scale(1e-1)]
    DeciMeterPerSquareSecond = -1,

    [BaseUnit]
    [UnitAbbreviation("m/s�")]
    [Scale(1.0)]
    MeterPerSquareSecond = 0,

    [UnitAbbreviation("dam/s�")]
    [Scale(10)]
    DekaMeterPerSquareSecond = 1,

    [UnitAbbreviation("hm/s�")]
    [Scale(1e2)]
    HectoMeterPerSquareSecond = 2,

    [UnitAbbreviation("km/s�")]
    [Scale(1e3)]
    KiloMeterPerSquareSecond = 3,

    [UnitAbbreviation("Mm/s�")]
    [Scale(1e6)]
    MegaMeterPerSquareSecond = 6,

    [UnitAbbreviation("Gm/s�")]
    [Scale(1e9)]
    GigaMeterPerSquareSecond = 9,

    [UnitAbbreviation("Tm/s�")]
    [Scale(1e12)]
    TeraMeterPerSquareSecond = 12,

    [UnitAbbreviation("Pm/s�")]
    [Scale(1e15)]
    PetaMeterPerSquareSecond = 15,

    [UnitAbbreviation("Em/s�")]
    [Scale(1e18)]
    ExaMeterPerSquareSecond = 18,

    [UnitAbbreviation("Zm/s�")]
    [Scale(1e21)]
    ZettaMeterPerSquareSecond = 21,

    [UnitAbbreviation("Ym/s�")]
    [Scale(1e24)]
    YottaMeterPerSquareSecond = 24,

    [UnitAbbreviation("km/h/s")]
    [Scale(1.0f / 3.6)]
    KiloMeterPerHourPerSecond = 101,

    [UnitAbbreviation("mph/s")]
    [Scale(0.44704)]
    MilePerHourPerSecond = 102,

    [UnitAbbreviation("ft/s�")]
    [Scale(0.3048)]
    FeetPerSquareSecond = 103

}