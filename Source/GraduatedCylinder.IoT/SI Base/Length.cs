using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Length : IDimension<Length, LengthUnit>, IComparable<Length>, IEquatable<Length>
    {

        private readonly float _value;
        private readonly LengthUnit _units;

        public Length(float value, LengthUnit units) {
            _value = value;
            _units = units;
        }

        public LengthUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Length other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Length other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Length other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Length In(LengthUnit units) {
            throw new NotImplementedException();
        }

    }
}