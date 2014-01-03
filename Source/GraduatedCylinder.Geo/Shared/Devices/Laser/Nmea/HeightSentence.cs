using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Laser.Nmea
{
    public static class HeightSentence
    {
        // "$PLTIT,HT,{htValue},{htUnits: F,Y,M},*{check}"

        public static Length Parse(Sentence sentence) {
            if (sentence.Parts[0] != "$PLTIT") {
                return null;
            }
            if (sentence.Parts[1] != "HT") {
                return null;
            }
            // todo high-res check
            Length height = new Length(double.Parse(sentence.Parts[2]), LengthUnit.Foot);
            return height;
        }
    }
}