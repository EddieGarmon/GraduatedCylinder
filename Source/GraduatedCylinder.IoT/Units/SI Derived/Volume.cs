using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Volume : IDimension<Volume, VolumeUnit>
    {

        private readonly float _value;
        private readonly VolumeUnit _units;

        public Volume(float value, VolumeUnit units) {
            _value = value;
            _units = units;
        }

        public VolumeUnit Units => _units;

        public float Value => _value;

    }
}