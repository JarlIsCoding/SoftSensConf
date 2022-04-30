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
        public event EventHandler<DauMessage> newMessage;
        public void handleMessage(object sender, SerialDataReceivedEventArgs e)
        {
            
                string RecievedData = ((SerialPort)sender).ReadLine();
                Console.WriteLine(RecievedData);
                if (RecievedData.Trim() == "") return;               
                List<string> splittedData = spltDataRecieved(RecievedData);
                string command = splittedData[0];
                splittedData.RemoveAt(0);            
                creatAndInvokeNewMessage(command, splittedData);
        }

        private void creatAndInvokeNewMessage(string command, List<string> splittedData)
        {
            DauMessage message = new DauMessage();
            message.command = command;
            message.data = splittedData;
            newMessage.Invoke(this, message);
           
        }
        private List<string> spltDataRecieved(string recievedData)
        {
            return recievedData.Split(';').ToList();
        }
    }
}
