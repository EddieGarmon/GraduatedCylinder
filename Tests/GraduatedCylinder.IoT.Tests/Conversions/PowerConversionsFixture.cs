using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class PowerConversionsFixture
    {

        [Theory]
        [InlineData(7654.986, PowerUnit.Watts, 6582103.18, PowerUnit.CaloriesPerHour)]
        [InlineData(7654.986, PowerUnit.Watts, 109701.719, PowerUnit.CaloriesPerMinute)]
        [InlineData(7654.986, PowerUnit.Watts, 1828.36199, PowerUnit.CaloriesPerSecond)]
        [InlineData(7654.986, PowerUnit.Watts, 10.265503, PowerUnit.Horsepower)]
        [InlineData(7654.986, PowerUnit.Watts, 27557946, PowerUnit.JoulesPerHour)]
        [InlineData(7654.986, PowerUnit.Watts, 459299.06, PowerUnit.JoulesPerMinute)]
        [InlineData(7654.986, PowerUnit.Watts, 7654.986, PowerUnit.JoulesPerSecond)]
        [InlineData(7654.986, PowerUnit.Watts, 7.654986, PowerUnit.Kilowatts)]
        [InlineData(7654.986, PowerUnit.Watts, 0.007654986, PowerUnit.Megawatts)]
        [InlineData(7654.986, PowerUnit.Watts, 7654.986, PowerUnit.NewtonMetersPerSecond)]
        public void PowerConversions(float value1, PowerUnit units1, float value2, PowerUnit units2) {
            new Power(value1, units1).In(units2).Value.ShouldBe(value2);
            new Power(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}