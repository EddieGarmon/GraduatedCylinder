using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Speed : IDimension<Speed, SpeedUnit>, IComparable<Speed>, IEquatable<Speed>
    {

        private readonly float _value;
        private readonly SpeedUnit _units;

        public Speed(float value, SpeedUnit units) {
            _value = value;
            _units = units;
        }

        public SpeedUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Speed other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Speed other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Speed other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Speed In(SpeedUnit units) {
            throw new NotImplementedException();
        }

    }
}