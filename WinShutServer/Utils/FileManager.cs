using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShutServer.Utils
{

    /// <summary>
    /// This class is used for reading and writing in a file.
    /// </summary>
    class FileManager
    {

        /// <summary>
        /// The full path of the file to be used
        /// </summary>
        string path = "";

        /// <summary>
        /// Gets the full path of the file being used by this FileManager.
        /// </summary>
        public string Path
        {
            get
            {
                return path;
            }
        }

        /// <summary>
        /// The lines read in the file.
        /// </summary>
        string[] lines = null;

        /// <summary>
        /// Gets all the lines read in the file.
        /// </summary>
        public string[] Lines
        {
            get
            {
                return lines;
            }
        }

        /// <summary>
        /// The current index for the buffer of the lines.
        /// </summary>
        int lineIndex = 0;

        /// <summary>
        /// The bytes that was read in the file.
        /// </summary>
        byte[] bytes = null;

        /// <summary>
        /// Gets all the bytes read from the file.
        /// </summary>
        public byte[] Bytes
        {
            get
            {
                return bytes;
            }
        }

        /// <summary>
        /// The current index where the buffer for reading bytes.
        /// </summary>
        int byteIndex = 0;

        /// <summary>
        /// Stores the last write time to be used when needing to load/reload the lines and bytes.
        /// </summary>
        DateTime lastWriteTime = DateTime.Now;

        /// <summary>
        /// Stores the last read time for lines to be used when needing to load/reload the lines.
        /// </summary>
        DateTime lastReadTimeLines = DateTime.Now;

        /// <summary>
        /// Stores the last read time for bytes to be used when needing to load/reload the bytes.
        /// </summary>
        DateTime lastReadTimeBytes = DateTime.Now;

        /// <summary>
        /// The buffer to which the writing of the file will go first before flushing.
        /// </summary>
        string buffer = "";

        /// <summary>
        /// Initialize the FileManager class.
        /// </summary>
        /// <param name="path">The full path where the file will be read/written.</param>
        /// <exception cref="ArgumentNullException">Thrown when <para>path</para> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when <para>path</para> is empty.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown when <para>path</para> cannot locate or create parent directory.</exception>
        /// <exception cref="FileNotFoundException">Thrown when<para>path</para> cannot be created or not found.</exception>
        public FileManager(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path", "path cannot be null");
            }
            if (path == "")
            {
                throw new ArgumentException("path cannot be empty", "path");
            }
            
            if(!File.Exists(path))
            {
                string dir = Directory.GetParent(path).ToString();
                Directory.CreateDirectory(dir);
                if(!Directory.Exists(dir))
                {
                    throw new DirectoryNotFoundException("Directory cannot be created.");
                }
                FileStream fs = File.Create(path);
                fs.Dispose();
            }
            this.path = path;
            ReloadAll();
            lastWriteTime = lastReadTimeLines.Ticks > lastReadTimeBytes.Ticks ? lastReadTimeLines : lastReadTimeBytes;
        }
        

        /// <summary>
        /// Loads both lines and bytes buffer.
        /// </summary>
        public void LoadAll()
        {
            LoadBytes();
            LoadLines();
        }

        /// <summary>
        /// Loads both lines and bytes buffer then reset their index.
        /// </summary>
        public void ReloadAll()
        {
            ReloadLines();
            ReloadBytes();
        }

        /// <summary>
        /// Loads lines buffer.
        /// </summary>
        public void LoadLines()
        {
            lines = File.ReadAllLines(path);
            lastReadTimeLines = DateTime.Now;
        }

        /// <summary>
        /// Loads bytes buffer.
        /// </summary>
        public void LoadBytes()
        {
            bytes = File.ReadAllBytes(path);
            lastReadTimeBytes = DateTime.Now;
        }

        /// <summary>
        /// Loads lines buffer then reset its index.
        /// </summary>
        public void ReloadLines()
        {
            LoadLines();
            lineIndex = 0;
        }

        /// <summary>
        /// Loads bytes buffer then reset its index.
        /// </summary>
        public void ReloadBytes()
        {
            LoadBytes();
            byteIndex = 0;
        }

        /// <summary>
        /// Reads a byte from the byte buffer then increment the byte buffer index. Return -1 if reaches the end of byte buffer.
        /// </summary>
        /// <returns>The byte read from the current byte buffer index. Returns -1 if end of the buffer.</returns>
        public int ReadByte()
        {
            if(byteIndex >= bytes.Length)
            {
                return -1;
            }
            return bytes[byteIndex++];
        }

        /// <summary>
        /// Check if the file is updated, then reloads the byte buffer if it is updated. 
        /// Return -1 if reaches the end of the byte buffer. 
        /// Does not affect line buffer.
        /// </summary>
        /// <param name="reset">Reset the byte buffer index.</param>
        /// <returns>if reset is true, returns the first byte read, if false, returns the current byte read from the current buffer index.</returns>
        public int ReadByte(bool reset)
        {
            if(lastWriteTime.Ticks > lastReadTimeBytes.Ticks)
            {
                if(reset)
                {
                    ReloadBytes();
                }
                else
                {
                    LoadBytes();
                }
            }
            return ReadByte();
        }

        /// <summary>
        /// Read a specific byte in the byte buffer using the specified index. Does not set the current byte buffer index.
        /// </summary>
        /// <param name="index">The index of the byte to be read.</param>
        /// <returns>Byte read from the byte buffer with the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">throw when index is not in the buffer.</exception>
        public int ReadByte(int index)
        {
            if(index < 0 || index >= bytes.Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return bytes[index];
        }

        /// <summary>
        /// Reloads the line buffer then read the specific line using the specified index. Does not set the current byte buffer index.
        /// </summary>
        /// <param name="index">The index of the byte to be read.</param>
        /// <param name="reset">Reset the byte buffer index.</param>
        /// <returns>The byte read from the byte buffer with the specified index</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when index is not in the buffer.</exception>
        public int ReadByte(int index, bool reset)
        {
            if (lastWriteTime.Ticks > lastReadTimeBytes.Ticks)
            {
                if(reset)
                {
                    ReloadBytes();
                }
                else
                {
                    LoadBytes();
                }
            }
            return ReadByte(index);
        }

        /// <summary>
        /// Read a line in the buffer and then increment the line buffer index.
        /// </summary>
        /// <returns>Line read from the line buffer or <c>null</c> when the index reaches the end of the buffer.</returns>
        public string ReadLine()
        {
            if(lineIndex >= lines.Length)
            {
                return null;
            }
            return lines[lineIndex++];
        }

        /// <summary>
        /// Check if the file is updated, then reloads the line buffer if it is updated. 
        /// Return <c>null</c> if reaches the end of the buffer. 
        /// Does not affect byte buffer.
        /// </summary>
        /// <param name="reset">Reset the line buffer index.</param>
        /// <returns>if reset is true, returns the first byte read, if false, returns the current byte read from the current buffer index.</returns>
        public string ReadLine(bool reset)
        {
            if (lastWriteTime.Ticks > lastReadTimeLines.Ticks)
            {
                if(reset)
                {
                    ReloadLines();
                }
                else
                {
                    LoadLines();
                }
            }
            return ReadLine();
        }

        /// <summary>
        /// Read a specific line in the lines buffer using the specified index. Does not set the current line buffer index.
        /// </summary>
        /// <param name="index">The index of the line to be read.</param>
        /// <returns>Line read from the line buffer with the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when index is not in the buffer.</exception>
        public string ReadLine(int index)
        {
            if (index < 0 || index >= lines.Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return lines[index];
        }

        /// <summary>
        /// Reloads the line buffer then read the specific line using the specified index. Does not set the current line buffer index.
        /// </summary>
        /// <param name="index">The index of the line to be read.</param>
        /// <param name="reset">Reset the line buffer index.</param>
        /// <returns>The line read from the line buffer with the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Throw when index is not in the buffer.</exception>
        public int ReadLine(int index, bool reset)
        {
            if (lastWriteTime.Ticks > lastReadTimeLines.Ticks)
            {
                if(reset)
                {
                    ReloadLines();
                }
                else
                {
                    LoadLines();
                }
            }
            return ReadByte(index);
        }

        /// <summary>
        /// Adds the string to the write buffer.
        /// </summary>
        /// <param name="str"><c>String</c> to be added.</param>
        public void Print(string str)
        {
            if(str == null)
            {
                throw new ArgumentNullException("str");
            }
            buffer += str;
        }

        /// <summary>
        /// Adds array of string to the write buffer.
        /// </summary>
        /// <param name="str">Array of <c>String</c> to be added.</param>
        public void Print(string[] str)
        {
            foreach(String s in str)
            {
                Print(str);
            }
        }

        /// <summary>
        /// Adds the string and a new line to the write buffer.
        /// </summary>
        /// <param name="str"><c>String to be added.</c></param>
        public void PrintLine(string str)
        {
            Print(str + Environment.NewLine);
        }

        /// <summary>
        /// Adds the array of string and a new line to each string to the write buffer.
        /// </summary>
        /// <param name="str">Array of <c>String</c> to be added.</param>
        public void PrintLine(string[] str)
        {
            foreach(String s in str)
            {
                Print(s + Environment.NewLine);
            }
        }

        
        /// <summary>
        /// Overwrites the current content of the file with the contents of the write buffer.
        /// If successful, reset the write buffer.
        /// </summary>
        /// <returns>True if successful.</returns>
        public bool Flush()
        {
            try
            {
                File.WriteAllText(path, buffer);
                buffer = "";
                return true;
            } catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Adds the current content of the buffer to the current content of the file.
        /// If successful, reset the write buffer.
        /// </summary>
        /// <returns>True if successful.</returns>
        public bool Append()
        {
            try
            {
                File.AppendAllText(path, buffer);
                buffer = "";
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Clears the write buffer.
        /// </summary>
        public void ClearBuffer()
        {
            buffer = "";
        }

    }
}
