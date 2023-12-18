using System.Collections.Concurrent;
using System.Globalization;

#if GraduatedCylinder
namespace GraduatedCylinder.Text;
#endif
#if Pipette
namespace Pipette.Text;
#endif

internal static class Formats
{

    private static ConcurrentDictionary<int, string> PrecisionFormats { get; } = [];

    public static string GetPrecisionFormat(int precision) {
        return PrecisionFormats.GetOrAdd(precision,
                                         count => "{0:N[pre]} {1}".Replace("[pre]", count.ToString(CultureInfo.InvariantCulture)));
    }

}