using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AmountOfSubstance : IDimension<AmountOfSubstance, AmountOfSubstanceUnit>,
                                               IComparable<AmountOfSubstance>,
                                               IEquatable<AmountOfSubstance>
    {

        private readonly float _value;
        private readonly AmountOfSubstanceUnit _units;

        public AmountOfSubstance(float value, AmountOfSubstanceUnit units) {
            _value = value;
            _units = units;
        }

        public AmountOfSubstanceUnit Units => _units;

        public float Value => _value;

        public int CompareTo(AmountOfSubstance other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(AmountOfSubstance other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            return obj is AmountOfSubstance other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public AmountOfSubstance In(AmountOfSubstanceUnit units) {
            throw new NotImplementedException();
        }

    }
}