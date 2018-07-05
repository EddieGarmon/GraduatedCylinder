using System;

namespace GraduatedCylinder
{
    public class LuminousIntensity : Dimension,
                                     IDimension<LuminousIntensityUnit>,
                                     IEquatable<LuminousIntensity>,
                                     IComparable<LuminousIntensity>
    {
        public LuminousIntensity(double value, LuminousIntensityUnit unitOfMeasure)
            : base(value, unitOfMeasure) { }

        public LuminousIntensity(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.LuminousIntensity);
        }

        internal LuminousIntensity(double valueInBaseUnits)
            : base(valueInBaseUnits, LuminousIntensityUnit.BaseUnit) { }

        public int CompareTo(LuminousIntensity other) {
            return base.CompareTo(other);
        }

        public bool Equals(LuminousIntensity other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return (obj is LuminousIntensity intensity) && Equals(intensity);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(LuminousIntensityUnit units) {
            return base.In(units);
        }

        public string ToString(LuminousIntensityUnit units) {
            return base.ToString(units);
        }

        public string ToString(LuminousIntensityUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static LuminousIntensity Parse(string input) {
            return (LuminousIntensity)Factory.Parse(input, DimensionType.LuminousIntensity);
        }
    }
}