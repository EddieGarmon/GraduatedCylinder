using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(AngularSpeed))]
public enum AngularSpeedUnit : short
{

    Unspecified = short.MinValue,

    [BaseUnit]
    [UnitAbbreviation("rad/s")]
    [Scale(1.0)]
    [Extension("RadiansPerSecond")]
    RadiansPerSecond = 0,

    [UnitAbbreviation("rad/min")]
    [Scale(0.0166666666666667)]
    RadiansPerMinute = 1,

    [UnitAbbreviation("rad/h")]
    [Scale(2.777778E-4)]
    RadiansPerHour = 2,

    [UnitAbbreviation("�/s")]
    [Scale(0.0174532925199433)]
    DegreesPerSecond = 100,

    [UnitAbbreviation("�/min")]
    [Scale(2.908882E-4)]
    DegreesPerMinute = 101,

    [UnitAbbreviation("�/h")]
    [Scale(4.848137E-6)]
    DegreesPerHour = 102,

    [UnitAbbreviation("rps")]
    [Scale(6.28318530717959)]
    RevolutionsPerSecond = 200,

    [UnitAbbreviation("rpm")]
    [Scale(0.10471975511966)]
    [Extension("RevolutionsPerMinute")]
    RevolutionsPerMinute = 201,

    [UnitAbbreviation("rph")]
    [Scale(0.00174532925199433)]
    RevolutionsPerHour = 202

}