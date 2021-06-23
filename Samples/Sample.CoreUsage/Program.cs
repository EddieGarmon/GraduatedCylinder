using System;
using GraduatedCylinder;

namespace Sample.CoreUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            Mass vehicleMass = new Mass(2500, MassUnit.Pounds);
            Speed startSpeed = new Speed(72, SpeedUnit.MilesPerHour);
            Speed endSpeed = new Speed(0, SpeedUnit.MilesPerHour);
            Length stoppingDistance = new Length(1234, LengthUnit.Foot);
            Acceleration deceleration = ((endSpeed * endSpeed) - (startSpeed * startSpeed)) / (2 * stoppingDistance);
            Force stoppingForceRequired = vehicleMass * deceleration;

            Console.WriteLine($"To stop a vehicle of {vehicleMass} moving at {startSpeed} within {stoppingDistance},");
            Console.WriteLine("the force required is:");
            Console.WriteLine($"\t{stoppingForceRequired}");
            Console.WriteLine($"\t{stoppingForceRequired.ToString(ForceUnit.Newtons, 3)}");
            Console.WriteLine($"\t{stoppingForceRequired.ToString(ForceUnit.KilogramForce, 3)}");
            Console.WriteLine($"\t{stoppingForceRequired.ToString(ForceUnit.PoundForce, 3)}");
            Console.ReadLine();
        }
    }
}
