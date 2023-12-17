using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class PressureConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(5897.56, PressureUnit.Pascals, 0.85536842471, PressureUnit.PoundsPerSquareInch)]
    [InlineData(5897.56, PressureUnit.Pascals, 1.74174837566, PressureUnit.InchesOfMercury)]
    [InlineData(5897.56, PressureUnit.Pascals, 601.383754901, PressureUnit.KiloGramForcePerSquareMeter)]
    [InlineData(5897.56, PressureUnit.Pascals, 0.0589756, PressureUnit.Bars)]
    [InlineData(5897.56, PressureUnit.Pascals, 5.89756, PressureUnit.KiloPascals)]
    [InlineData(5897.56, PressureUnit.Pascals, 0.00589756, PressureUnit.MegaPascals)]
    [InlineData(5897.56, PressureUnit.Pascals, 58.9756, PressureUnit.MilliBars)]
    [InlineData(5897.56, PressureUnit.Pascals, 5897.56, PressureUnit.NewtonsPerSquareMeter)]
    public void Conversions(double value1, PressureUnit units1, double value2, PressureUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Pressure(value, unit));
    }

}