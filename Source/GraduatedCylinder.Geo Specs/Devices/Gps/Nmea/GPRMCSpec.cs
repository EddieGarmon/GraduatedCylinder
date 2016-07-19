using GraduatedCylinder.Nmea;
using Xunit;
using XunitShould;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    public class GPRMCSpec
    {
        [Theory]
        [InlineData("$GPRMC,145710.00,A,3605.08678,N,07958.72572,W,0.037,,180716,,,D*6B", 13, 36.0847796666667, 'N', -79.978762, 'W')]
        [InlineData("$GPRMC,145930.00,A,3605.06933,N,07958.57358,W,38.579,94.11,180716,,,A*72", 13, 36.0844888333333, "N", -79.9762263333, 'W')]
        [InlineData("$GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A", 12, 48.1173, 'N', 11.5166666666667, 'E')]
        public void Parsing13Parts(string nmea, int expectedParts, double latitude, char latHemisphere, double longitude, char longHemisphere) {
            GpsParser parser = new GpsParser();
            Sentence sentence = Sentence.Parse(nmea);
            sentence.Id.ShouldEqual("$GPRMC");
            sentence.Parts.Length.ShouldEqual(expectedParts);

            Message message = parser.Parse(sentence);
            message.Sentence.ShouldEqual(sentence);

            IProvideGeoPosition provideGeoPosition = message.ValueAs<IProvideGeoPosition>();
            provideGeoPosition.CurrentLocation.Latitude.Value.ShouldEqualWithinPrecision(latitude, 10);
            provideGeoPosition.CurrentLocation.Latitude.Hemisphere.ShouldEqual(latHemisphere);
            provideGeoPosition.CurrentLocation.Longitude.Value.ShouldEqualWithinPrecision(longitude, 10);
            provideGeoPosition.CurrentLocation.Longitude.Hemisphere.ShouldEqual(longHemisphere);
        }
    }
}