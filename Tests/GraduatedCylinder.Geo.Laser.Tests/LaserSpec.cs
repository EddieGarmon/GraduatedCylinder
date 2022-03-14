//using System;
//using System.Collections.Generic;
//using System.Threading;
//using Xunit;

//namespace TruPulse
//{
//    public class LaserSpec
//    {
//        public LaserSpec() {
//            LogManager.CreateLog = type => new DebugLog(type);
//        }

//        [Fact(Timeout = 1000)]
//        public void ChangeMeasurementModes() {
//            Laser laser = new Laser();
//            laser.Connect();
//            laser.MeasurementMode = MeasurementMode.Azimuth;
//            laser.MeasurementMode = MeasurementMode.Height;
//            laser.MeasurementMode = MeasurementMode.HorizontalDistance;
//            laser.MeasurementMode = MeasurementMode.Inclination;
//            laser.MeasurementMode = MeasurementMode.MissingLine;
//            laser.MeasurementMode = MeasurementMode.SlopeDistance;
//            laser.MeasurementMode = MeasurementMode.VerticalDistance;
//        }

//        [Fact(Timeout = 1000)]
//        public void ChangeTargetModes() {
//            Laser laser = new Laser();
//            laser.Connect();
//            Console.WriteLine(laser.TargetMode);
//            laser.TargetMode = TargetMode.Closest;
//            laser.TargetMode = TargetMode.Continuous;
//            //laser.TargetMode = TargetMode.Farthest; // this causes a reader loop issue
//            laser.TargetMode = TargetMode.Filter;
//            laser.TargetMode = TargetMode.Normal;
//        }

//        [Fact(Timeout = 1000)]
//        public void ConnectAndReconnect() {
//            Laser laser = new Laser();
//            List<Message> messages = new List<Message>();
//            laser.Messages.Subscribe(messages.Add);
//            laser.Connect();
//            Thread.Sleep(500);
//            messages.Count.ShouldEqual(1);
//            laser.Disconnect();
//            Thread.Sleep(500);
//            messages.Count.ShouldEqual(1);
//            laser.Connect();
//            Thread.Sleep(500);
//            messages.Count.ShouldEqual(2);
//        }

//        [Fact(Timeout = 1000)]
//        public void GetBatteryVoltage() {
//            Laser laser = new Laser();
//            Voltage battery = laser.GetBatteryVoltage();
//            Voltage zeroVolts = new Voltage(0, VoltageUnit.MilliVolts);
//            battery.ShouldEqual(zeroVolts);
//            laser.Connect();
//            battery = laser.GetBatteryVoltage();
//            battery.ShouldBeGreaterThan(zeroVolts);
//        }

//        [Fact(Timeout = 1000)]
//        public void ListenToObservable() {
//            Laser laser = new Laser();
//            List<Message> log = new List<Message>();
//            IDisposable subscription = laser.Messages.Subscribe(log.Add);
//            laser.Connect();
//            //log.Count.ShouldEqual(1);

//            GeoVector vector = laser.CaptureVector();
//            log.Count.ShouldEqual(2);
//        }

//        [Fact(Timeout = 1000)]
//        public void SendRandomCommands() {
//            Laser laser = new Laser();
//            laser.Connect();
//            //laser.SendCommand("$BV\r\n");
//            laser.TurnOff();
//        }

//        [Fact(Timeout = 1000)]
//        public void SetupDeclination() {
//            //lookup
//            // http://www.ngdc.noaa.gov/geomagmodels/Declination.jsp
//            // latitude
//            // longitude
//            // year / month / day
//            // -8° 6' 40" changing by  -3.2' per year 
//        }

//        [Fact(Timeout = 1000)]
//        public void TestFire() {
//            //RangeFinder?
//            Laser laser = new Laser();
//            laser.Connect();
//            GeoVector vector = laser.CaptureVector();
//            //var height = laser.CaptureHeight();
//            //GeoVectorMessage[] triangle = laser.CaptureMissingLine();
//        }
//    }
//}

