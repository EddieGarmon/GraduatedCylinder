using System;

namespace GraduatedCylinder
{
    public class Torque : Dimension,
                          IDimension<TorqueUnit>,
                          IEquatable<Torque>,
                          IComparable<Torque>
    {
        public Torque(double value, TorqueUnit units)
            : base(value, units) { }

        public Torque(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Torque);
        }

        internal Torque(double valueInBaseUnits)
            : base(valueInBaseUnits, TorqueUnit.BaseUnit) { }

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
            return (obj is Torque torque) && Equals(torque);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(TorqueUnit units) {
            return base.In(units);
        }

        public string ToString(TorqueUnit units) {
            return base.ToString(units);
        }

        public string ToString(TorqueUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Torque Zero => new Torque(0);

        public static Torque Parse(string input) {
            return (Torque)Factory.Parse(input, DimensionType.Torque);
        }

        public static Torque operator +(Torque torque1, Torque torque2) {
            Guard.NotNull(torque1, nameof(torque1));
            Guard.NotNull(torque2, nameof(torque2));
            return new Torque(torque1.ValueInBaseUnits + torque2.ValueInBaseUnits) {
                Units = torque1.Units
            };
        }

        public static Torque operator /(Torque torque, double scaler) {
            Guard.NotNull(torque, nameof(torque));
            return new Torque(torque.ValueInBaseUnits / scaler) {
                Units = torque.Units
            };
        }

        public static Force operator /(Torque torque, Length length) {
            Guard.NotNull(torque, nameof(torque));
            Guard.NotNull(length, nameof(length));
            double forceValue = torque.In(TorqueUnit.NewtonMeters) / length.In(LengthUnit.Meter);
            return new Force(forceValue, ForceUnit.Newtons);
        }

        public static Length operator /(Torque torque, Force force) {
            Guard.NotNull(torque, nameof(torque));
            Guard.NotNull(force, nameof(force));
            double lengthValue = torque.In(TorqueUnit.NewtonMeters) / force.In(ForceUnit.Newtons);
            return new Length(lengthValue, LengthUnit.Meter);
        }

        public static double operator /(Torque numerator, Torque denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
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
            Guard.NotNull(torque, nameof(torque));
            return new Torque(torque.ValueInBaseUnits * scaler) {
                Units = torque.Units
            };
        }

        public static Torque operator *(double scaler, Torque torque) {
            Guard.NotNull(torque, nameof(torque));
            return new Torque(torque.ValueInBaseUnits * scaler) {
                Units = torque.Units
            };
        }

        public static Power operator *(Torque torque, Frequency angularVelocity) {
            Guard.NotNull(torque, nameof(torque));
            Guard.NotNull(angularVelocity, nameof(angularVelocity));
            double powerValue = torque.In(TorqueUnit.NewtonMeters)
                                * angularVelocity.In(FrequencyUnit.RevolutionPerSecond);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static Torque operator -(Torque torque1, Torque torque2) {
            Guard.NotNull(torque1, nameof(torque1));
            Guard.NotNull(torque2, nameof(torque2));
            return new Torque(torque1.ValueInBaseUnits - torque2.ValueInBaseUnits) {
                Units = torque1.Units
            };
        }

        public static Torque operator -(Torque source) {
            Guard.NotNull(source, nameof(source));
            return new Torque(-source.ValueInBaseUnits) {
                Units = source.Units
            };
        }
    }
}