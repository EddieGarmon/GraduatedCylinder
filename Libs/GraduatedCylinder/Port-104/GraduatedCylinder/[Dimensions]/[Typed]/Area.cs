using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This dimension represents a two dimensional area.
    /// </summary>
    public class Area : Dimension, IEquatable<Area>, IComparable<Area>
    {
        public Area(double value, AreaUnit units)
            : base(value, units) {}

        public Area(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Area);
        }

        internal Area(double valueInBaseUnits)
            : base(valueInBaseUnits, AreaUnit.BaseUnit) {}

        public int CompareTo(Area other) {
            return base.CompareTo(other);
        }

        public bool Equals(Area other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Area)) {
                return false;
            }
            return Equals((Area)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public Length SquareRoot() {
            double square = In(AreaUnit.SquareMeters);
            double root = Math.Sqrt(square);
            return new Length(root, LengthUnit.Meters);
        }

        public static Area operator +(Area area1, Area area2) {
            Guard.NotNull(area1, "area1");
            Guard.NotNull(area2, "area2");
            return new Area(area1.ValueInBaseUnits + area2.ValueInBaseUnits) {Units = area1.Units};
        }

        public static Area operator /(Area area, double scaler) {
            Guard.NotNull(area, "area");
            return new Area(area.ValueInBaseUnits / scaler) {Units = area.Units};
        }

        public static Length operator /(Area area, Length length) {
            Guard.NotNull(area, "area");
            Guard.NotNull(length, "length");
            double length2 = area.In(AreaUnit.SquareMeters) / length.In(LengthUnit.Meters);
            return new Length(length2, LengthUnit.Meters) {Units = length.Units};
        }

        public static double operator /(Area numerator, Area denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Area left, Area right) {
            return Equals(left, right);
        }

        public static bool operator >(Area left, Area right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Area left, Area right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Area left, Area right) {
            return !Equals(left, right);
        }

        public static bool operator <(Area left, Area right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Area left, Area right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Area operator *(Area area, double scaler) {
            Guard.NotNull(area, "area");
            return new Area(area.ValueInBaseUnits * scaler) {Units = area.Units};
        }

        public static Area operator *(double scaler, Area area) {
            Guard.NotNull(area, "area");
            return new Area(area.ValueInBaseUnits * scaler) {Units = area.Units};
        }

        public static Force operator *(Area area, Pressure pressure) {
            Guard.NotNull(area, "area");
            Guard.NotNull(pressure, "pressure");
            double forceValue = area.In(AreaUnit.SquareMeters) * pressure.In(PressureUnit.NewtonsPerSquareMeter);
            return new Force(forceValue, ForceUnit.Newtons);
        }

        public static Volume operator *(Area area, Length length) {
            Guard.NotNull(length, "length");
            Guard.NotNull(area, "area");
            double volumeValue = area.In(AreaUnit.SquareMeters) * length.In(LengthUnit.Meters);
            return new Volume(volumeValue, VolumeUnit.CubicMeters);
        }

        public static Area operator -(Area area1, Area area2) {
            Guard.NotNull(area1, "area1");
            Guard.NotNull(area2, "area2");
            return new Area(area1.ValueInBaseUnits - area2.ValueInBaseUnits) {Units = area1.Units};
        }
    }
}