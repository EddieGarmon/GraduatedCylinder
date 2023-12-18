#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class TimeOperators
{

    [Fact]
    public void OpAddition() {
        Time time1 = new(3600, TimeUnit.Second);
        Time time2 = new(1, TimeUnit.Hours);
        Time expected = new(7200, TimeUnit.Second);
        (time1 + time2).ShouldBe(expected);
        (time2 + time1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Time time1 = new(3600, TimeUnit.Second);
        Time time2 = new(1, TimeUnit.Hours);
        (time1 / time2).ShouldBeCloseTo(1);
        (time2 / time1).ShouldBeCloseTo(1);

        (time1 / 2).ShouldBe(new Time(1800, TimeUnit.Second));
        (time2 / 2).ShouldBe(new Time(.5, TimeUnit.Hours));
    }

    [Fact]
    public void OpEquals() {
        Time time1 = new(3600, TimeUnit.Second);
        Time time2 = new(1, TimeUnit.Hours);
        Time time3 = new(120, TimeUnit.Minutes);
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
        Time time1 = new(3600, TimeUnit.Second);
        Time time2 = new(1, TimeUnit.Hours);
        Time time3 = new(120, TimeUnit.Minutes);
        (time1 > time3).ShouldBeFalse();
        (time3 > time1).ShouldBeTrue();
        (time1 > time2).ShouldBeFalse();
        (time2 > time1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Time time1 = new(3600, TimeUnit.Second);
        Time time2 = new(1, TimeUnit.Hours);
        Time time3 = new(120, TimeUnit.Minutes);
        (time1 >= time3).ShouldBeFalse();
        (time3 >= time1).ShouldBeTrue();
        (time1 >= time2).ShouldBeTrue();
        (time2 >= time1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Time time1 = new(3600, TimeUnit.Second);
        Time time2 = new(1, TimeUnit.Hours);
        Time time3 = new(120, TimeUnit.Minutes);
        (time1 != time2).ShouldBeFalse();
        (time2 != time1).ShouldBeFalse();
        (time1 != time3).ShouldBeTrue();
        (time3 != time1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Time time1 = new(3600, TimeUnit.Second);
        Time time2 = new(1, TimeUnit.Hours);
        Time time3 = new(120, TimeUnit.Minutes);
        (time1 < time3).ShouldBeTrue();
        (time3 < time1).ShouldBeFalse();
        (time1 < time2).ShouldBeFalse();
        (time2 < time1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Time time1 = new(3600, TimeUnit.Second);
        Time time2 = new(1, TimeUnit.Hours);
        Time time3 = new(120, TimeUnit.Minutes);
        (time1 <= time3).ShouldBeTrue();
        (time3 <= time1).ShouldBeFalse();
        (time1 <= time2).ShouldBeTrue();
        (time2 <= time1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationAcceleration() {
        Speed speedBase = new Time(20, TimeUnit.Second) * new Acceleration(3, AccelerationUnit.MeterPerSquareSecond);
        speedBase.ShouldBe(new Speed(60, SpeedUnit.MeterPerSecond));

        Time time = new(1, TimeUnit.Minutes);
        Acceleration acceleration = new(1, AccelerationUnit.MilePerHourPerSecond);
        Speed speed = time * acceleration;
        speed = speed.In(SpeedUnit.MilesPerHour);
        speed.ShouldBe(new Speed(60, SpeedUnit.MilesPerHour));
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Time time = new(1, TimeUnit.Hours);
        Time expected = new(2, TimeUnit.Hours);
        (time * 2).ShouldBe(expected);
        (2 * time).ShouldBe(expected);
    }

    [Fact]
    public void OpMultiplicationSpeed() {
        Time time = new(2, TimeUnit.Hours);
        Speed speed = new(60, SpeedUnit.MilesPerHour);
        Length length = time * speed;
        length = length.In(LengthUnit.Mile);
        length.ShouldBe(new Length(120, LengthUnit.Mile));
    }

    [Fact]
    public void OpSubtraction() {
        Time time1 = new(7200, TimeUnit.Second);
        Time time2 = new(1, TimeUnit.Hours);
        (time1 - time2).ShouldBe(new Time(3600, TimeUnit.Second));
        (time2 - time1).ShouldBe(new Time(-1, TimeUnit.Hours));
    }

}