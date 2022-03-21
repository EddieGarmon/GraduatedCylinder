using System.Text.Json;
using GraduatedCylinder;
using GraduatedCylinder.Json;

namespace Sample.JsonUsage;

class Program
{

    static void Main(string[] args) {
        JsonSerializerOptions options = new() {
            WriteIndented = true,
            Converters = {
                new LengthJsonConverter { Units = LengthUnit.Foot, Precision = 4 },
                new AreaJsonConverter { Units = AreaUnit.SquareInch, Precision = 3 },
                new VolumeJsonConverter { Units = VolumeUnit.CubicCentimeters, Precision = 2 }
            }
        };

        Cube cube = new Cube(new Length(3.0, LengthUnit.Foot), new Length(0.5, LengthUnit.Meter), new Length(12.0, LengthUnit.Inch));
        string json = JsonSerializer.Serialize(cube, options);

        Console.WriteLine(json);
        Console.ReadLine();
    }

}