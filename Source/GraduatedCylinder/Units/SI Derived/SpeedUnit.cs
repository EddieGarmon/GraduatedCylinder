using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum SpeedUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = MeterPerSecond,

    [UnitAbbreviation("ym/s")]
    [Scale(1e-24)]
    YoctometerPerSecond = -24,

    [UnitAbbreviation("zm/s")]
    [Scale(1e-21)]
    ZeptometerPerSecond = -21,

    [UnitAbbreviation("am/s")]
    [Scale(1e-18)]
    AttometerPerSecond = -18,

    [UnitAbbreviation("fm/s")]
    [Scale(1e-15)]
    FemtometerPerSecond = -15,

    [UnitAbbreviation("pm/s")]
    [Scale(1e-12)]
    PicometerPerSecond = -12,

    [UnitAbbreviation("nm/s")]
    [Scale(1e-9)]
    NanometerPerSecond = -9,

    [UnitAbbreviation("µm/s")]
    [Scale(1e-6)]
    MicrometerPerSecond = -6,

    [UnitAbbreviation("mm/s")]
    [Scale(1e-3)]
    MillimeterPerSecond = -3,

    [UnitAbbreviation("cm/s")]
    [Scale(1e-2)]
    CentimeterPerSecond = -2,

    [UnitAbbreviation("dm/s")]
    [Scale(1e-1)]
    DecimeterPerSecond = -1,

    [UnitAbbreviation("m/s")]
    [Scale(1.0)]
    MeterPerSecond = 0,

    [UnitAbbreviation("dam/s")]
    [Scale(10)]
    DekameterPerSecond = 1,

    [UnitAbbreviation("hm/s")]
    [Scale(1e2)]
    HectometerPerSecond = 2,

    [UnitAbbreviation("km/s")]
    [Scale(1e3)]
    KilometerPerSecond = 3,

    [UnitAbbreviation("Mm/s")]
    [Scale(1e6)]
    MegameterPerSecond = 6,

    [UnitAbbreviation("Gm/s")]
    [Scale(1e9)]
    GigameterPerSecond = 9,

    [UnitAbbreviation("Tm/s")]
    [Scale(1e12)]
    TerameterPerSecond = 12,

    [UnitAbbreviation("Pm/s")]
    [Scale(1e15)]
    PetameterPerSecond = 15,

    [UnitAbbreviation("Em/s")]
    [Scale(1e18)]
    ExameterPerSecond = 18,

    [UnitAbbreviation("Zm/s")]
    [Scale(1e21)]
    ZettameterPerSecond = 21,

    [UnitAbbreviation("Ym/s")]
    [Scale(1e24)]
    YottameterPerSecond = 24,

    [UnitAbbreviation("m/min")]
    [Scale(1.0f / 60.0)]
    MetersPerMinute = 101,

    [UnitAbbreviation("m/h")]
    [Scale(1.0f / 3600.0)]
    MetersPerHour = 102,

    [UnitAbbreviation("km/h")]
    [Scale(1.0f / 3.6)]
    KilometersPerHour = 103,

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
    MilesPerHour = 107,

    [UnitAbbreviation("knots")]
    [Scale(0.514444)]
    NauticalMilesPerHour = 108,

    [UnitAbbreviation("yd/s")]
    [Scale(0.9144)]
    YardsPerSecond = 109

}