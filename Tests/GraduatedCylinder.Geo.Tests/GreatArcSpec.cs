namespace GraduatedCylinder.Geo;

public class GreatArcSpec
{

    [Theory]
    [InlineData(0, 0, 0, 0, 0)]
    [InlineData(36.081976, -79.967206, 36.103796, -79.934979, 3.77779646124)]
    [InlineData(34.081976, -89.957206, 36.103796, -79.934979, 938.66032459307)]
    public void VerifyDistance(double lat1, double long1, double lat2, double long2, double expectedLengthInKilometers) {
        UnitPreferences.Default.Precision = 15;
        GeoPosition start = new(lat1, long1);
        GeoPosition stop = new(lat2, long2);
        GreatArc.Distance(start, stop).In(LengthUnit.KiloMeter).ShouldBe(new Length(expectedLengthInKilometers, LengthUnit.KiloMeter));
    }

}