using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftSensConf
{
    internal class DataSenderHelper
    {
        SerialPort serialPort;
        public DataSenderHelper(SerialPort serialPort)
        {
            this.serialPort = serialPort;

        }

        public string formattedCommand(string command, List<string> args) {
            switch (command)
            {
                case "writeconf":
                    return handleWriteConfiguration(command, args);

                default:
                    System.Console.WriteLine("No match");
                    break;
            }

            return null;
        }

        private string handleWriteConfiguration(string command, List<string> args)
        {
            string configSeperator = ">";
            string seperator = ";"
            string password = args[0];
            string name = args[1];
            string lrv = args[2];
            string hrv = args[3];
            string al = args[4];
            string ah = args[5];
            StringBuilde sb = new StringBuilder();
            sb.Append(command);
            sb.Append(configSeperator);
            sb.Append(password);
            sb.Append(configSeperator);
            sb.Append(name);
            sb.Append(seperator);
            sb.Append(lrv);
            sb.Append(seperator);
            sb.Append(hrv);
            sb.Append(seperator);
            sb.Append(al);
            sb.Append(seperator);
            sb.Append(ah);
            return sb.ToString();
        }

    }
}