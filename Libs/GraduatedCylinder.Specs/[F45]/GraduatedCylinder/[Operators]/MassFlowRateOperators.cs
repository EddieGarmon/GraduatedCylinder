using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class MassFlowRateOperators
	{
		[Fact]
		public void OpAddition() {
			MassFlowRate massFlowRate1 = new MassFlowRate(4000, MassFlowRateUnit.GramsPerSecond);
			MassFlowRate massFlowRate2 = new MassFlowRate(1, MassFlowRateUnit.KilogramsPerSecond);
			MassFlowRate expected = new MassFlowRate(5000, MassFlowRateUnit.GramsPerSecond);
			(massFlowRate1 + massFlowRate2).ShouldEqual(expected, UnitAndValueComparers.MassFlowRate);
			expected.Units = MassFlowRateUnit.KilogramsPerSecond;
			(massFlowRate2 + massFlowRate1).ShouldEqual(expected, UnitAndValueComparers.MassFlowRate);
		}

		[Fact]
		public void OpDivision() {
			MassFlowRate massFlowRate1 = new MassFlowRate(3600, MassFlowRateUnit.GramsPerSecond);
			MassFlowRate massFlowRate2 = new MassFlowRate(3.6, MassFlowRateUnit.KilogramsPerSecond);
			(massFlowRate1 / massFlowRate2).ShouldBeWithinEpsilonOf(1);
			(massFlowRate2 / massFlowRate1).ShouldBeWithinEpsilonOf(1);

			(massFlowRate1 / 2).ShouldEqual(new MassFlowRate(1800, MassFlowRateUnit.GramsPerSecond));
			(massFlowRate2 / 2).ShouldEqual(new MassFlowRate(1.8, MassFlowRateUnit.KilogramsPerSecond));
		}

		[Fact]
		public void OpEquals() {
			MassFlowRate massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
			MassFlowRate massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KilogramsPerSecond);
			MassFlowRate massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KilogramsPerSecond);
			(massFlowRate1 == massFlowRate2).ShouldBeTrue();
			(massFlowRate2 == massFlowRate1).ShouldBeTrue();
			(massFlowRate1 == massFlowRate3).ShouldBeFalse();
			(massFlowRate3 == massFlowRate1).ShouldBeFalse();
			massFlowRate1.Equals(massFlowRate2).ShouldBeTrue();
			massFlowRate1.Equals((object)massFlowRate2).ShouldBeTrue();
			massFlowRate2.Equals(massFlowRate1).ShouldBeTrue();
			massFlowRate2.Equals((object)massFlowRate1).ShouldBeTrue();
		}

		[Fact]
		public void OpGreaterThan() {
			MassFlowRate massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
			MassFlowRate massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KilogramsPerSecond);
			MassFlowRate massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KilogramsPerSecond);
			(massFlowRate1 > massFlowRate3).ShouldBeFalse();
			(massFlowRate3 > massFlowRate1).ShouldBeTrue();
			(massFlowRate1 > massFlowRate2).ShouldBeFalse();
			(massFlowRate2 > massFlowRate1).ShouldBeFalse();
		}

		[Fact]
		public void OpGreaterThanOrEqual() {
			MassFlowRate massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
			MassFlowRate massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KilogramsPerSecond);
			MassFlowRate massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KilogramsPerSecond);
			(massFlowRate1 >= massFlowRate3).ShouldBeFalse();
			(massFlowRate3 >= massFlowRate1).ShouldBeTrue();
			(massFlowRate1 >= massFlowRate2).ShouldBeTrue();
			(massFlowRate2 >= massFlowRate1).ShouldBeTrue();
		}

		[Fact]
		public void OpInverseEquals() {
			MassFlowRate massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
			MassFlowRate massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KilogramsPerSecond);
			MassFlowRate massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KilogramsPerSecond);
			(massFlowRate1 != massFlowRate2).ShouldBeFalse();
			(massFlowRate2 != massFlowRate1).ShouldBeFalse();
			(massFlowRate1 != massFlowRate3).ShouldBeTrue();
			(massFlowRate3 != massFlowRate1).ShouldBeTrue();
		}

		[Fact]
		public void OpLessThan() {
			MassFlowRate massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
			MassFlowRate massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KilogramsPerSecond);
			MassFlowRate massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KilogramsPerSecond);
			(massFlowRate1 < massFlowRate3).ShouldBeTrue();
			(massFlowRate3 < massFlowRate1).ShouldBeFalse();
			(massFlowRate1 < massFlowRate2).ShouldBeFalse();
			(massFlowRate2 < massFlowRate1).ShouldBeFalse();
		}

		[Fact]
		public void OpLessThanOrEqual() {
			MassFlowRate massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
			MassFlowRate massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KilogramsPerSecond);
			MassFlowRate massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KilogramsPerSecond);
			(massFlowRate1 <= massFlowRate3).ShouldBeTrue();
			(massFlowRate3 <= massFlowRate1).ShouldBeFalse();
			(massFlowRate1 <= massFlowRate2).ShouldBeTrue();
			(massFlowRate2 <= massFlowRate1).ShouldBeTrue();
		}

		[Fact]
		public void OpMultiplicationScaler() {
			MassFlowRate massFlowRate = new MassFlowRate(1, MassFlowRateUnit.KilogramsPerSecond);
			MassFlowRate expected = new MassFlowRate(2, MassFlowRateUnit.KilogramsPerSecond);
			(massFlowRate * 2).ShouldEqual(expected, UnitAndValueComparers.MassFlowRate);
			(2 * massFlowRate).ShouldEqual(expected, UnitAndValueComparers.MassFlowRate);
		}

		[Fact]
		public void OpSubtraction() {
			MassFlowRate massFlowRate1 = new MassFlowRate(5000, MassFlowRateUnit.GramsPerSecond);
			MassFlowRate massFlowRate2 = new MassFlowRate(1, MassFlowRateUnit.KilogramsPerSecond);
			(massFlowRate1 - massFlowRate2).ShouldEqual(new MassFlowRate(4000, MassFlowRateUnit.GramsPerSecond), UnitAndValueComparers.MassFlowRate);
			(massFlowRate2 - massFlowRate1).ShouldEqual(new MassFlowRate(-4, MassFlowRateUnit.KilogramsPerSecond), UnitAndValueComparers.MassFlowRate);
		}
	}
}