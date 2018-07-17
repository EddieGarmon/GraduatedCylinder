namespace GraduatedCylinder
{
    public static class AmountOfSubstanceExtensions
    {
        public static AmountOfSubstance Moles(this double value) {
            return new AmountOfSubstance(value, AmountOfSubstanceUnit.Mole);
        }
    }
}