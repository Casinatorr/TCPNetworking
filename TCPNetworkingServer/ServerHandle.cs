using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPNetworkingServer
{
    class ServerHandle
    {
        public static void InitReceived(int fromClient, Packet packet)
        {
            int clientCheck = packet.ReadInt();
            string clientUsername = packet.ReadString();
            Server.clients[fromClient].username = clientUsername;

            Console.WriteLine($"Client {fromClient} answered init call with Username: {clientUsername}");

            if(clientCheck != fromClient)
            {
                Console.WriteLine($"Client {fromClient} ({clientUsername}) has assumed the wrong ID ({clientCheck})!");
            }
        }

        public static void StringReceived(int fromClient, Packet packet)
        {
            string msg = packet.ReadString();

            Console.WriteLine($"{Server.clients[fromClient].username} ({fromClient}) sent: {msg}");
            Console.WriteLine("Passing on");
            ServerSend.SendString($"{Server.clients[fromClient].username}: {msg}", fromClient);
        }
    }
}
