using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUcommon
{
    public partial class GovernorEngine
    {
        public bool GovernorEnabled { get; set; } = false;
        public double GovernorMaxAge { get; set; } = 60;
        public int GovernorBuckets { get; set; } = 10;
        public double GovernorGrowth { get; set; } = 1.5;
        public int GovernorFreeRange { get; set; } = 32;
        public int HardLimit { get; set; } = 255;

        public int RegulateA(int a)
        {
            return RegulateChannel(a, HistoryA, UnixTime.Current());
        }

        public int RegulateB(int b)
        {
            return RegulateChannel(b, HistoryB, UnixTime.Current());
        }

        private int RegulateChannel(int value, List<LevelEvent> history, double current_unixtime)
        {
            if (GovernorEnabled)
            {
                double bucket_width = GovernorMaxAge / GovernorBuckets;
                int divisor = (GovernorBuckets * (GovernorBuckets + 1)) / 2;

                int weighted_bucket_total = 0;

                for (int bkt = 0; bkt < GovernorBuckets; bkt++)
                {
                    double bucket_begin = current_unixtime - GovernorMaxAge + (bucket_width * bkt);
                    double bucket_end = bucket_begin + bucket_width;

                    List<LevelEvent> bucket = history.Where(e => e.unixtime >= bucket_begin &&
                                                                 e.unixtime < bucket_end).ToList();

                    if (bucket.Count > 0) weighted_bucket_total += (int)(bucket.Average(e => e.level) * (bkt + 1) / divisor);
                }

                int tolerance = (int)(weighted_bucket_total * GovernorGrowth);
                int limit = GovernorFreeRange > tolerance ? GovernorFreeRange : tolerance;
                value = value < limit ? value : limit;
                value = value > 255 ? 255 : value;
                value = value < 0 ? 0 : value;
            }

            value = value < HardLimit ? value : HardLimit;
            value = value > 255 ? 255 : value;
            value = value < 0 ? 0 : value;
            return value;
        }

        public void PruneHistory()
        {
            const double refresh_interval = 0.5;
            double current_unixtime = UnixTime.Current();

            if (HistoryA.Count > 0)
            {
                LevelEvent ale = HistoryA.Last();
                if (current_unixtime - ale.unixtime > refresh_interval)
                    HistoryA.Add(new LevelEvent() { level = ale.level, unixtime = current_unixtime });
            }
            if (HistoryB.Count > 0)
            {
                LevelEvent ble = HistoryB.Last();
                if (current_unixtime - ble.unixtime > refresh_interval)
                    HistoryB.Add(new LevelEvent() { level = ble.level, unixtime = current_unixtime });
            }

            int idx;
            idx = HistoryA.FindIndex(e => current_unixtime - e.unixtime > GovernorMaxAge);
            if(idx >= 0) HistoryA.RemoveRange(0, idx);
            idx = HistoryB.FindIndex(e => current_unixtime - e.unixtime > GovernorMaxAge);
            if (idx >= 0) HistoryB.RemoveRange(0, idx);
        }

        public void RecordA(int value)
        {
            RecordChannel(HistoryA, value);
        }

        public void RecordB(int value)
        {
            RecordChannel(HistoryB, value);
        }

        private void RecordChannel(List<LevelEvent> history, int value)
        {
            history.Add(new LevelEvent() { unixtime = UnixTime.Current(), level = value });
        }

        private readonly List<LevelEvent> HistoryA = new List<LevelEvent>();
        private readonly List<LevelEvent> HistoryB = new List<LevelEvent>();
    }
}
