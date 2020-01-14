namespace GraduatedCylinder.Geo
{
    public partial class GeoFence
    {
        public class Circle : IGeoFence
        {
            private readonly GeoPosition _center;
            private readonly string _id;
            private readonly Length _radius;

            public Circle(string id, GeoPosition center, Length radius) {
                _id = id;
                _center = center;
                _radius = radius;
            }

            public string Id {
                get { return _id; }
            }

            public bool IsInside(GeoPosition position) {
                return GreatArc.Distance(_center, position) <= _radius;
            }
        }
    }
}