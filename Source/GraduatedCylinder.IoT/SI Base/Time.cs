using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Time : IDimension<Time, TimeUnit>, IComparable<Time>, IEquatable<Time>
    {

        private readonly float _value;
        private readonly TimeUnit _units;

        public Time(float value, TimeUnit units) {
            _value = value;
            _units = units;
        }

        public TimeUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Time other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Time other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Time other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Time In(TimeUnit units) {
            throw new NotImplementedException();
        }

    }
}