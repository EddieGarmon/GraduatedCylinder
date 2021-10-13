using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Force : IDimension<Force, ForceUnit>, IComparable<Force>, IEquatable<Force>
    {

        private readonly float _value;
        private readonly ForceUnit _units;

        public Force(float value, ForceUnit units) {
            _value = value;
            _units = units;
        }

        public ForceUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Force other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Force other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Force other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Force In(ForceUnit units) {
            throw new NotImplementedException();
        }

    }
}