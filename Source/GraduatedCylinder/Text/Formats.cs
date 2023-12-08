using System.Globalization;

#if GraduatedCylinder
namespace GraduatedCylinder.Text;
#endif
#if Pipette
namespace Pipette.Text;
#endif

internal static class Formats
{

    private static Dictionary<int, string> PrecisionFormats { get; } = new();

    public static string GetPrecisionFormat(int precision) {
        if (!PrecisionFormats.TryGetValue(precision, out string? format)) {
            format = "{0:N[pre]} {1}".Replace("[pre]", precision.ToString(CultureInfo.InvariantCulture));
            PrecisionFormats.Add(precision, format);
        }
        return format;
    }

}