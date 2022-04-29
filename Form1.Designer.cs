namespace SoftSensConf
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.lblConnetionStatus = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblActiveConectStatus = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.textBoxDateReceived = new System.Windows.Forms.TextBox();
            this.lblBitRate = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.comboBoxBitRate = new System.Windows.Forms.ComboBox();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblConnetionStatus1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxLowerAlarm = new System.Windows.Forms.TextBox();
            this.txtBoxUpperAlarm = new System.Windows.Forms.TextBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxLRV = new System.Windows.Forms.TextBox();
            this.txtBoxURV = new System.Windows.Forms.TextBox();
            this.lblUpperAlarm = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLowerAlarm = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblURV = new System.Windows.Forms.Label();
            this.lbltextUpper = new System.Windows.Forms.Label();
            this.lblLRV = new System.Windows.Forms.Label();
            this.lblTextLRV = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNameText = new System.Windows.Forms.Label();
            this.btnLoadFromFile = new System.Windows.Forms.Button();
            this.btnLoadCurrentConfiguration = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label26 = new System.Windows.Forms.Label();
            this.comboBoxTagID = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblConnetionStatus2 = new System.Windows.Forms.Label();
            this.lblAlarmStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxScaledValues = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxRawValues = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkBoxEnableSignalReceiveMode = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnAddInstrumentToDB = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.comboBoxInstrumentFrequency = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.comboBoxInstrumentSensorSettingsID = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxiInstrumentIOType = new System.Windows.Forms.ComboBox();
            this.comboBoxInstrumentMaker = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtBoxInstrumentModel = new System.Windows.Forms.TextBox();
            this.txtBoxInstrumentType = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtBoxinstrumentChannel = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxDAUId = new System.Windows.Forms.ComboBox();
            this.comboBoxInstrumentArea = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBoxInstrumentTagID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAddRDC = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBoxRDCDecription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboboxAreaRDC = new System.Windows.Forms.ComboBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 444);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.lblConnetionStatus);
            this.tabPage1.Controls.Add(this.btnDisconnect);
            this.tabPage1.Controls.Add(this.btnConnect);
            this.tabPage1.Controls.Add(this.lblActiveConectStatus);
            this.tabPage1.Controls.Add(this.lblConnectionStatus);
            this.tabPage1.Controls.Add(this.textBoxDateReceived);
            this.tabPage1.Controls.Add(this.lblBitRate);
            this.tabPage1.Controls.Add(this.lblPort);
            this.tabPage1.Controls.Add(this.comboBoxBitRate);
            this.tabPage1.Controls.Add(this.comboBoxPort);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Serial Port Config";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(668, 402);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Connection Status:";
            // 
            // lblConnetionStatus
            // 
            this.lblConnetionStatus.AutoSize = true;
            this.lblConnetionStatus.BackColor = System.Drawing.Color.Red;
            this.lblConnetionStatus.ForeColor = System.Drawing.Color.Red;
            this.lblConnetionStatus.Location = new System.Drawing.Point(771, 402);
            this.lblConnetionStatus.Name = "lblConnetionStatus";
            this.lblConnetionStatus.Size = new System.Drawing.Size(15, 13);
            this.lblConnetionStatus.TabIndex = 9;
            this.lblConnetionStatus.Text = "D";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(72, 122);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(121, 23);
            this.btnDisconnect.TabIndex = 8;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(72, 93);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(121, 23);
            this.btnConnect.TabIndex = 7;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblActiveConectStatus
            // 
            this.lblActiveConectStatus.AutoSize = true;
            this.lblActiveConectStatus.Location = new System.Drawing.Point(300, 22);
            this.lblActiveConectStatus.Name = "lblActiveConectStatus";
            this.lblActiveConectStatus.Size = new System.Drawing.Size(73, 13);
            this.lblActiveConectStatus.TabIndex = 6;
            this.lblActiveConectStatus.Text = "Disconnected";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Location = new System.Drawing.Point(197, 22);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(97, 13);
            this.lblConnectionStatus.TabIndex = 5;
            this.lblConnectionStatus.Text = "Connection Status:";
            // 
            // textBoxDateReceived
            // 
            this.textBoxDateReceived.Location = new System.Drawing.Point(200, 38);
            this.textBoxDateReceived.Multiline = true;
            this.textBoxDateReceived.Name = "textBoxDateReceived";
            this.textBoxDateReceived.Size = new System.Drawing.Size(459, 359);
            this.textBoxDateReceived.TabIndex = 4;
            // 
            // lblBitRate
            // 
            this.lblBitRate.AutoSize = true;
            this.lblBitRate.Location = new System.Drawing.Point(10, 65);
            this.lblBitRate.Name = "lblBitRate";
            this.lblBitRate.Size = new System.Drawing.Size(48, 13);
            this.lblBitRate.TabIndex = 3;
            this.lblBitRate.Text = "Bit Rate:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(7, 38);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port:";
            // 
            // comboBoxBitRate
            // 
            this.comboBoxBitRate.FormattingEnabled = true;
            this.comboBoxBitRate.Location = new System.Drawing.Point(72, 65);
            this.comboBoxBitRate.Name = "comboBoxBitRate";
            this.comboBoxBitRate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBitRate.TabIndex = 1;
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(72, 38);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPort.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblConnetionStatus1);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.btnSaveToFile);
            this.tabPage2.Controls.Add(this.btnSend);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtBoxLowerAlarm);
            this.tabPage2.Controls.Add(this.txtBoxUpperAlarm);
            this.tabPage2.Controls.Add(this.txtBoxName);
            this.tabPage2.Controls.Add(this.txtBoxLRV);
            this.tabPage2.Controls.Add(this.txtBoxURV);
            this.tabPage2.Controls.Add(this.lblUpperAlarm);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.lblLowerAlarm);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lblURV);
            this.tabPage2.Controls.Add(this.lbltextUpper);
            this.tabPage2.Controls.Add(this.lblLRV);
            this.tabPage2.Controls.Add(this.lblTextLRV);
            this.tabPage2.Controls.Add(this.lblName);
            this.tabPage2.Controls.Add(this.lblNameText);
            this.tabPage2.Controls.Add(this.btnLoadFromFile);
            this.tabPage2.Controls.Add(this.btnLoadCurrentConfiguration);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 418);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Instrument Config";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblConnetionStatus1
            // 
            this.lblConnetionStatus1.AutoSize = true;
            this.lblConnetionStatus1.BackColor = System.Drawing.Color.Red;
            this.lblConnetionStatus1.ForeColor = System.Drawing.Color.Red;
            this.lblConnetionStatus1.Location = new System.Drawing.Point(767, 402);
            this.lblConnetionStatus1.Name = "lblConnetionStatus1";
            this.lblConnetionStatus1.Size = new System.Drawing.Size(15, 13);
            this.lblConnetionStatus1.TabIndex = 26;
            this.lblConnetionStatus1.Text = "D";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(664, 402);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Connection Status:";
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(7, 66);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(151, 23);
            this.btnSaveToFile.TabIndex = 21;
            this.btnSaveToFile.Text = "Save Config To File";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(507, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(275, 201);
            this.btnSend.TabIndex = 20;
            this.btnSend.Text = "Send all configurations";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Current Config:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "New Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Name:";
            // 
            // txtBoxLowerAlarm
            // 
            this.txtBoxLowerAlarm.Location = new System.Drawing.Point(286, 96);
            this.txtBoxLowerAlarm.Name = "txtBoxLowerAlarm";
            this.txtBoxLowerAlarm.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLowerAlarm.TabIndex = 16;
            this.txtBoxLowerAlarm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxUpperAlarm
            // 
            this.txtBoxUpperAlarm.Location = new System.Drawing.Point(286, 119);
            this.txtBoxUpperAlarm.Name = "txtBoxUpperAlarm";
            this.txtBoxUpperAlarm.Size = new System.Drawing.Size(100, 20);
            this.txtBoxUpperAlarm.TabIndex = 15;
            this.txtBoxUpperAlarm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(286, 30);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxName.TabIndex = 14;
            this.txtBoxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxLRV
            // 
            this.txtBoxLRV.Location = new System.Drawing.Point(286, 53);
            this.txtBoxLRV.Name = "txtBoxLRV";
            this.txtBoxLRV.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLRV.TabIndex = 13;
            this.txtBoxLRV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxURV
            // 
            this.txtBoxURV.Location = new System.Drawing.Point(286, 75);
            this.txtBoxURV.Name = "txtBoxURV";
            this.txtBoxURV.Size = new System.Drawing.Size(100, 20);
            this.txtBoxURV.TabIndex = 12;
            this.txtBoxURV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblUpperAlarm
            // 
            this.lblUpperAlarm.AutoSize = true;
            this.lblUpperAlarm.Location = new System.Drawing.Point(423, 122);
            this.lblUpperAlarm.Margin = new System.Windows.Forms.Padding(5);
            this.lblUpperAlarm.Name = "lblUpperAlarm";
            this.lblUpperAlarm.Size = new System.Drawing.Size(25, 13);
            this.lblUpperAlarm.TabIndex = 11;
            this.lblUpperAlarm.Text = "440";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Upper Alarm:";
            // 
            // lblLowerAlarm
            // 
            this.lblLowerAlarm.AutoSize = true;
            this.lblLowerAlarm.Location = new System.Drawing.Point(423, 99);
            this.lblLowerAlarm.Margin = new System.Windows.Forms.Padding(5);
            this.lblLowerAlarm.Name = "lblLowerAlarm";
            this.lblLowerAlarm.Size = new System.Drawing.Size(19, 13);
            this.lblLowerAlarm.TabIndex = 9;
            this.lblLowerAlarm.Text = "40";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Lower Alarm:";
            // 
            // lblURV
            // 
            this.lblURV.AutoSize = true;
            this.lblURV.Location = new System.Drawing.Point(423, 75);
            this.lblURV.Margin = new System.Windows.Forms.Padding(5);
            this.lblURV.Name = "lblURV";
            this.lblURV.Size = new System.Drawing.Size(25, 13);
            this.lblURV.TabIndex = 7;
            this.lblURV.Text = "500";
            // 
            // lbltextUpper
            // 
            this.lbltextUpper.AutoSize = true;
            this.lbltextUpper.Location = new System.Drawing.Point(164, 75);
            this.lbltextUpper.Margin = new System.Windows.Forms.Padding(5);
            this.lbltextUpper.Name = "lbltextUpper";
            this.lbltextUpper.Size = new System.Drawing.Size(104, 13);
            this.lbltextUpper.TabIndex = 6;
            this.lbltextUpper.Text = "Upper Range Value:";
            // 
            // lblLRV
            // 
            this.lblLRV.AutoSize = true;
            this.lblLRV.Location = new System.Drawing.Point(423, 53);
            this.lblLRV.Margin = new System.Windows.Forms.Padding(5);
            this.lblLRV.Name = "lblLRV";
            this.lblLRV.Size = new System.Drawing.Size(13, 13);
            this.lblLRV.TabIndex = 5;
            this.lblLRV.Text = "0";
            // 
            // lblTextLRV
            // 
            this.lblTextLRV.AutoSize = true;
            this.lblTextLRV.Location = new System.Drawing.Point(164, 53);
            this.lblTextLRV.Margin = new System.Windows.Forms.Padding(5);
            this.lblTextLRV.Name = "lblTextLRV";
            this.lblTextLRV.Size = new System.Drawing.Size(104, 13);
            this.lblTextLRV.TabIndex = 4;
            this.lblTextLRV.Text = "Lower Range Value:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(423, 30);
            this.lblName.Margin = new System.Windows.Forms.Padding(5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "C385IT001";
            // 
            // lblNameText
            // 
            this.lblNameText.AutoSize = true;
            this.lblNameText.Location = new System.Drawing.Point(164, 30);
            this.lblNameText.Margin = new System.Windows.Forms.Padding(5);
            this.lblNameText.Name = "lblNameText";
            this.lblNameText.Size = new System.Drawing.Size(38, 13);
            this.lblNameText.TabIndex = 2;
            this.lblNameText.Text = "Name:";
            // 
            // btnLoadFromFile
            // 
            this.btnLoadFromFile.Location = new System.Drawing.Point(7, 37);
            this.btnLoadFromFile.Name = "btnLoadFromFile";
            this.btnLoadFromFile.Size = new System.Drawing.Size(151, 23);
            this.btnLoadFromFile.TabIndex = 1;
            this.btnLoadFromFile.Text = "Load Config From File";
            this.btnLoadFromFile.UseVisualStyleBackColor = true;
            // 
            // btnLoadCurrentConfiguration
            // 
            this.btnLoadCurrentConfiguration.Location = new System.Drawing.Point(7, 7);
            this.btnLoadCurrentConfiguration.Name = "btnLoadCurrentConfiguration";
            this.btnLoadCurrentConfiguration.Size = new System.Drawing.Size(151, 23);
            this.btnLoadCurrentConfiguration.TabIndex = 0;
            this.btnLoadCurrentConfiguration.Text = "Load Current Configuration";
            this.btnLoadCurrentConfiguration.UseVisualStyleBackColor = true;
            this.btnLoadCurrentConfiguration.Click += new System.EventHandler(this.btnLoadCurrentConfiguration_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label26);
            this.tabPage3.Controls.Add(this.comboBoxTagID);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.lblConnetionStatus2);
            this.tabPage3.Controls.Add(this.lblAlarmStatus);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.txtBoxScaledValues);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.txtBoxRawValues);
            this.tabPage3.Controls.Add(this.chart1);
            this.tabPage3.Controls.Add(this.checkBoxEnableSignalReceiveMode);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 418);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Data Monitoring";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(76, 230);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 13);
            this.label26.TabIndex = 13;
            this.label26.Text = "Instrument:";
            // 
            // comboBoxTagID
            // 
            this.comboBoxTagID.FormattingEnabled = true;
            this.comboBoxTagID.Location = new System.Drawing.Point(141, 227);
            this.comboBoxTagID.Name = "comboBoxTagID";
            this.comboBoxTagID.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTagID.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(664, 402);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "Connection Status:";
            // 
            // lblConnetionStatus2
            // 
            this.lblConnetionStatus2.AutoSize = true;
            this.lblConnetionStatus2.BackColor = System.Drawing.Color.Red;
            this.lblConnetionStatus2.ForeColor = System.Drawing.Color.Red;
            this.lblConnetionStatus2.Location = new System.Drawing.Point(767, 402);
            this.lblConnetionStatus2.Name = "lblConnetionStatus2";
            this.lblConnetionStatus2.Size = new System.Drawing.Size(15, 13);
            this.lblConnetionStatus2.TabIndex = 10;
            this.lblConnetionStatus2.Text = "D";
            // 
            // lblAlarmStatus
            // 
            this.lblAlarmStatus.AutoSize = true;
            this.lblAlarmStatus.Location = new System.Drawing.Point(423, 251);
            this.lblAlarmStatus.Name = "lblAlarmStatus";
            this.lblAlarmStatus.Size = new System.Drawing.Size(21, 13);
            this.lblAlarmStatus.TabIndex = 9;
            this.lblAlarmStatus.Text = "Ok";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(350, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Alarm status:";
            // 
            // txtBoxScaledValues
            // 
            this.txtBoxScaledValues.Location = new System.Drawing.Point(179, 273);
            this.txtBoxScaledValues.Multiline = true;
            this.txtBoxScaledValues.Name = "txtBoxScaledValues";
            this.txtBoxScaledValues.Size = new System.Drawing.Size(155, 142);
            this.txtBoxScaledValues.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Online sensor scaled values:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Online sensor raw values:";
            // 
            // txtBoxRawValues
            // 
            this.txtBoxRawValues.Location = new System.Drawing.Point(7, 273);
            this.txtBoxRawValues.Multiline = true;
            this.txtBoxRawValues.Name = "txtBoxRawValues";
            this.txtBoxRawValues.Size = new System.Drawing.Size(155, 142);
            this.txtBoxRawValues.TabIndex = 4;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(7, 7);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Scaled sensor values";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(775, 214);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // checkBoxEnableSignalReceiveMode
            // 
            this.checkBoxEnableSignalReceiveMode.AutoSize = true;
            this.checkBoxEnableSignalReceiveMode.Location = new System.Drawing.Point(268, 231);
            this.checkBoxEnableSignalReceiveMode.Name = "checkBoxEnableSignalReceiveMode";
            this.checkBoxEnableSignalReceiveMode.Size = new System.Drawing.Size(288, 17);
            this.checkBoxEnableSignalReceiveMode.TabIndex = 0;
            this.checkBoxEnableSignalReceiveMode.Text = "Enable signal receive mode and store data in databaes ";
            this.checkBoxEnableSignalReceiveMode.UseVisualStyleBackColor = true;
            this.checkBoxEnableSignalReceiveMode.CheckedChanged += new System.EventHandler(this.checkBoxEnableSignalReceiveMode_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnAddInstrumentToDB);
            this.tabPage4.Controls.Add(this.label25);
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.comboBoxInstrumentFrequency);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.comboBoxInstrumentSensorSettingsID);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.comboBoxiInstrumentIOType);
            this.tabPage4.Controls.Add(this.comboBoxInstrumentMaker);
            this.tabPage4.Controls.Add(this.label20);
            this.tabPage4.Controls.Add(this.label19);
            this.tabPage4.Controls.Add(this.txtBoxInstrumentModel);
            this.tabPage4.Controls.Add(this.txtBoxInstrumentType);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.txtBoxinstrumentChannel);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.comboBoxDAUId);
            this.tabPage4.Controls.Add(this.comboBoxInstrumentArea);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.txtBoxInstrumentTagID);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.btnAddRDC);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.txtBoxRDCDecription);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.ComboboxAreaRDC);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 418);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Database input";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnAddInstrumentToDB
            // 
            this.btnAddInstrumentToDB.Location = new System.Drawing.Point(97, 318);
            this.btnAddInstrumentToDB.Name = "btnAddInstrumentToDB";
            this.btnAddInstrumentToDB.Size = new System.Drawing.Size(121, 23);
            this.btnAddInstrumentToDB.TabIndex = 28;
            this.btnAddInstrumentToDB.Text = "Add Instrument to DB";
            this.btnAddInstrumentToDB.UseVisualStyleBackColor = true;
            this.btnAddInstrumentToDB.Click += new System.EventHandler(this.btnAddInstrumentToDB_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(328, 29);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(85, 13);
            this.label25.TabIndex = 27;
            this.label25.Text = "Add RDC under:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(94, 29);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(111, 13);
            this.label24.TabIndex = 26;
            this.label24.Text = "Add Instrument under:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 299);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 13);
            this.label23.TabIndex = 25;
            this.label23.Text = "Frequency:";
            // 
            // comboBoxInstrumentFrequency
            // 
            this.comboBoxInstrumentFrequency.FormattingEnabled = true;
            this.comboBoxInstrumentFrequency.Location = new System.Drawing.Point(97, 291);
            this.comboBoxInstrumentFrequency.Name = "comboBoxInstrumentFrequency";
            this.comboBoxInstrumentFrequency.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInstrumentFrequency.TabIndex = 24;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 272);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 13);
            this.label22.TabIndex = 23;
            this.label22.Text = "Sensor Setting ID:";
            // 
            // comboBoxInstrumentSensorSettingsID
            // 
            this.comboBoxInstrumentSensorSettingsID.FormattingEnabled = true;
            this.comboBoxInstrumentSensorSettingsID.Location = new System.Drawing.Point(97, 264);
            this.comboBoxInstrumentSensorSettingsID.Name = "comboBoxInstrumentSensorSettingsID";
            this.comboBoxInstrumentSensorSettingsID.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInstrumentSensorSettingsID.TabIndex = 22;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 245);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 13);
            this.label21.TabIndex = 21;
            this.label21.Text = "I / O Type:";
            // 
            // comboBoxiInstrumentIOType
            // 
            this.comboBoxiInstrumentIOType.FormattingEnabled = true;
            this.comboBoxiInstrumentIOType.Location = new System.Drawing.Point(97, 237);
            this.comboBoxiInstrumentIOType.Name = "comboBoxiInstrumentIOType";
            this.comboBoxiInstrumentIOType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxiInstrumentIOType.TabIndex = 20;
            // 
            // comboBoxInstrumentMaker
            // 
            this.comboBoxInstrumentMaker.FormattingEnabled = true;
            this.comboBoxInstrumentMaker.Location = new System.Drawing.Point(97, 210);
            this.comboBoxInstrumentMaker.Name = "comboBoxInstrumentMaker";
            this.comboBoxInstrumentMaker.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInstrumentMaker.TabIndex = 19;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 217);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 18;
            this.label20.Text = "Maker:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 191);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 16;
            this.label19.Text = "Model:";
            // 
            // txtBoxInstrumentModel
            // 
            this.txtBoxInstrumentModel.Location = new System.Drawing.Point(97, 184);
            this.txtBoxInstrumentModel.Name = "txtBoxInstrumentModel";
            this.txtBoxInstrumentModel.Size = new System.Drawing.Size(121, 20);
            this.txtBoxInstrumentModel.TabIndex = 15;
            // 
            // txtBoxInstrumentType
            // 
            this.txtBoxInstrumentType.Location = new System.Drawing.Point(97, 158);
            this.txtBoxInstrumentType.Name = "txtBoxInstrumentType";
            this.txtBoxInstrumentType.Size = new System.Drawing.Size(121, 20);
            this.txtBoxInstrumentType.TabIndex = 14;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 165);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Instrument Type:";
            // 
            // txtBoxinstrumentChannel
            // 
            this.txtBoxinstrumentChannel.Location = new System.Drawing.Point(97, 132);
            this.txtBoxinstrumentChannel.Name = "txtBoxinstrumentChannel";
            this.txtBoxinstrumentChannel.Size = new System.Drawing.Size(121, 20);
            this.txtBoxinstrumentChannel.TabIndex = 12;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 135);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "Channel:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 112);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "DAU ID:";
            // 
            // comboBoxDAUId
            // 
            this.comboBoxDAUId.FormattingEnabled = true;
            this.comboBoxDAUId.Location = new System.Drawing.Point(97, 104);
            this.comboBoxDAUId.Name = "comboBoxDAUId";
            this.comboBoxDAUId.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDAUId.TabIndex = 9;
            // 
            // comboBoxInstrumentArea
            // 
            this.comboBoxInstrumentArea.FormattingEnabled = true;
            this.comboBoxInstrumentArea.Location = new System.Drawing.Point(97, 77);
            this.comboBoxInstrumentArea.Name = "comboBoxInstrumentArea";
            this.comboBoxInstrumentArea.Size = new System.Drawing.Size(121, 21);
            this.comboBoxInstrumentArea.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Instrument Area: ";
            // 
            // txtBoxInstrumentTagID
            // 
            this.txtBoxInstrumentTagID.Location = new System.Drawing.Point(97, 51);
            this.txtBoxInstrumentTagID.Name = "txtBoxInstrumentTagID";
            this.txtBoxInstrumentTagID.Size = new System.Drawing.Size(121, 20);
            this.txtBoxInstrumentTagID.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Instrument tagID:";
            // 
            // btnAddRDC
            // 
            this.btnAddRDC.Location = new System.Drawing.Point(331, 104);
            this.btnAddRDC.Name = "btnAddRDC";
            this.btnAddRDC.Size = new System.Drawing.Size(123, 23);
            this.btnAddRDC.TabIndex = 4;
            this.btnAddRDC.Text = "Add RDC to Database";
            this.btnAddRDC.UseVisualStyleBackColor = true;
            this.btnAddRDC.Click += new System.EventHandler(this.btnAddRDC_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(241, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "RDC Decription:";
            // 
            // txtBoxRDCDecription
            // 
            this.txtBoxRDCDecription.Location = new System.Drawing.Point(331, 78);
            this.txtBoxRDCDecription.Name = "txtBoxRDCDecription";
            this.txtBoxRDCDecription.Size = new System.Drawing.Size(132, 20);
            this.txtBoxRDCDecription.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(241, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Area For RDC: ";
            // 
            // ComboboxAreaRDC
            // 
            this.ComboboxAreaRDC.FormattingEnabled = true;
            this.ComboboxAreaRDC.Location = new System.Drawing.Point(331, 50);
            this.ComboboxAreaRDC.Name = "ComboboxAreaRDC";
            this.ComboboxAreaRDC.Size = new System.Drawing.Size(132, 21);
            this.ComboboxAreaRDC.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(792, 418);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Database view";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "SoftSensConf";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblActiveConectStatus;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label lblBitRate;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox comboBoxBitRate;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Button btnLoadFromFile;
        private System.Windows.Forms.Button btnLoadCurrentConfiguration;
        private System.Windows.Forms.Label lblUpperAlarm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLowerAlarm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblURV;
        private System.Windows.Forms.Label lbltextUpper;
        private System.Windows.Forms.Label lblLRV;
        private System.Windows.Forms.Label lblTextLRV;
        public System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNameText;
        private System.Windows.Forms.TextBox txtBoxURV;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxLowerAlarm;
        private System.Windows.Forms.TextBox txtBoxUpperAlarm;
        public System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxLRV;
        private System.Windows.Forms.Button btnSaveToFile;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtBoxRawValues;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckBox checkBoxEnableSignalReceiveMode;
        private System.Windows.Forms.Label lblAlarmStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxScaledValues;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblConnetionStatus;
        private System.Windows.Forms.Label lblConnetionStatus1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblConnetionStatus2;
        public System.Windows.Forms.TextBox textBoxDateReceived;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnAddRDC;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBoxRDCDecription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboboxAreaRDC;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtBoxInstrumentModel;
        private System.Windows.Forms.TextBox txtBoxInstrumentType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtBoxinstrumentChannel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxDAUId;
        private System.Windows.Forms.ComboBox comboBoxInstrumentArea;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBoxInstrumentTagID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAddInstrumentToDB;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox comboBoxInstrumentFrequency;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox comboBoxInstrumentSensorSettingsID;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxiInstrumentIOType;
        private System.Windows.Forms.ComboBox comboBoxInstrumentMaker;
        private System.Windows.Forms.ComboBox comboBoxTagID;
        private System.Windows.Forms.Label label26;
    }
}

