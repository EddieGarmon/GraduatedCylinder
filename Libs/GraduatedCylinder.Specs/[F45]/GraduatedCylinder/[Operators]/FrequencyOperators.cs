using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class FrequencyOperators
	{
		[Fact]
		public void OpAddition() {
			Frequency frequency1 = new Frequency(1, FrequencyUnit.Hertz);
			Frequency frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
			Frequency expected = new Frequency(2, FrequencyUnit.Hertz);
			(frequency1 + frequency2).ShouldEqual(expected, UnitAndValueComparers.Frequency);
			expected.Units = FrequencyUnit.NumberOfCyclesPerSecond;
			(frequency2 + frequency1).ShouldEqual(expected, UnitAndValueComparers.Frequency);
		}

		[Fact]
		public void OpDivision() {
			Frequency frequency1 = new Frequency(2, FrequencyUnit.Hertz);
			Frequency frequency2 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
			(frequency1 / frequency2).ShouldBeWithinEpsilonOf(1);
			(frequency2 / frequency1).ShouldBeWithinEpsilonOf(1);

			(frequency1 / 2).ShouldEqual(new Frequency(1, FrequencyUnit.Hertz));
			(frequency2 / 2).ShouldEqual(new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond));
		}

		[Fact]
		public void OpEquals() {
			Frequency frequency1 = new Frequency(1, FrequencyUnit.Hertz);
			Frequency frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
			Frequency frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
			(frequency1 == frequency2).ShouldBeTrue();
			(frequency2 == frequency1).ShouldBeTrue();
			(frequency1 == frequency3).ShouldBeFalse();
			(frequency3 == frequency1).ShouldBeFalse();
			frequency1.Equals(frequency2).ShouldBeTrue();
			frequency1.Equals((object)frequency2).ShouldBeTrue();
			frequency2.Equals(frequency1).ShouldBeTrue();
			frequency2.Equals((object)frequency1).ShouldBeTrue();
		}

		[Fact]
		public void OpGreaterThan() {
			Frequency frequency1 = new Frequency(1, FrequencyUnit.Hertz);
			Frequency frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
			Frequency frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
			(frequency1 > frequency3).ShouldBeFalse();
			(frequency3 > frequency1).ShouldBeTrue();
			(frequency1 > frequency2).ShouldBeFalse();
			(frequency2 > frequency1).ShouldBeFalse();
		}

		[Fact]
		public void OpGreaterThanOrEqual() {
			Frequency frequency1 = new Frequency(1, FrequencyUnit.Hertz);
			Frequency frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
			Frequency frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
			(frequency1 >= frequency3).ShouldBeFalse();
			(frequency3 >= frequency1).ShouldBeTrue();
			(frequency1 >= frequency2).ShouldBeTrue();
			(frequency2 >= frequency1).ShouldBeTrue();
		}

		[Fact]
		public void OpInverseEquals() {
			Frequency frequency1 = new Frequency(1, FrequencyUnit.Hertz);
			Frequency frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
			Frequency frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
			(frequency1 != frequency2).ShouldBeFalse();
			(frequency2 != frequency1).ShouldBeFalse();
			(frequency1 != frequency3).ShouldBeTrue();
			(frequency3 != frequency1).ShouldBeTrue();
		}

		[Fact]
		public void OpLessThan() {
			Frequency frequency1 = new Frequency(1, FrequencyUnit.Hertz);
			Frequency frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
			Frequency frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
			(frequency1 < frequency3).ShouldBeTrue();
			(frequency3 < frequency1).ShouldBeFalse();
			(frequency1 < frequency2).ShouldBeFalse();
			(frequency2 < frequency1).ShouldBeFalse();
		}

		[Fact]
		public void OpLessThanOrEqual() {
			Frequency frequency1 = new Frequency(1, FrequencyUnit.Hertz);
			Frequency frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
			Frequency frequency3 = new Frequency(2, FrequencyUnit.NumberOfCyclesPerSecond);
			(frequency1 <= frequency3).ShouldBeTrue();
			(frequency3 <= frequency1).ShouldBeFalse();
			(frequency1 <= frequency2).ShouldBeTrue();
			(frequency2 <= frequency1).ShouldBeTrue();
		}

		[Fact]
		public void OpMultiplicationScaler() {
			Frequency frequency = new Frequency(1, FrequencyUnit.Hertz);
			Frequency expected = new Frequency(2, FrequencyUnit.Hertz);
			(frequency * 2).ShouldEqual(expected, UnitAndValueComparers.Frequency);
			(2 * frequency).ShouldEqual(expected, UnitAndValueComparers.Frequency);
		}

		[Fact]
		public void OpSubtraction() {
			Frequency frequency1 = new Frequency(10, FrequencyUnit.Hertz);
			Frequency frequency2 = new Frequency(1, FrequencyUnit.NumberOfCyclesPerSecond);
			(frequency1 - frequency2).ShouldEqual(new Frequency(9, FrequencyUnit.Hertz), UnitAndValueComparers.Frequency);
			(frequency2 - frequency1).ShouldEqual(new Frequency(-9, FrequencyUnit.NumberOfCyclesPerSecond), UnitAndValueComparers.Frequency);
		}
	}
}