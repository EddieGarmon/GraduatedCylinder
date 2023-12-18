#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class TemperatureOperators
{

    [Fact]
    public void OpAddition() {
        (new Temperature(20, TemperatureUnit.Celsius) + new Temperature(40, TemperatureUnit.Celsius)).ShouldBe(
            new Temperature(60, TemperatureUnit.Celsius));
    }

    [Fact]
    public void OpDivision() {
        Temperature temperature1 = new(60, TemperatureUnit.Celsius);
        Temperature temperature2 = new(20, TemperatureUnit.Celsius);
        (temperature1 / temperature2).ShouldBeCloseTo(3.0f);
        (temperature2 / temperature1).ShouldBeCloseTo(0.333333333f);

        (temperature1 / 2).ShouldBe(new Temperature(30, TemperatureUnit.Celsius));
        (temperature2 / 2).ShouldBe(new Temperature(10, TemperatureUnit.Celsius));
    }

    [Fact]
    public void OpEquals() {
        Temperature temperature1 = new(68, TemperatureUnit.Fahrenheit);
        Temperature temperature2 = new(20, TemperatureUnit.Celsius);
        Temperature temperature3 = new(104, TemperatureUnit.Fahrenheit);
        (temperature1 == temperature2).ShouldBeTrue();
        (temperature2 == temperature1).ShouldBeTrue();
        (temperature1 == temperature3).ShouldBeFalse();
        (temperature3 == temperature1).ShouldBeFalse();
        temperature1.Equals(temperature2).ShouldBeTrue();
        temperature1.Equals((object)temperature2).ShouldBeTrue();
        temperature2.Equals(temperature1).ShouldBeTrue();
        temperature2.Equals((object)temperature1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        Temperature temperature1 = new(68, TemperatureUnit.Fahrenheit);
        Temperature temperature2 = new(20, TemperatureUnit.Celsius);
        Temperature temperature3 = new(104, TemperatureUnit.Fahrenheit);
        (temperature1 > temperature3).ShouldBeFalse();
        (temperature3 > temperature1).ShouldBeTrue();
        (temperature1 > temperature2).ShouldBeFalse();
        (temperature2 > temperature1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Temperature temperature1 = new(68, TemperatureUnit.Fahrenheit);
        Temperature temperature2 = new(20, TemperatureUnit.Celsius);
        Temperature temperature3 = new(104, TemperatureUnit.Fahrenheit);
        (temperature1 >= temperature3).ShouldBeFalse();
        (temperature3 >= temperature1).ShouldBeTrue();
        (temperature1 >= temperature2).ShouldBeTrue();
        (temperature2 >= temperature1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Temperature temperature1 = new(68, TemperatureUnit.Fahrenheit);
        Temperature temperature2 = new(20, TemperatureUnit.Celsius);
        Temperature temperature3 = new(104, TemperatureUnit.Fahrenheit);
        (temperature1 != temperature2).ShouldBeFalse();
        (temperature2 != temperature1).ShouldBeFalse();
        (temperature1 != temperature3).ShouldBeTrue();
        (temperature3 != temperature1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Temperature temperature1 = new(68, TemperatureUnit.Fahrenheit);
        Temperature temperature2 = new(20, TemperatureUnit.Celsius);
        Temperature temperature3 = new(104, TemperatureUnit.Fahrenheit);
        (temperature1 < temperature3).ShouldBeTrue();
        (temperature3 < temperature1).ShouldBeFalse();
        (temperature1 < temperature2).ShouldBeFalse();
        (temperature2 < temperature1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Temperature temperature1 = new(68, TemperatureUnit.Fahrenheit);
        Temperature temperature2 = new(20, TemperatureUnit.Celsius);
        Temperature temperature3 = new(104, TemperatureUnit.Fahrenheit);
        (temperature1 <= temperature3).ShouldBeTrue();
        (temperature3 <= temperature1).ShouldBeFalse();
        (temperature1 <= temperature2).ShouldBeTrue();
        (temperature2 <= temperature1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Temperature temperature = new(1, TemperatureUnit.Celsius);
        Temperature expected = new(2, TemperatureUnit.Celsius);
        (temperature * 2).ShouldBe(expected);
        (2 * temperature).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Temperature temperature1 = new(100, TemperatureUnit.Fahrenheit);
        Temperature temperature2 = new(20, TemperatureUnit.Fahrenheit);
        (temperature1 - temperature2).ShouldBe(new Temperature(80, TemperatureUnit.Fahrenheit));
    }

}