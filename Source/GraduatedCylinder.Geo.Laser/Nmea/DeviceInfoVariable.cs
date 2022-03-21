using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Laser.Nmea;

internal class DeviceInfoVariable : Variable<DeviceInfo>
{

    public DeviceInfoVariable()
        : base("ID") { }

    public override bool TryDecode(Sentence line, out DeviceInfo value) {
        throw new NotImplementedException();
    }

    protected override string Encode(DeviceInfo value) {
        throw new NotImplementedException();
    }

}