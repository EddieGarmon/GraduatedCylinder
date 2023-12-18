namespace Pipette;

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
    public static float Tolerance { get; set; } = .0001f;

    public static CompareInUnits Units { get; set; } = CompareInUnits.LeftHandSide;

}