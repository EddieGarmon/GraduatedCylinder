using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum AccelerationUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = MeterPerSecondSquared,

    [UnitAbbreviation("ym/s�")]
    [Scale(1e-24)]
    YoctometerPerSecondSquared = -24,

    [UnitAbbreviation("zm/s�")]
    [Scale(1e-21)]
    ZeptometerPerSecondSquared = -21,

    [UnitAbbreviation("am/s�")]
    [Scale(1e-18)]
    AttometerPerSecondSquared = -18,

    [UnitAbbreviation("fm/s�")]
    [Scale(1e-15)]
    FemtometerPerSecondSquared = -15,

    [UnitAbbreviation("pm/s�")]
    [Scale(1e-12)]
    PicometerPerSecondSquared = -12,

    [UnitAbbreviation("nm/s�")]
    [Scale(1e-9)]
    NanometerPerSecondSquared = -9,

    [UnitAbbreviation("�m/s�")]
    [Scale(1e-6)]
    MicrometerPerSecondSquared = -6,

    [UnitAbbreviation("mm/s�")]
    [Scale(1e-3)]
    MillimeterPerSecondSquared = -3,

    [UnitAbbreviation("cm/s�")]
    [Scale(1e-2)]
    CentimeterPerSecondSquared = -2,

    [UnitAbbreviation("dm/s�")]
    [Scale(1e-1)]
    DecimeterPerSecondSquared = -1,

    [UnitAbbreviation("m/s�")]
    [Scale(1.0)]
    MeterPerSecondSquared = 0,

    [UnitAbbreviation("dam/s�")]
    [Scale(10)]
    DekameterPerSecondSquared = 1,

    [UnitAbbreviation("hm/s�")]
    [Scale(1e2)]
    HectometerPerSecondSquared = 2,

    [UnitAbbreviation("km/s�")]
    [Scale(1e3)]
    KilometerPerSecondSquared = 3,

    [UnitAbbreviation("Mm/s�")]
    [Scale(1e6)]
    MegameterPerSecondSquared = 6,

    [UnitAbbreviation("Gm/s�")]
    [Scale(1e9)]
    GigameterPerSecondSquared = 9,

    [UnitAbbreviation("Tm/s�")]
    [Scale(1e12)]
    TerameterPerSecondSquared = 12,

    [UnitAbbreviation("Pm/s�")]
    [Scale(1e15)]
    PetameterPerSecondSquared = 15,

    [UnitAbbreviation("Em/s�")]
    [Scale(1e18)]
    ExameterPerSecondSquared = 18,

    [UnitAbbreviation("Zm/s�")]
    [Scale(1e21)]
    ZettameterPerSecondSquared = 21,

    [UnitAbbreviation("Ym/s�")]
    [Scale(1e24)]
    YottameterPerSecondSquared = 24,

    [UnitAbbreviation("km/h/s")]
    [Scale(1.0f / 3.6)]
    KilometerPerHourPerSecond = 101,

    [UnitAbbreviation("mph/s")]
    [Scale(0.44704)]
    MilePerHourPerSecond = 102

}