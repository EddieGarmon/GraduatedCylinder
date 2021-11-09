#nullable enable
using System.Collections.Generic;
using System.Globalization;

namespace GraduatedCylinder.Text
{
    internal static class Formats
    {

        private static Dictionary<int, string> PrecisionFormats { get; } = new Dictionary<int, string>();

        public static string GetPrecisionFormat(int precision) {
            if (!PrecisionFormats.TryGetValue(precision, out string? format)) {
                format = "{0:N[pre]} {1}".Replace("[pre]", precision.ToString(CultureInfo.InvariantCulture));
                PrecisionFormats.Add(precision, format);
            }
            return format;
        }

    }
}