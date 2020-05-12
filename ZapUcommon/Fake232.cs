using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class Fake232 : DeviceBase
    {
        public override void Reset()
        {
            QueueStateCallback(this, 0);
        }

        public override void SetMode(ModeCommand mode)
        {
            StateUpdatedCallback(this, (int)AddressByte.ModeOverride, mode.Mode);
            StateUpdatedCallback(this, (int)AddressByte.Pot_MA, mode.MA);
        }

        public override void SetLevels(LevelsCommand levels)
        {
            int A, B, MA;
            double current_unixtime = UnixTime.Current();

            lock (_thread_interlock)
            {
                if (levels.Mode == ControlMode.absolute)
                {
                    LastA = levels.A;
                    LastB = levels.B;
                }
                else
                {
                    LastA += levels.A;
                    LastB += levels.B;
                }

                if (LastA > 255) LastA = 255;
                if (LastB > 255) LastB = 255;
                if (LastA < 0) LastA = 0;
                if (LastB < 0) LastB = 0;

                AmpHistoryA.Add(new LevelEvent() { unixtime = current_unixtime, level = LastA });
                AmpHistoryB.Add(new LevelEvent() { unixtime = current_unixtime, level = LastB });

                A = LastA;
                B = LastB;
            }

            StateUpdatedCallback(this, (int)AddressByte.Pot_A, A);
            StateUpdatedCallback(this, (int)AddressByte.Pot_B, B);
            if (levels.MA != 0)
            {
                lock(_thread_interlock)
                {
                    LastMA += levels.MA;
                    if (LastMA > 255) LastMA = 255;
                    if (LastMA < 0) LastMA = 0;
                    MA = LastMA;
                }
                StateUpdatedCallback(this, (int)AddressByte.Pot_MA, MA);
            }
        }

        public override void RawWrite(RawCommand raw)
        {
            StateUpdatedCallback(this, raw.Address, raw.Data);
        }

        public override void RequestOutputData(RequestCommand request)
        {
            int data = 0;
            lock(_thread_interlock)
            {
                if (request.Address == (int)AddressByte.PulseAmp_A) data = LastA;
                if (request.Address == (int)AddressByte.PulseAmp_B) data = LastB;
            }
            DataReturnedCallback(this, request.Address, data);
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

        public override void ThreadFunction()
        {
            ErrorCallback(this, "Simulated device startup.", "", false);
            SetMode(new ModeCommand() { Mode = (int)IntenseMode.Mode, MA = IntenseMode.StartingMA });
            bool should_exit = false;
            while (!should_exit)
            {
                Thread.Yield();
                lock (_thread_interlock)
                {
                    Governor.PruneHistory();
                    should_exit = _thread_end;
                }
                Thread.Sleep(50);
                QueueStateCallback(this, 0);
            }
            ErrorCallback(this, "Simulated device shutdown.", "", false);
        }

        private readonly ErosTekModeData IntenseMode = ErosTek.Constants.Modes[ModeSelect.Intense];

        private int LastA = 0;
        private int LastB = 0;
        private int LastMA = 128;
    }
}
