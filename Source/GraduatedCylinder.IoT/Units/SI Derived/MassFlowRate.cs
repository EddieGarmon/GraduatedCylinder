using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct MassFlowRate : IDimension<MassFlowRate, MassFlowRateUnit>
    {

        private readonly float _value;
        private readonly MassFlowRateUnit _units;

        public MassFlowRate(float value, MassFlowRateUnit units) {
            _value = value;
            _units = units;
        }

        public MassFlowRateUnit Units => _units;

        public float Value => _value;

    }
}