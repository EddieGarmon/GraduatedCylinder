using System.Diagnostics;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This attribute should be applied to units that need inverse proportionality and scaling to go to and
    ///     from the base units.
    /// </summary>
    [DebuggerDisplay("ScaleFactor: {ScaleFactor} | InverseScaleFactor: {InverseScaleFactor}")]
    public sealed class ScaleInverselyAttribute : ScaleDefinitionAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ScaleInverselyAttribute" /> class.
        /// </summary>
        /// <param name="inversescalefactor">The inverse scale factor.</param>
        /// <param name="scalefactor">The value.</param>
        public ScaleInverselyAttribute(double inversescalefactor, double scalefactor) {
            InverseScaleFactor = inversescalefactor;
            ScaleFactor = scalefactor;
        }

        /// <summary>
        ///     Gets or sets the inverse proportionality scale factor.
        /// </summary>
        /// <value>The inverse proportionality scale factor.</value>
        public double InverseScaleFactor { get; private set; }

        /// <summary>
        ///     Gets or sets the scale factor.
        /// </summary>
        /// <value>The scale factor.</value>
        public double ScaleFactor { get; private set; }

        /// <summary>
        ///     Gets the unit converter for this unit.
        /// </summary>
        /// <value>The unit converter.</value>
        public override IUnitConverter UnitConverter {
            get { return new ScaleInverselyUnitConverter(InverseScaleFactor, ScaleFactor); }
        }
    }
}