using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPNetworkingServer
{
    class ServerSend
    {
        private static void SendTCPData(int toClient, Packet packet)
        {
            packet.WriteLength();
            Server.clients[toClient].tcp.SendData(packet);
        }

        public static void SendInit(int toClient)
        {
            using (Packet p = new Packet((int) ServerPackets.sendInit))
            {
                p.Write(toClient);

                SendTCPData(toClient, p);
                Console.WriteLine("Sent init packet");
            }
        }
    }
}
