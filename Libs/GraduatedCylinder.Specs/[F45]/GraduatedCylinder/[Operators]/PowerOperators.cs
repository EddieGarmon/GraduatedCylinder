using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class PowerOperators
	{
		[Fact]
		public void OpAddition() {
			Power power1 = new Power(6000, PowerUnit.Watts);
			Power power2 = new Power(1, PowerUnit.Kilowatts);
			Power expected = new Power(7000, PowerUnit.Watts);
			(power1 + power2).ShouldEqual(expected, UnitAndValueComparers.Power);
			expected.Units = PowerUnit.Kilowatts;
			(power2 + power1).ShouldEqual(expected, UnitAndValueComparers.Power);
		}

		[Fact]
		public void OpDivision() {
			Power power1 = new Power(2000, PowerUnit.Watts);
			Power power2 = new Power(2, PowerUnit.Kilowatts);
			(power1 / power2).ShouldBeWithinEpsilonOf(1);
			(power2 / power1).ShouldBeWithinEpsilonOf(1);

			(power1 / 2).ShouldEqual(new Power(1000, PowerUnit.Watts));
			(power2 / 2).ShouldEqual(new Power(1, PowerUnit.Kilowatts));
		}

		[Fact]
		public void OpEquals() {
			Power power1 = new Power(3000, PowerUnit.Watts);
			Power power2 = new Power(3, PowerUnit.Kilowatts);
			Power power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
			(power1 == power2).ShouldBeTrue();
			(power2 == power1).ShouldBeTrue();
			(power1 == power3).ShouldBeFalse();
			(power3 == power1).ShouldBeFalse();
			power1.Equals(power2).ShouldBeTrue();
			power1.Equals((object)power2).ShouldBeTrue();
			power2.Equals(power1).ShouldBeTrue();
			power2.Equals((object)power1).ShouldBeTrue();
		}

		[Fact]
		public void OpGreaterThan() {
			Power power1 = new Power(3000, PowerUnit.Watts);
			Power power2 = new Power(3, PowerUnit.Kilowatts);
			Power power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
			(power1 > power3).ShouldBeFalse();
			(power3 > power1).ShouldBeTrue();
			(power1 > power2).ShouldBeFalse();
			(power2 > power1).ShouldBeFalse();
		}

		[Fact]
		public void OpGreaterThanOrEqual() {
			Power power1 = new Power(3000, PowerUnit.Watts);
			Power power2 = new Power(3, PowerUnit.Kilowatts);
			Power power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
			(power1 >= power3).ShouldBeFalse();
			(power3 >= power1).ShouldBeTrue();
			(power1 >= power2).ShouldBeTrue();
			(power2 >= power1).ShouldBeTrue();
		}

		[Fact]
		public void OpInverseEquals() {
			Power power1 = new Power(3000, PowerUnit.Watts);
			Power power2 = new Power(3, PowerUnit.Kilowatts);
			Power power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
			(power1 != power2).ShouldBeFalse();
			(power2 != power1).ShouldBeFalse();
			(power1 != power3).ShouldBeTrue();
			(power3 != power1).ShouldBeTrue();
		}

		[Fact]
		public void OpLessThan() {
			Power power1 = new Power(3000, PowerUnit.Watts);
			Power power2 = new Power(3, PowerUnit.Kilowatts);
			Power power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
			(power1 < power3).ShouldBeTrue();
			(power3 < power1).ShouldBeFalse();
			(power1 < power2).ShouldBeFalse();
			(power2 < power1).ShouldBeFalse();
		}

		[Fact]
		public void OpLessThanOrEqual() {
			Power power1 = new Power(3000, PowerUnit.Watts);
			Power power2 = new Power(3, PowerUnit.Kilowatts);
			Power power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
			(power1 <= power3).ShouldBeTrue();
			(power3 <= power1).ShouldBeFalse();
			(power1 <= power2).ShouldBeTrue();
			(power2 <= power1).ShouldBeTrue();
		}

		[Fact]
		public void OpMultiplicationScaler() {
			Power power = new Power(1, PowerUnit.Kilowatts);
			Power expected = new Power(2, PowerUnit.Kilowatts);
			(power * 2).ShouldEqual(expected, UnitAndValueComparers.Power);
			(2 * power).ShouldEqual(expected, UnitAndValueComparers.Power);
		}

		[Fact]
		public void OpSubtraction() {
			Power power1 = new Power(5000, PowerUnit.Watts);
			Power power2 = new Power(1, PowerUnit.Kilowatts);
			(power1 - power2).ShouldEqual(new Power(4000, PowerUnit.Watts), UnitAndValueComparers.Power);
			(power2 - power1).ShouldEqual(new Power(-4, PowerUnit.Kilowatts), UnitAndValueComparers.Power);
		}
	}
}