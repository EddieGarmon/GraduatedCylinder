using System;
using System.Globalization;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This is the base class for all dimensions.
    /// </summary>
    public abstract partial class Dimension : ISupportUnitOfMeasure
    {
        private UnitOfMeasure _currentUnits;

        protected Dimension(double value, UnitOfMeasure unitOfMeasure) {
            Guard.NotNull(unitOfMeasure, nameof(unitOfMeasure));
            DimensionType = unitOfMeasure.DimensionType;
            Value = value;
            _currentUnits = unitOfMeasure;
            ValueInBaseUnits = _currentUnits.UnitConverter.ToBaseUnit(value);
        }

        public DimensionType DimensionType { get; }

        /// <summary>
        ///     Gets or sets the units that the current value is represented in.
        /// </summary>
        /// <value>The units.</value>
        public UnitOfMeasure Units {
            get { return _currentUnits; }
            set {
                if (_currentUnits == value) {
                    return;
                }
                value.DimensionType.ShouldBe(DimensionType);
                _currentUnits = value;
                Value = _currentUnits.UnitConverter.FromBaseUnit(ValueInBaseUnits);
            }
        }

        /// <summary>
        ///     Gets the value in the current units.
        /// </summary>
        /// <value>The value.</value>
        public double Value { get; private set; }

        public double ValueInBaseUnits { get; }

        public int CompareTo(ISupportUnitOfMeasure other) {
            if (other == null) {
                return 1;
            }
            if (ReferenceEquals(this, other)) {
                return 0;
            }
            int dimensionTypeComparison = DimensionType.CompareTo(other.DimensionType);
            if (dimensionTypeComparison != 0) {
                return dimensionTypeComparison;
            }
            double otherValueInBase = other.ValueInBaseUnits;
            return AreClose(ValueInBaseUnits, otherValueInBase) ? 0 : ValueInBaseUnits.CompareTo(otherValueInBase);
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return CompareTo(obj as ISupportUnitOfMeasure) == 0;
        }

        public bool Equals(ISupportUnitOfMeasure other) {
            return CompareTo(other) == 0;
        }

        public override int GetHashCode() {
            return ((int)DimensionType << 25) ^ ValueInBaseUnits.GetHashCode();
        }

        public override string ToString() {
            return string.Format("{0} {1}", Value, _currentUnits.Abbreviation);
        }

        public string ToString(int precision) {
            string format = "{0:N[pre]} {1}".Replace("[pre]", precision.ToString(CultureInfo.InvariantCulture));
            return string.Format(format, Value, _currentUnits.Abbreviation);
        }

        /// <summary>
        ///     Gets the current value in the desired units. The object's value is not changed.
        /// </summary>
        /// <param name="desiredUnits">The desired units.</param>
        /// <returns></returns>
        protected double In(UnitOfMeasure desiredUnits) {
            desiredUnits.DimensionType.ShouldBe(DimensionType);
            return (_currentUnits == desiredUnits)
                       ? Value
                       : desiredUnits.UnitConverter.FromBaseUnit(ValueInBaseUnits);
        }

        protected string ToString(UnitOfMeasure desiredUnits) {
            desiredUnits.DimensionType.ShouldBe(DimensionType);
            return string.Format("{0} {1}", In(desiredUnits), desiredUnits.Abbreviation);
        }

        protected string ToString(UnitOfMeasure desiredUnits, int precision) {
            string format = "{0:N[pre]} {1}".Replace("[pre]", precision.ToString(CultureInfo.InvariantCulture));
            return string.Format(format, In(desiredUnits), desiredUnits.Abbreviation);
        }

        private const double CloseMargin = 2.2204460492503131E-12;

        private static bool AreClose(double value1, double value2) {
            double num = (Math.Abs(value1) + Math.Abs(value2)) * CloseMargin;
            double difference = value1 - value2;
            bool areClose = (-num < difference) && (difference < num);
            return areClose;
        }

        public static bool operator ==(Dimension left, Dimension right) {
            return Equals(left, right);
        }

        public static bool operator !=(Dimension left, Dimension right) {
            return !Equals(left, right);
        }
    }
}