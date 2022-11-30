using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class AngularAngularAccelerationOperators
{

    [Fact]
    public void OpAddition() {
        AngularAcceleration angularAcceleration1 = new(3600, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        AngularAcceleration angularAcceleration2 = new(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        AngularAcceleration expected = new(7200, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 + angularAcceleration2).ShouldBe(expected);
        (angularAcceleration2 + angularAcceleration1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        AngularAcceleration angularAcceleration1 = new(3600, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        AngularAcceleration angularAcceleration2 = new(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        (angularAcceleration1 / angularAcceleration2).ShouldBeCloseTo(1);
        (angularAcceleration2 / angularAcceleration1).ShouldBeCloseTo(1);

        (angularAcceleration1 / 2).ShouldBe(new AngularAcceleration(1800, AngularAccelerationUnit.RevolutionsPerSquareMinute));
        (angularAcceleration2 / 2).ShouldBe(new AngularAcceleration(.5, AngularAccelerationUnit.RevolutionsPerSquareSecond));
    }

    [Fact]
    public void OpEquals() {
        AngularAcceleration angularAcceleration1 = new(3600, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        AngularAcceleration angularAcceleration2 = new(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        (angularAcceleration1 == angularAcceleration2).ShouldBeTrue();
        (angularAcceleration2 == angularAcceleration1).ShouldBeTrue();
        angularAcceleration1.Equals(angularAcceleration2).ShouldBeTrue();
        angularAcceleration1.Equals((object)angularAcceleration2).ShouldBeTrue();
        angularAcceleration2.Equals(angularAcceleration1).ShouldBeTrue();
        angularAcceleration2.Equals((object)angularAcceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        AngularAcceleration angularAcceleration1 = new(3600, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        AngularAcceleration angularAcceleration2 = new(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        AngularAcceleration angularAcceleration3 = new(180, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 > angularAcceleration3).ShouldBeTrue();
        (angularAcceleration3 > angularAcceleration1).ShouldBeFalse();
        (angularAcceleration1 > angularAcceleration2).ShouldBeFalse();
        (angularAcceleration2 > angularAcceleration1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        AngularAcceleration angularAcceleration1 = new(3600, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        AngularAcceleration angularAcceleration2 = new(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        AngularAcceleration angularAcceleration3 = new(180, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 >= angularAcceleration3).ShouldBeTrue();
        (angularAcceleration3 >= angularAcceleration1).ShouldBeFalse();
        (angularAcceleration1 >= angularAcceleration2).ShouldBeTrue();
        (angularAcceleration2 >= angularAcceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        AngularAcceleration angularAcceleration1 = new(3600, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        AngularAcceleration angularAcceleration2 = new(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        AngularAcceleration angularAcceleration3 = new(180, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 < angularAcceleration3).ShouldBeFalse();
        (angularAcceleration3 < angularAcceleration1).ShouldBeTrue();
        (angularAcceleration1 < angularAcceleration2).ShouldBeFalse();
        (angularAcceleration2 < angularAcceleration1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        AngularAcceleration angularAcceleration1 = new(3600, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        AngularAcceleration angularAcceleration2 = new(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        AngularAcceleration angularAcceleration3 = new(180, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 <= angularAcceleration3).ShouldBeFalse();
        (angularAcceleration3 <= angularAcceleration1).ShouldBeTrue();
        (angularAcceleration1 <= angularAcceleration2).ShouldBeTrue();
        (angularAcceleration2 <= angularAcceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        AngularAcceleration angularAcceleration = new(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        AngularAcceleration expected = new(2, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        (angularAcceleration * 2).ShouldBe(expected);
        (2 * angularAcceleration).ShouldBe(expected);
    }

    [Fact]
    public void OpNotEquals() {
        AngularAcceleration angularAcceleration1 = new(3600, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        AngularAcceleration angularAcceleration2 = new(1, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        AngularAcceleration angularAcceleration3 = new(180, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 != angularAcceleration2).ShouldBeFalse();
        (angularAcceleration2 != angularAcceleration1).ShouldBeFalse();
        (angularAcceleration1 != angularAcceleration3).ShouldBeTrue();
        (angularAcceleration3 != angularAcceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpSubtraction() {
        AngularAcceleration angularAcceleration1 = new(120, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        AngularAcceleration angularAcceleration2 = new(40, AngularAccelerationUnit.RevolutionsPerSquareMinute);
        (angularAcceleration1 - angularAcceleration2).ShouldBe(
            new AngularAcceleration(80, AngularAccelerationUnit.RevolutionsPerSquareMinute));
    }

}