using System;
using GraduatedCylinder;
using GraduatedCylinder.Calculators;

namespace Sample.CoreUsage;

class Program
{

    static void Main(string[] args) {
        Mass vehicleMass = new Mass(2500, MassUnit.Pounds);
        Speed startSpeed = new Speed(72, SpeedUnit.MilesPerHour);
        Speed endSpeed = new Speed(0, SpeedUnit.MilesPerHour);
        Length stoppingDistance = new Length(1234, LengthUnit.Foot);
        Acceleration deceleration = MotionCalculator.ComputeConstantAcceleration(startSpeed, endSpeed, stoppingDistance);
        Force constantStoppingForce = vehicleMass * deceleration;

        Console.WriteLine($"To stop a vehicle of {vehicleMass} moving at {startSpeed} within {stoppingDistance},");
        Console.WriteLine("the force required is:");
        Console.WriteLine($"\t{constantStoppingForce}");
        Console.WriteLine($"\t{constantStoppingForce.ToString(ForceUnit.Newtons, 3)}");
        Console.WriteLine($"\t{constantStoppingForce.ToString(ForceUnit.KilogramForce)}");
        Console.WriteLine($"\t{constantStoppingForce.ToString(ForceUnit.PoundForce, 5)}");
        Console.ReadLine();
    }

}