using System.Runtime.CompilerServices;

namespace GraduatedCylinder;

public static class Initializer
{

    [ModuleInitializer]
    public static void Run() {
        UnitPreferences.Default.Precision = 15;
    }

}