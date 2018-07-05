using System;

namespace GraduatedCylinder
{
    public static class StringExtensions
    {
        private static readonly char[] WhitespaceSeparators = {
            ' ',
            '\t',
            '\r',
            '\n'
        };

        public static string[] SplitOnWhitespace(this string value, bool removeEmpty = true) {
            StringSplitOptions options = removeEmpty ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;
            return value.Split(WhitespaceSeparators, options);
        }
    }
}