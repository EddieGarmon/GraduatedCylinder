namespace GraduatedCylinder
{
    /// <summary>
    ///     This is a list of all currently supported angular acceleration
    ///     units, Revolutions/Minute/Second is the Base Unit.
    /// </summary>
    public enum AngularAccelerationUnit
    {
        /// <summary>
        ///     Revolutions/Minute/Second, This is the Base Unit
        /// </summary>
        BaseUnit = RevolutionsPerMinutePerSecond,

        /// <summary>
        ///     Revolutions/Minute/Second, This is the Base Unit
        /// </summary>
        [UnitAbbreviation("r/min/s")]
        [Scale(1.0)]
        RevolutionsPerMinutePerSecond = 0,

        /// <summary>
        ///     Revolutions/Second^2
        /// </summary>
        [UnitAbbreviation("r/s^2")]
        [Scale(60.0)]
        RevolutionsPerSecondSquared = 1,
    }
}