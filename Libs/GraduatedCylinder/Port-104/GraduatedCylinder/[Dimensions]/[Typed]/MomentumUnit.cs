namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Momentum that are currently supported, Kilograms x Meters/Second is the Base Unit.
    /// </summary>
    public enum MomentumUnit
    {
        /// <summary>
        ///     Kilograms x Meters/Second, This is the Base Unit
        /// </summary>
        BaseUnit = KilogramMetersPerSecond,

        /// <summary>
        ///     Kilograms x Meters/Second, this is the Base Unit
        /// </summary>
        [UnitAbbreviation("kgm/s")]
        [Scale(1.0)]
        KilogramMetersPerSecond = 0,

        /// <summary>
        ///     Grams x Centimeters/Second
        /// </summary>
        [UnitAbbreviation("gcm/s")]
        [Scale(1e-5)]
        GramCentimetersPerSecond = 1,

        /// <summary>
        ///     Kilograms x Meters/Minute
        /// </summary>
        [UnitAbbreviation("kgm/min")]
        [Scale(1.0 / 60.0)]
        KilogramsMetersPerMinute = 2,

        /// <summary>
        ///     Kilograms x Kilometers/Hour
        /// </summary>
        [UnitAbbreviation("kgkm/h")]
        [Scale(1.0 / 3.6)]
        KilogramsKiloMetersPerHour = 3,

        /// <summary>
        ///     Pounds x Miles/Hour
        /// </summary>
        [UnitAbbreviation("lbm/h")]
        [Scale(0.2027739)]
        PoundsMilesPerHour = 4,
    }
}