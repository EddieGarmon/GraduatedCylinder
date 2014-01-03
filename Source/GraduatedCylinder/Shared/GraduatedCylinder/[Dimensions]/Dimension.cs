using System;
using System.Globalization;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This is the base class for all dimensions.
    /// </summary>
    public abstract partial class Dimension : ISupportUnitOfMeasure
    {
        private const double CloseMargin = 2.2204460492503131E-12;
        private readonly double _baseUnitsValue;
        private readonly DimensionType _dimensionType;
        private UnitOfMeasure _currentUnits;
        private double _currentValue;

        protected Dimension(double value, UnitOfMeasure unitOfMeasure) {
            Guard.NotNull(unitOfMeasure, "unitOfMeasure");
            _dimensionType = unitOfMeasure.DimensionType;
            _currentValue = value;
            _currentUnits = unitOfMeasure;
            _baseUnitsValue = _currentUnits.UnitConverter.ToBaseUnit(value);
        }

        public DimensionType DimensionType {
            get { return _dimensionType; }
        }

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
                value.DimensionType.ShouldBe(_dimensionType);
                _currentUnits = value;
                _currentValue = _currentUnits.UnitConverter.FromBaseUnit(_baseUnitsValue);
            }
        }

        /// <summary>
        ///     Gets the value in the current units.
        /// </summary>
        /// <value>The value.</value>
        public double Value {
            get { return _currentValue; }
        }

        public double ValueInBaseUnits {
            get { return _baseUnitsValue; }
        }

        public int CompareTo(ISupportUnitOfMeasure other) {
            if (other == null) {
                return 1;
            }
            if (ReferenceEquals(this, other)) {
                return 0;
            }
            int dimensionTypeComparison = _dimensionType.CompareTo(other.DimensionType);
            if (dimensionTypeComparison != 0) {
                return dimensionTypeComparison;
            }
            double otherValueInBase = other.ValueInBaseUnits;
            return AreClose(_baseUnitsValue, otherValueInBase) ? 0 : _baseUnitsValue.CompareTo(otherValueInBase);
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
            return ((int)_dimensionType << 25) ^ _baseUnitsValue.GetHashCode();
        }

        public override string ToString() {
            return string.Format("{0} {1}", _currentValue, _currentUnits.Abbreviation);
        }

        public string ToString(int precision) {
            string format = "{0:N[pre]} {1}".Replace("[pre]", precision.ToString(CultureInfo.InvariantCulture));
            return string.Format(format, _currentValue, _currentUnits.Abbreviation);
        }

        /// <summary>
        ///     Gets the current value in the desired units. The object's value is not changed.
        /// </summary>
        /// <param name="desiredUnits">The desired units.</param>
        /// <returns></returns>
        protected double In(UnitOfMeasure desiredUnits) {
            desiredUnits.DimensionType.ShouldBe(_dimensionType);
            return (_currentUnits == desiredUnits) ? _currentValue : desiredUnits.UnitConverter.FromBaseUnit(_baseUnitsValue);
        }

        protected string ToString(UnitOfMeasure desiredUnits) {
            desiredUnits.DimensionType.ShouldBe(_dimensionType);
            return string.Format("{0} {1}", In(desiredUnits), desiredUnits.Abbreviation);
        }

        protected string ToString(UnitOfMeasure desiredUnits, int precision) {
            string format = "{0:N[pre]} {1}".Replace("[pre]", precision.ToString(CultureInfo.InvariantCulture));
            return string.Format(format, In(desiredUnits), desiredUnits.Abbreviation);
        }

        public static bool operator ==(Dimension left, Dimension right) {
            return Equals(left, right);
        }

        public static bool operator !=(Dimension left, Dimension right) {
            return !Equals(left, right);
        }

        private static bool AreClose(double value1, double value2) {
            double num = (Math.Abs(value1) + Math.Abs(value2)) * CloseMargin;
            double difference = value1 - value2;
            bool areClose = (-num < difference) && (difference < num);
            return areClose;
        }
    }
}