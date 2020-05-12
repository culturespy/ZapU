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
    public enum ControlMode
    {
        relative = 0,
        absolute = 1,
        remote = 3,
    };

    [Serializable()]
    public class LevelsCommand : CommandBase
    {
        public LevelsCommand()
        {
            ObjectType = TransmissionType.Levels;
        }

        public ControlMode Mode { get; set; } = ControlMode.relative;
        public int A { get; set; } = 0;
        public int B { get; set; } = 0;
        public int MA { get; set; } = 0;
    }
}
