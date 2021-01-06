using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPNetworkingClientUI
{
    class ClientHandle
    {
        public static Action<string> onReceive;
        public static void ReceiveInit(Packet packet)
        {
            int myid = packet.ReadInt();

            Client.instance.myid = myid;
            Console.WriteLine("init received");
            ClientSend.InitReceived();
        }

        public static void ReceiveString(Packet packet)
        {
            string msg = packet.ReadString();
            Console.WriteLine(msg);
            onReceive(msg);
        }

        public static void ReceiveLogin(Packet packet)
        {
            string msg = packet.ReadString();
            Console.WriteLine(msg);
            onReceive(msg);
        }

        public static void Ping(Packet packet)
        {
        }
    }
}
