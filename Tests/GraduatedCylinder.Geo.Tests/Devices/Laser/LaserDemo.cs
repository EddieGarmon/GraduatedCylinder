using System.IO.Ports;

namespace GraduatedCylinder.Devices.Laser
{
    class Program
    {

        private static SerialPort? _serial;

        static void DemoMain(string[] args) {
            //SerialPort com4 = new SerialPort("COM4", 4800, Parity.None, 8, StopBits.One);
            _serial = new SerialPort("COM4", 38400, Parity.None, 8, StopBits.One);
            _serial.DataReceived += (sender, _) => {
                                        if (sender is not SerialPort port) {
                                            return;
                                        }
                                        string line = port.ReadLine();
                                        Console.WriteLine(line);
                                    };
            _serial.Open();

            //drive one reading from each measure available
            Exec("$ID", _serial);

            Console.ReadLine();
            Console.WriteLine("start reading:");
            Exec("$MM,2", _serial); //slope distance
            Exec("$GO", _serial);
            Exec("$MM,4", _serial); //height
            Exec("$GO", _serial);
            Console.ReadLine();
            Exec("$MM,5", _serial);
            Exec("$MM", _serial);
            Exec("$GO", _serial);
            Console.WriteLine("done");
            Console.ReadLine();

            string? input;
            while ((input = Console.ReadLine()) != null) {
                _serial.WriteLine(input + "\r\n");
            }
        }

        private static void Exec(string command, SerialPort serial) {
            serial.WriteLine(command + "\r\n");
            Thread.Sleep(500);
        }

    }
}