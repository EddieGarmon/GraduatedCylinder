namespace GraduatedCylinder.Geo;

public class GeoVector
{

    public GeoVector(Length horizontalDistance, Angle azimuth, Angle inclination, Length slopeDistance, bool highQuality) {
        HorizontalDistance = horizontalDistance;
        Azimuth = azimuth;
        Inclination = inclination;
        SlopeDistance = slopeDistance;
        HighQuality = highQuality;

        // a^2 + b^2 = c^2
        VerticalDistance = (SlopeDistance * SlopeDistance - HorizontalDistance * HorizontalDistance).SquareLength();
    }

    public Angle Azimuth { get; }

    public bool HighQuality { get; }

    public Length HorizontalDistance { get; }

    public Angle Inclination { get; }

    public Length SlopeDistance { get; }

    public Length VerticalDistance { get; }

}