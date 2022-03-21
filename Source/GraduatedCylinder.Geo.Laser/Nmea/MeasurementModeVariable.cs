using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Laser.Nmea;

internal class MeasurementModeVariable : Variable<MeasurementMode>
{

    public MeasurementModeVariable()
        : base("MM") { }

    public override bool TryDecode(Sentence line, out MeasurementMode value) {
        throw new NotImplementedException();
    }

    protected override string Encode(MeasurementMode value) {
        throw new NotImplementedException();
    }

}