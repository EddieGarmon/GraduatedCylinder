namespace GraduatedCylinder.Geo;

public static class PrettyPrinter
{

    public const char DegreesSymbol = '\xB0';
    public const char MinutesSymbol = '\x27';
    public const char SecondsSymbol = '\x22';
    public const string Unknown = "Unknown";

    public static string AsDegrees(Latitude latitude) {
        return AsDegrees(latitude.Value, latitude.Hemisphere);
    }

    public static string AsDegrees(Longitude longitude) {
        return AsDegrees(longitude.Value, longitude.Hemisphere);
    }

    public static string AsDegrees(Heading heading) {
        if (double.IsNaN(heading.Value)) {
            return Unknown;
        }
        return AsDegrees(heading.Value, ' ');
    }

    public static string AsDegreesMinutes(Latitude latitude) {
        return AsDegreesMinutes(latitude.Value, latitude.Hemisphere);
    }

    public static string AsDegreesMinutes(Longitude longitude) {
        return AsDegreesMinutes(longitude.Value, longitude.Hemisphere);
    }

    public static string AsDegreesMinutes(Heading heading) {
        if (double.IsNaN(heading.Value)) {
            return Unknown;
        }
        return AsDegreesMinutes(heading.Value, ' ');
    }

    public static string AsDegreesMinutesSeconds(Latitude latitude) {
        return AsDegreesMinutesSeconds(latitude.Value, latitude.Hemisphere);
    }

    public static string AsDegreesMinutesSeconds(Longitude longitude) {
        return AsDegreesMinutesSeconds(longitude.Value, longitude.Hemisphere);
    }

    public static string AsDegreesMinutesSeconds(Heading heading) {
        if (double.IsNaN(heading.Value)) {
            return Unknown;
        }
        return AsDegreesMinutesSeconds(heading.Value, ' ');
    }

    private static string AsDegrees(double value, char hemisphere) {
        return $"{value:N7}{DegreesSymbol} {hemisphere}";
    }

    private static string AsDegreesMinutes(double value, char hemisphere) {
        int roundedDegrees = (int)value;
        double minutes = (value - roundedDegrees) * 60;
        return $"{roundedDegrees}{DegreesSymbol} {minutes:N4}{MinutesSymbol} {hemisphere}";
    }

    private static string AsDegreesMinutesSeconds(double value, char hemisphere) {
        int roundedDegrees = (int)value;
        double minutes = (value - roundedDegrees) * 60;
        int roundedMinutes = (int)minutes;
        double seconds = (minutes - roundedMinutes) * 60;
        return $"{roundedDegrees}{DegreesSymbol} {roundedMinutes}{MinutesSymbol} {seconds:N4}{SecondsSymbol} {hemisphere}";
    }

}