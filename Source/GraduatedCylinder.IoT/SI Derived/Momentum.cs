using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Momentum : IDimension<Momentum, MomentumUnit>, IComparable<Momentum>, IEquatable<Momentum>
    {

        private readonly float _value;
        private readonly MomentumUnit _units;

        public Momentum(float value, MomentumUnit units) {
            _value = value;
            _units = units;
        }

        public MomentumUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Momentum other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Momentum other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Momentum other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Momentum In(MomentumUnit units) {
            throw new NotImplementedException();
        }

    }
}