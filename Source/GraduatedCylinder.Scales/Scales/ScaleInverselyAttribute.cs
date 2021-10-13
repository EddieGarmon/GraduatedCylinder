using System;
using System.Diagnostics;

namespace GraduatedCylinder.Scales
{
    /// <summary>
    ///     This attribute should be applied to units that need inverse proportionality and scaling to go to and
    ///     from the base units.
    /// </summary>
    [DebuggerDisplay("InverseScaleFactor: {InverseScaleFactor} | ScaleFactor: {ScaleFactor}")]
    public sealed class ScaleInverselyAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ScaleInverselyAttribute" /> class.
        /// </summary>
        /// <param name="inverseScaleFactor">The inverse scale factor.</param>
        /// <param name="scaleFactor">The value.</param>
        public ScaleInverselyAttribute(float inverseScaleFactor, float scaleFactor) {
            InverseScaleFactor = inverseScaleFactor;
            ScaleFactor = scaleFactor;
        }

        /// <summary>
        ///     Gets or sets the inverse proportionality scale factor.
        /// </summary>
        /// <value>The inverse proportionality scale factor.</value>
        public float InverseScaleFactor { get; private set; }

        /// <summary>
        ///     Gets or sets the scale factor.
        /// </summary>
        /// <value>The scale factor.</value>
        public float ScaleFactor { get; private set; }

    }
}