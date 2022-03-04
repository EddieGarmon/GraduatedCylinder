namespace GraduatedCylinder.Calculators;

public static class VolumeCalculator
{

    public static Volume OfCone(Length radius, Length height) {
        return (1.0 / 3.0) * Const.Pi * radius * radius * height;
    }

    public static Volume OfCylinder(Length radius, Length height) {
        return Const.Pi * radius * radius * height;
    }

    public static Volume OfSphere(Length radius) {
        return (4.0 / 3.0) * Const.Pi * radius * radius * radius;
    }

    public static Volume OfSquarePyramid(Length side, Length height) {
        return (1.0 / 3.0) * side * side * height;
    }

}