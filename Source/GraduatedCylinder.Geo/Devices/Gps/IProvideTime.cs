using System;

namespace GraduatedCylinder.Devices.Gps
{
    public interface IProvideTime
    {
        DateTimeOffset CurrentTime { get; }
    }
}