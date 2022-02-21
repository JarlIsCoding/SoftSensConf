using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace SoftSensConf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (Debugger.IsAttached) CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());
            comboBoxPort.Text = "--Select--";
            string[] bitRate = new string[] { "1200", "2400", "4800t", "9600",
                                              "19200", "38400", "57600", "115200" };
            comboBoxBitRate.Items.AddRange(bitRate);
            comboBoxBitRate.SelectedIndex = comboBoxBitRate.Items.IndexOf("9600");

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);
        }

        void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string RecievedData = ((SerialPort)sender).ReadLine();
            if (RecievedData.Trim() == "") return;
            textBoxDateReceived.Invoke((MethodInvoker)delegate
            { 

                textBoxDateReceived.AppendText("Recieved: " + RecievedData);
                
                textBoxDateReceived.AppendText(Environment.NewLine);
            });
            string[] splittedData = spltDataRecieved(RecievedData);
            string result = splittedData[0].Trim();
            
            if (splittedData.Length == 1 && result == "1")
            {
                textBoxDateReceived.Invoke((MethodInvoker)delegate
                {
                    textBoxDateReceived.AppendText("successfully wrote to config!");
                    textBoxDateReceived.AppendText(Environment.NewLine);
                    sendReadConfig();
                });
                


            }
            if (splittedData.Length == 5) setLable(splittedData);
            

        }
        delegate void SetTextCallback(Label label, string text);
        private void SetText(Label label, string text)
        {
            //Hvis metoden ikke blir kjørt fra tråden som det den prøver
            //å endre på ble laget i, så må den invokes for å kjøre 
            //i samme tråd som den ble laget i for å
            //gjøre endringer.
            if (label.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { label, text });

            }
            else
            {
                label.Text = text;
            }

        }

        private void setLable(string[] splittedData)
        {
            SetText(lblName, splittedData[0]);

            SetText(lblLRV, splittedData[1]);
            SetText(lblURV, splittedData[2]);
            SetText(lblLowerAlarm, splittedData[3]);
            SetText(lblUpperAlarm, splittedData[4]);
        }

        private string[] spltDataRecieved(string recievedData)
        {
            
            return recievedData.Split(';');
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // prøver å tilkoble valgt port 
                //går til catch hvis det ikke går
                serialPort1.Close();
                serialPort1.PortName = comboBoxPort.Text;
                while (serialPort1.IsOpen) ;
                serialPort1.Open();
                MessageBox.Show("Tilkoblet " + comboBoxPort.Text);
                lblActiveConectStatus.Text = "Connected " + comboBoxPort.Text;
                textBoxDateReceived.AppendText("Connectin to port: " + comboBoxPort.Text + " was sucessful!");
                textBoxDateReceived.AppendText(Environment.NewLine);
            }
            catch (Exception ex)
            {
                serialPort1.Close();
                if (ex is ArgumentException)
                {
                  
                    MessageBox.Show("Invalid Port");
                    textBoxDateReceived.AppendText("Failure to connect to: "+ comboBoxPort.Text + " invalid port. ");
                    textBoxDateReceived.AppendText(Environment.NewLine);

                }
                else if (ex is UnauthorizedAccessException)
                {
                    // porten er i bruk 
                    MessageBox.Show("Connection failed! The port may be in use.");
                    textBoxDateReceived.AppendText("The port may be in use.");
                    textBoxDateReceived.AppendText(Environment.NewLine);
                }
                else
                {
                    // viser feilmeldingen hvis ingen av alternativene over stemmer. 
                    MessageBox.Show(ex.ToString());
                    //throw;
                }
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {


            SendAllConfig();
            
            /*if (serialPort1.IsOpen)
            {

                //serialPort1.WriteLine(SendAllConfig());
            } // serial string received*/
        }

        private void SendAllConfig()
        {
            
            string currentName = getCurrentName();
            float currentLRV = getCurrentLRV();
            float currentURV = getCurrentURV();
            int currentLowerAlarm = getCurrentLowerAlarm();
            int currentUpperAlarm =  getCurrentUpperAlarm();
            string sendAll = ValidateText(currentName, currentLRV, currentURV, currentLowerAlarm, currentUpperAlarm);
            if (sendAll.Length > 0)
            {
                MessageBox.Show(sendAll);
                return;
            }
            clearUserInput();
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("din Dumme Faen! du må connekte. ");
            }
            writeConfig(currentName, currentLRV, currentURV, currentLowerAlarm, currentUpperAlarm);


                
        }

        private void clearUserInput()
        {
            txtBoxLowerAlarm.Clear();
            txtBoxLRV.Clear();
            txtBoxName.Clear();
            txtBoxURV.Clear();  
            txtBoxUpperAlarm.Clear();
        }

        private void writeConfig(string name, float lrv, float urv, int alarml, int alarmh)
        {
            serialPort1.WriteLine(kappa(name, lrv, urv, alarml, alarmh));
            textBoxDateReceived.AppendText("sending: " + kappa(name, lrv, urv, alarml, alarmh));
            textBoxDateReceived.AppendText(Environment.NewLine);
        }

        private static string kappa(string name, float lrv, float urv, int alarml, int alarmh)
        {
            return "writeconf>password>" + name + ";" + lrv + ";" + urv + ";" + alarml + ";" + alarmh;
        }

        private string ValidateText(string currentName, float currentLRV, float currentURV, int currentLowerAlarm, int currentUpperAlarm)
        {
            if (currentName.Length == 0) return "name er bad";
            if (currentLRV < 0.0 || currentLRV > 500.0) return "LRV er bad range =0-500 ";
            if (currentURV < 0.0 || currentURV > 500.0) return "URV er bad range =0-500";
            if (currentLowerAlarm < 0 || currentLowerAlarm > 440) return "Lower alram value er bad =0- 440";
            if (currentUpperAlarm < 0 || currentUpperAlarm > 440) return "Upper alram value er bad =0- 440";

            return ""; 
            
        }

        private int getCurrentUpperAlarm()
        {
            try
            {
                if (txtBoxUpperAlarm.Text.Length == 0) return Int32.Parse(lblUpperAlarm.Text);
                return Int32.Parse(txtBoxUpperAlarm.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;                
            }
            
        }

        private int getCurrentLowerAlarm()
        {
            try
            {

                if (txtBoxLowerAlarm.Text.Length == 0) return Int32.Parse(lblLowerAlarm.Text);
                return Int32.Parse(txtBoxLowerAlarm.Text);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
        }

        private float getCurrentLRV()
        {
            try
            {
            if (txtBoxLRV.Text.Length == 0) return float.Parse(lblLRV.Text, CultureInfo.InvariantCulture);
            return float.Parse(txtBoxLRV.Text, CultureInfo.InvariantCulture);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }


        }

        private string getCurrentName()
        {
            try
            {
            if (txtBoxName.Text.Length == 0) return lblName.Text;
            return txtBoxName.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }


        }

        private float getCurrentURV()
        {
            try
            {

            if (txtBoxURV.Text.Length == 0) return float.Parse(lblURV.Text, CultureInfo.InvariantCulture);
            return float.Parse(txtBoxURV.Text, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }


        }

        private void btnLoadCurrentConfiguration_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                sendReadConfig();
            } // serial string received
        }

        private void sendReadConfig()
        {
            serialPort1.WriteLine("readconf");
        }



        private void saveToFile()
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Text Files | *.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.WriteLine("writeconf>password>" + lblName.Text + ";" + lblLRV.Text + ";" + lblURV.Text + ";" + lblLowerAlarm.Text + ";" + lblUpperAlarm.Text);
                }


                /*string path = @"C:\Users\Jarl Benjamin\Documents\Arduino\SavedFiles\SoftSensConf.txt";

                // This text is added only once to the file.
                if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                        System.IO.FileStream fs =
                                    (System.IO.FileStream)saveFileDialog1.OpenFile();

                        sw.WriteLine("writeconf>password>" + lblName.Text + ";" + lblLRV.Text + ";" + lblURV.Text + ";" + lblLowerAlarm.Text + ";" + lblUpperAlarm.Text);
                        }
                    }

                    // This text is always added, making the file longer over time
                    // if it is not deleted.
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("writeconf>password>" + lblName.Text + ";" + lblLRV.Text + ";" + lblURV.Text + ";" + lblLowerAlarm.Text + ";" + lblUpperAlarm.Text);

                    }*/


            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files | *.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                txtBoxCurrentConfig.Text = File.ReadAllText(openFileDialog.FileName);

                
                 

            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            saveToFile();
        }

        private void btnApplyLoadedConfigurations_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (txtBoxCurrentConfig.Text.Length > 0)
                {
                    serialPort1.WriteLine(txtBoxCurrentConfig.Text);
                }
                else
                {
                    MessageBox.Show("No loaded configurations");
                }
            }
            else
            {
                MessageBox.Show("No device connected");
            }
                
            
            

        }
    }

}
