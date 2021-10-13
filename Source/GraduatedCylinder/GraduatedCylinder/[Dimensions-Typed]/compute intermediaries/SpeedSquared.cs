using System;

namespace GraduatedCylinder
{
    public class SpeedSquared : Dimension,
                                IEquatable<SpeedSquared>,
                                IComparable<SpeedSquared>
    {
        public SpeedSquared(double value, SpeedSquaredUnit units)
            : base(value, units) { }

        public SpeedSquared(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) { }

        internal SpeedSquared(double baseUnitsValue)
            : base(baseUnitsValue, SpeedSquaredUnit.BaseUnit) { }

        public int CompareTo(SpeedSquared other) {
            return base.CompareTo(other);
        }

        public bool Equals(SpeedSquared other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(SpeedSquared)) {
                return false;
            }
            return Equals((SpeedSquared)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(SpeedSquaredUnit units) {
            return base.In(units);
        }

        public static SpeedSquared operator +(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, nameof(left));
            Guard.NotNull(right, nameof(right));
            return new SpeedSquared(left.ValueInBaseUnits + right.ValueInBaseUnits) {
                Units = left.Units
            };
        }

        public static double operator /(SpeedSquared numerator, SpeedSquared denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static SpeedSquared operator /(SpeedSquared speedSquared, double scaler) {
            Guard.NotNull(speedSquared, nameof(speedSquared));
            return new SpeedSquared(speedSquared.ValueInBaseUnits / scaler) {
                Units = speedSquared.Units
            };
        }

        public static Acceleration operator /(SpeedSquared speedSquared, Length length) {
            Guard.NotNull(speedSquared, nameof(speedSquared));
            Guard.NotNull(length, nameof(length));
            double accelerationValue = speedSquared.In(SpeedSquaredUnit.MetersSquaredPerSecondSquared)
                                       / length.In(LengthUnit.Meter);
            return new Acceleration(accelerationValue, AccelerationUnit.MeterPerSecondSquared);
        }

        public static bool operator >(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, nameof(left));
            Guard.NotNull(right, nameof(right));
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, nameof(left));
            Guard.NotNull(right, nameof(right));
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, nameof(left));
            Guard.NotNull(right, nameof(right));
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, nameof(left));
            Guard.NotNull(right, nameof(right));
            return left.CompareTo(right) <= 0;
        }

        public static SpeedSquared operator *(SpeedSquared value, double scaler) {
            Guard.NotNull(value, nameof(value));
            return new SpeedSquared(value.ValueInBaseUnits * scaler) {
                Units = value.Units
            };
        }

        public static SpeedSquared operator *(double scaler, SpeedSquared value) {
            Guard.NotNull(value, nameof(value));
            return new SpeedSquared(value.ValueInBaseUnits * scaler) {
                Units = value.Units
            };
        }

        public static SpeedSquared operator -(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, nameof(left));
            Guard.NotNull(right, nameof(right));
            return new SpeedSquared(left.ValueInBaseUnits - right.ValueInBaseUnits) {
                Units = left.Units
            };
        }
    }
}