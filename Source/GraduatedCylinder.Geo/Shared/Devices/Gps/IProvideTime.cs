using System;

namespace GraduatedCylinder.Devices.Gps
{
    public interface IProvideTime
    {
        DateTime CurrentTime { get; }
    }
}