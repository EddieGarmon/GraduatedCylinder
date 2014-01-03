using GraduatedCylinder.Geo;

namespace GraduatedCylinder.Devices.Gps
{
    public interface IProvideGeoPosition
    {
        GeoPosition CurrentLocation { get; }
    }
}