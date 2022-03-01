namespace GraduatedCylinder.Geo.Gps;

public interface IProvideFixType
{

    GpsFixType CurrentFix { get; }

}