using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class JerkConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(100.476, JerkUnit.MetersPerSecondCubed, 0.100476, JerkUnit.KiloMetersPerSecondCubed)]
    [InlineData(134.567, JerkUnit.MetersPerSecondCubed, 0.0836160572, JerkUnit.MilesPerSecondCubed)]
    [InlineData(1678.98, JerkUnit.KiloMetersPerSecondCubed, 1043.26980434, JerkUnit.MilesPerSecondCubed)]
    public void Conversions(double value1, JerkUnit units1, double value2, JerkUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Jerk(value, unit));
    }

}