using System;
using System.Diagnostics;
using System.Threading;
using GraduatedCylinder.Nmea;
using Xunit;

namespace GraduatedCylinder.Devices.Gps
{
    public class GpsSpec
    {
        [Fact]
        public void LiveGpsOnCOM4() {
            GpsUnit gps = new GpsUnit(new NmeaSerialPort("COM4", 9600));
            gps.LocationChanged += args => {
                                       Trace.TraceInformation("Recieved: {0:u}: Message Timestamp: {1:u}",
                                                         DateTime.Now,
                                                         args.Time);
                                       Trace.TraceInformation("    Lat: {0} Long: {1} Alt: {2}",
                                                         args.Position.Latitude,
                                                         args.Position.Longitude,
                                                         args.Position.Altitude.ToString(LengthUnit.Foot, 1));
                                       Trace.TraceInformation("    Heading: {0} at Speed: {1}",
                                                         args.Heading,
                                                         args.Speed.ToString(SpeedUnit.MilesPerHour, 2));
                                       Trace.TraceInformation("");
                                   };
            gps.IsEnabled = true;
            Thread.Sleep(8000);
        }
    }
}