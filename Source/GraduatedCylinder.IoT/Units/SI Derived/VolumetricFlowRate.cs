using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct VolumetricFlowRate : IDimension<VolumetricFlowRate, VolumetricFlowRateUnit>

    {

        private readonly float _value;
        private readonly VolumetricFlowRateUnit _units;

        public VolumetricFlowRate(float value, VolumetricFlowRateUnit units) {
            _value = value;
            _units = units;
        }

        public VolumetricFlowRateUnit Units => _units;

        public float Value => _value;

    }
}