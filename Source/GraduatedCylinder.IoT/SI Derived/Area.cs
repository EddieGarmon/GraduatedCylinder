using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Area : IDimension<Area, AreaUnit>, IComparable<Area>, IEquatable<Area>
    {

        private readonly float _value;
        private readonly AreaUnit _units;

        public Area(float value, AreaUnit units) {
            _value = value;
            _units = units;
        }

        public AreaUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Area other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Area other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Area other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Area In(AreaUnit units) {
            throw new NotImplementedException();
        }

    }
}