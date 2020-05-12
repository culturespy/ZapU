using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUcommon
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransmissionType
    {
        Nothing = 0,
        Ready = 1,
        Panic = 2,
        Levels = 3,
        Raw = 4,
        Mode = 5,
        Request = 6,
        Response = 7,
        Error = 8,
    };

    [Serializable()]
    public class CommandBase
    {
        public TransmissionType ObjectType { get; set; } = TransmissionType.Nothing;
    }
}
