using Xunit;

namespace GraduatedCylinder.Conversions;

public class ElectricPotentialConversionsFixture
{

    [Theory]
    [InlineData(15555.6555, ElectricPotentialUnit.Volt, 15.5556555, ElectricPotentialUnit.Kilovolt)]
    [InlineData(15555.6555, ElectricPotentialUnit.Volt, 15555655.5, ElectricPotentialUnit.Millivolt)]
    public void ElectricPotentialConversions(double value1, ElectricPotentialUnit units1, double value2, ElectricPotentialUnit units2) {
        new ElectricPotential(value1, units1).In(units2).Value.ShouldBeWithinToleranceOf(value2);
        new ElectricPotential(value2, units2).In(units1).Value.ShouldBeWithinToleranceOf(value1);
    }

}