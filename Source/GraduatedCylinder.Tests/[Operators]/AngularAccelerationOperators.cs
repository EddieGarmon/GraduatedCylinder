using Xunit;
using XunitShould;

namespace GraduatedCylinder
{
    public class AngularAngularAccelerationOperators
    {
        [Fact]
        public void OpAddition() {
            var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            var expected = new AngularAcceleration(120, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            (angularAcceleration1 + angularAcceleration2).ShouldEqual(expected);
            (angularAcceleration2 + angularAcceleration1).ShouldEqual(expected);
        }

        [Fact]
        public void OpDivision() {
            var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            (angularAcceleration1 / angularAcceleration2).ShouldBeWithinEpsilonOf(1);
            (angularAcceleration2 / angularAcceleration1).ShouldBeWithinEpsilonOf(1);

            (angularAcceleration1 / 2).ShouldEqual(new AngularAcceleration(30, AngularAccelerationUnit.RevolutionsPerMinutePerSecond));
            (angularAcceleration2 / 2).ShouldEqual(new AngularAcceleration(.5, AngularAccelerationUnit.RevolutionsPerSecondSquared));
        }

        [Fact]
        public void OpEquals() {
            var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            (angularAcceleration1 == angularAcceleration2).ShouldBeTrue();
            (angularAcceleration2 == angularAcceleration1).ShouldBeTrue();
            (angularAcceleration1 == angularAcceleration3).ShouldBeFalse();
            (angularAcceleration3 == angularAcceleration1).ShouldBeFalse();
            angularAcceleration1.Equals(angularAcceleration2)
                                .ShouldBeTrue();
            angularAcceleration1.Equals((object)angularAcceleration2)
                                .ShouldBeTrue();
            angularAcceleration2.Equals(angularAcceleration1)
                                .ShouldBeTrue();
            angularAcceleration2.Equals((object)angularAcceleration1)
                                .ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            (angularAcceleration1 > angularAcceleration3).ShouldBeFalse();
            (angularAcceleration3 > angularAcceleration1).ShouldBeTrue();
            (angularAcceleration1 > angularAcceleration2).ShouldBeFalse();
            (angularAcceleration2 > angularAcceleration1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            (angularAcceleration1 >= angularAcceleration3).ShouldBeFalse();
            (angularAcceleration3 >= angularAcceleration1).ShouldBeTrue();
            (angularAcceleration1 >= angularAcceleration2).ShouldBeTrue();
            (angularAcceleration2 >= angularAcceleration1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            (angularAcceleration1 != angularAcceleration2).ShouldBeFalse();
            (angularAcceleration2 != angularAcceleration1).ShouldBeFalse();
            (angularAcceleration1 != angularAcceleration3).ShouldBeTrue();
            (angularAcceleration3 != angularAcceleration1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            (angularAcceleration1 < angularAcceleration3).ShouldBeTrue();
            (angularAcceleration3 < angularAcceleration1).ShouldBeFalse();
            (angularAcceleration1 < angularAcceleration2).ShouldBeFalse();
            (angularAcceleration2 < angularAcceleration1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            (angularAcceleration1 <= angularAcceleration3).ShouldBeTrue();
            (angularAcceleration3 <= angularAcceleration1).ShouldBeFalse();
            (angularAcceleration1 <= angularAcceleration2).ShouldBeTrue();
            (angularAcceleration2 <= angularAcceleration1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var angularAcceleration = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            var expected = new AngularAcceleration(2, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            (angularAcceleration * 2).ShouldEqual(expected);
            (2 * angularAcceleration).ShouldEqual(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var angularAcceleration1 = new AngularAcceleration(120, AngularAccelerationUnit.RevolutionsPerMinutePerSecond);
            var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            (angularAcceleration1 - angularAcceleration2).ShouldEqual(new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerMinutePerSecond));
            (angularAcceleration2 - angularAcceleration1).ShouldEqual(new AngularAcceleration(-1, AngularAccelerationUnit.RevolutionsPerSecondSquared));
        }
    }
}