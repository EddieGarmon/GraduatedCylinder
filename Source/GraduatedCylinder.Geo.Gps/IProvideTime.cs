namespace GraduatedCylinder.Geo.Gps;

public interface IProvideTime
{

    DateTimeOffset CurrentTime { get; }

}