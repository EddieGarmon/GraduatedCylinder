namespace GraduatedCylinder.Geo.Gps;

public class SatelliteInfo
{

    public SatelliteInfo(int prn, int elevation, int azimuth, double signalToNoise) {
        Prn = prn;
        Elevation = elevation;
        Azimuth = azimuth;
        SignalToNoise = signalToNoise;
    }

    public int Azimuth { get; }

    public int Elevation { get; }

    public int Prn { get; }

    public double SignalToNoise { get; }

}