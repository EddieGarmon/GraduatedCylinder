using Xunit;

namespace GraduatedCylinder.Conversions;

public class JerkConversionsFixture
{

    [Theory]
    [InlineData(100.476, JerkUnit.MetersPerSecondCubed, 0.100476, JerkUnit.KiloMetersPerSecondCubed)]
    [InlineData(134.567, JerkUnit.MetersPerSecondCubed, 0.0836160572, JerkUnit.MilesPerSecondCubed)]
    [InlineData(1678.98, JerkUnit.KiloMetersPerSecondCubed, 1043.26980434, JerkUnit.MilesPerSecondCubed)]
    public void JerkConversions(double value1, JerkUnit units1, double value2, JerkUnit units2) {
        new Jerk(value1, units1).In(units2).Value.ShouldBeWithinToleranceOf(value2);
        new Jerk(value2, units2).In(units1).Value.ShouldBeWithinToleranceOf(value1);
    }

}