using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Extensions;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum SpeedUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = MeterPerSecond,

    [UnitAbbreviation("ym/s")]
    [Scale(1e-24)]
    YoctoMeterPerSecond = -24,

    [UnitAbbreviation("zm/s")]
    [Scale(1e-21)]
    ZeptoMeterPerSecond = -21,

    [UnitAbbreviation("am/s")]
    [Scale(1e-18)]
    AttoMeterPerSecond = -18,

    [UnitAbbreviation("fm/s")]
    [Scale(1e-15)]
    FemtoMeterPerSecond = -15,

    [UnitAbbreviation("pm/s")]
    [Scale(1e-12)]
    PicoMeterPerSecond = -12,

    [UnitAbbreviation("nm/s")]
    [Scale(1e-9)]
    NanoMeterPerSecond = -9,

    [UnitAbbreviation("µm/s")]
    [Scale(1e-6)]
    MicroMeterPerSecond = -6,

    [UnitAbbreviation("mm/s")]
    [Scale(1e-3)]
    MilliMeterPerSecond = -3,

    [UnitAbbreviation("cm/s")]
    [Scale(1e-2)]
    CentiMeterPerSecond = -2,

    [UnitAbbreviation("dm/s")]
    [Scale(1e-1)]
    DeciMeterPerSecond = -1,

    [UnitAbbreviation("m/s")]
    [Scale(1.0)]
    [Extension("MetersPerSecond")]
    MeterPerSecond = 0,

    [UnitAbbreviation("dam/s")]
    [Scale(10)]
    DekaMeterPerSecond = 1,

    [UnitAbbreviation("hm/s")]
    [Scale(1e2)]
    HectoMeterPerSecond = 2,

    [UnitAbbreviation("km/s")]
    [Scale(1e3)]
    KiloMeterPerSecond = 3,

    [UnitAbbreviation("Mm/s")]
    [Scale(1e6)]
    MegaMeterPerSecond = 6,

    [UnitAbbreviation("Gm/s")]
    [Scale(1e9)]
    GigaMeterPerSecond = 9,

    [UnitAbbreviation("Tm/s")]
    [Scale(1e12)]
    TeraMeterPerSecond = 12,

    [UnitAbbreviation("Pm/s")]
    [Scale(1e15)]
    PetaMeterPerSecond = 15,

    [UnitAbbreviation("Em/s")]
    [Scale(1e18)]
    ExaMeterPerSecond = 18,

    [UnitAbbreviation("Zm/s")]
    [Scale(1e21)]
    ZettaMeterPerSecond = 21,

    [UnitAbbreviation("Ym/s")]
    [Scale(1e24)]
    YottaMeterPerSecond = 24,

    [UnitAbbreviation("m/min")]
    [Scale(1.0f / 60.0)]
    MetersPerMinute = 101,

    [UnitAbbreviation("m/h")]
    [Scale(1.0f / 3600.0)]
    MetersPerHour = 102,

    [UnitAbbreviation("km/h")]
    [Scale(1.0f / 3.6)]
    [Extension("KiloMetersPerHour")]
    KiloMetersPerHour = 103,

    [UnitAbbreviation("ft/s")]
    [Scale(0.3048)]
    FeetPerSecond = 104,

    [UnitAbbreviation("ft/min")]
    [Scale(0.00508)]
    FeetPerMinute = 105,

    [UnitAbbreviation("ft/h")]
    [Scale(1.0f / 11811.0)]
    FeetPerHour = 106,

    [UnitAbbreviation("mph")]
    [Scale(0.44704)]
    [Extension("MilesPerHour")]
    MilesPerHour = 107,

    [UnitAbbreviation("knots")]
    [Scale(0.514444)]
    NauticalMilesPerHour = 108,

    [UnitAbbreviation("yd/s")]
    [Scale(0.9144)]
    YardsPerSecond = 109

}