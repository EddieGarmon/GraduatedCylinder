using Xunit.Theories;

namespace GraduatedCylinder
{
    public class TimeConversionsFixture
    {
        [Theory]
        [InlineData(150, TimeUnit.Seconds, 2.5, TimeUnit.Minutes)]
        [InlineData(3600, TimeUnit.Seconds, 1, TimeUnit.Hours)]
        [InlineData(86400, TimeUnit.Seconds, 1, TimeUnit.Days)]
        [InlineData(150, TimeUnit.Minutes, 2.5, TimeUnit.Hours)]
        [InlineData(1440, TimeUnit.Minutes, 1, TimeUnit.Days)]
        [InlineData(48, TimeUnit.Hours, 2, TimeUnit.Days)]
        [InlineData(2.35678978, TimeUnit.Seconds, 2356789.78, TimeUnit.MicroSecond)]
        [InlineData(2.657843, TimeUnit.Seconds, 2657.843, TimeUnit.MilliSecond)]
        public void TimeConversions(double value1, TimeUnit units1, double value2, TimeUnit units2) {
            new Time(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
            new Time(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}