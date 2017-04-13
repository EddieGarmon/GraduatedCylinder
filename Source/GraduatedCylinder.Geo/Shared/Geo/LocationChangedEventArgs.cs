namespace GraduatedCylinder.Geo
{
    public class LocationChangedEventArgs
    {
        private readonly Heading _heading;
        private readonly GeoPosition _position;

        public LocationChangedEventArgs(GeoPosition position, Heading heading) {
            _position = position;
            _heading = heading;
        }

        public Heading Heading {
            get { return _heading; }
        }

        public GeoPosition Position {
            get { return _position; }
        }
    }
}