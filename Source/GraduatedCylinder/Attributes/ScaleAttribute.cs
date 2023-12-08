using System.Diagnostics;

namespace CodeGeneration.Attributes;

/// <summary>
///     This attribute should be applied to units that only need scaling to go to and from the base units.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
[DebuggerDisplay("ScaleFactor: {ScaleFactor}")]
internal sealed class ScaleAttribute : Attribute
{

    /// <summary>
    ///     Initializes a new instance of the <see cref="ScaleAttribute" /> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public ScaleAttribute(double value) {
        ScaleFactor = value;
    }

    /// <summary>
    ///     Gets or sets the scale factor.
    /// </summary>
    /// <value>The scale factor.</value>
    public double ScaleFactor { get; }

}