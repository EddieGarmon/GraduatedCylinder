using System;

namespace GraduatedCylinder
{
    public class AmountOfSubstance : Dimension,
                                     IEquatable<AmountOfSubstance>,
                                     IComparable<AmountOfSubstance>
    {
        public AmountOfSubstance(double value, AmountOfSubstanceUnit unitOfMeasure)
            : base(value, unitOfMeasure) { }

        public AmountOfSubstance(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.AmountOfSubstance);
        }

        internal AmountOfSubstance(double valueInBaseUnits)
            : base(valueInBaseUnits, AmountOfSubstanceUnit.BaseUnit) { }

        public int CompareTo(AmountOfSubstance other) {
            return base.CompareTo(other);
        }

        public bool Equals(AmountOfSubstance other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(AmountOfSubstance)) {
                return false;
            }
            return Equals((AmountOfSubstance)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(AmountOfSubstanceUnit units) {
            return base.In(units);
        }

        public string ToString(AmountOfSubstanceUnit units) {
            return base.ToString(units);
        }

        public string ToString(AmountOfSubstanceUnit units, int precision) {
            return base.ToString(units, precision);
        }

        //todo: what operators?
    }
}