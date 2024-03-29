﻿#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Temperature : IDimension<Temperature, TemperatureUnit>
{

    public static Temperature WaterBoilsAt { get; } = new(100, TemperatureUnit.Celsius);

    public static Temperature WaterFreezesAt { get; } = new(0, TemperatureUnit.Celsius);

}