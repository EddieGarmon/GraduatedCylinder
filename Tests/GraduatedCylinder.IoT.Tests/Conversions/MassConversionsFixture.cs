using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class MassConversionsFixture
    {

        [Theory]
        [InlineData(587.5689, MassUnit.Kilogram, 587568.9, MassUnit.Gram)]
        [InlineData(587.5689, MassUnit.Kilogram, 1295.3677, MassUnit.Pounds)]
        [InlineData(587.5689, MassUnit.Kilogram, 18890.777, MassUnit.OuncesTroy)]
        [InlineData(587.5689, MassUnit.Kilogram, 0.5782891, MassUnit.TonsUK)]
        [InlineData(587.5689, MassUnit.Kilogram, 2937844.5, MassUnit.Carats)]
        [InlineData(587.5689, MassUnit.Kilogram, 0.6476838, MassUnit.TonsUS)]
        public void MassConversions(float value1, MassUnit units1, float value2, MassUnit units2) {
            new Mass(value1, units1).In(units2).Value.ShouldBe(value2);
            new Mass(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}