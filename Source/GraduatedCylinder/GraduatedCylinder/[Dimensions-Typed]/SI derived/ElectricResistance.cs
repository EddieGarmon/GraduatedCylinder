using System;

namespace GraduatedCylinder
{
    public class ElectricResistance : Dimension,
                                      IDimension<ElectricResistanceUnit>,
                                      IEquatable<ElectricResistance>,
                                      IComparable<ElectricResistance>
    {
        public ElectricResistance(double value, ElectricResistanceUnit units)
            : base(value, units) { }

        public ElectricResistance(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.ElectricResistance);
        }

        internal ElectricResistance(double valueInBaseUnits)
            : base(valueInBaseUnits, ElectricResistanceUnit.BaseUnit) { }

        public int CompareTo(ElectricResistance other) {
            return base.CompareTo(other);
        }

        public bool Equals(ElectricResistance other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return (obj is ElectricResistance electricResistance) && Equals(electricResistance);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(ElectricResistanceUnit units) {
            return base.In(units);
        }

        public string ToString(ElectricResistanceUnit units) {
            return base.ToString(units);
        }

        public string ToString(ElectricResistanceUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static ElectricResistance Zero => new ElectricResistance(0);

        public static ElectricResistance Parse(string input) {
            return (ElectricResistance)Factory.Parse(input, DimensionType.ElectricResistance);
        }

        public static ElectricResistance operator +(ElectricResistance resistance1, ElectricResistance resistance2) {
            Guard.NotNull(resistance1, nameof(resistance1));
            Guard.NotNull(resistance2, nameof(resistance2));
            return new ElectricResistance(resistance1.ValueInBaseUnits + resistance2.ValueInBaseUnits) {
                Units = resistance1.Units
            };
        }

        public static ElectricResistance operator /(ElectricResistance electricResistance, double scaler) {
            Guard.NotNull(electricResistance, nameof(electricResistance));
            return new ElectricResistance(electricResistance.ValueInBaseUnits / scaler) {
                Units = electricResistance.Units
            };
        }

        public static double operator /(ElectricResistance numerator, ElectricResistance denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(ElectricResistance left, ElectricResistance right) {
            return Equals(left, right);
        }

        public static bool operator >(ElectricResistance left, ElectricResistance right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(ElectricResistance left, ElectricResistance right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(ElectricResistance left, ElectricResistance right) {
            return !Equals(left, right);
        }

        public static bool operator <(ElectricResistance left, ElectricResistance right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(ElectricResistance left, ElectricResistance right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static ElectricResistance operator *(ElectricResistance electricResistance, double scaler) {
            Guard.NotNull(electricResistance, nameof(electricResistance));
            return new ElectricResistance(electricResistance.ValueInBaseUnits * scaler) {
                Units = electricResistance.Units
            };
        }

        public static ElectricResistance operator *(double scaler, ElectricResistance electricResistance) {
            Guard.NotNull(electricResistance, nameof(electricResistance));
            return new ElectricResistance(electricResistance.ValueInBaseUnits * scaler) {
                Units = electricResistance.Units
            };
        }

        public static ElectricPotential operator *(ElectricResistance electricResistance, ElectricCurrent current) {
            Guard.NotNull(electricResistance, nameof(electricResistance));
            Guard.NotNull(current, nameof(current));
            double voltageValue = electricResistance.In(ElectricResistanceUnit.Ohm)
                                  * current.In(ElectricCurrentUnit.Ampere);
            return new ElectricPotential(voltageValue, ElectricPotentialUnit.Volt);
        }

        public static ElectricResistance operator -(ElectricResistance resistance1, ElectricResistance resistance2) {
            Guard.NotNull(resistance1, nameof(resistance1));
            Guard.NotNull(resistance2, nameof(resistance2));
            return new ElectricResistance(resistance1.ValueInBaseUnits - resistance2.ValueInBaseUnits) {
                Units = resistance1.Units
            };
        }

        public static ElectricResistance operator -(ElectricResistance source) {
            Guard.NotNull(source, nameof(source));
            return new ElectricResistance(-source.ValueInBaseUnits) {
                Units = source.Units
            };
        }
    }
}