using System.Text.RegularExpressions;

namespace GraduatedCylinder.IoT.Parsing
{
    public static partial class Parser
    {

        private static Regex PairRegex { get; } =
            new Regex(@"^(?<value>[+-]?\d+(?:\.\d+)?(?:[eE][+-]?\d+)?)\s*?(?<units>\w+)$", RegexOptions.Compiled);

        private static Regex ValueOnlyRegex { get; } =
            new Regex(@"^[+-]?\d+(?:\.\d+)?(?:[eE][+-]?\d+)?$", RegexOptions.Compiled);

    }
}