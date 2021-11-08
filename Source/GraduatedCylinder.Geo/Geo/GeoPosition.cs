namespace GraduatedCylinder.Geo
{
    public class GeoPosition
    {

        public GeoPosition(Latitude latitude, Longitude longitude)
            : this(latitude, longitude, Length.Zero) { }

        public GeoPosition(Latitude latitude, Longitude longitude, Length altitude) {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }

        public Length Altitude { get; }

        public Latitude Latitude { get; }

        public Longitude Longitude { get; }

        public override string ToString() {
            return string.Format("{0}, {1}{2}{3}",
                                 PrettyPrinter.AsDegrees(Latitude),
                                 PrettyPrinter.AsDegrees(Longitude),
                                 Altitude == null ? null : ", ",
                                 Altitude);
        }

        public static GeoPosition New(Latitude latitude, Longitude longitude) {
            return new GeoPosition(latitude, longitude);
        }

        public static GeoPosition New(Latitude latitude, Longitude longitude, Length altitude) {
            return new GeoPosition(latitude, longitude, altitude);
        }

        public static GeoPosition Parse(string value) {
            //"30.00000° N, 40.00000° E"
            string[] split = value.Split(' ');
            double latitude = double.Parse(split[0].TrimEnd(PrettyPrinter.DegreesSymbol));
            double longitude = double.Parse(split[2].TrimEnd(PrettyPrinter.DegreesSymbol));
            double altitude = 0;
            if (split.Length == 6) {
                altitude = 0;
            }
            return new GeoPosition(latitude, longitude, new Length(altitude, LengthUnit.Meter));
        }

    }
}