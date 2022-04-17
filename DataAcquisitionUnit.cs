using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
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
        private string portName;
        private int baudRate;
        SerialPort serialPort;
        DataHandler dataHandler = new DataHandler();

        public DataAcquisitionUnit(string portName, int baudRate)
        {

            serialPort = new SerialPort();
            setValues(tagName, lowerRangeValue, upperRangeValue, lowerAlarm, upperAlarm);
            this.portName = portName;
            this.baudRate = baudRate;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(dataHandler.handleMessage);
            
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
    }

}
