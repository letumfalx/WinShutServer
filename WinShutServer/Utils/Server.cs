using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinShutServer.Utils
{
    static class Server
    {

        internal static OnConnectionStartEventListener Connecting;
        internal static OnConnectedEventListener Connected;
        internal static OnDisconnectEventListener Disconnect;
        internal static OnErrorEventListener Error;
        internal static OnDataReceivedEventListener DataReceived;
        internal static OnConnectionStopEventListener OnStop;

        private static TcpListener server = null;

        private static DataStream stream = null;

        private static int port = 12207;
        public static int Port
        {
            get
            {
                return port;
            }
            set
            {
                if(value > 0 && value < UInt16.MaxValue - 1)
                {
                    port = value;
                }
            }
        }

        private static double updateInterval = 1000;

        public static double UpdateInterval
        {
            get
            {
                return updateInterval;
            }
            set
            {
                if (value > 250)
                {
                    updateInterval = value;
                }
                else
                {
                    updateInterval = 1000;
                }
                if(updater != null)
                {
                    updater.Interval = updateInterval;
                }
            }
        }

        private static System.Timers.Timer updater;
        private static Thread receiver;

        internal static bool IsRunning
        {
            get
            {
                return receiver != null ? receiver.IsAlive : false;
            }
        }

        internal static bool IsConnected
        {
            get
            {
                return (stream != null) ? stream.Client != null : false;
            }
        }

        private static EndPoint clientEndpoint = null;
        
        internal static EndPoint ClientEndpoint
        {
            get
            {
                return clientEndpoint;
            }
        }

        internal static bool Disconnection
        {
            get;
            set;
        }

        internal static bool RestartBroadcast
        {
            get;
            set;
        }

        private static Data updateData = new Data("update", Environment.TickCount.ToString());

        private static void Init()
        {
            if(server == null)
            {
                if(Globals.IpAddress == null)
                {
                    using (Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                    {
                        sock.Connect(IPAddress.Broadcast, UInt16.MaxValue - 2);
                        Globals.IpAddress
                            = (sock.LocalEndPoint as IPEndPoint).Address.ToString();
                        Globals.Hostname = Dns.GetHostEntry(Globals.IpAddress).HostName;
                    }
                }
                server = new TcpListener(new IPEndPoint(IPAddress.Parse(Globals.IpAddress), 12207));
                updater = new System.Timers.Timer(updateInterval);
                updater.AutoReset = true;
                updater.Elapsed += Updater_Elapsed;
            }
        }

        private static void Updater_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(stream != null)
            {
                Data updateData = new Data("sequence", ((int)(Sequence.CurrentSequence)).ToString())
                    .Add(((int)(Sequence.CurrentType)).ToString())
                    .Add(Globals.Hours(Sequence.TimeRemaining).ToString())
                    .Add(Globals.Minutes(Sequence.TimeRemaining).ToString())
                    .Add(Globals.Seconds(Sequence.TimeRemaining).ToString());
                stream.Write(updateData);
            }
        }

        public static void Start()
        {
            Stop(true);
            try
            {
                Init();
                receiver = new Thread(() => 
                {
                    try
                    {
                        RestartBroadcast = false;
                        server.Start(1);
                        OnConnecting(new ConnectionEventArgs(server.LocalEndpoint, null));
                        
                        stream = new DataStream(server);

                        RestartBroadcast = Broadcast.Running;

                        OnConnected(new ConnectionEventArgs(server?.LocalEndpoint, stream?.Client.Client.RemoteEndPoint));
                        updater.Start();
                        for (;;)
                        {
                            if(Disconnection)
                            {
                                throw new System.IO.IOException();
                            }
                            Data d = stream.Read();
                            if(d != null)
                            {
                                OnDataReceive(new DataEventArgs(stream.Client.Client.RemoteEndPoint as IPEndPoint, d));
                            }
                        }
                    }
                    catch (System.IO.IOException)
                    {
                        new Thread(() =>
                        {
                            OnDisconnect(new ConnectionEventArgs(server.LocalEndpoint, stream?.Client?.Client?.RemoteEndPoint));
                        }).Start();
                    }
                    catch (ThreadAbortException)
                    {
                        return;
                    }
                    
                });
                receiver.Start();
            }
            catch(SocketException)
            {
                OnError("Unable to create control server.");
            }
        }

        internal static void Stop(bool silent = false)
        {
            if (updater != null ? updater.Enabled : false) updater.Stop();

            if (server != null)
            {
                if (server.Server.Connected) server.Server.Disconnect(true);
                server.Stop();
            }
            
            if (receiver != null ? receiver.IsAlive : false) receiver.Abort();

            if (stream != null)
            {
                stream.Close();
                stream = null;
            }
            
            if(!silent)
            {
                Log.Write("Server has been stopped.");
            }
            OnConnectionStop();
        }

        public static void Dispose()
        {
            Stop();
            if(server != null)
            {
                server.Stop();
            }
        }

        public static void Send(Data dt)
        {
            if(stream != null)
            {
                stream.Write(dt);
            }
        }

        public static void Send(string key, string value)
        {
            Send(new Data(key, value));
        }

        private static void OnConnecting(ConnectionEventArgs arg)
        {
            Log.Write("Control Server has started successfully!");
            Connecting?.Invoke(arg);
        }

        private static void OnConnected(ConnectionEventArgs arg)
        {
            Log.Write("Control Server has successfully connected to " 
                + arg.RemoteIPEndPoint.Address.ToString() + "/"
                + arg.RemoteHostname + ".");
            Connected?.Invoke(arg);
            clientEndpoint = arg.RemoteEndPoint;
        }

        private static void OnDisconnect(ConnectionEventArgs arg)
        {
            Log.Write("Control Server has been disconnected to "
                + arg.RemoteIPEndPoint.Address.ToString() + "/"
                + arg.RemoteHostname + ".");
            Disconnect?.Invoke(arg);
            clientEndpoint = null;
            if (Config.Equals("restart", "1"))
            {
                Start();
                switch (Config.Get("rebroadcast"))
                {
                    case "0":
                        Broadcast.Start();
                        break;
                    case "1":
                        if(RestartBroadcast)
                        {
                            Broadcast.Start();
                        }
                        break;
                    default:
                        Broadcast.Stop();
                        break;
                }
            }
            else
            {
                Broadcast.Stop();
                Stop();
            }
        }

        private static void OnError(string message)
        {
            Log.Write(message);
            Error?.Invoke(message);
            clientEndpoint = null;
        }

        private static void OnDataReceive(DataEventArgs arg)
        {
            DataReceived?.Invoke(arg);
        }

        private static void OnConnectionStop()
        {
            OnStop?.Invoke(new ConnectionEventArgs(server?.LocalEndpoint, null));
            clientEndpoint = null;
        }

    }
}
