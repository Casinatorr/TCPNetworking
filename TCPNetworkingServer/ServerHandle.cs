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

            Console.WriteLine($"Client {fromClient} answered init call");

            if(clientCheck != fromClient)
            {
                Console.WriteLine($"Client {fromClient} has assumed the wrong ID ({clientCheck})!");
            }
        }
    }
}
