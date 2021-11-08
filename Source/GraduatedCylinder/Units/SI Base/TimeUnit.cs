using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    /// <summary>
    /// One of the seven SI base quantities.
    /// </summary>
    public enum TimeUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Second,

        [UnitAbbreviation("ys")]
        [Scale(1e-24f)]
        Yoctosecond = -24,

        [UnitAbbreviation("zs")]
        [Scale(1e-21f)]
        Zeptosecond = -21,

        [UnitAbbreviation("as")]
        [Scale(1e-18f)]
        Attosecond = -18,

        [UnitAbbreviation("fs")]
        [Scale(1e-15f)]
        Femtosecond = -15,

        [UnitAbbreviation("ps")]
        [Scale(1e-12f)]
        Picosecond = -12,

        [UnitAbbreviation("ns")]
        [Scale(1e-9f)]
        Nanosecond = -9,

        [UnitAbbreviation("µs")]
        [Scale(1e-6f)]
        MicroSecond = -6,

        [UnitAbbreviation("ms")]
        [Scale(1e-3f)]
        MilliSecond = -3,

        [UnitAbbreviation("cs")]
        [Scale(1e-2f)]
        Centisecond = -2,

        [UnitAbbreviation("ds")]
        [Scale(1e-1f)]
        Decisecond = -1,

        /// <summary>
        /// This is the Base Unit
        /// </summary>
        [UnitAbbreviation("s")]
        [Scale(1.0f)]
        Second = 0,

        [UnitAbbreviation("das")]
        [Scale(10f)]
        Dekasecond = 1,

        [UnitAbbreviation("hs")]
        [Scale(100f)]
        Hectosecond = 2,

        [UnitAbbreviation("ks")]
        [Scale(1e3f)]
        Kilosecond = 3,

        [UnitAbbreviation("Ms")]
        [Scale(1e6f)]
        Megasecond = 6,

        [UnitAbbreviation("Gs")]
        [Scale(1e9f)]
        Gigasecond = 9,

        [UnitAbbreviation("Ts")]
        [Scale(1e12f)]
        Terasecond = 12,

        [UnitAbbreviation("Ps")]
        [Scale(1e15f)]
        Petasecond = 15,

        [UnitAbbreviation("Es")]
        [Scale(1e18f)]
        Exasecond = 18,

        [UnitAbbreviation("Zs")]
        [Scale(1e21f)]
        Zettasecond = 21,

        [UnitAbbreviation("Ys")]
        [Scale(1e24f)]
        Yottasecond = 24,

        [UnitAbbreviation("min")]
        [Scale(60.0f)]
        Minutes = 103,

        [UnitAbbreviation("h")]
        [Scale(3600.0f)]
        Hours = 104,

        [UnitAbbreviation("d")]
        [Scale(86400.0f)]
        Days = 105,

        //Weeks = 106,
        //Months = 107,
        //Years = 108,

        [UnitAbbreviation("ticks")]
        [Scale(1e-7f)]
        Ticks = 110

    }
}