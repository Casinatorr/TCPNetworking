﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TCPNetworkingClientUI
{
    class OtherClient
    {
        public static Dictionary<int, OtherClient> otherClients = new Dictionary<int, OtherClient>();

        public string username;
        public int id;
        public Image profilePicture;

        public OtherClient(string username, int id)
        {
            this.id = id;
            this.username = username;
            otherClients.Add(id, this);
        }
        public static void init(string username, int id)
        {
            OtherClient c = new OtherClient(username, id);
        }

        public void Disconnect()
        {
            otherClients.Remove(id);
        }
    }
}
