using GraduatedCylinder.Geo.Gps.Nmea;
using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Gps;

public class GpsUnit : IProvideGeoPosition, IProvideTrajectory, IProvideTime, IProvideSatelliteInfo, IDisposable
{

    private readonly List<int> _activeSatellitePrns = new();
    private readonly IProvideSentences _nmeaProvider;
    private readonly GpsParser _parser = new();
    private readonly Dictionary<int, SatelliteInfo> _satellites = new();

    private bool _isEnabled;

    public GpsUnit(IProvideSentences nmeaProvider) {
        _nmeaProvider = nmeaProvider ?? throw new ArgumentNullException(nameof(nmeaProvider));

        MinimumFixForNotification = GpsFixType.ThreeD;
        MinimumSpeedForHeadingUpdate = new Speed(1, SpeedUnit.MilesPerHour);
        CurrentLocation = new GeoPosition(0, 0, new Length(0, LengthUnit.Meter));
        CurrentHeading = Heading.Unknown;

        _nmeaProvider.SentenceReceived += sentence => {
                                              Message? message = _parser.Parse(sentence);
                                              if (message == null) {
                                                  return;
                                              }
                                              //NB set all values then raise all notifications
                                              if (message.Value is IProvideSatelliteInfo info) {
                                                  foreach (SatelliteInfo satellite in info.Satellites) {
                                                      _satellites[satellite.Prn] = satellite;
                                                  }
                                              }
                                              if (message.Value is IProvideActiveSatellites active) {
                                                  _activeSatellitePrns.Clear();
                                                  foreach (int prn in active.ActiveSatellitePrns.Where(prn => prn != 0)) {
                                                      _activeSatellitePrns.Add(prn);
                                                  }
                                              }
                                              if (message.Value is IProvideFixType fixType) {
                                                  CurrentFixType = fixType.CurrentFix;
                                              }
                                              if (message.Value is IProvideDilutionOfPrecision dop) {
                                                  PositionDop = dop.PositionDop;
                                                  HorizontalDop = dop.HorizontalDop;
                                                  VerticalDop = dop.VerticalDop;
                                              }
                                              if (message.Value is IProvideTime time) {
                                                  CurrentTime = time.CurrentTime;
                                              }
                                              if (message.Value is IProvideTrajectory trajectory) {
                                                  //NB heading and speed are correlated
                                                  CurrentSpeed = trajectory.CurrentSpeed;
                                                  // NB don't update heading when speed is near zero
                                                  if (CurrentSpeed > MinimumSpeedForHeadingUpdate) {
                                                      CurrentHeading = trajectory.CurrentHeading;
                                                  }
                                              }
                                              if (message.Value is IProvideGeoPosition position) {
                                                  GeoPosition newLocation = position.CurrentLocation;
                                                  CurrentLocation =
                                                      newLocation.Altitude == Length.Unknown ?
                                                          new GeoPosition(newLocation.Latitude,
                                                                          newLocation.Longitude,
                                                                          CurrentLocation.Altitude) :
                                                          newLocation;
                                                  HasLocation = true;
                                                  RaiseLocationChanged();
                                              }
                                          };
    }

    public GpsFixType CurrentFixType { get; private set; }

    public Heading CurrentHeading { get; private set; }

    public GeoPosition CurrentLocation { get; private set; }

    public Speed CurrentSpeed { get; private set; }

    public DateTimeOffset CurrentTime { get; private set; }

    public bool HasLocation { get; private set; }

    public double HorizontalDop { get; private set; }

    public bool IsEnabled {
        get => _isEnabled;
        set {
            if (value == _isEnabled) {
                return;
            }
            if (value) {
                _nmeaProvider.Open();
            } else {
                _nmeaProvider.Close();
            }
            _isEnabled = value;
        }
    }

    public GpsFixType MinimumFixForNotification { get; set; }

    public Speed MinimumSpeedForHeadingUpdate { get; set; }

    public double PositionDop { get; private set; }

    public IEnumerable<SatelliteInfo> Satellites => _activeSatellitePrns.Select(prn => _satellites[prn]);

    public double VerticalDop { get; private set; }

    public event Action<LocationChangedEventArgs>? LocationChanged;

    void IDisposable.Dispose() {
        LocationChanged = null;
        _nmeaProvider.Close();
    }

    private void RaiseLocationChanged() {
        if (CurrentFixType < MinimumFixForNotification) {
            return;
        }
        Action<LocationChangedEventArgs>? handler = LocationChanged;
        if (handler == null) {
            return;
        }
        LocationChangedEventArgs args = new(CurrentTime, CurrentLocation, CurrentHeading, CurrentSpeed, CurrentFixType);
        handler(args);
    }

}