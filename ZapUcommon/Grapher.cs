using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScottPlot;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUcommon
{
    public class Grapher
    {
        public static void Plot(DeviceBase device, ScottPlot.FormsPlot plot)
        {
            if (device == null) return;
            double current_unixtime = UnixTime.Current();
            double cutoff = current_unixtime - 5;
            device.PruneAmplitudeHistory(cutoff);

            double[] a_time = null, a_amp = null, b_time = null, b_amp = null;
            if(device.ExtractAmplitudeData(ref a_time, ref a_amp, ref b_time, ref b_amp))
            {
                plot.plt.Clear();
                plot.plt.PlotStep(a_time, a_amp);
                plot.plt.PlotStep(b_time, b_amp);
                plot.plt.Axis(cutoff, current_unixtime, 0, 255);
                plot.plt.Ticks(rulerModeX: false, rulerModeY: false, displayTicksX: false, displayTicksY: false);
                plot.plt.Frame(left: false, right: false, top: false);
                plot.plt.TightenLayout(padding: 0, render: true);
                plot.Render();
            }
        }
    }
}
