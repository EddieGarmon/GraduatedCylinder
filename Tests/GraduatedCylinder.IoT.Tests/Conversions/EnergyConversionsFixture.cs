using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class EnergyConversionsFixture
    {

        [Theory]
        [InlineData(1000.3449, EnergyUnit.Joules, 238.92828, EnergyUnit.Calories)]
        [InlineData(1000.345, EnergyUnit.Joules, 0.2389282985, EnergyUnit.KiloCalories)]
        [InlineData(1000.345, EnergyUnit.Joules, 102.0068015071, EnergyUnit.KilogramForceMeters)]
        [InlineData(1000.345, EnergyUnit.Joules, 1.000345, EnergyUnit.Kilojoules)]
        [InlineData(1000.3449, EnergyUnit.Joules, 0.0002778736, EnergyUnit.KilowattHours)]
        [InlineData(1000.345, EnergyUnit.Joules, 1000.345, EnergyUnit.NewtonMeters)]
        [InlineData(1000.345, EnergyUnit.Joules, 0.2778736111, EnergyUnit.WattHours)]
        [InlineData(1000.345, EnergyUnit.Joules, 1000.345, EnergyUnit.WattSeconds)]
        public void EnergyConversions(float value1, EnergyUnit units1, float value2, EnergyUnit units2) {
            new Energy(value1, units1).In(units2).Value.ShouldBe(value2);
            new Energy(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}