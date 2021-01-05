using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPNetworkingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            c.tcp.Connect();
            Console.ReadKey();
        }
    }
}
