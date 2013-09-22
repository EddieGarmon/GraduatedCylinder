using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Represents the Torque Dimension.
    /// </summary>
    public class Torque : Dimension, IEquatable<Torque>, IComparable<Torque>
    {
        public Torque(double value, TorqueUnit units)
            : base(value, units) {}

        public Torque(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Torque);
        }

        internal Torque(double valueInBaseUnits)
            : base(valueInBaseUnits, TorqueUnit.BaseUnit) {}

        public int CompareTo(Torque other) {
            return base.CompareTo(other);
        }

        public bool Equals(Torque other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Torque)) {
                return false;
            }
            return Equals((Torque)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public static Torque operator +(Torque torque1, Torque torque2) {
            Guard.NotNull(torque1, "torque1");
            Guard.NotNull(torque2, "torque2");
            return new Torque(torque1.ValueInBaseUnits + torque2.ValueInBaseUnits) {Units = torque1.Units};
        }

        public static Torque operator /(Torque torque, double scaler) {
            Guard.NotNull(torque, "torque");
            return new Torque(torque.ValueInBaseUnits / scaler) {Units = torque.Units};
        }

        public static Force operator /(Torque torque, Length length) {
            Guard.NotNull(torque, "torque");
            Guard.NotNull(length, "length");
            double forceValue = torque.In(TorqueUnit.NewtonMeters) / length.In(LengthUnit.Meters);
            return new Force(forceValue, ForceUnit.Newtons);
        }

        public static Length operator /(Torque torque, Force force) {
            Guard.NotNull(torque, "torque");
            Guard.NotNull(force, "force");
            double lengthValue = torque.In(TorqueUnit.NewtonMeters) / force.In(ForceUnit.Newtons);
            return new Length(lengthValue, LengthUnit.Meters);
        }

        public static double operator /(Torque numerator, Torque denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Torque left, Torque right) {
            return Equals(left, right);
        }

        public static bool operator >(Torque left, Torque right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Torque left, Torque right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Torque left, Torque right) {
            return !Equals(left, right);
        }

        public static bool operator <(Torque left, Torque right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Torque left, Torque right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Torque operator *(Torque torque, double scaler) {
            Guard.NotNull(torque, "torque");
            return new Torque(torque.ValueInBaseUnits * scaler) {Units = torque.Units};
        }

        public static Torque operator *(double scaler, Torque torque) {
            Guard.NotNull(torque, "torque");
            return new Torque(torque.ValueInBaseUnits * scaler) {Units = torque.Units};
        }

        public static Power operator *(Torque torque, AngularVelocity angularVelocity) {
            Guard.NotNull(torque, "torque");
            Guard.NotNull(angularVelocity, "angularVelocity");
            double powerValue = torque.In(TorqueUnit.NewtonMeters) * angularVelocity.In(AngularVelocityUnit.RevolutionsPerSecond);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static Torque operator -(Torque torque1, Torque torque2) {
            Guard.NotNull(torque1, "torque1");
            Guard.NotNull(torque2, "torque2");
            return new Torque(torque1.ValueInBaseUnits - torque2.ValueInBaseUnits) {Units = torque1.Units};
        }
    }
}