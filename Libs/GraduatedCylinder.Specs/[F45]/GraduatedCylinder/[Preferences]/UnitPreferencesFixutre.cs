using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class UnitPreferencesFixture
	{
		[Fact]
		public void SetUnitPreferences() {
			UnitPreferences usPreferences = UnitPreferences.GetAmericanEnglishUnits();

			Time time = new Time(3600, TimeUnit.MilliSecond);
			usPreferences.Fix(time);
			time.Units.Abbreviation.ShouldEqual(usPreferences.TimeUnits.Abbreviation);

			Acceleration acceleration = new Acceleration(5, AccelerationUnit.KilometersPerSecondSquared);
			usPreferences.Fix(acceleration);
			acceleration.Units.Abbreviation.ShouldEqual(usPreferences.AccelerationUnits.Abbreviation);

			Angle angle = new Angle(4, AngleUnit.Grads);
			usPreferences.Fix(angle);
			angle.Units.Abbreviation.ShouldEqual(usPreferences.AngleUnits.Abbreviation);

			AngularAcceleration angularAcceleration = new AngularAcceleration(3, AngularAccelerationUnit.RevolutionsPerSecondSquared);
			usPreferences.Fix(angularAcceleration);
			angularAcceleration.Units.Abbreviation.ShouldEqual(usPreferences.AngularAccelerationUnits.Abbreviation);

			Area area = new Area(10, AreaUnit.SquareMiles);
			usPreferences.Fix(area);
			area.Units.Abbreviation.ShouldEqual(usPreferences.AreaUnits.Abbreviation);
		}
	}
}