using System;

namespace GraduatedCylinder
{
    public class ElectricCurrent : Dimension,
                                   IDimension<ElectricCurrentUnit>,
                                   IEquatable<ElectricCurrent>,
                                   IComparable<ElectricCurrent>
    {
        public ElectricCurrent(double value, ElectricCurrentUnit units)
            : base(value, units) { }

        public ElectricCurrent(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.ElectricCurrent);
        }

        internal ElectricCurrent(double valueInBaseUnits)
            : base(valueInBaseUnits, ElectricCurrentUnit.BaseUnit) { }

        public int CompareTo(ElectricCurrent other) {
            return base.CompareTo(other);
        }

        public bool Equals(ElectricCurrent other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return (obj is ElectricCurrent current) && Equals(current);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(ElectricCurrentUnit units) {
            return base.In(units);
        }

        public string ToString(ElectricCurrentUnit units) {
            return base.ToString(units);
        }

        public string ToString(ElectricCurrentUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static ElectricCurrent Zero => new ElectricCurrent(0);

        public static ElectricCurrent Parse(string input) {
            return (ElectricCurrent)Factory.Parse(input, DimensionType.ElectricCurrent);
        }

        public static ElectricCurrent operator +(ElectricCurrent current1, ElectricCurrent current2) {
            Guard.NotNull(current1, nameof(current1));
            Guard.NotNull(current2, nameof(current2));
            return new ElectricCurrent(current1.ValueInBaseUnits + current2.ValueInBaseUnits) {
                Units = current1.Units
            };
        }

        public static ElectricCurrent operator /(ElectricCurrent electricCurrent, double scaler) {
            Guard.NotNull(electricCurrent, nameof(electricCurrent));
            return new ElectricCurrent(electricCurrent.ValueInBaseUnits / scaler) {
                Units = electricCurrent.Units
            };
        }

        public static double operator /(ElectricCurrent numerator, ElectricCurrent denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(ElectricCurrent left, ElectricCurrent right) {
            return Equals(left, right);
        }

        public static bool operator >(ElectricCurrent left, ElectricCurrent right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(ElectricCurrent left, ElectricCurrent right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(ElectricCurrent left, ElectricCurrent right) {
            return !Equals(left, right);
        }

        public static bool operator <(ElectricCurrent left, ElectricCurrent right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(ElectricCurrent left, ElectricCurrent right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static ElectricCurrent operator *(ElectricCurrent electricCurrent, double scaler) {
            Guard.NotNull(electricCurrent, nameof(electricCurrent));
            return new ElectricCurrent(electricCurrent.ValueInBaseUnits * scaler) {
                Units = electricCurrent.Units
            };
        }

        public static ElectricCurrent operator *(double scaler, ElectricCurrent electricCurrent) {
            Guard.NotNull(electricCurrent, nameof(electricCurrent));
            return new ElectricCurrent(electricCurrent.ValueInBaseUnits * scaler) {
                Units = electricCurrent.Units
            };
        }

        public static Power operator *(ElectricCurrent electricCurrent, ElectricPotential voltage) {
            Guard.NotNull(electricCurrent, nameof(electricCurrent));
            Guard.NotNull(voltage, nameof(voltage));
            double powerValue = electricCurrent.In(ElectricCurrentUnit.Ampere) * voltage.In(ElectricPotentialUnit.Volt);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static ElectricPotential operator *(ElectricCurrent electricCurrent, ElectricResistance resistance) {
            Guard.NotNull(resistance, nameof(resistance));
            Guard.NotNull(electricCurrent, nameof(electricCurrent));
            double voltageValue = electricCurrent.In(ElectricCurrentUnit.Ampere)
                                  * resistance.In(ElectricResistanceUnit.Ohm);
            return new ElectricPotential(voltageValue, ElectricPotentialUnit.Volt);
        }

        public static ElectricCurrent operator -(ElectricCurrent current1, ElectricCurrent current2) {
            Guard.NotNull(current1, nameof(current1));
            Guard.NotNull(current2, nameof(current2));
            return new ElectricCurrent(current1.ValueInBaseUnits - current2.ValueInBaseUnits) {
                Units = current1.Units
            };
        }

        public static ElectricCurrent operator -(ElectricCurrent source) {
            Guard.NotNull(source, nameof(source));
            return new ElectricCurrent(-source.ValueInBaseUnits) {
                Units = source.Units
            };
        }
    }
}