namespace GraduatedCylinder.Devices.Gps
{
    public interface IProvideFixType
    {
        GpsFixType CurrentFix { get; }
    }
}