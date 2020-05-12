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
    namespace ErosTek
    {
        public enum ModeSelect
        {
            Throb = 0x00,
            Climb = 0x01,
            AudioLoud = 0x02,
            AudioWaves = 0x03,
            Combo = 0x04,
            HiFreq = 0x05,
            AudioSoft = 0x06,
            User = 0x07,
            Thump = 0x08,
            Ramp = 0x09,
            Intense = 0x0a,
            Waves = 0x0b,
            Thrust = 0x0c,
            Stroke = 0x0d,
            Random = 0x0e,
            Off = 0x0f,
        };

        public class Constants
        {
            public static Dictionary<ModeSelect, ErosTekModeData> Modes = new Dictionary<ModeSelect, ErosTekModeData>()
            {
                { ModeSelect.Throb,      new ErosTekModeData() { Mode = ModeSelect.Throb,      Name = "Throb",        StartingMA = 255,   } },
                { ModeSelect.Climb,      new ErosTekModeData() { Mode = ModeSelect.Climb,      Name = "Climb",        StartingMA = 210,   } },
                { ModeSelect.AudioLoud,  new ErosTekModeData() { Mode = ModeSelect.AudioLoud,  Name = "Audio Loud",   StartingMA = 0,     } },
                { ModeSelect.AudioWaves, new ErosTekModeData() { Mode = ModeSelect.AudioWaves, Name = "Audio Waves",  StartingMA = 0,     } },
                { ModeSelect.Combo,      new ErosTekModeData() { Mode = ModeSelect.Combo,      Name = "Combo",        StartingMA = 210,   } },
                { ModeSelect.HiFreq,     new ErosTekModeData() { Mode = ModeSelect.HiFreq,     Name = "HiFreq",       StartingMA = 255,   } },
                { ModeSelect.AudioSoft,  new ErosTekModeData() { Mode = ModeSelect.AudioSoft,  Name = "Audio Soft",   StartingMA = 0,     } },
                { ModeSelect.User,       new ErosTekModeData() { Mode = ModeSelect.User,       Name = "User",         StartingMA = 255,   } },
                { ModeSelect.Thump,      new ErosTekModeData() { Mode = ModeSelect.Thump,      Name = "Thump",        StartingMA = 210,   } },
                { ModeSelect.Ramp,       new ErosTekModeData() { Mode = ModeSelect.Ramp,       Name = "Ramp",         StartingMA = 210,   } },
                { ModeSelect.Intense,    new ErosTekModeData() { Mode = ModeSelect.Intense,    Name = "Intense",      StartingMA = 150,   } },
                { ModeSelect.Waves,      new ErosTekModeData() { Mode = ModeSelect.Waves,      Name = "Waves",        StartingMA = 210,   } },
                { ModeSelect.Thrust,     new ErosTekModeData() { Mode = ModeSelect.Thrust,     Name = "Thrust",       StartingMA = 128,   } },
                { ModeSelect.Stroke,     new ErosTekModeData() { Mode = ModeSelect.Stroke,     Name = "Stroke",       StartingMA = 128,   } },
                { ModeSelect.Random,     new ErosTekModeData() { Mode = ModeSelect.Random,     Name = "Random",       StartingMA = 210,   } },
                { ModeSelect.Off,        new ErosTekModeData() { Mode = ModeSelect.Off,        Name = "Off",          StartingMA = 0,     } },
            };
        }

        namespace ET232
        {
            public enum CommandByte
            {
                read = 'H',
                write = 'I',
                unknown = 'J',
            };

            public enum AddressByte
            {
                PulseWidth_A = 0x08,
                PulseFreqRecip_A = 0x09,
                PulseAmp_A = 0x0A,
                PulsePower_A = 0x0B,
                PulsePolarity_A = 0x0C,
                PulseWidth_B = 0x0E,
                PulseFreqRecip_B = 0x0F,
                PulseAmp_B = 0x10,
                PulsePower_B = 0x11,
                PulsePolarity_B = 0x12,
                Pot_B = 0x88,
                Pot_MA = 0x89,
                BatteryVoltage = 0x8A,
                AudioInputLevel = 0x8B,
                Pot_A = 0x8C,
                ModeSwitch = 0xA2,
                ModeOverride = 0xA3,
                InputOverride = 0xA4,
                PowerOffTimer = 0xD3,
                ProgramFadeInTimer = 0xD8,
            };

            public class Constants
            {
                public const byte OverrideB =       0b00000001;
                public const byte OverrideMA =      0b00000010;
                public const byte OverrideBatt =    0b00000100;
                public const byte OverrideAudio =   0b00001000;
                public const byte OverrideA =       0b00010000;
                public const byte OverrideAll =     0b00011111;
                public const byte OverrideNone =    0b00000000;

                public const byte ForceMode = 0x80;
                public const byte ForceReset = 0x8F;

                public const byte ForceModeMask = 0xFF ^ ForceMode;
            }
        }
    }
}
