using System.Collections.Generic;
using System.Diagnostics;

namespace GraduatedCylinder
{
	/// <summary>
	///     A dictionary that does not throw when trying to lookup values that do not exist;
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	[DebuggerDisplay("Count = {Count}")]
	internal class SafeDictionary<TKey, TValue> : Dictionary<TKey, TValue>
		where TValue : class
	{
		public new TValue this[TKey key] {
			get {
				TValue value;
				TryGetValue(key, out value);
				return value;
			}
			set { base[key] = value; }
		}
	}
}