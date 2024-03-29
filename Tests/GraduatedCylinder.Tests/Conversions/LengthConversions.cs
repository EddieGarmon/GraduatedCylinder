using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class LengthConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(100, LengthUnit.Meter, 328.083989501, LengthUnit.Foot)]
    [InlineData(30.48, LengthUnit.Meter, 1200, LengthUnit.Inch)]
    [InlineData(100.546, LengthUnit.Meter, 0.100546, LengthUnit.KiloMeter)]
    [InlineData(100.546, LengthUnit.Meter, 0.062476387894694981309154537500994, LengthUnit.Mile)]
    [InlineData(100.546, LengthUnit.Meter, 10054.6, LengthUnit.CentiMeter)]
    [InlineData(100.546, LengthUnit.Meter, 1005.46, LengthUnit.DeciMeter)]
    [InlineData(100.546, LengthUnit.Meter, 100546, LengthUnit.MilliMeter)]
    [InlineData(100.546, LengthUnit.Meter, 0.0542904968, LengthUnit.NauticalMile)]
    [InlineData(100.546, LengthUnit.Meter, 109.958442695, LengthUnit.Yard)]
    [InlineData(100.546, LengthUnit.Meter, 54.97922134733, LengthUnit.Fathom)]
    [InlineData(1769.98, LengthUnit.KiloMeter, 1099.814582836236, LengthUnit.Mile)]
    [InlineData(1800.7685, LengthUnit.Mile, 2898.055980864, LengthUnit.KiloMeter)]
    public void Conversions(double value1, LengthUnit units1, double value2, LengthUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Length(value, unit));
    }

}