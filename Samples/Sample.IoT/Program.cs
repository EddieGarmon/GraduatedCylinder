using System;
using GraduatedCylinder;
using GraduatedCylinder.IoT.Text; //using System.Text.Json;
//using GraduatedCylinder.IoT.Json;

namespace Sample.IoT
{
    class Program
    {

        static void Main(string[] args) {
            Length length = new Length(3.1415f, LengthUnit.Foot);
            Length width = new Length(1.23f, LengthUnit.Inch);
            Area area = length * width;

            Console.WriteLine($"Length: {length.Print()}");
            Console.WriteLine($"Width: {width.Print()}");
            Console.WriteLine($"Area: {area.Print()} or {area.Print(AreaUnit.FootSquared, 3)}");

            //Console.WriteLine(
            //    $"Default: {JsonSerializer.Serialize(length)}, Custom: {JsonSerializer.Serialize(length, JsonHelper.Options)}");
            //Console.WriteLine();

            //JsonHelper.LengthJsonConverter.Units = LengthUnit.Inch;
            //Console.WriteLine(
            //    $"Default: {JsonSerializer.Serialize(length)}, Custom: {JsonSerializer.Serialize(length, JsonHelper.Options)}");
        }

    }
}