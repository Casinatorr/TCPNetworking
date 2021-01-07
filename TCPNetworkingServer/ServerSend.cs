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
            }
        }

        public static void SendLogin(int loginClient)
        {
            using(Packet p = new Packet((int) ServerPackets.sendLogin))
            {
                p.Write(loginClient);
                p.Write(Server.clients[loginClient].username);
                p.Write(true);
                SendTCPDataToAll(p);
            }

            //Sending the new client all other clients
            for(int i = 1; i < Server.MaxClients; i++)
            {
                if (Server.clients[i].tcp.socket == null) continue;
                if (i == loginClient) continue;
                using(Packet p = new Packet((int) ServerPackets.sendLogin))
                {
                    p.Write(Server.clients[i].id);
                    p.Write(Server.clients[i].username);
                    p.Write(false);
                    SendTCPData(loginClient, p);
                }
            }
        }

        public static void SendMessage(int fromClient, string msg)
        {
            using(Packet p = new Packet((int) ServerPackets.sendMessage))
            {
                p.Write(fromClient);
                p.Write(msg);
                SendTCPDataToAll(fromClient, p);
            }
        }

        public static void SendDisconnect(int client)
        {
            using(Packet p = new Packet((int) ServerPackets.disconnect))
            {
                p.Write(client);
                SendTCPDataToAll(client, p);
            }
        }

        public static void SendPrivateMessage(int fromClient, int toClient, Packet packet)
        {
            using (Packet p = new Packet((int) ServerPackets.sendPrivateMessage))
            {
                p.Write(fromClient);
                string msg = packet.ReadString();
                p.Write(msg);
                SendTCPData(toClient, p);
            }
        }

    }
}
