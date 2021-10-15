using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Momentum : IDimension<Momentum, MomentumUnit>
    {

        private readonly float _value;
        private readonly MomentumUnit _units;

        public Momentum(float value, MomentumUnit units) {
            _value = value;
            _units = units;
        }

        public MomentumUnit Units => _units;

        public float Value => _value;

    }
}