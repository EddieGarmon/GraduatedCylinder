using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum AmountOfSubstanceUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Mole,

        [UnitAbbreviation("ymol")]
        [Scale(1e-24f)]
        Yoctomole = -24,

        [UnitAbbreviation("zmol")]
        [Scale(1e-21f)]
        Zeptomole = -21,

        [UnitAbbreviation("amol")]
        [Scale(1e-18f)]
        Attomole = -18,

        [UnitAbbreviation("fmol")]
        [Scale(1e-15f)]
        Femtomole = -15,

        [UnitAbbreviation("pmol")]
        [Scale(1e-12f)]
        Picomole = -12,

        [UnitAbbreviation("nmol")]
        [Scale(1e-9f)]
        Nanomole = -9,

        [UnitAbbreviation("µmol")]
        [Scale(1e-6f)]
        Micromole = -6,

        [UnitAbbreviation("mmol")]
        [Scale(1e-3f)]
        Millimole = -3,

        [UnitAbbreviation("cmol")]
        [Scale(1e-2f)]
        Centimole = -2,

        [UnitAbbreviation("dmol")]
        [Scale(1e-1f)]
        Decimole = -1,

        [UnitAbbreviation("mol")]
        [Scale(1.0f)]
        Mole = 0,

        [UnitAbbreviation("damol")]
        [Scale(10f)]
        Dekamole = 1,

        [UnitAbbreviation("hmol")]
        [Scale(1e2f)]
        Hectomole = 2,

        [UnitAbbreviation("kmol")]
        [Scale(1e3f)]
        Kilomole = 3,

        [UnitAbbreviation("Mmol")]
        [Scale(1e6f)]
        Megamole = 6,

        [UnitAbbreviation("Gmol")]
        [Scale(1e9f)]
        Gigamole = 9,

        [UnitAbbreviation("Tmol")]
        [Scale(1e12f)]
        Teramole = 12,

        [UnitAbbreviation("Pmol")]
        [Scale(1e15f)]
        Petamole = 15,

        [UnitAbbreviation("Emol")]
        [Scale(1e18f)]
        Examole = 18,

        [UnitAbbreviation("Zmol")]
        [Scale(1e21f)]
        Zetamole = 21,

        [UnitAbbreviation("Ymol")]
        [Scale(1e24f)]
        Yottamole = 24

    }
}