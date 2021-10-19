using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class AreaConversionsFixture
    {

        [Theory]
        [InlineData(1, AreaUnit.MeterSquared, 1000000, AreaUnit.MillimeterSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 10000, AreaUnit.CentimeterSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 0.000001, AreaUnit.KilometerSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 1550.0032, AreaUnit.InchSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 10.76391042, AreaUnit.FootSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 1.1959902, AreaUnit.YardSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 0.0002471054, AreaUnit.Acres)]
        [InlineData(10000000, AreaUnit.MeterSquared, 3.8610218, AreaUnit.SquareMiles)]
        [InlineData(0.99999994, AreaUnit.FootSquared, 144, AreaUnit.InchSquared)]
        public void AreaConversions(float value1, AreaUnit units1, float value2, AreaUnit units2) {
            new Area(value1, units1).In(units2).Value.ShouldBe(value2);
            new Area(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}