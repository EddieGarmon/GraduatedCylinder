using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class TimeOperators
{

    [Fact]
    public void OpAddition() {
        var time1 = new Time(3600, TimeUnit.Second);
        var time2 = new Time(1, TimeUnit.Hours);
        var expected = new Time(7200, TimeUnit.Second);
        (time1 + time2).ShouldBe(expected);
        (time2 + time1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var time1 = new Time(3600, TimeUnit.Second);
        var time2 = new Time(1, TimeUnit.Hours);
        (time1 / time2).ShouldBeCloseTo(1);
        (time2 / time1).ShouldBeCloseTo(1);

        (time1 / 2).ShouldBe(new Time(1800, TimeUnit.Second));
        (time2 / 2).ShouldBe(new Time(.5, TimeUnit.Hours));
    }

    [Fact]
    public void OpEquals() {
        var time1 = new Time(3600, TimeUnit.Second);
        var time2 = new Time(1, TimeUnit.Hours);
        var time3 = new Time(120, TimeUnit.Minutes);
        (time1 == time2).ShouldBeTrue();
        (time2 == time1).ShouldBeTrue();
        (time1 == time3).ShouldBeFalse();
        (time3 == time1).ShouldBeFalse();
        time1.Equals(time2).ShouldBeTrue();
        time1.Equals((object)time2).ShouldBeTrue();
        time2.Equals(time1).ShouldBeTrue();
        time2.Equals((object)time1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        var time1 = new Time(3600, TimeUnit.Second);
        var time2 = new Time(1, TimeUnit.Hours);
        var time3 = new Time(120, TimeUnit.Minutes);
        (time1 > time3).ShouldBeFalse();
        (time3 > time1).ShouldBeTrue();
        (time1 > time2).ShouldBeFalse();
        (time2 > time1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var time1 = new Time(3600, TimeUnit.Second);
        var time2 = new Time(1, TimeUnit.Hours);
        var time3 = new Time(120, TimeUnit.Minutes);
        (time1 >= time3).ShouldBeFalse();
        (time3 >= time1).ShouldBeTrue();
        (time1 >= time2).ShouldBeTrue();
        (time2 >= time1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var time1 = new Time(3600, TimeUnit.Second);
        var time2 = new Time(1, TimeUnit.Hours);
        var time3 = new Time(120, TimeUnit.Minutes);
        (time1 != time2).ShouldBeFalse();
        (time2 != time1).ShouldBeFalse();
        (time1 != time3).ShouldBeTrue();
        (time3 != time1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var time1 = new Time(3600, TimeUnit.Second);
        var time2 = new Time(1, TimeUnit.Hours);
        var time3 = new Time(120, TimeUnit.Minutes);
        (time1 < time3).ShouldBeTrue();
        (time3 < time1).ShouldBeFalse();
        (time1 < time2).ShouldBeFalse();
        (time2 < time1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var time1 = new Time(3600, TimeUnit.Second);
        var time2 = new Time(1, TimeUnit.Hours);
        var time3 = new Time(120, TimeUnit.Minutes);
        (time1 <= time3).ShouldBeTrue();
        (time3 <= time1).ShouldBeFalse();
        (time1 <= time2).ShouldBeTrue();
        (time2 <= time1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationAcceleration() {
        Speed speedBase = new Time(20, TimeUnit.Second) * new Acceleration(3, AccelerationUnit.MeterPerSquareSecond);
        speedBase.ShouldBe(new Speed(60, SpeedUnit.MeterPerSecond));

        var time = new Time(1, TimeUnit.Minutes);
        var acceleration = new Acceleration(1, AccelerationUnit.MilePerHourPerSecond);
        Speed speed = time * acceleration;
        speed = speed.In(SpeedUnit.MilesPerHour);
        speed.ShouldBe(new Speed(60, SpeedUnit.MilesPerHour));
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var time = new Time(1, TimeUnit.Hours);
        var expected = new Time(2, TimeUnit.Hours);
        (time * 2).ShouldBe(expected);
        (2 * time).ShouldBe(expected);
    }

    [Fact]
    public void OpMultiplicationSpeed() {
        var time = new Time(2, TimeUnit.Hours);
        var speed = new Speed(60, SpeedUnit.MilesPerHour);
        Length length = time * speed;
        length = length.In(LengthUnit.Mile);
        length.ShouldBe(new Length(120, LengthUnit.Mile));
    }

    [Fact]
    public void OpSubtraction() {
        var time1 = new Time(7200, TimeUnit.Second);
        var time2 = new Time(1, TimeUnit.Hours);
        (time1 - time2).ShouldBe(new Time(3600, TimeUnit.Second));
        (time2 - time1).ShouldBe(new Time(-1, TimeUnit.Hours));
    }

}