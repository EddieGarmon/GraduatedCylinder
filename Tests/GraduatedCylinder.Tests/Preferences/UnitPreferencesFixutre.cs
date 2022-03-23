using DigitalHammer.Testing;
using GraduatedCylinder.Text;
using Xunit;

namespace GraduatedCylinder.Preferences;

public class UnitPreferencesFixture
{

    [Fact]
    public void SetUnitPreferences() {
        UnitPreferences usPreferences = UnitPreferences.GetAmericanEnglishUnits();

        var time = new Time(3600, TimeUnit.MilliSecond);
        usPreferences.Fix(ref time);
        time.Units.GetAbbreviation().ShouldBe(usPreferences.TimeUnit.GetAbbreviation());

        var acceleration = new Acceleration(5, AccelerationUnit.KiloMeterPerSquareSecond);
        usPreferences.Fix(ref acceleration);
        acceleration.Units.GetAbbreviation().ShouldBe(usPreferences.AccelerationUnit.GetAbbreviation());

        var angle = new Angle(4, AngleUnit.Grad);
        usPreferences.Fix(ref angle);
        angle.Units.GetAbbreviation().ShouldBe(usPreferences.AngleUnit.GetAbbreviation());

        var angularAcceleration = new AngularAcceleration(3, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        usPreferences.Fix(ref angularAcceleration);
        angularAcceleration.Units.GetAbbreviation().ShouldBe(usPreferences.AngularAccelerationUnit.GetAbbreviation());

        var area = new Area(10, AreaUnit.SquareMiles);
        usPreferences.Fix(ref area);
        area.Units.GetAbbreviation().ShouldBe(usPreferences.AreaUnit.GetAbbreviation());
    }

}