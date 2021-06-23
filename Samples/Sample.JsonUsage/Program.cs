using System;
using System.Text.Json;
using GraduatedCylinder;
using GraduatedCylinder.Json;

namespace Sample.JsonUsage
{
    class Program
    {

        static void Main(string[] args) {
            JsonSerializerOptions options = new() {
                WriteIndented = true,
                Converters = { new LengthConverter() { Units = LengthUnit.Foot, Precision = 4 } }
            };

            Cube cube = new Cube(3.0.Feet(), 0.5.Meters(), 12.0.Inches());
            string json = JsonSerializer.Serialize(cube, options);

            Console.WriteLine(json);
            Console.ReadLine();
        }

    }
}