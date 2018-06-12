namespace GraduatedCylinder.Devices.Gps
{
    public interface IProvideDilutionOfPrecision
    {
        double HorizontalDop { get; }

        double PositionDop { get; }

        double VerticalDop { get; }
    }
}