using DigitalHammer.Testing;
using GraduatedCylinder.Devices.Serial;
using GraduatedCylinder.Nmea;
using Xunit;

namespace GraduatedCylinder.Geo
{
    public class NmeaSerialPortSpec
    {
        [Fact]
        public void EmptyLinesInBuffer() {
            int counter = 0;
            EmulatedSerialPort port = new EmulatedSerialPort();
            NmeaSerialPort nmea = new NmeaSerialPort(port);
            nmea.SentenceReceived += sentence => { counter++; };
            nmea.Open();
            port.QueueData("$sent1\r\n\r\n$sent2\r\n".ToCharArray());
            counter.ShouldBe(2);
            port.BytesToRead.ShouldBe(0);
            nmea.BufferCount.ShouldBe(0);
            nmea.Close();
        }

        [Fact]
        public void MultipleSentencesInBuffer() {
            int counter = 0;
            EmulatedSerialPort port = new EmulatedSerialPort();
            NmeaSerialPort nmea = new NmeaSerialPort(port);
            nmea.SentenceReceived += sentence => { counter++; };
            nmea.Open();
            port.QueueData("$sent1\r\n$sent2\r\n".ToCharArray());
            counter.ShouldBe(2);
            port.BytesToRead.ShouldBe(0);
            nmea.BufferCount.ShouldBe(0);
            nmea.Close();
        }

        [Fact]
        public void PartialSentenceInBuffer() {
            int counter = 0;
            EmulatedSerialPort port = new EmulatedSerialPort();
            NmeaSerialPort nmea = new NmeaSerialPort(port);
            nmea.SentenceReceived += sentence => { counter++; };
            nmea.Open();
            port.QueueData("$sent1\r\n$sent2\r\n$sent3".ToCharArray());
            counter.ShouldBe(2);
            port.BytesToRead.ShouldBe(0);
            nmea.BufferCount.ShouldBe(6);
            nmea.Close();
        }
    }
}