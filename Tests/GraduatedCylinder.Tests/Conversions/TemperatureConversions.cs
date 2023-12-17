using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class TemperatureConversions(ITestOutputHelper output) : ConversionTestBase(output)
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
    public void Conversions(double value1, TemperatureUnit units1, double value2, TemperatureUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Temperature(value, unit));
    }

}