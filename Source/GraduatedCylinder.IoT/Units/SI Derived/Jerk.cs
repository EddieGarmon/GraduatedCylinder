using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Jerk : IDimension<Jerk, JerkUnit>, IComparable<Jerk>, IEquatable<Jerk>
    {

        private readonly float _value;
        private readonly JerkUnit _units;

        public Jerk(float value, JerkUnit units) {
            _value = value;
            _units = units;
        }

        public JerkUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Jerk other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Jerk other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Jerk other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Jerk In(JerkUnit units) {
            throw new NotImplementedException();
        }

    }
}