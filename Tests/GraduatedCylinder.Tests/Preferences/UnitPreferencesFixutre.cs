#if GraduatedCylinder
namespace GraduatedCylinder.Preferences;
#endif
#if Pipette
namespace Pipette.Preferences;
#endif

public class UnitPreferencesFixture
{

    [Fact]
    public void SetUnitPreferences() {
        UnitPreferences usPreferences = UnitPreferences.GetAmericanEnglishUnits();

        Time time = new(3600, TimeUnit.MilliSecond);
        usPreferences.Fix(ref time);
        time.Units.GetAbbreviation().ShouldBe(usPreferences.TimeUnit.GetAbbreviation());

        Acceleration acceleration = new(5, AccelerationUnit.KiloMeterPerSquareSecond);
        usPreferences.Fix(ref acceleration);
        acceleration.Units.GetAbbreviation().ShouldBe(usPreferences.AccelerationUnit.GetAbbreviation());

        Angle angle = new(4, AngleUnit.Grad);
        usPreferences.Fix(ref angle);
        angle.Units.GetAbbreviation().ShouldBe(usPreferences.AngleUnit.GetAbbreviation());

        AngularAcceleration angularAcceleration = new(3, AngularAccelerationUnit.RevolutionsPerSquareSecond);
        usPreferences.Fix(ref angularAcceleration);
        angularAcceleration.Units.GetAbbreviation().ShouldBe(usPreferences.AngularAccelerationUnit.GetAbbreviation());

        Area area = new(10, AreaUnit.SquareMiles);
        usPreferences.Fix(ref area);
        area.Units.GetAbbreviation().ShouldBe(usPreferences.AreaUnit.GetAbbreviation());
    }

}