using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftSensConf
{
    public class DataHandler
    {
        DataHanderHelper dataHandlerHelper = new DataHanderHelper();
        public event EventHandler<DauMessage> newMessage;
        public void handleMessage(object sender, SerialDataReceivedEventArgs e)
        {
            
                string RecievedData = ((SerialPort)sender).ReadLine();
                Console.WriteLine(RecievedData);
                if (RecievedData.Trim() == "") return;               
                List<string> splittedData = spltDataRecieved(RecievedData);
                string command = splittedData[0];
                splittedData.RemoveAt(0);            
                routeMessage(command, splittedData);
        }

        private void routeMessage(string command, List<string> splittedData)
        {
            DauMessage message = new DauMessage();
            switch (command)
            {
                case "writeconf":
                    makingWriteconfMessage(command ,message, splittedData);
                    newMessage.Invoke(this, message);
                    break;
                 case "readraw":
                    makingReadRawMessage(command, message, splittedData);
                    newMessage.Invoke(this, message);
                    break;

                 case "readscaled":
                     makingReadScaledMessage(command, message, splittedData);
                     newMessage.Invoke(this, message);
                     break;

                 case "readstatus":
                    makingChangeAlarmstatusMessage(command, message, splittedData);
                    newMessage.Invoke(this, message);

                    break; 

                case "readconf":
                    message.command = "readconf";
                    message.args = splittedData;
                    Console.WriteLine("test");
                    newMessage.Invoke(this, message);
                    break;

                default:
                    MessageBox.Show("No match");
                    break;
                    

            }
        }

        private void makingReadRawMessage(string command, DauMessage message, List<string> splittedData)
        {
            message.command = command;
            message.args = splittedData;
            message.commandToSend = "readstatus";
        }

        private void makingChangeAlarmstatusMessage(string command, DauMessage message, List<string> splittedData)
        {
            message.command = command;
            message.args = splittedData;  
        }

        private void makingReadScaledMessage(string command, DauMessage message, List<string> splittedData)
        {
            message.command = command;
            message.commandToSend = "readraw"; // <-- Heg setter kommando jeg ønsker at DAU skal sende når den mottar denne meldingen
            message.args = splittedData;
        }

        private void makingWriteconfMessage(string command, DauMessage message, List<string> splittedData)
        {
            
            if (splittedData[0].Trim() != "1")
            {
                MessageBox.Show("Wrong Password");
                return;
            }
            message.command = command;
            message.commandToSend = "readconf";
        }

        private List<string> spltDataRecieved(string recievedData)
        {

            return recievedData.Split(';').ToList();
        }
    }
}
