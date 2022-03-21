using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class SpeedOperators
{

    [Fact]
    public void OpAddition() {
        var speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
        var speed2 = new Speed(1, SpeedUnit.MetersPerMinute);
        var expected = new Speed(3660, SpeedUnit.MetersPerHour);
        (speed1 + speed2).ShouldBe(expected);
        (speed2 + speed1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
        var speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
        (speed1 / speed2).ShouldBeCloseTo(1);
        (speed2 / speed1).ShouldBeCloseTo(1);

        (speed1 / 2).ShouldBe(new Speed(1800, SpeedUnit.MetersPerHour));
        (speed2 / 2).ShouldBe(new Speed(30, SpeedUnit.MetersPerMinute));
    }

    [Fact]
    public void OpEquals() {
        var speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
        var speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
        var speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
        (speed1 == speed2).ShouldBeTrue();
        (speed2 == speed1).ShouldBeTrue();
        (speed1 == speed3).ShouldBeFalse();
        (speed3 == speed1).ShouldBeFalse();
        speed1.Equals(speed2).ShouldBeTrue();
        speed1.Equals((object)speed2).ShouldBeTrue();
        speed2.Equals(speed1).ShouldBeTrue();
        speed2.Equals((object)speed1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        var speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
        var speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
        var speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
        (speed1 > speed3).ShouldBeFalse();
        (speed3 > speed1).ShouldBeTrue();
        (speed1 > speed2).ShouldBeFalse();
        (speed2 > speed1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
        var speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
        var speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
        (speed1 >= speed3).ShouldBeFalse();
        (speed3 >= speed1).ShouldBeTrue();
        (speed1 >= speed2).ShouldBeTrue();
        (speed2 >= speed1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
        var speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
        var speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
        (speed1 != speed2).ShouldBeFalse();
        (speed2 != speed1).ShouldBeFalse();
        (speed1 != speed3).ShouldBeTrue();
        (speed3 != speed1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
        var speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
        var speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
        (speed1 < speed3).ShouldBeTrue();
        (speed3 < speed1).ShouldBeFalse();
        (speed1 < speed2).ShouldBeFalse();
        (speed2 < speed1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
        var speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
        var speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
        (speed1 <= speed3).ShouldBeTrue();
        (speed3 <= speed1).ShouldBeFalse();
        (speed1 <= speed2).ShouldBeTrue();
        (speed2 <= speed1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var speed = new Speed(1, SpeedUnit.MilesPerHour);
        var expected = new Speed(2, SpeedUnit.MilesPerHour);
        (speed * 2).ShouldBe(expected);
        (2 * speed).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var speed1 = new Speed(7200, SpeedUnit.MetersPerHour);
        var speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
        (speed1 - speed2).ShouldBe(new Speed(3600, SpeedUnit.MetersPerHour));
        (speed2 - speed1).ShouldBe(new Speed(-60, SpeedUnit.MetersPerMinute));
    }

}