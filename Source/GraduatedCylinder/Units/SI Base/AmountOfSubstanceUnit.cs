using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum AmountOfSubstanceUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Mole,

        [UnitAbbreviation("ymol")]
        [Scale(1e-24)]
        Yoctomole = -24,

        [UnitAbbreviation("zmol")]
        [Scale(1e-21)]
        Zeptomole = -21,

        [UnitAbbreviation("amol")]
        [Scale(1e-18)]
        Attomole = -18,

        [UnitAbbreviation("fmol")]
        [Scale(1e-15)]
        Femtomole = -15,

        [UnitAbbreviation("pmol")]
        [Scale(1e-12)]
        Picomole = -12,

        [UnitAbbreviation("nmol")]
        [Scale(1e-9)]
        Nanomole = -9,

        [UnitAbbreviation("µmol")]
        [Scale(1e-6)]
        Micromole = -6,

        [UnitAbbreviation("mmol")]
        [Scale(1e-3)]
        Millimole = -3,

        [UnitAbbreviation("cmol")]
        [Scale(1e-2)]
        Centimole = -2,

        [UnitAbbreviation("dmol")]
        [Scale(1e-1)]
        Decimole = -1,

        [UnitAbbreviation("mol")]
        [Scale(1.0)]
        Mole = 0,

        [UnitAbbreviation("damol")]
        [Scale(10)]
        Dekamole = 1,

        [UnitAbbreviation("hmol")]
        [Scale(1e2)]
        Hectomole = 2,

        [UnitAbbreviation("kmol")]
        [Scale(1e3)]
        Kilomole = 3,

        [UnitAbbreviation("Mmol")]
        [Scale(1e6)]
        Megamole = 6,

        [UnitAbbreviation("Gmol")]
        [Scale(1e9)]
        Gigamole = 9,

        [UnitAbbreviation("Tmol")]
        [Scale(1e12)]
        Teramole = 12,

        [UnitAbbreviation("Pmol")]
        [Scale(1e15)]
        Petamole = 15,

        [UnitAbbreviation("Emol")]
        [Scale(1e18)]
        Examole = 18,

        [UnitAbbreviation("Zmol")]
        [Scale(1e21)]
        Zetamole = 21,

        [UnitAbbreviation("Ymol")]
        [Scale(1e24)]
        Yottamole = 24

    }
}