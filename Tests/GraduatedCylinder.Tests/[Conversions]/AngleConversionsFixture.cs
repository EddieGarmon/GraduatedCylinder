using Xunit;

namespace GraduatedCylinder
{
    public class AngleConversionsFixture
    {
        [Theory]
        [InlineData(75, AngleUnit.Degree, 1.3089969, AngleUnit.Radian)]
        [InlineData(75, AngleUnit.Degree, 1308.99693, AngleUnit.Milliradian)]
        [InlineData(75, AngleUnit.Degree, 1308996.93899, AngleUnit.Microradian)]
        [InlineData(75, AngleUnit.Degree, 83.33333, AngleUnit.Grad)]
        public void AngleConversions(double value1, AngleUnit units1, double value2, AngleUnit units2) {
            new Angle(value1, units1) {
                Units = units2
            }.Value.ShouldBeWithinEpsilonOf(value2);
            new Angle(value2, units2) {
                Units = units1
            }.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}