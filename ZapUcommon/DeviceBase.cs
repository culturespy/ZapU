using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUcommon
{
    public abstract class DeviceBase
    {
        public void SetStream(Stream stream)
        {
            lock(_thread_interlock) DeviceStream = stream;
        }

        public bool HasStream
        {
            get
            {
                bool retval;
                lock (_thread_interlock) retval = DeviceStream != null;
                return retval;
            }
        }
 
        public bool GovernorEnabled
        {
            get
            {
                bool retval;
                lock (_thread_interlock) retval = Governor.GovernorEnabled;
                return retval;
            }
            set
            {
                lock (_thread_interlock) Governor.GovernorEnabled = value;
            }
        }

        public double GovernorMaxAge
        {
            get
            {
                double retval;
                lock (_thread_interlock) retval = Governor.GovernorMaxAge;
                return retval;
            }
            set
            {
                lock (_thread_interlock) Governor.GovernorMaxAge = value;
            }
        }

        public int GovernorBuckets
        {
            get
            {
                int retval;
                lock (_thread_interlock) retval = Governor.GovernorBuckets;
                return retval;
            }
            set
            {
                lock (_thread_interlock) Governor.GovernorBuckets = value;
            }
        }

        public double GovernorGrowth
        {
            get
            {
                double retval;
                lock (_thread_interlock) retval = Governor.GovernorGrowth;
                return retval;
            }
            set
            {
                lock (_thread_interlock) Governor.GovernorGrowth = value;
            }
        }

        public int GovernorFreeRange
        {
            get
            {
                int retval;
                lock (_thread_interlock) retval = Governor.GovernorFreeRange;
                return retval;
            }
            set
            {
                lock (_thread_interlock) Governor.GovernorFreeRange = value;
            }
        }

        public int HardLimit
        {
            get
            {
                int retval;
                lock (_thread_interlock) retval = Governor.HardLimit;
                return retval;
            }
            set
            {
                lock (_thread_interlock) Governor.HardLimit = value;
            }
        }

        public DeviceQueueStateCallback     QueueStateCallback      { get; set; }
        public DeviceErrorCallback          ErrorCallback           { get; set; }
        public DeviceStateUpdatedCallback   StateUpdatedCallback    { get; set; }
        public DeviceMassLevelSetCallback   MassLevelSetCallback    { get; set; }
        public DeviceDataReturnedCallback   DataReturnedCallback    { get; set; }

        public abstract void Reset();
        public abstract void SetMode(ModeCommand mode);
        public abstract void SetLevels(LevelsCommand levels);
        public abstract void RawWrite(RawCommand raw);
        public abstract void RequestOutputData(RequestCommand request);
        public abstract void ReportOutputData(ResponseCommand response);
        public abstract void ReportError(ErrorCommand error);
        public virtual void Panic() { EndThread(); }
        public abstract string GetModeName(int mode);

        public virtual bool IsReady
        {
            get
            {
                bool retval;
                lock(_thread_interlock)
                {
                    retval = _thread != null;
                }
                return retval;
            }
        }

        public abstract void ThreadFunction();

        public void BeginThread()
        {
            EndThread();
            _thread = new Thread(ThreadFunction);
            _thread.Start();
        }

        public void EndThread()
        {
            if (_thread == null) return;
            Reset();
            lock (_thread_interlock) _thread_end = true;
            _thread.Join();
            _thread = null;
            lock (_thread_interlock) _thread_end = false;
        }

        public void PruneAmplitudeHistory(double cutoff)
        {
            lock(_thread_interlock)
            {
                foreach (List<LevelEvent> hist in new List<LevelEvent>[] { AmpHistoryA, AmpHistoryB })
                    hist.RemoveAll(e => e.unixtime < cutoff);
            }
        }

        public bool ExtractAmplitudeData(ref double[] a_time, ref double[] a_amp , ref double[] b_time, ref double[] b_amp)
        {
            bool retval;
            lock(_thread_interlock)
            {
                retval = AmpHistoryA.Count > 0 && AmpHistoryB.Count > 0;
                a_time = AmpHistoryA.Select(e => e.unixtime).ToArray();
                a_amp = AmpHistoryA.Select(e => (double)e.level).ToArray();
                b_time = AmpHistoryB.Select(e => e.unixtime).ToArray();
                b_amp = AmpHistoryB.Select(e => (double)e.level).ToArray();
            }
            return retval;
        }

        public delegate void DeviceQueueStateCallback(DeviceBase device, int depth);
        public delegate void DeviceErrorCallback(DeviceBase device, string message, string details, bool panic);
        public delegate void DeviceStateUpdatedCallback(DeviceBase device, int address, int data);
        public delegate void DeviceMassLevelSetCallback(DeviceBase device, int A, int B, int MA, bool absolute);
        public delegate void DeviceDataReturnedCallback(DeviceBase device, int address, int data);

        protected Stream DeviceStream = null;
        protected GovernorEngine Governor { get; } = new GovernorEngine();
        public List<LevelEvent> AmpHistoryA = new List<LevelEvent>();
        public List<LevelEvent> AmpHistoryB = new List<LevelEvent>();

        protected readonly object _thread_interlock = new object();
        protected bool _thread_end = false;

        private Thread _thread;
    }
}
