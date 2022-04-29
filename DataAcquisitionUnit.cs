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

        public string tagName { get; private set; }
        public float lowerRangeValue { get; private set; }
        public float upperRangeValue { get; private set; }
        public int lowerAlarm { get; private set; }
        public int upperAlarm { get; private set; }
        public int rawValue { get; private set; }
        public float scaledValue { get; private set; }
        public int alarmStatusValue { get; private set; }

        /*private string portName;
        private int baudRate;*/
        SerialPort serialPort = new SerialPort();
        DataHandler dataHandler = new DataHandler();
        Dictionary<string, string> formattedMessages = new Dictionary<string, string>();
        DataSender dataSender;
        public event EventHandler<bool> readConfig;
        public event EventHandler<List<string>> readScaled;
        public event EventHandler<List<string>> readStatus;
        public event EventHandler<List<string>> readraw;
        RemoteDataCollector remoteDataCollector;


        public DataAcquisitionUnit()
        {
            serialPort.DataReceived += new SerialDataReceivedEventHandler(dataHandler.handleMessage);
            dataSender = new DataSender(serialPort);
            dataHandler.newMessage += newMessageEvent;
            
        }


        private void newMessageEvent(object sender, DauMessage message)
        {
            switch (message.command)
            {
                case "writeconf":
                    sendCommand(message.commandToSend);
                    break;
                case "readconf":
                    parseAndSetValues(message.args);
                    readConfig?.Invoke(this, true);
                    break;
                case "readscaled":
                    readScaled?.Invoke(this, message.args);
                    sendCommand(message.commandToSend);
                    scaledValue = float.Parse(message.args[0]);
                    break;
                case "readraw":
                    readraw?.Invoke(this, message.args);
                    sendCommand(message.commandToSend);
                    rawValue = int.Parse(message.args[0]);
                    break;
                case "readstatus":
                    readStatus?.Invoke(this, message.args);
                    alarmStatusValue = int.Parse(message.args[0]);
                    break;
                

                default:
                    Console.WriteLine("no match");
                    break;
                  

            }


        }

        private void parseAndSetValues(List<string> args)
        {
            string name = args[0];
            float lowerRangeValue = parseStringToFloat(args[1]);
            float upperRangeValue = parseStringToFloat(args[2]);
            int lowerAlarm = parseStringtoInt(args[3]);
            int upperAlarm = parseStringtoInt(args[4]);

            setValues(name, lowerRangeValue, upperRangeValue, lowerAlarm, upperAlarm);
        }

        public bool sendCommand(string command)
        {
            if (!serialPort.IsOpen) return false;
            dataSender.SendCommandToArduino(command);
            return true;
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

        private float parseStringToFloat(string stringToParse)
        {
            return float.Parse(stringToParse);
        }

        private int parseStringtoInt(string intToParse)
        {
            return int.Parse(intToParse);
        }
    }

}
