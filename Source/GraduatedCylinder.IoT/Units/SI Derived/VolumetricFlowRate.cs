using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct VolumetricFlowRate : IDimension<VolumetricFlowRate, VolumetricFlowRateUnit>,
                                                IComparable<VolumetricFlowRate>,
                                                IEquatable<VolumetricFlowRate>
    {

        private readonly float _value;
        private readonly VolumetricFlowRateUnit _units;

        public VolumetricFlowRate(float value, VolumetricFlowRateUnit units) {
            _value = value;
            _units = units;
        }

        public VolumetricFlowRateUnit Units => _units;

        public float Value => _value;

        public int CompareTo(VolumetricFlowRate other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(VolumetricFlowRate other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is VolumetricFlowRate other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public VolumetricFlowRate In(VolumetricFlowRateUnit units) {
            throw new NotImplementedException();
        }

    }
}