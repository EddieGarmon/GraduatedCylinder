namespace GraduatedCylinder.Geo.Laser.Nmea;

internal class Command
{

    public Command(string id) {
        Id = id;
    }

    public string Id { get; }

    public string GetCommand() {
        return $"${Id}\r\n";
    }

}