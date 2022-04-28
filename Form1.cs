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
using System.Threading;


namespace SoftSensConf
{
    public partial class Form1 : Form
    {
        List<float> analogReading = new List<float>();
        List<string> timeStamp = new List<string>();
        Dictionary<string, float> listOfFormatedTimeAndScaledDataNumbers = new Dictionary<string, float>();
        DataAcquisitionUnit dau;
       
        public Form1()
        {
            InitializeComponent();
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());
            comboBoxPort.Text = "--Select--";
            string[] bitRate = new string[] { "1200", "2400", "4800", "9600",
                                              "19200", "38400", "57600", "115200" };
            comboBoxBitRate.Items.AddRange(bitRate);
            comboBoxBitRate.SelectedIndex = comboBoxBitRate.Items.IndexOf("9600");
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            dau = new DataAcquisitionUnit();
            dau.readConfig += readConfigComplete;
            dau.readScaled += readScaledEventComplete;
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
           
            if (isConnected())
            {
                MessageBox.Show("Connected!");
                ChangeConnectionStatusLable();
            }
            else
            {
                MessageBox.Show("Can't connect");
            }


        }
        private bool isConnected()
        {
            return dau.connectToSerialPort(comboBoxPort.Text, int.Parse(comboBoxBitRate.Text)) == true;
        }

        private void ChangeConnectionStatusLable()
        {
            if (!isConnected())
            {
                lblConnetionStatus.BackColor = Color.Green;
                lblConnetionStatus.ForeColor = Color.Green;
                lblConnetionStatus1.BackColor = Color.Green;
                lblConnetionStatus1.ForeColor = Color.Green;
                lblConnetionStatus2.BackColor = Color.Green;
                lblConnetionStatus2.ForeColor = Color.Green;
                lblActiveConectStatus.Text = "Connected";
                return;
            }
            if (isDisconnected())
            {
                lblConnetionStatus.BackColor = Color.Red;
                lblConnetionStatus.ForeColor = Color.Red;
                lblConnetionStatus1.BackColor = Color.Red;
                lblConnetionStatus1.ForeColor = Color.Red;
                lblConnetionStatus2.BackColor = Color.Red;
                lblConnetionStatus2.ForeColor = Color.Red;
                lblActiveConectStatus.Text = "Disconnected";
            }

        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            dau.sendstuff();
        }


        private void readConfigComplete(object sender, List<string> args)
        {
            Console.WriteLine("We made readConfig! UPDATE THE SHIT YO!");
            Console.WriteLine(dau.tagName);
            Console.WriteLine(dau.lowerRangeValue);
            Console.WriteLine(dau.upperRangeValue);
            Console.WriteLine(dau.lowerAlarm);
            Console.WriteLine(dau.upperAlarm);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (isDisconnected())
            {
                MessageBox.Show("Disconnected!");
                ChangeConnectionStatusLable();
            }
            else
            {
                MessageBox.Show("Can't disconnected");
            }
        }
        private bool isDisconnected()
        {
            return dau.disconnectFromSerialport() == true;
        }

        private void btnLoadCurrentConfiguration_Click(object sender, EventArgs e)
        {
            dau.sendCommand("readconf");

        }

        private void checkBoxEnableSignalReceiveMode_CheckedChanged(object sender, EventArgs e)
        {
            dau.sendCommand("readscaled");
        }
        private void readScaledEventComplete(object sender, List<string> scaledValueArgument)
        {
           string scaledValue = scaledValueArgument[0];
            plotGraph(scaledValue);
            
        }
        private void plotGraph(string ScaledValue)
        {
            
        }
    }

}


       