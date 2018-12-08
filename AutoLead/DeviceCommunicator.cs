using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoLead
{
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public class DeviceCommunicator
    {
        IDeviceConnectDelegate mCallback;
        Socket _clientSocket;

        public bool isConnect()
        {
            if (_clientSocket != null)
            {
                return _clientSocket.Connected;
            }
            else
                return false;
        }

        public void connect(string deviceIp, IDeviceConnectDelegate connDelegate)
        {
            this.mCallback = connDelegate;

            _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse(deviceIp);
            _clientSocket.BeginConnect(new IPEndPoint(address, 2048), new AsyncCallback(this.ConnectCallback), _clientSocket);
        }

        public void disconnect()
        {
            if(_clientSocket != null)
            {
                try
                {
                    _clientSocket.Disconnect(false);
                    _clientSocket = null;
                }
                catch(SocketException ex)
                {

                }
            }
            onDisconnect("");
        }

        public void ConnectCallback(IAsyncResult AR)
        {
            try
            {
                Socket client = (Socket)AR.AsyncState;
                client.EndConnect(AR);
                Console.WriteLine("Socket connected to {0}",
                client.RemoteEndPoint.ToString());

                Receive(client);
                mCallback.onConnectSuccess();
            }
            catch(SocketException ex)
            {
                Console.WriteLine(ex.ToString());
                mCallback.onConnectFailed(ex.ToString());
            }
        }

        private void Receive(Socket client)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                disconnect();
            }
        }

        public void sendData(byte[] byteData)
        {
            mCallback.onSendCommand(Encoding.Unicode.GetString(byteData));
            try {
                // Begin sending the data to the remote device.  
                _clientSocket.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), _clientSocket);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                disconnect();
            }         
        }



        public void SendCallback(IAsyncResult AR)
        {
            try
            {
                Socket client = (Socket)AR.AsyncState;
                if(client != _clientSocket)
                {
                    client.Disconnect(false);
                    return;
                }

                client.EndSend(AR);
            }
            catch(SocketException ex)
            {
                Console.WriteLine(ex.ToString());
                disconnect();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ReceiveCallback(IAsyncResult AR)
        {
            try
            { 
                StateObject state = (StateObject)AR.AsyncState;
                Socket client = state.workSocket;
                if(client != _clientSocket)
                {
                    client.Disconnect(false);
                    return;
                }

                int bytesRead = client.EndReceive(AR);
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.Unicode.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);

                    string temp = state.sb.ToString();
                    if (temp.EndsWith("{[|]}"))
                    {
                        string[] commands = temp.Split(new string[] {"{[|]}"}, StringSplitOptions.None);
                        for(int i=0; i< commands.Length; i++)
                        {
                            if (commands[i] != "")
                            {
                                mCallback.onReceivedCommand(commands[i]);
                            }
                        }

                        state.sb.Clear();
                    }
                }
            }
            catch(SocketException ex)
            {
                Console.WriteLine(ex.ToString());
                disconnect();
            }
        }

        public void onDisconnect(string reason)
        {
            if(mCallback != null)
                mCallback.onConnectFailed(reason);
        }
    }
}
