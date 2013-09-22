using System;
using System.ComponentModel;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This is a base attribute that should be used when defining conversion
    ///     attributes that are applied to the enumeration values of a dimensions units.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class ScaleDefinitionAttribute : Attribute
    {
        /// <summary>
        ///     Gets the unit converter for this unit.
        /// </summary>
        /// <value>The unit converter.</value>
        public abstract IUnitConverter UnitConverter { get; }
    }
}