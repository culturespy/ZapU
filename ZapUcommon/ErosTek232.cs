using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using ZapUcommon.ErosTek;
using ZapUcommon.ErosTek.ET232;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUcommon
{
    public class ErosTek232 : DeviceBase
    {
        public override void Reset()
        {
            lock (_thread_interlock)
            {
                CommandQueue.Clear();
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = AddressByte.Pot_A,
                    Data = 0,
                    Retry = true,
                });
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = AddressByte.Pot_B,
                    Data = 0,
                    Retry = true,
                });
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = AddressByte.InputOverride,
                    Data = ErosTek.ET232.Constants.OverrideNone,
                    Retry = true,
                });
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = AddressByte.ModeOverride,
                    Data = ErosTek.ET232.Constants.ForceReset,
                    Retry = true,
                });
                draining_queue = true;
            }
        }

        public override void SetMode(ModeCommand mode)
        {
            lock (_thread_interlock)
            {
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = AddressByte.ModeOverride,
                    Data = ErosTek.ET232.Constants.ForceMode | (byte)mode.Mode,
                    Retry = true,
                });
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = AddressByte.Pot_MA,
                    Data = mode.MA,
                    Retry = true,
                });
                draining_queue = true;
            }
        }

        public override void SetLevels(LevelsCommand levels)
        {
            int A, B, MA;

            lock (_thread_interlock)
            {
                if (levels.Mode == ControlMode.absolute)
                {
                    A = levels.A;
                    B = levels.B;
                }
                else
                {
                    A = LastA + levels.A;
                    B = LastB + levels.B;
                }

                if (A > 255) A = 255;
                if (A < 0) A = 0;

                if (B > 255) B = 255;
                if (B < 0) B = 0;

                if(A != LastA)
                {
                    CommandQueue.Add(new ET232Command()
                    {
                        Command = CommandByte.write,
                        Address = AddressByte.Pot_A,
                        Data = A,
                    });

                }
                if(B != LastB)
                {
                    CommandQueue.Add(new ET232Command()
                    {
                        Command = CommandByte.write,
                        Address = AddressByte.Pot_B,
                        Data = B,
                    });
                }

                if (levels.MA != 0)
                {
                    MA = LastMA + levels.MA;

                    if (MA > 255) MA = 255;
                    if (MA < 0) MA = 0;

                    if(MA != LastMA)
                    {
                        CommandQueue.Add(new ET232Command()
                        {
                            Command = CommandByte.write,
                            Address = AddressByte.Pot_MA,
                            Data = MA,
                        });
                    }
                }
            }
        }

        public override void RawWrite(RawCommand raw)
        {
            lock (_thread_interlock)
            {
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = (AddressByte)raw.Address,
                    Data = raw.Data,
                });
            }
        }

        public override void RequestOutputData(RequestCommand request)
        {
            lock (_thread_interlock)
            {
                draining_queue = true;
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.read,
                    Address = (AddressByte)request.Address,
                });
            }
        }

        public override void ReportOutputData(ResponseCommand response)
        {
            throw (new NotImplementedException());
        }

        public override void ReportError(ErrorCommand error)
        {
            throw (new NotImplementedException());
        }

        public override string GetModeName(int mode)
        {
            return ErosTek.Constants.Modes[(ModeSelect)mode].Name;
        }

        public override bool IsReady
        {
            get
            {
                bool retval = base.IsReady;
                lock (_thread_interlock) if (retval) retval = _state == State.ready && !draining_queue;
                return retval;
            }
        }

        public override void ThreadFunction()
        {
            ErrorCallback(this, "ET232 connection started.", "Waiting for device handshake.", false);

            Initialize();

            bool should_exit = false;
            byte[] device_inputs = Array.Empty<byte>();

            // https://www.sparxeng.com/blog/software/must-use-net-system-io-ports-serialport
            byte[] read_buffer = new byte[1024];
            void DataReader()
            {
                try
                {
                    lock(_thread_interlock) DeviceStream.BeginRead(read_buffer, 0, read_buffer.Length, delegate (IAsyncResult ar)
                    {
                        try
                        {
                            lock (_thread_interlock)
                            {
                                if (DeviceStream == null) return;
                                int len = DeviceStream.EndRead(ar);
                                int pos = device_inputs.Length;
                                Array.Resize(ref device_inputs, pos + len);
                                Buffer.BlockCopy(read_buffer, 0, device_inputs, pos, len);
                            }
                        }
                        catch (Exception e)
                        {
                            bool exiting;
                            lock (_thread_interlock) exiting = _thread_end;
                            if (!exiting) ErrorCallback(this, "Device error.", e.Message, false);
                        }
                        DataReader();
                    }, null);
                }
                catch (Exception e)
                {
                    bool exiting;
                    lock (_thread_interlock) exiting = _thread_end;
                    if (!exiting) ErrorCallback(this, "Device error.", e.Message, false);
                }
            }
            DataReader();

            while (!should_exit)
            {
                Thread.Yield();
                State current_state;
                byte[] current_input_data;
                lock (_thread_interlock)
                {
                    Governor.PruneHistory();
                    current_state = _state;
                    current_input_data = device_inputs;
                    device_inputs = Array.Empty<byte>();
                }

                switch (current_state)
                {
                    case State.init:
                        CheckHandshake(ref current_input_data);
                        break;
                    case State.ready:
                        TransmitCommand();
                        break;
                    case State.command:
                        CheckResponse(ref current_input_data);
                        break;
                }

                lock (_thread_interlock)
                {
                    int pos = current_input_data.Length;
                    Array.Resize(ref current_input_data, pos + device_inputs.Length);
                    Buffer.BlockCopy(device_inputs, 0, current_input_data, pos, device_inputs.Length);
                    device_inputs = current_input_data;
                }

                QueueMaintenance();

                lock (_thread_interlock)
                {
                    should_exit = _thread_end;
                    if (CommandQueue.Count > 0) should_exit = false;
                }
                if (last_command != null) should_exit = false;
            }

            lock (_thread_interlock)
            {
                if (DeviceStream != null)
                {
                    DeviceStream.Close();
                    DeviceStream.Dispose();
                }
                DeviceStream = null;
            }

            ErrorCallback(this, "ET232 disconnected.", "Device should now be unlocked. Switch it off before reconnecting.", false);
        }

        private void Initialize()
        {
            last_command = null;
            last_command_time = 0;
            command_retries = 0;

            lock (_thread_interlock)
            {
                _state = State.init;
                CommandQueue.Clear();
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = AddressByte.InputOverride,
                    Data = ErosTek.ET232.Constants.OverrideAll,
                    Retry = true,
                });
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = AddressByte.Pot_A,
                    Data = 0,
                    Retry = true,
                });
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = AddressByte.Pot_B,
                    Data = 0,
                    Retry = true,
                });
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = AddressByte.ModeOverride,
                    Data = ErosTek.ET232.Constants.ForceMode | (byte)IntenseMode.Mode,
                    Retry = true,
                });
                CommandQueue.Add(new ET232Command()
                {
                    Command = CommandByte.write,
                    Address = AddressByte.Pot_MA,
                    Data = IntenseMode.StartingMA,
                    Retry = true,
                });
                draining_queue = true;
            }
        }

        private void CheckHandshake(ref byte [] input)
        {
            if (input.Length >= et232_handshake_sequence.Length)
            {
                for (int idx = 0; idx < et232_handshake_sequence.Length; idx++)
                {
                    if (input[idx] != et232_handshake_sequence[idx])
                    {
                        List<string> details = input.Select(e => String.Format("0x{0,2:X2}", new object[] { e })).ToList();
                        lock (_thread_interlock) _state = State.error;
                        ErrorCallback(this, "Handshake error.", "Bytes received: " + String.Join(", ", details), false);
                    }
                }
                byte[] temp = new byte[input.Length - et232_handshake_sequence.Length];
                if (temp.Length > 0) Buffer.BlockCopy(input, et232_handshake_sequence.Length, temp, 0, temp.Length);
                input = temp;
                Thread.Sleep(connect_delay);
                lock (_thread_interlock) _state = State.ready;
                QueueStateCallback(this, 0);
                ErrorCallback(this, "ET232 handshake complete.", "Manual controls are now locked out and will not respond until unlocked or power is removed.", false);
            }
        }

        private void TransmitCommand()
        {
            ET232Command command = null;
            lock (_thread_interlock)
            {
                if (CommandQueue.Count > 0)
                {
                    command = CommandQueue.First();
                    CommandQueue.RemoveAt(0);
                }
            }

            if(command != null)
            {
                if (command.IsWrite())
                {
                    if (command.Address == AddressByte.Pot_A) lock (_thread_interlock) command.Data = Governor.RegulateA(command.Data);
                    if (command.Address == AddressByte.Pot_B) lock (_thread_interlock) command.Data = Governor.RegulateB(command.Data);
                }

                byte[] data = command.Format();
                last_command = command;
                last_command_time = UnixTime.Current();
                lock (_thread_interlock)
                {
                    DeviceStream.Write(data, 0, data.Length);
                    _state = State.command;
                }
            }
        }

        private void CheckResponse(ref byte[] input)
        {
            double current_unixtime = UnixTime.Current();
            int expected_bytes = last_command.IsWrite() ? et232_success_sequence.Length : et232_read_response_length;
            if(input.Length < expected_bytes)
            {
                if (current_unixtime - last_command_time > command_timeout)
                {
                    HandleCommandFailure("Device timeout.");
                    input = Array.Empty<byte>();
                }
                return;
            }

            byte[] result_bytes = input;
            int extra_bytes = result_bytes.Length - expected_bytes;
            if (extra_bytes > 0)
            {
                input = new byte[extra_bytes];
                Buffer.BlockCopy(result_bytes, expected_bytes, input, 0, extra_bytes);
            }
            else input = Array.Empty<byte>();

            bool error = false;
            if (last_command.IsWrite())
            {
                for (int idx = 0; idx < et232_success_sequence.Length; idx++)
                    if (result_bytes[idx] != et232_success_sequence[idx]) error = true;
            }
            else if (result_bytes.Last() != (byte)'\n') error = true;

            if (error)
            {
                HandleCommandFailure("Device error.");
                return;
            }

            int ScalingFunction(int user_level, int function)
            {
                return (int)(Math.Sqrt(user_level * function));
            }

            command_retries = 0;
            if (last_command.IsWrite())
            {
                if (last_command.Address == AddressByte.Pot_A)
                {
                    lock (_thread_interlock)
                    {
                        Governor.RecordA(last_command.Data);
                        LastA = last_command.Data;
                    }
                }
                if (last_command.Address == AddressByte.Pot_B)
                {
                    lock (_thread_interlock)
                    {
                        Governor.RecordB(last_command.Data);
                        LastB = last_command.Data;
                    }
                }
                if (last_command.Address == AddressByte.Pot_MA) lock (_thread_interlock) LastMA = last_command.Data;
                if (last_command.Address == AddressByte.ModeOverride)
                {
                    lock (_thread_interlock) draining_queue = true;
                    Thread.Sleep(mode_delay);
                    StateUpdatedCallback(this, (int)last_command.Address, last_command.Data & ErosTek.ET232.Constants.ForceModeMask);
                }
                else StateUpdatedCallback(this, (int)last_command.Address, last_command.Data);
            }
            else
            {
                string result_string = Encoding.ASCII.GetString(result_bytes, 0, 2);
                try
                {
                    int result_value = int.Parse(result_string, System.Globalization.NumberStyles.HexNumber);
                    DataReturnedCallback(this, (int)last_command.Address, result_value);
                    LevelEvent level = new LevelEvent() { unixtime = current_unixtime, level = result_value };
                    if (last_command.Address == AddressByte.PulseAmp_A)
                    {
                        lock (_thread_interlock)
                        {
                            level.level = ScalingFunction(LastA, level.level);
                            AmpHistoryA.Add(level);
                        }
                    }
                    if (last_command.Address == AddressByte.PulseAmp_B)
                    {
                        lock (_thread_interlock)
                        {
                            level.level = ScalingFunction(LastB, level.level);
                            AmpHistoryB.Add(level);
                        }
                    }
                }
                catch (Exception)
                {
                    List<string> details = result_bytes.Select(e => String.Format("0x{0,2:X2}", new object[] { e })).ToList();
                    ErrorCallback(this,
                                  "Device returned invalid data.",
                                  "Bytes: " + input.Length + " Data: " + String.Join(", ", details), false);
                }
            }

            last_command = null;
            lock (_thread_interlock) _state = State.ready;
        }

        private void HandleCommandFailure(string failure)
        {
            ET232Command failed_command = last_command;
            last_command = null;
            string command_text = Encoding.ASCII.GetString(failed_command.Format());
            bool should_retry = failed_command.Retry;


            string details;
            if (should_retry)
            {
                command_retries++;
                if (command_retries > command_retry_limit)
                {
                    command_retries = 0;
                    should_retry = false;
                    details = "Command abandoned";
                }
                else
                {
                    details = "Retrying command";
                    CommandQueue.Insert(0, failed_command);
                }
            }
            else details = "Command aborted";

            ErrorCallback(this, failure, details + ": " + command_text, false);
            lock (_thread_interlock) _state = State.ready;
        }

        private void QueueMaintenance()
        {
            int report_queue_depth = 0;
            bool should_report_queue_state = false;
            lock (_thread_interlock)
            {
                if (CommandQueue.Count > command_queue_max_depth)
                    CommandQueue.RemoveAll(e => !e.Retry);
                if (last_queue_depth != CommandQueue.Count)
                {
                    last_queue_depth = CommandQueue.Count;
                    if (last_queue_depth == 0) draining_queue = false;
                    should_report_queue_state = true;
                    report_queue_depth = last_queue_depth;
                }
            }
            if(should_report_queue_state) QueueStateCallback(this, report_queue_depth);
        }

        private readonly byte[] et232_handshake_sequence = { 0x00, 0x43, 0x43 };
        private readonly byte[] et232_success_sequence = { (byte)'$', 0x0a };
        private const int et232_read_response_length = 3;
        private const int connect_delay = 1000;
        private const int mode_delay = 20;
        private const double command_timeout = 0.3;
        private const double command_retry_limit = 3;
        private const int command_queue_max_depth = 10;
        private readonly ErosTekModeData IntenseMode = ErosTek.Constants.Modes[ModeSelect.Intense];
        //private readonly ErosTekModeData WavesMode = ErosTek.Constants.Modes[ModeSelect.Waves];

        private ET232Command last_command = null;
        private double last_command_time;
        private int last_queue_depth = 0;
        private int command_retries = 0;

        private enum State
        {
            init,           // waiting for handshake
            ready,          // handshake received or command acknowledged, ready for command
            command,        // command sent, waiting for confirmation
            error           // oops
        };

        // The following are all shared state and must use "lock (_thread_interlock) { }" to access.
        private State _state = State.init;
        private int LastA = 0;
        private int LastB = 0;
        private int LastMA = 0;
        private bool draining_queue = false;
        private readonly List<ET232Command> CommandQueue = new List<ET232Command>();
    }
}
