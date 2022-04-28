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
                    makingWriteconfMessage(message, splittedData);
                    newMessage.Invoke(this, message);
                    break;
                 case "readraw":
              
                     break;

                 case "readscaled":
                     makingReadRawMessage(message, splittedData);
                     newMessage.Invoke(this, message);
                     

                     break;

                /* case "readstatus":
                    //readStatusValue();
                    changeAlarmstatus(textBoxDateReceived, splittedData[0]);

                    break; */

                case "readconf":
                    message.command = "readconf";
                    message.sendCommandIfTrue = false;
                    message.args = splittedData;
                    Console.WriteLine("test");
                    newMessage.Invoke(this, message);
                    break;

                default:
                    MessageBox.Show("No match");
                    break;
                    

            }
        }

        private void makingReadRawMessage(DauMessage message, List<string> splittedData)
        {
            message.sendCommandIfTrue = true;
            message.command = "readraw";
            message.args = splittedData;
        }

        private void makingWriteconfMessage(DauMessage message, List<string> splittedData)
        {
            
            if (splittedData[0].Trim() != "1")
            {
                MessageBox.Show("Wrong Password");
                return;
            }
            message.command = "readconf";
            message.sendCommandIfTrue = true;
            
        }

        private List<string> spltDataRecieved(string recievedData)
        {

            return recievedData.Split(';').ToList();
        }


    }
}
