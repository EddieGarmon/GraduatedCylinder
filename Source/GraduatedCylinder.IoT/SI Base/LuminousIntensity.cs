using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct LuminousIntensity : IDimension<LuminousIntensity, LuminousIntensityUnit>,
                                               IComparable<LuminousIntensity>,
                                               IEquatable<LuminousIntensity>
    {

        private readonly float _value;

        private readonly LuminousIntensityUnit _units;

        public LuminousIntensity(float value, LuminousIntensityUnit units) {
            _value = value;
            _units = units;
        }

        public LuminousIntensityUnit Units => _units;

        public float Value => _value;

        public int CompareTo(LuminousIntensity other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(LuminousIntensity other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is LuminousIntensity other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public LuminousIntensity In(LuminousIntensityUnit units) {
            throw new NotImplementedException();
        }

    }
}