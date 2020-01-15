using System;
using System.IO.Ports;
using System.Reflection;
using System.Text;

namespace GraduatedCylinder.Devices.Serial
{
    public class EmulatedSerialPort : ISerialPort
    {
        private readonly SerialDataReceivedEventArgs _dataEoFArgs;
        private readonly SerialDataReceivedEventArgs _dataReceivedArgs;
        private byte[] _buffer = new byte[4096];
        private int _bufferHead;
        private int _bufferTail;

        public EmulatedSerialPort() {
            ConstructorInfo constructor = typeof(SerialDataReceivedEventArgs).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                new[] {
                    typeof(SerialData)
                },
                null);

            _dataEoFArgs = (SerialDataReceivedEventArgs)constructor.Invoke(new object[] {
                SerialData.Eof
            });

            _dataReceivedArgs = (SerialDataReceivedEventArgs)constructor.Invoke(new object[] {
                SerialData.Chars
            });
        }

        public int BytesToRead => _bufferTail - _bufferHead;

        public bool IsOpen { get; private set; }

        public event SerialDataReceivedEventHandler DataReceived;

        public event SerialErrorReceivedEventHandler ErrorReceived;

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
            DataReceived?.Invoke(this, _dataReceivedArgs);
        }

        public void QueueEoF() {
            throw new NotImplementedException("EmulatedSerialPort.QueueEoF");
            DataReceived?.Invoke(this, _dataEoFArgs);
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
    }
}