using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public abstract class ConversionTestBase(ITestOutputHelper output)
{

    protected void Validate<T, TUnit>(double value1, TUnit units1, double value2, TUnit units2, Func<double, TUnit, T> build)
        where T : IDimension<T, TUnit> {
        T param1 = build(value1, units1);
        T param2 = build(value2, units2);

        T param1Converted = param1.In(units2);
        T param2Converted = param2.In(units1);

        output.WriteLine($"parameter 1: {param1}, 2: {param2}");
        output.WriteLine($"converted 2: {param2Converted}, 1: {param1Converted}");

        param1Converted.ShouldBe(param2);
        param2Converted.ShouldBe(param1);
    }

}