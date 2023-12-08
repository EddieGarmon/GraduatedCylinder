using System.Diagnostics;

namespace CodeGeneration.Attributes;

/// <summary>
///     Apply this attribute to a dimensions unit to specify the abbreviated representation of the unit.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
[DebuggerDisplay("{Value}")]
internal sealed class UnitAbbreviationAttribute(string value) : Attribute
{

    public string Value { get; } = value;

}