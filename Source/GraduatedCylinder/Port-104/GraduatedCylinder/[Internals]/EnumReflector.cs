using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraduatedCylinder
{
    /// <summary>
    /// </summary>
    /// <remarks></remarks>
    internal class EnumReflector
    {
        /// <summary>
        ///     Generate an EnumValueDescriptor{TEnum} for all values in an enumeration.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <returns></returns>
        /// <remarks></remarks>
        public static IEnumerable<EnumValueDescriptor<TEnum>> DescribeAllValues<TEnum>() {
            Type enumType = typeof(TEnum);
            EnsureIsEnum(enumType);
            FieldInfo[] publicStaticFields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return publicStaticFields.Select(fieldInfo => new EnumValueDescriptor<TEnum>(fieldInfo));
        }

        /// <summary>
        ///     Describes all values as byte.
        /// </summary>
        /// <param name="enumType">Type of the enumeration.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static IEnumerable<EnumValueDescriptor<byte>> DescribeAllValuesAsByte(Type enumType) {
            EnsureIsEnum(enumType);
            FieldInfo[] publicStaticFields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return publicStaticFields.Select(fieldInfo => new EnumValueDescriptor<byte>(fieldInfo));
        }

        /// <summary>
        ///     Describes all values as int16.
        /// </summary>
        /// <param name="enumType">Type of the enumeration.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static IEnumerable<EnumValueDescriptor<short>> DescribeAllValuesAsInt16(Type enumType) {
            EnsureIsEnum(enumType);
            FieldInfo[] publicStaticFields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return publicStaticFields.Select(fieldInfo => new EnumValueDescriptor<short>(fieldInfo));
        }

        /// <summary>
        ///     Describes all values as int32.
        /// </summary>
        /// <param name="enumType">Type of the enumeration.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static IEnumerable<EnumValueDescriptor<int>> DescribeAllValuesAsInt32(Type enumType) {
            EnsureIsEnum(enumType);
            FieldInfo[] publicStaticFields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return publicStaticFields.Select(fieldInfo => new EnumValueDescriptor<int>(fieldInfo));
        }

        /// <summary>
        ///     Describes all values as int64.
        /// </summary>
        /// <param name="enumType">Type of the enumeration.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static IEnumerable<EnumValueDescriptor<long>> DescribeAllValuesAsInt64(Type enumType) {
            EnsureIsEnum(enumType);
            FieldInfo[] publicStaticFields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return publicStaticFields.Select(fieldInfo => new EnumValueDescriptor<long>(fieldInfo));
        }

        /// <summary>
        ///     Describes all values as signed byte.
        /// </summary>
        /// <param name="enumType">Type of the enumeration.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static IEnumerable<EnumValueDescriptor<sbyte>> DescribeAllValuesAsSignedByte(Type enumType) {
            EnsureIsEnum(enumType);
            FieldInfo[] publicStaticFields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return publicStaticFields.Select(fieldInfo => new EnumValueDescriptor<sbyte>(fieldInfo));
        }

        /// <summary>
        ///     Describes all values as U int16.
        /// </summary>
        /// <param name="enumType">Type of the enumeration.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static IEnumerable<EnumValueDescriptor<ushort>> DescribeAllValuesAsUInt16(Type enumType) {
            EnsureIsEnum(enumType);
            FieldInfo[] publicStaticFields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return publicStaticFields.Select(fieldInfo => new EnumValueDescriptor<ushort>(fieldInfo));
        }

        /// <summary>
        ///     Describes all values as U int32.
        /// </summary>
        /// <param name="enumType">Type of the enumeration.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static IEnumerable<EnumValueDescriptor<uint>> DescribeAllValuesAsUInt32(Type enumType) {
            EnsureIsEnum(enumType);
            FieldInfo[] publicStaticFields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return publicStaticFields.Select(fieldInfo => new EnumValueDescriptor<uint>(fieldInfo));
        }

        /// <summary>
        ///     Describes all values as U int64.
        /// </summary>
        /// <param name="enumType">Type of the enumeration.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static IEnumerable<EnumValueDescriptor<ulong>> DescribeAllValuesAsUInt64(Type enumType) {
            EnsureIsEnum(enumType);
            FieldInfo[] publicStaticFields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return publicStaticFields.Select(fieldInfo => new EnumValueDescriptor<ulong>(fieldInfo));
        }

        /// <summary>
        ///     Ensures the type is an enumeration.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <exception cref="Exception">
        ///     <c>Exception</c>.
        /// </exception>
        /// <remarks></remarks>
        public static void EnsureIsEnum(Type type) {
            if (!type.IsEnum) {
                throw new Exception(type + " is not an enumeration.");
            }
        }

        /// <summary>
        ///     Gets the enumeration level attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="enumValue">The enumeration value.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static TAttribute[] GetEnumAttributes<TAttribute>(object enumValue) where TAttribute : Attribute {
            Type enumType = enumValue.GetType();
            EnsureIsEnum(enumType);
            return (TAttribute[])enumType.GetCustomAttributes(typeof(TAttribute), false);
        }

        /// <summary>
        ///     Gets the enumeration value attribute.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <param name="enumValue">The enumeration value.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static TAttribute[] GetValueAttributes<TAttribute>(object enumValue) where TAttribute : Attribute {
            Type enumType = enumValue.GetType();
            EnsureIsEnum(enumType);
            //use a long as all integral types have an implicit conversion to long, and we don't care about the value here.
            EnumValueDescriptor<long> descriptor = new EnumValueDescriptor<long>((long)enumValue);
            return descriptor.GetAttributes<TAttribute>();
        }

        /// <summary>
        ///     Parses the string into an enumeration value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enumeration.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <remarks>If the enumeration is a flags based enumeration, then parsing supports both '|' and ',' flag separators.</remarks>
        public static TEnum Parse<TEnum>(string value) {
            Type enumType = typeof(TEnum);
            if (enumType.GetCustomAttributes(typeof(FlagsAttribute), true).Length > 0) {
                value = value.Replace('|', ',');
            }
            TEnum result = (TEnum)Enum.Parse(enumType, value, true);
            return result;
        }
    }
}