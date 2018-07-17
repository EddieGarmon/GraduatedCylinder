namespace GraduatedCylinder
{
    public static class AngleExtensions
    {
        public static Angle Degrees(this double value) {
            return new Angle(value, AngleUnit.Degree);
        }

        public static Angle Grads(this double value) {
            return new Angle(value, AngleUnit.Grad);
        }

        public static Angle Radians(this double value) {
            return new Angle(value, AngleUnit.Radian);
        }
    }
}