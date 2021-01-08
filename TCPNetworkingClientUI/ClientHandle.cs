using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPNetworkingClientUI
{
    class ClientHandle
    {
        public static Action<int, string> onReceive;
        public static void ReceiveInit(Packet packet)
        {
            int myid = packet.ReadInt();

            Client.instance.myid = myid;
            Console.WriteLine("init received");
            //Return init packet with username and profile picture
            ClientSend.SendInit();
        }

        public static void ReceiveLogin(Packet packet)
        {
            int id = packet.ReadInt();
            string username = packet.ReadString();
            bool newLogin = packet.ReadBool();
            //Add client to list
            OtherClient.init(username, id, newLogin);
        }

        public static void ReceiveMessage(Packet packet)
        {
            int id = packet.ReadInt();
            string msg = packet.ReadString();

            onReceive(id, msg);
        }

        public static void ReceiveDisconnect(Packet packet)
        {
            int id = packet.ReadInt();
            //Remove client from list
            OtherClient.otherClients[id].Disconnect();
        }

        public static void Ping(Packet packet)
        {
        }

        public static void ReceivePrivateMessage(Packet packet)
        {
            int fromClient = packet.ReadInt();
            string msg = packet.ReadString();
            Console.WriteLine($"Received private message from {fromClient}: {msg}");
            OtherClient.otherClients[fromClient].AppendToChat($"{OtherClient.otherClients[fromClient].username}: {msg}");
        }

        public static void ReceiveAudioMessage(Packet p)
        {
            int fromClient = p.ReadInt();
            string msg = p.ReadString();
            byte[] data = p.ReadBytes(p.UnreadLength());
            ChatUI.instance.lastAudio = data;
            ChatUI.instance.Invoke(new Action(() =>
            {
                ChatUI.instance.SetAudioMessage($"{OtherClient.otherClients[fromClient].username}: {msg}");
            }));
        }

    }
}
