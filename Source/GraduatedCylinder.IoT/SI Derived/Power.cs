using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Power : IDimension<Power, PowerUnit>, IComparable<Power>, IEquatable<Power>
    {

        private readonly float _value;
        private readonly PowerUnit _units;

        public Power(float value, PowerUnit units) {
            _value = value;
            _units = units;
        }

        public PowerUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Power other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Power other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Power other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Power In(PowerUnit units) {
            throw new NotImplementedException();
        }

    }
}