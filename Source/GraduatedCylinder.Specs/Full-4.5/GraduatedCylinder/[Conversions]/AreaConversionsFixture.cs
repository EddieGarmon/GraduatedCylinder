using Xunit.Theories;

namespace GraduatedCylinder
{
    public class AreaConversionsFixture
    {
        [Theory]
        [InlineData(1, AreaUnit.SquareMeters, 1000000, AreaUnit.SquareMillimeters)]
        [InlineData(1, AreaUnit.SquareMeters, 10000, AreaUnit.SquareCentimeters)]
        [InlineData(1, AreaUnit.SquareMeters, 0.000001, AreaUnit.SquareKilometers)]
        [InlineData(1, AreaUnit.SquareMeters, 1550.0031, AreaUnit.SquareInches)]
        [InlineData(1, AreaUnit.SquareMeters, 10.76391042, AreaUnit.SquareFeet)]
        [InlineData(1, AreaUnit.SquareMeters, 1.19599005, AreaUnit.SquareYards)]
        [InlineData(1, AreaUnit.SquareMeters, 0.000247105381, AreaUnit.Acres)]
        [InlineData(10000000, AreaUnit.SquareMeters, 3.8610215854244584726288113937313, AreaUnit.SquareMiles)]
        [InlineData(1, AreaUnit.SquareFeet, 144, AreaUnit.SquareInches)]
        public void AreaConversions(double value1, AreaUnit units1, double value2, AreaUnit units2) {
            new Area(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
            new Area(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}