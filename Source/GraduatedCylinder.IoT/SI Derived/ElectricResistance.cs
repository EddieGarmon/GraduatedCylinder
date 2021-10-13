using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ElectricResistance : IDimension<ElectricResistance, ElectricResistanceUnit>,
                                                IComparable<ElectricResistance>,
                                                IEquatable<ElectricResistance>
    {

        private readonly float _value;
        private readonly ElectricResistanceUnit _units;

        public ElectricResistance(float value, ElectricResistanceUnit units) {
            _value = value;
            _units = units;
        }

        public ElectricResistanceUnit Units => _units;

        public float Value => _value;

        public int CompareTo(ElectricResistance other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(ElectricResistance other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is ElectricResistance other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public ElectricResistance In(ElectricResistanceUnit units) {
            throw new NotImplementedException();
        }

    }
}