using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using DigitalHammer.Testing;
using GraduatedCylinder.Nmea;
using Xunit;

namespace GraduatedCylinder.Devices.Gps
{
    public class GpsSpec
    {
        [Fact]
        public void LiveGpsOnCOM4() {
            string fileName = @"C:\Gps\Test.glog";
            if (File.Exists(fileName)) {
                File.Delete(fileName);
            }
            IProvideSentences sentences = new NmeaSerialPort("COM4");
            sentences = new SentenceLogger(sentences, fileName);
            GpsUnit gps = new GpsUnit(sentences);
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
            for (int i = 0; i < 100; i++) {
                Thread.Sleep(100);
            }
            gps.IsEnabled = false;
            if (!File.Exists(fileName)) {
                throw new FileNotFoundException("Expected test to create a log file.", fileName);
            }
        }

        [Fact]
        public void RecordedGpsFromLog() {
            int eventCount = 0;
            string fileName = @".\NMEA\Sample1.glog";
            SentenceLog sentences = new SentenceLog(fileName, SentenceLog.PlaybackRate.AsFastAsPossible);
            GpsUnit gps = new GpsUnit(sentences);
            gps.LocationChanged += _ => eventCount++;
            sentences.Open();
            while (!sentences.PlaybackComplete) {
                Thread.Sleep(100);
            }
            sentences.Close();
            eventCount.ShouldBe(18);
        }

        [Fact]
        public void TranslateLog() {
            string input = @".\NMEA\Sample1.glog";
            string output = @"C:\Gps\Sample1.clean.glog";
            SentenceLog source = new SentenceLog(input, SentenceLog.PlaybackRate.AsRecorded);
            SentenceLogger logger = new SentenceLogger(source, output);
            source.Open();
            while (!source.PlaybackComplete) {
                Thread.Sleep(100);
            }
            source.Close();
        }
    }
}