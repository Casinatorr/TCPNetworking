﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Drawing;

namespace TCPNetworkingClientUI
{
    class Client
    {
        public static Client instance;
        public static int dataBufferSize = 4096;
        private bool isConnected = false;

        public string ip = "4.tcp.ngrok.io";
        public int port = 11079;
        public int myid = 0;

        public TCP tcp;

        public static Action<bool> onConnect;

        private delegate void PacketHandler(Packet _packet);
        private static Dictionary<int, PacketHandler> packetHandlers;
        public static Action onDisconnect;

        public Client()
        {
            instance = this;
            tcp = new TCP();
            InitializeClientData();
        }

        public static void init()
        {
            Client c = new Client();
        }

        public class TCP
        {
            public TcpClient socket;
            private NetworkStream stream;

            private byte[] receiveBuffer;
            private Packet receivedData;

            public void Connect()
            {
                instance.isConnected = true;
                socket = new TcpClient
                {
                    ReceiveBufferSize = dataBufferSize,
                    SendBufferSize = dataBufferSize
                };

                receiveBuffer = new byte[dataBufferSize];
                socket.BeginConnect(instance.ip, instance.port, ConnectCallback, null);
            }

            public void SendData(Packet packet)
            {
                try
                {
                    if(socket != null)
                    {
                        stream.BeginWrite(packet.ToArray(), 0, packet.Length(), null, null);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending data to server via TCP: {ex}");
                }
            }

            private void ConnectCallback(IAsyncResult result)
            {
                try
                {
                    socket.EndConnect(result);
                    if (!socket.Connected)
                    {
                        return;
                    }
                    stream = socket.GetStream();
                    onConnect(true);

                    receivedData = new Packet();
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch
                {
                    onConnect(false);
                }
            }

            private void ReceiveCallback(IAsyncResult result)
            {
                if (!instance.isConnected)
                    return;
                try
                {
                    int byteLength = stream.EndRead(result);
                    if (byteLength < 0)
                    {
                        instance.Disconnect(); 
                        return;
                    }

                    byte[] data = new byte[byteLength];
                    Array.Copy(receiveBuffer, data, byteLength);

                    receivedData.Reset(HandleData(data));
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error receiving TCP Data: {ex}");
                    Disconnect();
                }
            }

            private void Disconnect()
            {
                instance.Disconnect();

                stream = null;
                receivedData = null;
                receiveBuffer = null;
                socket = null;
            }

            private bool HandleData(byte[] _data)
            {
                int _packetLength = 0;

                receivedData.SetBytes(_data);

                if (receivedData.UnreadLength() >= 4)
                {
                    _packetLength = receivedData.ReadInt();
                    if (_packetLength <= 0)
                    {
                        return true;
                    }
                }

                while (_packetLength > 0 && _packetLength <= receivedData.UnreadLength())
                {
                    byte[] _packetBytes = receivedData.ReadBytes(_packetLength);

                    using (Packet _packet = new Packet(_packetBytes))
                    {
                        int _packetId = _packet.ReadInt();
                        packetHandlers[_packetId](_packet);
                    }

                    _packetLength = 0;

                    if (receivedData.UnreadLength() >= 4)
                    {
                        _packetLength = receivedData.ReadInt();
                        if (_packetLength <= 0)
                        {
                            return true;
                        }
                    }
                }

                if (_packetLength <= 1)
                {
                    return true;
                }

                return false;
            }


        }
        private void InitializeClientData()
        {
            packetHandlers = new Dictionary<int, PacketHandler>()
        {
            {(int)ServerPackets.receivedInit, ClientHandle.ReceiveInit },
            {(int)ServerPackets.receivedLogin, ClientHandle.ReceiveLogin },
            {(int)ServerPackets.receivedDisconnect, ClientHandle.ReceiveDisconnect },
            {(int)ServerPackets.receivedMessage, ClientHandle.ReceiveMessage },
            {(int)ServerPackets.receivedPrivateMessage, ClientHandle.ReceivePrivateMessage },
            {(int)ServerPackets.ping, ClientHandle.Ping },
            {(int)ServerPackets.receivedAudioMessage, ClientHandle.ReceiveAudioMessage}
        };
            Console.WriteLine("Initialized packets.");
        }


        public void Disconnect()
        {
            if (isConnected)
            {
                isConnected = false;
                tcp.socket.Close();
                onDisconnect();
                Console.WriteLine("Disconnected from server.");
            }
        }
    }

}

