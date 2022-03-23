namespace GraduatedCylinder.Geo;

public static class GreatArc
{

    private static Length EarthsRadius { get; } = new Length(6371, LengthUnit.KiloMeter);

    //http://www.movable-type.co.uk/scripts/latlong.html
    public static Length Distance(GeoPosition start, GeoPosition stop) {
        Angle phi1 = new Angle(start.Latitude, AngleUnit.Degree) { Units = AngleUnit.Radian };
        Angle phi2 = new Angle(stop.Latitude, AngleUnit.Degree) { Units = AngleUnit.Radian };
        Angle deltaPhi = new Angle(stop.Latitude - start.Latitude, AngleUnit.Degree) { Units = AngleUnit.Radian };
        Angle deltaLong = new Angle(stop.Longitude - start.Longitude, AngleUnit.Degree) { Units = AngleUnit.Radian };

        double sinOfHalfPhi = Math.Sin(deltaPhi.Value / 2);
        double sinOfHalfLong = Math.Sin(deltaLong.Value / 2);

        double a = sinOfHalfPhi * sinOfHalfPhi + Math.Cos(phi1.Value) * Math.Cos(phi2.Value) * sinOfHalfLong * sinOfHalfLong;
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return EarthsRadius * c;
    }

}