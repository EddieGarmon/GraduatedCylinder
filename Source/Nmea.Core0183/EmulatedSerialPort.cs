using System.IO.Ports;
using System.Reflection;
using System.Text;

namespace Nmea.Core0183;

public class EmulatedSerialPort : ISerialPort
{

    private byte[] _buffer = new byte[4096];
    private int _bufferHead;
    private int _bufferTail;

    public int BytesToRead => _bufferTail - _bufferHead;

    public bool IsOpen { get; private set; }

    public event SerialDataReceivedEventHandler? DataReceived;

    public event SerialErrorReceivedEventHandler? ErrorReceived;

    public void Close() {
        IsOpen = false;
    }

    public void Open() {
        IsOpen = true;
    }

    public void QueueData(char[] data) {
        QueueData(Encoding.ASCII.GetBytes(data));
    }

    public void QueueData(byte[] data) {
        QueueData(data, 0, data.Length);
    }

    public void QueueData(byte[] data, int offset, int count) {
        if (_buffer.Length - _bufferTail < count) {
            EnsureBuffer(count);
        }
        for (int i = 0; i < count; i++) {
            _buffer[_bufferTail++] = data[i + offset];
        }
        DataReceived?.Invoke(this, EventHelper.DataReceivedArgs);
    }

    public void QueueEoF() {
        DataReceived?.Invoke(this, EventHelper.DataEofArgs);
    }

    public void QueueError(SerialError error) {
        ErrorReceived?.Invoke(this, EventHelper.GetErrorArgs(error));
    }

    public int Read(byte[] buffer, int offset, int count) {
        int available = _bufferTail - _bufferHead;
        int toRead = Math.Min(available, count);
        for (int i = 0; i < toRead; i++) {
            buffer[offset + i] = _buffer[_bufferHead + i];
        }
        _bufferHead += toRead;
        return toRead;
    }

    public void Write(string text) {
        throw new Exception("EmulatedSerialPort should be used for testing/debugging inbound serial data only.");
    }

    private void EnsureBuffer(int size) {
        int used = _bufferTail - _bufferHead;
        int available = _buffer.Length - used;
        if (available > size) {
            //shift
            for (int i = 0; i < used; i++) {
                _buffer[i] = _buffer[i + _bufferHead];
            }
        } else {
            //need a bigger buffer
            int newSize = _buffer.Length * 2;
            while (newSize < used + size) {
                newSize *= 2;
            }
            byte[] newBuffer = new byte[newSize];
            for (int i = 0; i < used; i++) {
                newBuffer[i] = _buffer[i + _bufferHead];
            }
            _buffer = newBuffer;
        }
        _bufferHead = 0;
        _bufferTail = used;
    }

    private static class EventHelper
    {

        static EventHelper() {
            ConstructorInfo data = typeof(SerialDataReceivedEventArgs).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] { typeof(SerialData) },
                null)!;
            DataConstructor = serialData => { return (SerialDataReceivedEventArgs)data.Invoke(new object[] { serialData }); };
            DataReceivedArgs = DataConstructor(SerialData.Chars);
            DataEofArgs = DataConstructor(SerialData.Eof);

            ConstructorInfo error = typeof(SerialErrorReceivedEventArgs).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] { typeof(SerialError) },
                null)!;
            ErrorConstructor = serialError => { return (SerialErrorReceivedEventArgs)error.Invoke(new object[] { serialError }); };
        }

        public static SerialDataReceivedEventArgs DataEofArgs { get; }

        public static SerialDataReceivedEventArgs DataReceivedArgs { get; }

        private static Func<SerialData, SerialDataReceivedEventArgs> DataConstructor { get; }

        private static Func<SerialError, SerialErrorReceivedEventArgs> ErrorConstructor { get; }

        public static SerialErrorReceivedEventArgs GetErrorArgs(SerialError serialError) {
            return ErrorConstructor(serialError);
        }

    }

}