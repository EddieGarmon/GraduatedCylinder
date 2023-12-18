using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class ElectricResistanceConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(67749.5444, ElectricResistanceUnit.Ohm, 67.7495444, ElectricResistanceUnit.KiloOhm)]
    [InlineData(67749.5444, ElectricResistanceUnit.Ohm, 67749544.4, ElectricResistanceUnit.MilliOhm)]
    public void ResistanceConversions(double value1, ElectricResistanceUnit units1, double value2, ElectricResistanceUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new ElectricResistance(value, unit));
    }

}