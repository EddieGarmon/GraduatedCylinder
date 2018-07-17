namespace GraduatedCylinder
{
    public static class FrequencyExtensions
    {
        public static Frequency Gigahertz(this double value) {
            return new Frequency(value, FrequencyUnit.Gigahertz);
        }

        public static Frequency Hertz(this double value) {
            return new Frequency(value, FrequencyUnit.Hertz);
        }

        public static Frequency Megahertz(this double value) {
            return new Frequency(value, FrequencyUnit.Megahertz);
        }

        public static Frequency RadiansPerSecond(this double value) {
            return new Frequency(value, FrequencyUnit.RadiansPerSecond);
        }

        public static Frequency RevolutionsPerMinute(this double value) {
            return new Frequency(value, FrequencyUnit.RevolutionsPerMinute);
        }
    }
}