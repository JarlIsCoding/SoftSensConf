﻿using System;
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
using System.Threading;


namespace SoftSensConf
{
    public partial class Form1 : Form
    {
        List<float> analogReading = new List<float>();
        List<string> timeStamp = new List<string>();
        Dictionary<string, float> listOfFormatedTimeAndScaledDataNumbers = new Dictionary<string, float>();
        Instrument lightSensor = new Instrument();

        public Form1()
        {
            InitializeComponent();
            if (Debugger.IsAttached) CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());
            comboBoxPort.Text = "--Select--";
            string[] bitRate = new string[] { "1200", "2400", "4800", "9600",
                                              "19200", "38400", "57600", "115200" };
            comboBoxBitRate.Items.AddRange(bitRate);
            comboBoxBitRate.SelectedIndex = comboBoxBitRate.Items.IndexOf("9600");

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);
        }


        void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string RecievedData = ((SerialPort)sender).ReadLine();
                Console.WriteLine(RecievedData);
                if (RecievedData.Trim() == "") return;
                textBoxDateReceived.Invoke((MethodInvoker)delegate
                { 
                    textBoxDateReceived.AppendText("Recieved: " + RecievedData);
                    textBoxDateReceived.AppendText(Environment.NewLine);
                });
                List<string> splittedData = spltDataRecieved(RecievedData);
                string command = splittedData[0];
                splittedData.RemoveAt(0);
            
                messageRecieved(command, splittedData);
                appendConfigToDatabase(command, splittedData);
                return;
            }
            MessageBox.Show("No connection");
            
        }

        private void messageRecieved(string command, List<string> splittedData)
        {
            switch (command)
            {
                case "writeconf":
                    Console.WriteLine(splittedData[0]);
                    if (splittedData[0].Trim() != "1")
                    {
                        MessageBox.Show("Wrong Password");
                        break;
                    }
                    sendReadConfig();
                    txtBoxName.Invoke((MethodInvoker)delegate
                    {
                    clearUserInput();    
                    });
                    MessageBox.Show("configurations was successfully changed");

                    break;
                
                case "readraw":
                    appendTextToTextBox(txtBoxRawValues, splittedData[0]);
                    readStatusValue();


                    break ;

                case "readscaled":
                    readRawValues();
                    plotGraph(splittedData);
                    
                    break;
                
                case "readstatus":
                    //readStatusValue();
                    changeAlarmstatus(textBoxDateReceived, splittedData[0]);

                    break;
                
                case "readconf":
                    setCurrentConfigurationLable(splittedData);

                    break;

                default: 
                    MessageBox.Show("macher not");
                    break;

            }

        }

        private void changeAlarmstatus(TextBox textboxAlarmData, string splittedData)
        {
            textboxAlarmData.Invoke((MethodInvoker)delegate
            {
                if (splittedData.Trim() == "0")
                {
                    lblAlarmStatus.Text = "OK";
                }
                if (splittedData.Trim() == "1")
                {
                    timer1.Enabled = false;
                    lblAlarmStatus.Text = "Fail. Datatracking stopped";
                    MessageBox.Show("Alarm! Data received has failed. Datatracking stopped");
                    saveChart1DialogBox();
                    checkBoxEnableSignalReceiveMode.Checked = false;
                }
                if (splittedData.Trim() == "2")
                {
                    timer1.Enabled = false;
                    lblAlarmStatus.Text = "Lower limit alarm. Datatracking stopped";
                    MessageBox.Show("Lower limit alarm. Datatracking stopped");
                    saveChart1DialogBox();
                    checkBoxEnableSignalReceiveMode.Checked = false;
                }
                if (splittedData.Trim() == "3")
                {
                    timer1.Enabled = false;
                    lblAlarmStatus.Text = "Upper limit alarm. Datatracking stopped";
                    MessageBox.Show("Upper limit alarm. Datatracking stopped");
                    saveChart1DialogBox();
                    checkBoxEnableSignalReceiveMode.Checked = false;
                }

            });
        }

        private void appendTextToTextBox(TextBox txtBox, string v)
        {
            txtBox.Invoke((MethodInvoker)delegate
            {
                txtBox.AppendText(v);
                txtBox.AppendText(Environment.NewLine);
            });
        }

        private void plotGraph(List<string> RecievedData)
        {
            textBoxDateReceived.Invoke((MethodInvoker)delegate
            {
                
                string trimedData = RecievedData[0];
                float scaledDataNumber = float.Parse(trimedData, CultureInfo.InvariantCulture);
                analogReading.Add(scaledDataNumber);
                DateTime now = DateTime.Now;
                string formattedTime = now.Hour + ":" + now.Minute + ":" + now.Second;
                timeStamp.Add(formattedTime);
                txtBoxScaledValues.AppendText("Scaled value:" + scaledDataNumber.ToString());
                txtBoxScaledValues.AppendText(Environment.NewLine);
                chart1.ChartAreas[0].AxisX.Title = "Time";
                chart1.ChartAreas[0].AxisY.Title = "Scaled Value";
                chart1.Series["Scaled sensor values"].Points.DataBindXY(timeStamp, analogReading);
                chart1.Invalidate();
                dataAppenderForCart1(formattedTime, scaledDataNumber);

            });

        }

        private void dataAppenderForCart1(string formattedTime, float scaledDataNumber)
        {
          try
            {
            listOfFormatedTimeAndScaledDataNumbers.Add(formattedTime, scaledDataNumber);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        delegate void SetTextCallback(Label label, string text);
        private void SetTextInvoker(Label label, string text)
        {
            //Hvis metoden ikke blir kjørt fra tråden som det den prøver
            //å endre på ble laget i, så må den invokes for å kjøre 
            //i samme tråd som den ble laget i for å
            //gjøre endringer.
            if (label.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetTextInvoker);
                this.Invoke(d, new object[] { label, text });

            }
            else
            {
                label.Text = text;
            }

        }

        private void setCurrentConfigurationLable(List<string> splittedData)
        {
            SetTextInvoker(lblName, splittedData[0]);
            SetTextInvoker(lblLRV, splittedData[1]);
            SetTextInvoker(lblURV, splittedData[2]);
            SetTextInvoker(lblLowerAlarm, splittedData[3]);
            SetTextInvoker(lblUpperAlarm, splittedData[4]);
        }

        private List<string> spltDataRecieved(string recievedData)
        {
            
            return recievedData.Split(';').ToList();
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
                Thread.Sleep(500);
                changeConnetionCouloureToGreen();
                sendReadConfig();
                MessageBox.Show("Tilkoblet " + comboBoxPort.Text);
                lblActiveConectStatus.Text = "Connected " + comboBoxPort.Text;
                textBoxDateReceived.AppendText("Connectin to port: " + comboBoxPort.Text + " was sucessful!");
                textBoxDateReceived.AppendText(Environment.NewLine);
                timer2.Enabled = true;
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
            if (txtBoxName.TextLength == 0 && txtBoxLRV.TextLength == 0 && txtBoxURV.TextLength == 0 && txtBoxLowerAlarm.TextLength == 0 && txtBoxUpperAlarm.TextLength == 0)
            {
                MessageBox.Show("No values written");
                return;
            }

            SendAllConfig();
            

        }

        private void SendAllConfig()
        {

            string currentName = getCurrentName();
            float currentLRV = getCurrentLRV();
            float currentURV = getCurrentURV();
            int currentLowerAlarm = getCurrentLowerAlarm();
            int currentUpperAlarm = getCurrentUpperAlarm();
            string sendAll = validateText(currentName, currentLRV, currentURV, currentLowerAlarm, currentUpperAlarm);
            List<string> list = new List<string> { currentName, currentLRV.ToString(), currentURV.ToString(), currentLowerAlarm.ToString(), currentUpperAlarm.ToString() };
            string command = "writeconf";
            Console.WriteLine(String.Join(", ", list));
            
            if (sendAll.Length > 0)
            {
                MessageBox.Show(sendAll);
                return;
            }
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("Device is not connected");
                return;
            }
            
            writeConfig(command, list);
            
            


                
        }


        private void clearUserInput()
        {
            txtBoxLowerAlarm.Clear();
            txtBoxLRV.Clear();
            txtBoxName.Clear();
            txtBoxURV.Clear();  
            txtBoxUpperAlarm.Clear();
            
        }

        private void writeConfig(string command, List<string> args)
        {
            sendCommand(command, args);
            //serialPort1.WriteLine(kappa(name, lrv, urv, alarml, alarmh));
            textBoxDateReceived.AppendText("sending: " + args);
            textBoxDateReceived.AppendText(Environment.NewLine);
        }


        private string validateText(string currentName, float currentLRV, float currentURV, int currentLowerAlarm, int currentUpperAlarm)
        {
            if (currentName.Length == 0 || currentName.Length > 10) return "Name must be between one and ten characters";
            if (currentLRV < 0.0 || currentLRV > 500.0) return "Lower rage value must be a number between 0-500 ";
            if (currentURV < 0.0 || currentURV > 500.0) return "Upper range value must be between 0-500";
            if (currentLowerAlarm < 0 || currentLowerAlarm > 500) return "Lower alram value must be a wholenumber between 0- 440";
            if (currentUpperAlarm < 0 || currentUpperAlarm > 500) return "Upper alram value must be a wholenumber between 0- 440";

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
            if (txtBoxName.Text.Length == 0) return lblName.Text;
            return txtBoxName.Text;
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
            else
            {
                MessageBox.Show("Not connected to any device");
            }
        }

        private void sendReadConfig()
        {
            sendCommand("readconf", null);
        }

        private void sendCommand(string command, List<string> args) 
        {
            string password = "";
            string writeToArduino;
            if (command == "writeconf")
            {
                password = askForPassword();
                writeToArduino = command + ">" + password + ">" + String.Join(";", args);
            }
            else
            {
                writeToArduino = command;
            }
            serialPort1.WriteLine(writeToArduino);
            
            Console.WriteLine(writeToArduino);
              
        }

        private string askForPassword()
        {

            string input = "";
            
            DialogResult result = ShowInputDialog(ref input);
            if (result == DialogResult.Cancel) return "";
            return input;
            
        }

        private void saveToFile()
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Text Files | *.ssc";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.WriteLine( lblName.Text + ";" + lblLRV.Text + ";" + lblURV.Text + ";" + lblLowerAlarm.Text + ";" + lblUpperAlarm.Text);
                }

            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            clearUserInput();
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files | *.ssc";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var configValues = File.ReadAllText(openFileDialog.FileName);
                    var configList = new List<string>(configValues.Split(';').ToList());
                    txtBoxName.AppendText(configList[0].ToString());
                    txtBoxLRV.AppendText(configList[1].ToString());
                    txtBoxURV.AppendText(configList[2].ToString());
                    txtBoxLowerAlarm.AppendText(configList[3].ToString());
                    txtBoxUpperAlarm.AppendText(configList[4].ToString().Trim());
                }
                      
                    
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                
                 

            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            saveToFile();
        }

        /*private void btnApplyLoadedConfigurations_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (txtBoxCurrentConfig.Text.Length > 0)
                {
                    string command = "writeconf";
                    List<string> config = txtBoxCurrentConfig.Text.Split(';').ToList();
                    string validation = validateText(config[0], float.Parse(config[1]), float.Parse(config[2]), int.Parse(config[3]), int.Parse(config[4].Trim()));
                    if (validation.Length > 0)
                    {
                        MessageBox.Show(validation);
                        return;
                    }
                    writeConfig(command, config);
                    
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
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            reascaledValues();
            
        }


        private void connectionCheck()
        {
            if (serialPort1.IsOpen)
            {
                timer2.Enabled = true;
                changeConnetionCouloureToGreen();
                return;
            }
            timer2.Enabled=false;
            changeConnetionCouloureToRed();
            textBoxDateReceived.AppendText("Connection lost!");
            textBoxDateReceived.AppendText(Environment.NewLine);
            MessageBox.Show("connection lost");
            saveCartToFile();
            
        }

        private void changeConnetionCouloureToRed()
        {
            lblConnetionStatus.BackColor = Color.Red;
            lblConnetionStatus.ForeColor = Color.Red;
            lblConnetionStatus1.BackColor = Color.Red;
            lblConnetionStatus1.ForeColor = Color.Red;
            lblConnetionStatus2.ForeColor = Color.Red;
            lblConnetionStatus2.BackColor = Color.Red;
            lblActiveConectStatus.Text = "Disconnected";
        }

        private void changeConnetionCouloureToGreen()
        {
            lblConnetionStatus.BackColor = Color.Green;
            lblConnetionStatus.ForeColor = Color.Green;
            lblConnetionStatus1.BackColor = Color.Green;
            lblConnetionStatus1.ForeColor = Color.Green;
            lblConnetionStatus2.ForeColor = Color.Green;
            lblConnetionStatus2.BackColor = Color.Green;
        }

        private void readStatusValue()
        {
            serialPort1.WriteLine("readstatus");
        }

        private void readRawValues()
        {
            serialPort1.WriteLine("readraw");
        }

        private void reascaledValues()
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                serialPort1.WriteLine("readscaled");
                return;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            timer1.Enabled = false;
            MessageBox.Show("No connection");
            if (DialogResult == DialogResult.OK) return;
            
            

        }

        private void checkBoxEnableSignalReceiveMode_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                MessageBox.Show("No device connected", serialPort1.IsOpen.ToString());
                checkBoxEnableSignalReceiveMode.Checked = false;
                return;
            }
            if (checkBoxEnableSignalReceiveMode.Checked)
            {
                listOfFormatedTimeAndScaledDataNumbers.Clear();
                timer1.Enabled = true;
            }
            if (!checkBoxEnableSignalReceiveMode.Checked)
            {
                timer1.Enabled = false;
                saveChart1DialogBox();
            }
        }
       

        private void saveChart1DialogBox()
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save chartdata to file?", "Save Chart", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                saveCartToFile();
               
            }
        }

        private void saveCartToFile()
        {
            string formatedScaledDataNumber = listOfFormatedTimeAndScaledDataNumbers.ToString();
            SaveFileDialog saveFileDialogTimeAndData = new SaveFileDialog();

            saveFileDialogTimeAndData.Filter = "Text Files | *.csv";
            saveFileDialogTimeAndData.FilterIndex = 2;
            saveFileDialogTimeAndData.RestoreDirectory = true;

            if (saveFileDialogTimeAndData.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialogTimeAndData.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    foreach (KeyValuePair<string, float> entry in listOfFormatedTimeAndScaledDataNumbers)
                    {
                        sw.Write(entry.Key + "," + entry.Value + "[" + entry.Key + "]; ");

                    }
                    
                }

            }
        }

        private static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();
            inputBox.StartPosition = FormStartPosition.CenterParent;

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Password";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            textBox.PasswordChar = '*';
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            disconnectArduino();
            changeConnetionCouloureToRed();
        }

        private void disconnectArduino()
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                serialPort1.PortName = comboBoxPort.Text;
                MessageBox.Show("Disconnected: " + comboBoxPort.Text);
                lblActiveConectStatus.Text = "Disconnected";
                textBoxDateReceived.AppendText("Disconnection from: " + comboBoxPort.Text + " was sucessful!");
                textBoxDateReceived.AppendText(Environment.NewLine);
                return;
            }
            MessageBox.Show("No devise connected");

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            connectionCheck();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* switch (tabControl1.SelectedIndex)
            {
                case 1:
                    if (serialPort1.IsOpen) sendReadConfig();
                    
                    break;

            }*/
        }
        private void appendConfigToDatabase(string command, List<string> recevedData)
        {
            if (command == "writeconf")
            {
                string InstrumentName = recevedData[0];
                string lowerRangeValue = recevedData[1];
                string upperRangeValue = recevedData[2];
                string alarmLower = recevedData[3];
                string alarmUpper = recevedData[4];
            }
            


        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            lightSensor.instrumentName = "testnavn";
            lightSensor.upperRangeValue = 500;
            lightSensor.lowerRangeValue = 40;
            textBoxDateReceived.Text = Convert.ToString(lightSensor.Span());
        }

        /*private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do You Want To Save Your Data", "CodeJuggler", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes) saveCartToFile();
            else if (dialogResult == DialogResult.Cancel) e.Cancel = true;
            // funker ikke som tiltenkt
        }*/
    }

}
