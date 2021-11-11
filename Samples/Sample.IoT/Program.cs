using System;
using GraduatedCylinder;
using GraduatedCylinder.Text;

//using System.Text.Json;
//using GraduatedCylinder.IoT.Json;

namespace Sample.IoT;

class Program
{

    static void Main(string[] args) {
        Length length = new Length(3.1415f, LengthUnit.Foot);
        Length width = new Length(1.23f, LengthUnit.Inch);
        Area area = length * width;

        Console.WriteLine($"Length: {length.ToString(LengthUnit.Inch)}");
        Console.WriteLine($"Width: {width.ToString(LengthUnit.Inch)}");
        Console.WriteLine($"Area: {area.ToString(AreaUnit.SquareInch, 3)}");

        //Console.WriteLine(
        //    $"Default: {JsonSerializer.Serialize(length)}, Custom: {JsonSerializer.Serialize(length, JsonHelper.Options)}");
        //Console.WriteLine();

        //JsonHelper.LengthJsonConverter.Units = LengthUnit.Inch;
        //Console.WriteLine(
        //    $"Default: {JsonSerializer.Serialize(length)}, Custom: {JsonSerializer.Serialize(length, JsonHelper.Options)}");
    }

}