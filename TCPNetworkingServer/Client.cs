using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPNetworkingServer
{
    class Client
    {
        public TCP tcp;
        public int id;
        public static int dataBufferSize = 4096;

        public Client(int _id)
        {
            id = _id;
        }

        public class TCP
        {
            public TcpClient socket;

            private readonly int id;
            private NetworkStream stream;
            private byte[] receiveBuffer;

            public TCP(int _id)
            {
                id = _id;
            }

            public void Connect(TcpClient _socket)
            {
                socket = _socket;
              
            }
        }
    }
}
