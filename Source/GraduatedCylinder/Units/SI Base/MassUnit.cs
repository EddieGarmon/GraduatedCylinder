using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum MassUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Kilogram,

        [UnitAbbreviation("yg")]
        [Scale(1e-27f)]
        Yoctogram = -24,

        [UnitAbbreviation("zg")]
        [Scale(1e-24f)]
        Zeptogram = -21,

        [UnitAbbreviation("ag")]
        [Scale(1e-21f)]
        Attogram = -18,

        [UnitAbbreviation("fg")]
        [Scale(1e-18f)]
        Femtogram = -15,

        [UnitAbbreviation("pg")]
        [Scale(1e-15f)]
        Picogram = -12,

        [UnitAbbreviation("ng")]
        [Scale(1e-12f)]
        Nanogram = -9,

        [UnitAbbreviation("µg")]
        [Scale(1e-9f)]
        Microgram = -6,

        [UnitAbbreviation("mg")]
        [Scale(1e-6f)]
        Milligram = -3,

        [UnitAbbreviation("cg")]
        [Scale(1e-5f)]
        Centigram = -2,

        [UnitAbbreviation("dg")]
        [Scale(1e-4f)]
        Decigram = -1,

        [UnitAbbreviation("g")]
        [Scale(1e-3f)]
        Gram = 0,

        [UnitAbbreviation("dag")]
        [Scale(1e-2f)]
        Dekagram = 1,

        [UnitAbbreviation("hg")]
        [Scale(1e-1f)]
        Hectogram = 2,

        [UnitAbbreviation("kg")]
        [Scale(1.0f)]
        Kilogram = 3,

        [UnitAbbreviation("Mg")]
        [Scale(1e3f)]
        Megagram = 6,

        [UnitAbbreviation("Gg")]
        [Scale(1e6f)]
        Gigagram = 9,

        [UnitAbbreviation("Tg")]
        [Scale(1e9f)]
        Teragram = 12,

        [UnitAbbreviation("Pg")]
        [Scale(1e12f)]
        Petagram = 15,

        [UnitAbbreviation("Eg")]
        [Scale(1e15f)]
        Exagram = 18,

        [UnitAbbreviation("Zg")]
        [Scale(1e18f)]
        Zettagram = 21,

        [UnitAbbreviation("Yg")]
        [Scale(1e21f)]
        Yottagram = 24,

        [UnitAbbreviation("CD")]
        [Scale(0.0002f)]
        Carats = 101,

        [UnitAbbreviation("ozt")]
        [Scale(0.0311034768f)]
        OuncesTroy = 102,

        [UnitAbbreviation("lbs")]
        [Scale(0.45359237f)]
        Pounds = 103,

        [UnitAbbreviation("T")]
        [Scale(907.18474f)]
        TonsUS = 104,

        [UnitAbbreviation("t")]
        [Scale(1016.0469088f)]
        TonsUK = 105

    }
}