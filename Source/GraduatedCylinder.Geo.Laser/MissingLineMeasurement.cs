namespace GraduatedCylinder.Geo.Laser;

public class MissingLineMeasurement
{

    public MissingLineMeasurement(GeoVector value) {
        Value = value;
    }

    public GeoVector Value { get; }

}