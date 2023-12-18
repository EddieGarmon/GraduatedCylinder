#if GraduatedCylinder
namespace GraduatedCylinder.Calculators;
#endif
#if Pipette
namespace Pipette.Calculators;
#endif

public class TriangleCalculator
{

    public static Length GetHypotenuse(Length sideA, Length sideB) {
        return (sideA * sideA + sideB * sideB).SquareLength();
    }

}