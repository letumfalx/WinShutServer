using System;
using System.IO;
using System.Linq;
using System.Text;

namespace WinShutServer.Utils
{
    /// <summary>
    /// This class is use for logging events.
    /// </summary>
    static class Log
    {
        /// <summary>
        /// Constant used in writing the logs to the console.
        /// </summary>
        public const int CONSOLE = 1;

        /// <summary>
        /// Constant used in writing the logs to a file.
        /// </summary>
        public const int FILE = 2;

        /// <summary>
        /// Constant used in writing the logs to a stream.
        /// </summary>
        public const int STREAM = 4;

        /// <summary>
        /// Constant used in writing files to a Form Control.
        /// </summary>
        public const int LOGBOX = 8;

        /// <summary>
        /// Stores the File to where the log will be written.
        /// </summary>
        private static FileManager logFile = null;

        /// <summary>
        /// Sets the file where the logs will be written.
        /// </summary>
        /// <param name="path">Full path of the log file.</param>
        public static void SetFile(String path)
        {
            logFile = new FileManager(path);
        }

        /// <summary>
        /// Sets teh file where the logs will be written.
        /// </summary>
        /// <param name="file">FileManager of the log file.</param>
        public static void SetFile(FileManager file)
        {
            logFile = file;
        }

        
        /// <summary>
        /// Stores the Windows Form RichTextBox where the log will be written.
        /// </summary>
        private static System.Windows.Forms.RichTextBox logBox = null;
        
        /// <summary>
        /// Sets the Windows Form RichTextBox where the log will be written.
        /// </summary>
        /// <param name="lb">The control where the log will be written.</param>
        public static void SetLogBox(System.Windows.Forms.RichTextBox lb)
        {
            logBox = lb;
        }

        /// <summary>
        /// Stores the stream where the log will be written.
        /// </summary>
        private static Stream stream = null;

        /// <summary>
        /// Sets the stream where the log will be written.
        /// </summary>
        /// <param name="strm">The stream of the log.</param>
        public static void SetStream(Stream strm)
        {
            stream = strm;
        }

        /// <summary>
        /// Writes the log to all available loggers.
        /// </summary>
        /// <param name="log">The string of the log.</param>
        public static void Write(String log)
        {
            Write(log, 0xFFFF);
        }

        /// <summary>
        /// Writes the log to the specified loggers, use arithmetic add (+) for multiple loggers.
        /// </summary>
        /// <param name="log">The string of the log.</param>
        /// <param name="where">The loggers.</param>
        /// <example>Write("Log here", CONSOLE + LOGBOX); for writing in console and logbox only.</example>
        public static void Write(String log, int where)
        {
            log = Format(log);
            if ((where & CONSOLE) == CONSOLE)
            {
                Console.Write(log);
            }

            if ((where & FILE) == FILE && logFile != null)
            {
                logFile.Print(log);
                logFile.Append();
            }

            if ((where & STREAM) == STREAM && stream != null && stream.CanWrite)
            {
                byte[] send = ASCIIEncoding.ASCII.GetBytes(log);
                stream.Write(send, 0, send.Length);
            }

            if ((where & LOGBOX) == LOGBOX && logBox != null)
            {
                try
                {
                    if (!logBox.IsDisposed)
                    {
                        if (logBox.InvokeRequired)
                        {
                            logBox.Invoke(new Action(() =>
                            {
                                while (logBox.Lines.Count() > 249)
                                {
                                    logBox.Text = logBox.Text.Substring(
                                        logBox.Text.IndexOf(Environment.NewLine)
                                        + Environment.NewLine.Length);
                                }
                                logBox.AppendText(log);
                                logBox.SelectionStart = logBox.TextLength;
                                logBox.ScrollToCaret();
                            }));
                        }
                        else
                        {
                            while (logBox.Lines.Count() > 249)
                            {
                                logBox.Text = logBox.Text.Substring(
                                    logBox.Text.IndexOf(Environment.NewLine)
                                    + Environment.NewLine.Length);
                            }
                            logBox.AppendText(log);
                            logBox.SelectionStart = logBox.TextLength;
                            logBox.ScrollToCaret();
                        }
                    }
                }
                catch (Exception) { }

            }
        }


        /// <summary>
        /// Formats the log appending the current date and time to the log.
        /// </summary>
        /// <param name="line">The log message.</param>
        /// <returns>Formatted log with current date and time.</returns>
        private static String Format(String line)
        {
            return "[" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt") + "] " +
                line + Environment.NewLine;
        }

    }
}
