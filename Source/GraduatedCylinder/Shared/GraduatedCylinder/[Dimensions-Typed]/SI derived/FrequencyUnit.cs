namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Frequency that are currently supported, Hertz is the Base Unit
    /// </summary>
    public enum FrequencyUnit
    {
        /// <summary>
        ///     Hertz, This is the Base Unit
        /// </summary>
        BaseUnit = Hertz,

        /// <summary>
        ///     Hertz, This is the Base Unit
        /// </summary>
        [UnitAbbreviation("Hz")]
        [Scale(1.0)]
        Hertz = 0,

        /// <summary>
        ///     Number of Cycles/Second
        /// </summary>
        [UnitAbbreviation("n/s")]
        [Scale(1.0)]
        NumberOfCyclesPerSecond = 1,

        //MHz
    }
}