namespace GraduatedCylinder.Geo
{
    public class GeoPosition
    {
        private readonly Length _altitude;
        private readonly Latitude _latitude;
        private readonly Longitude _longitude;

        public GeoPosition(Latitude latitude, Longitude longitude, Length altitude = null) {
            _latitude = latitude;
            _longitude = longitude;
            _altitude = altitude;
        }

        public Length Altitude {
            get { return _altitude; }
        }

        public Latitude Latitude {
            get { return _latitude; }
        }

        public Longitude Longitude {
            get { return _longitude; }
        }

        public override string ToString() {
            return "{" + Latitude + ", " + Longitude + "}";
        }

        public static GeoPosition New(Latitude latitude, Longitude longitude) {
            return new GeoPosition(latitude, longitude);
        }

        public static GeoPosition New(Latitude latitude, Longitude longitude, Length altitude) {
            return new GeoPosition(latitude, longitude, altitude);
        }
    }
}