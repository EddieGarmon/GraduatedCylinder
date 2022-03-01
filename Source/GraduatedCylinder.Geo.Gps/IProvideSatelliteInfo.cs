namespace GraduatedCylinder.Geo.Gps;

public interface IProvideSatelliteInfo
{

    IEnumerable<SatelliteInfo> Satellites { get; }

}