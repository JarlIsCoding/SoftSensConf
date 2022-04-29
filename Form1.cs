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
using Timer = System.Windows.Forms.Timer;

namespace SoftSensConf
{
    public partial class Form1 : Form
    {

        List<float> analogReading = new List<float>();
        List<string> timeStamp = new List<string>();
        Dictionary<string, float> listOfFormatedTimeAndScaledDataNumbers = new Dictionary<string, float>();
        DataAcquisitionUnit dau;
        Timer readScaledTimer;
        RemoteDataCollector remoteDataCollector;
        Databaseconnection dbconnection = new Databaseconnection();


        public Form1()
        {
            InitializeComponent();
            readScaledTimer = new Timer();
            readScaledTimer.Interval = 5000;
            readScaledTimer.Tick += readScaledTimerTick;
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
            dau.readStatus += readStatusEventComplete;
            dau.readraw += readRawEventComplete;
            dbconnection.connect();
            addAreaToComboBox();
            addInstrumentAreaToComboBox();
            addMakerToComboBox();
            addDAUToComboBox();
            addIOTypeToComboBox();
            addSensorSettingsToComboBox();
            addFrequensyToComboBox();
            addTagIdToComboBox();
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


        private void readConfigComplete(object sender, bool TrueIfComplete)
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
            bool result = dau.sendCommand("readconf");
            if (!result) MessageBox.Show("Something went wrong, is the serial port open?");

        }

