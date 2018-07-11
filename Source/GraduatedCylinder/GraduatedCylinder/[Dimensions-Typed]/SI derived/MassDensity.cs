using System;

namespace GraduatedCylinder
{
    public class MassDensity : Dimension,
                               IDimension<MassDensityUnit>,
                               IEquatable<MassDensity>,
                               IComparable<MassDensity>
    {
        public MassDensity(double value, MassDensityUnit units)
            : base(value, units) { }

        public MassDensity(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.MassDensity);
        }

        internal MassDensity(double valueInBaseUnits)
            : base(valueInBaseUnits, MassDensityUnit.BaseUnit) { }

        public int CompareTo(MassDensity other) {
            return base.CompareTo(other);
        }

        public bool Equals(MassDensity other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return (obj is MassDensity density) && Equals(density);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(MassDensityUnit units) {
            return base.In(units);
        }

        public string ToString(MassDensityUnit units) {
            return base.ToString(units);
        }

        public string ToString(MassDensityUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static MassDensity Zero => new MassDensity(0);

        public static MassDensity Parse(string input) {
            return (MassDensity)Factory.Parse(input, DimensionType.MassDensity);
        }

        public static MassDensity operator +(MassDensity density1, MassDensity density2) {
            Guard.NotNull(density1, nameof(density1));
            Guard.NotNull(density2, nameof(density2));
            return new MassDensity(density1.ValueInBaseUnits + density2.ValueInBaseUnits) {
                Units = density1.Units
            };
        }

        public static MassDensity operator /(MassDensity massDensity, double scaler) {
            Guard.NotNull(massDensity, nameof(massDensity));
            return new MassDensity(massDensity.ValueInBaseUnits / scaler) {
                Units = massDensity.Units
            };
        }

        public static double operator /(MassDensity numerator, MassDensity denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(MassDensity left, MassDensity right) {
            return Equals(left, right);
        }

        public static bool operator >(MassDensity left, MassDensity right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(MassDensity left, MassDensity right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(MassDensity left, MassDensity right) {
            return !Equals(left, right);
        }

        public static bool operator <(MassDensity left, MassDensity right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(MassDensity left, MassDensity right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static MassDensity operator *(MassDensity massDensity, double scaler) {
            Guard.NotNull(massDensity, nameof(massDensity));
            return new MassDensity(massDensity.ValueInBaseUnits * scaler) {
                Units = massDensity.Units
            };
        }

        public static MassDensity operator *(double scaler, MassDensity massDensity) {
            Guard.NotNull(massDensity, nameof(massDensity));
            return new MassDensity(massDensity.ValueInBaseUnits * scaler) {
                Units = massDensity.Units
            };
        }

        public static Mass operator *(MassDensity massDensity, Volume volume) {
            Guard.NotNull(massDensity, nameof(massDensity));
            Guard.NotNull(volume, nameof(volume));
            double massValue = massDensity.In(MassDensityUnit.KilogramsPerLiter) * volume.In(VolumeUnit.Liters);
            return new Mass(massValue, MassUnit.Kilogram);
        }

        public static MassDensity operator -(MassDensity density1, MassDensity density2) {
            Guard.NotNull(density1, nameof(density1));
            Guard.NotNull(density2, nameof(density2));
            return new MassDensity(density1.ValueInBaseUnits - density2.ValueInBaseUnits) {
                Units = density1.Units
            };
        }
    }
}