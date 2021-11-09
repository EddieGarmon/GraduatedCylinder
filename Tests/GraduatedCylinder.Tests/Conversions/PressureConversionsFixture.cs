using Xunit;

namespace GraduatedCylinder.Conversions
{
    public class PressureConversionsFixture
    {
        [Theory]
        [InlineData(5897.56, PressureUnit.Pascals, 0.85536842471, PressureUnit.PoundsPerSquareInch)]
        [InlineData(5897.56, PressureUnit.Pascals, 1.74174837566, PressureUnit.InchesOfMercury)]
        [InlineData(5897.56, PressureUnit.Pascals, 601.383754901, PressureUnit.KilogramForcePerSquareMeter)]
        [InlineData(5897.56, PressureUnit.Pascals, 0.0589756, PressureUnit.Bars)]
        [InlineData(5897.56, PressureUnit.Pascals, 5.89756, PressureUnit.KiloPascals)]
        [InlineData(5897.56, PressureUnit.Pascals, 0.00589756, PressureUnit.MegaPascals)]
        [InlineData(5897.56, PressureUnit.Pascals, 58.9756, PressureUnit.MilliBars)]
        [InlineData(5897.56, PressureUnit.Pascals, 5897.56, PressureUnit.NewtonsPerSquareMeter)]
        public void PressureConversions(double value1, PressureUnit units1, double value2, PressureUnit units2) {
            new Pressure(value1, units1) {
                Units = units2
            }.Value.ShouldBeWithinToleranceOf(value2);
            new Pressure(value2, units2) {
                Units = units1
            }.Value.ShouldBeWithinToleranceOf(value1);
        }
    }
}