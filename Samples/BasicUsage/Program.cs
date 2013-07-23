using System;
using GraduatedCylinder;

namespace BasicUsage
{
	internal class Program
	{
		private static void Main(string[] args) {
			Mass vehicleMass = new Mass(2500, MassUnit.Pounds);
			Speed startSpeed = new Speed(72, SpeedUnit.MilesPerHour);
			Speed endSpeed = new Speed(0, SpeedUnit.MilesPerHour);
			Length stoppingDistance = new Length(1234, LengthUnit.Feet);
			Acceleration deceleration = ((endSpeed * endSpeed) - (startSpeed * startSpeed)) / (2 * stoppingDistance);
			Force stoppingForceRequired = vehicleMass * deceleration;
			Console.WriteLine("The stopping force required is:");
			Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.Newtons));
			Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.KilogramForce));
			Console.WriteLine("\t{0}", stoppingForceRequired.ToString(ForceUnit.PoundForce));
			Console.ReadLine();
		}
	}
}