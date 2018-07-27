namespace GraduatedCylinder
{
    public class PercentGradeAttribute : ScaleDefinitionAttribute
    {
        public override IUnitConverter UnitConverter => new PercentGradeUnitConverter();
    }
}