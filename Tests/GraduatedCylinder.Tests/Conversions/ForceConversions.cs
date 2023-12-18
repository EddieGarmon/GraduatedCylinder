using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class ForceConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(156.758, ForceUnit.Newtons, 15.9794087666, ForceUnit.KiloGramForce)]
    [InlineData(156.789, ForceUnit.Newtons, 35.247582178938991326867825781998, ForceUnit.PoundForce)]
    [InlineData(1678.254, ForceUnit.PoundForce, 760.98297735779816513761467889908, ForceUnit.KiloGramForce)]
    public void Conversions(double value1, ForceUnit units1, double value2, ForceUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Force(value, unit));
    }

}