using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Laser.Nmea;

internal class BatteryVoltageVariable : Variable<ElectricPotential>
{

    public BatteryVoltageVariable()
        : base("BV") { }

    public override bool TryDecode(Sentence line, out ElectricPotential value) {
        value = ElectricPotential.Unknown; //default value

        if (line.Id != Id) {
            return false;
        }

        if (!double.TryParse(line[1], out double newValue)) {
            return false;
        }
        value = new ElectricPotential(newValue, ElectricPotentialUnit.Millivolt);
        return true;
    }

    protected override string Encode(ElectricPotential value) {
        throw new NotImplementedException();
    }

}