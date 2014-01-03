using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This dimension represents the rate of change of acceleration.
    /// </summary>
    public class Jerk : Dimension,
                        IEquatable<Jerk>,
                        IComparable<Jerk>
    {
        public Jerk(double value, JerkUnit units)
            : base(value, units) { }

        public Jerk(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Jerk);
        }

        internal Jerk(double valueInBaseUnits)
            : base(valueInBaseUnits, JerkUnit.BaseUnit) { }

        public int CompareTo(Jerk other) {
            return base.CompareTo(other);
        }

        public bool Equals(Jerk other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Jerk)) {
                return false;
            }
            return Equals((Jerk)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(JerkUnit units) {
            return base.In(units);
        }

        public string ToString(JerkUnit units) {
            return base.ToString(units);
        }

        public string ToString(JerkUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Jerk operator +(Jerk left, Jerk right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new Jerk(left.ValueInBaseUnits + right.ValueInBaseUnits) {
                Units = left.Units
            };
        }

        public static Jerk operator /(Jerk jerk, double scaler) {
            Guard.NotNull(jerk, "jerk");
            return new Jerk(jerk.ValueInBaseUnits / scaler) {
                Units = jerk.Units
            };
        }

        public static double operator /(Jerk numerator, Jerk denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Jerk left, Jerk right) {
            return Equals(left, right);
        }

        public static bool operator >(Jerk left, Jerk right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Jerk left, Jerk right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Jerk left, Jerk right) {
            return !Equals(left, right);
        }

        public static bool operator <(Jerk left, Jerk right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Jerk left, Jerk right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Jerk operator *(Jerk jerk, double scaler) {
            Guard.NotNull(jerk, "jerk");
            return new Jerk(jerk.ValueInBaseUnits * scaler) {
                Units = jerk.Units
            };
        }

        public static Jerk operator *(double scaler, Jerk jerk) {
            Guard.NotNull(jerk, "jerk");
            return new Jerk(jerk.ValueInBaseUnits * scaler) {
                Units = jerk.Units
            };
        }

        public static Acceleration operator *(Jerk jerk, Time time) {
            Guard.NotNull(jerk, "jerk");
            Guard.NotNull(time, "time");
            double accelerationValue = jerk.In(JerkUnit.MetersPerSecondCubed) * time.In(TimeUnit.Second);
            return new Acceleration(accelerationValue, AccelerationUnit.MeterPerSecondSquared);
        }

        public static Jerk operator -(Jerk jerk1, Jerk jerk2) {
            Guard.NotNull(jerk1, "jerk1");
            Guard.NotNull(jerk2, "jerk2");
            return new Jerk(jerk1.ValueInBaseUnits - jerk2.ValueInBaseUnits) {
                Units = jerk1.Units
            };
        }
    }
}