using System;

using GraduatedCylinder;

namespace BasicUsage
{
    internal class Program
    {
        private static void Main(string[] args) {
            var vehicleMass = new Mass(2500, MassUnit.Pounds);
            var startSpeed = new Speed(72, SpeedUnit.MilesPerHour);
            var endSpeed = new Speed(0, SpeedUnit.MilesPerHour);
            var stoppingDistance = new Length(1234, LengthUnit.Foot);
            Acceleration deceleration = ((endSpeed * endSpeed) - (startSpeed * startSpeed)) / (2 * stoppingDistance);
            Force stoppingForceRequired = vehicleMass * deceleration;

            Console.WriteLine("The stopping force required is:");
            Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.Newtons, 3));
            Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.KilogramForce, 3));
            Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.PoundForce, 3));
            Console.ReadLine();
        }
    }
}