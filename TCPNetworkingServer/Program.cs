using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TCPNetworkingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Start(50, 26950);
            Thread checkDisconnects = new Thread(CheckClientDisconnects);
            checkDisconnects.Start();
            Console.ReadKey();
        }

        public static void CheckClientDisconnects()
        {
            while (true)
            {
                for (int i = 1; i <= Server.MaxClients; i++)
                {
                    using (Packet p = new Packet((int) ServerPackets.ping))
                    {
                        p.Write("Ping");
                        p.WriteLength();
                        Server.clients[i].tcp.SendData(p);
                    }
                }
                Thread.Sleep(2000);
                
            }
        }
    }
}
