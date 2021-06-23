namespace GraduatedCylinder.Geo
{
    public class GeoVector
    {

        public GeoVector(Length horizontalDistance,
                         Angle azimuth,
                         Angle inclination,
                         Length slopeDistance,
                         bool highQuality) {
            HorizontalDistance = horizontalDistance;
            Azimuth = azimuth;
            Inclination = inclination;
            SlopeDistance = slopeDistance;
            HighQuality = highQuality;
            if (horizontalDistance != null && slopeDistance != null) {
                // a^2 + b^2 = c^2
                VerticalDistance =
                    (SlopeDistance * SlopeDistance - HorizontalDistance * HorizontalDistance).SquareRoot();
            }
        }

        public Angle Azimuth { get; private set; }

        public bool HighQuality { get; private set; }

        public Length HorizontalDistance { get; private set; }

        public Angle Inclination { get; private set; }

        public Length SlopeDistance { get; private set; }

        public Length VerticalDistance { get; private set; }

    }
}