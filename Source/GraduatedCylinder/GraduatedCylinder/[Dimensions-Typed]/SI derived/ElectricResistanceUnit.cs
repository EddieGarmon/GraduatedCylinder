namespace GraduatedCylinder
{
    public enum ElectricResistanceUnit
    {
        BaseUnit = Ohm,

        [UnitAbbreviation("yΩ")]
        [Scale(1e-24)]
        Yoctoohm = -24,

        [UnitAbbreviation("zΩ")]
        [Scale(1e-21)]
        Zeptoohm = -21,

        [UnitAbbreviation("aΩ")]
        [Scale(1e-18)]
        Attoohm = -18,

        [UnitAbbreviation("fΩ")]
        [Scale(1e-15)]
        Femtoohm = -15,

        [UnitAbbreviation("pΩ")]
        [Scale(1e-12)]
        Picoohm = -12,

        [UnitAbbreviation("nΩ")]
        [Scale(1e-9)]
        Nanoohm = -9,

        [UnitAbbreviation("µΩ")]
        [Scale(1e-6)]
        Microohm = -6,

        [UnitAbbreviation("mΩ")]
        [Scale(1e-3)]
        Milliohm = -3,

        [UnitAbbreviation("cΩ")]
        [Scale(1e-2)]
        Centiohm = -2,

        [UnitAbbreviation("dΩ")]
        [Scale(1e-1)]
        Deciohm = -1,

        [UnitAbbreviation("Ω")]
        [Scale(1.0)]
        Ohm = 0,

        [UnitAbbreviation("daΩ")]
        [Scale(10)]
        Dekaohm = 1,

        [UnitAbbreviation("hΩ")]
        [Scale(1e2)]
        Hectoohm = 2,

        [UnitAbbreviation("kΩ")]
        [Scale(1e3)]
        Kiloohm = 3,

        [UnitAbbreviation("MΩ")]
        [Scale(1e6)]
        Megaogm = 6,

        [UnitAbbreviation("GΩ")]
        [Scale(1e9)]
        Gigaogm = 9,

        [UnitAbbreviation("TΩ")]
        [Scale(1e12)]
        Teraohm = 12,

        [UnitAbbreviation("PΩ")]
        [Scale(1e15)]
        Petaohm = 15,

        [UnitAbbreviation("EΩ")]
        [Scale(1e18)]
        Exaohm = 18,

        [UnitAbbreviation("ZΩ")]
        [Scale(1e21)]
        Zettaohm = 21,

        [UnitAbbreviation("YΩ")]
        [Scale(1e24)]
        Yottaohm = 24
    }
}