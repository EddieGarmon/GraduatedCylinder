namespace GraduatedCylinder;

public partial struct Temperature : IDimension<Temperature, TemperatureUnit>
{

    public static Temperature WaterBoilsAt { get; } = new Temperature(100, TemperatureUnit.Celsius);

    public static Temperature WaterFreezesAt { get; } = new Temperature(0, TemperatureUnit.Celsius);

}