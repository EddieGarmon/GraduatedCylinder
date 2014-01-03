using System;
using Caliburn.Micro;
using GraduatedCylinder;
using GraduatedCylinder.Devices.Gps;
using GraduatedCylinder.Geo;
using GraduatedCylinder.Nmea;

namespace GeoDemo
{
    public class ShellViewModel : PropertyChangedBase,
                                  IShell,
                                  IDisposable
    {
        private GpsUnit _gps;
        private string _nmeaLog;

        public string NmeaLog {
            get { return _nmeaLog; }
            set {
                if (value == _nmeaLog) {
                    return;
                }
                _nmeaLog = value;
                NotifyOfPropertyChange(() => NmeaLog);
            }
        }

        public void CloseDevice() {
            if (_gps == null) {
                return;
            }
            _gps.LocationChanged -= OnLocationChanged;
            ((IDisposable)_gps).Dispose();
            _gps = null;
        }

        public void OpenDevice() {
            if (_gps != null) {
                return;
            }
            _gps = new GpsUnit(new NmeaSerialPort("COM2", 19200));
            _gps.LocationChanged += OnLocationChanged;
        }

        void IDisposable.Dispose() {
            CloseDevice();
        }

        private void OnLocationChanged(GeoPosition position) {
            NmeaLog = string.Format("Lat: {1}{0}Long: {2}{0}Alt: {3}{0}Fix: {4}{0}Heading: {5}{0}Speed: {6}{0}Time: {7}{0}",
                                    Environment.NewLine,
                                    _gps.CurrentLocation.Latitude,
                                    _gps.CurrentLocation.Longitude,
                                    _gps.CurrentLocation.Altitude,
                                    _gps.CurentFixType,
                                    _gps.CurrentHeading,
                                    _gps.CurrentSpeed.ToString(SpeedUnit.MilesPerHour, 2),
                                    _gps.CurrentTime);
        }
    }
}