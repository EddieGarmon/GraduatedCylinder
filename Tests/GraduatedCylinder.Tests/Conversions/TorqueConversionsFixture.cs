using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Conversions;

public class TorqueConversionsFixture
{

    [Theory]
    [InlineData(156.758, TorqueUnit.NewtonMeters, 15.9794087666, TorqueUnit.KiloGramForceMeters)]
    [InlineData(156.789, TorqueUnit.NewtonMeters, 115.64163168071347631885239460062, TorqueUnit.FootPounds)]
    [InlineData(1678.254, TorqueUnit.KiloGramForceMeters, 12142.9810986054, TorqueUnit.FootPounds)]
    public void TorqueConversions(double value1, TorqueUnit units1, double value2, TorqueUnit units2) {
        new Torque(value1, units1).In(units2).ShouldBe(new Torque(value2, units2));
        new Torque(value2, units2).In(units1).ShouldBe(new Torque(value1, units1));
    }

}