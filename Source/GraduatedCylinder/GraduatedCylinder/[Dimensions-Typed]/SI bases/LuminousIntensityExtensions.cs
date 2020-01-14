namespace GraduatedCylinder
{
    public static class LuminousIntensityExtensions
    {
        public static LuminousIntensity Candelas(this double value) {
            return new LuminousIntensity(value, LuminousIntensityUnit.Candela);
        }
    }
}