#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class SpeedOperators
{

    [Fact]
    public void OpAddition() {
        Speed speed1 = new(3600, SpeedUnit.MetersPerHour);
        Speed speed2 = new(1, SpeedUnit.MetersPerMinute);
        Speed expected = new(3660, SpeedUnit.MetersPerHour);
        (speed1 + speed2).ShouldBe(expected);
        (speed2 + speed1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Speed speed1 = new(3600, SpeedUnit.MetersPerHour);
        Speed speed2 = new(60, SpeedUnit.MetersPerMinute);
        (speed1 / speed2).ShouldBeCloseTo(1);
        (speed2 / speed1).ShouldBeCloseTo(1);

        (speed1 / 2).ShouldBe(new Speed(1800, SpeedUnit.MetersPerHour));
        (speed2 / 2).ShouldBe(new Speed(30, SpeedUnit.MetersPerMinute));
    }

    [Fact]
    public void OpEquals() {
        Speed speed1 = new(3600, SpeedUnit.MetersPerHour);
        Speed speed2 = new(60, SpeedUnit.MetersPerMinute);
        Speed speed3 = new(120, SpeedUnit.MetersPerMinute);
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
        Speed speed1 = new(3600, SpeedUnit.MetersPerHour);
        Speed speed2 = new(60, SpeedUnit.MetersPerMinute);
        Speed speed3 = new(120, SpeedUnit.MetersPerMinute);
        (speed1 > speed3).ShouldBeFalse();
        (speed3 > speed1).ShouldBeTrue();
        (speed1 > speed2).ShouldBeFalse();
        (speed2 > speed1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Speed speed1 = new(3600, SpeedUnit.MetersPerHour);
        Speed speed2 = new(60, SpeedUnit.MetersPerMinute);
        Speed speed3 = new(120, SpeedUnit.MetersPerMinute);
        (speed1 >= speed3).ShouldBeFalse();
        (speed3 >= speed1).ShouldBeTrue();
        (speed1 >= speed2).ShouldBeTrue();
        (speed2 >= speed1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Speed speed1 = new(3600, SpeedUnit.MetersPerHour);
        Speed speed2 = new(60, SpeedUnit.MetersPerMinute);
        Speed speed3 = new(120, SpeedUnit.MetersPerMinute);
        (speed1 != speed2).ShouldBeFalse();
        (speed2 != speed1).ShouldBeFalse();
        (speed1 != speed3).ShouldBeTrue();
        (speed3 != speed1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Speed speed1 = new(3600, SpeedUnit.MetersPerHour);
        Speed speed2 = new(60, SpeedUnit.MetersPerMinute);
        Speed speed3 = new(120, SpeedUnit.MetersPerMinute);
        (speed1 < speed3).ShouldBeTrue();
        (speed3 < speed1).ShouldBeFalse();
        (speed1 < speed2).ShouldBeFalse();
        (speed2 < speed1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Speed speed1 = new(3600, SpeedUnit.MetersPerHour);
        Speed speed2 = new(60, SpeedUnit.MetersPerMinute);
        Speed speed3 = new(120, SpeedUnit.MetersPerMinute);
        (speed1 <= speed3).ShouldBeTrue();
        (speed3 <= speed1).ShouldBeFalse();
        (speed1 <= speed2).ShouldBeTrue();
        (speed2 <= speed1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Speed speed = new(1, SpeedUnit.MilesPerHour);
        Speed expected = new(2, SpeedUnit.MilesPerHour);
        (speed * 2).ShouldBe(expected);
        (2 * speed).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Speed speed1 = new(7200, SpeedUnit.MetersPerHour);
        Speed speed2 = new(60, SpeedUnit.MetersPerMinute);
        (speed1 - speed2).ShouldBe(new Speed(3600, SpeedUnit.MetersPerHour));
        (speed2 - speed1).ShouldBe(new Speed(-60, SpeedUnit.MetersPerMinute));
    }

}