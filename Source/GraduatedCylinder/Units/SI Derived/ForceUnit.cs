using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum ForceUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Newtons,

        [UnitAbbreviation("N")]
        [Scale(1.0f)]
        Newtons = 0,

        [UnitAbbreviation("lbf")]
        [Scale(4.44822f)]
        PoundForce = 1,

        [UnitAbbreviation("kgf")]
        [Scale(9.81f)]
        KilogramForce = 2

    }
}