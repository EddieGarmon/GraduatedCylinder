using System;

namespace GraduatedCylinder
{
    public class Angle : Dimension,
                         IDimension<AngleUnit>,
                         IEquatable<Angle>,
                         IComparable<Angle>
    {
        public Angle(double value, AngleUnit units)
            : base(value, units) { }

        public Angle(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Angle);
        }

        internal Angle(double valueInBaseUnits)
            : base(valueInBaseUnits, AngleUnit.BaseUnit) { }

        public int CompareTo(Angle other) {
            return base.CompareTo(other);
        }

        public bool Equals(Angle other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return (obj is Angle angle) && Equals(angle);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(AngleUnit units) {
            return base.In(units);
        }

        public string ToString(AngleUnit units) {
            return base.ToString(units);
        }

        public string ToString(AngleUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Angle Zero => new Angle(0);

        public static Angle Parse(string input) {
            return (Angle)Factory.Parse(input, DimensionType.Angle);
        }

        public static Angle operator +(Angle angle1, Angle angle2) {
            Guard.NotNull(angle1, nameof(angle1));
            Guard.NotNull(angle2, nameof(angle2));
            return new Angle(angle1.ValueInBaseUnits + angle2.ValueInBaseUnits) {
                Units = angle1.Units
            };
        }

        public static double operator /(Angle numerator, Angle denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static Angle operator /(Angle angle, double scaler) {
            Guard.NotNull(angle, nameof(angle));
            return new Angle(angle.ValueInBaseUnits / scaler) {
                Units = angle.Units
            };
        }

        public static bool operator ==(Angle left, Angle right) {
            return Equals(left, right);
        }

        public static bool operator >(Angle left, Angle right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Angle left, Angle right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Angle left, Angle right) {
            return !Equals(left, right);
        }

        public static bool operator <(Angle left, Angle right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Angle left, Angle right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Angle operator *(Angle angle, double scaler) {
            Guard.NotNull(angle, nameof(angle));
            return new Angle(angle.ValueInBaseUnits * scaler) {
                Units = angle.Units
            };
        }

        public static Angle operator *(double scaler, Angle angle) {
            Guard.NotNull(angle, nameof(angle));
            return new Angle(angle.ValueInBaseUnits * scaler) {
                Units = angle.Units
            };
        }

        public static Angle operator -(Angle angle1, Angle angle2) {
            Guard.NotNull(angle1, nameof(angle1));
            Guard.NotNull(angle2, nameof(angle2));
            return new Angle(angle1.ValueInBaseUnits - angle2.ValueInBaseUnits) {
                Units = angle1.Units
            };
        }
    }
}