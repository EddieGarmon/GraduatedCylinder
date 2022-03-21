namespace GraduatedCylinder.Geo.Gps;

public interface IProvideTrajectory
{

    Heading CurrentHeading { get; }

    Speed CurrentSpeed { get; }

}