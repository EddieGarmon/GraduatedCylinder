namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Volumetric Flow Rate that are currently supported, Liters/Second is the Base Unit.
    /// </summary>
    public enum VolumetricFlowRateUnit
    {
        /// <summary>
        ///     Liters/Second, This is the Base Unit
        /// </summary>
        BaseUnit = LitersPerSecond,

        /// <summary>
        ///     Liters/Second, this is the Base Unit
        /// </summary>
        [UnitAbbreviation("L/s")]
        [Scale(1.0)]
        LitersPerSecond = 0,

        /// <summary>
        ///     Liters/Minute
        /// </summary>
        [UnitAbbreviation("L/min")]
        [Scale(1.0 / 60.0)]
        LitersPerMinute = 1,

        /// <summary>
        ///     Liters/Hour
        /// </summary>
        [UnitAbbreviation("L/h")]
        [Scale(1.0 / 3600.0)]
        LitersPerHour = 2,

        /// <summary>
        ///     Meters^3/Second
        /// </summary>
        [UnitAbbreviation("m^3/s")]
        [Scale(1e3)]
        CubicMetersPerSecond = 3,

        /// <summary>
        ///     US Gallons/Second
        /// </summary>
        [UnitAbbreviation("gal/s")]
        [Scale(3.785411784)]
        GallonsUsPerSecond = 4,

        /// <summary>
        ///     US Gallons/Hour
        /// </summary>
        [UnitAbbreviation("gal/h")]
        [Scale(3.785411784 / 3600.0)]
        GallonsUsPerHour = 5
    }
}