using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum MomentumUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = KilogramMetersPerSecond,

        [UnitAbbreviation("kgm/s")]
        [Scale(1.0f)]
        KilogramMetersPerSecond = 0,

        [UnitAbbreviation("gcm/s")]
        [Scale(1e-5f)]
        GramCentimetersPerSecond = 1,

        [UnitAbbreviation("kgm/min")]
        [Scale(1.0f / 60.0f)]
        KilogramsMetersPerMinute = 2,

        [UnitAbbreviation("kgkm/h")]
        [Scale(1.0f / 3.6f)]
        KilogramsKiloMetersPerHour = 3,

        [UnitAbbreviation("lbm/h")]
        [Scale(0.2027739f)]
        PoundsMilesPerHour = 4

    }
}