using Xunit;

namespace GraduatedCylinder.Conversions
{
    public class EnergyConversionsFixture
    {
        [Theory]
        [InlineData(1000.345, EnergyUnit.Joules, 238.928298462, EnergyUnit.Calories)]
        [InlineData(1000.345, EnergyUnit.Joules, 0.2389282985, EnergyUnit.KiloCalories)]
        [InlineData(1000.345, EnergyUnit.Joules, 102.0068015071, EnergyUnit.KilogramForceMeters)]
        [InlineData(1000.345, EnergyUnit.Joules, 1.000345, EnergyUnit.Kilojoules)]
        [InlineData(1000.345, EnergyUnit.Joules, 0.000277873611111, EnergyUnit.KilowattHours)]
        [InlineData(1000.345, EnergyUnit.Joules, 1000.345, EnergyUnit.NewtonMeters)]
        [InlineData(1000.345, EnergyUnit.Joules, 0.2778736111, EnergyUnit.WattHours)]
        [InlineData(1000.345, EnergyUnit.Joules, 1000.345, EnergyUnit.WattSeconds)]
        public void EnergyConversions(double value1, EnergyUnit units1, double value2, EnergyUnit units2) {
            new Energy(value1, units1) {
                Units = units2
            }.Value.ShouldBeWithinToleranceOf(value2);
            new Energy(value2, units2) {
                Units = units1
            }.Value.ShouldBeWithinToleranceOf(value1);
        }
    }
}