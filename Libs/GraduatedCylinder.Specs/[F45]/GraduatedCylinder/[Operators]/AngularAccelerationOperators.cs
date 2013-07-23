using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class AngularAngularAccelerationOperators
	{
		[Fact]
		public void OpAddition() {
			AngularAcceleration angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			AngularAcceleration angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			AngularAcceleration expected = new AngularAcceleration(120, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			(angularAcceleration1 + angularAcceleration2).ShouldEqual(expected, UnitAndValueComparers.AngularAcceleration);
			expected.Units = AngularAccelerationUnit.RevolutionsPerSecondSquared;
			(angularAcceleration2 + angularAcceleration1).ShouldEqual(expected, UnitAndValueComparers.AngularAcceleration);
		}

		[Fact]
		public void OpDivision() {
			AngularAcceleration angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			AngularAcceleration angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			(angularAcceleration1 / angularAcceleration2).ShouldBeWithinEpsilonOf(1);
			(angularAcceleration2 / angularAcceleration1).ShouldBeWithinEpsilonOf(1);

			(angularAcceleration1 / 2).ShouldEqual(new AngularAcceleration(30, AngularAccelerationUnit.RevolutionsPerMinutePerSecond));
			(angularAcceleration2 / 2).ShouldEqual(new AngularAcceleration(.5, AngularAccelerationUnit.RevolutionsPerSecondSquared));
		}

		[Fact]
		public void OpEquals() {
			AngularAcceleration angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			AngularAcceleration angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			AngularAcceleration angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			(angularAcceleration1 == angularAcceleration2).ShouldBeTrue();
			(angularAcceleration2 == angularAcceleration1).ShouldBeTrue();
			(angularAcceleration1 == angularAcceleration3).ShouldBeFalse();
			(angularAcceleration3 == angularAcceleration1).ShouldBeFalse();
			angularAcceleration1.Equals(angularAcceleration2).ShouldBeTrue();
			angularAcceleration1.Equals((object)angularAcceleration2).ShouldBeTrue();
			angularAcceleration2.Equals(angularAcceleration1).ShouldBeTrue();
			angularAcceleration2.Equals((object)angularAcceleration1).ShouldBeTrue();
		}

		[Fact]
		public void OpGreaterThan() {
			AngularAcceleration angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			AngularAcceleration angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			AngularAcceleration angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			(angularAcceleration1 > angularAcceleration3).ShouldBeFalse();
			(angularAcceleration3 > angularAcceleration1).ShouldBeTrue();
			(angularAcceleration1 > angularAcceleration2).ShouldBeFalse();
			(angularAcceleration2 > angularAcceleration1).ShouldBeFalse();
		}

		[Fact]
		public void OpGreaterThanOrEqual() {
			AngularAcceleration angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			AngularAcceleration angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			AngularAcceleration angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			(angularAcceleration1 >= angularAcceleration3).ShouldBeFalse();
			(angularAcceleration3 >= angularAcceleration1).ShouldBeTrue();
			(angularAcceleration1 >= angularAcceleration2).ShouldBeTrue();
			(angularAcceleration2 >= angularAcceleration1).ShouldBeTrue();
		}

		[Fact]
		public void OpInverseEquals() {
			AngularAcceleration angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			AngularAcceleration angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			AngularAcceleration angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			(angularAcceleration1 != angularAcceleration2).ShouldBeFalse();
			(angularAcceleration2 != angularAcceleration1).ShouldBeFalse();
			(angularAcceleration1 != angularAcceleration3).ShouldBeTrue();
			(angularAcceleration3 != angularAcceleration1).ShouldBeTrue();
		}

		[Fact]
		public void OpLessThan() {
			AngularAcceleration angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			AngularAcceleration angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			AngularAcceleration angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			(angularAcceleration1 < angularAcceleration3).ShouldBeTrue();
			(angularAcceleration3 < angularAcceleration1).ShouldBeFalse();
			(angularAcceleration1 < angularAcceleration2).ShouldBeFalse();
			(angularAcceleration2 < angularAcceleration1).ShouldBeFalse();
		}

		[Fact]
		public void OpLessThanOrEqual() {
			AngularAcceleration angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			AngularAcceleration angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			AngularAcceleration angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			(angularAcceleration1 <= angularAcceleration3).ShouldBeTrue();
			(angularAcceleration3 <= angularAcceleration1).ShouldBeFalse();
			(angularAcceleration1 <= angularAcceleration2).ShouldBeTrue();
			(angularAcceleration2 <= angularAcceleration1).ShouldBeTrue();
		}

		[Fact]
		public void OpMultiplicationScaler() {
			AngularAcceleration angularAcceleration = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			AngularAcceleration expected = new AngularAcceleration(2, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			(angularAcceleration * 2).ShouldEqual(expected, UnitAndValueComparers.AngularAcceleration);
			(2 * angularAcceleration).ShouldEqual(expected, UnitAndValueComparers.AngularAcceleration);
		}

		[Fact]
		public void OpSubtraction() {
			AngularAcceleration angularAcceleration1 = new AngularAcceleration(120, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
			AngularAcceleration angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			(angularAcceleration1 - angularAcceleration2).ShouldEqual(
				new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond), UnitAndValueComparers.AngularAcceleration);
			(angularAcceleration2 - angularAcceleration1).ShouldEqual(
				new AngularAcceleration(-1, AngularAccelerationUnit.RevolutionsPerSecondSquared), UnitAndValueComparers.AngularAcceleration);
		}
	}
}