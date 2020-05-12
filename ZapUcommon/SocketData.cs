using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://www.wtfpl.net/ for more details. */

namespace ZapUcommon
{
    public class SocketData
    {
        public SocketData(TcpClient client)
        {
            Client = client;
        }

        public TcpClient Client = null;

        public override string ToString()
        {
            if (Client == null || !Client.Connected) return "Not Connected";
            else return Client.Client.RemoteEndPoint.ToString();
        }

        public void Close()
        {
            if (Client != null && Client.Connected) Client.Close();
        }
    }
}
