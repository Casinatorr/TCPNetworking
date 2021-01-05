using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace NetworkingTesting
{
    class Server
    {
        public static int MaxConnections {
            get;
            private set;
        }

        public static int Port {
            get;
            private set;
        }

        private static TcpListener tcpListener;
        public static void Start(int _maxConnections, int _port)
        {
            MaxConnections = _maxConnections;
            Port = _port;

            Console.WriteLine("Starting Server...");

            tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();

            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);

            Console.WriteLine($"Started Server on Port: {Port}");
        }

        private static void TCPConnectCallback(IAsyncResult _result)
        {
            Console.WriteLine("lol");
        }
    }
}
