using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSensConf
{
    internal class DataSender
    {
        SerialPort serialPort;
        public DataSender(SerialPort serialPort)
        {
            this.serialPort = serialPort;

        }

        
        public void SendCommandToArduino(string command)
        {
            send(command);
        }



        private void send(string command)
        {
            serialPort.WriteLine(command);
        }

    }
}
