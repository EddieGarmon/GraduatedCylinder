namespace GraduatedCylinder
{
    public enum NumericUnit
    {
        BaseUnit = Empty,

        [UnitAbbreviation("")]
        [Scale(1.0)]
        Empty = 0,

        [UnitAbbreviation("%")]
        [Scale(0.01)]
        Percent
    }
}