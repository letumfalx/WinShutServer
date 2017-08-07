using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WinShutServer.Utils
{
    class DataStream
    {
        /// <summary>
        /// The one that sends data.
        /// </summary>
        private TcpClient client = null;

        public TcpClient Client
        {
            get
            {
                return client;
            }
        }

        /// <summary>
        /// The stream between the client and the server.
        /// </summary>
        private NetworkStream stream = null;

        /// <summary>
        /// Initialize the class using a server and the connected client.
        /// </summary>
        /// <param name="server">The server that will receive/send the data.</param>
        /// <param name="client">The client that will receive/send the data.</param>
        /// <exception cref="System.IO.IOException">Throws when the initial handshake failed.</exception>
        /// <exception cref="SocketException">Throws when blocking accept is stopped.</exception>
        public DataStream(TcpListener server)
        {
            try
            {
                client = server.AcceptTcpClient();
            }
            catch(SocketException)
            {
                return;
            }
            stream = client.GetStream();

            Write(new Data("connect", "connect"));

            int startTime = Environment.TickCount;

            while (Environment.TickCount - startTime < 2000)
            {
                if (Read() != null) return;
            }
            throw new System.IO.IOException();
        }
        

        /// <summary>
        /// Closes all the network objects of this class.
        /// </summary>
        public void Close()
        {
            this.stream?.Close();
            this.client?.Close();
        }

        /// <summary>
        /// Reads the incoming data from the client.
        /// </summary>
        /// <returns>Data that has been read.</returns>
        public Data Read()
        {
            String s = "";
            for (int i = this.stream.ReadByte(); i > -1 && i != 10; i = this.stream.ReadByte())
            {
                s += (char)i;
            }
            try
            {
                return new Data(s);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        /// <summary>
        /// Sends the data to the client connected.
        /// </summary>
        /// <param name="d">Data to be sent.</param>
        /// <returns>True if sending data is a success.</returns>
        public bool Write(Data d)
        {
            try
            {
                byte[] sent = Encoding.ASCII.GetBytes(d.GetData() + (char)10);
                this.stream.Write(sent, 0, sent.Length);
                this.stream.Flush();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
    }
}
