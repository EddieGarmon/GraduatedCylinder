using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduatedCylinder.Devices.Gps.Nmea;
using GraduatedCylinder.Nmea;
using Xunit;
using XunitShould;

namespace GraduatedCylinder.Devices.Gps
{
    public class GPRMCSpec
    {
        [Theory]
        [InlineData("$GPRMC,145710.00,A,3605.08678,N,07958.72572,W,0.037,,180716,,,D*6B", 13)]
        [InlineData("$GPRMC,145930.00,A,3605.06933,N,07958.57358,W,38.579,94.11,180716,,,A*72", 13)]
        [InlineData("$GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A", 12)]
        public void Parsing13Parts(string nmea, int expectedParts) {
            GpsParser parser = new GpsParser();
            Sentence sentence = Sentence.Parse(nmea);
            sentence.Id.ShouldEqual("$GPRMC");
            sentence.Parts.Length.ShouldEqual(expectedParts);
            Message message = parser.Parse(sentence);
            message.Sentence.ShouldEqual(sentence);
        }

    }
}
