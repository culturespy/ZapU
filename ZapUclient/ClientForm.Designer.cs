namespace ZapUclient
{
    partial class ClientForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.AddressText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TCPPortNumber = new System.Windows.Forms.NumericUpDown();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PadRadio4 = new System.Windows.Forms.RadioButton();
            this.PadRadio3 = new System.Windows.Forms.RadioButton();
            this.PadRadio2 = new System.Windows.Forms.RadioButton();
            this.PadRadio1 = new System.Windows.Forms.RadioButton();
            this.StickSensitivityNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.FeedbackB = new System.Windows.Forms.TrackBar();
            this.FeedbackA = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ModeText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.ShoulderMinimumNumeric = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.ShoulderSensitivityNumeric = new System.Windows.Forms.NumericUpDown();
            this.InputTriggersRadio = new System.Windows.Forms.RadioButton();
            this.InputSticksRadio = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.FeedbackM = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AmplitudePlot = new ScottPlot.FormsPlot();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TCPPortNumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StickSensitivityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackA)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShoulderMinimumNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShoulderSensitivityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackM)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host";
            // 
            // AddressText
            // 
            this.AddressText.Location = new System.Drawing.Point(41, 19);
            this.AddressText.Name = "AddressText";
            this.AddressText.Size = new System.Drawing.Size(75, 20);
            this.AddressText.TabIndex = 1;
            this.AddressText.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // TCPPortNumber
            // 
            this.TCPPortNumber.Location = new System.Drawing.Point(154, 19);
            this.TCPPortNumber.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.TCPPortNumber.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.TCPPortNumber.Name = "TCPPortNumber";
            this.TCPPortNumber.Size = new System.Drawing.Size(75, 20);
            this.TCPPortNumber.TabIndex = 4;
            this.TCPPortNumber.Value = new decimal(new int[] {
            6969,
            0,
            0,
            0});
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(242, 19);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 7;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "B";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PadRadio4);
            this.groupBox1.Controls.Add(this.PadRadio3);
            this.groupBox1.Controls.Add(this.PadRadio2);
            this.groupBox1.Controls.Add(this.PadRadio1);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(88, 73);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gamepads";
            // 
            // PadRadio4
            // 
            this.PadRadio4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PadRadio4.AutoSize = true;
            this.PadRadio4.Location = new System.Drawing.Point(43, 43);
            this.PadRadio4.Name = "PadRadio4";
            this.PadRadio4.Size = new System.Drawing.Size(31, 17);
            this.PadRadio4.TabIndex = 3;
            this.PadRadio4.Tag = "4";
            this.PadRadio4.Text = "4";
            this.PadRadio4.UseVisualStyleBackColor = true;
            this.PadRadio4.CheckedChanged += new System.EventHandler(this.PadRadioChange);
            // 
            // PadRadio3
            // 
            this.PadRadio3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PadRadio3.AutoSize = true;
            this.PadRadio3.Location = new System.Drawing.Point(6, 43);
            this.PadRadio3.Name = "PadRadio3";
            this.PadRadio3.Size = new System.Drawing.Size(31, 17);
            this.PadRadio3.TabIndex = 2;
            this.PadRadio3.Tag = "3";
            this.PadRadio3.Text = "3";
            this.PadRadio3.UseVisualStyleBackColor = true;
            this.PadRadio3.CheckedChanged += new System.EventHandler(this.PadRadioChange);
            // 
            // PadRadio2
            // 
            this.PadRadio2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PadRadio2.AutoSize = true;
            this.PadRadio2.Location = new System.Drawing.Point(44, 20);
            this.PadRadio2.Name = "PadRadio2";
            this.PadRadio2.Size = new System.Drawing.Size(31, 17);
            this.PadRadio2.TabIndex = 1;
            this.PadRadio2.Tag = "2";
            this.PadRadio2.Text = "2";
            this.PadRadio2.UseVisualStyleBackColor = true;
            this.PadRadio2.CheckedChanged += new System.EventHandler(this.PadRadioChange);
            // 
            // PadRadio1
            // 
            this.PadRadio1.AutoSize = true;
            this.PadRadio1.Checked = true;
            this.PadRadio1.Location = new System.Drawing.Point(7, 20);
            this.PadRadio1.Name = "PadRadio1";
            this.PadRadio1.Size = new System.Drawing.Size(31, 17);
            this.PadRadio1.TabIndex = 0;
            this.PadRadio1.TabStop = true;
            this.PadRadio1.Tag = "1";
            this.PadRadio1.Text = "1";
            this.PadRadio1.UseVisualStyleBackColor = true;
            this.PadRadio1.CheckedChanged += new System.EventHandler(this.PadRadioChange);
            // 
            // StickSensitivityNumeric
            // 
            this.StickSensitivityNumeric.Location = new System.Drawing.Point(241, 19);
            this.StickSensitivityNumeric.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.StickSensitivityNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StickSensitivityNumeric.Name = "StickSensitivityNumeric";
            this.StickSensitivityNumeric.Size = new System.Drawing.Size(47, 20);
            this.StickSensitivityNumeric.TabIndex = 13;
            this.StickSensitivityNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.StickSensitivityNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Stick Sensitivitiy";
            // 
            // FeedbackB
            // 
            this.FeedbackB.Location = new System.Drawing.Point(57, 32);
            this.FeedbackB.Maximum = 255;
            this.FeedbackB.Name = "FeedbackB";
            this.FeedbackB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FeedbackB.Size = new System.Drawing.Size(45, 190);
            this.FeedbackB.TabIndex = 16;
            this.FeedbackB.TickFrequency = 25;
            // 
            // FeedbackA
            // 
            this.FeedbackA.Location = new System.Drawing.Point(6, 32);
            this.FeedbackA.Maximum = 255;
            this.FeedbackA.Name = "FeedbackA";
            this.FeedbackA.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FeedbackA.Size = new System.Drawing.Size(45, 190);
            this.FeedbackA.TabIndex = 15;
            this.FeedbackA.TickFrequency = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 568);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Messages";
            // 
            // MessageText
            // 
            this.MessageText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageText.Location = new System.Drawing.Point(12, 584);
            this.MessageText.Multiline = true;
            this.MessageText.Name = "MessageText";
            this.MessageText.ReadOnly = true;
            this.MessageText.Size = new System.Drawing.Size(415, 79);
            this.MessageText.TabIndex = 23;
            this.MessageText.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Mode:";
            // 
            // ModeText
            // 
            this.ModeText.Location = new System.Drawing.Point(66, 227);
            this.ModeText.Name = "ModeText";
            this.ModeText.ReadOnly = true;
            this.ModeText.Size = new System.Drawing.Size(100, 20);
            this.ModeText.TabIndex = 25;
            this.ModeText.TabStop = false;
            this.ModeText.Text = "UNKNOWN";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.ShoulderMinimumNumeric);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.ShoulderSensitivityNumeric);
            this.groupBox2.Controls.Add(this.InputTriggersRadio);
            this.groupBox2.Controls.Add(this.StickSensitivityNumeric);
            this.groupBox2.Controls.Add(this.InputSticksRadio);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(100, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 98);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Mode";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(132, 72);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 13);
            this.label20.TabIndex = 52;
            this.label20.Text = "Shoulder Minimum";
            // 
            // ShoulderMinimumNumeric
            // 
            this.ShoulderMinimumNumeric.Location = new System.Drawing.Point(241, 70);
            this.ShoulderMinimumNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ShoulderMinimumNumeric.Name = "ShoulderMinimumNumeric";
            this.ShoulderMinimumNumeric.Size = new System.Drawing.Size(47, 20);
            this.ShoulderMinimumNumeric.TabIndex = 51;
            this.ShoulderMinimumNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(124, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 13);
            this.label16.TabIndex = 50;
            this.label16.Text = "Shoulder Sensitivity";
            // 
            // ShoulderSensitivityNumeric
            // 
            this.ShoulderSensitivityNumeric.Location = new System.Drawing.Point(241, 44);
            this.ShoulderSensitivityNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ShoulderSensitivityNumeric.Name = "ShoulderSensitivityNumeric";
            this.ShoulderSensitivityNumeric.Size = new System.Drawing.Size(47, 20);
            this.ShoulderSensitivityNumeric.TabIndex = 49;
            this.ShoulderSensitivityNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ShoulderSensitivityNumeric.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // InputTriggersRadio
            // 
            this.InputTriggersRadio.AutoSize = true;
            this.InputTriggersRadio.Location = new System.Drawing.Point(8, 44);
            this.InputTriggersRadio.Name = "InputTriggersRadio";
            this.InputTriggersRadio.Size = new System.Drawing.Size(108, 17);
            this.InputTriggersRadio.TabIndex = 2;
            this.InputTriggersRadio.Text = "Shoulder Triggers";
            this.InputTriggersRadio.UseVisualStyleBackColor = true;
            // 
            // InputSticksRadio
            // 
            this.InputSticksRadio.AutoSize = true;
            this.InputSticksRadio.Checked = true;
            this.InputSticksRadio.Location = new System.Drawing.Point(8, 19);
            this.InputSticksRadio.Name = "InputSticksRadio";
            this.InputSticksRadio.Size = new System.Drawing.Size(90, 17);
            this.InputSticksRadio.TabIndex = 1;
            this.InputSticksRadio.TabStop = true;
            this.InputSticksRadio.Text = "Analog Sticks";
            this.InputSticksRadio.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(118, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "MA";
            // 
            // FeedbackM
            // 
            this.FeedbackM.Location = new System.Drawing.Point(121, 31);
            this.FeedbackM.Maximum = 255;
            this.FeedbackM.Minimum = 128;
            this.FeedbackM.Name = "FeedbackM";
            this.FeedbackM.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FeedbackM.Size = new System.Drawing.Size(45, 190);
            this.FeedbackM.TabIndex = 27;
            this.FeedbackM.TickFrequency = 25;
            this.FeedbackM.Value = 128;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(225, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "X - PANIC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(306, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "B - Intense";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label8.Location = new System.Drawing.Point(260, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "A - Waves";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "D-Pad Up/Down - Multi-Adjust";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 177);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(190, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Multi-Adjust works differently per mode.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 203);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(194, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Intense - Lower MA is higher frequency.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 190);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(395, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Waves - Higher MA is higher frequency and faster cycle through the wave pattern.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label17.Location = new System.Drawing.Point(260, 135);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "Y - Input Mode";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DisconnectButton);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.AddressText);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.TCPPortNumber);
            this.groupBox3.Controls.Add(this.ConnectButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(415, 54);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Network Connection";
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(334, 19);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(75, 23);
            this.DisconnectButton.TabIndex = 8;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AmplitudePlot);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.FeedbackA);
            this.groupBox4.Controls.Add(this.FeedbackB);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.ModeText);
            this.groupBox4.Controls.Add(this.FeedbackM);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(12, 309);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(415, 256);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Feedback";
            // 
            // AmplitudePlot
            // 
            this.AmplitudePlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AmplitudePlot.Location = new System.Drawing.Point(172, 19);
            this.AmplitudePlot.Name = "AmplitudePlot";
            this.AmplitudePlot.Size = new System.Drawing.Size(237, 231);
            this.AmplitudePlot.TabIndex = 29;
            this.AmplitudePlot.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(12, 72);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(415, 231);
            this.groupBox5.TabIndex = 38;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Controller Input";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 127);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(150, 13);
            this.label19.TabIndex = 59;
            this.label19.Text = "Shoulder Buttons - Base Level";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 153);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(189, 13);
            this.label18.TabIndex = 37;
            this.label18.Text = "D-Pad Left/Right - Shoulder Sensitivity";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 675);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ZapU Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ZapClosed);
            this.Shown += new System.EventHandler(this.FormShown);
            ((System.ComponentModel.ISupportInitialize)(this.TCPPortNumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StickSensitivityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackA)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShoulderMinimumNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShoulderSensitivityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackM)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AddressText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown TCPPortNumber;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton PadRadio4;
        private System.Windows.Forms.RadioButton PadRadio3;
        private System.Windows.Forms.RadioButton PadRadio2;
        private System.Windows.Forms.RadioButton PadRadio1;
        private System.Windows.Forms.NumericUpDown StickSensitivityNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar FeedbackB;
        private System.Windows.Forms.TrackBar FeedbackA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox MessageText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ModeText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton InputTriggersRadio;
        private System.Windows.Forms.RadioButton InputSticksRadio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar FeedbackM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private ScottPlot.FormsPlot AmplitudePlot;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown ShoulderSensitivityNumeric;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown ShoulderMinimumNumeric;
        private System.Windows.Forms.Button DisconnectButton;
    }
}

