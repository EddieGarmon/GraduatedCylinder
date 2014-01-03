using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace TruConsole
{
	class Program
	{
		private static SerialPort _com4;

		static void Main(string[] args)
		{
			//SerialPort com4 = new SerialPort("COM4", 4800, Parity.None, 8, StopBits.One);
			_com4 = new SerialPort("COM4", 38400, Parity.None, 8, StopBits.One);
			_com4.DataReceived += (sender1, e1) =>
			{
				SerialPort port = sender1 as SerialPort;
				string line = port.ReadLine();
				Console.WriteLine(line);
			};
			_com4.Open();

			//drive one reading from each measure available
			Exec("$ID");

			Console.ReadLine();
			Console.WriteLine("start reading:");
			Exec("$MM,2"); //slope distance
			Exec("$GO");
			Exec("$MM,4"); //height
			Exec("$GO");
			Console.ReadLine();
			Exec("$MM,5");
			Exec("$MM");
			Exec("$GO");
			Console.WriteLine("done");
			Console.ReadLine();

			string input;
			while ((input = Console.ReadLine()) != null)
			{
				_com4.WriteLine(input + "\r\n");
			}
		}

		private static void Exec(string command)
		{
			_com4.WriteLine(command + "\r\n");
			Thread.Sleep(500);
		}
	}
}
