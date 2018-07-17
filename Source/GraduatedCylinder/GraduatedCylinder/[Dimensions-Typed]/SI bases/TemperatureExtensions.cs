namespace GraduatedCylinder
{
    public static class TemperatureExtensions
    {
        public static Temperature Celsius(this double value) {
            return new Temperature(value, TemperatureUnit.Celsius);
        }

        public static Temperature Fahrenheit(this double value) {
            return new Temperature(value, TemperatureUnit.Fahrenheit);
        }

        public static Temperature Kelvin(this double value) {
            return new Temperature(value, TemperatureUnit.Kelvin);
        }
    }
}