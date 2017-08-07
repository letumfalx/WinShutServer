using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShutServer.Utils
{

    /// <summary>
    /// This class will be used for data processing from the network.
    /// </summary>
    public class Data
    {

        /// <summary>
        /// The string or series of bytes that will be appended to the front of the data.
        /// </summary>
        static string header = ASCIIEncoding.ASCII.GetString(new byte[] {0, 6, 1, 8, 1, 9, 9, 6});

        /// <summary>
        /// Gets the current header of the <c>Data</c> class in <c>String</c>.
        /// </summary>
        public static string Header
        {
            get
            {
                return header;
            }
        }


        /// <summary>
        /// Sets the header of the <c>Data</c> class.
        /// </summary>
        /// <param name="header">The <c>String</c> that will be the header.</param>
        public static void SetHeader(string header)
        {
            if(header == null)
            {
                throw new ArgumentNullException("header");
            }
            if(header.Length > 64)
            {
                throw new ArgumentException("header is too long", "header");
            }
            Data.header = header;
        }

        /// <summary>
        /// Sets the header of the <c>Data</c> class using array of <c>byte</c>.
        /// </summary>
        /// <param name="header">The array of <c>byte</c> that will be converted to string to become the header.</param>
        public static void SetHeader(byte[] header)
        {
            SetHeader(ASCIIEncoding.ASCII.GetString(header));
        }

        /// <summary>
        /// Sets the header of the <c>Data</c> class using array of <c>int</c>.
        /// </summary>
        /// <param name="header">The array of <c>int</c> that will be converted to string to become the header.</param>
        public static void SetHeader(int[] header)
        {
            byte[] h = new byte[header.Length];
            for(int i=0; i<header.Length; i++)
            {
                h[i] = (byte)header[i];
            }
            SetHeader(ASCIIEncoding.ASCII.GetString(h));
        }

        /// <summary>
        /// The identifier of the data.
        /// </summary>
        string key;

        /// <summary>
        /// Gets the identifier of the data.
        /// </summary>
        public string Key
        {
            get
            {
                return key;
            }
        }

        /// <summary>
        /// The values of the data.
        /// </summary>
        List<string> values;

        /// <summary>
        /// Gets the list of the values of the data.
        /// </summary>
        public List<string> Values
        {
            get
            {
                return values;
            }
        }

        /// <summary>
        /// Initialize the Data class with its key and collection of values.
        /// </summary>
        /// <param name="key">The identifier of the data.</param>
        /// <param name="value">The collection of string that will added to the values of the data.</param>
        public Data(string key, IEnumerable<string> values)
        {
            this.key = key;
            this.values = new List<string>(values);
        }

        /// <summary>
        /// Initialize the Data class with its key and a value.
        /// </summary>
        /// <param name="key">The identifier of the data.</param>
        /// <param name="value">A value to be added to the values of the data.</param>
        public Data(string key, string value) : this(key, new string[] { value })
        {

        }

        /// <summary>
        /// Initialize the Data class through parsing a string to get the key and values.
        /// </summary>
        /// <param name="data">The <c>String</c> that will parsed.</param>
        /// <exception cref="ArgumentException">Throws when the received data 
        /// has wrong header or insufficient number of key/values</exception>
        public Data(string data)
        {
            if (!data.StartsWith(header))
            {
                throw new ArgumentException("wrong header");
            }
            data = data.Substring(data.IndexOf(header) + header.Length);

            int count = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data.ElementAt(i) == '\0')
                {
                    count++;
                }
            }
            if (count < 2)
            {
                throw new ArgumentException("no key/value found");
            }
            this.key = data.Substring(0, data.IndexOf("\0"));
            data = data.Substring(data.IndexOf(("\0")));
            this.values = new List<string>();
            this.values.Clear();
            while (data.IndexOf('\0') > -1)
            {
                values.Add(data.Substring(0, data.IndexOf("\0")));
                data = data.Substring(data.IndexOf("\0") + 1);
            }

            while (this.values[0] == null || this.values[0] == "")
            {
                if (this.values.Count > 1) this.values.RemoveAt(0);
            }
        }

        /// <summary>
        /// Initialize the Data class through parsing an array of byte to get its key and values.
        /// </summary>
        /// <param name="received">The array of byte that will be parsed.</param>
        public Data(byte[] received) : this(ASCIIEncoding.ASCII.GetString(received))
        {

        }

        /// <summary>
        /// Initialize the Data class through parsing an array of byte to get its key and values.
        /// Parsing starts at a specified offset with a specified count to be parsed.
        /// </summary>
        /// <param name="received">The array of byte to be parsed.</param>
        /// <param name="offset">The first index of the byte to be parsed.</param>
        /// <param name="count">The count of byte to be parsed.</param>
        public Data(byte[] received, int offset, int count) : this(new List<byte>(received).GetRange(offset, count).ToArray())
        {

        }

        /// <summary>
        /// Initialize the Data class through parsing an array of byte to get its key and values.
        /// Parsing starts at zero with a specified count to be parsed.
        /// </summary>
        /// <param name="received">The array of byte to be parsed.</param>
        /// <param name="count">The count of byte to be parsed.</param>
        public Data(byte[] received, int count) : this(received, 0, count)
        {

        }

        /// <summary>
        /// Adds a value to the list of values.
        /// </summary>
        /// <param name="value">The value to be added.</param>
        public Data Add(string value)
        {
            this.values.Add(value);
            return this;
        }

        /// <summary>
        /// Adds a array of values to the list of values.
        /// </summary>
        /// <param name="values">The array to be added.</param>
        public Data Add(IEnumerable<string> values)
        {
            this.values.AddRange(values);
            return this;
        }

        /// <summary>
        /// Adds multiple values to the list of values.
        /// </summary>
        /// <param name="values">The multiple values to be added.</param>
        public Data Add(params string[] values)
        {
            this.values.AddRange(values);
            return this;
        }

        /// <summary>
        /// Gets the first value of the list of values.
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            return this.values[0];
        }

        /// <summary>
        /// Gets a specific value with the specified index.
        /// </summary>
        /// <param name="index">The requested index to be returned.</param>
        /// <returns>The string with the specified index.</returns>
        /// <exception cref="IndexOutOfRangeException">Index requested is outside of the range of the array.</exception>
        public string Get(int index)
        {
            if (index < 0 || index >= this.values.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return this.values[index];
        }

        /// <summary>
        /// Gets a range of values from the list of values.
        /// </summary>
        /// <param name="offset">Start position of the range.</param>
        /// <param name="size">Size of the return array.</param>
        /// <returns>The array of the values requested.</returns>
        /// <exception cref="IndexOutOfRangeException">Offset or size is too big for the list.</exception>
        public IEnumerable<string> Get(int offset, int size)
        {
            if(offset < 0 || offset >= this.values.Count)
            {
                throw new IndexOutOfRangeException("invalid offset");
            }
            if(offset + size > this.values.Count)
            {
                throw new IndexOutOfRangeException("size too large");
            }
            return this.values.GetRange(offset, size).ToArray();
        }

        /// <summary>
        /// Gets the string of the data that will be used to send data through the connections.
        /// </summary>
        /// <returns>The string to be sent through the connections.</returns>
        public string GetData()
        {

            string tmp = "";
            tmp += header + key + (char)(0);
            foreach (string s in this.values)
            {
                tmp += s + (char)(0);
            }
            return tmp;
        }

        /// <summary>
        /// Gets the byte sequence equivalent of <c>GetData</c>.
        /// </summary>
        /// <returns>The bytes to be sent through the connections.</returns>
        public byte[] GetBytes()
        {
            return ASCIIEncoding.ASCII.GetBytes(this.GetData());
        }

        /// <summary>
        /// Checks this data is the same with the other data.
        /// </summary>
        /// <param name="d2">The other data to be compared with.</param>
        /// <returns>True if data are the same.</returns>
        public bool compare(Data d2)
        {
            return this.GetData() == d2.GetData();
        }

        /// <summary>
        /// Checks the data d1 if it is the same with data d2.
        /// </summary>
        /// <param name="d1">The first data to be compared.</param>
        /// <param name="d2">The other data to be compared.</param>
        /// <returns></returns>
        public static bool compare(Data d1, Data d2)
        {
            return d1.GetData() == d2.GetData();
        }
    }
}
