using System.IO.Ports;
using System.Text;

namespace Nmea.Core0183;

public sealed class NmeaSerialPort : ITalkSentences, IDisposable
{

    private readonly char[] _buffer = new char[262144];
    private readonly ISerialPort _port;
    private int _bufferHead;
    private int _bufferTail;

    public NmeaSerialPort(string portName = "COM1",
                          int baudRate = 4800,
                          Parity parity = Parity.None,
                          int dataBits = 8,
                          StopBits stopBits = StopBits.One) {
        string[] portNames = SerialPort.GetPortNames();
        if (!portNames.Contains(portName)) {
            //throw new Exception("Bad Port: " + portName);
            //todo: handle extra null terminators in name
        }
        _port = new LiveSerialPort(portName, baudRate, parity, dataBits, stopBits);
        _port.ErrorReceived += ProcessError;
        _port.DataReceived += ProcessData;
    }

    public NmeaSerialPort(ISerialPort port) {
        _port = port;
        _port.ErrorReceived += ProcessError;
        _port.DataReceived += ProcessData;
    }

    public int BufferCount => _bufferTail - _bufferHead;

    public bool IsOpen => _port.IsOpen;

    public event Action<Exception, string>? ParseException;

    public event Action<SerialError>? PortError;

    public event Action<Sentence>? SentenceReceived;

    public void Close() {
        if (_port.IsOpen) {
            _port.Close();
        }
    }

    public void Open() {
        if (!_port.IsOpen) {
            _port.Open();
        }
    }

    public void Send(Sentence sentence) {
        _port.Write(sentence.ToString(includeChecksum: false));
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
        if (_port.IsOpen) {
            _port.Close();
        }
        PortError = null;
        SentenceReceived = null;
    }

    private string? GetNextBufferedSentence() {
        for (int i = _bufferHead; i < _bufferTail; i++) {
            if (_buffer[i] == '\r' && _buffer[i + 1] == '\n') {
                string result = new string(_buffer, _bufferHead, i - _bufferHead);
                _bufferHead = i + 2;
                return result;
            }
        }
        return null;
    }

    private void ProcessData(object sender, SerialDataReceivedEventArgs args) {
        try {
            //buffer incoming data
            int bytesToRead = _port.BytesToRead;
            byte[] bytes = new byte[bytesToRead];
            _port.Read(bytes, 0, bytesToRead);
            AppendToBuffer(Encoding.ASCII.GetChars(bytes));

            //process all complete sentences available
            string? possibleSentence = GetNextBufferedSentence();
            while (possibleSentence != null) {
                Sentence? sentence = Sentence.Parse(possibleSentence);
                if (sentence != null) {
                    PublishSentence(sentence);
                }
                possibleSentence = GetNextBufferedSentence();
            }
        } catch (Exception ex) {
            string bufferContent = new string(_buffer, _bufferHead, _bufferTail - _bufferHead);
            ParseException?.Invoke(ex, bufferContent);
            //clear buffer and restart parsing
            _bufferHead = 0;
            _bufferTail = 0;
        }
    }

    private void ProcessError(object sender, SerialErrorReceivedEventArgs e) {
        PortError?.Invoke(e.EventType);
    }

    private void PublishSentence(Sentence sentence) {
        SentenceReceived?.Invoke(sentence);
    }

}