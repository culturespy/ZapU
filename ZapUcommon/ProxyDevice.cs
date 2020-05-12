using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

using ZapUcommon.ErosTek;
using ZapUcommon.ErosTek.ET232;
using System.Net.NetworkInformation;
using System.Net.Sockets;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUcommon
{
    public class ProxyDevice : DeviceBase
    {
        public override void Reset()
        {
            lock (_thread_interlock)
            {
                CommandQueue.Clear();
                CommandQueue.Add(new ReadyCommand());
            }
        }

        public override void SetLevels(LevelsCommand levels)
        {
            lock(_thread_interlock) CommandQueue.Add(levels);
        }

        public override void RawWrite(RawCommand write)
        {
            lock (_thread_interlock) CommandQueue.Add(write);
        }

        public override void SetMode(ModeCommand mode)
        {
            lock (_thread_interlock) CommandQueue.Add(mode);
        }

        public override void RequestOutputData(RequestCommand request)
        {
            lock (_thread_interlock) CommandQueue.Add(request);
        }

        public override void ReportOutputData(ResponseCommand response)
        {
            lock (_thread_interlock) CommandQueue.Add(response);
        }

        public override void ReportError(ErrorCommand error)
        {
            lock (_thread_interlock) CommandQueue.Add(error);
        }

        public override void Panic()
        {
            lock (_thread_interlock)
            {
                CommandQueue.Clear();
                CommandQueue.Add(new PanicCommand());
            }
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
                lock (_thread_interlock) if (retval) retval = CommandQueue.Count == 0;
                return retval;
            }
        }

        public override void ThreadFunction()
        {
            ErrorCallback(this, "Network processing startup.", "", false);

            bool should_exit = false;
            byte[] remote_bytes = Array.Empty<byte>();
            NetworkHeader read_header = null;
            Utf8JsonWriter jsonwriter;

            lock (_thread_interlock)
            {
                jsonwriter = new Utf8JsonWriter(DeviceStream);
                CommandQueue.Clear();
            }

            byte[] read_buffer = new byte[block_size];
            void DataReader()
            {
                try
                {
                    lock (_thread_interlock) DeviceStream.BeginRead(read_buffer, 0, read_buffer.Length, delegate (IAsyncResult ar)
                    {
                        try
                        {
                            lock (_thread_interlock)
                            {
                                if (DeviceStream == null) return;
                                int len = DeviceStream.EndRead(ar);
                                int pos = remote_bytes.Length;
                                Array.Resize(ref remote_bytes, pos + len);
                                Buffer.BlockCopy(read_buffer, 0, remote_bytes, pos, len);
                            }
                        }
                        catch (Exception e)
                        {
                            bool exiting;
                            lock (_thread_interlock) exiting = _thread_end;
                            if (!exiting) ErrorCallback(this, "Network error.", e.Message, false);
                        }
                        DataReader();
                    }, null);
                }
                catch (Exception e)
                {
                    bool exiting;
                    lock (_thread_interlock) exiting = _thread_end;
                    if (!exiting) ErrorCallback(this, "Network error.", e.Message, false);
                }
            }
            DataReader();

            while (!should_exit)
            {
                Thread.Yield();

                long consumed = 0;
                if (read_header == null)
                {
                    try
                    {
                        lock (_thread_interlock)
                        {
                            if(remote_bytes.Length > 0)
                            {
                                Utf8JsonReader jsonreader = new Utf8JsonReader(new ReadOnlySpan<byte>(remote_bytes));
                                read_header = JsonSerializer.Deserialize<NetworkHeader>(ref jsonreader);
                                consumed = jsonreader.BytesConsumed;
                            }
                        }
                    }
                    catch (JsonException) { }
                }
                else
                {
                    CommandBase received_command = null;
                    try
                    {
                        lock (_thread_interlock)
                        {
                            if (remote_bytes.Length > 0)
                            {
                                Utf8JsonReader jsonreader = new Utf8JsonReader(new ReadOnlySpan<byte>(remote_bytes));
                                switch (read_header.ObjectType)
                                {
                                    case TransmissionType.Nothing:
                                        break;
                                    case TransmissionType.Ready:
                                        received_command = JsonSerializer.Deserialize<ReadyCommand>(ref jsonreader);
                                        break;
                                    case TransmissionType.Panic:
                                        received_command = JsonSerializer.Deserialize<PanicCommand>(ref jsonreader);
                                        break;
                                    case TransmissionType.Levels:
                                        received_command = JsonSerializer.Deserialize<LevelsCommand>(ref jsonreader);
                                        break;
                                    case TransmissionType.Raw:
                                        received_command = JsonSerializer.Deserialize<RawCommand>(ref jsonreader);
                                        break;
                                    case TransmissionType.Mode:
                                        received_command = JsonSerializer.Deserialize<ModeCommand>(ref jsonreader);
                                        break;
                                    case TransmissionType.Response:
                                        received_command = JsonSerializer.Deserialize<DeviceResponse>(ref jsonreader);
                                        break;
                                    case TransmissionType.Request:
                                        break;
                                    case TransmissionType.Error:
                                        received_command = JsonSerializer.Deserialize<ErrorCommand>(ref jsonreader);
                                        break;
                                }
                                consumed = jsonreader.BytesConsumed;
                            }
                        }
                    }
                    catch (JsonException) { }

                    if(received_command != null)
                    {
                        switch (read_header.ObjectType)
                        {
                            case TransmissionType.Nothing:
                                break;
                            case TransmissionType.Ready:
                                QueueStateCallback(this, 0);
                                break;
                            case TransmissionType.Panic:
                                MassLevelSetCallback(this, 0, 0, 0, true);
                                ErrorCallback(this, "PANIC!", "Panic received from remote!", true);
                                break;
                            case TransmissionType.Levels:
                                LevelsCommand levels = (LevelsCommand)received_command;
                                LastA = levels.A;
                                LastB = levels.B;
                                MassLevelSetCallback(this, levels.A, levels.B, levels.MA, levels.Mode == ControlMode.absolute);
                                break;
                            case TransmissionType.Raw:
                                RawCommand raw = (RawCommand)received_command;
                                if (raw.Address == (int)AddressByte.Pot_A) LastA = raw.Data;
                                if (raw.Address == (int)AddressByte.Pot_B) LastB = raw.Data;
                                StateUpdatedCallback(this, raw.Address, raw.Data);
                                break;
                            case TransmissionType.Mode:
                                ModeCommand mode = (ModeCommand)received_command;
                                StateUpdatedCallback(this, (int)AddressByte.ModeOverride, mode.Mode);
                                StateUpdatedCallback(this, (int)AddressByte.Pot_MA, mode.MA);
                                break;
                            case TransmissionType.Request:
                                break;
                            case TransmissionType.Response:
                                DeviceResponse response = (DeviceResponse)received_command;
                                DataReturnedCallback(this, response.Address, response.Data);
                                double current_unixtime = UnixTime.Current();
                                LevelEvent level = new LevelEvent() { unixtime = current_unixtime };
                                lock (_thread_interlock)
                                {
                                    if (response.Address == (int)AddressByte.PulseAmp_A)
                                    {
                                        level.level = (int)Math.Sqrt(LastA * response.Data);
                                        AmpHistoryA.Add(level);
                                    }
                                    if (response.Address == (int)AddressByte.PulseAmp_B)
                                    {
                                        level.level = (int)Math.Sqrt(LastB * response.Data);
                                        AmpHistoryB.Add(level);
                                    }
                                }
                                break;
                            case TransmissionType.Error:
                                ErrorCommand error = (ErrorCommand)received_command;
                                ErrorCallback(this, error.Error, error.Details, false);
                                break;
                        }
                        read_header = null;
                    }
                }

                if(consumed > 0)
                {
                    lock (_thread_interlock)
                    {
                        byte[] remaining = new byte[remote_bytes.Length - consumed];
                        Buffer.BlockCopy(remote_bytes, (int)consumed, remaining, 0, remaining.Length);
                        remote_bytes = remaining;
                    }
                }

                lock (_thread_interlock)
                {
                    if (CommandQueue.Count > 0)
                    {
                        CommandBase command = CommandQueue.First();
                        CommandQueue.RemoveAt(0);
                        NetworkHeader write_header = new NetworkHeader() { ObjectType = command.ObjectType };
                        try
                        {
                            JsonSerializer.Serialize(jsonwriter, write_header, typeof(NetworkHeader));
                            jsonwriter.Flush();
                            jsonwriter.Reset();
                            switch (command.ObjectType)
                            {
                                case TransmissionType.Nothing:
                                    break;
                                case TransmissionType.Ready:
                                    JsonSerializer.Serialize(jsonwriter, (ReadyCommand)command, typeof(ReadyCommand));
                                    break;
                                case TransmissionType.Panic:
                                    JsonSerializer.Serialize(jsonwriter, (PanicCommand)command, typeof(PanicCommand));
                                    break;
                                case TransmissionType.Levels:
                                    JsonSerializer.Serialize(jsonwriter, (LevelsCommand)command, typeof(LevelsCommand));
                                    break;
                                case TransmissionType.Raw:
                                    JsonSerializer.Serialize(jsonwriter, (RawCommand)command, typeof(RawCommand));
                                    break;
                                case TransmissionType.Mode:
                                    JsonSerializer.Serialize(jsonwriter, (ModeCommand)command, typeof(ModeCommand));
                                    break;
                                case TransmissionType.Request:
                                    JsonSerializer.Serialize(jsonwriter, (RequestCommand)command, typeof(RequestCommand));
                                    break;
                                case TransmissionType.Response:
                                    JsonSerializer.Serialize(jsonwriter, (ResponseCommand)command, typeof(ResponseCommand));
                                    break;
                                case TransmissionType.Error:
                                    JsonSerializer.Serialize(jsonwriter, (ErrorCommand)command, typeof(ErrorCommand));
                                    break;
                            }
                            jsonwriter.Flush();
                            jsonwriter.Reset();
                        }
                        catch (JsonException) { }
                        catch (IOException e) when (e.InnerException is SocketException)
                        {
                            _thread_end = true;
                            ErrorCallback(this, "Network error.", e.InnerException.Message, false);
                        }
                        catch (IOException e)
                        {
                            _thread_end = true;
                            ErrorCallback(this, "Network error.", e.Message, false);
                        }
                        catch (Exception e)
                        {
                            _thread_end = true;
                            ErrorCallback(this, "Network error.", e.Message, false);
                        }
                        if (CommandQueue.Count == 0 && command.ObjectType != TransmissionType.Ready)
                            CommandQueue.Add(new ReadyCommand());
                    }
                    should_exit = _thread_end;
                }
            }

            try
            {
                lock (_thread_interlock)
                {
                    if (DeviceStream != null)
                    {
                        DeviceStream.Close();
                        DeviceStream.Dispose();
                    }
                    DeviceStream = null;
                }
            }
            catch (Exception e)
            {
                ErrorCallback(this, "Network error.", e.Message, false);
            }

            ErrorCallback(this, "Network processing shutdown.", "", false);
        }

        private int LastA = 0;
        private int LastB = 0;

        private readonly List<CommandBase> CommandQueue = new List<CommandBase>();
        const int block_size = 1024;
    }
}
