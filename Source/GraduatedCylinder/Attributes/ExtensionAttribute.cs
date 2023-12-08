using System.Diagnostics;

namespace CodeGeneration.Attributes;

/// <summary>
///     Apply this attribute to a dimensions unit to specify generating an extension method API for the unit.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
[DebuggerDisplay("{MethodName}")]
internal sealed class ExtensionAttribute(string methodName) : Attribute
{

    public string MethodName { get; } = methodName;

}