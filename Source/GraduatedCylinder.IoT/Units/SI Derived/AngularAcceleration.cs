using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AngularAcceleration : IDimension<AngularAcceleration, AngularAccelerationUnit>,
                                                 IComparable<AngularAcceleration>,
                                                 IEquatable<AngularAcceleration>
    {

        private readonly float _value;
        private readonly AngularAccelerationUnit _units;

        public AngularAcceleration(float value, AngularAccelerationUnit units) {
            _value = value;
            _units = units;
        }

        public AngularAccelerationUnit Units => _units;

        public float Value => _value;

        public int CompareTo(AngularAcceleration other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(AngularAcceleration other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is AngularAcceleration other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public AngularAcceleration In(AngularAccelerationUnit units) {
            throw new NotImplementedException();
        }

    }
}