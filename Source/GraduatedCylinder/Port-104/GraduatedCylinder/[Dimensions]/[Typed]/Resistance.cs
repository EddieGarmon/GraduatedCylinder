using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Represents Electric Resistance.
    /// </summary>
    public class Resistance : Dimension, IEquatable<Resistance>, IComparable<Resistance>
    {
        public Resistance(double value, ResistanceUnit units)
            : base(value, units) { }

        public Resistance(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Resistance);
        }

        internal Resistance(double valueInBaseUnits)
            : base(valueInBaseUnits, ResistanceUnit.BaseUnit) { }

        public int CompareTo(Resistance other) {
            return base.CompareTo(other);
        }

        public bool Equals(Resistance other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Resistance)) {
                return false;
            }
            return Equals((Resistance)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public string ToString(ResistanceUnit units) {
            return base.ToString(units);
        }

        public string ToString(ResistanceUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Resistance operator +(Resistance resistance1, Resistance resistance2) {
            Guard.NotNull(resistance1, "resistance1");
            Guard.NotNull(resistance2, "resistance2");
            return new Resistance(resistance1.ValueInBaseUnits + resistance2.ValueInBaseUnits) { Units = resistance1.Units };
        }

        public static Resistance operator /(Resistance resistance, double scaler) {
            Guard.NotNull(resistance, "resistance");
            return new Resistance(resistance.ValueInBaseUnits / scaler) { Units = resistance.Units };
        }

        public static double operator /(Resistance numerator, Resistance denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Resistance left, Resistance right) {
            return Equals(left, right);
        }

        public static bool operator >(Resistance left, Resistance right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Resistance left, Resistance right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Resistance left, Resistance right) {
            return !Equals(left, right);
        }

        public static bool operator <(Resistance left, Resistance right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Resistance left, Resistance right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Resistance operator *(Resistance resistance, double scaler) {
            Guard.NotNull(resistance, "resistance");
            return new Resistance(resistance.ValueInBaseUnits * scaler) { Units = resistance.Units };
        }

        public static Resistance operator *(double scaler, Resistance resistance) {
            Guard.NotNull(resistance, "resistance");
            return new Resistance(resistance.ValueInBaseUnits * scaler) { Units = resistance.Units };
        }

        public static Voltage operator *(Resistance resistance, Current current) {
            Guard.NotNull(resistance, "resistance");
            Guard.NotNull(current, "current");
            double voltageValue = resistance.In(ResistanceUnit.Ohms) * current.In(CurrentUnit.Amperes);
            return new Voltage(voltageValue, VoltageUnit.Volts);
        }

        public static Resistance operator -(Resistance resistance1, Resistance resistance2) {
            Guard.NotNull(resistance1, "resistance1");
            Guard.NotNull(resistance2, "resistance2");
            return new Resistance(resistance1.ValueInBaseUnits - resistance2.ValueInBaseUnits) { Units = resistance1.Units };
        }
    }
}