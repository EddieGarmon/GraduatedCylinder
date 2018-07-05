using System;

namespace GraduatedCylinder
{
    public class Pressure : Dimension,
                            IDimension<PressureUnit>,
                            IEquatable<Pressure>,
                            IComparable<Pressure>
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
            return (obj is Pressure pressure) && Equals(pressure);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(PressureUnit units) {
            return base.In(units);
        }

        public string ToString(PressureUnit units) {
            return base.ToString(units);
        }

        public string ToString(PressureUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Pressure Parse(string input) {
            return (Pressure)Factory.Parse(input, DimensionType.Pressure);
        }

        public static Pressure operator +(Pressure pressure1, Pressure pressure2) {
            Guard.NotNull(pressure1, nameof(pressure1));
            Guard.NotNull(pressure2, nameof(pressure2));
            return new Pressure(pressure1.ValueInBaseUnits + pressure2.ValueInBaseUnits) {
                Units = pressure1.Units
            };
        }

        public static Pressure operator /(Pressure pressure, double scaler) {
            Guard.NotNull(pressure, nameof(pressure));
            return new Pressure(pressure.ValueInBaseUnits / scaler) {
                Units = pressure.Units
            };
        }

        public static double operator /(Pressure numerator, Pressure denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
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
            Guard.NotNull(pressure, nameof(pressure));
            return new Pressure(pressure.ValueInBaseUnits * scaler) {
                Units = pressure.Units
            };
        }

        public static Pressure operator *(double scaler, Pressure pressure) {
            Guard.NotNull(pressure, nameof(pressure));
            return new Pressure(pressure.ValueInBaseUnits * scaler) {
                Units = pressure.Units
            };
        }

        public static Force operator *(Pressure pressure, Area area) {
            Guard.NotNull(area, nameof(area));
            Guard.NotNull(pressure, nameof(pressure));
            double forceValue = pressure.In(PressureUnit.NewtonsPerSquareMeter) * area.In(AreaUnit.MeterSquared);
            return new Force(forceValue, ForceUnit.Newtons);
        }

        public static Pressure operator -(Pressure pressure1, Pressure pressure2) {
            Guard.NotNull(pressure1, nameof(pressure1));
            Guard.NotNull(pressure2, nameof(pressure2));
            return new Pressure(pressure1.ValueInBaseUnits - pressure2.ValueInBaseUnits) {
                Units = pressure1.Units
            };
        }
    }
}