#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class AngleOperators
{

    [Fact]
    public void OpAddition() {
        Angle angle1 = new(180, AngleUnit.Degree);
        Angle angle2 = new(200, AngleUnit.Grad);
        (angle1 + angle2).In(AngleUnit.Degree).Value.ShouldBeCloseTo(360);
        (angle2 + angle1).In(AngleUnit.Revolutions).Value.ShouldBeCloseTo(1);
    }

    [Fact]
    public void OpDivision() {
        Angle angle1 = new(180, AngleUnit.Degree);
        Angle angle2 = new(200, AngleUnit.Grad);
        (angle1 / angle2).ShouldBeCloseTo(1);
        (angle2 / angle1).ShouldBeCloseTo(1);

        (angle1 / 2).ShouldBe(new Angle(90, AngleUnit.Degree));
        (angle2 / 2).ShouldBe(new Angle(100, AngleUnit.Grad));
    }

    [Fact]
    public void OpEquals() {
        Angle angle1 = new(180, AngleUnit.Degree);
        Angle angle2 = new(.5, AngleUnit.Revolutions);
        Angle angle3 = new(200, AngleUnit.Degree);
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
        Angle angle1 = new(180, AngleUnit.Degree);
        Angle angle2 = new(200, AngleUnit.Grad);
        Angle angle3 = new(200, AngleUnit.Degree);
        (angle1 > angle3).ShouldBeFalse();
        (angle3 > angle1).ShouldBeTrue();
        (angle1 > angle2).ShouldBeFalse();
        (angle2 > angle1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Angle angle1 = new(180, AngleUnit.Degree);
        Angle angle2 = new(200, AngleUnit.Grad);
        Angle angle3 = new(200, AngleUnit.Degree);
        (angle1 >= angle3).ShouldBeFalse();
        (angle3 >= angle1).ShouldBeTrue();
        (angle1 >= angle2).ShouldBeTrue();
        (angle2 >= angle1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Angle angle1 = new(180, AngleUnit.Degree);
        Angle angle2 = new(200, AngleUnit.Grad);
        Angle angle3 = new(200, AngleUnit.Degree);
        (angle1 != angle2).ShouldBeFalse();
        (angle2 != angle1).ShouldBeFalse();
        (angle1 != angle3).ShouldBeTrue();
        (angle3 != angle1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Angle angle1 = new(180, AngleUnit.Degree);
        Angle angle2 = new(200, AngleUnit.Grad);
        Angle angle3 = new(200, AngleUnit.Degree);
        (angle1 < angle3).ShouldBeTrue();
        (angle3 < angle1).ShouldBeFalse();
        (angle1 < angle2).ShouldBeFalse();
        (angle2 < angle1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Angle angle1 = new(180, AngleUnit.Degree);
        Angle angle2 = new(200, AngleUnit.Grad);
        Angle angle3 = new(200, AngleUnit.Degree);
        (angle1 <= angle3).ShouldBeTrue();
        (angle3 <= angle1).ShouldBeFalse();
        (angle1 <= angle2).ShouldBeTrue();
        (angle2 <= angle1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Angle angle = new(100, AngleUnit.Degree);
        Angle expected = new(200, AngleUnit.Degree);
        (angle * 2).ShouldBe(expected);
        (2 * angle).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Angle angle1 = new(180, AngleUnit.Degree);
        Angle angle2 = new(100, AngleUnit.Grad);
        (angle1 - angle2).ShouldBe(new Angle(90, AngleUnit.Degree));
        (angle2 - angle1).ShouldBe(new Angle(-100, AngleUnit.Grad));
    }

}