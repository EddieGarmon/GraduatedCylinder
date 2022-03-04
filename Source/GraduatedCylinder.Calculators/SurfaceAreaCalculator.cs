namespace GraduatedCylinder.Calculators;

public static class SurfaceAreaCalculator
{

    public static Area OfCone(Length radius, Length height) {
        Length sideLength = TriangleCalculator.GetHypotenuse(radius, height);
        return Const.Pi * radius * radius + Const.Pi * radius * sideLength;
    }

    public static Area OfCylinder(Length radius, Length height) {
        return Const.TwoPi * radius * radius + Const.TwoPi * radius * height;
    }

    public static Area OfSphere(Length radius) {
        return Const.FourPi * radius * radius;
    }

}