        private void checkBoxEnableSignalReceiveMode_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxTagID.SelectedIndex != -1)
            {
                bool isReadData = checkBoxEnableSignalReceiveMode.Checked;
                readScaledTimer.Enabled = isReadData;
                return;
            }
            if (!checkBoxEnableSignalReceiveMode.Checked) return;
            checkBoxEnableSignalReceiveMode.Checked = false;
            MessageBox.Show("Vennligst velg et instrument å lagre data på!");
        }
        private void readScaledEventComplete(object sender, List<string> scaledValueArgument)
        {
           string scaledValue = scaledValueArgument[0];
            plotGraph(scaledValue);
            
            appendTextToTextBox(scaledValue, txtBoxScaledValues);

        }
        private void readStatusEventComplete(object sender, List<string> alarmStatus)
        {
            string alarmValue = alarmStatus[0];
            changeAlarmLable(alarmValue);
            appendDataToDataLogTableDatabase();

        }

        private void changeAlarmLable(string alarmValue)
        {
            lblAlarmStatus.Invoke((MethodInvoker)delegate
            {
                lblAlarmStatus.Text = alarmValue;
            });
        }
        private void readRawEventComplete(object sender, List<string> rawValue)
        {
            string rawValuestring = rawValue[0];
            appendTextToTextBox(rawValuestring, txtBoxRawValues);
        }

        private void appendTextToTextBox(string valueString, TextBox txtBox)
        {

            txtBox.Invoke((MethodInvoker)delegate
            {
                txtBox.AppendText("Value:" + valueString);
                txtBox.AppendText(Environment.NewLine);
            });
           

        }

        private void plotGraph(string scaledValue)
        {
            float scaledDataNumber = float.Parse(scaledValue, CultureInfo.InvariantCulture);
            analogReading.Add(scaledDataNumber);
            DateTime now = DateTime.Now;
            string formattedTime = now.Hour + ":" + now.Minute + ":" + now.Second;
            timeStamp.Add(formattedTime);
            

            chart1.Invoke((MethodInvoker)delegate
            {
            chart1.ChartAreas[0].AxisX.Title = "Time";
            chart1.ChartAreas[0].AxisY.Title = "Scaled Value";
            chart1.Series["Scaled sensor values"].Points.DataBindXY(timeStamp, analogReading);
            chart1.Invalidate();
            });

            dataAppenderForCart1(formattedTime, scaledDataNumber);
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

        private void readScaledTimerTick(object sender, EventArgs e)
        {
            dau.sendCommand("readscaled");
        }

        private void addAreaToComboBox()
        {
            string areaTable = "AREA_LOCATION";
            string collum = "AreaID";
            string order = "ASC";

            List<string> areaComboBoxList = dbconnection.selectQueryAsList(areaTable, collum, order);
            areaComboBoxList.ForEach(item => ComboboxAreaRDC.Items.Add(item));
        }
        private void addTagIdToComboBox()
        {
            string tagIdTable = "INSTRUMENT";
            string collum = "TagID";
            string order = "ASC";

            List<string> tagIdComboBoxList = dbconnection.selectQueryAsList(tagIdTable, collum, order);
            tagIdComboBoxList.ForEach(item =>  comboBoxTagID.Items.Add(item));
        }

        private void btnAddRDC_Click(object sender, EventArgs e)
        {
            string RDCDecription = txtBoxRDCDecription.Text;
            string RDCDecriptionCollumname = "Descripon";
            string AreaID = ComboboxAreaRDC.SelectedItem.ToString();
            string areaIdCollumName = "AreaCode";
            string Table = "REMOTE_DATA_COLLECTOR";
            dbconnection.insertQueryForRDC(Table, areaIdCollumName, AreaID, RDCDecriptionCollumname, RDCDecription);
        }
        private void addInstrumentAreaToComboBox()
        {
            string areaTable = "AREA_LOCATION";
            string collum = "AreaID";
            string order = "ASC";

            List<string> areaComboBoxList = dbconnection.selectQueryAsList(areaTable, collum, order);
            areaComboBoxList.ForEach(item => comboBoxInstrumentArea.Items.Add(item));
        }
        private void addDAUToComboBox()
        {
            string DAUTable = "DATA_ACQUISITION_UNIT";
            string collum = "DataAcquisitionUnitID";
            string order = "ASC";

            List<string> dauComboBoxList = dbconnection.selectQueryAsList(DAUTable, collum, order);
            dauComboBoxList.ForEach(item => comboBoxDAUId.Items.Add(item));
        }
        private void addMakerToComboBox()
        {
            string makerTable = "MAKER";
            string collum = "MakerID";
            string order = "ASC";

            List<string> makerComboBoxList = dbconnection.selectQueryAsList(makerTable, collum, order);
            makerComboBoxList.ForEach(item => comboBoxInstrumentMaker.Items.Add(item));
        }
        private void addIOTypeToComboBox()
        {
            string ioTypeTable = "IO_Type";
            string collum = "IO_TypeID";
            string order = "ASC";

            List<string> ioTypeComboBoxList = dbconnection.selectQueryAsList(ioTypeTable, collum, order);
            ioTypeComboBoxList.ForEach(item => comboBoxiInstrumentIOType.Items.Add(item));
        }
        private void addSensorSettingsToComboBox()
        {
            string sensorSettingTable = "SENSOR_SETTINGS";
            string collum = "SensorSettingsID";
            string order = "ASC";

            List<string> sensorSettingsComboBoxList = dbconnection.selectQueryAsList(sensorSettingTable, collum, order);
            sensorSettingsComboBoxList.ForEach(item => comboBoxInstrumentSensorSettingsID.Items.Add(item));
        }
        private void addFrequensyToComboBox()
        {
            string[] bitRate = new string[] { "1200", "2400", "4800", "9600",
                                              "19200", "38400", "57600", "115200" };
            comboBoxInstrumentFrequency.Items.AddRange(bitRate);
            comboBoxInstrumentFrequency.SelectedIndex = comboBoxBitRate.Items.IndexOf("9600");
        }
        private void btnAddInstrumentToDB_Click(object sender, EventArgs e)
        {
            appendDataToInstrumentTableDatabase();
        }

        private void appendDataToInstrumentTableDatabase()
        {
            string Table = "INSTRUMENT";
            string instrumentTagIdCollumename = "TagID";
            string instrumentAreaIdCollumename = "AreaID";
            string instrumentDAUIDCollumename = "DataAcquisitionUnitID";
            string instrumentChannelCollumename = "Channel";
            string instrumentTypeCollumename = "InstrumentDescription";
            string instrumentModelCollumename = "Model";
            string instrumentMakerCollumename = "MakerID";
            string isntrumentIOTyprCollumename = "IO_TypeID";
            string instrumentSensorSettingsCollumename = "SensorSettingsID";
            string instrumentFrequencyCollumename = "Frequency";

            string instrumentTagIdValue = txtBoxInstrumentTagID.Text;
            string instrumentAreaIdValue = comboBoxInstrumentArea.SelectedItem.ToString();
            string instrumentDAUIDValue = comboBoxDAUId.SelectedItem.ToString();
            string instrumentChannelValue = txtBoxinstrumentChannel.Text;
            string instrumentTypeValue = txtBoxInstrumentType.Text;
            string instrumentModelValue = txtBoxInstrumentModel.Text;
            string instrumentMakerValue = comboBoxInstrumentMaker.SelectedItem.ToString();
            string isntrumentIOTyprValue = comboBoxiInstrumentIOType.SelectedItem.ToString();
            string instrumentSensorSettingsValue = comboBoxInstrumentSensorSettingsID.SelectedItem.ToString();
            string instrumentFrequencyValue = comboBoxInstrumentFrequency.SelectedItem.ToString();

            dbconnection.insertQueryForInstrument(Table, instrumentTagIdCollumename, instrumentAreaIdCollumename, instrumentDAUIDCollumename,
                instrumentChannelCollumename, instrumentTypeCollumename, instrumentModelCollumename, instrumentMakerCollumename,
                isntrumentIOTyprCollumename, instrumentSensorSettingsCollumename, instrumentFrequencyCollumename, instrumentTagIdValue,
                instrumentAreaIdValue, instrumentDAUIDValue, instrumentChannelValue, instrumentTypeValue, instrumentModelValue,
                instrumentMakerValue, isntrumentIOTyprValue, instrumentSensorSettingsValue, instrumentFrequencyValue);
        }
        private void appendDataToDataLogTableDatabase()
        {
            string Table = "DATA_LOG";
            string datalogErrorCodeColumnName = "ErrorCode";
            string datalogRawValueColumnName = "RawValue";
            string datalogScaledValueColumnName = "ScaledValue";
            string datalogTimeStampColumnName = "TimeStamp";
            string datalogTagIdColumnName = "TagID";

            int errorStatusvalue = dau.alarmStatusValue;
            int rawValue = dau.rawValue;
            float scaledValue = dau.scaledValue;

            DateTime dateTimeNow = DateTime.Now;
            string tagIdValue = "";

            comboBoxTagID.Invoke((MethodInvoker)delegate { tagIdValue = comboBoxTagID.Text; });

            dbconnection.insertQueryForDataLog(Table, datalogErrorCodeColumnName, datalogRawValueColumnName, 
                                               datalogScaledValueColumnName, datalogTimeStampColumnName, datalogTagIdColumnName, errorStatusvalue,
                                               rawValue, scaledValue, dateTimeNow, tagIdValue);
            
        }

        
    }

}


       