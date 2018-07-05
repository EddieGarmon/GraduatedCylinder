namespace GraduatedCylinder
{
    public interface IDimension<in TUoM>
    {
        double In(TUoM units);

        string ToString(TUoM units);

        string ToString(TUoM units, int precision);
    }
}