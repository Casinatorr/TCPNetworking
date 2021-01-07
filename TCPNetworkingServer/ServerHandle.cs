using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TCPNetworkingServer
{
    class ServerHandle
    {
        public static void ReceiveInit(int fromClient, Packet p)
        {
            int checkId = p.ReadInt();
            string username = p.ReadString();

            Server.clients[fromClient].username = username;
            Console.WriteLine($"{username} with Client ID: {fromClient} joined the server");
            ServerSend.SendLogin(fromClient);

            if(checkId != fromClient)
            {
                Console.WriteLine($"Client {username} ({fromClient}) has assumed the wrong client ID ({checkId})!");
            }
        }

        public static void ReceiveMessage(int fromClient, Packet p)
        {
            string msg = p.ReadString();
            Console.WriteLine($"{Server.clients[fromClient].username} sent: {msg}");
            ServerSend.SendMessage(fromClient, msg);
        }

        public static void ReceivePrivateMessage(int fromClient, Packet p)
        {
            int toClient = p.ReadInt();
            ServerSend.SendPrivateMessage(fromClient, toClient, p);
        }
    }
}
