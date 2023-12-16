#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class EnergyConversionsFixture
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
    public void EnergyConversions(double value1, EnergyUnit units1, double value2, EnergyUnit units2) {
        new Energy(value1, units1).In(units2).ShouldBe(new Energy(value2, units2));
        new Energy(value2, units2).In(units1).ShouldBe(new Energy(value1, units1));
    }

}