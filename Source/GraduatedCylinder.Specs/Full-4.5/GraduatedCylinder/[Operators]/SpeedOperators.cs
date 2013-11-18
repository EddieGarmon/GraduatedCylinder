using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class SpeedOperators
    {
        [Fact]
        public void OpAddition() {
            Speed speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
            Speed speed2 = new Speed(1, SpeedUnit.MetersPerMinute);
            Speed expected = new Speed(3660, SpeedUnit.MetersPerHour);
            (speed1 + speed2).ShouldEqual(expected, UnitAndValueComparers.Speed);
            expected.Units = SpeedUnit.MetersPerMinute;
            (speed2 + speed1).ShouldEqual(expected, UnitAndValueComparers.Speed);
        }

        [Fact]
        public void OpDivision() {
            Speed speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
            Speed speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
            (speed1 / speed2).ShouldBeWithinEpsilonOf(1);
            (speed2 / speed1).ShouldBeWithinEpsilonOf(1);

            (speed1 / 2).ShouldEqual(new Speed(1800, SpeedUnit.MetersPerHour));
            (speed2 / 2).ShouldEqual(new Speed(30, SpeedUnit.MetersPerMinute));
        }

        [Fact]
        public void OpEquals() {
            Speed speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
            Speed speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
            Speed speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
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
            Speed speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
            Speed speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
            Speed speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
            (speed1 > speed3).ShouldBeFalse();
            (speed3 > speed1).ShouldBeTrue();
            (speed1 > speed2).ShouldBeFalse();
            (speed2 > speed1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            Speed speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
            Speed speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
            Speed speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
            (speed1 >= speed3).ShouldBeFalse();
            (speed3 >= speed1).ShouldBeTrue();
            (speed1 >= speed2).ShouldBeTrue();
            (speed2 >= speed1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            Speed speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
            Speed speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
            Speed speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
            (speed1 != speed2).ShouldBeFalse();
            (speed2 != speed1).ShouldBeFalse();
            (speed1 != speed3).ShouldBeTrue();
            (speed3 != speed1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            Speed speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
            Speed speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
            Speed speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
            (speed1 < speed3).ShouldBeTrue();
            (speed3 < speed1).ShouldBeFalse();
            (speed1 < speed2).ShouldBeFalse();
            (speed2 < speed1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            Speed speed1 = new Speed(3600, SpeedUnit.MetersPerHour);
            Speed speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
            Speed speed3 = new Speed(120, SpeedUnit.MetersPerMinute);
            (speed1 <= speed3).ShouldBeTrue();
            (speed3 <= speed1).ShouldBeFalse();
            (speed1 <= speed2).ShouldBeTrue();
            (speed2 <= speed1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            Speed speed = new Speed(1, SpeedUnit.MilesPerHour);
            Speed expected = new Speed(2, SpeedUnit.MilesPerHour);
            (speed * 2).ShouldEqual(expected, UnitAndValueComparers.Speed);
            (2 * speed).ShouldEqual(expected, UnitAndValueComparers.Speed);
        }

        [Fact]
        public void OpSubtraction() {
            Speed speed1 = new Speed(7200, SpeedUnit.MetersPerHour);
            Speed speed2 = new Speed(60, SpeedUnit.MetersPerMinute);
            (speed1 - speed2).ShouldEqual(new Speed(3600, SpeedUnit.MetersPerHour), UnitAndValueComparers.Speed);
            (speed2 - speed1).ShouldEqual(new Speed(-60, SpeedUnit.MetersPerMinute), UnitAndValueComparers.Speed);
        }
    }
}