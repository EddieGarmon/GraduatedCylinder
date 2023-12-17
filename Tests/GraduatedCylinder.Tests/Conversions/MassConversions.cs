using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class MassConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(587.5689, MassUnit.KiloGram, 587568.93750, MassUnit.Gram)]
    [InlineData(587.5689, MassUnit.KiloGram, 1295.367688835, MassUnit.Pounds)]
    [InlineData(587.5689, MassUnit.KiloGram, 18890.7787955075, MassUnit.OuncesTroy)]
    [InlineData(587.5689, MassUnit.KiloGram, 0.578289147, MassUnit.TonsUK)]
    [InlineData(587.5689, MassUnit.KiloGram, 2937844.5, MassUnit.Carats)]
    [InlineData(587.5689, MassUnit.KiloGram, 0.647683844, MassUnit.TonsUS)]
    public void Conversions(double value1, MassUnit units1, double value2, MassUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Mass(value, unit));
    }

}