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
    [Serializable()]
    public class RawCommand : CommandBase
    {
        public RawCommand()
        {
            ObjectType = TransmissionType.Raw;
        }

        public int Address { get; set; } = 0;
        public int Data { get; set; } = 0;
    }
}
