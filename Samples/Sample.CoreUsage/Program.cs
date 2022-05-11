using GraduatedCylinder;
using GraduatedCylinder.Calculators;
using GraduatedCylinder.Extensions;

namespace Sample.CoreUsage;

internal class Program
{

    private static void Main(string[] args) {
        ComputeStop(new Mass(2500, MassUnit.Pounds),
                    new Speed(72, SpeedUnit.MilesPerHour),
                    new Length(321, LengthUnit.Foot),
                    new Speed(0, SpeedUnit.MilesPerHour));

        ComputeStop(2000.Pounds(), 65.43.MilesPerHour(), 234.5.Feet(), 0.MilesPerHour());
    }

    private static void ComputeStop(Mass vehicleMass, Speed startSpeed, Length stoppingDistance, Speed endSpeed) {
        Console.WriteLine($"To stop a vehicle of {vehicleMass} moving at {startSpeed} within {stoppingDistance},");

        Momentum momentum = vehicleMass * startSpeed;
        Console.WriteLine($"(computing the momentum to be {momentum.In(MomentumUnit.PoundsMilesPerHour)})");

        Acceleration deceleration = MotionCalculator.ComputeConstantAcceleration(startSpeed, endSpeed, stoppingDistance);
        Console.WriteLine($"(computing the constant deceleration to be {deceleration.In(AccelerationUnit.MilePerHourPerSecond)}");

        Force constantStoppingForce = vehicleMass * deceleration;
        Console.WriteLine("the force required is:");
        Console.WriteLine($"\t{constantStoppingForce}");
        Console.WriteLine($"\t{constantStoppingForce.ToString(ForceUnit.Newtons, 3)}");
        Console.WriteLine($"\t{constantStoppingForce.ToString(ForceUnit.KiloGramForce)}");
        Console.WriteLine($"\t{constantStoppingForce.ToString(ForceUnit.PoundForce, 5)}");

        Time time = momentum / constantStoppingForce;
        Console.WriteLine("and the time to stop is:");
        Console.WriteLine($"\t{time}");
        Console.WriteLine();
        Console.WriteLine();

        Console.ReadLine();
    }

}