using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class TorqueConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(156.758, TorqueUnit.NewtonMeters, 15.9794087666, TorqueUnit.KiloGramForceMeters)]
    [InlineData(156.789, TorqueUnit.NewtonMeters, 115.64163168071347631885239460062, TorqueUnit.FootPounds)]
    [InlineData(1678.254, TorqueUnit.KiloGramForceMeters, 12142.9810986054, TorqueUnit.FootPounds)]
    public void Conversions(double value1, TorqueUnit units1, double value2, TorqueUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Torque(value, unit));
    }

}