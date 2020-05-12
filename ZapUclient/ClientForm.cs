using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.IO;

using ZapUcommon;
using ZapUcommon.ErosTek;
using XInput.Wrapper;
using ZapUcommon.ErosTek.ET232;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUclient
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void FormShown(object sender, EventArgs e)
        {
            InputSticksRadio.Tag = ControlMode.relative;
            InputTriggersRadio.Tag = ControlMode.absolute;

            Proxy.QueueStateCallback = ProxyQueueStateCallback;
            Proxy.ErrorCallback = ProxyErrorCallback;
            Proxy.StateUpdatedCallback = ProxyStateUpdatedCallback;
            Proxy.MassLevelSetCallback = ProxyMassLevelSetCallback;
            Proxy.DataReturnedCallback = ProxyDataReturnedCallback;

            InputTimer = new Timer() { Interval = 20 };
            InputTimer.Tick += Poller;
            InputTimer.Enabled = true;
        }

        private void ZapClosed(object sender, FormClosedEventArgs er)
        {
            Proxy.EndThread();
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

        private void ConnectClick(object sender, EventArgs er)
        {
            clear_to_send = false;

            AddMessage("Connecting to host " + AddressText.Text + " on port " + TCPPortNumber.Value.ToString() + "...");
            try
            {
                TcpClient ClientSocket = new TcpClient();
                ClientSocket.BeginConnect(AddressText.Text, (int)TCPPortNumber.Value, new AsyncCallback(ConnectCallback), ClientSocket);
            }
            catch (Exception e)
            {
                AddMessage(e.Message);
            }
        }


        private void DisconnectClick(object sender, EventArgs e)
        {
            clear_to_send = false;
            if(Proxy.HasStream)
            {
                AddMessage("Closing connection.");
                Proxy.EndThread();
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                TcpClient connection = (TcpClient)ar.AsyncState;
                connection.EndConnect(ar);
                connection.NoDelay = true;
                first_resync_received = false;

                Proxy.EndThread();
                Proxy.SetStream(connection.GetStream());
                Proxy.BeginThread();

                AddMessage("Connected! Waiting for device state sync...");
            }
            catch (Exception e)
            {
                AddMessage(e.Message);
            }
        }

        void Poller(object sender, EventArgs ea)
        {
            ControllerPoller.Poller(gamepad,
                                    Proxy,
                                    new ControllerPoller.PanicDelegate(DoPanic),
                                    new List<RadioButton>()
                                    {
                                        InputSticksRadio,
                                        InputTriggersRadio,
                                    },
                                    StickSensitivityNumeric,
                                    ShoulderSensitivityNumeric,
                                    ShoulderMinimumNumeric,
                                    clear_to_send,
                                    ref A_button_debounce,
                                    ref B_button_debounce,
                                    ref X_button_debounce,
                                    ref Y_button_debounce);
        }

        void ProxyQueueStateCallback(DeviceBase device, int depth)
        {
            if(this.InvokeRequired)
            {
                var d = new DeviceBase.DeviceQueueStateCallback(ProxyQueueStateCallback);
                this.BeginInvoke(d, new object[] { device, depth });
            }
            else
            {
                if (depth == 0)
                {
                    if (!first_resync_received) AddMessage("Device state synchronized.");
                    first_resync_received = true;
                    clear_to_send = true;
                }
            }
        }

        void ProxyErrorCallback(DeviceBase device, string message, string details, bool panic)
        {
            if (this.InvokeRequired)
            {
                var d = new DeviceBase.DeviceErrorCallback(ProxyErrorCallback);
                this.BeginInvoke(d, new object[] { device, message, details, panic });
            }
            else
            {
                AddMessage(message);
                AddMessage(details);
            }
        }

        void ProxyStateUpdatedCallback(DeviceBase device, int address, int data)
        {
            if (this.InvokeRequired)
            {
                var d = new DeviceBase.DeviceStateUpdatedCallback(ProxyStateUpdatedCallback);
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
                if (address == (int)AddressByte.ModeOverride)
                {
                    try
                    {
                        ErosTekModeData mode = ZapUcommon.ErosTek.Constants.Modes[(ModeSelect)data];
                        ModeText.Text = mode.Name;
                    }
                    catch (Exception) { } // Ignore unknown modes
                }
            }
        }

        void ProxyMassLevelSetCallback(DeviceBase device, int A, int B, int MA, bool absolute)
        {
        }

        void ProxyDataReturnedCallback(DeviceBase device, int address, int data)
        {
            if (this.InvokeRequired)
            {
                var d = new DeviceBase.DeviceDataReturnedCallback(ProxyDataReturnedCallback);
                this.BeginInvoke(d, new object[] { device, address, data });
            }
            else
            {
                Grapher.Plot(Proxy, AmplitudePlot);
            }
        }

        public void DoPanic()
        {
            Proxy.Panic();
        }

        private delegate void AddMessageDelegate(string text);
        private void AddMessage(string text)
        {
            if (this.InvokeRequired)
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

        bool first_resync_received = false;
        bool clear_to_send = false;

        bool A_button_debounce = false;
        bool B_button_debounce = false;
        bool X_button_debounce = false;
        bool Y_button_debounce = false;

        private readonly ProxyDevice Proxy = new ProxyDevice();
        X.Gamepad gamepad = X.Gamepad_1;
        Timer InputTimer;
    }
}
