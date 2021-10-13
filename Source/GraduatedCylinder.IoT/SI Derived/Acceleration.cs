using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Acceleration : IDimension<Acceleration, AccelerationUnit>,
                                          IComparable<Acceleration>,
                                          IEquatable<Acceleration>
    {

        private readonly float _value;
        private readonly AccelerationUnit _units;

        public Acceleration(float value, AccelerationUnit units) {
            _value = value;
            _units = units;
        }

        public AccelerationUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Acceleration other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Acceleration other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Acceleration other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Acceleration In(AccelerationUnit units) {
            throw new NotImplementedException();
        }

    }
}