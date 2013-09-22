using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This dimension represents Angular Acceleration, which is the second derivative of
    ///     position with respect to time, and the first derivative of revolutions with respect
    ///     to time.
    /// </summary>
    public class AngularAcceleration : Dimension, IEquatable<AngularAcceleration>, IComparable<AngularAcceleration>
    {
        public AngularAcceleration(double value, AngularAccelerationUnit units)
            : base(value, units) {}

        public AngularAcceleration(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.AngularAcceleration);
        }

        internal AngularAcceleration(double valueInBaseUnits)
            : base(valueInBaseUnits, AngularAccelerationUnit.BaseUnit) {}

        public int CompareTo(AngularAcceleration other) {
            return base.CompareTo(other);
        }

        public bool Equals(AngularAcceleration other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(AngularAcceleration)) {
                return false;
            }
            return Equals((AngularAcceleration)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public static AngularAcceleration operator +(AngularAcceleration angularAcceleration1, AngularAcceleration angularAcceleration2) {
            Guard.NotNull(angularAcceleration1, "angularAcceleration1");
            Guard.NotNull(angularAcceleration2, "angularAcceleration2");
            return new AngularAcceleration(angularAcceleration1.ValueInBaseUnits + angularAcceleration2.ValueInBaseUnits) {
                Units = angularAcceleration1.Units
            };
        }

        public static AngularAcceleration operator /(AngularAcceleration angularAcceleration, double scaler) {
            Guard.NotNull(angularAcceleration, "angularAcceleration");
            return new AngularAcceleration(angularAcceleration.ValueInBaseUnits / scaler) {Units = angularAcceleration.Units};
        }

        public static double operator /(AngularAcceleration numerator, AngularAcceleration denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(AngularAcceleration left, AngularAcceleration right) {
            return Equals(left, right);
        }

        public static bool operator >(AngularAcceleration left, AngularAcceleration right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(AngularAcceleration left, AngularAcceleration right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(AngularAcceleration left, AngularAcceleration right) {
            return !Equals(left, right);
        }

        public static bool operator <(AngularAcceleration left, AngularAcceleration right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(AngularAcceleration left, AngularAcceleration right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static AngularAcceleration operator *(AngularAcceleration angularAcceleration, double scaler) {
            Guard.NotNull(angularAcceleration, "angularAcceleration");
            return new AngularAcceleration(angularAcceleration.ValueInBaseUnits * scaler) {Units = angularAcceleration.Units};
        }

        public static AngularAcceleration operator *(double scaler, AngularAcceleration angularAcceleration) {
            Guard.NotNull(angularAcceleration, "angularAcceleration");
            return new AngularAcceleration(angularAcceleration.ValueInBaseUnits * scaler) {Units = angularAcceleration.Units};
        }

        public static AngularAcceleration operator -(AngularAcceleration left, AngularAcceleration right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new AngularAcceleration(left.ValueInBaseUnits - right.ValueInBaseUnits) {Units = left.Units};
        }
    }
}