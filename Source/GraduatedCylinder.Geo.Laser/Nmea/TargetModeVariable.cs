using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Laser.Nmea;

internal class TargetModeVariable : Variable<TargetMode>
{

    public TargetModeVariable()
        : base("TM") { }

    public override bool TryDecode(Sentence line, out TargetMode value) {
        throw new NotImplementedException();
    }

    protected override string Encode(TargetMode value) {
        throw new NotImplementedException();
    }

}