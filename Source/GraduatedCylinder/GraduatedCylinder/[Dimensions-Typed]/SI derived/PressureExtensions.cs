namespace GraduatedCylinder
{
    public static class PressureExtensions
    {
        public static Pressure Bars(this double value) {
            return new Pressure(value, PressureUnit.Bars);
        }

        public static Pressure InchesOfMercury(this double value) {
            return new Pressure(value, PressureUnit.InchesOfMercury);
        }

        public static Pressure Pascals(this double value) {
            return new Pressure(value, PressureUnit.Pascals);
        }

        public static Pressure PoundsPerSquareInch(this double value) {
            return new Pressure(value, PressureUnit.PoundsPerSquareInch);
        }
    }
}