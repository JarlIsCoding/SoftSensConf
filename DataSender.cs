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
        DataSendeHelper dataSendeHelper;
        public DataSender(SerialPort serialPort)
        {
            this.serialPort = serialPort;
            dataSendeHelper = new DataSendeHelper(serialPort);

        }

        
        public void SendCommandToArduino(string command)
        {
            send(command);
        }

        public void SendCommandToArduino(string command, List<string> args)
        {
            string formattedCommand = dataSendeHelper.formattedCommand(command, args);
            send(formattedCommand);
        }

        private void send(string command)
        {
            serialPort.WriteLine(command);
        }

    }
}
