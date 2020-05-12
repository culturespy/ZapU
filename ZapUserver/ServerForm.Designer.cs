namespace ZapUserver
{
    partial class ServerForm
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
            this.TCPPortNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ClientList = new System.Windows.Forms.ListBox();
            this.PanicButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.COMPortList = new System.Windows.Forms.ListBox();
            this.ClosePortButton = new System.Windows.Forms.Button();
            this.MessageText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GrowthNumeric = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.AllowanceNumeric = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.BucketsNumeric = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.HistorySecondsNumeric = new System.Windows.Forms.NumericUpDown();
            this.GovernorEnabledCheck = new System.Windows.Forms.CheckBox();
            this.HardLimitNumeric = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.SimulateDeviceCheck = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ShoulderMinimumNumeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ShoulderSensitivityNumeric = new System.Windows.Forms.NumericUpDown();
            this.RemoteInputRadio = new System.Windows.Forms.RadioButton();
            this.InputTriggersRadio = new System.Windows.Forms.RadioButton();
            this.label23 = new System.Windows.Forms.Label();
            this.StickSensitivityNumeric = new System.Windows.Forms.NumericUpDown();
            this.InputSticksRadio = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PadRadio4 = new System.Windows.Forms.RadioButton();
            this.PadRadio3 = new System.Windows.Forms.RadioButton();
            this.PadRadio2 = new System.Windows.Forms.RadioButton();
            this.PadRadio1 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.AmplitudePlot = new ScottPlot.FormsPlot();
            this.FeedbackA = new System.Windows.Forms.TrackBar();
            this.FeedbackB = new System.Windows.Forms.TrackBar();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.ModeText = new System.Windows.Forms.TextBox();
            this.FeedbackM = new System.Windows.Forms.TrackBar();
            this.DisconnectClientButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TCPPortNumber)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrowthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllowanceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BucketsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistorySecondsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HardLimitNumeric)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShoulderMinimumNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShoulderSensitivityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickSensitivityNumeric)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackM)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "TCP Port";
            // 
            // TCPPortNumber
            // 
            this.TCPPortNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TCPPortNumber.Location = new System.Drawing.Point(62, 19);
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
            this.TCPPortNumber.Size = new System.Drawing.Size(69, 20);
            this.TCPPortNumber.TabIndex = 3;
            this.TCPPortNumber.Value = new decimal(new int[] {
            6969,
            0,
            0,
            0});
            this.TCPPortNumber.ValueChanged += new System.EventHandler(this.TCPPortChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Incoming Connections";
            // 
            // ClientList
            // 
            this.ClientList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientList.FormattingEnabled = true;
            this.ClientList.Location = new System.Drawing.Point(6, 63);
            this.ClientList.Name = "ClientList";
            this.ClientList.Size = new System.Drawing.Size(125, 43);
            this.ClientList.TabIndex = 8;
            this.ClientList.SelectedIndexChanged += new System.EventHandler(this.ClientChanged);
            // 
            // PanicButton
            // 
            this.PanicButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PanicButton.Location = new System.Drawing.Point(12, 455);
            this.PanicButton.Name = "PanicButton";
            this.PanicButton.Size = new System.Drawing.Size(925, 85);
            this.PanicButton.TabIndex = 10;
            this.PanicButton.Text = "EMERGENCY STOP";
            this.PanicButton.UseVisualStyleBackColor = true;
            this.PanicButton.Click += new System.EventHandler(this.PanicClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "COM Port";
            // 
            // COMPortList
            // 
            this.COMPortList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.COMPortList.FormattingEnabled = true;
            this.COMPortList.Location = new System.Drawing.Point(6, 32);
            this.COMPortList.Name = "COMPortList";
            this.COMPortList.Size = new System.Drawing.Size(102, 69);
            this.COMPortList.TabIndex = 12;
            this.COMPortList.SelectedIndexChanged += new System.EventHandler(this.ComPortChanged);
            // 
            // ClosePortButton
            // 
            this.ClosePortButton.Location = new System.Drawing.Point(6, 107);
            this.ClosePortButton.Name = "ClosePortButton";
            this.ClosePortButton.Size = new System.Drawing.Size(75, 23);
            this.ClosePortButton.TabIndex = 22;
            this.ClosePortButton.Text = "Close Port";
            this.ClosePortButton.UseVisualStyleBackColor = true;
            this.ClosePortButton.Click += new System.EventHandler(this.ClosePortClick);
            // 
            // MessageText
            // 
            this.MessageText.Location = new System.Drawing.Point(521, 273);
            this.MessageText.Multiline = true;
            this.MessageText.Name = "MessageText";
            this.MessageText.ReadOnly = true;
            this.MessageText.Size = new System.Drawing.Size(416, 169);
            this.MessageText.TabIndex = 23;
            this.MessageText.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Messages";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(6, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Reset Network";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ResetNetworkClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GrowthNumeric);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.AllowanceNumeric);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.BucketsNumeric);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.HistorySecondsNumeric);
            this.groupBox1.Controls.Add(this.GovernorEnabledCheck);
            this.groupBox1.Controls.Add(this.HardLimitNumeric);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(275, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 168);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Governor";
            // 
            // GrowthNumeric
            // 
            this.GrowthNumeric.DecimalPlaces = 2;
            this.GrowthNumeric.Location = new System.Drawing.Point(168, 97);
            this.GrowthNumeric.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.GrowthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GrowthNumeric.Name = "GrowthNumeric";
            this.GrowthNumeric.Size = new System.Drawing.Size(60, 20);
            this.GrowthNumeric.TabIndex = 8;
            this.GrowthNumeric.Value = new decimal(new int[] {
            13,
            0,
            0,
            65536});
            this.GrowthNumeric.ValueChanged += new System.EventHandler(this.GovernorGrowthChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(78, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Growth";
            // 
            // AllowanceNumeric
            // 
            this.AllowanceNumeric.Location = new System.Drawing.Point(168, 71);
            this.AllowanceNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AllowanceNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AllowanceNumeric.Name = "AllowanceNumeric";
            this.AllowanceNumeric.Size = new System.Drawing.Size(60, 20);
            this.AllowanceNumeric.TabIndex = 6;
            this.AllowanceNumeric.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.AllowanceNumeric.ValueChanged += new System.EventHandler(this.GovernorAllowanceChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(78, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Allowance";
            // 
            // BucketsNumeric
            // 
            this.BucketsNumeric.Location = new System.Drawing.Point(168, 45);
            this.BucketsNumeric.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.BucketsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BucketsNumeric.Name = "BucketsNumeric";
            this.BucketsNumeric.Size = new System.Drawing.Size(60, 20);
            this.BucketsNumeric.TabIndex = 4;
            this.BucketsNumeric.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.BucketsNumeric.ValueChanged += new System.EventHandler(this.GovernorBucketsChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Buckets";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(78, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "History Seconds";
            // 
            // HistorySecondsNumeric
            // 
            this.HistorySecondsNumeric.Location = new System.Drawing.Point(168, 19);
            this.HistorySecondsNumeric.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.HistorySecondsNumeric.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.HistorySecondsNumeric.Name = "HistorySecondsNumeric";
            this.HistorySecondsNumeric.Size = new System.Drawing.Size(60, 20);
            this.HistorySecondsNumeric.TabIndex = 1;
            this.HistorySecondsNumeric.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.HistorySecondsNumeric.ValueChanged += new System.EventHandler(this.GovernorHistoryChanged);
            // 
            // GovernorEnabledCheck
            // 
            this.GovernorEnabledCheck.AutoSize = true;
            this.GovernorEnabledCheck.Location = new System.Drawing.Point(7, 20);
            this.GovernorEnabledCheck.Name = "GovernorEnabledCheck";
            this.GovernorEnabledCheck.Size = new System.Drawing.Size(65, 17);
            this.GovernorEnabledCheck.TabIndex = 0;
            this.GovernorEnabledCheck.Text = "Enabled";
            this.GovernorEnabledCheck.UseVisualStyleBackColor = true;
            this.GovernorEnabledCheck.CheckedChanged += new System.EventHandler(this.GovernorEnabledCheckChanged);
            // 
            // HardLimitNumeric
            // 
            this.HardLimitNumeric.Location = new System.Drawing.Point(168, 142);
            this.HardLimitNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HardLimitNumeric.Name = "HardLimitNumeric";
            this.HardLimitNumeric.Size = new System.Drawing.Size(60, 20);
            this.HardLimitNumeric.TabIndex = 39;
            this.HardLimitNumeric.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HardLimitNumeric.ValueChanged += new System.EventHandler(this.HardLimitChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Level Limit (always active)";
            // 
            // SimulateDeviceCheck
            // 
            this.SimulateDeviceCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SimulateDeviceCheck.AutoSize = true;
            this.SimulateDeviceCheck.Location = new System.Drawing.Point(6, 142);
            this.SimulateDeviceCheck.Name = "SimulateDeviceCheck";
            this.SimulateDeviceCheck.Size = new System.Drawing.Size(103, 17);
            this.SimulateDeviceCheck.TabIndex = 43;
            this.SimulateDeviceCheck.Text = "Simulate Device";
            this.SimulateDeviceCheck.UseVisualStyleBackColor = true;
            this.SimulateDeviceCheck.CheckedChanged += new System.EventHandler(this.SimulateDeviceCheckChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label17.Location = new System.Drawing.Point(266, 152);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 55;
            this.label17.Text = "Y - Input Mode";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 207);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(395, 13);
            this.label15.TabIndex = 54;
            this.label15.Text = "Waves - Higher MA is higher frequency and faster cycle through the wave pattern.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 220);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(194, 13);
            this.label16.TabIndex = 53;
            this.label16.Text = "Intense - Lower MA is higher frequency.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 191);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(190, 13);
            this.label18.TabIndex = 52;
            this.label18.Text = "Multi-Adjust works differently per mode:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label20.Location = new System.Drawing.Point(266, 190);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 13);
            this.label20.TabIndex = 50;
            this.label20.Text = "A - Waves";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label21.Location = new System.Drawing.Point(307, 171);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(58, 13);
            this.label21.TabIndex = 49;
            this.label21.Text = "B - Intense";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label22.Location = new System.Drawing.Point(230, 171);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 13);
            this.label22.TabIndex = 48;
            this.label22.Text = "X - PANIC";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.ShoulderMinimumNumeric);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ShoulderSensitivityNumeric);
            this.groupBox2.Controls.Add(this.RemoteInputRadio);
            this.groupBox2.Controls.Add(this.InputTriggersRadio);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.StickSensitivityNumeric);
            this.groupBox2.Controls.Add(this.InputSticksRadio);
            this.groupBox2.Location = new System.Drawing.Point(91, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 113);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Mode";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(139, 90);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 13);
            this.label19.TabIndex = 50;
            this.label19.Text = "Shoulder Minimum";
            // 
            // ShoulderMinimumNumeric
            // 
            this.ShoulderMinimumNumeric.Location = new System.Drawing.Point(248, 88);
            this.ShoulderMinimumNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ShoulderMinimumNumeric.Name = "ShoulderMinimumNumeric";
            this.ShoulderMinimumNumeric.Size = new System.Drawing.Size(47, 20);
            this.ShoulderMinimumNumeric.TabIndex = 49;
            this.ShoulderMinimumNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Shoulder Sensitivity";
            // 
            // ShoulderSensitivityNumeric
            // 
            this.ShoulderSensitivityNumeric.Location = new System.Drawing.Point(248, 65);
            this.ShoulderSensitivityNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ShoulderSensitivityNumeric.Name = "ShoulderSensitivityNumeric";
            this.ShoulderSensitivityNumeric.Size = new System.Drawing.Size(47, 20);
            this.ShoulderSensitivityNumeric.TabIndex = 47;
            this.ShoulderSensitivityNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ShoulderSensitivityNumeric.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // RemoteInputRadio
            // 
            this.RemoteInputRadio.AutoSize = true;
            this.RemoteInputRadio.Checked = true;
            this.RemoteInputRadio.Location = new System.Drawing.Point(8, 19);
            this.RemoteInputRadio.Name = "RemoteInputRadio";
            this.RemoteInputRadio.Size = new System.Drawing.Size(62, 17);
            this.RemoteInputRadio.TabIndex = 3;
            this.RemoteInputRadio.TabStop = true;
            this.RemoteInputRadio.Text = "Remote";
            this.RemoteInputRadio.UseVisualStyleBackColor = true;
            // 
            // InputTriggersRadio
            // 
            this.InputTriggersRadio.AutoSize = true;
            this.InputTriggersRadio.Location = new System.Drawing.Point(8, 65);
            this.InputTriggersRadio.Name = "InputTriggersRadio";
            this.InputTriggersRadio.Size = new System.Drawing.Size(108, 17);
            this.InputTriggersRadio.TabIndex = 2;
            this.InputTriggersRadio.TabStop = true;
            this.InputTriggersRadio.Text = "Shoulder Triggers";
            this.InputTriggersRadio.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(139, 44);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 13);
            this.label23.TabIndex = 46;
            this.label23.Text = "Stick Sensitivitiy";
            // 
            // StickSensitivityNumeric
            // 
            this.StickSensitivityNumeric.Location = new System.Drawing.Point(248, 42);
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
            this.StickSensitivityNumeric.TabIndex = 45;
            this.StickSensitivityNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.StickSensitivityNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // InputSticksRadio
            // 
            this.InputSticksRadio.AutoSize = true;
            this.InputSticksRadio.Location = new System.Drawing.Point(8, 42);
            this.InputSticksRadio.Name = "InputSticksRadio";
            this.InputSticksRadio.Size = new System.Drawing.Size(90, 17);
            this.InputSticksRadio.TabIndex = 1;
            this.InputSticksRadio.TabStop = true;
            this.InputSticksRadio.Text = "Analog Sticks";
            this.InputSticksRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PadRadio4);
            this.groupBox3.Controls.Add(this.PadRadio3);
            this.groupBox3.Controls.Add(this.PadRadio2);
            this.groupBox3.Controls.Add(this.PadRadio1);
            this.groupBox3.Location = new System.Drawing.Point(6, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(79, 66);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gamepads";
            // 
            // PadRadio4
            // 
            this.PadRadio4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PadRadio4.AutoSize = true;
            this.PadRadio4.Location = new System.Drawing.Point(44, 43);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Location = new System.Drawing.Point(521, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(416, 242);
            this.groupBox4.TabIndex = 57;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gamepad Input";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "Shoulder Buttons - Base Level";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(189, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "D-Pad Left/Right - Shoulder Sensitivity";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "D-Pad Up/Down - Multi-Adjust";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.DisconnectClientButton);
            this.groupBox6.Controls.Add(this.TCPPortNumber);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.ClientList);
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Location = new System.Drawing.Point(132, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(137, 167);
            this.groupBox6.TabIndex = 59;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Network Connection";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.COMPortList);
            this.groupBox7.Controls.Add(this.ClosePortButton);
            this.groupBox7.Controls.Add(this.SimulateDeviceCheck);
            this.groupBox7.Location = new System.Drawing.Point(12, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(114, 167);
            this.groupBox7.TabIndex = 60;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Output Device";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.label24);
            this.groupBox8.Controls.Add(this.AmplitudePlot);
            this.groupBox8.Controls.Add(this.FeedbackA);
            this.groupBox8.Controls.Add(this.FeedbackB);
            this.groupBox8.Controls.Add(this.label25);
            this.groupBox8.Controls.Add(this.label26);
            this.groupBox8.Controls.Add(this.ModeText);
            this.groupBox8.Controls.Add(this.FeedbackM);
            this.groupBox8.Location = new System.Drawing.Point(12, 186);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(503, 256);
            this.groupBox8.TabIndex = 58;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Feedback";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "A";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(82, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(14, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "B";
            // 
            // AmplitudePlot
            // 
            this.AmplitudePlot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AmplitudePlot.Location = new System.Drawing.Point(172, 17);
            this.AmplitudePlot.Name = "AmplitudePlot";
            this.AmplitudePlot.Size = new System.Drawing.Size(325, 233);
            this.AmplitudePlot.TabIndex = 56;
            this.AmplitudePlot.TabStop = false;
            // 
            // FeedbackA
            // 
            this.FeedbackA.Location = new System.Drawing.Point(6, 33);
            this.FeedbackA.Maximum = 255;
            this.FeedbackA.Name = "FeedbackA";
            this.FeedbackA.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FeedbackA.Size = new System.Drawing.Size(45, 190);
            this.FeedbackA.TabIndex = 31;
            this.FeedbackA.TabStop = false;
            this.FeedbackA.TickFrequency = 25;
            // 
            // FeedbackB
            // 
            this.FeedbackB.Location = new System.Drawing.Point(57, 33);
            this.FeedbackB.Maximum = 255;
            this.FeedbackB.Name = "FeedbackB";
            this.FeedbackB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FeedbackB.Size = new System.Drawing.Size(45, 190);
            this.FeedbackB.TabIndex = 32;
            this.FeedbackB.TabStop = false;
            this.FeedbackB.TickFrequency = 25;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(13, 231);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 13);
            this.label25.TabIndex = 33;
            this.label25.Text = "Mode:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(133, 16);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(23, 13);
            this.label26.TabIndex = 36;
            this.label26.Text = "MA";
            // 
            // ModeText
            // 
            this.ModeText.Location = new System.Drawing.Point(56, 228);
            this.ModeText.Name = "ModeText";
            this.ModeText.ReadOnly = true;
            this.ModeText.Size = new System.Drawing.Size(100, 20);
            this.ModeText.TabIndex = 34;
            this.ModeText.TabStop = false;
            this.ModeText.Text = "UNKNOWN";
            // 
            // FeedbackM
            // 
            this.FeedbackM.Location = new System.Drawing.Point(121, 32);
            this.FeedbackM.Maximum = 255;
            this.FeedbackM.Minimum = 128;
            this.FeedbackM.Name = "FeedbackM";
            this.FeedbackM.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.FeedbackM.Size = new System.Drawing.Size(45, 190);
            this.FeedbackM.TabIndex = 35;
            this.FeedbackM.TabStop = false;
            this.FeedbackM.TickFrequency = 25;
            this.FeedbackM.Value = 128;
            // 
            // DisconnectClientButton
            // 
            this.DisconnectClientButton.Location = new System.Drawing.Point(6, 113);
            this.DisconnectClientButton.Name = "DisconnectClientButton";
            this.DisconnectClientButton.Size = new System.Drawing.Size(125, 23);
            this.DisconnectClientButton.TabIndex = 26;
            this.DisconnectClientButton.Text = "Disconnect Client";
            this.DisconnectClientButton.UseVisualStyleBackColor = true;
            this.DisconnectClientButton.Click += new System.EventHandler(this.DisconnectClientClick);
            // 
            // ServerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(946, 552);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.PanicButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ZapU Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ZapFormClosed);
            this.Shown += new System.EventHandler(this.FormShown);
            ((System.ComponentModel.ISupportInitialize)(this.TCPPortNumber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrowthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllowanceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BucketsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistorySecondsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HardLimitNumeric)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShoulderMinimumNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShoulderSensitivityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickSensitivityNumeric)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FeedbackM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TCPPortNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ClientList;
        private System.Windows.Forms.Button PanicButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox COMPortList;
        private System.Windows.Forms.Button ClosePortButton;
        private System.Windows.Forms.TextBox MessageText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox GovernorEnabledCheck;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown HistorySecondsNumeric;
        private System.Windows.Forms.NumericUpDown BucketsNumeric;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown AllowanceNumeric;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown GrowthNumeric;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown HardLimitNumeric;
        private System.Windows.Forms.CheckBox SimulateDeviceCheck;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton InputTriggersRadio;
        private System.Windows.Forms.RadioButton InputSticksRadio;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown StickSensitivityNumeric;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton PadRadio4;
        private System.Windows.Forms.RadioButton PadRadio3;
        private System.Windows.Forms.RadioButton PadRadio2;
        private System.Windows.Forms.RadioButton PadRadio1;
        private System.Windows.Forms.RadioButton RemoteInputRadio;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label24;
        private ScottPlot.FormsPlot AmplitudePlot;
        private System.Windows.Forms.TrackBar FeedbackA;
        private System.Windows.Forms.TrackBar FeedbackB;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox ModeText;
        private System.Windows.Forms.TrackBar FeedbackM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ShoulderSensitivityNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown ShoulderMinimumNumeric;
        private System.Windows.Forms.Button DisconnectClientButton;
    }
}

