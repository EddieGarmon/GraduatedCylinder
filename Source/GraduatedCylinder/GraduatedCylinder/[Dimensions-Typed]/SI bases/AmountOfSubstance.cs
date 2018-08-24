using System;

namespace GraduatedCylinder
{
    public class AmountOfSubstance : Dimension,
                                     IDimension<AmountOfSubstanceUnit>,
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
            return (obj is AmountOfSubstance amountOfSubstance) && Equals(amountOfSubstance);
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

        public static AmountOfSubstance Zero => new AmountOfSubstance(0);

        public static AmountOfSubstance Parse(string input) {
            return (AmountOfSubstance)Factory.Parse(input, DimensionType.AmountOfSubstance);
        }

        public static AmountOfSubstance operator -(AmountOfSubstance source) {
            Guard.NotNull(source, nameof(source));
            return new AmountOfSubstance(-source.ValueInBaseUnits) {
                Units = source.Units
            };
        }
    }
}