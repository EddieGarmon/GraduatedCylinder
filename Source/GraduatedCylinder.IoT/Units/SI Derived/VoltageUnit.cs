using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum VoltageUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Volts,

        [UnitAbbreviation("µV")]
        [Scale(1e-6f)]
        Microvolts = -6,

        [UnitAbbreviation("mV")]
        [Scale(1e-3f)]
        Millivolts = -3,

        [UnitAbbreviation("V")]
        [Scale(1.0f)]
        Volts = 0,

        [UnitAbbreviation("kV")]
        [Scale(1e3f)]
        Kilovolts = 3,

        [UnitAbbreviation("MV")]
        [Scale(1e6f)]
        Megavolts = 6,

        [UnitAbbreviation("GV")]
        [Scale(1e9f)]
        Gigavolts = 9,

    }
}