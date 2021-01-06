using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPNetworkingClientUI
{
    class ClientHandle
    {
        public static void ReceiveInit(Packet packet)
        {
            int myid = packet.ReadInt();

            Client.instance.myid = myid;

            ClientSend.InitReceived();
        }
    }
}
