using System;

namespace GraduatedCylinder
{
    [AttributeUsage(AttributeTargets.All)]
    internal class DescriptionAttribute : Attribute
    {
        private readonly string _description;

        public DescriptionAttribute(string description) {
            _description = description;
        }

        public virtual string Description {
            get { return _description; }
        }

        public override bool Equals(object obj) {
            if (obj == this) {
                return true;
            }

            DescriptionAttribute other = obj as DescriptionAttribute;

            return (other != null) && other.Description == Description;
        }

        public override int GetHashCode() {
            return Description.GetHashCode();
        }
    }
}