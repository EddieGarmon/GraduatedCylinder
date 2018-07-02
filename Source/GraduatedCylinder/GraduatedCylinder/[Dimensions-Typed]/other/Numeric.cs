using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     A 'unitless' dimension.
    /// </summary>
    public class Numeric : Dimension,
                           IEquatable<Numeric>,
                           IComparable<Numeric>
    {
        public Numeric(double value, NumericUnit units = NumericUnit.Empty)
            : base(value, units) { }

        public Numeric(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) { }

        internal Numeric(double valueInBaseUnits)
            : base(valueInBaseUnits, NumericUnit.BaseUnit) { }

        public int CompareTo(Numeric other) {
            return base.CompareTo(other);
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return (obj is Numeric) && Equals((Numeric)obj);
        }

        public bool Equals(Numeric other) {
            return CompareTo(other) == 0;
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(NumericUnit units) {
            return base.In(units);
        }

        public string ToString(NumericUnit units) {
            return base.ToString(units);
        }

        public string ToString(NumericUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Numeric operator +(Numeric left, Numeric right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new Numeric(left.ValueInBaseUnits + right.ValueInBaseUnits) {
                Units = left.Units
            };
        }

        public static Numeric operator /(Numeric top, Numeric bottom) {
            Guard.NotNull(top, "top");
            Guard.NotNull(bottom, "bottom");
            return new Numeric(top.ValueInBaseUnits / bottom.ValueInBaseUnits) {
                Units = top.Units
            };
        }

        public static Numeric operator /(Numeric top, double scaler) {
            Guard.NotNull(top, "top");
            return new Numeric(top.ValueInBaseUnits / scaler) {
                Units = top.Units
            };
        }

        public static bool operator ==(Numeric left, Numeric right) {
            return Equals(left, right);
        }

        public static bool operator >(Numeric left, Numeric right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Numeric left, Numeric right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static implicit operator double(Numeric value) {
            return value.In(NumericUnit.Empty);
        }

        public static implicit operator int(Numeric value) {
            return (int)value.In(NumericUnit.Empty);
        }

        public static implicit operator Numeric(double value) {
            return new Numeric(value, NumericUnit.Empty);
        }

        public static implicit operator Numeric(int value) {
            return new Numeric(value, NumericUnit.Empty);
        }

        public static bool operator !=(Numeric left, Numeric right) {
            return !Equals(left, right);
        }

        public static bool operator <(Numeric left, Numeric right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Numeric left, Numeric right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Numeric operator *(Numeric left, Numeric right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new Numeric(left.ValueInBaseUnits * right.ValueInBaseUnits) {
                Units = left.Units
            };
        }

        public static Numeric operator *(Numeric numeric, double scaler) {
            Guard.NotNull(numeric, "numeric");
            return new Numeric(numeric.ValueInBaseUnits * scaler) {
                Units = numeric.Units
            };
        }

        public static Numeric operator -(Numeric left, Numeric right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new Numeric(left.ValueInBaseUnits - right.ValueInBaseUnits) {
                Units = left.Units
            };
        }
    }
}