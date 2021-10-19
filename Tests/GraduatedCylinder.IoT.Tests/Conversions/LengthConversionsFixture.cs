using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class LengthConversionsFixture
    {

        [Theory]
        [InlineData(100, LengthUnit.Meter, 328.083989501, LengthUnit.Foot)]
        [InlineData(30.48, LengthUnit.Meter, 1200, LengthUnit.Inch)]
        [InlineData(100.546, LengthUnit.Meter, 0.100545995, LengthUnit.Kilometer)]
        [InlineData(100.546, LengthUnit.Meter, 0.062476385, LengthUnit.Mile)]
        [InlineData(100.546, LengthUnit.Meter, 10054.6, LengthUnit.Centimeter)]
        [InlineData(100.546, LengthUnit.Meter, 1005.45996, LengthUnit.Decimeter)]
        [InlineData(100.546, LengthUnit.Meter, 100545.99, LengthUnit.Millimeter)]
        [InlineData(100.546, LengthUnit.Meter, 0.0542904968, LengthUnit.NauticalMile)]
        [InlineData(100.546, LengthUnit.Meter, 109.958442695, LengthUnit.Yard)]
        [InlineData(100.546, LengthUnit.Meter, 54.97922134733, LengthUnit.Fathom)]
        [InlineData(1769.98, LengthUnit.Kilometer, 1099.814582836236, LengthUnit.Mile)]
        [InlineData(1800.7685, LengthUnit.Mile, 2898.055980864, LengthUnit.Kilometer)]
        public void LengthConversions(float value1, LengthUnit units1, float value2, LengthUnit units2) {
            new Length(value1, units1).In(units2).Value.ShouldBe(value2);
            new Length(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}