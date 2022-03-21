namespace GraduatedCylinder.Geo.Gps;

public class SatelliteInfo
{

    public SatelliteInfo(int prn, int elevation, int azimuth, double signalToNoise) {
        Prn = prn;
        Elevation = elevation;
        Azimuth = azimuth;
        SignalToNoise = signalToNoise;
    }

    public int Azimuth { get; private set; }

    public int Elevation { get; private set; }

    public int Prn { get; private set; }

    public double SignalToNoise { get; private set; }

}