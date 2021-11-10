using DigitalHammer.Testing;
using Xunit;

namespace Nmea.Core0183;

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

    [Fact]
    public void SplitNewlineAcrossTwoReceiveEvents() {
        int counter = 0;
        EmulatedSerialPort port = new EmulatedSerialPort();
        NmeaSerialPort nmea = new NmeaSerialPort(port);
        nmea.SentenceReceived += sentence => { counter++; };
        nmea.Open();
        port.QueueData("$sent1\r".ToCharArray());
        counter.ShouldBe(0);
        port.BytesToRead.ShouldBe(0);
        nmea.BufferCount.ShouldBe(7);
        port.QueueData("\n$sent2\r\n".ToCharArray());
        counter.ShouldBe(2);
        port.BytesToRead.ShouldBe(0);
        nmea.BufferCount.ShouldBe(0);
        nmea.Close();
    }

    [Fact]
    public void StartMidSentence() {
        int counter = 0;
        EmulatedSerialPort port = new EmulatedSerialPort();
        NmeaSerialPort nmea = new NmeaSerialPort(port);
        nmea.SentenceReceived += sentence => { counter++; };
        nmea.Open();
        port.QueueData("nt1\r\n$sent2\r\n".ToCharArray());
        counter.ShouldBe(1);
        port.BytesToRead.ShouldBe(0);
        nmea.BufferCount.ShouldBe(0);
        nmea.Close();
    }
}