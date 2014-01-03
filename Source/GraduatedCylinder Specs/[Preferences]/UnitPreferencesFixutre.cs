using Xunit;
using XunitShould;

namespace GraduatedCylinder
{
    public class UnitPreferencesFixture
    {
        [Fact]
        public void SetUnitPreferences() {
            UnitPreferences usPreferences = UnitPreferences.GetAmericanEnglishUnits();

            var time = new Time(3600, TimeUnit.MilliSecond);
            usPreferences.Fix(time);
            time.Units.Abbreviation.ShouldEqual(usPreferences.TimeUnits.Abbreviation);

            var acceleration = new Acceleration(5, AccelerationUnit.KilometerPerSecondSquared);
            usPreferences.Fix(acceleration);
            acceleration.Units.Abbreviation.ShouldEqual(usPreferences.AccelerationUnits.Abbreviation);

            var angle = new Angle(4, AngleUnit.Grad);
            usPreferences.Fix(angle);
            angle.Units.Abbreviation.ShouldEqual(usPreferences.AngleUnits.Abbreviation);

            var angularAcceleration = new AngularAcceleration(3, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            usPreferences.Fix(angularAcceleration);
            angularAcceleration.Units.Abbreviation.ShouldEqual(usPreferences.AngularAccelerationUnits.Abbreviation);

            var area = new Area(10, AreaUnit.SquareMiles);
            usPreferences.Fix(area);
            area.Units.Abbreviation.ShouldEqual(usPreferences.AreaUnits.Abbreviation);
        }
    }
}