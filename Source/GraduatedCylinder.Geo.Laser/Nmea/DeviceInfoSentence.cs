using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Laser.Nmea;

public static class DeviceInfoSentence
{

    // DeviceInfoRequest - "$PLTIT,RQ,ID\r\n"
    // DeviceInfoResponse - "$PLTIT,ID,{model},{version}*{check}\r\n"
    // $ID,{model},{version},{date}*{check}\r\n

    public static DeviceInfo? Parse(Sentence sentence) {
        if (sentence[0] == "$PLTIT" && sentence[1] == "ID") {
            return new DeviceInfo(sentence[2], sentence[3]);
        }
        if (sentence[0] == "$ID") {
            return new DeviceInfo(sentence[1], sentence[2], sentence[3]);
        }
        return null;
    }

}