using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class AccelerationOperators
{

    [Fact]
    public void OpAddition() {
        Acceleration acceleration1 = new(3600, AccelerationUnit.MeterPerSquareSecond);
        Acceleration acceleration2 = new(3.6, AccelerationUnit.KiloMeterPerSquareSecond);
        (acceleration1 + acceleration2).ShouldBe(new Acceleration(7200, AccelerationUnit.MeterPerSquareSecond));
        (acceleration2 + acceleration1).ShouldBe(new Acceleration(7.2, AccelerationUnit.KiloMeterPerSquareSecond));
    }

    [Fact]
    public void OpDivision() {
        Acceleration acceleration1 = new(3600, AccelerationUnit.MeterPerSquareSecond);
        Acceleration acceleration2 = new(3.6, AccelerationUnit.KiloMeterPerSquareSecond);
        (acceleration1 / acceleration2).ShouldBeCloseTo(1);
        (acceleration2 / acceleration1).ShouldBeCloseTo(1);

        (acceleration1 / 2).ShouldBe(new Acceleration(1800, AccelerationUnit.MeterPerSquareSecond));
        (acceleration2 / 2).ShouldBe(new Acceleration(1.8, AccelerationUnit.KiloMeterPerSquareSecond));
    }

    [Fact]
    public void OpEquals() {
        Acceleration acceleration1 = new(3600, AccelerationUnit.MeterPerSquareSecond);
        Acceleration acceleration2 = new(3.6, AccelerationUnit.KiloMeterPerSquareSecond);
        Acceleration acceleration3 = new(1200, AccelerationUnit.MeterPerSquareSecond);
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
        Acceleration acceleration1 = new(3600, AccelerationUnit.MeterPerSquareSecond);
        Acceleration acceleration2 = new(3.6, AccelerationUnit.KiloMeterPerSquareSecond);
        Acceleration acceleration3 = new(4500, AccelerationUnit.MeterPerSquareSecond);
        (acceleration1 > acceleration3).ShouldBeFalse();
        (acceleration3 > acceleration1).ShouldBeTrue();
        (acceleration1 > acceleration2).ShouldBeFalse();
        (acceleration2 > acceleration1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Acceleration acceleration1 = new(3600, AccelerationUnit.MeterPerSquareSecond);
        Acceleration acceleration2 = new(3.6, AccelerationUnit.KiloMeterPerSquareSecond);
        Acceleration acceleration3 = new(4500, AccelerationUnit.MeterPerSquareSecond);
        (acceleration1 >= acceleration3).ShouldBeFalse();
        (acceleration3 >= acceleration1).ShouldBeTrue();
        (acceleration1 >= acceleration2).ShouldBeTrue();
        (acceleration2 >= acceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Acceleration acceleration1 = new(3600, AccelerationUnit.MeterPerSquareSecond);
        Acceleration acceleration2 = new(3.6, AccelerationUnit.KiloMeterPerSquareSecond);
        Acceleration acceleration3 = new(4500, AccelerationUnit.MeterPerSquareSecond);
        (acceleration1 != acceleration2).ShouldBeFalse();
        (acceleration2 != acceleration1).ShouldBeFalse();
        (acceleration1 != acceleration3).ShouldBeTrue();
        (acceleration3 != acceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Acceleration acceleration1 = new(3600, AccelerationUnit.MeterPerSquareSecond);
        Acceleration acceleration2 = new(3.6, AccelerationUnit.KiloMeterPerSquareSecond);
        Acceleration acceleration3 = new(4500, AccelerationUnit.MeterPerSquareSecond);
        (acceleration1 < acceleration3).ShouldBeTrue();
        (acceleration3 < acceleration1).ShouldBeFalse();
        (acceleration1 < acceleration2).ShouldBeFalse();
        (acceleration2 < acceleration1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Acceleration acceleration1 = new(3600, AccelerationUnit.MeterPerSquareSecond);
        Acceleration acceleration2 = new(3.6, AccelerationUnit.KiloMeterPerSquareSecond);
        Acceleration acceleration3 = new(4500, AccelerationUnit.MeterPerSquareSecond);
        (acceleration1 <= acceleration3).ShouldBeTrue();
        (acceleration3 <= acceleration1).ShouldBeFalse();
        (acceleration1 <= acceleration2).ShouldBeTrue();
        (acceleration2 <= acceleration1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Acceleration acceleration = new(1, AccelerationUnit.MeterPerSquareSecond);
        Acceleration expected = new(2, AccelerationUnit.MeterPerSquareSecond);
        (acceleration * 2).ShouldBe(expected);
        (2 * acceleration).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Acceleration acceleration1 = new(7200, AccelerationUnit.MeterPerSquareSecond);
        Acceleration acceleration2 = new(3.6, AccelerationUnit.KiloMeterPerSquareSecond);
        (acceleration1 - acceleration2).ShouldBe(new Acceleration(3600, AccelerationUnit.MeterPerSquareSecond));
        (acceleration2 - acceleration1).ShouldBe(new Acceleration(-3.6, AccelerationUnit.KiloMeterPerSquareSecond));
    }

}