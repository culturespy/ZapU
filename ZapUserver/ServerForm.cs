using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using ZapUcommon;
using ZapUcommon.ErosTek;
using ZapUcommon.ErosTek.ET232;

using ScottPlot;
using XInput.Wrapper;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUserver
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        private void FormShown(object sender, EventArgs e)
        {
            InputSticksRadio.Tag = ControlMode.relative;
            InputTriggersRadio.Tag = ControlMode.absolute;
            RemoteInputRadio.Tag = ControlMode.remote;

            Proxy.QueueStateCallback = ProxyQueueStateCallback;
            Proxy.ErrorCallback = ProxyErrorCallback;
            Proxy.StateUpdatedCallback = ProxyStateUpdatedCallback;
            Proxy.MassLevelSetCallback = ProxyMassLevelSetCallback;
            Proxy.DataReturnedCallback = ProxyDataReturnedCallback;

            SimulateDeviceCheckChanged(this, null);

            Device = new ErosTek232();
            GovernorEnabledCheck.Checked = Device.GovernorEnabled;
            HistorySecondsNumeric.Value = (decimal)Device.GovernorMaxAge;
            BucketsNumeric.Value = Device.GovernorBuckets;
            AllowanceNumeric.Value = Device.GovernorFreeRange;
            GrowthNumeric.Value = (decimal)Device.GovernorGrowth;
            HardLimitNumeric.Value = Device.HardLimit;

            COMPortList.Items.AddRange(SerialPort.GetPortNames());

            OpenNetwork();

            InputTimer = new Timer() { Interval = 20 };
            InputTimer.Tick += DoInputs;
            InputTimer.Enabled = true;

            GraphTimer = new Timer() { Interval = 100 };
            GraphTimer.Tick += RequestGraphData;
            GraphTimer.Enabled = true;
        }

        private void ZapFormClosed(object sender, FormClosedEventArgs e)
        {
            CloseNetwork();
            CloseDevice();
        }

        private void ClosePortClick(object sender, EventArgs e)
        {
            CloseDevice();
            COMPortList.SelectedIndex = -1;
            COMPortList.Items.Clear();
            COMPortList.Items.AddRange(SerialPort.GetPortNames());
        }

        private void ComPortChanged(object sender, EventArgs e)
        {
            ListBox comports = sender as ListBox;
            if(comports.SelectedIndex != -1)
            {
                string port = (string)comports.SelectedItem;
                if (Output.PortName != port)
                {
                    CloseDevice();
                    Device = new ErosTek232();
                    DoDevicePlumbing();

                    Output.PortName = port;
                    Output.BaudRate = 19200;
                    Output.Parity = Parity.None;
                    Output.DataBits = 8;
                    Output.StopBits = StopBits.One;
                    Output.Handshake = Handshake.None;
                    Output.RtsEnable = false;
                    Output.Open();

                    Device.SetStream(Output.BaseStream);
                    Device.BeginThread();
                }
            }
        }

        private void SimulateDeviceCheckChanged(object sender, EventArgs e)
        {
            CloseDevice();
            if (SimulateDeviceCheck.Checked)
            {
                COMPortList.Enabled = false;
                Device = new Fake232();
                DoDevicePlumbing();
                Device.BeginThread();
            }
            else COMPortList.Enabled = true;
        }

        void DoDevicePlumbing()
        {
            Device.QueueStateCallback = ZapQueueStateCallback;
            Device.ErrorCallback = ZapErrorCallback;
            Device.StateUpdatedCallback = ZapStateUpdatedCallback;
            Device.MassLevelSetCallback = ZapMassLevelSetCallback;
            Device.DataReturnedCallback = ZapDataReturnedCallback;

            Device.GovernorEnabled = GovernorEnabledCheck.Checked;
            Device.GovernorMaxAge = (double)HistorySecondsNumeric.Value;
            Device.GovernorBuckets = (int)BucketsNumeric.Value;
            Device.GovernorFreeRange = (int)AllowanceNumeric.Value;
            Device.GovernorGrowth = (double)GrowthNumeric.Value;
            Device.HardLimit = (int)HardLimitNumeric.Value;
        }

        public void CloseDevice()
        {
            if (Device != null) Device.EndThread();
            if (Output.IsOpen)
            {
                Output.Close();
                Output.PortName = "";
            }
            Device = null;
        }

        private void TCPPortChanged(object sender, EventArgs e)
        {
            OpenNetwork();
        }

        private void ClientChanged(object sender, EventArgs ea)
        {
            ListBox clientlist = sender as ListBox;
            CloseCurrentConnection(true);
            if (clientlist.SelectedItem != null)
            {
                SocketData remote = (SocketData)clientlist.SelectedItem;
                try
                {
                    Proxy.SetStream(new NetworkStream(remote.Client.Client, true));
                    client_needs_resync = true;
                    Proxy.BeginThread();
                }
                catch (Exception)
                {
                    clientlist.SelectedIndex = -1;
                    AddMessage("Client abandoned connection.");
                }
            }
            MaintainClientList();
        }

        private void DisconnectClientClick(object sender, EventArgs e)
        {
            CloseCurrentConnection(false);
            MaintainClientList();
        }

        public void MaintainClientList()
        {
            for (int ctr = ClientList.Items.Count; ctr > 0; ctr--)
            {
                int idx = ctr - 1;
                SocketData item = (SocketData)ClientList.Items[idx];
                if (idx != ClientList.SelectedIndex &&
                    (item == null || item.Client == null || item.Client.Client == null || !item.Client.Connected))
                    ClientList.Items.RemoveAt(idx);
            }
        }

        private void ResetNetworkClick(object sender, EventArgs e)
        {
            OpenNetwork();
        }

        private void OpenNetwork()
        {
            CloseNetwork();
            try
            {
                Listener = new TcpListener(IPAddress.Any, (int)TCPPortNumber.Value);
                Listener.Start();
                Listener.BeginAcceptTcpClient(new AsyncCallback(SocketAcceptCallback), Listener);
            }
            catch (Exception e)
            {
                AddMessage(e.Message);
            }
        }

        private void CloseNetwork()
        {
            CloseAllClients();
            if (Listener != null) Listener.Stop();
            Listener = null;
            ClientList.Items.Clear();
        }

        private void CloseAllClients()
        {
            CloseCurrentConnection(false);
            foreach (object item in ClientList.Items)
                if (item is SocketData client) client.Close();
            MaintainClientList();
        }

        private void CloseCurrentConnection(bool selecting)
        {
            Proxy.EndThread();
            if(!selecting) ClientList.SelectedIndex = -1;
        }

        private void GovernorEnabledCheckChanged(object sender, EventArgs e)
        {
            Device.GovernorEnabled = GovernorEnabledCheck.Checked;
        }

        private void GovernorHistoryChanged(object sender, EventArgs e)
        {
            Device.GovernorMaxAge = (double)HistorySecondsNumeric.Value;
        }

        private void GovernorBucketsChanged(object sender, EventArgs e)
        {
            Device.GovernorBuckets = (int)BucketsNumeric.Value;
        }

        private void GovernorAllowanceChanged(object sender, EventArgs e)
        {
            if (AllowanceNumeric.Value > HardLimitNumeric.Value)
                AllowanceNumeric.Value = HardLimitNumeric.Value;
            Device.GovernorFreeRange = (int)AllowanceNumeric.Value;
        }

        private void GovernorGrowthChanged(object sender, EventArgs e)
        {
            Device.GovernorGrowth = (double)GrowthNumeric.Value;
        }

        private void HardLimitChanged(object sender, EventArgs e)
        {
            Device.HardLimit = (int)HardLimitNumeric.Value;
            if (AllowanceNumeric.Value > HardLimitNumeric.Value)
                AllowanceNumeric.Value = HardLimitNumeric.Value;
        }

        private void PadRadioChange(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            switch (radio.Tag)
            {
                case "1":
                    gamepad = X.Gamepad_1;
                    break;
                case "2":
                    gamepad = X.Gamepad_2;
                    break;
                case "3":
                    gamepad = X.Gamepad_3;
                    break;
                case "4":
                    gamepad = X.Gamepad_4;
                    break;
            }
        }

        private void PanicClick(object sender, EventArgs e)
        {
            DoPanic();
        }

        private void DoPanic()
        {
            if(Device != null) Proxy.Panic();
            Device.Panic();
            AddMessage("PANIC!");
        }

        private void DoInputs(object sender, EventArgs ea)
        {
            ControllerPoller.Poller(gamepad,
                                    Device,
                                    new ControllerPoller.PanicDelegate(DoPanic),
                                    new List<RadioButton>()
                                    {
                                        RemoteInputRadio,
                                        InputSticksRadio,
                                        InputTriggersRadio,
                                    },
                                    StickSensitivityNumeric,
                                    ShoulderSensitivityNumeric,
                                    ShoulderMinimumNumeric,
                                    Device !=null && Device.IsReady,
                                    ref A_button_debounce,
                                    ref B_button_debounce,
                                    ref X_button_debounce,
                                    ref Y_button_debounce);
        }

        private void RequestGraphData(object sender, EventArgs e)
        {
            if(Device != null && Device.IsReady)
            {
                Device.RequestOutputData(new RequestCommand() { Address = (int)AddressByte.PulseAmp_A });
                Device.RequestOutputData(new RequestCommand() { Address = (int)AddressByte.PulseAmp_B });
            }
            double current_unixtime = UnixTime.Current();
            double cutoff = current_unixtime - 20;
            Proxy.PruneAmplitudeHistory(cutoff);
        }

        public void ZapQueueStateCallback(DeviceBase device, int depth)
        {
            if (this.InvokeRequired)
            {
                var d = new DeviceBase.DeviceQueueStateCallback(ZapQueueStateCallback);
                this.BeginInvoke(d, new object[] { device, depth });
            }
            else
            {
                if (depth == 0 && client_needs_resync)
                {
                    Proxy.SetLevels(new LevelsCommand() { A = FeedbackA.Value, B = FeedbackB.Value, MA = 0, Mode = ControlMode.absolute });
                    Proxy.SetMode(new ModeCommand() { Mode = (int)_last_mode, MA = FeedbackM.Value });
                    client_needs_resync = false;
                }
            }
        }

        public void ZapErrorCallback(DeviceBase device, string message, string details, bool panic)
        {
            if (this.InvokeRequired)
            {
                var d = new DeviceBase.DeviceErrorCallback(ZapErrorCallback);
                this.BeginInvoke(d, new object[] { device, message, details, panic });
            }
            else
            {
                if (panic) DoPanic();
                if (!String.IsNullOrEmpty(message)) AddMessage(message);
                if (!String.IsNullOrEmpty(details)) AddMessage(details);
                Proxy.ReportError(new ErrorCommand() { Error = message, Details = details });
            }
        }

        public void ZapStateUpdatedCallback(DeviceBase device, int address, int data)
        {
            if (this.InvokeRequired)
            {
                var d = new DeviceBase.DeviceStateUpdatedCallback(ZapStateUpdatedCallback);
                this.BeginInvoke(d, new object[] { device, address, data });
            }
            else
            {
                TrackBar target = null;
                if (address == (int)AddressByte.Pot_A) target = FeedbackA;
                if (address == (int)AddressByte.Pot_B) target = FeedbackB;
                if (address == (int)AddressByte.Pot_MA) target = FeedbackM;
                if (target != null)
                {
                    try
                    {
                        target.Value = data;
                    }
                    catch (Exception) { } // Ignore values out of range
                }
                if(address == (int)AddressByte.ModeOverride)
                {
                    _last_mode = (ModeSelect)data;
                    try
                    {
                        ErosTekModeData mode = ZapUcommon.ErosTek.Constants.Modes[(ModeSelect)data];
                        ModeText.Text = mode.Name;
                        client_needs_resync = true;
                    }
                    catch (Exception) { }
                }

                Proxy.RawWrite(new RawCommand() { Address = address, Data = data });
            }
        }

        public void ZapMassLevelSetCallback(DeviceBase device, int A, int B, int MA, bool absolute)
        {
        }

        public void ZapDataReturnedCallback(DeviceBase device, int address, int data)
        {
            if (this.InvokeRequired)
            {
                var d = new DeviceBase.DeviceDataReturnedCallback(ZapDataReturnedCallback);
                this.BeginInvoke(d, new object[] { device, address, data });
            }
            else
            {
                Grapher.Plot(Device, AmplitudePlot);
                Proxy.ReportOutputData(new ResponseCommand() { Address = address, Data = data });
            }
        }

        public void ProxyQueueStateCallback(DeviceBase device, int depth)
        {
        }

        public void ProxyErrorCallback(DeviceBase device, string message, string details, bool panic)
        {
            if (this.InvokeRequired)
            {
                var d = new DeviceBase.DeviceErrorCallback(ProxyErrorCallback);
                this.BeginInvoke(d, new object[] { device, message, details, panic });
            }
            else
            {
                if (panic) DoPanic();
                AddMessage(message);
                AddMessage(details);
            }
        }

        public void ProxyStateUpdatedCallback(DeviceBase device, int address, int data)
        {
            if (this.InvokeRequired)
            {
                var d = new DeviceBase.DeviceStateUpdatedCallback(ProxyStateUpdatedCallback);
                this.BeginInvoke(d, new object[] { device, address, data });
            }
            else
            {
                if (RemoteInputRadio.Checked && Device != null && Device.IsReady)
                    Device.RawWrite(new RawCommand() { Address = address, Data = data });
            }
        }

        public void ProxyMassLevelSetCallback(DeviceBase device, int A, int B, int MA, bool absolute)
        {
            if (this.InvokeRequired)
            {
                var d = new DeviceBase.DeviceMassLevelSetCallback(ProxyMassLevelSetCallback);
                this.BeginInvoke(d, new object[] { device, A, B, MA, absolute });
            }
            else
            {
                if (RemoteInputRadio.Checked && Device != null && Device.IsReady)
                    Device.SetLevels(new LevelsCommand() { A = A, B = B, MA = MA, Mode = absolute ? ControlMode.absolute :
                                                                                                    ControlMode.relative });
            }
        }

        public void ProxyDataReturnedCallback(DeviceBase device, int address, int data)
        {
        }

        public void SocketAcceptCallback(IAsyncResult ar)
        {
            TcpListener listener = (TcpListener)ar.AsyncState;
            try
            {
                TcpClient client = listener.EndAcceptTcpClient(ar);
                client.NoDelay = true;
                NewClient(client);
                Listener.BeginAcceptTcpClient(new AsyncCallback(SocketAcceptCallback), listener);
            }
            catch (Exception e)
            {
                AddMessage(e.Message);
            }
        }

        private delegate void NewClientDelegate(TcpClient client);
        public void NewClient(TcpClient client)
        {
            if (this.InvokeRequired)
            {
                var d = new NewClientDelegate(NewClient);
                this.BeginInvoke(d, new object[] { client });
            }
            else
            {
                ClientList.Items.Add(new SocketData(client));
            }
        }

        private delegate void AddMessageDelegate(string text);
        private void AddMessage(string text)
        {
            if(this.InvokeRequired)
            {
                var d = new AddMessageDelegate(AddMessage);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                MessageText.AppendText(text.Replace("\n", Environment.NewLine));
                MessageText.AppendText(Environment.NewLine);
            }
        }

        private readonly SerialPort Output = new SerialPort();
        private readonly ProxyDevice Proxy = new ProxyDevice();
        private DeviceBase Device = null;

        TcpListener Listener = null;

        bool client_needs_resync = false;

        Timer InputTimer;
        Timer GraphTimer;
        X.Gamepad gamepad = X.Gamepad_1;
        bool A_button_debounce = false;
        bool B_button_debounce = false;
        bool X_button_debounce = false;
        bool Y_button_debounce = false;

        private ModeSelect _last_mode = ModeSelect.Intense;
    }
}
