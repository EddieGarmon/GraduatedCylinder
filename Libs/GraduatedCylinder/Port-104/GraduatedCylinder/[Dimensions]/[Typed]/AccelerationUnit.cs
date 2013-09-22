namespace GraduatedCylinder
{
    /// <summary>
    ///     This is a list of all currently supported acceleration units, Meters/Second^2 is the Base Unit .
    /// </summary>
    public enum AccelerationUnit
    {
        /// <summary>
        ///     Meters/Second^2, This is the Base Unit
        /// </summary>
        BaseUnit = MetersPerSecondSquared,

        /// <summary>
        ///     Meters/Second^2, This is the Base Unit
        /// </summary>
        [UnitAbbreviation("m/s^2")]
        [Scale(1.0)]
        MetersPerSecondSquared = 0,

        /// <summary>
        ///     Kilometers/Hour/Second
        /// </summary>
        [UnitAbbreviation("km/h/s")]
        [Scale(1.0 / 3.6)]
        KilometersPerHourPerSecond = 1,

        /// <summary>
        ///     Miles/Hour/Second
        /// </summary>
        [UnitAbbreviation("mph/s")]
        [Scale(0.44704)]
        MilesPerHourPerSecond = 2,

        /// <summary>
        ///     Kilometers/Second^2
        /// </summary>
        [UnitAbbreviation("km/s^2")]
        [Scale(1e3)]
        KilometersPerSecondSquared = 3,
    }
}