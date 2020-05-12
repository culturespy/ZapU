using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZapUcommon.ErosTek.ET232;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUcommon
{
    [Serializable()]
    public class ET232Command
    {
        public CommandByte Command { get; set; } = CommandByte.unknown;
        public AddressByte Address { get; set; } = 0;
        public int Data { get; set; } = 0;
        public bool Retry { get; set; } = false;

        public bool IsWrite() { return Command == CommandByte.write; }

        public bool IsLevelPot()
        {
            return Address == AddressByte.Pot_A || Address == AddressByte.Pot_B;
        }

        public bool IsMA()
        {
            return Address == AddressByte.Pot_MA;
        }

        public byte [] Format()
        {
            if (Command == CommandByte.write) return FormatWrite();
            else return FormatRead();
        }

        private byte[] FormatRead()
        {
            byte[] retval = new byte[] { (byte)Command, 0, 0, 0, 0, (byte)'\r' };
            ConvertAndInsert(ref retval, 1, (byte)Address);
            ApplyChecksum(ref retval);
            return retval;
        }

        private byte[] FormatWrite()
        {
            byte[] retval = new byte[] { (byte)Command, 0, 0, 0, 0, 0, 0, (byte)'\r' };
            ConvertAndInsert(ref retval, 1, (byte)Address);
            ConvertAndInsert(ref retval, 3, (byte)Data);
            ApplyChecksum(ref retval);
            return retval;
        }

        private static void ConvertAndInsert(ref byte[] target, int start, byte value)
        {
            string converted = String.Format("{0,2:X2}", new object[] { value });
            byte[] convbytes = Encoding.ASCII.GetBytes(converted);
            for (int src = 0; src < convbytes.Length; src++)
                target[start + src] = convbytes[src];
        }

        private static void ApplyChecksum(ref byte[] target)
        {
            int sum = target.Sum(e => (e >= 0x30 && e <= 0x90) ? e : 0) & 0xff;
            ConvertAndInsert(ref target, target.Length - 3, (byte)sum);
        }
    }
}
