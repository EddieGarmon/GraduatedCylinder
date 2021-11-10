using System;
using System.Diagnostics;

namespace GraduatedCylinder.Scales;

/// <summary>
///     This attribute should be applied to units that need scaling and 'zero' offset
///     translation to go to and from the base units.
/// </summary>
[DebuggerDisplay("ScaleFactor: {ScaleFactor} | Offset: {Offset}")]
public sealed class ScaleAndOffsetAttribute : Attribute
{

    /// <summary>
    ///     Initializes a new instance of the <see cref="ScaleAndOffsetAttribute" /> class.
    /// </summary>
    /// <param name="scaleFactor">The ratio of this unit to the base unit</param>
    /// <param name="offset">The offset from the base units to align the 'zero' value.</param>
    public ScaleAndOffsetAttribute(double scaleFactor, double offset) {
        ScaleFactor = scaleFactor;
        Offset = offset;
    }

    /// <summary>
    ///     Gets or sets the 'zero' offset.
    /// </summary>
    /// <value>The offset.</value>
    public double Offset { get; private set; }

    /// <summary>
    ///     Gets or sets the scale factor.
    /// </summary>
    /// <value>The scale factor.</value>
    public double ScaleFactor { get; private set; }

}