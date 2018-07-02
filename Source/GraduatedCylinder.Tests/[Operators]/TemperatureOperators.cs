using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder
{
    public class TemperatureOperators
    {
        [Fact]
        public void OpAddition() {
            var temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
            var temperature2 = new Temperature(20, TemperatureUnit.Celsius);
            var expected = new Temperature(104, TemperatureUnit.Fahrenheit);
            (temperature1 + temperature2).ShouldBe(expected);
            (temperature2 + temperature1).ShouldBe(expected);
        }

        [Fact]
        public void OpDivision() {
            var temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
            var temperature2 = new Temperature(20, TemperatureUnit.Celsius);
            (temperature1 / temperature2).ShouldBeWithinEpsilonOf(1);
            (temperature2 / temperature1).ShouldBeWithinEpsilonOf(1);

            (temperature1 / 2).ShouldBe(new Temperature(50, TemperatureUnit.Fahrenheit));
            (temperature2 / 2).ShouldBe(new Temperature(10, TemperatureUnit.Celsius));
        }

        [Fact]
        public void OpEquals() {
            var temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
            var temperature2 = new Temperature(20, TemperatureUnit.Celsius);
            var temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
            (temperature1 == temperature2).ShouldBeTrue();
            (temperature2 == temperature1).ShouldBeTrue();
            (temperature1 == temperature3).ShouldBeFalse();
            (temperature3 == temperature1).ShouldBeFalse();
            temperature1.Equals(temperature2)
                        .ShouldBeTrue();
            temperature1.Equals((object)temperature2)
                        .ShouldBeTrue();
            temperature2.Equals(temperature1)
                        .ShouldBeTrue();
            temperature2.Equals((object)temperature1)
                        .ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            var temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
            var temperature2 = new Temperature(20, TemperatureUnit.Celsius);
            var temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
            (temperature1 > temperature3).ShouldBeFalse();
            (temperature3 > temperature1).ShouldBeTrue();
            (temperature1 > temperature2).ShouldBeFalse();
            (temperature2 > temperature1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
            var temperature2 = new Temperature(20, TemperatureUnit.Celsius);
            var temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
            (temperature1 >= temperature3).ShouldBeFalse();
            (temperature3 >= temperature1).ShouldBeTrue();
            (temperature1 >= temperature2).ShouldBeTrue();
            (temperature2 >= temperature1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
            var temperature2 = new Temperature(20, TemperatureUnit.Celsius);
            var temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
            (temperature1 != temperature2).ShouldBeFalse();
            (temperature2 != temperature1).ShouldBeFalse();
            (temperature1 != temperature3).ShouldBeTrue();
            (temperature3 != temperature1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
            var temperature2 = new Temperature(20, TemperatureUnit.Celsius);
            var temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
            (temperature1 < temperature3).ShouldBeTrue();
            (temperature3 < temperature1).ShouldBeFalse();
            (temperature1 < temperature2).ShouldBeFalse();
            (temperature2 < temperature1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
            var temperature2 = new Temperature(20, TemperatureUnit.Celsius);
            var temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
            (temperature1 <= temperature3).ShouldBeTrue();
            (temperature3 <= temperature1).ShouldBeFalse();
            (temperature1 <= temperature2).ShouldBeTrue();
            (temperature2 <= temperature1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var temperature = new Temperature(1, TemperatureUnit.Celsius);
            var expected = new Temperature(2, TemperatureUnit.Celsius);
            (temperature * 2).ShouldBe(expected);
            (2 * temperature).ShouldBe(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var temperature1 = new Temperature(104, TemperatureUnit.Fahrenheit);
            var temperature2 = new Temperature(20, TemperatureUnit.Celsius);
            (temperature1 - temperature2).ShouldBe(new Temperature(68, TemperatureUnit.Fahrenheit));
            (temperature2 - temperature1).ShouldBe(new Temperature(-20, TemperatureUnit.Celsius));
        }
    }
}