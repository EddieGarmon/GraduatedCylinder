using System.IO.Ports;

namespace Nmea.Core0183
{
    public interface ISerialPort
    {

        int BytesToRead { get; }

        bool IsOpen { get; }

        event SerialDataReceivedEventHandler DataReceived;

        event SerialErrorReceivedEventHandler ErrorReceived;

        void Close();

        void Open();

        int Read(byte[] buffer, int offset, int count);

        void Write(string text);

    }
}