using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPNetworkingServer
{
    class Server
    {
        public static int Port {
            get;
            private set;
        }
        public static int MaxClients {
            get;
            private set;
        }

        private static TcpListener tcpListener;
        public static Dictionary<int, Client> clients = new Dictionary<int, Client>();

        public delegate void PacketHandler(int _fromClient, Packet _packet);
        public static Dictionary<int, PacketHandler> packetHandlers;

        public static void Start(int _maxPlayers, int _port)
        {
            Port = _port;
            MaxClients = _maxPlayers;

            Console.WriteLine("Starting Server...");
            InitializeServerData();

            tcpListener = new TcpListener(IPAddress.Any, Port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);

            Console.WriteLine($"Server started on Port {Port}");
        }

        private static void TCPConnectCallback(IAsyncResult result)
        {
            TcpClient client = tcpListener.EndAcceptTcpClient(result);
            tcpListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);
            Console.WriteLine($"Incoming connection from {client.Client.RemoteEndPoint}...");


            for(int i = 1; i <= MaxClients; i++)
            {
                if(clients[i].tcp.socket == null)
                {
                    clients[i].tcp.Connect(client);
                    return;
                }
            }

            Console.WriteLine($"{client.Client.RemoteEndPoint} failed to connect: Server full!");
        }

        private static void InitializeServerData()
        {
            for(int i = 0; i < MaxClients; i++)
            {
                clients.Add(i, new Client(i));
            }

            packetHandlers = new Dictionary<int, PacketHandler>()
            {
                {(int)ClientPackets.initReceived, ServerHandle.InitReceived }
            };

            Console.WriteLine("Initialized Packets");
        }

    }
}
