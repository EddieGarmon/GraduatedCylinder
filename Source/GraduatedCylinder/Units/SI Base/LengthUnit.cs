using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum LengthUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Meter,

        [UnitAbbreviation("ym")]
        [Scale(1e-24f)]
        Yoctometer = -24,

        [UnitAbbreviation("zm")]
        [Scale(1e-21f)]
        Zeptometer = -21,

        [UnitAbbreviation("am")]
        [Scale(1e-18f)]
        Attometer = -18,

        [UnitAbbreviation("fm")]
        [Scale(1e-15f)]
        Femtometer = -15,

        [UnitAbbreviation("pm")]
        [Scale(1e-12f)]
        Picometer = -12,

        [UnitAbbreviation("nm")]
        [Scale(1e-9f)]
        Nanometer = -9,

        [UnitAbbreviation("µm")]
        [Scale(1e-6f)]
        Micrometer = -6,

        [UnitAbbreviation("mm")]
        [Scale(1e-3f)]
        Millimeter = -3,

        [UnitAbbreviation("cm")]
        [Scale(1e-2f)]
        Centimeter = -2,

        [UnitAbbreviation("dm")]
        [Scale(1e-1f)]
        Decimeter = -1,

        [UnitAbbreviation("m")]
        [Scale(1.0f)]
        Meter = 0,

        [UnitAbbreviation("dam")]
        [Scale(10f)]
        Dekameter = 1,

        [UnitAbbreviation("hm")]
        [Scale(100f)]
        Hectometer = 2,

        [UnitAbbreviation("km")]
        [Scale(1e3f)]
        Kilometer = 3,

        [UnitAbbreviation("Mm")]
        [Scale(1e6f)]
        Megameter = 6,

        [UnitAbbreviation("Gm")]
        [Scale(1e9f)]
        Gigameter = 9,

        [UnitAbbreviation("Tm")]
        [Scale(1e12f)]
        Terameter = 12,

        [UnitAbbreviation("Pm")]
        [Scale(1e15f)]
        Petameter = 15,

        [UnitAbbreviation("Em")]
        [Scale(1e18f)]
        Exameter = 18,

        [UnitAbbreviation("Zm")]
        [Scale(1e21f)]
        Zettameter = 21,

        [UnitAbbreviation("Ym")]
        [Scale(1e24f)]
        Yottameter = 24,

        [UnitAbbreviation("in")]
        [Scale(0.0254f)]
        Inch = 101,

        [UnitAbbreviation("ft")]
        [Scale(0.3048f)]
        Foot = 102,

        [UnitAbbreviation("yd")]
        [Scale(0.9144f)]
        Yard = 103,

        [UnitAbbreviation("fath")]
        [Scale(1.8288f)]
        Fathom = 104,

        [UnitAbbreviation("mi")]
        [Scale(1609.344f)]
        Mile = 105,

        [UnitAbbreviation("nmi")]
        [Scale(1852.0f)]
        NauticalMile = 106

    }
}