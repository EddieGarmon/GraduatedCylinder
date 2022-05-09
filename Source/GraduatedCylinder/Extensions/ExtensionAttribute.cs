using System.Diagnostics;

namespace GraduatedCylinder.Extensions;

/// <summary>
///     Apply this attribute to a dimensions unit to specify generating an extension method API for the unit.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
[DebuggerDisplay("{MethodName}")]
public sealed class ExtensionAttribute : Attribute
{

    public ExtensionAttribute(string methodName) {
        MethodName = methodName;
    }

    public string MethodName { get; }

}