using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Represents the AngularVelocity dimension.
    /// </summary>
    public class AngularVelocity : Dimension, IEquatable<AngularVelocity>, IComparable<AngularVelocity>
    {
        public AngularVelocity(double value, AngularVelocityUnit units)
            : base(value, units) {}

        public AngularVelocity(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.AngularVelocity);
        }

        internal AngularVelocity(double valueInBaseUnits)
            : base(valueInBaseUnits, AngularVelocityUnit.BaseUnit) {}

        public int CompareTo(AngularVelocity other) {
            return base.CompareTo(other);
        }

        public bool Equals(AngularVelocity other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(AngularVelocity)) {
                return false;
            }
            return Equals((AngularVelocity)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public static AngularVelocity operator +(AngularVelocity revolutions1, AngularVelocity revolutions2) {
            Guard.NotNull(revolutions1, "revolutions1");
            Guard.NotNull(revolutions2, "revolutions2");
            return new AngularVelocity(revolutions1.ValueInBaseUnits + revolutions2.ValueInBaseUnits) {Units = revolutions1.Units};
        }

        public static AngularVelocity operator /(AngularVelocity angularVelocity, double scaler) {
            Guard.NotNull(angularVelocity, "angularVelocity");
            return new AngularVelocity(angularVelocity.ValueInBaseUnits / scaler) {Units = angularVelocity.Units};
        }

        public static double operator /(AngularVelocity numerator, AngularVelocity denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(AngularVelocity left, AngularVelocity right) {
            return Equals(left, right);
        }

        public static bool operator >(AngularVelocity left, AngularVelocity right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(AngularVelocity left, AngularVelocity right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(AngularVelocity left, AngularVelocity right) {
            return !Equals(left, right);
        }

        public static bool operator <(AngularVelocity left, AngularVelocity right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(AngularVelocity left, AngularVelocity right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static AngularVelocity operator *(AngularVelocity angularVelocity, double scaler) {
            Guard.NotNull(angularVelocity, "angularVelocity");
            return new AngularVelocity(angularVelocity.ValueInBaseUnits * scaler) {Units = angularVelocity.Units};
        }

        public static AngularVelocity operator *(double scaler, AngularVelocity angularVelocity) {
            Guard.NotNull(angularVelocity, "angularVelocity");
            return new AngularVelocity(angularVelocity.ValueInBaseUnits * scaler) {Units = angularVelocity.Units};
        }

        public static Power operator *(AngularVelocity angularVelocity, Torque torque) {
            Guard.NotNull(torque, "torque");
            Guard.NotNull(angularVelocity, "angularVelocity");
            double powerValue = angularVelocity.In(AngularVelocityUnit.RevolutionsPerSecond) * torque.In(TorqueUnit.NewtonMeters);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static AngularVelocity operator -(AngularVelocity revolutions1, AngularVelocity revolutions2) {
            Guard.NotNull(revolutions1, "revolutions1");
            Guard.NotNull(revolutions2, "revolutions2");
            return new AngularVelocity(revolutions1.ValueInBaseUnits - revolutions2.ValueInBaseUnits) {Units = revolutions1.Units};
        }
    }
}