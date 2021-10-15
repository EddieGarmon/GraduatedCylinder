using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Converters;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ElectricCurrent : IDimension<ElectricCurrent, ElectricCurrentUnit>,
                                             IComparable<ElectricCurrent>,
                                             IEquatable<ElectricCurrent>
    {

        private readonly float _value;
        private readonly ElectricCurrentUnit _units;

        public ElectricCurrent(float value, ElectricCurrentUnit units) {
            _value = value;
            _units = units;
        }

        public ElectricCurrentUnit Units => _units;

        public float Value => _value;

        public int CompareTo(ElectricCurrent other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                float thisInBase = ElectricCurrentConverter.ToBase(this);
                float otherInBase = ElectricCurrentConverter.ToBase(other);
                return thisInBase.CompareTo(otherInBase);
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(ElectricCurrent other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            return obj is ElectricCurrent other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine(_value, (int)_units);
        }

        public ElectricCurrent In(ElectricCurrentUnit units) {
            if (Units == units) {
                return this;
            }
            float baseValue = ElectricCurrentConverter.ToBase(this);
            return ElectricCurrentConverter.FromBase(baseValue, units);
        }

        public static ElectricCurrent Zero => new ElectricCurrent(0, ElectricCurrentUnit.Ampere);

        //todo: operators

    }
}