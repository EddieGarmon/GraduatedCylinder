namespace GraduatedCylinder
{
    public enum AngularAccelerationUnit
    {
        //todo: convert to rad/s^2 as the base
        BaseUnit = RevolutionsPerMinutePerSecond,

        [UnitAbbreviation("r/min/s")]
        [Scale(1.0)]
        RevolutionsPerMinutePerSecond = 0,

        [UnitAbbreviation("r/s^2")]
        [Scale(60.0)]
        RevolutionsPerSecondSquared = 1
    }
}