using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        public static void SendInit()
        {
            using(Packet p = new Packet((int) ClientPackets.init))
            {
                p.Write(Client.instance.myid);
                p.Write(ChatUI.username);
                SendTCPData(p);
            }
        }

        public static void SendMessage(string msg)
        {
            using(Packet p = new Packet((int) ClientPackets.sendMessage))
            {
                p.Write(msg);
                SendTCPData(p);
            }
        }


        public static void SendPrivateMessage(int toClient, string msg)
        {
            using(Packet p = new Packet((int) ClientPackets.sendPrivateMessage))
            {
                p.Write(toClient);
                p.Write(msg);
                SendTCPData(p);
            }
        }

    }
}
