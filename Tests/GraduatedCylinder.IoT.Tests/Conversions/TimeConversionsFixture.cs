using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class TimeConversionsFixture
    {

        [Theory]
        [InlineData(150, TimeUnit.Second, 2.5, TimeUnit.Minutes)]
        [InlineData(3600, TimeUnit.Second, 1, TimeUnit.Hours)]
        [InlineData(86400, TimeUnit.Second, 1, TimeUnit.Days)]
        [InlineData(150, TimeUnit.Minutes, 2.5, TimeUnit.Hours)]
        [InlineData(1440, TimeUnit.Minutes, 1, TimeUnit.Days)]
        [InlineData(48, TimeUnit.Hours, 2, TimeUnit.Days)]
        [InlineData(2.35678978, TimeUnit.Second, 2356789.78, TimeUnit.MicroSecond)]
        [InlineData(2.657843, TimeUnit.Second, 2657.843, TimeUnit.MilliSecond)]
        public void TimeConversions(float value1, TimeUnit units1, float value2, TimeUnit units2) {
            new Time(value1, units1).In(units2).Value.ShouldBe(value2);
            new Time(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}