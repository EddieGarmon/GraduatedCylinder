namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Jerk that are currently supported, Meters/Seconds^3 is the Base Unit.
    /// </summary>
    public enum JerkUnit
    {
        /// <summary>
        ///     Meters/Seconds^3, This is the Base Unit
        /// </summary>
        BaseUnit = MetersPerSecondCubed,

        /// <summary>
        ///     Meters/Seconds^3
        /// </summary>
        [UnitAbbreviation("m/s^3")]
        [Scale(1.0)]
        MetersPerSecondCubed = 0,

        /// <summary>
        ///     Kilometers/Seconds^3
        /// </summary>
        [UnitAbbreviation("km/s^3")]
        [Scale(1e3)]
        KiloMetersPerSecondCubed = 1,

        /// <summary>
        ///     Miles/Second^3
        /// </summary>
        [UnitAbbreviation("miles/s^3")]
        [Scale(1609.344)]
        MilesPerSecondCubed = 2,
    }
}