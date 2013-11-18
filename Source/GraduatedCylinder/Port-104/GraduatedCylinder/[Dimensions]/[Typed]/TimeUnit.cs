namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Time that are currently supported, Seconds is the Base Unit.
    /// </summary>
    public enum TimeUnit
    {
        /// <summary>
        ///     Seconds, This is the Base Unit
        /// </summary>
        BaseUnit = Seconds,

        /// <summary>
        ///     Seconds, this is the Base Unit
        /// </summary>
        [UnitAbbreviation("s")]
        [Scale(1.0)]
        Seconds = 0,

        /// <summary>
        ///     MilliSeconds
        /// </summary>
        [UnitAbbreviation("ms")]
        [Scale(1e-3)]
        MilliSecond = 1,

        /// <summary>
        ///     MicroSeconds
        /// </summary>
        [UnitAbbreviation("µs")]
        [Scale(1e-6)]
        MicroSecond = 2,

        /// <summary>
        ///     Minutes
        /// </summary>
        [UnitAbbreviation("min")]
        [Scale(60.0)]
        Minutes = 3,

        /// <summary>
        ///     Hours
        /// </summary>
        [UnitAbbreviation("h")]
        [Scale(3600.0)]
        Hours = 4,

        /// <summary>
        ///     Days
        /// </summary>
        [UnitAbbreviation("d")]
        [Scale(86400.0)]
        Days = 5,
    }
}