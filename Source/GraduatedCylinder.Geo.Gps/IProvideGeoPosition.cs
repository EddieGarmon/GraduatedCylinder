namespace GraduatedCylinder.Geo.Gps;

public interface IProvideGeoPosition
{

    GeoPosition CurrentLocation { get; }

}