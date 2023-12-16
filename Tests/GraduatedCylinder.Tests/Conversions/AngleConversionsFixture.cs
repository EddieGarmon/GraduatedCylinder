#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class AngleConversionsFixture
{

    [Theory]
    [InlineData(75, AngleUnit.Degree, 1.3089969, AngleUnit.Radian)]
    [InlineData(75, AngleUnit.Degree, 1308.99693, AngleUnit.MilliRadian)]
    [InlineData(75, AngleUnit.Degree, 1308996.93899, AngleUnit.MicroRadian)]
    [InlineData(75, AngleUnit.Degree, 83.33333, AngleUnit.Grad)]
    public void AngleConversions(double value1, AngleUnit units1, double value2, AngleUnit units2) {
        new Angle(value1, units1).In(units2).ShouldBe(new Angle(value2, units2));
        new Angle(value2, units2).In(units1).ShouldBe(new Angle(value1, units1));
    }

}