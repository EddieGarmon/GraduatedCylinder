using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class AngularAngularAccelerationOperators
{

    [Fact]
    public void OpAddition() {
        var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        var expected = new AngularAcceleration(120, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 + angularAcceleration2).ShouldBe(expected);
        (angularAcceleration2 + angularAcceleration1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        (angularAcceleration1 / angularAcceleration2).ShouldBeCloseTo(1);
        (angularAcceleration2 / angularAcceleration1).ShouldBeCloseTo(1);

        (angularAcceleration1 / 2).ShouldBe(new AngularAcceleration(30, AngularAccelerationUnit.RevolutionsPerSquareMinute));
        (angularAcceleration2 / 2).ShouldBe(new AngularAcceleration(.5, AngularAccelerationUnit.RevolutionsPerSquareSecond));
    }

    [Fact]
    public void OpEquals() {
        var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerSquareMinute);
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
        var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 > angularAcceleration3).ShouldBeFalse();
        (angularAcceleration3 > angularAcceleration1).ShouldBeTrue();
        (angularAcceleration1 > angularAcceleration2).ShouldBeFalse();
        (angularAcceleration2 > angularAcceleration1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 >= angularAcceleration3).ShouldBeFalse();
        (angularAcceleration3 >= angularAcceleration1).ShouldBeTrue();
        (angularAcceleration1 >= angularAcceleration2).ShouldBeTrue();
        (angularAcceleration2 >= angularAcceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 != angularAcceleration2).ShouldBeFalse();
        (angularAcceleration2 != angularAcceleration1).ShouldBeFalse();
        (angularAcceleration1 != angularAcceleration3).ShouldBeTrue();
        (angularAcceleration3 != angularAcceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 < angularAcceleration3).ShouldBeTrue();
        (angularAcceleration3 < angularAcceleration1).ShouldBeFalse();
        (angularAcceleration1 < angularAcceleration2).ShouldBeFalse();
        (angularAcceleration2 < angularAcceleration1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var angularAcceleration1 = new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        var angularAcceleration3 = new AngularAcceleration(180, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 <= angularAcceleration3).ShouldBeTrue();
        (angularAcceleration3 <= angularAcceleration1).ShouldBeFalse();
        (angularAcceleration1 <= angularAcceleration2).ShouldBeTrue();
        (angularAcceleration2 <= angularAcceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var angularAcceleration = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        var expected = new AngularAcceleration(2, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        (angularAcceleration * 2).ShouldBe(expected);
        (2 * angularAcceleration).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var angularAcceleration1 = new AngularAcceleration(120, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        var angularAcceleration2 = new AngularAcceleration(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        (angularAcceleration1 - angularAcceleration2).ShouldBe(
            new AngularAcceleration(60, AngularAccelerationUnit.RevolutionsPerSquareMinute));
        (angularAcceleration2 - angularAcceleration1).ShouldBe(
            new AngularAcceleration(-1, AngularAccelerationUnit.RevolutionsPerSquareSecond));
    }

}