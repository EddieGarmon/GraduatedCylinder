using System;

namespace GraduatedCylinder
{
	/// <summary>
	///     This dimension represents current.
	/// </summary>
	public class Current : Dimension, IEquatable<Current>, IComparable<Current>
	{
		public Current(double value, CurrentUnit units)
			: base(value, units) {}

		public Current(double value, UnitOfMeasure unitOfMeasure)
			: base(value, unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Current);
		}

		internal Current(double valueInBaseUnits)
			: base(valueInBaseUnits, CurrentUnit.BaseUnit) {}

		public int CompareTo(Current other) {
			return base.CompareTo(other);
		}

		public bool Equals(Current other) {
			return CompareTo(other) == 0;
		}

		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}
			if (ReferenceEquals(this, obj)) {
				return true;
			}
			if (obj.GetType() != typeof(Current)) {
				return false;
			}
			return Equals((Current)obj);
		}

		public override int GetHashCode() {
			return ValueInBaseUnits.GetHashCode();
		}

		public static Current operator +(Current current1, Current current2) {
			Guard.NotNull(current1, "current1");
			Guard.NotNull(current2, "current2");
			return new Current(current1.ValueInBaseUnits + current2.ValueInBaseUnits) {Units = current1.Units};
		}

		public static Current operator /(Current current, double scaler) {
			Guard.NotNull(current, "current");
			return new Current(current.ValueInBaseUnits / scaler) {Units = current.Units};
		}

		public static double operator /(Current numerator, Current denominator) {
			Guard.NotNull(numerator, "numerator");
			Guard.NotNull(denominator, "denominator");
			return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
		}

		public static bool operator ==(Current left, Current right) {
			return Equals(left, right);
		}

		public static bool operator >(Current left, Current right) {
			return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
		}

		public static bool operator >=(Current left, Current right) {
			return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
		}

		public static bool operator !=(Current left, Current right) {
			return !Equals(left, right);
		}

		public static bool operator <(Current left, Current right) {
			return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
		}

		public static bool operator <=(Current left, Current right) {
			return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
		}

		public static Current operator *(Current current, double scaler) {
			Guard.NotNull(current, "current");
			return new Current(current.ValueInBaseUnits * scaler) {Units = current.Units};
		}

		public static Current operator *(double scaler, Current current) {
			Guard.NotNull(current, "current");
			return new Current(current.ValueInBaseUnits * scaler) {Units = current.Units};
		}

		public static Power operator *(Current current, Voltage voltage) {
			Guard.NotNull(current, "current");
			Guard.NotNull(voltage, "voltage");
			double powerValue = current.In(CurrentUnit.Amperes) * voltage.In(VoltageUnit.Volts);
			return new Power(powerValue, PowerUnit.Watts);
		}

		public static Voltage operator *(Current current, Resistance resistance) {
			Guard.NotNull(resistance, "resistance");
			Guard.NotNull(current, "current");
			double voltageValue = current.In(CurrentUnit.Amperes) * resistance.In(ResistanceUnit.Ohms);
			return new Voltage(voltageValue, VoltageUnit.Volts);
		}

		public static Current operator -(Current current1, Current current2) {
			Guard.NotNull(current1, "current1");
			Guard.NotNull(current2, "current2");
			return new Current(current1.ValueInBaseUnits - current2.ValueInBaseUnits) {Units = current1.Units};
		}
	}
}