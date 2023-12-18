using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class EnergyConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(1000.345, EnergyUnit.Joules, 238.928298462, EnergyUnit.Calories)]
    [InlineData(1000.345, EnergyUnit.Joules, 0.2389282985, EnergyUnit.KiloCalories)]
    [InlineData(1000.345, EnergyUnit.Joules, 102.0068015071, EnergyUnit.KiloGramForceMeters)]
    [InlineData(1000.345, EnergyUnit.Joules, 1.000345, EnergyUnit.KiloJoules)]
    [InlineData(1000.345, EnergyUnit.Joules, 0.000277873611111, EnergyUnit.KiloWattHours)]
    [InlineData(1000.345, EnergyUnit.Joules, 1000.345, EnergyUnit.NewtonMeters)]
    [InlineData(1000.345, EnergyUnit.Joules, 0.2778736111, EnergyUnit.WattHours)]
    [InlineData(1000.345, EnergyUnit.Joules, 1000.345, EnergyUnit.WattSeconds)]
    public void Conversions(double value1, EnergyUnit units1, double value2, EnergyUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Energy(value, unit));
    }

}