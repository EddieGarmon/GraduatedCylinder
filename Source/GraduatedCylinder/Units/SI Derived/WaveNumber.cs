namespace GraduatedCylinder;

public partial struct WaveNumber : IDimension<WaveNumber, WaveNumberUnit>
{

    public Length ToWaveLength() {
        switch (Units) {
            case WaveNumberUnit.ReciprocalCentiMeter:
                return new Length(1 / Value, LengthUnit.CentiMeter);
            case WaveNumberUnit.ReciprocalMeter:
                return new Length(1 / Value, LengthUnit.Meter);
            case WaveNumberUnit.ReciprocalKiloMeter:
                return new Length(1 / Value, LengthUnit.KiloMeter);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

}