using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class ElectricPotentialConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(15555.65, ElectricPotentialUnit.Volt, 15.55565, ElectricPotentialUnit.KiloVolt)]
    [InlineData(155.6555, ElectricPotentialUnit.Volt, 155655.5, ElectricPotentialUnit.MilliVolt)]
    public void Conversions(double value1, ElectricPotentialUnit units1, double value2, ElectricPotentialUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new ElectricPotential(value, unit));
    }

}