using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class RevolutionsOperators
	{
		[Fact]
		public void OpAddition() {
			AngularVelocity revolutions1 = new AngularVelocity(60, AngularVelocityUnit.RevolutionsPerMinute);
			AngularVelocity revolutions2 = new AngularVelocity(1, AngularVelocityUnit.RevolutionsPerSecond);
			AngularVelocity expected = new AngularVelocity(120, AngularVelocityUnit.RevolutionsPerMinute);
			(revolutions1 + revolutions2).ShouldEqual(expected, UnitAndValueComparers.Revolutions);
			expected.Units = AngularVelocityUnit.RevolutionsPerSecond;
			(revolutions2 + revolutions1).ShouldEqual(expected, UnitAndValueComparers.Revolutions);
		}

		[Fact]
		public void OpDivision() {
			AngularVelocity revolutions1 = new AngularVelocity(60, AngularVelocityUnit.RevolutionsPerMinute);
			AngularVelocity revolutions2 = new AngularVelocity(1, AngularVelocityUnit.RevolutionsPerSecond);
			(revolutions1 / revolutions2).ShouldBeWithinEpsilonOf(1);
			(revolutions2 / revolutions1).ShouldBeWithinEpsilonOf(1);

			(revolutions1 / 2).ShouldEqual(new AngularVelocity(30, AngularVelocityUnit.RevolutionsPerMinute));
			(revolutions2 / 2).ShouldEqual(new AngularVelocity(.5, AngularVelocityUnit.RevolutionsPerSecond));
		}

		[Fact]
		public void OpEquals() {
			AngularVelocity revolutions1 = new AngularVelocity(3600, AngularVelocityUnit.RevolutionsPerMinute);
			AngularVelocity revolutions2 = new AngularVelocity(60, AngularVelocityUnit.RevolutionsPerSecond);
			AngularVelocity revolutions3 = new AngularVelocity(120, AngularVelocityUnit.RevolutionsPerSecond);
			(revolutions1 == revolutions2).ShouldBeTrue();
			(revolutions2 == revolutions1).ShouldBeTrue();
			(revolutions1 == revolutions3).ShouldBeFalse();
			(revolutions3 == revolutions1).ShouldBeFalse();
			revolutions1.Equals(revolutions2).ShouldBeTrue();
			revolutions1.Equals((object)revolutions2).ShouldBeTrue();
			revolutions2.Equals(revolutions1).ShouldBeTrue();
			revolutions2.Equals((object)revolutions1).ShouldBeTrue();
		}

		[Fact]
		public void OpGreaterThan() {
			AngularVelocity revolutions1 = new AngularVelocity(3600, AngularVelocityUnit.RevolutionsPerMinute);
			AngularVelocity revolutions2 = new AngularVelocity(60, AngularVelocityUnit.RevolutionsPerSecond);
			AngularVelocity revolutions3 = new AngularVelocity(120, AngularVelocityUnit.RevolutionsPerSecond);
			(revolutions1 > revolutions3).ShouldBeFalse();
			(revolutions3 > revolutions1).ShouldBeTrue();
			(revolutions1 > revolutions2).ShouldBeFalse();
			(revolutions2 > revolutions1).ShouldBeFalse();
		}

		[Fact]
		public void OpGreaterThanOrEqual() {
			AngularVelocity revolutions1 = new AngularVelocity(3600, AngularVelocityUnit.RevolutionsPerMinute);
			AngularVelocity revolutions2 = new AngularVelocity(60, AngularVelocityUnit.RevolutionsPerSecond);
			AngularVelocity revolutions3 = new AngularVelocity(120, AngularVelocityUnit.RevolutionsPerSecond);
			(revolutions1 >= revolutions3).ShouldBeFalse();
			(revolutions3 >= revolutions1).ShouldBeTrue();
			(revolutions1 >= revolutions2).ShouldBeTrue();
			(revolutions2 >= revolutions1).ShouldBeTrue();
		}

		[Fact]
		public void OpInverseEquals() {
			AngularVelocity revolutions1 = new AngularVelocity(3600, AngularVelocityUnit.RevolutionsPerMinute);
			AngularVelocity revolutions2 = new AngularVelocity(60, AngularVelocityUnit.RevolutionsPerSecond);
			AngularVelocity revolutions3 = new AngularVelocity(120, AngularVelocityUnit.RevolutionsPerSecond);
			(revolutions1 != revolutions2).ShouldBeFalse();
			(revolutions2 != revolutions1).ShouldBeFalse();
			(revolutions1 != revolutions3).ShouldBeTrue();
			(revolutions3 != revolutions1).ShouldBeTrue();
		}

		[Fact]
		public void OpLessThan() {
			AngularVelocity revolutions1 = new AngularVelocity(3600, AngularVelocityUnit.RevolutionsPerMinute);
			AngularVelocity revolutions2 = new AngularVelocity(60, AngularVelocityUnit.RevolutionsPerSecond);
			AngularVelocity revolutions3 = new AngularVelocity(120, AngularVelocityUnit.RevolutionsPerSecond);
			(revolutions1 < revolutions3).ShouldBeTrue();
			(revolutions3 < revolutions1).ShouldBeFalse();
			(revolutions1 < revolutions2).ShouldBeFalse();
			(revolutions2 < revolutions1).ShouldBeFalse();
		}

		[Fact]
		public void OpLessThanOrEqual() {
			AngularVelocity revolutions1 = new AngularVelocity(3600, AngularVelocityUnit.RevolutionsPerMinute);
			AngularVelocity revolutions2 = new AngularVelocity(60, AngularVelocityUnit.RevolutionsPerSecond);
			AngularVelocity revolutions3 = new AngularVelocity(120, AngularVelocityUnit.RevolutionsPerSecond);
			(revolutions1 <= revolutions3).ShouldBeTrue();
			(revolutions3 <= revolutions1).ShouldBeFalse();
			(revolutions1 <= revolutions2).ShouldBeTrue();
			(revolutions2 <= revolutions1).ShouldBeTrue();
		}

		[Fact]
		public void OpMultiplicationScaler() {
			AngularVelocity angularVelocity = new AngularVelocity(1, AngularVelocityUnit.RevolutionsPerSecond);
			AngularVelocity expected = new AngularVelocity(2, AngularVelocityUnit.RevolutionsPerSecond);
			(angularVelocity * 2).ShouldEqual(expected, UnitAndValueComparers.Revolutions);
			(2 * angularVelocity).ShouldEqual(expected, UnitAndValueComparers.Revolutions);
		}

		[Fact]
		public void OpSubtraction() {
			AngularVelocity revolutions1 = new AngularVelocity(720, AngularVelocityUnit.RevolutionsPerMinute);
			AngularVelocity revolutions2 = new AngularVelocity(1, AngularVelocityUnit.RevolutionsPerSecond);
			(revolutions1 - revolutions2).ShouldEqual(new AngularVelocity(660, AngularVelocityUnit.RevolutionsPerMinute),
													  UnitAndValueComparers.Revolutions);
			(revolutions2 - revolutions1).ShouldEqual(new AngularVelocity(-11, AngularVelocityUnit.RevolutionsPerSecond),
													  UnitAndValueComparers.Revolutions);
		}
	}
}