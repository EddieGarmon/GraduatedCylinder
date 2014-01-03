using System;

namespace GraduatedCylinder
{
    public enum AngularVelocityUnit
    {
        //todo: convert to rad/s as the base.
        BaseUnit = RevolutionsPerMinute,

        [UnitAbbreviation("rpm")]
        [Scale(1.0)]
        RevolutionsPerMinute = 0,

        [UnitAbbreviation("r/s")]
        [Scale(60.0)]
        RevolutionsPerSecond = 1,

        [UnitAbbreviation("Hz")]
        [Scale(60.0)]
        Hertz = 2,

        [UnitAbbreviation("rad/s")]
        [Scale(30 / Math.PI)]
        RadiansPerSecond = 3

        //deg/s
    }
}