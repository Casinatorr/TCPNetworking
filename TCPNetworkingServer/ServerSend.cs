using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TCPNetworkingServer
{
    class ServerSend
    {
        private static void SendTCPData(int toClient, Packet packet)
        {
            packet.WriteLength();
            Server.clients[toClient].tcp.SendData(packet);
        }

        private static void SendTCPDataToAll(Packet packet)
        {
            packet.WriteLength();
            for (int i = 1; i <= Server.MaxClients; i++)
            {
                Server.clients[i].tcp.SendData(packet);
            }
        }

        private static void SendTCPDataToAll(int exceptClient, Packet packet)
        {
            packet.WriteLength();
            for (int i = 1; i <= Server.MaxClients; i++)
            {
                if (i == exceptClient) continue;
                Server.clients[i].tcp.SendData(packet);
            }
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

        public static void SendString(int toClient, string msg)
        {
            using (Packet p = new Packet((int) ServerPackets.sendString))
            {
                p.Write(msg);
                SendTCPData(toClient, p);
            }
        }

        public static void SendString(string msg, bool all)
        {
            using (Packet p = new Packet((int) ServerPackets.sendString))
            {
                p.Write(msg);
                SendTCPDataToAll(p);
            }
        }

        public static void SendString(string msg, int exceptClient)
        {
            using (Packet p = new Packet((int) ServerPackets.sendString))
            {
                p.Write(msg);
                SendTCPDataToAll(exceptClient, p);
            }
        }

        public static void SendLogin(int loginClient)
        {
            using (Packet p = new Packet((int) ServerPackets.sendLogin))
            {
                p.Write($"{Server.clients[loginClient].username} logged in!");
                SendTCPDataToAll(p);
            }
        }

        public static void SendOtherLogin(int loginClient)
        {
            using (Packet p = new Packet((int) ServerPackets.sendOtherLogin))
            {
                Console.WriteLine(loginClient);
                p.Write(loginClient);
                p.Write(Server.clients[loginClient].username);
                SendTCPDataToAll(loginClient, p);
            }
        }

        public static void SendAllLogins(int toClient)
        {
            for(int i = 1; i <= Server.MaxClients; i++)
            {
                if (i == toClient) continue;
                if (Server.clients[i].tcp.socket == null) continue;
                using (Packet p = new Packet((int) ServerPackets.sendOtherLogin))
                {
                    p.Write(i);
                    p.Write(Server.clients[i].username);
                    SendTCPData(toClient, p);
                }
            }
        }

        public static void SendProfilePicure(int fromClient, Packet packet)
        {
            using (Packet p = new Packet((int) ServerPackets.profilePicture))
            {
                packet.ReadInt();
                p.Write(fromClient);
                p.Write(packet.ReadBytes(packet.UnreadLength()));
                SendTCPDataToAll(fromClient, p);
            }
        }

        public static void SendDisconnect(int client)
        {
            using(Packet p = new Packet((int) ServerPackets.Disconnect))
            {
                p.Write(client);
                SendTCPDataToAll(client, p);
            }
        }
    }
}
