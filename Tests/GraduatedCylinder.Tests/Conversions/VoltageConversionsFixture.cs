#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class VoltageConversionsFixture
{

    [Theory]
    [InlineData(15555.655, ElectricPotentialUnit.Volt, 15.555655, ElectricPotentialUnit.KiloVolt)]
    [InlineData(15555.655, ElectricPotentialUnit.Volt, 15555655, ElectricPotentialUnit.MilliVolt)]
    public void VoltageConversions(double value1, ElectricPotentialUnit units1, double value2, ElectricPotentialUnit units2) {
        new ElectricPotential(value1, units1).In(units2).ShouldBe(new ElectricPotential(value2, units2));
        new ElectricPotential(value2, units2).In(units1).ShouldBe(new ElectricPotential(value1, units1));
    }

}