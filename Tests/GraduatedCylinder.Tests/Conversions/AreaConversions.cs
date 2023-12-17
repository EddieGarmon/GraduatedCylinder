using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class AreaConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(1, AreaUnit.SquareMeter, 1000000, AreaUnit.SquareMilliMeter)]
    [InlineData(1, AreaUnit.SquareMeter, 10000, AreaUnit.SquareCentiMeter)]
    [InlineData(1, AreaUnit.SquareMeter, 0.000001, AreaUnit.SquareKiloMeter)]
    [InlineData(1, AreaUnit.SquareMeter, 1550.0031, AreaUnit.SquareInch)]
    [InlineData(1, AreaUnit.SquareMeter, 10.76391042, AreaUnit.SquareFoot)]
    [InlineData(1, AreaUnit.SquareMeter, 1.19599005, AreaUnit.SquareYard)]
    [InlineData(1, AreaUnit.SquareMeter, 0.000247105381, AreaUnit.Acres)]
    [InlineData(1, AreaUnit.SquareFoot, 144, AreaUnit.SquareInch)]
    public void Conversions(double value1, AreaUnit units1, double value2, AreaUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Area(value, unit));
    }

}