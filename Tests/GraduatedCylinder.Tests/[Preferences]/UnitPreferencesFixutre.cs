using DigitalHammer.Testing;
using GraduatedCylinder.Text;
using Xunit;

namespace GraduatedCylinder
{
    public class UnitPreferencesFixture
    {

        [Fact]
        public void SetUnitPreferences() {
            UnitPreferences usPreferences = UnitPreferences.GetAmericanEnglishUnits();

            var time = new Time(3600, TimeUnit.MilliSecond);
            usPreferences.Fix(time);
            time.Units.GetAbbreviation().ShouldBe(usPreferences.TimeUnit.GetAbbreviation());

            var acceleration = new Acceleration(5, AccelerationUnit.KilometerPerSecondSquared);
            usPreferences.Fix(acceleration);
            acceleration.Units.GetAbbreviation().ShouldBe(usPreferences.AccelerationUnit.GetAbbreviation());

            var angle = new Angle(4, AngleUnit.Grad);
            usPreferences.Fix(angle);
            angle.Units.GetAbbreviation().ShouldBe(usPreferences.AngleUnit.GetAbbreviation());

            var angularAcceleration = new AngularAcceleration(3, AngularAccelerationUnit.RevolutionsPerSecondSquared);
            usPreferences.Fix(angularAcceleration);
            angularAcceleration.Units.GetAbbreviation()
                               .ShouldBe(usPreferences.AngularAccelerationUnit.GetAbbreviation());

            var area = new Area(10, AreaUnit.SquareMiles);
            usPreferences.Fix(area);
            area.Units.GetAbbreviation().ShouldBe(usPreferences.AreaUnit.GetAbbreviation());
        }

    }
}