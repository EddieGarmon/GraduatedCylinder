namespace GraduatedCylinder;

public static class Equality
{

    public enum CompareInUnits
    {

        Base,
        LeftHandSide

    }

    /// <summary>
    ///     This value is used to determine if two instances are close enough to be considered the same value.
    /// </summary>
    public static double Tolerance { get; set; } = .0001;

    public static CompareInUnits Units { get; set; } = CompareInUnits.Base;

}