using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Laser.Nmea
{
    public static class DeviceInfoSentence
    {
        // DeviceInfoRequest - "$PLTIT,RQ,ID\r\n"
        // DeviceInfoResponse - "$PLTIT,ID,{model},{version}*{check}\r\n"
        // $ID,{model},{version},{date}*{check}\r\n

        public static DeviceInfo Parse(Sentence sentence) {
            if (sentence.Parts[0] == "$PLTIT" && sentence.Parts[1] == "ID") {
                return new DeviceInfo(sentence.Parts[2], sentence.Parts[3]);
            }
            if (sentence.Parts[0] == "$ID") {
                return new DeviceInfo(sentence.Parts[1], sentence.Parts[2], sentence.Parts[3]);
            }
            return null;
        }
    }
}