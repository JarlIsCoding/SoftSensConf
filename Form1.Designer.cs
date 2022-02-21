﻿namespace SoftSensConf
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblActiveConectStatus = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.textBoxDateReceived = new System.Windows.Forms.TextBox();
            this.lblBitRate = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.comboBoxBitRate = new System.Windows.Forms.ComboBox();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 444);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
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
            // btnSaveToFile
            // 
            this.btnSaveToFile.Location = new System.Drawing.Point(7, 66);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(151, 23);
            this.btnSaveToFile.TabIndex = 21;
            this.btnSaveToFile.Text = "Save To File";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(507, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(275, 400);
            this.btnSend.TabIndex = 20;
            this.btnSend.Text = "Send all ";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Value:";
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
            this.lblUpperAlarm.Location = new System.Drawing.Point(440, 122);
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
            this.lblLowerAlarm.Location = new System.Drawing.Point(440, 99);
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
            this.lblURV.Location = new System.Drawing.Point(440, 75);
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
            this.lblLRV.Location = new System.Drawing.Point(440, 53);
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
            this.lblName.Location = new System.Drawing.Point(440, 30);
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
            this.btnLoadFromFile.Text = "Load From File";
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
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 418);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Current Values";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxDateReceived;
        private System.Windows.Forms.Label lblBitRate;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox comboBoxBitRate;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.IO.Ports.SerialPort serialPort1;
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
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNameText;
        private System.Windows.Forms.TextBox txtBoxURV;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxLowerAlarm;
        private System.Windows.Forms.TextBox txtBoxUpperAlarm;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxLRV;
        private System.Windows.Forms.Button btnSaveToFile;
    }
}

