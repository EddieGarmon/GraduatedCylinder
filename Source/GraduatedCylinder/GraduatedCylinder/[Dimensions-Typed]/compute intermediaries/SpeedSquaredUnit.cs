namespace GraduatedCylinder
{
    public enum SpeedSquaredUnit
    {
        BaseUnit = MetersSquaredPerSecondSquared,

        /// <summary>
        ///     Meters^2/Second^2, This is the Base Unit
        /// </summary>
        [UnitAbbreviation("m^2/s^2")]
        [Scale(1.0)]
        MetersSquaredPerSecondSquared = 0
    }
}