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
        
        public DauMessage handleMessage(object sender, SerialDataReceivedEventArgs e)
        {
            
                string RecievedData = ((SerialPort)sender).ReadLine();
                Console.WriteLine(RecievedData);
                if (RecievedData.Trim() == "") return null;               
                List<string> splittedData = spltDataRecieved(RecievedData);
                string command = splittedData[0];
                splittedData.RemoveAt(0);

                
                return routeMessage(command, splittedData);
            

        }

        private DauMessage routeMessage(string command, List<string> splittedData)
        {
            DauMessage message;
            switch (command)
            {
                case "writeconf":
                    Console.WriteLine(splittedData[0]);
                    if (splittedData[0].Trim() != "1")
                    {
                        MessageBox.Show("Wrong Password");
                        break;
                    }
                    //string formatted = dataHandlerHelper.formatArgsFromCommand(splittedData);
                    message = new DauMessage();
                    message.command = "readconf";
                    message.sendCommand = true;
                    Console.WriteLine(message.ToString() + "test1");
                    return message;

               /* case "readraw":
                    appendTextToTextBox(txtBoxRawValues, splittedData[0]);
                    readStatusValue();


                    break;

                case "readscaled":
                    readRawValues();
                    plotGraph(splittedData);

                    break;

                case "readstatus":
                    //readStatusValue();
                    changeAlarmstatus(textBoxDateReceived, splittedData[0]);

                    break; */

                case "readconf":

                    message = new DauMessage();
                    message.command = "readconf";
                    message.sendCommand = false;
                    message.args = splittedData;
                    Console.WriteLine("test");
                    return message;

                default:
                    MessageBox.Show("No match");
                    return null;
                    

            }
            return null;
        }

        private List<string> spltDataRecieved(string recievedData)
        {

            return recievedData.Split(';').ToList();
        }


    }
}
