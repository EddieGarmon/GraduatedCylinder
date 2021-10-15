using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Angle : IDimension<Angle, AngleUnit>, IComparable<Angle>, IEquatable<Angle>
    {

        private readonly float _value;
        private readonly AngleUnit _units;

        public Angle(float value, AngleUnit units) {
            _value = value;
            _units = units;
        }

        public AngleUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Angle other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Angle other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Angle other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Angle In(AngleUnit units) {
            throw new NotImplementedException();
        }

    }
}