using System;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace GraduatedCylinder.Nmea
{
    public sealed class NmeaSerialPort : IProvideSentences, IDisposable
    {
        private readonly char[] _buffer = new char[262144];
        private readonly SerialPort _serialPort;
        private int _bufferHead;
        private int _bufferTail;

        public NmeaSerialPort(string portName = "COM1", int baudRate = 4800, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One) {
            string[] portNames = SerialPort.GetPortNames();
            if (!portNames.Contains(portName)) {
                //throw new Exception("Bad Port: " + portName);
                //todo: handle extra null terminators in name
            }
            _serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits) {
                Handshake = Handshake.None,
                Encoding = Encoding.ASCII
            };
            _serialPort.ErrorReceived += ProcessError;
            _serialPort.DataReceived += ProcessData;
        }

        public bool IsOpen {
            get { return _serialPort.IsOpen; }
        }

        public event Action<SerialError> PortError;

        public event Action<Sentence> SentenceReceived;

        public void Close() {
            if (_serialPort.IsOpen) {
                _serialPort.Close();
            }
        }

        public void Open() {
            if (!_serialPort.IsOpen) {
                _serialPort.Open();
            }
        }

        public void SendData(string message) {
            _serialPort.Write(message);
        }

        private void AppendToBuffer(char[] data) {
            if (_buffer.Length - _bufferTail < data.Length) {
                CompactBuffer();
            }
            for (int i = 0; i < data.Length; i++) {
                _buffer[_bufferTail++] = data[i];
            }
        }

        private void CompactBuffer() {
            int length = _bufferTail - _bufferHead;
            for (int i = 0; i < length; i++) {
                _buffer[i] = _buffer[i + _bufferHead];
            }
            _bufferHead = 0;
            _bufferTail = length;
        }

        void IDisposable.Dispose() {
            if (_serialPort.IsOpen) {
                _serialPort.Close();
            }
            PortError = null;
            SentenceReceived = null;
        }

        private string GetNextBufferedSentence() {
            for (int i = _bufferHead; i < _bufferTail; i++) {
                if ((_buffer[i] == '\r') && (_buffer[i + 1] == '\n')) {
                    string result = new string(_buffer, _bufferHead, i - _bufferHead);
                    _bufferHead = i + 2;
                    return result;
                }
            }
            return null;
        }

        private void ProcessData(object sender, SerialDataReceivedEventArgs e) {
            //buffer incomming data
            int bytesToRead = _serialPort.BytesToRead;
            byte[] bytes = new byte[bytesToRead];
            _serialPort.Read(bytes, 0, bytesToRead);
            AppendToBuffer(Encoding.ASCII.GetChars(bytes));

            //process all complete sentences available
            string possibleSentence = GetNextBufferedSentence();
            while (possibleSentence != null) {
                var sentence = Sentence.Parse(possibleSentence);
                if (sentence != null) {
                    PublishSentence(sentence);
                }
                possibleSentence = GetNextBufferedSentence();
            }
        }

        private void ProcessError(object sender, SerialErrorReceivedEventArgs e) {
            var handler = PortError;
            if (handler != null) {
                handler(e.EventType);
            }
        }

        private void PublishSentence(Sentence sentence) {
            var handler = SentenceReceived;
            if (handler != null) {
                handler(sentence);
            }
        }
    }
}