namespace GraduatedCylinder.Devices.Laser
{
    public class DeviceInfo
    {

        public DeviceInfo(string model, string version, string date = null) {
            Model = model;
            Version = version;
            Date = date;
        }

        public string Date { get; private set; }

        public string Model { get; private set; }

        public string Version { get; private set; }

    }
}