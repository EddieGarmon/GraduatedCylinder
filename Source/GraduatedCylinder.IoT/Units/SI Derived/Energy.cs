using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Energy : IDimension<Energy, EnergyUnit>, IComparable<Energy>, IEquatable<Energy>
    {

        private readonly EnergyUnit _units;
        private readonly float _value;

        public EnergyUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Energy other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Energy other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Energy other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Energy In(EnergyUnit units) {
            throw new NotImplementedException();
        }

    }
}