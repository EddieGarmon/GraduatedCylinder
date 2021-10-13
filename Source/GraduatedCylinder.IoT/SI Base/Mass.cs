using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Mass : IDimension<Mass, MassUnit>, IComparable<Mass>, IEquatable<Mass>
    {

        private readonly float _value;
        private readonly MassUnit _units;

        public Mass(float value, MassUnit units) {
            _value = value;
            _units = units;
        }

        public MassUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Mass other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Mass other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Mass other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Mass In(MassUnit units) {
            throw new NotImplementedException();
        }

    }
}