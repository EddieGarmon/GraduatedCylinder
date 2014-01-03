using Xunit;
using XunitShould;

namespace GraduatedCylinder
{
    public class AngleOperators
    {
        [Fact]
        public void OpAddition() {
            var angle1 = new Angle(180, AngleUnit.Degree);
            var angle2 = new Angle(200, AngleUnit.Grad);
            var expected = new Angle(360, AngleUnit.Degree);
            (angle1 + angle2).ShouldEqual(expected);
            (angle2 + angle1).ShouldEqual(expected);
        }

        [Fact]
        public void OpDivision() {
            var angle1 = new Angle(180, AngleUnit.Degree);
            var angle2 = new Angle(200, AngleUnit.Grad);
            (angle1 / angle2).ShouldBeWithinEpsilonOf(1);
            (angle2 / angle1).ShouldBeWithinEpsilonOf(1);

            (angle1 / 2).ShouldEqual(new Angle(90, AngleUnit.Degree));
            (angle2 / 2).ShouldEqual(new Angle(100, AngleUnit.Grad));
        }

        [Fact]
        public void OpEquals() {
            var angle1 = new Angle(180, AngleUnit.Degree);
            var angle2 = new Angle(200, AngleUnit.Grad);
            var angle3 = new Angle(200, AngleUnit.Degree);
            (angle1 == angle2).ShouldBeTrue();
            (angle2 == angle1).ShouldBeTrue();
            (angle1 == angle3).ShouldBeFalse();
            (angle3 == angle1).ShouldBeFalse();
            angle1.Equals(angle2)
                  .ShouldBeTrue();
            angle1.Equals((object)angle2)
                  .ShouldBeTrue();
            angle2.Equals(angle1)
                  .ShouldBeTrue();
            angle2.Equals((object)angle1)
                  .ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            var angle1 = new Angle(180, AngleUnit.Degree);
            var angle2 = new Angle(200, AngleUnit.Grad);
            var angle3 = new Angle(200, AngleUnit.Degree);
            (angle1 > angle3).ShouldBeFalse();
            (angle3 > angle1).ShouldBeTrue();
            (angle1 > angle2).ShouldBeFalse();
            (angle2 > angle1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var angle1 = new Angle(180, AngleUnit.Degree);
            var angle2 = new Angle(200, AngleUnit.Grad);
            var angle3 = new Angle(200, AngleUnit.Degree);
            (angle1 >= angle3).ShouldBeFalse();
            (angle3 >= angle1).ShouldBeTrue();
            (angle1 >= angle2).ShouldBeTrue();
            (angle2 >= angle1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var angle1 = new Angle(180, AngleUnit.Degree);
            var angle2 = new Angle(200, AngleUnit.Grad);
            var angle3 = new Angle(200, AngleUnit.Degree);
            (angle1 != angle2).ShouldBeFalse();
            (angle2 != angle1).ShouldBeFalse();
            (angle1 != angle3).ShouldBeTrue();
            (angle3 != angle1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var angle1 = new Angle(180, AngleUnit.Degree);
            var angle2 = new Angle(200, AngleUnit.Grad);
            var angle3 = new Angle(200, AngleUnit.Degree);
            (angle1 < angle3).ShouldBeTrue();
            (angle3 < angle1).ShouldBeFalse();
            (angle1 < angle2).ShouldBeFalse();
            (angle2 < angle1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var angle1 = new Angle(180, AngleUnit.Degree);
            var angle2 = new Angle(200, AngleUnit.Grad);
            var angle3 = new Angle(200, AngleUnit.Degree);
            (angle1 <= angle3).ShouldBeTrue();
            (angle3 <= angle1).ShouldBeFalse();
            (angle1 <= angle2).ShouldBeTrue();
            (angle2 <= angle1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var angle = new Angle(100, AngleUnit.Degree);
            var expected = new Angle(200, AngleUnit.Degree);
            (angle * 2).ShouldEqual(expected);
            (2 * angle).ShouldEqual(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var angle1 = new Angle(180, AngleUnit.Degree);
            var angle2 = new Angle(100, AngleUnit.Grad);
            (angle1 - angle2).ShouldEqual(new Angle(90, AngleUnit.Degree));
            (angle2 - angle1).ShouldEqual(new Angle(-100, AngleUnit.Grad));
        }
    }
}