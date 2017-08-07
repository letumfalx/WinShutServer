using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace WinShutServer.Utils
{

    /// <summary>
    /// Generates a timed or scheduled event.
    /// </summary>
    public class Alarm
    {

        /// <summary>
        /// The event listener when the alarm expires.
        /// </summary>
        public delegate void OnExpireEventListener();

        /// <summary>
        /// The methods that will be executed when the alarm expires.
        /// </summary>
        public OnExpireEventListener Expire;

        /// <summary>
        /// The event listener for any notification before the alarm expires.
        /// </summary>
        /// <param name="remaining">Time remaining when this event is triggered.</param>
        public delegate void OnTimeoutRemaining(int remaining);

        /// <summary>
        /// The methods to be executed for any notification before the alarm expires.
        /// </summary>
        public OnTimeoutRemaining TimeoutRemaining;

        private List<int> timeoutThreshold;

        /// <summary>
        /// The object that monitors the remaining time of the alarm.
        /// </summary>
        private Timer timer;

        /// <summary>
        /// The remaining time in milliseconds of the alarm before it expires.
        /// </summary>
        private long timeout = 0;

        /// <summary>
        /// Gets or sets the remaining time of the alarm before it expires.
        /// Setting the timeout in a scheduled alarm or the alarm is already finished
        /// will do nothing.
        /// </summary>
        public long Timeout
        {
            get
            {
                return timeout < 0 ? -1 : timeout;
            }
            set
            {
                if (date == null && !finish)
                {
                    timeout = value;
                }
            }
        }

        /// <summary>
        /// The date in this MyDate instance will be the expiry time of the alarm.
        /// </summary>
        private MyDate date = null;
        
        /// <summary>
        /// Gets or sets the MyDate of the alarm.
        /// Setting the date on a timed alarm or if the alarm is already finished
        /// will do nothing.
        /// </summary>
        public MyDate Date
        {
            get
            {
                return date;
            }

            set
            {
                if(date != null && !finish)
                {
                    date = value;
                    timeout = date.Millis - new MyDate().Millis;
                }
            }
        }

        /// <summary>
        /// Use to monitor the time elapsed of per tick of the timer.
        /// </summary>
        private long startTime = 0;

        /// <summary>
        /// Use to monitor if the alarm already expires.
        /// </summary>
        private bool finish = false;

        /// <summary>
        /// Gets whether the alarm already expires or not.
        /// </summary>
        public bool Finish
        {
            get
            {
                return finish;
            }
        }

        /// <summary>
        /// Gets whether the Alarm is running or not.
        /// </summary>
        public bool Running
        {
            get
            {
                return finish ? false : timer.Enabled;
            }
        }

        private static Comparison<int> comparator = new Comparison<int>((i1, i2) => i2.CompareTo(i1));

        /// <summary>
        /// Initialize a general alarm.
        /// </summary>
        private Alarm()
        {
            timer = new Timer();
            timer.Interval = 150;
            timer.Elapsed += Timer_Elapsed;
            timeoutThreshold = new List<int>();
        }

        /// <summary>
        /// The method that will be invoked when the timer ticks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(timeout <= 0)
            {
                Expire?.Invoke();
                Expire = null;
                finish = true;
                Stop();
                return;
            }

            if(timeoutThreshold.Count > 0)
            {
                if(timeout <= timeoutThreshold[0])
                {
                    TimeoutRemaining?.Invoke(timeoutThreshold[0]);
                    timeoutThreshold.RemoveAt(0);
                    
                }
            }

            long minus = Environment.TickCount - startTime;
            timeout -= minus <= 0 ? 1 : minus;
            startTime = Environment.TickCount;
        }

        /// <summary>
        /// Creates an instance of this class using a specified timeout.
        /// Sets the alarm to a timed alarm.
        /// </summary>
        /// <param name="timeout">Timeout in milliseconds before the alarm expires.</param>
        public Alarm(long timeout) : this()
        {
            this.timeout = timeout;
            if(timeout < timer.Interval)
            {
                timer.Interval = timeout;
            }
        }

        /// <summary>
        /// Creates an instance of this class using specified hour, minute and second
        /// that will be converted to milliseconds.
        /// </summary>
        /// <param name="hour">Number of hour before the timer expires.</param>
        /// <param name="minute">Number of minute before the timer expires.</param>
        /// <param name="second">Number of seconds before the timer expires.</param>
        public Alarm(int hour, int minute, int second) 
            : this((hour * 3600 + minute * 60 + second) * 1000)
        {

        }

        /// <summary>
        /// Creates an instance of this class using a specified MyDate instance where
        /// its date will be the date and time when the alarm will expires.
        /// </summary>
        /// <param name="date">The MyDate instance that contains the date and time when the alarm will expires.</param>
        public Alarm(MyDate date) : this()
        {
            this.date = date;
        }

        /// <summary>
        /// Creates an instance of this class using a specified DateTime instance
        /// where its date and time will be the date and time when the alarm will
        /// expires.
        /// </summary>
        /// <param name="date">The DateTime instance that contains the date and time when the alarm will expires.</param>
        public Alarm(DateTime date) : this(new MyDate(date))
        {

        }

        /// <summary>
        /// Starts the ticking of the alarm.
        /// </summary>
        /// <exception cref="AlreadyFinishedException">Throw when trying to start an expired alarm.</exception>
        public void Start()
        {
            if(finish)
            {
                throw new AlreadyFinishedException();
            }
            if(timer.Enabled)
            {
                timer.Stop();
            }
            if(date != null)
            {
                timeout = date.Millis - new MyDate().Millis;
                Console.WriteLine(timeout);
            }
            startTime = Environment.TickCount;
            timer.Start();
        }
        
        /// <summary>
        /// Cancel the ticking of the alarm.
        /// </summary>
        public void Stop()
        {
            if(timer.Enabled)
            {
                timer.Stop();
            }
        }
        
        /// <summary>
        /// Adds a time threshold when the timeout remaining event occurs.
        /// Maximum of 5 time threshold is allowed.
        /// Can add time greater than timeout if the list is still empty.
        /// </summary>
        /// <param name="timeLeft">Time in milliseconds remaining before the event triggers, 
        /// must be less than the timeout.</param>
        /// <returns>True if successfully added or already in the list.</returns>
        /// <exception cref="AlreadyFinishedException">Throws when trying to add time 
        /// threshold to an alarm that is already finished.</exception>
        public bool AddTimeoutThreshold(int timeLeft)
        {
            if(finish)
            {
                throw new AlreadyFinishedException();
            }

            if(timeoutThreshold.Count >= 5)
            {
                return false;
            }
            
            if(timeLeft > timeout && timeoutThreshold.Count > 0)
            {
                return false;
            }


            

            //do not add replicates
            if (!timeoutThreshold.Contains(timeLeft))
            {
                timeoutThreshold.Add(timeLeft);
                timeoutThreshold.Sort(comparator);
            }

            return true;
        }
               
    }
    
    /// <summary>
    /// Represents the error occurs when trying to start an already finished instance.
    /// </summary>
    public class AlreadyFinishedException : Exception
    {

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public AlreadyFinishedException() : base("Instance trying to start is already finished.")
        {
            
        }

    }

}
