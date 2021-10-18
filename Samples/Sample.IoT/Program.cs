using System;
using System.Text.Json;
using GraduatedCylinder;
using GraduatedCylinder.IoT.Json;
using GraduatedCylinder.IoT.Text;

namespace Sample.IoT
{
    class Program
    {

        static void Main(string[] args) {

            Length length = new Length(3.1415f, LengthUnit.Foot);

            Console.WriteLine($"Hello measurement: {length.Print()}");

            Console.WriteLine($"Default: {JsonSerializer.Serialize(length)}, Custom: {JsonSerializer.Serialize(length, JsonHelper.Options)}");
            Console.WriteLine();

            JsonHelper.LengthJsonConverter.Units = LengthUnit.Inch;
            Console.WriteLine($"Default: {JsonSerializer.Serialize(length)}, Custom: {JsonSerializer.Serialize(length, JsonHelper.Options)}");
        }

    }
}