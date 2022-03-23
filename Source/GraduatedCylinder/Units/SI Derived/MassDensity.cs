namespace GraduatedCylinder;

public partial struct MassDensity : IDimension<MassDensity, MassDensityUnit>
{

    public static Mass operator *(MassDensity massDensity, Volume volume) {
        massDensity = massDensity.In(MassDensityUnit.KiloGramsPerLiter);
        volume = volume.In(VolumeUnit.Liters);
        return new Mass(massDensity.Value * volume.Value, MassUnit.KiloGram);
    }

}