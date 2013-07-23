using System;

namespace GraduatedCylinder
{
	/// <summary>
	///     This dimension represents frequency.
	/// </summary>
	public class Frequency : Dimension, IEquatable<Frequency>, IComparable<Frequency>
	{
		public Frequency(double value, FrequencyUnit units)
			: base(value, units) {}

		public Frequency(double value, UnitOfMeasure unitOfMeasure)
			: base(value, unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Frequency);
		}

		internal Frequency(double valueInBaseUnits)
			: base(valueInBaseUnits, FrequencyUnit.BaseUnit) {}

		public int CompareTo(Frequency other) {
			return base.CompareTo(other);
		}

		public bool Equals(Frequency other) {
			return CompareTo(other) == 0;
		}

		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}
			if (ReferenceEquals(this, obj)) {
				return true;
			}
			if (obj.GetType() != typeof(Frequency)) {
				return false;
			}
			return Equals((Frequency)obj);
		}

		public override int GetHashCode() {
			return ValueInBaseUnits.GetHashCode();
		}

		public static Frequency operator +(Frequency frequency1, Frequency frequency2) {
			Guard.NotNull(frequency1, "frequency1");
			Guard.NotNull(frequency2, "frequency2");
			return new Frequency(frequency1.ValueInBaseUnits + frequency2.ValueInBaseUnits) {Units = frequency1.Units};
		}

		public static Frequency operator /(Frequency frequency, double scaler) {
			Guard.NotNull(frequency, "frequency");
			return new Frequency(frequency.ValueInBaseUnits / scaler) {Units = frequency.Units};
		}

		public static double operator /(Frequency numerator, Frequency denominator) {
			Guard.NotNull(numerator, "numerator");
			Guard.NotNull(denominator, "denominator");
			return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
		}

		public static bool operator ==(Frequency left, Frequency right) {
			return Equals(left, right);
		}

		public static bool operator >(Frequency left, Frequency right) {
			return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
		}

		public static bool operator >=(Frequency left, Frequency right) {
			return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
		}

		public static bool operator !=(Frequency left, Frequency right) {
			return !Equals(left, right);
		}

		public static bool operator <(Frequency left, Frequency right) {
			return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
		}

		public static bool operator <=(Frequency left, Frequency right) {
			return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
		}

		public static Frequency operator *(Frequency frequency, double scaler) {
			Guard.NotNull(frequency, "frequency");
			return new Frequency(frequency.ValueInBaseUnits * scaler) {Units = frequency.Units};
		}

		public static Frequency operator *(double scaler, Frequency frequency) {
			Guard.NotNull(frequency, "frequency");
			return new Frequency(frequency.ValueInBaseUnits * scaler) {Units = frequency.Units};
		}

		public static Frequency operator -(Frequency frequency1, Frequency frequency2) {
			Guard.NotNull(frequency1, "frequency1");
			Guard.NotNull(frequency2, "frequency2");
			return new Frequency(frequency1.ValueInBaseUnits - frequency2.ValueInBaseUnits) {Units = frequency1.Units};
		}
	}
}