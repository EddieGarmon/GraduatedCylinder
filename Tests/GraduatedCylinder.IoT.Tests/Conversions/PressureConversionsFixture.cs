using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class PressureConversionsFixture
    {

        [Theory]
        [InlineData(5897.56, PressureUnit.Pascals, 0.85536842471, PressureUnit.PoundsPerSquareInch)]
        [InlineData(5897.56, PressureUnit.Pascals, 1.7417485, PressureUnit.InchesOfMercury)]
        [InlineData(5897.56, PressureUnit.Pascals, 601.383754901, PressureUnit.KilogramForcePerSquareMeter)]
        [InlineData(5897.56, PressureUnit.Pascals, 0.0589756, PressureUnit.Bars)]
        [InlineData(5897.56, PressureUnit.Pascals, 5.89756, PressureUnit.KiloPascals)]
        [InlineData(5897.56, PressureUnit.Pascals, 0.00589756, PressureUnit.MegaPascals)]
        [InlineData(5897.56, PressureUnit.Pascals, 58.9756, PressureUnit.MilliBars)]
        [InlineData(5897.56, PressureUnit.Pascals, 5897.56, PressureUnit.NewtonsPerSquareMeter)]
        public void PressureConversions(float value1, PressureUnit units1, float value2, PressureUnit units2) {
            new Pressure(value1, units1).In(units2).Value.ShouldBe(value2);
            new Pressure(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}