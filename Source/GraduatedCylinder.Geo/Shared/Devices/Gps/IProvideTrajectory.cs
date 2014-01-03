using GraduatedCylinder.Geo;

namespace GraduatedCylinder.Devices.Gps
{
    public interface IProvideTrajectory
    {
        Heading CurrentHeading { get; }

        Speed CurrentSpeed { get; }
    }
}