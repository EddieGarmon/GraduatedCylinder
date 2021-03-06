using Xunit;

namespace GraduatedCylinder
{
    public class MassConversionsFixture
    {
        [Theory]
        [InlineData(587.5689, MassUnit.Kilogram, 587568.9, MassUnit.Gram)]
        [InlineData(587.5689, MassUnit.Kilogram, 1295.367688835, MassUnit.Pounds)]
        [InlineData(587.5689, MassUnit.Kilogram, 18890.7787955075, MassUnit.OuncesTroy)]
        [InlineData(587.5689, MassUnit.Kilogram, 0.578289147, MassUnit.TonsUK)]
        [InlineData(587.5689, MassUnit.Kilogram, 2937844.5, MassUnit.Carats)]
        [InlineData(587.5689, MassUnit.Kilogram, 0.647683844, MassUnit.TonsUS)]
        public void MassConversions(double value1, MassUnit units1, double value2, MassUnit units2) {
            new Mass(value1, units1) {
                Units = units2
            }.Value.ShouldBeWithinEpsilonOf(value2);
            new Mass(value2, units2) {
                Units = units1
            }.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}