using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Area : IDimension<Area, AreaUnit>
    {

        private readonly float _value;
        private readonly AreaUnit _units;

        public Area(float value, AreaUnit units) {
            _value = value;
            _units = units;
        }

        public AreaUnit Units => _units;

        public float Value => _value;

    }
}