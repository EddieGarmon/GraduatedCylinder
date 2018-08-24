using System;

namespace GraduatedCylinder
{
    public class Area : Dimension,
                        IDimension<AreaUnit>,
                        IEquatable<Area>,
                        IComparable<Area>
    {
        public Area(double value, AreaUnit units)
            : base(value, units) { }

        public Area(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Area);
        }

        internal Area(double valueInBaseUnits)
            : base(valueInBaseUnits, AreaUnit.BaseUnit) { }

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
            return (obj is Area area) && Equals(area);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(AreaUnit units) {
            return base.In(units);
        }

        public Length SquareRoot() {
            double square = In(AreaUnit.MeterSquared);
            double root = Math.Sqrt(square);
            return new Length(root, LengthUnit.Meter);
        }

        public string ToString(AreaUnit units) {
            return base.ToString(units);
        }

        public string ToString(AreaUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Area Zero => new Area(0);

        public static Area Parse(string input) {
            return (Area)Factory.Parse(input, DimensionType.Area);
        }

        public static Area operator +(Area area1, Area area2) {
            Guard.NotNull(area1, nameof(area1));
            Guard.NotNull(area2, nameof(area2));
            return new Area(area1.ValueInBaseUnits + area2.ValueInBaseUnits) {
                Units = area1.Units
            };
        }

        public static Area operator /(Area area, double scaler) {
            Guard.NotNull(area, nameof(area));
            return new Area(area.ValueInBaseUnits / scaler) {
                Units = area.Units
            };
        }

        public static Length operator /(Area area, Length length) {
            Guard.NotNull(area, nameof(area));
            Guard.NotNull(length, nameof(length));
            double length2 = area.In(AreaUnit.MeterSquared) / length.In(LengthUnit.Meter);
            return new Length(length2, LengthUnit.Meter) {
                Units = length.Units
            };
        }

        public static double operator /(Area numerator, Area denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
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
            Guard.NotNull(area, nameof(area));
            return new Area(area.ValueInBaseUnits * scaler) {
                Units = area.Units
            };
        }

        public static Area operator *(double scaler, Area area) {
            Guard.NotNull(area, nameof(area));
            return new Area(area.ValueInBaseUnits * scaler) {
                Units = area.Units
            };
        }

        public static Force operator *(Area area, Pressure pressure) {
            Guard.NotNull(area, nameof(area));
            Guard.NotNull(pressure, nameof(pressure));
            double forceValue = area.In(AreaUnit.MeterSquared) * pressure.In(PressureUnit.NewtonsPerSquareMeter);
            return new Force(forceValue, ForceUnit.Newtons);
        }

        public static Volume operator *(Area area, Length length) {
            Guard.NotNull(length, nameof(length));
            Guard.NotNull(area, nameof(area));
            double volumeValue = area.In(AreaUnit.MeterSquared) * length.In(LengthUnit.Meter);
            return new Volume(volumeValue, VolumeUnit.CubicMeters);
        }

        public static Area operator -(Area area1, Area area2) {
            Guard.NotNull(area1, nameof(area1));
            Guard.NotNull(area2, nameof(area2));
            return new Area(area1.ValueInBaseUnits - area2.ValueInBaseUnits) {
                Units = area1.Units
            };
        }

        public static Area operator -(Area source) {
            Guard.NotNull(source, nameof(source));
            return new Area(-source.ValueInBaseUnits) {
                Units = source.Units
            };
        }
    }
}