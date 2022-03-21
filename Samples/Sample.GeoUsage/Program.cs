using System;
using GraduatedCylinder;
using GraduatedCylinder.Geo;

namespace Sample.GeoUsage
{
    class Program
    {

        static void Main(string[] args) {
            Latitude latitude = new Latitude(36.1234);
            Longitude longitude = new Longitude(58.1234);
            Length altitude = new Length(1234.56, LengthUnit.Meter);
            GeoPosition position = new GeoPosition(latitude, longitude, altitude);
            Console.WriteLine($"Hello from: {position}!");
        }

    }
}