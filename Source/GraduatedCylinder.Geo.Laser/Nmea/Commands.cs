namespace GraduatedCylinder.Geo.Laser.Nmea;

internal static class Commands
{

    internal static Command PowerOff { get; } = new("PO");

    internal static Command Start { get; } = new("GO");

    internal static Command Stop { get; } = new("ST");

}