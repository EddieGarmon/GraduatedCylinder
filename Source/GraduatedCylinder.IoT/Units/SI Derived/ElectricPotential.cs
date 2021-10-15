using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ElectricPotential : IDimension<ElectricPotential, ElectricPotentialUnit>,
                                               IComparable<ElectricPotential>,
                                               IEquatable<ElectricPotential>
    {

        private readonly float _value;
        private readonly ElectricPotentialUnit _units;

        public ElectricPotential(float value, ElectricPotentialUnit units) {
            _value = value;
            _units = units;
        }

        public ElectricPotentialUnit Units => _units;

        public float Value => _value;

        public int CompareTo(ElectricPotential other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(ElectricPotential other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is ElectricPotential other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public ElectricPotential In(ElectricPotentialUnit units) {
            throw new NotImplementedException();
        }

    }
}