using Xunit.Theories;

namespace GraduatedCylinder
{
    public class LengthConversionsFixture
    {
        [Theory]
        [InlineData(100, LengthUnit.Meters, 328.083989501, LengthUnit.Feet)]
        [InlineData(30.48, LengthUnit.Meters, 1200, LengthUnit.Inches)]
        [InlineData(100.546, LengthUnit.Meters, 0.100546, LengthUnit.Kilometers)]
        [InlineData(100.546, LengthUnit.Meters, 0.062476387894694981309154537500994, LengthUnit.Miles)]
        [InlineData(100.546, LengthUnit.Meters, 10054.6, LengthUnit.Centimeters)]
        [InlineData(100.546, LengthUnit.Meters, 1005.46, LengthUnit.Decimeters)]
        [InlineData(100.546, LengthUnit.Meters, 100546, LengthUnit.Millimeters)]
        [InlineData(100.546, LengthUnit.Meters, 0.0542904968, LengthUnit.NauticalMiles)]
        [InlineData(100.546, LengthUnit.Meters, 109.958442695, LengthUnit.Yards)]
        [InlineData(100.546, LengthUnit.Meters, 54.97922134733, LengthUnit.Fathoms)]
        [InlineData(1769.98, LengthUnit.Kilometers, 1099.814582836236, LengthUnit.Miles)]
        [InlineData(1800.7685, LengthUnit.Miles, 2898.055980864, LengthUnit.Kilometers)]
        public void LengthConversions(double value1, LengthUnit units1, double value2, LengthUnit units2) {
            new Length(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
            new Length(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}