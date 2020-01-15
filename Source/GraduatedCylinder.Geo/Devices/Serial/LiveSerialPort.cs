using System.IO.Ports;
using System.Text;

namespace GraduatedCylinder.Devices.Serial
{
    public class LiveSerialPort : ISerialPort
    {
        private readonly SerialPort _port;

        public LiveSerialPort(string portName = "COM1",
                              int baudRate = 4800,
                              Parity parity = Parity.None,
                              int dataBits = 8,
                              StopBits stopBits = StopBits.One) {
            _port = new SerialPort(portName, baudRate, parity, dataBits, stopBits) {
                Handshake = Handshake.None,
                Encoding = Encoding.ASCII
            };
        }

        public int BytesToRead => _port.BytesToRead;

        public bool IsOpen => _port.IsOpen;

        public event SerialDataReceivedEventHandler DataReceived {
            add => _port.DataReceived += value;
            remove => _port.DataReceived -= value;
        }

        public event SerialErrorReceivedEventHandler ErrorReceived {
            add => _port.ErrorReceived += value;
            remove => _port.ErrorReceived -= value;
        }

        public void Close() {
            _port.Close();
        }

        public void Open() {
            _port.Open();
        }

        public int Read(byte[] buffer, int offset, int count) {
            return _port.Read(buffer, offset, count);
        }

        public void Write(string text) {
            _port.Write(text);
        }
    }
}