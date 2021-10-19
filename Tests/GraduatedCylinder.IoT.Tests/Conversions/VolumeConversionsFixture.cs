using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class VolumeConversionsFixture
    {

        [Theory]
        [InlineData(1000.7865, VolumeUnit.Liters, 100078.66, VolumeUnit.Centilitres)]
        [InlineData(1000.7865, VolumeUnit.Liters, 1000786.56, VolumeUnit.CubicCentimeters)]
        [InlineData(1000.7865, VolumeUnit.Liters, 1000.7865, VolumeUnit.CubicDecimeters)]
        [InlineData(1000.7865, VolumeUnit.Liters, 35.342438, VolumeUnit.CubicFeet)]
        [InlineData(1000.7865, VolumeUnit.Liters, 61071.754, VolumeUnit.CubicInches)]
        [InlineData(1000.7865, VolumeUnit.Liters, 1.0007865, VolumeUnit.CubicMeters)]
        [InlineData(1000.7865, VolumeUnit.Liters, 1.00078656E+09, VolumeUnit.CubicMillimeters)]
        [InlineData(1000.7865, VolumeUnit.Liters, 1.30897932248, VolumeUnit.CubicYards)]
        [InlineData(1000.7865, VolumeUnit.Liters, 35222.766, VolumeUnit.FluidOuncesUK)]
        [InlineData(1000.7865, VolumeUnit.Liters, 33840.617430698, VolumeUnit.FluidOuncesUS)]
        [InlineData(1000.7865, VolumeUnit.Liters, 220.1422541129, VolumeUnit.GallonsUK)]
        [InlineData(1000.7865, VolumeUnit.Liters, 227.19931, VolumeUnit.GallonsUSDry)]
        [InlineData(1000.7865, VolumeUnit.Liters, 264.3798236773, VolumeUnit.GallonsUSLiquid)]
        [InlineData(1000.7865, VolumeUnit.Liters, 1000786.56, VolumeUnit.Milliliters)]
        [InlineData(1000.7865, VolumeUnit.Liters, 1761.138, VolumeUnit.PintsUK)]
        [InlineData(1000.7865, VolumeUnit.Liters, 1817.5945, VolumeUnit.PintsUSDry)]
        [InlineData(1000.7865, VolumeUnit.Liters, 2115.03858942, VolumeUnit.PintsUSLiquid)]
        [InlineData(1000.7865, VolumeUnit.Liters, 880.56866, VolumeUnit.QuartsUK)]
        [InlineData(1000.7865, VolumeUnit.Liters, 908.79724, VolumeUnit.QuartsUSDry)]
        [InlineData(1000.7865, VolumeUnit.Liters, 1057.519294709, VolumeUnit.QuartsUSLiquid)]
        public void VolumeConversions(float value1, VolumeUnit units1, float value2, VolumeUnit units2) {
            new Volume(value1, units1).In(units2).Value.ShouldBe(value2);
            new Volume(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}