using System;
using System.Diagnostics;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Apply this attribute to a dimensions unit to specify the string representation
    ///     of the unit.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    [DebuggerDisplay("{Value}")]
    public sealed class UnitAbbreviationAttribute : Attribute
    {

        public UnitAbbreviationAttribute(string value) {
            Value = value;
        }

        public string Value { get; private set; }

    }
}