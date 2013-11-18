using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class AngleOperators
    {
        [Fact]
        public void OpAddition() {
            Angle angle1 = new Angle(180, AngleUnit.Degrees);
            Angle angle2 = new Angle(200, AngleUnit.Grads);
            Angle expected = new Angle(360, AngleUnit.Degrees);
            (angle1 + angle2).ShouldEqual(expected, UnitAndValueComparers.Angle);
            expected.Units = AngleUnit.Grads;
            (angle2 + angle1).ShouldEqual(expected, UnitAndValueComparers.Angle);
        }

        [Fact]
        public void OpDivision() {
            Angle angle1 = new Angle(180, AngleUnit.Degrees);
            Angle angle2 = new Angle(200, AngleUnit.Grads);
            (angle1 / angle2).ShouldBeWithinEpsilonOf(1);
            (angle2 / angle1).ShouldBeWithinEpsilonOf(1);

            (angle1 / 2).ShouldEqual(new Angle(90, AngleUnit.Degrees));
            (angle2 / 2).ShouldEqual(new Angle(100, AngleUnit.Grads));
        }

        [Fact]
        public void OpEquals() {
            Angle angle1 = new Angle(180, AngleUnit.Degrees);
            Angle angle2 = new Angle(200, AngleUnit.Grads);
            Angle angle3 = new Angle(200, AngleUnit.Degrees);
            (angle1 == angle2).ShouldBeTrue();
            (angle2 == angle1).ShouldBeTrue();
            (angle1 == angle3).ShouldBeFalse();
            (angle3 == angle1).ShouldBeFalse();
            angle1.Equals(angle2).ShouldBeTrue();
            angle1.Equals((object)angle2).ShouldBeTrue();
            angle2.Equals(angle1).ShouldBeTrue();
            angle2.Equals((object)angle1).ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            Angle angle1 = new Angle(180, AngleUnit.Degrees);
            Angle angle2 = new Angle(200, AngleUnit.Grads);
            Angle angle3 = new Angle(200, AngleUnit.Degrees);
            (angle1 > angle3).ShouldBeFalse();
            (angle3 > angle1).ShouldBeTrue();
            (angle1 > angle2).ShouldBeFalse();
            (angle2 > angle1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            Angle angle1 = new Angle(180, AngleUnit.Degrees);
            Angle angle2 = new Angle(200, AngleUnit.Grads);
            Angle angle3 = new Angle(200, AngleUnit.Degrees);
            (angle1 >= angle3).ShouldBeFalse();
            (angle3 >= angle1).ShouldBeTrue();
            (angle1 >= angle2).ShouldBeTrue();
            (angle2 >= angle1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            Angle angle1 = new Angle(180, AngleUnit.Degrees);
            Angle angle2 = new Angle(200, AngleUnit.Grads);
            Angle angle3 = new Angle(200, AngleUnit.Degrees);
            (angle1 != angle2).ShouldBeFalse();
            (angle2 != angle1).ShouldBeFalse();
            (angle1 != angle3).ShouldBeTrue();
            (angle3 != angle1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            Angle angle1 = new Angle(180, AngleUnit.Degrees);
            Angle angle2 = new Angle(200, AngleUnit.Grads);
            Angle angle3 = new Angle(200, AngleUnit.Degrees);
            (angle1 < angle3).ShouldBeTrue();
            (angle3 < angle1).ShouldBeFalse();
            (angle1 < angle2).ShouldBeFalse();
            (angle2 < angle1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            Angle angle1 = new Angle(180, AngleUnit.Degrees);
            Angle angle2 = new Angle(200, AngleUnit.Grads);
            Angle angle3 = new Angle(200, AngleUnit.Degrees);
            (angle1 <= angle3).ShouldBeTrue();
            (angle3 <= angle1).ShouldBeFalse();
            (angle1 <= angle2).ShouldBeTrue();
            (angle2 <= angle1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            Angle angle = new Angle(100, AngleUnit.Degrees);
            Angle expected = new Angle(200, AngleUnit.Degrees);
            (angle * 2).ShouldEqual(expected, UnitAndValueComparers.Angle);
            (2 * angle).ShouldEqual(expected, UnitAndValueComparers.Angle);
        }

        [Fact]
        public void OpSubtraction() {
            Angle angle1 = new Angle(180, AngleUnit.Degrees);
            Angle angle2 = new Angle(100, AngleUnit.Grads);
            (angle1 - angle2).ShouldEqual(new Angle(90, AngleUnit.Degrees), UnitAndValueComparers.Angle);
            (angle2 - angle1).ShouldEqual(new Angle(-100, AngleUnit.Grads), UnitAndValueComparers.Angle);
        }
    }
}