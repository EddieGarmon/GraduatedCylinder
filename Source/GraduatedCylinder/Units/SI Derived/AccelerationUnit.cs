using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum AccelerationUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = MeterPerSquareSecond,

    [UnitAbbreviation("ym/s�")]
    [Scale(1e-24)]
    YoctometerPerSquareSecond = -24,

    [UnitAbbreviation("zm/s�")]
    [Scale(1e-21)]
    ZeptometerPerSquareSecond = -21,

    [UnitAbbreviation("am/s�")]
    [Scale(1e-18)]
    AttometerPerSquareSecond = -18,

    [UnitAbbreviation("fm/s�")]
    [Scale(1e-15)]
    FemtometerPerSquareSecond = -15,

    [UnitAbbreviation("pm/s�")]
    [Scale(1e-12)]
    PicometerPerSquareSecond = -12,

    [UnitAbbreviation("nm/s�")]
    [Scale(1e-9)]
    NanometerPerSquareSecond = -9,

    [UnitAbbreviation("�m/s�")]
    [Scale(1e-6)]
    MicrometerPerSquareSecond = -6,

    [UnitAbbreviation("mm/s�")]
    [Scale(1e-3)]
    MillimeterPerSquareSecond = -3,

    [UnitAbbreviation("cm/s�")]
    [Scale(1e-2)]
    CentimeterPerSquareSecond = -2,

    [UnitAbbreviation("dm/s�")]
    [Scale(1e-1)]
    DecimeterPerSquareSecond = -1,

    [UnitAbbreviation("m/s�")]
    [Scale(1.0)]
    MeterPerSquareSecond = 0,

    [UnitAbbreviation("dam/s�")]
    [Scale(10)]
    DekameterPerSquareSecond = 1,

    [UnitAbbreviation("hm/s�")]
    [Scale(1e2)]
    HectometerPerSquareSecond = 2,

    [UnitAbbreviation("km/s�")]
    [Scale(1e3)]
    KilometerPerSquareSecond = 3,

    [UnitAbbreviation("Mm/s�")]
    [Scale(1e6)]
    MegameterPerSquareSecond = 6,

    [UnitAbbreviation("Gm/s�")]
    [Scale(1e9)]
    GigameterPerSquareSecond = 9,

    [UnitAbbreviation("Tm/s�")]
    [Scale(1e12)]
    TerameterPerSquareSecond = 12,

    [UnitAbbreviation("Pm/s�")]
    [Scale(1e15)]
    PetameterPerSquareSecond = 15,

    [UnitAbbreviation("Em/s�")]
    [Scale(1e18)]
    ExameterPerSquareSecond = 18,

    [UnitAbbreviation("Zm/s�")]
    [Scale(1e21)]
    ZettameterPerSquareSecond = 21,

    [UnitAbbreviation("Ym/s�")]
    [Scale(1e24)]
    YottameterPerSquareSecond = 24,

    [UnitAbbreviation("km/h/s")]
    [Scale(1.0f / 3.6)]
    KilometerPerHourPerSecond = 101,

    [UnitAbbreviation("mph/s")]
    [Scale(0.44704)]
    MilePerHourPerSecond = 102

}