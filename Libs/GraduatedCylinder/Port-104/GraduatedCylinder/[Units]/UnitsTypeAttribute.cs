using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This class is intended for book keeping and internal automation
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class UnitsTypeAttribute : Attribute
    {
        private readonly Type _unitsType;

        public UnitsTypeAttribute(Type unitsType) {
            _unitsType = unitsType;
        }

        public Type UnitsType {
            get { return _unitsType; }
        }
    }
}