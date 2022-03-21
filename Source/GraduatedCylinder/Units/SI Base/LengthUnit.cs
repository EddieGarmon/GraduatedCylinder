using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum LengthUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Meter,

    [UnitAbbreviation("ym")]
    [Scale(1e-24)]
    Yoctometer = -24,

    [UnitAbbreviation("zm")]
    [Scale(1e-21)]
    Zeptometer = -21,

    [UnitAbbreviation("am")]
    [Scale(1e-18)]
    Attometer = -18,

    [UnitAbbreviation("fm")]
    [Scale(1e-15)]
    Femtometer = -15,

    [UnitAbbreviation("pm")]
    [Scale(1e-12)]
    Picometer = -12,

    [UnitAbbreviation("nm")]
    [Scale(1e-9)]
    Nanometer = -9,

    [UnitAbbreviation("µm")]
    [Scale(1e-6)]
    Micrometer = -6,

    [UnitAbbreviation("mm")]
    [Scale(1e-3)]
    Millimeter = -3,

    [UnitAbbreviation("cm")]
    [Scale(1e-2)]
    Centimeter = -2,

    [UnitAbbreviation("dm")]
    [Scale(1e-1)]
    Decimeter = -1,

    [UnitAbbreviation("m")]
    [Scale(1.0)]
    Meter = 0,

    [UnitAbbreviation("dam")]
    [Scale(10)]
    Dekameter = 1,

    [UnitAbbreviation("hm")]
    [Scale(100)]
    Hectometer = 2,

    [UnitAbbreviation("km")]
    [Scale(1e3)]
    Kilometer = 3,

    [UnitAbbreviation("Mm")]
    [Scale(1e6)]
    Megameter = 6,

    [UnitAbbreviation("Gm")]
    [Scale(1e9)]
    Gigameter = 9,

    [UnitAbbreviation("Tm")]
    [Scale(1e12)]
    Terameter = 12,

    [UnitAbbreviation("Pm")]
    [Scale(1e15)]
    Petameter = 15,

    [UnitAbbreviation("Em")]
    [Scale(1e18)]
    Exameter = 18,

    [UnitAbbreviation("Zm")]
    [Scale(1e21)]
    Zettameter = 21,

    [UnitAbbreviation("Ym")]
    [Scale(1e24)]
    Yottameter = 24,

    [UnitAbbreviation("in")]
    [Scale(0.0254)]
    Inch = 101,

    [UnitAbbreviation("ft")]
    [Scale(0.3048)]
    Foot = 102,

    [UnitAbbreviation("yd")]
    [Scale(0.9144)]
    Yard = 103,

    [UnitAbbreviation("fath")]
    [Scale(1.8288)]
    Fathom = 104,

    [UnitAbbreviation("mi")]
    [Scale(1609.344)]
    Mile = 105,

    [UnitAbbreviation("nmi")]
    [Scale(1852.0)]
    NauticalMile = 106

}