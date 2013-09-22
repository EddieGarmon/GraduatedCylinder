using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This dimension represents Density
    /// </summary>
    public class Density : Dimension, IEquatable<Density>, IComparable<Density>
    {
        public Density(double value, DensityUnit units)
            : base(value, units) {}

        public Density(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Density);
        }

        internal Density(double valueInBaseUnits)
            : base(valueInBaseUnits, DensityUnit.BaseUnit) {}

        public int CompareTo(Density other) {
            return base.CompareTo(other);
        }

        public bool Equals(Density other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Density)) {
                return false;
            }
            return Equals((Density)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public static Density operator +(Density density1, Density density2) {
            Guard.NotNull(density1, "density1");
            Guard.NotNull(density2, "density2");
            return new Density(density1.ValueInBaseUnits + density2.ValueInBaseUnits) {Units = density1.Units};
        }

        public static Density operator /(Density density, double scaler) {
            Guard.NotNull(density, "density");
            return new Density(density.ValueInBaseUnits / scaler) {Units = density.Units};
        }

        public static double operator /(Density numerator, Density denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Density left, Density right) {
            return Equals(left, right);
        }

        public static bool operator >(Density left, Density right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Density left, Density right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Density left, Density right) {
            return !Equals(left, right);
        }

        public static bool operator <(Density left, Density right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Density left, Density right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Density operator *(Density density, double scaler) {
            Guard.NotNull(density, "density");
            return new Density(density.ValueInBaseUnits * scaler) {Units = density.Units};
        }

        public static Density operator *(double scaler, Density density) {
            Guard.NotNull(density, "density");
            return new Density(density.ValueInBaseUnits * scaler) {Units = density.Units};
        }

        public static Mass operator *(Density density, Volume volume) {
            Guard.NotNull(density, "density");
            Guard.NotNull(volume, "volume");
            double massValue = density.In(DensityUnit.KilogramsPerLiter) * volume.In(VolumeUnit.Liters);
            return new Mass(massValue, MassUnit.Kilograms);
        }

        public static Density operator -(Density density1, Density density2) {
            Guard.NotNull(density1, "density1");
            Guard.NotNull(density2, "density2");
            return new Density(density1.ValueInBaseUnits - density2.ValueInBaseUnits) {Units = density1.Units};
        }
    }
}