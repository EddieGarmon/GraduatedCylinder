namespace GraduatedCylinder.Geo.Laser;

public class DeviceInfo
{

    public DeviceInfo(string model, string version, string? date = null) {
        Model = model;
        Version = version;
        Date = date;
    }

    public string? Date { get; }

    public string Model { get; }

    public string Version { get; }

}