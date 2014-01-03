//using System;
//using System.Collections.Generic;
//using System.IO.Ports;
//using System.Linq;
//using System.Threading;
//using Research.Logging;
//using Research.Measurements;
//using Research.Text.Nmea;
//using TruPulse.Modes;
//using TruPulse.Nmea;

//namespace GraduatedCylinder.Devices.Laser
//{
//	//manage settings
//	//execute remote fire
//	public class Laser : ICanLog, IDisposable
//	{
//		private readonly Subject<object> _messages = new Subject<object>();
//		private readonly LaserParser _parser = new LaserParser();
//		private Thread _pollThread;
//		private SerialPort _port;

//		public bool IsConnected {
//			get { return (_port != null) && _port.IsOpen; }
//		}

//		public MeasurementMode MeasurementMode {
//			get {
//				IEnumerable<Sentence> next = _messages.OfType<Sentence>().Where(sentence => sentence.Raw.StartsWith("$MM,")).Next();
//				SendCommand(Commands.MeasurementMode.GetCommand());
//				Sentence response = next.First();
//				return (MeasurementMode)Enum.Parse(typeof(MeasurementMode), response.Raw.Substring(4));
//			}
//			set {
//				string command = Commands.MeasurementMode.GetSetCommand(value);
//				SendCommand(command);
//			}
//		}

//		public IObservable<Message> Messages {
//			get { return _messages.OfType<Message>(); }
//		}

//		public TargetMode TargetMode {
//			get {
//				IEnumerable<Sentence> next = _messages.OfType<Sentence>().Where(sentence => sentence.Raw.StartsWith("$TM,")).Next();
//				SendCommand(Commands.TargetMode.GetCommand());
//				Sentence response = next.First();
//				return (TargetMode)Enum.Parse(typeof(TargetMode), response.Raw.Substring(4));
//			}
//			set {
//				string command = Commands.TargetMode.GetSetCommand(value);
//				SendCommand(command);
//			}
//		}

//		public HeightVector CaptureHeight() {
//			MeasurementMode = MeasurementMode.Height;
//			IEnumerable<Message> next = _messages.OfType<Message>().Where(m => m.Value is HeightVector).Next();
//			Message message = next.First();
//			return message.ValueAs<HeightVector>();
//		}

//		public MissingLine CaptureMissingLine() {
//			//todo: mode is not setting correctly here.
//			MeasurementMode = MeasurementMode.MissingLine;
//			IEnumerable<Message> next = _messages.OfType<Message>().Where(m => m.Value is MissingLine).Next();
//			Message message = next.First();
//			return message.ValueAs<MissingLine>();
//		}

//		public GeoVector CaptureVector(bool autoFire = false) {
//			MeasurementMode = MeasurementMode.SlopeDistance;
//			IEnumerable<Message> next = _messages.OfType<Message>().Where(m => m.Value is GeoVector).Next();
//			if (autoFire) {
//				SendCommand(Commands.Start.GetCommand());
//			}
//			Message message = next.First();
//			return message.ValueAs<GeoVector>();
//		}

//		public void Connect(string portName = "COM40") {
//			string[] portNames = SerialPort.GetPortNames();
//			if (!portNames.Contains(portName)) {
//				throw new Exception("Bad Port: " + portName);
//			}
//			//4800 or 38400? baud
//			_port = new SerialPort(portName, 4800, Parity.None, 8, StopBits.One) {
//				// ReadTimeout = 100
//			};
//			_pollThread = new Thread(() => {
//				while (true) {
//					if (_port == null) {
//						return;
//					}
//					try {
//						string line = _port.ReadLine().TrimEnd('\r', '\n');
//						//todo handle not complete message
//						this.Log().Info(line);
//						object value = _parser.Parse(line);
//						_messages.OnNext(value);
//					}
//					catch (Exception) {
//						throw;
//					}
//				}
//			});

//			//_port.DataReceived += (sender, args) => { };
//			_port.Open();
//			_pollThread.Start();
//			InitializeSettings();
//		}

//		public void Disconnect() {
//			Thread thread = Interlocked.CompareExchange(ref _pollThread, null, null);
//			if (thread != null) {
//				thread.Abort();
//			}
//			SerialPort port = Interlocked.CompareExchange(ref _port, null, null);
//			if (port != null) {
//				port.Close();
//			}
//		}

//		public void Dispose() {
//			Disconnect();
//		}

//		public Voltage GetBatteryVoltage() {
//			if (!IsConnected) {
//				return Voltage.Zero;
//			}
//			IEnumerable<Sentence> next = _messages.OfType<Sentence>().Where(sentence => sentence.Raw.StartsWith("$BV,")).Next();
//			SendCommand(Commands.BatteryVoltage.GetCommand());
//			Sentence response = next.First();
//			return new Voltage(double.Parse(response.Raw.Substring(4)), VoltageUnit.MilliVolts);
//		}

//		public void TurnOff() {
//			if (IsConnected) {
//				SendCommand(Commands.PowerOff.GetCommand());
//			}
//		}

//		private void InitializeSettings() {
//			//read some settings
//			SendCommand(Commands.Id.GetCommand());

//			//set some others
//			SendCommandAndWaitForOk(Commands.AngleUnits.GetSetCommand(AngleUnitsMode.Degrees));
//			SendCommandAndWaitForOk(Commands.DistanceUnits.GetSetCommand(DistanceUnitsMode.Meters));
//		}

//		private void SendCommand(string command) {
//			_port.WriteLine(command);
//		}

//		private void SendCommandAndWaitForOk(string command) {
//			IEnumerable<Sentence> next = _messages.OfType<Sentence>().Where(sentence => sentence.Raw == "$OK").Next();
//			_port.WriteLine(command);
//			next.First();
//		}
//	}
//}