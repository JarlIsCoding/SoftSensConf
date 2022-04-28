using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftSensConf
{
    internal class DataAcquisitionUnit
    {

        private string tagName = "somthing";
        private float lowerRangeValue;
        private float upperRangeValue;
        private int lowerAlarm;
        private int upperAlarm;
        /*private string portName;
        private int baudRate;*/
        SerialPort serialPort = new SerialPort();
        DataHandler dataHandler = new DataHandler();
        Dictionary<string, string> formattedMessages = new Dictionary<string, string>();
        DataSender dataSender;
        public event EventHandler<bool> readConfig;

        public DataAcquisitionUnit()
        {

            
            setValues(tagName, lowerRangeValue, upperRangeValue, lowerAlarm, upperAlarm);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(handleMessage);
            dataSender = new DataSender(serialPort);


        }

        private void handleMessage(object sender, SerialDataReceivedEventArgs e)
        {

            DauMessage message = dataHandler.handleMessage(sender, e);
            if (message != null)
            {
                if (message.sendCommand)
                {
                    dataSender.SendCommandToArduino(message.command);
                }
                else
                {
                    routeCommand(message.command, message.args != null ? message.args : null);
                }
            }


        }

        private void routeCommand(string command, List<string> args)
        {
            switch (command)
            {
                case "readconf":
                    readConfig?.Invoke(this, true);
                    break;
                default:
                    Console.WriteLine("no match");
                    break;
            }
        }

        public void sendCommand(string command)
        {
            dataSender.SendCommandToArduino(command);
        }

        private void setValues(string tagName, float lowerRangeValue, float upperRangeValue, int lowerAlarm, int upperAlarm)
        {
            this.tagName = tagName.Length > 0 ? tagName : "somthing";
            this.lowerRangeValue = lowerRangeValue.ToString().Length > 0 ? lowerRangeValue : 0;
            this.upperRangeValue = upperRangeValue.ToString().Length > 0 ? upperRangeValue : 500;
            this.lowerAlarm = lowerAlarm.ToString().Length > 0 ? lowerAlarm : 0;
            this.upperAlarm = upperAlarm.ToString().Length > 0 ? upperAlarm : 400;
        }
        public bool connectToSerialPort(string port, int rate)
        {
            if (!serialPort.IsOpen)
            {
            serialPort.BaudRate = rate;
            serialPort.PortName = port;
            serialPort.Open();
                if (serialPort.IsOpen) return true;
            }
            return false;

        }

        public bool disconnectFromSerialport()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                if (!serialPort.IsOpen) return true;
            }
            return false ;
        }
        public void sendstuff()
        {
            serialPort.WriteLine("writeconf>password>name;0;500;40; 440");
        }
    }

}
