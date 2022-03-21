namespace GraduatedCylinder.Geo.Laser.Nmea;

internal static class Commands
{

    internal static Command PowerOff { get; } = new Command("PO");

    internal static Command Start { get; } = new Command("GO");

    internal static Command Stop { get; } = new Command("ST");

}