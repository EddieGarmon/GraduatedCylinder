namespace GraduatedCylinder.Calculators;

public class TriangleCalculator
{

    public static Length GetHypotenuse(Length sideA, Length sideB) {
        return (sideA * sideA + sideB * sideB).SquareLength();
    }

}