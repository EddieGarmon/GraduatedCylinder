using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of <see cref="AngularVelocity" /> that are currently supported,
    ///     Revolutions/Minute is the Base Unit.
    /// </summary>
    public enum AngularVelocityUnit
    {
        /// <summary>
        ///     AngularVelocity/Minute, This is the Base Unit
        /// </summary>
        BaseUnit = RevolutionsPerMinute,

        /// <summary>
        ///     AngularVelocity/Minute, this is the Base Unit
        /// </summary>
        [UnitAbbreviation("rpm")]
        //ToDo: Support multiple Abbrev "r/min"
        [Scale(1.0)]
        RevolutionsPerMinute = 0,

        /// <summary>
        ///     AngularVelocity/second
        /// </summary>
        [UnitAbbreviation("r/s")]
        [Scale(60.0)]
        RevolutionsPerSecond = 1,

        /// <summary>
        ///     Hertz
        /// </summary>
        [UnitAbbreviation("Hz")]
        [Scale(60.0)]
        Hertz = 2,

        /// <summary>
        ///     Radians/Second
        /// </summary>
        [UnitAbbreviation("rad/s")]
        [Scale(30 / Math.PI)]
        RadiansPerSecond = 3,
    }
}