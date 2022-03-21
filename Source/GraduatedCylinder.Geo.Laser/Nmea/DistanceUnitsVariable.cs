using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Laser.Nmea;

internal class DistanceUnitsVariable : Variable<DistanceUnitsMode>
{

    public DistanceUnitsVariable()
        : base("DU") { }

    public override bool TryDecode(Sentence line, out DistanceUnitsMode value) {
        throw new NotImplementedException();
    }

    protected override string Encode(DistanceUnitsMode value) {
        throw new NotImplementedException();
    }

}