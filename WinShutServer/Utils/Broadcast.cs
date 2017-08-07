using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WinShutServer.Utils
{
    static class Broadcast
    {

        internal static OnConnectionStartEventListener OnStart;
        internal static OnConnectionStopEventListener OnStop;
        internal static OnErrorEventListener OnError;

        private static Socket server;

        private static Timer timer;

        private static double updateInterval = 1000.0;

        internal static double UpdateInterval
        {
            get
            {
                return updateInterval;
            }
            set
            {
                if(value > 250)
                {
                    updateInterval = value;
                }
                else
                {
                    updateInterval = 1000;
                }
                if(timer != null)
                {
                    timer.Interval = updateInterval;
                }
            }
        }

        private static int port = 12206;

        internal static int Port
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

        private static byte[] data = null;
        private static EndPoint receiver = null;

        internal static bool Running
        {
            get
            {
                return timer != null ? timer.Enabled : false;
            }
        }

        internal static void Start()
        {
            try
            {
                if(receiver == null)
                {
                    receiver = new IPEndPoint(IPAddress.Broadcast, port);
                }
                if (server == null)
                {
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    server.Connect(receiver);
                    if(Globals.IpAddress == null)
                    {
                        Globals.IpAddress 
                            = (server.LocalEndPoint as IPEndPoint).Address.ToString();
                        Globals.Hostname = Dns.GetHostEntry(Globals.IpAddress).HostName;
                    }
                }
                if (data == null)
                {
                    data = Encoding.ASCII.GetBytes(new Data("hostname", Globals.Hostname).GetData());
                }
                if (timer == null)
                {
                    timer = new Timer(updateInterval);
                    timer.AutoReset = true;
                    timer.Elapsed += Timer_Elapsed;
                }
                timer.Start();
                Log.Write("Broadcast has been started.");
                OnStart?.Invoke(new ConnectionEventArgs(server.LocalEndPoint, null));
            }
            catch(SocketException)
            {
                OnError?.Invoke("Cannot create broadcast server.");
            }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(server != null)
            {
                server.Send(data, data.Length, SocketFlags.None);
            }
        }


        internal static void Stop(bool silent = false)
        {
            if (timer != null)
            {
                timer.Stop();
            }
            if(!silent)
            {
                Log.Write("Broadcast has been stopped.");
            }
            OnStop?.Invoke(new ConnectionEventArgs(server?.LocalEndPoint, null));
        }

        internal static void Dispose()
        {
            Stop(true);
            if(server != null)
            {
                server.Dispose();
            }
        }
    }
}
