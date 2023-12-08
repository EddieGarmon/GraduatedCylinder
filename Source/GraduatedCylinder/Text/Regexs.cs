using System.Text.RegularExpressions;

#if GraduatedCylinder
namespace GraduatedCylinder.Text;
#endif
#if Pipette
namespace Pipette.Text;
#endif

internal static class Regexs
{

    public static Regex Pair { get; } = new(
        //12 s
        //-12 s
        //12.12 s
        @"^(?<value>[+-]?\d+(?:\.\d+)?(?:[eE][+-]?\d+)?)\s*?(?<units>\w+)$",
        RegexOptions.Compiled);

    public static Regex ValueOnly { get; } = new(
        //no units
        @"^[+-]?\d+(?:\.\d+)?(?:[eE][+-]?\d+)?$",
        RegexOptions.Compiled);

}