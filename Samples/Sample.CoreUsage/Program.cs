using System;
using GraduatedCylinder;

namespace Sample.CoreUsage;

class Program
{

    private static Acceleration ComputeConstantAcceleration(Speed startSpeed, Speed endSpeed, Length distance) {
        startSpeed.Units = SpeedUnit.MeterPerSecond;
        endSpeed.Units = SpeedUnit.MeterPerSecond;
        distance.Units = LengthUnit.Meter;

        double value = ((endSpeed.Value * endSpeed.Value) - (startSpeed.Value * startSpeed.Value)) /
                       (2 * distance.Value);
        return new Acceleration(value, AccelerationUnit.MeterPerSquareSecond);
    }

    static void Main(string[] args) {
        Mass vehicleMass = new Mass(25000, MassUnit.Pounds);
        Speed startSpeed = new Speed(72, SpeedUnit.MilesPerHour);
        Speed endSpeed = new Speed(0, SpeedUnit.MilesPerHour);
        Length stoppingDistance = new Length(100, LengthUnit.Foot);
        Acceleration deceleration = ComputeConstantAcceleration(startSpeed, endSpeed, stoppingDistance);
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