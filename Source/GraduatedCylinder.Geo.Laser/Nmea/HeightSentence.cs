using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Laser.Nmea;

public static class HeightSentence
{

    // "$PLTIT,HT,{htValue},{htUnits: F,Y,M},*{check}"

    public static object? Parse(Sentence sentence) {
        if (sentence[0] != "$PLTIT") {
            return null;
        }
        if (sentence[1] != "HT") {
            return null;
        }
        // todo high-res check
        Length height = new(double.Parse(sentence[2]), LengthUnit.Foot);
        return height;
    }

    public class Decoded
    {

        public Decoded(Length height) {
            Height = height;
        }

        public Length Height { get; }

    }

}