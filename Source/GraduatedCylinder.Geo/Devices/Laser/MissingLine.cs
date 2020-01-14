using GraduatedCylinder.Geo;

namespace GraduatedCylinder.Devices.Laser
{
    public class MissingLine
    {
        public MissingLine(GeoVector line1, GeoVector line2, GeoVector missing) {
            Line1 = line1;
            Line2 = line2;
            Missing = missing;
        }

        public GeoVector Line1 { get; private set; }

        public GeoVector Line2 { get; private set; }

        public GeoVector Missing { get; private set; }
    }
}