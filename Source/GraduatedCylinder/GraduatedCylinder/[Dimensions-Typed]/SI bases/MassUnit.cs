namespace GraduatedCylinder
{
    /// <summary>
    /// One of the seven SI base quantities.
    /// </summary>
    public enum MassUnit
    {
        BaseUnit = Kilogram,

        [UnitAbbreviation("yg")]
        [Scale(1e-27)]
        Yoctogram = -24,

        [UnitAbbreviation("zg")]
        [Scale(1e-24)]
        Zeptogram = -21,

        [UnitAbbreviation("ag")]
        [Scale(1e-21)]
        Attogram = -18,

        [UnitAbbreviation("fg")]
        [Scale(1e-18)]
        Femtogram = -15,

        [UnitAbbreviation("pg")]
        [Scale(1e-15)]
        Picogram = -12,

        [UnitAbbreviation("ng")]
        [Scale(1e-12)]
        Nanogram = -9,

        [UnitAbbreviation("µg")]
        [Scale(1e-9)]
        Microgram = -6,

        [UnitAbbreviation("mg")]
        [Scale(1e-6)]
        Milligram = -3,

        [UnitAbbreviation("cg")]
        [Scale(1e-5)]
        Centigram = -2,

        [UnitAbbreviation("dg")]
        [Scale(1e-4)]
        Decigram = -1,

        [UnitAbbreviation("g")]
        [Scale(1e-3)]
        Gram = 0,

        [UnitAbbreviation("dag")]
        [Scale(1e-2)]
        Dekagram = 1,

        [UnitAbbreviation("hg")]
        [Scale(1e-1)]
        Hectogram = 2,

        /// <summary>
        /// This is the Base Unit
        /// </summary>
        [UnitAbbreviation("kg")]
        [Scale(1.0)]
        Kilogram = 3,

        [UnitAbbreviation("Mg")]
        [Scale(1e3)]
        Megagram = 6,

        [UnitAbbreviation("Gg")]
        [Scale(1e6)]
        Gigagram = 9,

        [UnitAbbreviation("Tg")]
        [Scale(1e9)]
        Teragram = 12,

        [UnitAbbreviation("Pg")]
        [Scale(1e12)]
        Petagram = 15,

        [UnitAbbreviation("Eg")]
        [Scale(1e15)]
        Exagram = 18,

        [UnitAbbreviation("Zg")]
        [Scale(1e18)]
        Zettagram = 21,

        [UnitAbbreviation("Yg")]
        [Scale(1e21)]
        Yottagram = 24,

        [UnitAbbreviation("CD")]
        [Scale(0.0002)]
        Carats = 101,

        [UnitAbbreviation("ozt")]
        [Scale(0.0311034768)]
        OuncesTroy = 102,

        [UnitAbbreviation("lbs")]
        [Scale(0.45359237)]
        Pounds = 103,

        [UnitAbbreviation("T")]
        [Scale(907.18474)]
        TonsUS = 104,

        [UnitAbbreviation("t")]
        [Scale(1016.0469088)]
        TonsUK = 105
    }
}