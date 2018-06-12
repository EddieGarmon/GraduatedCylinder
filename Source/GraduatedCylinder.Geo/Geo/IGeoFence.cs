namespace GraduatedCylinder.Geo
{
    public interface IGeoFence
    {
        string Id { get; }

        bool IsInside(GeoPosition position);
    }
}