using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum AngularAccelerationUnit : short
    {

        Unspecified = short.MinValue,

        //todo: convert to rad/s^2 as the base
        BaseUnit = RevolutionsPerMinutePerSecond,

        [UnitAbbreviation("r/min/s")]
        [Scale(1.0f)]
        RevolutionsPerMinutePerSecond = 0,

        [UnitAbbreviation("r/s^2")]
        [Scale(60.0f)]
        RevolutionsPerSecondSquared = 1

    }
}