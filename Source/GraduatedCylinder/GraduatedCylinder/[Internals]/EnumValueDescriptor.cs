using System;
using System.Linq;
using System.Reflection;

namespace GraduatedCylinder
{
    internal class EnumValueDescriptor<TEnum>
    {
        private readonly FieldInfo _fieldInfo;
        private readonly string _name;
        private readonly TEnum _value;

        public EnumValueDescriptor(FieldInfo fieldInfo) {
            _fieldInfo = fieldInfo;
            _name = _fieldInfo.Name;
            _value = (TEnum)_fieldInfo.GetValue(typeof(TEnum));
        }

        public EnumValueDescriptor(TEnum enumValue) {
            _value = enumValue;
            _name = enumValue.ToString();
            _fieldInfo = typeof(TEnum).GetField(_name, BindingFlags.Public | BindingFlags.Static);
        }

        public string Description {
            get {
                DescriptionAttribute attribute = GetAttributes<DescriptionAttribute>()
                    .FirstOrDefault();
                return attribute == null ? null : attribute.Description;
            }
        }

        public string Name {
            get { return _name; }
        }

        public TEnum Value {
            get { return _value; }
        }

        public TAttribute EnsureOnlyOneAttribute<TAttribute>()
            where TAttribute : Attribute {
            TAttribute[] attributes = GetAttributes<TAttribute>();
            if (attributes.Length == 0) {
                const string format = "No '{0}' is defined on the enumeration value {1}.{2}";
                throw new Exception(string.Format(format, typeof(TAttribute), typeof(TEnum), _name));
            }
            if (attributes.Length > 1) {
                const string format = "More than one '{0}' is defined on the enumeration value {1}.{2}";
                throw new Exception(string.Format(format, typeof(TAttribute), typeof(TEnum), _name));
            }
            return attributes[0];
        }

        public TAttribute[] GetAttributes<TAttribute>()
            where TAttribute : Attribute {
            return (TAttribute[])_fieldInfo.GetCustomAttributes(typeof(TAttribute), false);
        }

        public bool HasAttribute<TAttribute>()
            where TAttribute : Attribute {
            return GetAttributes<TAttribute>()
                       .Length > 0;
        }
    }
}