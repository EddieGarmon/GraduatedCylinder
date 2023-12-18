using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class ElectricCurrentConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(45553.6666, ElectricCurrentUnit.Ampere, 45.5536666, ElectricCurrentUnit.KiloAmpere)]
    [InlineData(45553.6666, ElectricCurrentUnit.Ampere, 45553666.6, ElectricCurrentUnit.MilliAmpere)]
    public void Conversions(double value1, ElectricCurrentUnit units1, double value2, ElectricCurrentUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new ElectricCurrent(value, unit));
    }

}