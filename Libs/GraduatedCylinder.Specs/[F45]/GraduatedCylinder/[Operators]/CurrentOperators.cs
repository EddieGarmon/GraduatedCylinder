using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class ElectricCurrentOperators
	{
		[Fact]
		public void OpAddition() {
			Current current1 = new Current(3000, CurrentUnit.Amperes);
			Current current2 = new Current(1, CurrentUnit.KiloAmperes);
			Current expected = new Current(4000, CurrentUnit.Amperes);
			(current1 + current2).ShouldEqual(expected, UnitAndValueComparers.ElectricCurrent);
			expected.Units = CurrentUnit.KiloAmperes;
			(current2 + current1).ShouldEqual(expected, UnitAndValueComparers.ElectricCurrent);
		}

		[Fact]
		public void OpDivision() {
			Current current1 = new Current(2000, CurrentUnit.Amperes);
			Current current2 = new Current(2, CurrentUnit.KiloAmperes);
			(current1 / current2).ShouldBeWithinEpsilonOf(1);
			(current2 / current1).ShouldBeWithinEpsilonOf(1);

			(current1 / 2).ShouldEqual(new Current(1000, CurrentUnit.Amperes));
			(current2 / 2).ShouldEqual(new Current(1, CurrentUnit.KiloAmperes));
		}

		[Fact]
		public void OpEquals() {
			Current current1 = new Current(3000, CurrentUnit.Amperes);
			Current current2 = new Current(3, CurrentUnit.KiloAmperes);
			Current current3 = new Current(6, CurrentUnit.KiloAmperes);
			(current1 == current2).ShouldBeTrue();
			(current2 == current1).ShouldBeTrue();
			(current1 == current3).ShouldBeFalse();
			(current3 == current1).ShouldBeFalse();
			current1.Equals(current2).ShouldBeTrue();
			current1.Equals((object)current2).ShouldBeTrue();
			current2.Equals(current1).ShouldBeTrue();
			current2.Equals((object)current1).ShouldBeTrue();
		}

		[Fact]
		public void OpGreaterThan() {
			Current current1 = new Current(3000, CurrentUnit.Amperes);
			Current current2 = new Current(3, CurrentUnit.KiloAmperes);
			Current current3 = new Current(6, CurrentUnit.KiloAmperes);
			(current1 > current3).ShouldBeFalse();
			(current3 > current1).ShouldBeTrue();
			(current1 > current2).ShouldBeFalse();
			(current2 > current1).ShouldBeFalse();
		}

		[Fact]
		public void OpGreaterThanOrEqual() {
			Current current1 = new Current(3000, CurrentUnit.Amperes);
			Current current2 = new Current(3, CurrentUnit.KiloAmperes);
			Current current3 = new Current(6, CurrentUnit.KiloAmperes);
			(current1 >= current3).ShouldBeFalse();
			(current3 >= current1).ShouldBeTrue();
			(current1 >= current2).ShouldBeTrue();
			(current2 >= current1).ShouldBeTrue();
		}

		[Fact]
		public void OpInverseEquals() {
			Current current1 = new Current(3000, CurrentUnit.Amperes);
			Current current2 = new Current(3, CurrentUnit.KiloAmperes);
			Current current3 = new Current(6, CurrentUnit.KiloAmperes);
			(current1 != current2).ShouldBeFalse();
			(current2 != current1).ShouldBeFalse();
			(current1 != current3).ShouldBeTrue();
			(current3 != current1).ShouldBeTrue();
		}

		[Fact]
		public void OpLessThan() {
			Current current1 = new Current(3000, CurrentUnit.Amperes);
			Current current2 = new Current(3, CurrentUnit.KiloAmperes);
			Current current3 = new Current(6, CurrentUnit.KiloAmperes);
			(current1 < current3).ShouldBeTrue();
			(current3 < current1).ShouldBeFalse();
			(current1 < current2).ShouldBeFalse();
			(current2 < current1).ShouldBeFalse();
		}

		[Fact]
		public void OpLessThanOrEqual() {
			Current current1 = new Current(3000, CurrentUnit.Amperes);
			Current current2 = new Current(3, CurrentUnit.KiloAmperes);
			Current current3 = new Current(6, CurrentUnit.KiloAmperes);
			(current1 <= current3).ShouldBeTrue();
			(current3 <= current1).ShouldBeFalse();
			(current1 <= current2).ShouldBeTrue();
			(current2 <= current1).ShouldBeTrue();
		}

		[Fact]
		public void OpMultiplicationScaler() {
			Current current = new Current(1, CurrentUnit.Amperes);
			Current expected = new Current(2, CurrentUnit.Amperes);
			(current * 2).ShouldEqual(expected, UnitAndValueComparers.ElectricCurrent);
			(2 * current).ShouldEqual(expected, UnitAndValueComparers.ElectricCurrent);
		}

		[Fact]
		public void OpSubtraction() {
			Current current1 = new Current(7000, CurrentUnit.Amperes);
			Current current2 = new Current(1, CurrentUnit.KiloAmperes);
			(current1 - current2).ShouldEqual(new Current(6000, CurrentUnit.Amperes), UnitAndValueComparers.ElectricCurrent);
			(current2 - current1).ShouldEqual(new Current(-6, CurrentUnit.KiloAmperes), UnitAndValueComparers.ElectricCurrent);
		}
	}
}