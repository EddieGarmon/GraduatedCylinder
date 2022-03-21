using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Geo
{
    public class GreatArcSpec
    {

        [Theory]
        [InlineData(0, 0, 0, 0, 0)]
        [InlineData(36.081976, -79.967206, 36.103796, -79.934979, 3.778)]
        [InlineData(34.081976, -89.957206, 36.103796, -79.934979, 938.66)]
        public void VerifyDistance(double lat1, double long1, double lat2, double long2, double expectedLengthInKilometers) {
            GeoPosition start = new GeoPosition(lat1, long1);
            GeoPosition stop = new GeoPosition(lat2, long2);
            GreatArc.Distance(start, stop).In(LengthUnit.Kilometer).Value.ShouldBeNear(expectedLengthInKilometers, .0001);
        }

    }
}