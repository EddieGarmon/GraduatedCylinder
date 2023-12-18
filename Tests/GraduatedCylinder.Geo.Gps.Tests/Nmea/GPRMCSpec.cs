using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Gps.Nmea;

public class GPRMC_Spec
{

    [Theory]
    [InlineData("$GPRMC,145710.00,A,3605.08678,N,07958.72572,W,0.037,,180716,,,D*6B", 13, 36.0847796666667, -79.978762)]
    [InlineData("$GPRMC,145930.00,A,3605.06933,N,07958.57358,W,38.579,94.11,180716,,,A*72", 13, 36.0844888333333, -79.9762263333)]
    [InlineData("$GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A", 12, 48.1173, 11.5166666666667)]
    public void Parsing13Parts(string nmea, int expectedParts, double latitude, double longitude) {
        GpsParser parser = new();
        Sentence? sentence = Sentence.Parse(nmea);
        sentence.ShouldNotBeNull();
        sentence!.Id.ShouldBe("$GPRMC");
        sentence.WordCount.ShouldBe(expectedParts);

        Message? message = parser.Parse(sentence);
        message.ShouldNotBeNull();
        message!.Sentence.ShouldBe(sentence);

        IProvideGeoPosition? position = message.Value as IProvideGeoPosition;
        position.ShouldNotBeNull();
        position.CurrentLocation.Latitude.ShouldBe(new Latitude(latitude));
        position.CurrentLocation.Longitude.ShouldBe(new Longitude(longitude));
    }

    /// <summary>
    /// </summary>
    /// <param name="nmea"></param>
    /// <param name="expectedHeading"></param>
    [Theory]
    [InlineData("$GPRMC,145710.00,A,3605.08678,N,07958.72572,W,0.037,,180716,,,D*6B", double.NaN)]
    [InlineData("$GPRMC,145930.00,A,3605.06933,N,07958.57358,W,38.579,94.11,180716,,,A*72", 94.11)]
    [InlineData("$GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A", 84.4)]
    public void ValidateHeading(string nmea, double expectedHeading) {
        Sentence? sentence = Sentence.Parse(nmea);

        GpsParser parser = new();
        Message? message = parser.Parse(sentence);
        message.ShouldNotBeNull();
        message!.Sentence.ShouldBe(sentence);

        IProvideTrajectory? provideTrajectory = message.Value as IProvideTrajectory;
        provideTrajectory.ShouldNotBeNull();
        provideTrajectory!.CurrentHeading.Value.ShouldBe(expectedHeading);
    }

}