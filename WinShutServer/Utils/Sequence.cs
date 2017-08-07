using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShutServer.Utils
{
    
    /// <summary>
    /// 
    /// </summary>
    static class Sequence
    {

        /// <summary>
        /// The event listener whenever the sequence has been set successfully.
        /// </summary>
        /// <param name="args">The object that contains the event's data.</param>
        internal delegate void OnSequenceChangeEventListener(SequenceChangeEventArgs args);

        /// <summary>
        /// The event that triggers whenever the sequence has been set successfully.
        /// </summary>
        internal static OnSequenceChangeEventListener SequenceChange;

        /// <summary>
        /// The event that triggers whenever there are problems setting the sequence.
        /// </summary>
        internal static OnErrorEventListener Error;

        /// <summary>
        /// The storage for the current sequence.
        /// </summary>
        private static SequenceList currentSequence = SequenceList.NoShutdown;

        /// <summary>
        /// Gets the current sequence.
        /// </summary>
        public static SequenceList CurrentSequence
        {
            get
            {
                return currentSequence;
            }
        }

        /// <summary>
        /// Storage for the current type.
        /// </summary>
        private static SequenceType currentType = SequenceType.None;

        /// <summary>
        /// Gets the current type.
        /// </summary>
        public static SequenceType CurrentType
        {
            get
            {
                return currentType;
            }
        }

        /// <summary>
        /// The alarm that monitors when to execute the sequence.
        /// </summary>
        private static Alarm alarm;
        
        internal static long TimeRemaining
        {
            get
            {
                return alarm.Timeout;
            }
        }

        /// <summary>
        /// Gets or sets whether the status change is requested by remote or not.
        /// </summary>
        internal static bool Requested
        {
            get;
            set;
        }

        /// <summary>
        /// Set the sequence to the specified integral equivalent of the sequence and type to Fast.
        /// </summary>
        /// <param name="seq">The integral equivalent of the sequence.</param>
        internal static void Set(int seq)
        {
            Set((SequenceList)seq);
        }

        /// <summary>
        /// Set the sequence to the specified integral equivalent of the sequence and its type to Timed.
        /// Will execute after the specified hour, minute and second.
        /// </summary>
        /// <param name="seq">The integral equivalent of the sequence.</param>
        /// <param name="hr">The number of hour before it executes.</param>
        /// <param name="min">The number of minute before it executes.</param>
        /// <param name="sec">The number of second before it executes.</param>
        internal static void Set(int seq, int hr, int min, int sec)
        {
            Set((SequenceList)seq, hr, min, sec);
        }

        /// <summary>
        /// Set the sequence to the specified integral equivalent of the sequence and its type to Timed.
        /// Will execute after the specified timeout in milliseconds.
        /// </summary>
        /// <param name="seq">The integral equivalent of the sequence.</param>
        /// <param name="timeout">The number of milliseconds before it executes.</param>
        internal static void Set(int seq, int timeout)
        {
            Set((SequenceList)seq, timeout);
        }

        /// <summary>
        /// Set the sequence to the specified integral equivalent of the sequence and its type to Scheduled.
        /// Will execute on the date provided.
        /// </summary>
        /// <param name="seq">The integral equivalent of the sequence.</param>
        /// <param name="date">MyDate instance of the date when will execute.</param>
        internal static void Set(int seq, MyDate date)
        {
            Set((SequenceList)seq, date);
        }

        /// <summary>
        /// Set the sequence to the specified integral equivalent of the sequence and its type to Scheduled.
        /// Will execute on the date provided.
        /// </summary>
        /// <param name="seq">The integral equivalent of the sequence.</param>
        /// <param name="date">DateTime instance of the date when will execute.</param>
        internal static void Set(int seq, DateTime date)
        {
            Set((SequenceList)seq, date);
        }

        /// <summary>
        /// Set the sequence to the specified sequence and type to Fast.
        /// </summary>
        /// <param name="seq">The sequence to be set.</param>
        internal static void Set(SequenceList seq)
        {
            Log.Write("Trying to change sequence.");

            if (currentSequence == seq)
            {
                OnErrorEvent(seq == SequenceList.NoShutdown ? "Already unset any sequence." :
                    "There is a sequence already set.");
                return;
            }

            if (currentSequence > SequenceList.NoShutdown && seq > SequenceList.NoShutdown)
            {
                OnErrorEvent("There is a sequence already set.");
                return;
            }

            if (seq < SequenceList.NoShutdown || seq > SequenceList.LockUser)
            {
                OnErrorEvent("Setting to an invalid sequence.");
                return;
            }
            
            Stop();
            if (seq == SequenceList.NoShutdown)
            {
                currentType = SequenceType.None;
                Log.Write("Successfully unset current sequence.");
            }
            else
            {
                alarm = new Alarm(2000);
                alarm.Expire += () => 
                {
                    ExecuteCommand();
                    Reset();
                };
                alarm.Start();
                currentType = SequenceType.Fast;
                if(Config.Equals("alert", "1"))
                {
                    AlertBox.Show("Sequence Changed!", 
                        "Will " + seq + " in a moment.",
                        1800);
                }
                Log.Write("Set sequence to " + currentType + " " + seq + ".");
            }

            currentSequence = seq;
            OnSequenceChangeEvent(new SequenceChangeEventArgs(CurrentSequence, CurrentType));
        }

        /// <summary>
        /// Set the sequence to the specified sequence and its type to Timed.
        /// Will execute after the specified hour, minute and second.
        /// </summary>
        /// <param name="seq">The sequence to be set.</param>
        /// <param name="hr">The number of hour before it executes.</param>
        /// <param name="min">The number of minute before it executes.</param>
        /// <param name="sec">The number of second before it executes.</param>
        internal static void Set(SequenceList seq, int hr, int min, int sec)
        {
            Set(seq, hr * 3600000 + min * 60000 + sec * 1000);
        }

        /// <summary>
        /// Set the sequence to the specified sequence and its type to Timed.
        /// Will execute after the specified timeout in milliseconds.
        /// </summary>
        /// <param name="seq">The sequence to be set.</param>
        /// <param name="timeout">The number of milliseconds before it executes.</param>
        internal static void Set(SequenceList seq, int timeout)
        {
            Log.Write("Trying to change sequence.");
            if (currentSequence > SequenceList.NoShutdown && seq > SequenceList.NoShutdown)
            {
                OnErrorEvent("There is a sequence already set.");
                return;
            }

            if (seq < SequenceList.Shutdown || seq > SequenceList.LockUser)
            {
                OnErrorEvent("Setting to an invalid timed sequence.");
                return;
            }

            if(timeout < 5000)
            {
                OnErrorEvent("Setting timed sequence with timeout less than 5 seconds.");
                return;
            }

            Stop();

            alarm = new Alarm(timeout);
            alarm.Expire += () =>
            {
                ExecuteCommand();
                Reset();
            };
            alarm.AddTimeoutThreshold(60000);
            alarm.AddTimeoutThreshold(600000);
            alarm.AddTimeoutThreshold(3600000);

            alarm.TimeoutRemaining += (int remain) =>
            {
                if (Config.Equals("alert", "1"))
                {
                    string alert = "Will " + CurrentSequence + " in less than ";
                    switch(remain)
                    {
                        case 60000:
                            alert += "a minute.";
                            break;
                        case 600000:
                            alert += "ten minutes.";
                            break;
                        case 3600000:
                            alert += "an hour.";
                            break;
                    }
                    AlertBox.Show("Sequence Reminder!", alert, 15000);
                }
            };

            alarm.Start();

            currentType = SequenceType.Timed;
            currentSequence = seq;

            int hr = timeout / 3600000;
            int min = (timeout % 3600000) / 60000;
            int sec = ((timeout % 3600000) % 60000) / 1000;

            string show = "";
            if(hr > 0)
            {
                show += hr + " hour" + (hr > 0 ? "s" : "") + (min > 0 || sec > 0 ? ", " : "");
            }

            if(min > 0)
            {
                show += min + " minute" + (min > 0 ? "s" : "") + (sec > 0 ? ", " : "");
            }

            if(sec > 0)
            {
                show += sec + " second" + (sec > 0 ? "s" : "") + "";
            }

            if (Config.Equals("alert", "1"))
            {
                AlertBox.Show("Sequence Changed!",
                    "Will " + seq + " in " + show + ".",
                    15000);
            }
            Log.Write("Set sequence to " + currentType + " " + seq + " that will execute after " + show + ".");
            
            OnSequenceChangeEvent(new SequenceChangeEventArgs(CurrentSequence, timeout));

        }

        /// <summary>
        /// Set the sequence to the specified sequence and its type to Scheduled.
        /// Will execute on the date provided.
        /// </summary>
        /// <param name="seq">The sequence to be set.</param>
        /// <param name="date">MyDate instance of the date when will execute.</param>
        internal static void Set(SequenceList seq, DateTime date)
        {
            Set(seq, new MyDate(date));
        }

        /// <summary>
        /// Set the sequence to the specified sequence and its type to Scheduled.
        /// Will execute on the date provided.
        /// </summary>
        /// <param name="seq">The sequence to be set.</param>
        /// <param name="date">DateTime instance of the date when will execute.</param>
        internal static void Set(SequenceList seq, MyDate date)
        {
            Log.Write("Trying to change sequence.");
            if (currentSequence > SequenceList.NoShutdown && seq > SequenceList.NoShutdown)
            {
                OnErrorEvent("There is a sequence already set.");
                return;
            }

            if (seq < SequenceList.Shutdown || seq > SequenceList.LockUser)
            {
                OnErrorEvent("Setting to an invalid timed sequence.");
                return;
            }

            if (date.Millis < new MyDate().Millis + 5000)
            {
                OnErrorEvent("Setting scheduled sequence time five seconds or less in the future.");
                return;
            }

            Stop();

            alarm = new Alarm(date);
            alarm.Expire += () =>
            {
                ExecuteCommand();
                Reset();
            };
            alarm.AddTimeoutThreshold(60000);
            alarm.AddTimeoutThreshold(600000);
            alarm.AddTimeoutThreshold(3600000);

            alarm.TimeoutRemaining += (int remain) =>
            {
                if (Config.Equals("alert", "1"))
                {
                    string alert = "Will " + CurrentSequence + " in less than ";
                    switch (remain)
                    {
                        case 60000:
                            alert += "a minute.";
                            break;
                        case 600000:
                            alert += "ten minutes.";
                            break;
                        case 3600000:
                            alert += "an hour.";
                            break;
                    }
                    AlertBox.Show("Sequence Reminder!", alert, 15000);
                }
            };
            Console.WriteLine(alarm.Timeout);
            alarm.Start();

            currentType = SequenceType.Scheduled;
            currentSequence = seq;
            
            if (Config.Equals("alert", "1"))
            {
                AlertBox.Show("Sequence Changed!",
                    "Will " + seq + " on " + date.GetString() + ".",
                    15000);
            }
            Log.Write("Set sequence to " + currentType + " " + seq + " that will execute on " + date.GetString() + ".");

            OnSequenceChangeEvent(new SequenceChangeEventArgs(CurrentSequence, date));

        }

        /// <summary>
        /// Stops the ongoing alarm for this class.
        /// </summary>
        private static void Stop()
        {
            if (alarm != null) alarm.Stop();
        }

        /// <summary>
        /// Resets the current sequence and current type and invoke the sequence change event.
        /// </summary>
        private static void Reset()
        {
            currentSequence = SequenceList.NoShutdown;
            currentType = SequenceType.None;
            OnSequenceChangeEvent(new SequenceChangeEventArgs(CurrentSequence, CurrentType));
        }

        /// <summary>
        /// Executes the command for the current sequence.
        /// </summary>
        private static void ExecuteCommand()
        {
            AlertBox.Close();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = " /C " + Command(currentSequence);
            process.StartInfo = startInfo;
            process.Start();
        }

        /// <summary>
        /// Gets the command for the specified sequence.
        /// </summary>
        /// <param name="seq">The sequence.</param>
        /// <returns>Command string of the specified sequence.</returns>
        private static string Command(SequenceList seq)
        {
            switch (seq)
            {
                case SequenceList.NoShutdown:
                    return "shutdown /a";
                case SequenceList.Shutdown:
                    return "shutdown /f /s /t 0";
                case SequenceList.Restart:
                    return "shutdown /f /r /t 0";
                case SequenceList.Sleep:
                    return "rundll32.exe powrprof.dll,SetSuspendState 0,1,0";
                case SequenceList.Hibernate:
                    return "rundll32.exe PowrProf.dll,SetSuspendState";
                case SequenceList.LogOff:
                    return "shutdown /f /l";
                case SequenceList.LockUser:
                    return "rundll32.exe user32.dll, LockWorkStation";
            }
            return "";
        }

        /// <summary>
        /// Gets the color representation of the sequence using the specified integral
        /// equivalent of the sequence.
        /// </summary>
        /// <param name="seq">Integral equivalent of the sequence.</param>
        /// <returns>Color representation of the sequence.</returns>
        internal static System.Drawing.Color GetColor(int seq)
        {
            return GetColor((SequenceList)seq);
        }

        /// <summary>
        /// Gets the color representation of the sequence using the specified sequence.
        /// </summary>
        /// <param name="seq">The sequence.</param>
        /// <returns>Color representation of the sequence.</returns>
        internal static System.Drawing.Color GetColor(SequenceList seq)
        {
            switch (seq)
            {
                case SequenceList.NoShutdown:
                    return System.Drawing.Color.Red;
                case SequenceList.Shutdown:
                    return System.Drawing.Color.OrangeRed;
                case SequenceList.Restart:
                    return System.Drawing.Color.Green;
                case SequenceList.Sleep:
                    return System.Drawing.Color.Yellow;
                case SequenceList.Hibernate:
                    return System.Drawing.Color.LightGoldenrodYellow;
                case SequenceList.LogOff:
                    return System.Drawing.Color.GreenYellow;
                case SequenceList.LockUser:
                    return System.Drawing.Color.YellowGreen;
            }
            return System.Drawing.Color.Black;
        }

        /// <summary>
        /// Invokes when sequence is successfully set.
        /// </summary>
        /// <param name="args">The object that contains the event's data.</param>
        private static void OnSequenceChangeEvent(SequenceChangeEventArgs args)
        {
            Data send = new Data("sequence", ((int)args.Sequence).ToString())
                .Add(((int)args.Type).ToString());
            switch (args.Type)
            {
                case SequenceType.Timed:
                    send.Add(args.Hour.ToString(), args.Minute.ToString(), args.Second.ToString());
                    break;
                case SequenceType.Scheduled:
                    send.Add(args.Date.Hour.ToString(), args.Date.Minute.ToString(), args.Date.Second.ToString());
                    break;
            }
            Server.Send(send);
            SequenceChange?.Invoke(args);
        }

        /// <summary>
        /// Invokes the message event with the specified error message.
        /// </summary>
        /// <param name="message">The error message of the event.</param>
        private static void OnErrorEvent(string message)
        {
            Log.Write(message);
            if(Config.Equals("alert", "1"))
            {
                AlertBox.Show("Sequence Change Error!", message);
            }
            if (Requested)
            {
                Server.Send(new Data("sequence", "-1").Add(message));
                Requested = false;
            }
            Error?.Invoke(message);
        }

    }

    /// <summary>
    /// Generates the data needed in an sequence change event.
    /// </summary>
    internal class SequenceChangeEventArgs : EventArgs
    {

        /// <summary>
        /// The new sequence set.
        /// </summary>
        private SequenceList sequence;

        /// <summary>
        /// Gets the new sequence set.
        /// </summary>
        internal SequenceList Sequence
        {
            get
            {
                return sequence;
            }
        } 

        /// <summary>
        /// The new type set.
        /// </summary>
        private SequenceType type;

        /// <summary>
        /// Gets the new type set.
        /// </summary>
        internal SequenceType Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// The date when the sequence will be executed.
        /// Used only in Scheduled type.
        /// </summary>
        private MyDate date;

        /// <summary>
        /// Gets the date when the sequence will be executed.
        /// Used only in Scheduled type.
        /// </summary>
        internal MyDate Date
        {
            get
            {
                return date;
            }
        }

        /// <summary>
        /// The number of hours before the sequence executed.
        /// Used only in Timed type.
        /// </summary>
        private int hour;

        /// <summary>
        /// Gets the number of hours before the sequence executed.
        /// Used only in Timed type.
        /// </summary>
        internal int Hour
        {
            get
            {
                return hour;
            }
        }

        /// <summary>
        /// The number of minutes before the sequence executed.
        /// Used only in Timed type.
        /// </summary>
        private int minute;
        
        /// <summary>
        /// Gets the number of minutes before the sequence executed.
        /// Used only in Timed type.
        /// </summary>
        internal int Minute
        {
            get
            {
                return minute;
            }
        }

        /// <summary>
        /// The number of seconds before the sequence executed.
        /// Used only in Timed type.
        /// </summary>
        private int second;

        /// <summary>
        /// Gets the number of seconds before the sequence executed.
        /// Used only in Timed type.
        /// </summary>
        internal int Second
        {
            get
            {
                return second;
            }
        }

        /// <summary>
        /// Gets total number of milliseconds before the sequence executed.
        /// Used only in Timed type.
        /// </summary>
        internal int Millis
        {
            get
            {
                return hour * 3600000 + minute * 60000 + second * 1000;
            }
        }

        /// <summary>
        /// Creates an instance with specified sequence and type.
        /// </summary>
        /// <param name="sequence">The new sequence being set.</param>
        /// <param name="type">The new type being set.</param>
        internal SequenceChangeEventArgs(SequenceList sequence, SequenceType type)
        {
            this.sequence = sequence;
            this.type = type;
        }

        /// <summary>
        /// Creates an instance with specified sequence and time before it executes.
        /// Automatically sets to Timed sequence type.
        /// </summary>
        /// <param name="sequence">The new sequence being set.</param>
        /// <param name="millis">Time in milleseconds before the sequence's command executes.</param>
        internal SequenceChangeEventArgs(SequenceList sequence, int millis) 
            : this(sequence, SequenceType.Timed)
        {
            hour = millis / 3600000;
            minute = (millis % 3600000) / 60000;
            second = ((millis % 3600000) % 60000) / 1000;
        }

        /// <summary>
        /// Creates an instance with specified sequence and time before it executes in
        /// hour, minutes and seconds.
        /// Automatically sets to Timed sequence type.
        /// </summary>
        /// <param name="sequence">The new sequence being set.</param>
        /// <param name="hr">Time in milleseconds before the sequence's command executes.</param>
        /// <param name="min">Time in milleseconds before the sequence's command executes.</param>
        /// <param name="sec">Time in milleseconds before the sequence's command executes.</param>
        internal SequenceChangeEventArgs(SequenceList sequence, int hr, int min, int sec) 
            : this(sequence, SequenceType.Timed)
        {
            hour = hr;
            minute = min;
            second = sec;
        }

        /// <summary>
        /// Creates an instance with specified sequence and datetime when it will be executed.
        /// </summary>
        /// <param name="sequence">The new sequence being set.</param>
        /// <param name="datetime">The MyDate instance of the date time when it will be executed.</param>
        internal SequenceChangeEventArgs(SequenceList sequence, MyDate datetime) 
            : this(sequence, SequenceType.Scheduled) 
        {
            date = datetime;
        }

        /// <summary>
        /// Creates an instance with specified sequence and datetime when it will be executed.
        /// </summary>
        /// <param name="sequence">The new sequence being set.</param>
        /// <param name="datetime">The DateTime instance of the date time when it will be executed.</param>
        internal SequenceChangeEventArgs(SequenceList sequence, DateTime datetime) 
            : this(sequence, SequenceType.Scheduled)
        {
            date = new MyDate(datetime);
        }

        /// <summary>
        /// Gets the string representation of the instance.
        /// </summary>
        /// <returns>String with the sequence and type.</returns>
        public override string ToString()
        {
            return sequence == SequenceList.NoShutdown ? sequence.ToString() : type + " " + sequence;
        }

    }

    /// <summary>
    /// The list of possible sequences to be executed to the computer.
    /// </summary>
    enum SequenceList : int
    {
        NoShutdown = 0,
        Shutdown = 1,
        Restart = 2,
        Sleep = 3,
        Hibernate = 4,
        LogOff = 5,
        LockUser = 6
    }

    /// <summary>
    /// The list of how the sequence can be executed.
    /// </summary>
    enum SequenceType : int
    {
        None = 0,
        Fast = 1,
        Timed = 2,
        Scheduled = 3
    }
}
