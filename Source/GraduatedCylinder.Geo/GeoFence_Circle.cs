namespace GraduatedCylinder.Geo;

public partial class GeoFence
{

    public class Circle : IGeoFence
    {

        private readonly GeoPosition _center;
        private readonly Length _radius;

        public Circle(string id, GeoPosition center, Length radius) {
            Id = id;
            _center = center;
            _radius = radius;
        }

        public string Id { get; }

        public bool IsInside(GeoPosition position) {
            return GreatArc.Distance(_center, position) <= _radius;
        }

    }

}