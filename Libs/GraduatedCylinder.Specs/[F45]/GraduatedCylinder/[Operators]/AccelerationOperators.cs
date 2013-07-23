using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class AccelerationOperators
	{
		[Fact]
		public void OpAddition() {
			Acceleration acceleration1 = new Acceleration(3600, AccelerationUnit.MetersPerSecondSquared);
			Acceleration acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometersPerSecondSquared);
			Acceleration expected = new Acceleration(7200, AccelerationUnit.MetersPerSecondSquared);
			(acceleration1 + acceleration2).ShouldEqual(expected, UnitAndValueComparers.Acceleration);
			expected.Units = AccelerationUnit.KilometersPerSecondSquared;
			(acceleration2 + acceleration1).ShouldEqual(expected, UnitAndValueComparers.Acceleration);
		}

		[Fact]
		public void OpDivision() {
			Acceleration acceleration1 = new Acceleration(3600, AccelerationUnit.MetersPerSecondSquared);
			Acceleration acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometersPerSecondSquared);
			(acceleration1 / acceleration2).ShouldBeWithinEpsilonOf(1);
			(acceleration2 / acceleration1).ShouldBeWithinEpsilonOf(1);

			(acceleration1 / 2).ShouldEqual(new Acceleration(1800, AccelerationUnit.MetersPerSecondSquared));
			(acceleration2 / 2).ShouldEqual(new Acceleration(1.8, AccelerationUnit.KilometersPerSecondSquared));
		}

		[Fact]
		public void OpEquals() {
			Acceleration acceleration1 = new Acceleration(3600, AccelerationUnit.MetersPerSecondSquared);
			Acceleration acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometersPerSecondSquared);
			Acceleration acceleration3 = new Acceleration(1200, AccelerationUnit.MetersPerSecondSquared);
			(acceleration1 == acceleration2).ShouldBeTrue();
			(acceleration2 == acceleration1).ShouldBeTrue();
			(acceleration1 == acceleration3).ShouldBeFalse();
			(acceleration3 == acceleration1).ShouldBeFalse();
			acceleration1.Equals(acceleration2).ShouldBeTrue();
			acceleration1.Equals((object)acceleration2).ShouldBeTrue();
			acceleration2.Equals(acceleration1).ShouldBeTrue();
			acceleration2.Equals((object)acceleration1).ShouldBeTrue();
		}

		[Fact]
		public void OpGreaterThan() {
			Acceleration acceleration1 = new Acceleration(3600, AccelerationUnit.MetersPerSecondSquared);
			Acceleration acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometersPerSecondSquared);
			Acceleration acceleration3 = new Acceleration(4500, AccelerationUnit.MetersPerSecondSquared);
			(acceleration1 > acceleration3).ShouldBeFalse();
			(acceleration3 > acceleration1).ShouldBeTrue();
			(acceleration1 > acceleration2).ShouldBeFalse();
			(acceleration2 > acceleration1).ShouldBeFalse();
		}

		[Fact]
		public void OpGreaterThanOrEqual() {
			Acceleration acceleration1 = new Acceleration(3600, AccelerationUnit.MetersPerSecondSquared);
			Acceleration acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometersPerSecondSquared);
			Acceleration acceleration3 = new Acceleration(4500, AccelerationUnit.MetersPerSecondSquared);
			(acceleration1 >= acceleration3).ShouldBeFalse();
			(acceleration3 >= acceleration1).ShouldBeTrue();
			(acceleration1 >= acceleration2).ShouldBeTrue();
			(acceleration2 >= acceleration1).ShouldBeTrue();
		}

		[Fact]
		public void OpInverseEquals() {
			Acceleration acceleration1 = new Acceleration(3600, AccelerationUnit.MetersPerSecondSquared);
			Acceleration acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometersPerSecondSquared);
			Acceleration acceleration3 = new Acceleration(4500, AccelerationUnit.MetersPerSecondSquared);
			(acceleration1 != acceleration2).ShouldBeFalse();
			(acceleration2 != acceleration1).ShouldBeFalse();
			(acceleration1 != acceleration3).ShouldBeTrue();
			(acceleration3 != acceleration1).ShouldBeTrue();
		}

		[Fact]
		public void OpLessThan() {
			Acceleration acceleration1 = new Acceleration(3600, AccelerationUnit.MetersPerSecondSquared);
			Acceleration acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometersPerSecondSquared);
			Acceleration acceleration3 = new Acceleration(4500, AccelerationUnit.MetersPerSecondSquared);
			(acceleration1 < acceleration3).ShouldBeTrue();
			(acceleration3 < acceleration1).ShouldBeFalse();
			(acceleration1 < acceleration2).ShouldBeFalse();
			(acceleration2 < acceleration1).ShouldBeFalse();
		}

		[Fact]
		public void OpLessThanOrEqual() {
			Acceleration acceleration1 = new Acceleration(3600, AccelerationUnit.MetersPerSecondSquared);
			Acceleration acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometersPerSecondSquared);
			Acceleration acceleration3 = new Acceleration(4500, AccelerationUnit.MetersPerSecondSquared);
			(acceleration1 <= acceleration3).ShouldBeTrue();
			(acceleration3 <= acceleration1).ShouldBeFalse();
			(acceleration1 <= acceleration2).ShouldBeTrue();
			(acceleration2 <= acceleration1).ShouldBeTrue();
		}

		[Fact]
		public void OpMultiplicationScaler() {
			Acceleration acceleration = new Acceleration(1, AccelerationUnit.MetersPerSecondSquared);
			Acceleration expected = new Acceleration(2, AccelerationUnit.MetersPerSecondSquared);
			(acceleration * 2).ShouldEqual(expected, UnitAndValueComparers.Acceleration);
			(2 * acceleration).ShouldEqual(expected, UnitAndValueComparers.Acceleration);
		}

		[Fact]
		public void OpSubtraction() {
			Acceleration acceleration1 = new Acceleration(7200, AccelerationUnit.MetersPerSecondSquared);
			Acceleration acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometersPerSecondSquared);
			(acceleration1 - acceleration2).ShouldEqual(new Acceleration(3600, AccelerationUnit.MetersPerSecondSquared),
														UnitAndValueComparers.Acceleration);
			(acceleration2 - acceleration1).ShouldEqual(new Acceleration(-3.6, AccelerationUnit.KilometersPerSecondSquared),
														UnitAndValueComparers.Acceleration);
		}
	}
}