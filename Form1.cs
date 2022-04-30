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
        Dictionary<string, float> dictionaryOfFormatedTimeAndScaledDataNumbers = new Dictionary<string, float>();
        DataAcquisitionUnit dau;
        Timer readScaledTimer;
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
            startListeners();
            loadDatafromDatabaseToCombobox();
        }

        private void loadDatafromDatabaseToCombobox()
        {
            addAreaToComboBox();
            addInstrumentAreaToComboBox();
            addMakerToComboBox();
            addDAUToComboBox();
            addIOTypeToComboBox();
            addSensorSettingsToComboBox();
            addFrequensyToComboBox();
            addTagIdToComboBox();
        }

        private void startListeners()
        {
            dau.writeconf += writeConfigEventComplete;
            dau.readConfig += readConfigComplete;
            dau.readScaled += readScaledEventComplete;
            dau.readStatus += readStatusEventComplete;
            dau.readraw += readRawEventComplete;
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {

            if (isConnected())
            {
                MessageBox.Show("Connected!");
                ChangeConnectionStatusLable();
                dau.sendCommand("readconf");
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
            formatDataAndSetValues();
            string password = askForPassword();
            if (password == "") return;
            dau.sendCommand(buildWriteConfMessage(password));
        }

        private void formatDataAndSetValues()
        {
            string tagname = txtBoxName.Text.Length > 0 ? txtBoxName.Text : lblName.Text;
            float lrv = float.TryParse(txtBoxLRV.Text, out float reslrv) ? reslrv : float.Parse(lblLRV.Text);
            float urv = float.TryParse(txtBoxURV.Text, out float resurv) ? resurv : float.Parse(lblURV.Text);
            int al = int.TryParse(txtBoxLowerAlarm.Text, out int resal) ? resal : int.Parse(lblLowerAlarm.Text);
            int ul = int.TryParse(txtBoxUpperAlarm.Text, out int resul) ? resul : int.Parse(lblUpperAlarm.Text);

            dau.setValues(tagname, lrv, urv, al, ul);
        }

        private string askForPassword()
        {
            string input = "";
            DialogResult result = PasswordDialog.ShowInputDialog(ref input);
            if (result == DialogResult.Cancel) return "";
            return input;
        }

        private string buildWriteConfMessage(string password)
        {
            string name = dau.tagName;
            string lowerRangeValue = dau.lowerRangeValue.ToString();
            string upperRangeValue = dau.upperRangeValue.ToString();
            string lowerAlarm = dau.lowerAlarm.ToString();
            string upperAlarm = dau.upperAlarm.ToString();
            StringBuilder writeconfString = new StringBuilder();
            writeconfString.Append("writeconf");
            writeconfString.Append(">");
            writeconfString.Append(password);
            writeconfString.Append(">");
            writeconfString.Append(name);
            writeconfString.Append(";");
            writeconfString.Append(lowerRangeValue);
            writeconfString.Append(";");
            writeconfString.Append(upperRangeValue);
            writeconfString.Append(";");
            writeconfString.Append(lowerAlarm);
            writeconfString.Append(";");
            writeconfString.Append(upperAlarm);
            return writeconfString.ToString();
        }


        private void readConfigComplete(object sender, List<string> listOfConfigsValues)
        {

            Console.WriteLine(sender.ToString());
            Console.WriteLine("We made readConfig! UPDATE THE SHIT YO!");
            lblName.Invoke((MethodInvoker)delegate { lblName.Text = listOfConfigsValues[0]; });
            lblLRV.Invoke((MethodInvoker)delegate { lblLRV.Text = listOfConfigsValues[1]; });
            lblURV.Invoke((MethodInvoker)delegate { lblURV.Text = listOfConfigsValues[2]; });
            lblLowerAlarm.Invoke((MethodInvoker)delegate { lblLowerAlarm.Text = listOfConfigsValues[3]; });
            lblUpperAlarm.Invoke((MethodInvoker)delegate { lblUpperAlarm.Text = listOfConfigsValues[4]; });

        }
        private void writeConfigEventComplete(object sender, bool result)
        {
            if (result)
            {
                clearInputs();
                return;
            }

            MessageBox.Show("Wrong password browski");
        }

        private void clearInputs()
        {
            lblName.Invoke((MethodInvoker)delegate { txtBoxName.Clear(); });
            txtBoxLRV.Invoke((MethodInvoker)delegate { txtBoxLRV.Clear(); });
            txtBoxURV.Invoke((MethodInvoker)delegate { txtBoxURV.Clear(); });
            txtBoxLowerAlarm.Invoke((MethodInvoker)delegate { txtBoxLowerAlarm.Clear(); });
            txtBoxUpperAlarm.Invoke((MethodInvoker)delegate { txtBoxUpperAlarm.Clear(); });
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
        private void readScaledEventComplete(object sender, string scaledValue)
        {
            
            plotGraph(scaledValue);

            appendTextToTextBox(scaledValue, txtBoxScaledValues);

        }
        private void readStatusEventComplete(object sender, string statusValue)
        {
            changeAlarmLable(statusValue);
            appendDataToDataLogTableDatabase();

        }

        private void changeAlarmLable(string alarmValue)
        {
            lblAlarmStatus.Invoke((MethodInvoker)delegate
            {
                lblAlarmStatus.Text = alarmValue;
            });
        }
        private void readRawEventComplete(object sender, string rawValue)
        {
            appendTextToTextBox(rawValue, txtBoxRawValues);
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

            //dataAppenderForCart1(formattedTime, scaledDataNumber);
            //Bruktes til å adde data til en dictionary for å lagre det til fil. denne funksjonener er ikke implementert i nye programmet enda.  
        }
        private void dataAppenderForCart1(string formattedTime, float scaledDataNumber)
        {
            try
            {
                dictionaryOfFormatedTimeAndScaledDataNumbers.Add(formattedTime, scaledDataNumber);
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
            if (ComboboxAreaRDC.Items.Count > 0) ComboboxAreaRDC.SelectedIndex = 0;
        }
        private void addTagIdToComboBox()
        {
            string tagIdTable = "INSTRUMENT";
            string collum = "TagID";
            string order = "ASC";

            List<string> tagIdComboBoxList = dbconnection.selectQueryAsList(tagIdTable, collum, order);
            tagIdComboBoxList.ForEach(item => comboBoxTagID.Items.Add(item));
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
            if (comboBoxInstrumentArea.Items.Count > 0) comboBoxInstrumentArea.SelectedIndex = 0;



        }
        private void addDAUToComboBox()
        {
            string DAUTable = "DATA_ACQUISITION_UNIT";
            string collum = "DataAcquisitionUnitID";
            string order = "ASC";

            List<string> dauComboBoxList = dbconnection.selectQueryAsList(DAUTable, collum, order);
            dauComboBoxList.ForEach(item => comboBoxDAUId.Items.Add(item));
            if (comboBoxDAUId.Items.Count > 0) comboBoxDAUId.SelectedIndex = 0;
        }
        private void addMakerToComboBox()
        {
            string makerTable = "MAKER";
            string collum = "MakerID";
            string order = "ASC";

            List<string> makerComboBoxList = dbconnection.selectQueryAsList(makerTable, collum, order);
            makerComboBoxList.ForEach(item => comboBoxInstrumentMaker.Items.Add(item));
            if (comboBoxInstrumentMaker.Items.Count > 0) comboBoxInstrumentMaker.SelectedIndex = 0;
        }
        private void addIOTypeToComboBox()
        {
            string ioTypeTable = "IO_Type";
            string collum = "IO_TypeID";
            string order = "ASC";

            List<string> ioTypeComboBoxList = dbconnection.selectQueryAsList(ioTypeTable, collum, order);
            ioTypeComboBoxList.ForEach(item => comboBoxiInstrumentIOType.Items.Add(item));
            if (comboBoxiInstrumentIOType.Items.Count > 0) comboBoxiInstrumentIOType.SelectedIndex = 0;
        }
        private void addSensorSettingsToComboBox()
        {
            string sensorSettingTable = "SENSOR_SETTINGS";
            string collum = "SensorSettingsID";
            string order = "ASC";

            List<string> sensorSettingsComboBoxList = dbconnection.selectQueryAsList(sensorSettingTable, collum, order);
            sensorSettingsComboBoxList.ForEach(item => comboBoxInstrumentSensorSettingsID.Items.Add(item));
            if (comboBoxInstrumentSensorSettingsID.Items.Count > 0) comboBoxInstrumentSensorSettingsID.SelectedIndex = 0;
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
            if (checkIfAlldataIsAppended()) 
            {
                appendDataToInstrumentTableDatabase();
                return;
            }
            MessageBox.Show("fyll inn riktig data i alle feltene");

        }

        private bool checkIfAlldataIsAppended()
        {
            if (txtBoxInstrumentTagID.Text.Length == 0) return false;
            if (comboBoxInstrumentArea.Text.Length == 0) return false;
            if (comboBoxDAUId.Text.Length == 0) return false;
            if (txtBoxinstrumentChannel.Text.Length == 0) return false;
            if (txtBoxInstrumentType.Text.Length == 0) return false;
            if (txtBoxInstrumentModel.Text.Length == 0) return false;
            if (comboBoxInstrumentMaker.Text.Length == 0) return false;
            if (comboBoxiInstrumentIOType.Text.Length == 0) return false;
            if (comboBoxInstrumentSensorSettingsID.Text.Length == 0) return false;
            if (comboBoxInstrumentFrequency.Text.Length == 0) return false;
            return true;


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

        private void btnAddCurrentConfogToDB_Click(object sender, EventArgs e)
        {
            string table = "SENSOR_SETTINGS";
            string alarmLowLimitColumnName = "AlarmLowLimit";
            string alarmUpperLimitColumnName = "AlarmUpperLimit";
            string lowerRangeValueColumnName = "LowerRangeValue";
            string upperRangeValueColumnName = "UpperRangeValue";
            string descriptionColumnName = "Description";

            string alarmLowLimitValue = lblLowerAlarm.Text;
            string alarmUpperLimitValue = lblUpperAlarm.Text;
            string lowerRangeValue = lblLRV.Text;
            string upperRangeValue = lblURV.Text;
            string descriptionvalue = txtBoxDecriptionCurrentConfig.Text;

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add(alarmLowLimitColumnName, alarmLowLimitValue);
            dict.Add(alarmUpperLimitColumnName, alarmUpperLimitValue);
            dict.Add(lowerRangeValueColumnName, lowerRangeValue);
            dict.Add(upperRangeValueColumnName, upperRangeValue);
            dict.Add(descriptionColumnName, "'" + descriptionvalue + "'");
            dbconnection.insertConfigWithDictionary(table, dict);

        }


        private void btnTestReadscaled_Click(object sender, EventArgs e)
        {
            dau.sendCommand("readscaled");
        }

        private void tabControl1_Selecting_1(object sender, TabControlCancelEventArgs e)
        {
            dataGridViewInstrument.DataSource = dbconnection.getInstrumentTableInGrid();
        }
    }
}


       