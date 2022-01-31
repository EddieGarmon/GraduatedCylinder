using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class AccelerationOperators
{
    [Fact]
    public void OpAddition() {
        var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSquareSecond);
        var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSquareSecond);
        (acceleration1 + acceleration2).ShouldBe(new Acceleration(7200, AccelerationUnit.MeterPerSquareSecond));
        (acceleration2 + acceleration1).ShouldBe(new Acceleration(7.2, AccelerationUnit.KilometerPerSquareSecond));
    }

    [Fact]
    public void OpDivision() {
        var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSquareSecond);
        var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSquareSecond);
        (acceleration1 / acceleration2).ShouldBeCloseTo(1);
        (acceleration2 / acceleration1).ShouldBeCloseTo(1);

        (acceleration1 / 2).ShouldBe(new Acceleration(1800, AccelerationUnit.MeterPerSquareSecond));
        (acceleration2 / 2).ShouldBe(new Acceleration(1.8, AccelerationUnit.KilometerPerSquareSecond));
    }

    [Fact]
    public void OpEquals() {
        var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSquareSecond);
        var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSquareSecond);
        var acceleration3 = new Acceleration(1200, AccelerationUnit.MeterPerSquareSecond);
        (acceleration1 == acceleration2).ShouldBeTrue();
        (acceleration2 == acceleration1).ShouldBeTrue();
        (acceleration1 == acceleration3).ShouldBeFalse();
        (acceleration3 == acceleration1).ShouldBeFalse();
        acceleration1.Equals(acceleration2).ShouldBeTrue();
        acceleration1.Equals((object)acceleration2).ShouldBeTrue();
        acceleration2.Equals(acceleration1).ShouldBeTrue();
        acceleration2.Equals((object)acceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSquareSecond);
        var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSquareSecond);
        var acceleration3 = new Acceleration(4500, AccelerationUnit.MeterPerSquareSecond);
        (acceleration1 > acceleration3).ShouldBeFalse();
        (acceleration3 > acceleration1).ShouldBeTrue();
        (acceleration1 > acceleration2).ShouldBeFalse();
        (acceleration2 > acceleration1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSquareSecond);
        var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSquareSecond);
        var acceleration3 = new Acceleration(4500, AccelerationUnit.MeterPerSquareSecond);
        (acceleration1 >= acceleration3).ShouldBeFalse();
        (acceleration3 >= acceleration1).ShouldBeTrue();
        (acceleration1 >= acceleration2).ShouldBeTrue();
        (acceleration2 >= acceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSquareSecond);
        var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSquareSecond);
        var acceleration3 = new Acceleration(4500, AccelerationUnit.MeterPerSquareSecond);
        (acceleration1 != acceleration2).ShouldBeFalse();
        (acceleration2 != acceleration1).ShouldBeFalse();
        (acceleration1 != acceleration3).ShouldBeTrue();
        (acceleration3 != acceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSquareSecond);
        var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSquareSecond);
        var acceleration3 = new Acceleration(4500, AccelerationUnit.MeterPerSquareSecond);
        (acceleration1 < acceleration3).ShouldBeTrue();
        (acceleration3 < acceleration1).ShouldBeFalse();
        (acceleration1 < acceleration2).ShouldBeFalse();
        (acceleration2 < acceleration1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSquareSecond);
        var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSquareSecond);
        var acceleration3 = new Acceleration(4500, AccelerationUnit.MeterPerSquareSecond);
        (acceleration1 <= acceleration3).ShouldBeTrue();
        (acceleration3 <= acceleration1).ShouldBeFalse();
        (acceleration1 <= acceleration2).ShouldBeTrue();
        (acceleration2 <= acceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var acceleration = new Acceleration(1, AccelerationUnit.MeterPerSquareSecond);
        var expected = new Acceleration(2, AccelerationUnit.MeterPerSquareSecond);
        (acceleration * 2).ShouldBe(expected);
        (2 * acceleration).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var acceleration1 = new Acceleration(7200, AccelerationUnit.MeterPerSquareSecond);
        var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSquareSecond);
        (acceleration1 - acceleration2).ShouldBe(new Acceleration(3600, AccelerationUnit.MeterPerSquareSecond));
        (acceleration2 - acceleration1).ShouldBe(
            new Acceleration(-3.6, AccelerationUnit.KilometerPerSquareSecond));
    }
}