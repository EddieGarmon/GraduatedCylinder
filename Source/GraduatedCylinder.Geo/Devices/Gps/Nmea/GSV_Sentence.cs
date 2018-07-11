using System.Collections.Generic;
using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    public class GSV_Sentence
    {
        private static readonly List<string> ValidIds = new List<string> {
            "$GPGSV",
            "$GLGSV",
            "$BDGSV"
        };

        public static Decoded Parse(Sentence sentence) {
            // $__GSV,<1>,<2>,<3>,<4>,<5>,<6>,<7>, ... ,<4>,<5>,<6>,<7>*<CS><CR><LF>
            // 0) Sentence Id
            // 1) Total number of GSV sentences to be transmitted, 1-3.
            // 2) Sequence number of message, 1-3.
            // 3) Total number of satellites in view, 00 to 12.
            // 4) Satellite PRN number, 01 to 32.
            // 5) Satellite elevation, 00 to 90 degrees.
            // 6) Satellite azimuth, 000 to 359 degrees, true.
            // 7) Signal to noise ration in dBHZ (0-99), null when not tracking.
            // *<CS>) Checksum.
            // <CR><LF>) Sentence terminator
            //
            // NOTE: Items <4>,<5>,<6> and <7> repeat for each satellite in view to a maximum 
            // of four (4) satellites per sentence.  Additional satellites in view information 
            // must be sent in subsequent sentences. These fields will be null if unused.

            if (!ValidIds.Contains(sentence.Id)) {
                return null;
            }
            if (sentence.Parts.Length != 20) {
                return null;
            }

            int sequenceCount, sequenceId, numberOfSatellites;
            int.TryParse(sentence.Parts[1], out sequenceCount);
            int.TryParse(sentence.Parts[2], out sequenceId);
            int.TryParse(sentence.Parts[3], out numberOfSatellites);

            SatelliteInfo[] satelliteInfos = new SatelliteInfo[4];
            for (int i = 0; i < 4; i++) {
                int prn, elevation, azimuth;
                double signalToNoise;
                int.TryParse(sentence.Parts[4 * i + 4], out prn);
                int.TryParse(sentence.Parts[4 * i + 5], out elevation);
                int.TryParse(sentence.Parts[4 * i + 6], out azimuth);
                double.TryParse(sentence.Parts[4 * i + 7], out signalToNoise);

                //todo use sequence id for start offset
                satelliteInfos[i] = new SatelliteInfo(prn, elevation, azimuth, signalToNoise);
            }
            return new Decoded(satelliteInfos);
        }

        public class Decoded : IProvideSatelliteInfo
        {
            public Decoded(IEnumerable<SatelliteInfo> satellites) {
                Satellites = satellites;
            }

            public IEnumerable<SatelliteInfo> Satellites { get; private set; }
        }
    }
}