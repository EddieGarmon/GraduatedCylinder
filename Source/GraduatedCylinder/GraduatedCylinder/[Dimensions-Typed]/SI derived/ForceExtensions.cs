namespace GraduatedCylinder
{
    public static class ForceExtensions
    {
        public static Force Newtons(this double value) {
            return new Force(value, ForceUnit.Newtons);
        }
    }
}