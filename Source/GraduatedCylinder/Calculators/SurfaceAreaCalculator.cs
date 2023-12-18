#if GraduatedCylinder
namespace GraduatedCylinder.Calculators;
#endif
#if Pipette
namespace Pipette.Calculators;
#endif

public static class SurfaceAreaCalculator
{

    public static Area OfCone(Length radius, Length height) {
        Length sideLength = TriangleCalculator.GetHypotenuse(radius, height);
        return Constants.Pi * radius * radius + Constants.Pi * radius * sideLength;
    }

    public static Area OfCylinder(Length radius, Length height) {
        return Constants.TwoPi * radius * radius + Constants.TwoPi * radius * height;
    }

    public static Area OfSphere(Length radius) {
        return Constants.FourPi * radius * radius;
    }

}