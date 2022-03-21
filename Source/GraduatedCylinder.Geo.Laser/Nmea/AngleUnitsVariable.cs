using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Laser.Nmea;

internal class AngleUnitsVariable : Variable<AngleUnitsMode>
{

    public AngleUnitsVariable()
        : base("AU") { }

    public override bool TryDecode(Sentence line, out AngleUnitsMode value) {
        value = AngleUnitsMode.Degrees; //default value

        if (line.Id != Id) {
            return false;
        }

        if (!int.TryParse(line[1], out int intValue)) {
            return false;
        }
        value = (AngleUnitsMode)intValue;
        return true;
    }

    protected override string Encode(AngleUnitsMode value) {
        throw new NotImplementedException();
    }

}