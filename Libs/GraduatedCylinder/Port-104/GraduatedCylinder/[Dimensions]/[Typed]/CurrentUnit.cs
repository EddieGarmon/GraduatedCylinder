namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Electric Current that are currently supported, Amperes is the Base Unit.
    /// </summary>
    public enum CurrentUnit
    {
        /// <summary>
        ///     Amperes, This is the Base Unit
        /// </summary>
        BaseUnit = Amperes,

        /// <summary>
        ///     Amperes, this is the Base Unit
        /// </summary>
        [UnitAbbreviation("A")]
        [Scale(1.0)]
        Amperes = 0,

        /// <summary>
        ///     MilliAmperes
        /// </summary>
        [UnitAbbreviation("mA")]
        [Scale(1e-3)]
        Milliamperes = 1,

        /// <summary>
        ///     KiloAmperes
        /// </summary>
        [UnitAbbreviation("kA")]
        [Scale(1e3)]
        KiloAmperes = 2,
    }
}