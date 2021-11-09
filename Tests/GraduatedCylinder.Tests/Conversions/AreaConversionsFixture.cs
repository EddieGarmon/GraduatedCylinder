using Xunit;

namespace GraduatedCylinder.Conversions
{
    public class AreaConversionsFixture
    {
        [Theory]
        [InlineData(1, AreaUnit.MeterSquared, 1000000, AreaUnit.MillimeterSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 10000, AreaUnit.CentimeterSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 0.000001, AreaUnit.KilometerSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 1550.0031, AreaUnit.InchSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 10.76391042, AreaUnit.FootSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 1.19599005, AreaUnit.YardSquared)]
        [InlineData(1, AreaUnit.MeterSquared, 0.000247105381, AreaUnit.Acres)]
        [InlineData(10000000, AreaUnit.MeterSquared, 3.8610215854244584726288113937313, AreaUnit.SquareMiles)]
        [InlineData(1, AreaUnit.FootSquared, 144, AreaUnit.InchSquared)]
        public void AreaConversions(double value1, AreaUnit units1, double value2, AreaUnit units2) {
            new Area(value1, units1) {
                Units = units2
            }.Value.ShouldBeWithinToleranceOf(value2);
            new Area(value2, units2) {
                Units = units1
            }.Value.ShouldBeWithinToleranceOf(value1);
        }
    }
}