using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPNetworkingClient
{
    class Client
    {
        public static Client instance;
        public static int dataBufferSize = 4096;

        public string ip = "4.tcp.ngrok.io";
        public int port = 19617;
        public int myid = 0;

        public TCP tcp;

        public Client()
        {
            instance = this;
            tcp = new TCP();
        }

        public class TCP
        {
            private TcpClient socket;
            private NetworkStream stream;

            private byte[] receiveBuffer;

            public void Connect()
            {
                socket = new TcpClient
                {
                    ReceiveBufferSize = dataBufferSize,
                    SendBufferSize = dataBufferSize
                };

                socket.BeginConnect(instance.ip, instance.port, ConnectCallback, null);
            }

            private void ConnectCallback(IAsyncResult result)
            {
                socket.EndConnect(result);
            }
        }
    }
}
