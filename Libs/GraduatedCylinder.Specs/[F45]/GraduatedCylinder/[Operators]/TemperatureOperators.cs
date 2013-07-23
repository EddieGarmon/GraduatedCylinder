using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class TemperatureOperators
	{
		[Fact]
		public void OpAddition() {
			Temperature temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
			Temperature temperature2 = new Temperature(20, TemperatureUnit.Celsius);
			Temperature expected = new Temperature(104, TemperatureUnit.Fahrenheit);
			(temperature1 + temperature2).ShouldEqual(expected, UnitAndValueComparers.Temperature);
			expected.Units = TemperatureUnit.Celsius;
			(temperature2 + temperature1).ShouldEqual(expected, UnitAndValueComparers.Temperature);
		}

		[Fact]
		public void OpDivision() {
			Temperature temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
			Temperature temperature2 = new Temperature(20, TemperatureUnit.Celsius);
			(temperature1 / temperature2).ShouldBeWithinEpsilonOf(1);
			(temperature2 / temperature1).ShouldBeWithinEpsilonOf(1);

			(temperature1 / 2).ShouldEqual(new Temperature(50, TemperatureUnit.Fahrenheit));
			(temperature2 / 2).ShouldEqual(new Temperature(10, TemperatureUnit.Celsius));
		}

		[Fact]
		public void OpEquals() {
			Temperature temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
			Temperature temperature2 = new Temperature(20, TemperatureUnit.Celsius);
			Temperature temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
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
			Temperature temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
			Temperature temperature2 = new Temperature(20, TemperatureUnit.Celsius);
			Temperature temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
			(temperature1 > temperature3).ShouldBeFalse();
			(temperature3 > temperature1).ShouldBeTrue();
			(temperature1 > temperature2).ShouldBeFalse();
			(temperature2 > temperature1).ShouldBeFalse();
		}

		[Fact]
		public void OpGreaterThanOrEqual() {
			Temperature temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
			Temperature temperature2 = new Temperature(20, TemperatureUnit.Celsius);
			Temperature temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
			(temperature1 >= temperature3).ShouldBeFalse();
			(temperature3 >= temperature1).ShouldBeTrue();
			(temperature1 >= temperature2).ShouldBeTrue();
			(temperature2 >= temperature1).ShouldBeTrue();
		}

		[Fact]
		public void OpInverseEquals() {
			Temperature temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
			Temperature temperature2 = new Temperature(20, TemperatureUnit.Celsius);
			Temperature temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
			(temperature1 != temperature2).ShouldBeFalse();
			(temperature2 != temperature1).ShouldBeFalse();
			(temperature1 != temperature3).ShouldBeTrue();
			(temperature3 != temperature1).ShouldBeTrue();
		}

		[Fact]
		public void OpLessThan() {
			Temperature temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
			Temperature temperature2 = new Temperature(20, TemperatureUnit.Celsius);
			Temperature temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
			(temperature1 < temperature3).ShouldBeTrue();
			(temperature3 < temperature1).ShouldBeFalse();
			(temperature1 < temperature2).ShouldBeFalse();
			(temperature2 < temperature1).ShouldBeFalse();
		}

		[Fact]
		public void OpLessThanOrEqual() {
			Temperature temperature1 = new Temperature(68, TemperatureUnit.Fahrenheit);
			Temperature temperature2 = new Temperature(20, TemperatureUnit.Celsius);
			Temperature temperature3 = new Temperature(104, TemperatureUnit.Fahrenheit);
			(temperature1 <= temperature3).ShouldBeTrue();
			(temperature3 <= temperature1).ShouldBeFalse();
			(temperature1 <= temperature2).ShouldBeTrue();
			(temperature2 <= temperature1).ShouldBeTrue();
		}

		[Fact]
		public void OpMultiplicationScaler() {
			Temperature temperature = new Temperature(1, TemperatureUnit.Celsius);
			Temperature expected = new Temperature(2, TemperatureUnit.Celsius);
			(temperature * 2).ShouldEqual(expected, UnitAndValueComparers.Temperature);
			(2 * temperature).ShouldEqual(expected, UnitAndValueComparers.Temperature);
		}

		[Fact]
		public void OpSubtraction() {
			Temperature temperature1 = new Temperature(104, TemperatureUnit.Fahrenheit);
			Temperature temperature2 = new Temperature(20, TemperatureUnit.Celsius);
			(temperature1 - temperature2).ShouldEqual(new Temperature(68, TemperatureUnit.Fahrenheit), UnitAndValueComparers.Temperature);
			(temperature2 - temperature1).ShouldEqual(new Temperature(-20, TemperatureUnit.Celsius), UnitAndValueComparers.Temperature);
		}
	}
}