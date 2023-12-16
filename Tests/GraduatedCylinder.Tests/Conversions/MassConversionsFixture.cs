#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class MassConversionsFixture
{

    [Theory]
    [InlineData(587.5689, MassUnit.KiloGram, 587568.9, MassUnit.Gram)]
    [InlineData(587.5689, MassUnit.KiloGram, 1295.367688835, MassUnit.Pounds)]
    [InlineData(587.5689, MassUnit.KiloGram, 18890.7787955075, MassUnit.OuncesTroy)]
    [InlineData(587.5689, MassUnit.KiloGram, 0.578289147, MassUnit.TonsUK)]
    [InlineData(587.5689, MassUnit.KiloGram, 2937844.5, MassUnit.Carats)]
    [InlineData(587.5689, MassUnit.KiloGram, 0.647683844, MassUnit.TonsUS)]
    public void MassConversions(double value1, MassUnit units1, double value2, MassUnit units2) {
        new Mass(value1, units1).In(units2).ShouldBe(new Mass(value2, units2));
        new Mass(value2, units2).In(units1).ShouldBe(new Mass(value1, units1));
    }

}