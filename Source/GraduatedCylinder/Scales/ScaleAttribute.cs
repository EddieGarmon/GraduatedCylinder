using System;
using System.Diagnostics;

namespace GraduatedCylinder.Scales;

/// <summary>
///     This attribute should be applied to units that only need scaling to go to and
///     from the base units.
/// </summary>
[DebuggerDisplay("ScaleFactor: {ScaleFactor}")]
public sealed class ScaleAttribute : Attribute
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
    public double ScaleFactor { get; private set; }

}