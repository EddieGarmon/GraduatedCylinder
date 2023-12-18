#if GraduatedCylinder
namespace GraduatedCylinder.Calculators;
#endif
#if Pipette
namespace Pipette.Calculators;
#endif

public static class VolumeCalculator
{

    public static Volume OfCone(Length radius, Length height) {
        return 1.0 / 3.0 * Constants.Pi * radius * radius * height;
    }

    public static Volume OfCylinder(Length radius, Length height) {
        return Constants.Pi * radius * radius * height;
    }

    public static Volume OfSphere(Length radius) {
        return 4.0 / 3.0 * Constants.Pi * radius * radius * radius;
    }

    public static Volume OfSquarePyramid(Length side, Length height) {
        return 1.0 / 3.0 * side * side * height;
    }

}