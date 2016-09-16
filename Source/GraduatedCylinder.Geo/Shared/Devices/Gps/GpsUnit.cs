using System;
using System.Collections.Generic;
using System.Linq;
using GraduatedCylinder.Devices.Gps.Nmea;
using GraduatedCylinder.Geo;
using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Gps
{
    public class GpsUnit : IProvideGeoPosition,
                           IProvideTrajectory,
                           IProvideTime,
                           IProvideSatelliteInfo,
                           IDisposable
    {
        private static readonly Speed MinimumSpeedForHeadingUpdate = new Speed(.03, SpeedUnit.NauticalMilesPerHour);
        private readonly List<int> _activeSatellitePrns = new List<int>();
        private readonly IProvideSentences _nmeaProvider;
        private readonly GpsParser _parser = new GpsParser();
        private readonly Dictionary<int, SatelliteInfo> _satellites = new Dictionary<int, SatelliteInfo>();
        private double _horizontalDop;
        private double _positionDop;
        private double _verticalDop;

        public GpsUnit(IProvideSentences nmeaProvider) {
            MinimumFixForNotification = GpsFixType.ThreeD;
            CurrentLocation = new GeoPosition(0, 0, new Length(0, LengthUnit.Meter));
            CurrentHeading = Heading.Unknown;

            _nmeaProvider = nmeaProvider;
            _nmeaProvider.SentenceReceived += sentence => {
                                                  Message message = _parser.Parse(sentence);
                                                  if (message == null) {
                                                      return;
                                                  }
                                                  //NB set all values then raise all notifications
                                                  if (message.Value is IProvideSatelliteInfo) {
                                                      foreach (SatelliteInfo satellite in message.ValueAs<IProvideSatelliteInfo>()
                                                                                                 .Satellites) {
                                                          _satellites[satellite.Prn] = satellite;
                                                      }
                                                  }
                                                  if (message.Value is IProvideActiveSatellites) {
                                                      _activeSatellitePrns.Clear();
                                                      foreach (int prn in message.ValueAs<IProvideActiveSatellites>()
                                                                                 .ActiveSatellitePrns.Where(prn => prn != 0)) {
                                                          _activeSatellitePrns.Add(prn);
                                                      }
                                                  }
                                                  if (message.Value is IProvideFixType) {
                                                      CurentFixType = message.ValueAs<IProvideFixType>()
                                                                             .CurrentFix;
                                                  }
                                                  if (message.Value is IProvideDilutionOfPrecision) {
                                                      var dop = message.ValueAs<IProvideDilutionOfPrecision>();
                                                      _positionDop = dop.PositionDop;
                                                      _horizontalDop = dop.HorizontalDop;
                                                      _verticalDop = dop.VerticalDop;
                                                  }
                                                  if (message.Value is IProvideTime) {
                                                      CurrentTime = message.ValueAs<IProvideTime>()
                                                                           .CurrentTime;
                                                  }
                                                  if (message.Value is IProvideTrajectory) {
                                                      //NB heading and speed are correlated
                                                      IProvideTrajectory trajectory = message.ValueAs<IProvideTrajectory>();
                                                      CurrentSpeed = trajectory.CurrentSpeed;
                                                      // NB don't update heading when speed is near zero
                                                      if (CurrentSpeed > MinimumSpeedForHeadingUpdate) {
                                                          CurrentHeading = trajectory.CurrentHeading;
                                                      }
                                                  }
                                                  if (message.Value is IProvideGeoPosition) {
                                                      var newLocation = message.ValueAs<IProvideGeoPosition>()
                                                                               .CurrentLocation;
                                                      CurrentLocation = newLocation.Altitude == null
                                                                            ? new GeoPosition(newLocation.Latitude,
                                                                                              newLocation.Longitude,
                                                                                              CurrentLocation.Altitude)
                                                                            : newLocation;
                                                      RaiseLocationChanged();
                                                  }
                                              };

            _nmeaProvider.Open();
        }

        public GpsFixType CurentFixType { get; private set; }

        public Heading CurrentHeading { get; private set; }

        public GeoPosition CurrentLocation { get; private set; }

        public Speed CurrentSpeed { get; private set; }

        public DateTime CurrentTime { get; private set; }

        public double HorizontalDop {
            get { return _horizontalDop; }
        }

        public bool IsConnected {
            get { return _nmeaProvider != null && _nmeaProvider.IsOpen; }
        }

        public GpsFixType MinimumFixForNotification { get; set; }

        public double PositionDop {
            get { return _positionDop; }
        }

        public IEnumerable<SatelliteInfo> Satellites {
            get {
                foreach (int prn in _activeSatellitePrns) {
                    yield return _satellites[prn];
                }
            }
        }

        public double VerticalDop {
            get { return _verticalDop; }
        }

        public event Action<LocationChangedEventArgs> LocationChanged;

        void IDisposable.Dispose() {
            LocationChanged = null;
            _nmeaProvider.Close();
        }

        private void RaiseLocationChanged() {
            if (CurentFixType < MinimumFixForNotification) {
                return;
            }
            var handler = LocationChanged;
            if (handler != null) {
                var args = new LocationChangedEventArgs(CurrentLocation, CurrentHeading);
                handler(args);
            }
        }
    }
}