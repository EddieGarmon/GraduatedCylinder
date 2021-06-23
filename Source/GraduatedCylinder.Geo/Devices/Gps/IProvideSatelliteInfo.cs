using System.Collections.Generic;

namespace GraduatedCylinder.Devices.Gps
{
    public interface IProvideSatelliteInfo
    {

        IEnumerable<SatelliteInfo> Satellites { get; }

    }
}