using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShutServer.Utils
{
    
    /// <summary>
    /// Event listener for any error occurence.
    /// </summary>
    /// <param name="message">The error message.</param>
    internal delegate void OnErrorEventListener(string message);
    

    /// <summary>
    /// Event Listener for starting any connection.
    /// </summary>
    /// <param name="args">Object containing the event data.</param>
    internal delegate void OnConnectionStartEventListener(ConnectionEventArgs args);

    /// <summary>
    /// Event Listener for any connected events.
    /// </summary>
    /// <param name="args">Object containing the event data.</param>
    internal delegate void OnConnectedEventListener(ConnectionEventArgs args);

    /// <summary>
    /// Event Listener for any disconnected events.
    /// </summary>
    /// <param name="args">Object containing the event data.</param>
    internal delegate void OnDisconnectEventListener(ConnectionEventArgs args);

    /// <summary>
    /// Event Listener for stopping any connection.
    /// </summary>
    /// <param name="args">Object containing the event data.</param>
    internal delegate void OnConnectionStopEventListener(ConnectionEventArgs args);

    /// <summary>
    /// Event Listener for sending data through connection.
    /// </summary>
    /// <param name="args">Object containing the event data.</param>
    internal delegate void OnDataSentEventListener(DataEventArgs args);

    /// <summary>
    /// Event Listener for receiving data through connection.
    /// </summary>
    /// <param name="args">Object containing the event data.</param>
    internal delegate void OnDataReceivedEventListener(DataEventArgs args); 
    
    /// <summary>
    /// Generates the data needed on connection events.
    /// </summary>
    class ConnectionEventArgs : EventArgs
    {

        /// <summary>
        /// The local endpoint information of the event.
        /// </summary>
        private System.Net.EndPoint localEndPoint;

        /// <summary>
        /// Gets the local endpoint information of the event.
        /// </summary>
        internal System.Net.EndPoint LocalEndPoint
        {
            get
            {
                return localEndPoint;
            }
        }

        /// <summary>
        /// The remote endpoint information of the event.
        /// </summary>
        private System.Net.EndPoint remoteEndPoint;

        /// <summary>
        /// Gets the remote endpoint information of the event.
        /// </summary>
        internal System.Net.EndPoint RemoteEndPoint
        {
            get
            {
                return localEndPoint;
            }
        }


        /// <summary>
        /// Gets the local IP Endpoint information of the event.
        /// </summary>
        internal System.Net.IPEndPoint LocalIPEndPoint
        {
            get
            {
                return (localEndPoint as System.Net.IPEndPoint);
            }
        }

        /// <summary>
        /// Gets the remote IP Endpoint Information fo the event.
        /// </summary>
        internal System.Net.IPEndPoint RemoteIPEndPoint
        {
            get
            {
                return (remoteEndPoint as System.Net.IPEndPoint);
            }
        }

        /// <summary>
        /// Gets the local hostname of the event.
        /// </summary>
        internal string LocalHostname
        {
            get
            {
                return System.Net.Dns.GetHostEntry(LocalIPEndPoint.Address)?.HostName;
            }
        }

        /// <summary>
        /// Gets the remote hostname of the event.
        /// </summary>
        internal string RemoteHostname
        {
            get
            {
                try
                {
                    return System.Net.Dns.GetHostEntry(RemoteIPEndPoint.Address)?.HostName;
                }
                catch(System.Net.Sockets.SocketException)
                {
                    return RemoteIPEndPoint.Address.ToString();
                }
            }
        }

        /// <summary>
        /// Creates an instance with the specified local and remote endpoint.
        /// </summary>
        /// <param name="local">The local endpoint information about the connection.</param>
        /// <param name="remote">The remote endpoint informaion about the connection.</param>
        internal ConnectionEventArgs(
            System.Net.EndPoint local = null,      //the local endpoint information of the connection
            System.Net.EndPoint remote = null     //the remote endpoint information of the connection
            )
        {
            localEndPoint = local;
            remoteEndPoint = remote;
        }
        
    }

    /// <summary>
    /// Generates the data needed on any data received event.
    /// </summary>
    internal class DataEventArgs : EventArgs {

        /// <summary>
        /// The data received/sent from/to the sender/receiver.
        /// </summary>
        private Data receivedData;

        /// <summary>
        /// Gets the data received from the sender/receiver.
        /// </summary>
        internal Data Data
        {
            get
            {
                return receivedData;
            }
        }

        /// <summary>
        /// The endpoint information of the sender/receiver.
        /// </summary>
        private System.Net.IPEndPoint senderEndPoint;

        /// <summary>
        /// Gets the IP endpoint information of the sender/receiver.
        /// </summary>
        internal System.Net.IPEndPoint IPEndpoint
        {
            get
            {
                return senderEndPoint;
            }
        }

        /// <summary>
        /// Gets the IP Address of the sender/receiver.
        /// </summary>
        internal System.Net.IPAddress IpAddress
        {
            get
            {
                return IPEndpoint.Address;
            }
        }

        /// <summary>
        /// Gets the hostname of the sender/receiver.
        /// </summary>
        internal string Hostname
        {
            get
            {
                return (System.Net.Dns.GetHostEntry(IpAddress))?.HostName;
            }
        }

        /// <summary>
        /// Creates an instance with specified IP endpoint information of the sender/receiver
        /// and the data being received/sent.
        /// </summary>
        /// <param name="sender">The information of the sender.</param>
        /// <param name="received">The data that is received.</param>
        internal DataEventArgs(System.Net.IPEndPoint senderOrReceiver, Data receivedOrSent)
        {
            receivedData = receivedOrSent;
            senderEndPoint = senderOrReceiver;
        }


    }

    internal static class Globals
    {
        private static string ipAddress;

        internal static string IpAddress
        {
            get
            {
                return ipAddress;
            }
            set
            {
                ipAddress = value;
            }
        }

        private static string hostname;

        internal static string Hostname
        {
            get
            {
                return hostname;
            }
            set
            {
                hostname = value;
            }
        }

        public static long Hours(long millis)
        {
            return millis / 3600000;
        }

        public static long Minutes(long millis)
        {
            return (millis % 3600000) / 60000;
        }

        public static long Seconds(long millis)
        {
            return ((millis % 3600000) % 60000) / 1000;
        }



    }



}
