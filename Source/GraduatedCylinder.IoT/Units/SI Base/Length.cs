using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    public partial struct Length { }

    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Length : IDimension<Length, LengthUnit>
    {

        private readonly float _value;
        private readonly LengthUnit _units;

        public Length(float value, LengthUnit units) {
            _value = value;
            _units = units;
        }

        public LengthUnit Units => _units;

        public float Value => _value;

    }
}