namespace GraduatedCylinder.Devices.Gps
{
    public interface IProvideActiveSatellites
    {

        int[] ActiveSatellitePrns { get; }

    }
}