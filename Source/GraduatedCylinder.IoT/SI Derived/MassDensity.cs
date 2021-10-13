using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct MassDensity : IDimension<MassDensity, MassDensityUnit>,
                                         IComparable<MassDensity>,
                                         IEquatable<MassDensity>
    {

        private readonly float _value;
        private readonly MassDensityUnit _units;

        public MassDensity(float value, MassDensityUnit units) {
            _value = value;
            _units = units;
        }

        public MassDensityUnit Units => _units;

        public float Value => _value;

        public int CompareTo(MassDensity other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(MassDensity other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is MassDensity other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public MassDensity In(MassDensityUnit units) {
            throw new NotImplementedException();
        }

    }
}