namespace GraduatedCylinder.Devices.Gps
{
    public enum DilutionOfPrecisionRating
    {

        Poor, // >20, discard measurements
        Fair, // 10-20, low confidence, generally discard
        Moderate, // 5-10, more open view of sky is recommended
        Good, // 2-5, minimum appropriate for making business decisions
        Excellent, // 1-2, accurate enough to meet all but the most sensitive applications
        Ideal // <1, highest possible precision

    }
}