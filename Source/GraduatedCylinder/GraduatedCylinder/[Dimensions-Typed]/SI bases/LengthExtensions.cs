namespace GraduatedCylinder
{
    public static class LengthExtensions
    {
        public static Length Feet(this double value) {
            return new Length(value, LengthUnit.Foot);
        }

        public static Length Inches(this double value) {
            return new Length(value, LengthUnit.Inch);
        }

        public static Length Kilometers(this double value) {
            return new Length(value, LengthUnit.Kilometer);
        }

        public static Length Meters(this double value) {
            return new Length(value, LengthUnit.Meter);
        }

        public static Length Miles(this double value) {
            return new Length(value, LengthUnit.Mile);
        }

        public static Length Yards(this double value) {
            return new Length(value, LengthUnit.Yard);
        }
    }
}