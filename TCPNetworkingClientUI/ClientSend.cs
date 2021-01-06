using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static void InitReceived()
        {
            using(Packet p = new Packet((int) ClientPackets.initReceived))
            {
                p.Write(Client.instance.myid);
                p.Write(ChatUI.username);
                SendTCPData(p);
            }
            SendProfilePicture();
        }

        public static void SendString(string msg)
        {
            using (Packet p = new Packet((int) ClientPackets.sendString))
            {
                p.Write(msg);
                SendTCPData(p);
            }
        }

        public static void SendProfilePicture()
        {
            using(Packet p = new Packet((int) ClientPackets.profilePictureSend))
            {
                Console.WriteLine("Sending profile picture");
                p.Write(Client.instance.myid);
                byte[] imageData = ImageToByteArray(ChatUI.profilePicture);
                p.Write(imageData);
                SendTCPData(p);
            }
        }

        private static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
