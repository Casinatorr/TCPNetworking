using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPNetworkingClientUI
{
    class ClientSend
    {
        private static void SendTCPData(Packet packet)
        {
            packet.WriteLength();
            Client.instance.tcp.SendData(packet);
        }

        public static void InitReceived()
        {
            using(Packet p = new Packet((int) ClientPackets.initReceived))
            {
                p.Write(Client.instance.myid);
                SendTCPData(p);
            }
        }
    }
}
