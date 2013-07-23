using System;

namespace GraduatedCylinder
{
	/// <summary>
	///     This dimension represents rate of Mass flow.
	/// </summary>
	public class MassFlowRate : Dimension, IEquatable<MassFlowRate>, IComparable<MassFlowRate>
	{
		public MassFlowRate(double value, MassFlowRateUnit units)
			: base(value, units) {}

		public MassFlowRate(double value, UnitOfMeasure unitOfMeasure)
			: base(value, unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.MassFlowRate);
		}

		internal MassFlowRate(double valueInBaseUnits)
			: base(valueInBaseUnits, MassFlowRateUnit.BaseUnit) {}

		public int CompareTo(MassFlowRate other) {
			return base.CompareTo(other);
		}

		public bool Equals(MassFlowRate other) {
			return CompareTo(other) == 0;
		}

		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}
			if (ReferenceEquals(this, obj)) {
				return true;
			}
			if (obj.GetType() != typeof(MassFlowRate)) {
				return false;
			}
			return Equals((MassFlowRate)obj);
		}

		public override int GetHashCode() {
			return ValueInBaseUnits.GetHashCode();
		}

		public static MassFlowRate operator +(MassFlowRate massFlowRate1, MassFlowRate massFlowRate2) {
			Guard.NotNull(massFlowRate1, "massFlowRate1");
			Guard.NotNull(massFlowRate2, "massFlowRate2");
			return new MassFlowRate(massFlowRate1.ValueInBaseUnits + massFlowRate2.ValueInBaseUnits) {Units = massFlowRate1.Units};
		}

		public static MassFlowRate operator /(MassFlowRate massFlowRate, double scaler) {
			Guard.NotNull(massFlowRate, "massFlowRate");
			return new MassFlowRate(massFlowRate.ValueInBaseUnits / scaler) {Units = massFlowRate.Units};
		}

		public static double operator /(MassFlowRate numerator, MassFlowRate denominator) {
			Guard.NotNull(numerator, "numerator");
			Guard.NotNull(denominator, "denominator");
			return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
		}

		public static bool operator ==(MassFlowRate left, MassFlowRate right) {
			return Equals(left, right);
		}

		public static bool operator >(MassFlowRate left, MassFlowRate right) {
			return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
		}

		public static bool operator >=(MassFlowRate left, MassFlowRate right) {
			return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
		}

		public static bool operator !=(MassFlowRate left, MassFlowRate right) {
			return !Equals(left, right);
		}

		public static bool operator <(MassFlowRate left, MassFlowRate right) {
			return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
		}

		public static bool operator <=(MassFlowRate left, MassFlowRate right) {
			return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
		}

		public static MassFlowRate operator *(MassFlowRate massFlowRate, double scaler) {
			Guard.NotNull(massFlowRate, "massFlowRate");
			return new MassFlowRate(massFlowRate.ValueInBaseUnits * scaler) {Units = massFlowRate.Units};
		}

		public static MassFlowRate operator *(double scaler, MassFlowRate massFlowRate) {
			Guard.NotNull(massFlowRate, "massFlowRate");
			return new MassFlowRate(massFlowRate.ValueInBaseUnits * scaler) {Units = massFlowRate.Units};
		}

		public static Mass operator *(MassFlowRate massFlowRate, Time time) {
			Guard.NotNull(massFlowRate, "massFlowRate");
			Guard.NotNull(time, "time");
			double massValue = massFlowRate.In(MassFlowRateUnit.KilogramsPerSecond) * time.In(TimeUnit.Seconds);
			return new Mass(massValue, MassUnit.Kilograms);
		}

		public static MassFlowRate operator -(MassFlowRate massFlowRate1, MassFlowRate massFlowRate2) {
			Guard.NotNull(massFlowRate1, "massFlowRate1");
			Guard.NotNull(massFlowRate2, "massFlowRate2");
			return new MassFlowRate(massFlowRate1.ValueInBaseUnits - massFlowRate2.ValueInBaseUnits) {Units = massFlowRate1.Units};
		}
	}
}