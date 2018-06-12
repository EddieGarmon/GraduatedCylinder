using Xunit;

namespace GraduatedCylinder
{
    public class TemperatureConversionsFixture
    {
        [Theory]
        [InlineData(-100, TemperatureUnit.Celsius, -148, TemperatureUnit.Fahrenheit)]
        [InlineData(0, TemperatureUnit.Celsius, 32, TemperatureUnit.Fahrenheit)]
        [InlineData(50, TemperatureUnit.Celsius, 122, TemperatureUnit.Fahrenheit)]
        [InlineData(100, TemperatureUnit.Celsius, 212, TemperatureUnit.Fahrenheit)]
        [InlineData(150, TemperatureUnit.Celsius, 302, TemperatureUnit.Fahrenheit)]
        [InlineData(0, TemperatureUnit.Celsius, 273.15, TemperatureUnit.Kelvin)]
        [InlineData(68, TemperatureUnit.Celsius, 341.15, TemperatureUnit.Kelvin)]
        [InlineData(100, TemperatureUnit.Celsius, 373.15, TemperatureUnit.Kelvin)]
        [InlineData(68, TemperatureUnit.Fahrenheit, 293.15, TemperatureUnit.Kelvin)]
        [InlineData(167, TemperatureUnit.Fahrenheit, 348.15, TemperatureUnit.Kelvin)]
        public void TemperatureConversions(double value1, TemperatureUnit units1, double value2, TemperatureUnit units2) {
            new Temperature(value1, units1) {
                Units = units2
            }.Value.ShouldBeWithinEpsilonOf(value2);
            new Temperature(value2, units2) {
                Units = units1
            }.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}