using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Time : IDimension<Time, TimeUnit>
    {

        private readonly float _value;
        private readonly TimeUnit _units;

        public Time(float value, TimeUnit units) {
            _value = value;
            _units = units;
        }

        public TimeUnit Units => _units;

        public float Value => _value;

    }
}