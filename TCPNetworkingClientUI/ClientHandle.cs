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
        public static Action<string> onReceive;
        public static Action<Image> onImageReceive;
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

        public static void ProfilePictureReceived(Packet p)
        {
            int client = p.ReadInt();
            byte[] data = p.ReadBytes(p.UnreadLength());
            using (var ms = new MemoryStream(data))
            {
                Image i = Image.FromStream(ms);
                OtherClient.otherClients[client].profilePicture = i;
                onImageReceive(i);
            }
        }

        public static void OtherLoginReceived(Packet p)
        {           
            int id = p.ReadInt();
            string username = p.ReadString();
            OtherClient.init(username, id);
            ClientSend.SendProfilePicture();
        }

        public static void DisconnectReceived(Packet p)
        {
            int id = p.ReadInt();
            ChatUI.instance.onReceive($"{OtherClient.otherClients[id].username} Disconnected!");
            OtherClient.otherClients[id].Disconnect();
        }
    }
}
