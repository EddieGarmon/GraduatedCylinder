using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Represents the Pressure dimension.
    /// </summary>
    public class Pressure : Dimension, IEquatable<Pressure>, IComparable<Pressure>
    {
        public Pressure(double value, PressureUnit units)
            : base(value, units) { }

        public Pressure(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Pressure);
        }

        internal Pressure(double valueInBaseUnits)
            : base(valueInBaseUnits, PressureUnit.BaseUnit) { }

        public int CompareTo(Pressure other) {
            return base.CompareTo(other);
        }

        public bool Equals(Pressure other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Pressure)) {
                return false;
            }
            return Equals((Pressure)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public string ToString(PressureUnit units) {
            return base.ToString(units);
        }

        public string ToString(PressureUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Pressure operator +(Pressure pressure1, Pressure pressure2) {
            Guard.NotNull(pressure1, "pressure1");
            Guard.NotNull(pressure2, "pressure2");
            return new Pressure(pressure1.ValueInBaseUnits + pressure2.ValueInBaseUnits) { Units = pressure1.Units };
        }

        public static Pressure operator /(Pressure pressure, double scaler) {
            Guard.NotNull(pressure, "pressure");
            return new Pressure(pressure.ValueInBaseUnits / scaler) { Units = pressure.Units };
        }

        public static double operator /(Pressure numerator, Pressure denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Pressure left, Pressure right) {
            return Equals(left, right);
        }

        public static bool operator >(Pressure left, Pressure right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Pressure left, Pressure right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Pressure left, Pressure right) {
            return !Equals(left, right);
        }

        public static bool operator <(Pressure left, Pressure right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Pressure left, Pressure right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Pressure operator *(Pressure pressure, double scaler) {
            Guard.NotNull(pressure, "pressure");
            return new Pressure(pressure.ValueInBaseUnits * scaler) { Units = pressure.Units };
        }

        public static Pressure operator *(double scaler, Pressure pressure) {
            Guard.NotNull(pressure, "pressure");
            return new Pressure(pressure.ValueInBaseUnits * scaler) { Units = pressure.Units };
        }

        public static Force operator *(Pressure pressure, Area area) {
            Guard.NotNull(area, "area");
            Guard.NotNull(pressure, "pressure");
            double forceValue = pressure.In(PressureUnit.NewtonsPerSquareMeter) * area.In(AreaUnit.SquareMeters);
            return new Force(forceValue, ForceUnit.Newtons);
        }

        public static Pressure operator -(Pressure pressure1, Pressure pressure2) {
            Guard.NotNull(pressure1, "pressure1");
            Guard.NotNull(pressure2, "pressure2");
            return new Pressure(pressure1.ValueInBaseUnits - pressure2.ValueInBaseUnits) { Units = pressure1.Units };
        }
    }
}