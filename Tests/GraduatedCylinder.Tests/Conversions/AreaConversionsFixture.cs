using Xunit;

namespace GraduatedCylinder.Conversions;

public class AreaConversionsFixture
{

    [Theory]
    [InlineData(1, AreaUnit.SquareMeter, 1000000, AreaUnit.SquareMillimeter)]
    [InlineData(1, AreaUnit.SquareMeter, 10000, AreaUnit.SquareCentimeter)]
    [InlineData(1, AreaUnit.SquareMeter, 0.000001, AreaUnit.SquareKilometer)]
    [InlineData(1, AreaUnit.SquareMeter, 1550.0031, AreaUnit.SquareInch)]
    [InlineData(1, AreaUnit.SquareMeter, 10.76391042, AreaUnit.SquareFoot)]
    [InlineData(1, AreaUnit.SquareMeter, 1.19599005, AreaUnit.SquareYard)]
    [InlineData(1, AreaUnit.SquareMeter, 0.000247105381, AreaUnit.Acres)]
    [InlineData(10000000, AreaUnit.SquareMeter, 3.8610215854244584726288113937313, AreaUnit.SquareMiles)]
    [InlineData(1, AreaUnit.SquareFoot, 144, AreaUnit.SquareInch)]
    public void AreaConversions(double value1, AreaUnit units1, double value2, AreaUnit units2) {
        new Area(value1, units1).In(units2).Value.ShouldBeWithinToleranceOf(value2);
        new Area(value2, units2).In(units1).Value.ShouldBeWithinToleranceOf(value1);
    }

}