using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZapUcommon.ErosTek;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUcommon
{
    [Serializable()]
    public class ErosTekModeData
    {
        public ModeSelect Mode { get; set; } = ModeSelect.Intense;
        public string Name { get; set; } = "UNKNOWN";
        public int StartingMA { get; set; } = 0;
    }
}
