using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class TimeOperators
	{
		[Fact]
		public void OpAddition() {
			Time time1 = new Time(3600, TimeUnit.Seconds);
			Time time2 = new Time(1, TimeUnit.Hours);
			Time expected = new Time(7200, TimeUnit.Seconds);
			(time1 + time2).ShouldEqual(expected, UnitAndValueComparers.Time);
			expected.Units = TimeUnit.Hours;
			(time2 + time1).ShouldEqual(expected, UnitAndValueComparers.Time);
		}

		[Fact]
		public void OpDivision() {
			Time time1 = new Time(3600, TimeUnit.Seconds);
			Time time2 = new Time(1, TimeUnit.Hours);
			(time1 / time2).ShouldBeWithinEpsilonOf(1);
			(time2 / time1).ShouldBeWithinEpsilonOf(1);

			(time1 / 2).ShouldEqual(new Time(1800, TimeUnit.Seconds));
			(time2 / 2).ShouldEqual(new Time(.5, TimeUnit.Hours));
		}

		[Fact]
		public void OpEquals() {
			Time time1 = new Time(3600, TimeUnit.Seconds);
			Time time2 = new Time(1, TimeUnit.Hours);
			Time time3 = new Time(120, TimeUnit.Minutes);
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
			Time time1 = new Time(3600, TimeUnit.Seconds);
			Time time2 = new Time(1, TimeUnit.Hours);
			Time time3 = new Time(120, TimeUnit.Minutes);
			(time1 > time3).ShouldBeFalse();
			(time3 > time1).ShouldBeTrue();
			(time1 > time2).ShouldBeFalse();
			(time2 > time1).ShouldBeFalse();
		}

		[Fact]
		public void OpGreaterThanOrEqual() {
			Time time1 = new Time(3600, TimeUnit.Seconds);
			Time time2 = new Time(1, TimeUnit.Hours);
			Time time3 = new Time(120, TimeUnit.Minutes);
			(time1 >= time3).ShouldBeFalse();
			(time3 >= time1).ShouldBeTrue();
			(time1 >= time2).ShouldBeTrue();
			(time2 >= time1).ShouldBeTrue();
		}

		[Fact]
		public void OpInverseEquals() {
			Time time1 = new Time(3600, TimeUnit.Seconds);
			Time time2 = new Time(1, TimeUnit.Hours);
			Time time3 = new Time(120, TimeUnit.Minutes);
			(time1 != time2).ShouldBeFalse();
			(time2 != time1).ShouldBeFalse();
			(time1 != time3).ShouldBeTrue();
			(time3 != time1).ShouldBeTrue();
		}

		[Fact]
		public void OpLessThan() {
			Time time1 = new Time(3600, TimeUnit.Seconds);
			Time time2 = new Time(1, TimeUnit.Hours);
			Time time3 = new Time(120, TimeUnit.Minutes);
			(time1 < time3).ShouldBeTrue();
			(time3 < time1).ShouldBeFalse();
			(time1 < time2).ShouldBeFalse();
			(time2 < time1).ShouldBeFalse();
		}

		[Fact]
		public void OpLessThanOrEqual() {
			Time time1 = new Time(3600, TimeUnit.Seconds);
			Time time2 = new Time(1, TimeUnit.Hours);
			Time time3 = new Time(120, TimeUnit.Minutes);
			(time1 <= time3).ShouldBeTrue();
			(time3 <= time1).ShouldBeFalse();
			(time1 <= time2).ShouldBeTrue();
			(time2 <= time1).ShouldBeTrue();
		}

		[Fact]
		public void OpMultiplicationAcceleration() {
			Speed speedBase = new Time(20, TimeUnit.Seconds) * new Acceleration(3, AccelerationUnit.MetersPerSecondSquared);
			speedBase.ShouldEqual(new Speed(60, SpeedUnit.MetersPerSecond), UnitAndValueComparers.Speed);

			Time time = new Time(1, TimeUnit.Minutes);
			Acceleration acceleration = new Acceleration(1, AccelerationUnit.MilesPerHourPerSecond);
			Speed speed = time * acceleration;
			speed.Units = SpeedUnit.MilesPerHour;
			speed.ShouldEqual(new Speed(60, SpeedUnit.MilesPerHour), UnitAndValueComparers.Speed);
		}

		[Fact]
		public void OpMultiplicationScaler() {
			Time time = new Time(1, TimeUnit.Hours);
			Time expected = new Time(2, TimeUnit.Hours);
			(time * 2).ShouldEqual(expected, UnitAndValueComparers.Time);
			(2 * time).ShouldEqual(expected, UnitAndValueComparers.Time);
		}

		[Fact]
		public void OpMultiplicationSpeed() {
			Time time = new Time(2, TimeUnit.Hours);
			Speed speed = new Speed(60, SpeedUnit.MilesPerHour);
			Length length = time * speed;
			length.Units = LengthUnit.Miles;
			length.ShouldEqual(new Length(120, LengthUnit.Miles));
		}

		[Fact]
		public void OpSubtraction() {
			Time time1 = new Time(7200, TimeUnit.Seconds);
			Time time2 = new Time(1, TimeUnit.Hours);
			(time1 - time2).ShouldEqual(new Time(3600, TimeUnit.Seconds), UnitAndValueComparers.Time);
			(time2 - time1).ShouldEqual(new Time(-1, TimeUnit.Hours), UnitAndValueComparers.Time);
		}

		//todo: finish all operators
	}
}