namespace System.Reflection
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="TEnum">The type of the enumeration.</typeparam>
	internal class EnumValueDescriptor<TEnum>
	{
		private readonly FieldInfo _fieldInfo;
		private readonly string _name;
		private readonly TEnum _value;

		/// <summary>
		/// Initializes a new instance of the <see cref="EnumValueDescriptor&lt;TEnum&gt;"/> class.
		/// </summary>
		/// <param name="fieldInfo">The field info.</param>
		public EnumValueDescriptor(FieldInfo fieldInfo)
		{
			_fieldInfo = fieldInfo;
			_name = _fieldInfo.Name;
			_value = (TEnum)_fieldInfo.GetValue(typeof(TEnum));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EnumValueDescriptor&lt;TEnum&gt;"/> class.
		/// </summary>
		/// <param name="enumValue">The enumeration value.</param>
		/// <remarks></remarks>
		public EnumValueDescriptor(TEnum enumValue)
		{
			_value = enumValue;
			_name = enumValue.ToString();
			_fieldInfo = typeof(TEnum).GetField(_name, BindingFlags.Public | BindingFlags.Static);
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		public TEnum Value
		{
			get { return _value; }
		}

		/// <summary>
		/// Ensures the only one attribute.
		/// </summary>
		/// <typeparam name="TAttribute">The type of the attribute.</typeparam>
		/// <returns></returns>
		public TAttribute EnsureOnlyOneAttribute<TAttribute>() where TAttribute : Attribute
		{
			TAttribute[] attributes = GetAttributes<TAttribute>();
			if (attributes.Length == 0)
			{
				const string format = "No '{0}' is defined on the enumeration value {1}.{2}";
				throw new Exception(string.Format(format, typeof(TAttribute), typeof(TEnum), _name));
			}
			if (attributes.Length > 1)
			{
				const string format = "More than one '{0}' is defined on the enumeration value {1}.{2}";
				throw new Exception(string.Format(format, typeof(TAttribute), typeof(TEnum), _name));
			}
			return attributes[0];
		}

		/// <summary>
		/// Gets the attributes.
		/// </summary>
		/// <typeparam name="TAttribute">The type of the attribute.</typeparam>
		/// <returns></returns>
		public TAttribute[] GetAttributes<TAttribute>() where TAttribute : Attribute
		{
			return (TAttribute[])_fieldInfo.GetCustomAttributes(typeof(TAttribute), false);
		}

		/// <summary>
		/// Determines whether this instance has attribute.
		/// </summary>
		/// <typeparam name="TAttribute">The type of the attribute.</typeparam>
		/// <returns>
		/// 	<c>true</c> if this instance has attribute; otherwise, <c>false</c>.
		/// </returns>
		public bool HasAttribute<TAttribute>() where TAttribute : Attribute
		{
			return GetAttributes<TAttribute>().Length > 0;
		}
	}
}