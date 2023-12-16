using System.Runtime.CompilerServices;

namespace Pipette;

public static class Initializer
{

    [ModuleInitializer]
    public static void Run() {
        UnitPreferences.Default.Precision = 15;
    }

}