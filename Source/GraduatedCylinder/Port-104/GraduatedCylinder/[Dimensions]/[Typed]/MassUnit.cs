namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Mass that are currently supported, Kilograms is the Base Unit.
    /// </summary>
    public enum MassUnit
    {
        /// <summary>
        ///     Kilograms, This is the Base Unit
        /// </summary>
        BaseUnit = Kilograms,

        /// <summary>
        ///     Kilograms, this is the Base Unit
        /// </summary>
        [UnitAbbreviation("kg")]
        [Scale(1.0)]
        Kilograms = 0,

        /// <summary>
        ///     Carats
        /// </summary>
        [UnitAbbreviation("CD")]
        [Scale(0.0002)]
        Carats = 1,

        /// <summary>
        ///     Grams
        /// </summary>
        [UnitAbbreviation("g")]
        [Scale(0.001)]
        Grams = 2,

        /// <summary>
        ///     Troy Ounce
        /// </summary>
        [UnitAbbreviation("ozt")]
        [Scale(0.0311034768)]
        OuncesTroy = 3,

        /// <summary>
        ///     Pounds
        /// </summary>
        [UnitAbbreviation("lbs")]
        [Scale(0.45359237)]
        Pounds = 4,

        /// <summary>
        ///     US Tons
        /// </summary>
        [UnitAbbreviation("T")]
        [Scale(907.18474)]
        TonsUS = 5,

        /// <summary>
        ///     UK Tons
        /// </summary>
        [UnitAbbreviation("t")]
        [Scale(1016.0469088)]
        TonsUK = 6,
    }
}