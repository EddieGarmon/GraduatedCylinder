using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Volume : IDimension<Volume, VolumeUnit>, IComparable<Volume>, IEquatable<Volume>
    {

        private readonly float _value;
        private readonly VolumeUnit _units;

        public Volume(float value, VolumeUnit units) {
            _value = value;
            _units = units;
        }

        public VolumeUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Volume other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Volume other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Volume other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Volume In(VolumeUnit units) {
            throw new NotImplementedException();
        }

    }
}