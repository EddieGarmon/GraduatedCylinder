#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class ElectricCurrentConversionsFixture
{

    [Theory]
    [InlineData(45553.6666, ElectricCurrentUnit.Ampere, 45.5536666, ElectricCurrentUnit.KiloAmpere)]
    [InlineData(45553.6666, ElectricCurrentUnit.Ampere, 45553666.6, ElectricCurrentUnit.MilliAmpere)]
    public void CurrentConversions(double value1, ElectricCurrentUnit units1, double value2, ElectricCurrentUnit units2) {
        new ElectricCurrent(value1, units1).In(units2).ShouldBe(new ElectricCurrent(value2, units2));
        new ElectricCurrent(value2, units2).In(units1).ShouldBe(new ElectricCurrent(value1, units1));
    }

}