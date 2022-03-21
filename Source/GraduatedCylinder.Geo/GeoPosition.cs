using System.Runtime.InteropServices;

namespace GraduatedCylinder.Geo;

[StructLayout(LayoutKind.Sequential)]
public readonly struct GeoPosition
{

    private readonly Latitude _latitude;
    private readonly Longitude _longitude;
    private readonly Length _altitude;

    public GeoPosition(Latitude latitude, Longitude longitude)
        : this(latitude, longitude, Length.Unknown) { }

    public GeoPosition(Latitude latitude, Longitude longitude, Length altitude) {
        _latitude = latitude;
        _longitude = longitude;
        _altitude = altitude;
    }

    public Length Altitude => _altitude;

    public Latitude Latitude => _latitude;

    public Longitude Longitude => _longitude;

    public override string ToString() {
        return Altitude == Length.Unknown ? ToStringWithoutAltitude() : ToStringWithAltitude();
    }

    private string ToStringWithAltitude() {
        return $"{PrettyPrinter.AsDegrees(Latitude)}, {PrettyPrinter.AsDegrees(Longitude)}, {Altitude}";
    }

    private string ToStringWithoutAltitude() {
        return $"{PrettyPrinter.AsDegrees(Latitude)}, {PrettyPrinter.AsDegrees(Longitude)}";
    }

    public static GeoPosition New(Latitude latitude, Longitude longitude) {
        return new GeoPosition(latitude, longitude, Length.Unknown);
    }

    public static GeoPosition New(Latitude latitude, Longitude longitude, Length altitude) {
        return new GeoPosition(latitude, longitude, altitude);
    }

    public static GeoPosition Parse(string value) {
        //"30.00000° N, 40.00000° E"
        string[] split = value.Split(' ');
        double latitude = double.Parse(split[0].TrimEnd(PrettyPrinter.DegreesSymbol));
        double longitude = double.Parse(split[2].TrimEnd(PrettyPrinter.DegreesSymbol));
        //todo: double altitude = 0;
        //if (split.Length == 6) {
        //    altitude = 0;
        //}
        return new GeoPosition(latitude, longitude);
    }

}