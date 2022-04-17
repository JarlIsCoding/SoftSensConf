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
            dau = new DataAcquisitionUnit(comboBoxPort.Text, int.Parse(comboBoxBitRate.Text));
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (dau.connectToSerialPort(comboBoxPort.Text, int.Parse(comboBoxBitRate.Text)))
            {
                MessageBox.Show("Connected!");
            }
            else
            {
                MessageBox.Show("Can't connect");
            }

            
        }
    }
}


       