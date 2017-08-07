using System;

namespace WinShutServer.Utils
{
    /// <summary>
    /// An improve DateTime class that can accept negative or big arguments.
    /// </summary>
    public class MyDate
    {

        /// <summary>
        /// The <c>DateTime</c> of this instance.
        /// </summary>
        private DateTime dt;

        /// <summary>
        /// Constant for the month of January.
        /// </summary>
        public const int JAN = 1;

        /// <summary>
        /// Constant for the month of February.
        /// </summary>
        public const int FEB = 2;

        /// <summary>
        /// Constant for the month of March.
        /// </summary>
        public const int MAR = 3;

        /// <summary>
        /// Constant for the month of April.
        /// </summary>
        public const int APR = 4;

        /// <summary>
        /// Constant for the month of May.
        /// </summary>
        public const int MAY = 5;

        /// <summary>
        /// Constant for the month of June.
        /// </summary>
        public const int JUN = 6;

        /// <summary>
        /// Constant for the month of July.
        /// </summary>
        public const int JUL = 7;

        /// <summary>
        /// Constant for the month of August.
        /// </summary>
        public const int AUG = 8;

        /// <summary>
        /// Constant for the month of September.
        /// </summary>
        public const int SEP = 9;

        /// <summary>
        /// Constant for the month of October.
        /// </summary>
        public const int OCT = 10;

        /// <summary>
        /// Constant for the month of November.
        /// </summary>
        public const int NOV = 11;

        /// <summary>
        /// Constant for the month of December.
        /// </summary>
        public const int DEC = 12;

        /// <summary>
        /// The year of this instance.
        /// </summary>
        private int year = 0;

        /// <summary>
        /// Gets the year of this instance.
        /// </summary>
        public int Year
        {
            get
            {
                return year;
            }
        }

        /// <summary>
        /// Gets the last two digit of the year of this instance.
        /// </summary>
        public int TwoDigitYear
        {
            get
            {
                return Convert.ToInt16(this.dt.ToString("yy"));
            }
        }

        /// <summary>
        /// The month of this instance.
        /// </summary>
        private int month = 0;

        /// <summary>
        /// Gets the month of this instance.
        /// </summary>
        public int Month
        {
            get
            {
                return month;
            }
        }

        /// <summary>
        /// Gets the Long name of the month of this instance.
        /// </summary>
        public String MonthLongName
        {
            get
            {
                return this.dt.ToString("MMMM");
            }
        }
        
        /// <summary>
        /// Gets the short name of the month of this instance.
        /// </summary>
        public String MonthShortName
        {
            get
            {
                return this.dt.ToString("MMM");
            }
        }

        /// <summary>
        /// The day of this instance.
        /// </summary>
        private int day = 0;

        /// <summary>
        /// Gets the day in the month of this instance.
        /// </summary>
        public int Day
        {
            get
            {
                return day;
            }
        }

        /// <summary>
        /// Gets the short week day name of the day of this instance.
        /// </summary>
        public String WeekDayShortName
        {
            get
            {
                return this.dt.ToString("ddd");
            }

        }

        /// <summary>
        /// Gets the long week day name of the day of this instance.
        /// </summary>
        public String WeekDayLongName
        {
            get
            {
                return this.dt.ToString("dddd");
            }
        }

        /// <summary>
        /// Gets on what day of the week is the day of this instance.
        /// </summary>
        public int WeekDay
        {
            get
            {
                switch (WeekDayLongName.ToLower())
                {
                    case "monday":
                        return 1;
                    case "tuesday":
                        return 2;
                    case "wednesday":
                        return 3;
                    case "thursday":
                        return 4;
                    case "friday":
                        return 5;
                    case "saturday":
                        return 6;
                    case "sunday":
                        return 7;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// Gets what day of the year is the day of this instance.
        /// </summary>
        public int YearDay
        {
            get
            {
                return this.dt.DayOfYear;
            }
        }


        /// <summary>
        /// The hour of this instance.
        /// </summary>
        private int hour = 0;

        /// <summary>
        /// Gets the 24-hr format of the hour of this instance.
        /// </summary>
        public int Hour
        {
            get
            {
                return hour;
            }
        }

        /// <summary>
        /// Gets the 12-hr format of the hour of this instance.
        /// </summary>
        public int Hour12
        {
            get
            {
                return Convert.ToInt32(this.dt.ToString("hh"));
            }
        }

        /// <summary>
        /// The minute of this instance.
        /// </summary>
        private int minute = 0;

        /// <summary>
        /// Gets the minute of this instance.
        /// </summary>
        public int Minute
        {
            get
            {
                return minute;
            }
        }

        /// <summary>
        /// The second of this instance.
        /// </summary>
        private int second = 0;

        /// <summary>
        /// Gets the seconds of this instance.
        /// </summary>
        public int Second
        {
            get
            {
                return second;
            }
        }


        public String AmPm
        {
            get
            {
                return this.dt.ToString("tt");
            }
        }

        /// <summary>
        /// Gets the elapsed milliseconds since January 1, 0001 12:00 MN.
        /// </summary>
        public long Millis
        {
            get
            {
                return this.dt.Ticks / 10000;
            }
        }

        /// <summary>
        /// Gets the elapsed milliseconds since January 1, 1970 12:00 MN. 
        /// This (1970/01/01 00:00) is the standard start of some other language.
        /// </summary>
        public long Millis1970
        {
            get
            {
                return Millis - new MyDate(1970, 1, 1, 0, 0, 0).Millis;
            }
        }

        /// <summary>
        /// Gets the ticks (1 tick = 100 ns) since January 1, 0001 12:00MN.
        /// </summary>
        public long Ticks
        {
            get
            {
                return this.dt.Ticks;
            }
        }

        // <summary>
        /// Gets the ticks (1 tick = 100 ns) since January 1, 1970 12:00 MN. 
        /// This (1970/01/01 00:00) is the standard start of some other language.
        /// </summary>
        public long Ticks1970
        {
            get
            {
                return Ticks - new MyDate(1970, 1, 1, 0, 0, 0).Ticks;
            }
        }

        /// <summary>
        /// Gets the offset of the local timezone to UTC.
        /// </summary>
        public String UTCOffset
        {
            get
            {
                return this.dt.ToString("zzz");
            }
        }

        /// <summary>
        /// Gets the DateTime instance of this instance.
        /// </summary>
        public DateTime Date
        {
            get
            {
                return dt;
            }
        }
        
        /// <summary>
        /// Initialize the MyDate class using the current DateTime.
        /// </summary>
        public MyDate()
        {
            dt = DateTime.Now;
            parseAll();
        }

        /// <summary>
        /// Initialize the MyDate class using specified DateTime.
        /// </summary>
        /// <param name="dt">The DateTime of the instance.</param>
        public MyDate(DateTime dt)
        {
            this.dt = dt;
            parseAll();
        }

        /// <summary>
        /// Initialize the MyDate class using specified elapsed ticks.
        /// </summary>
        /// <param name="ticks">The ticks of the DateTime used.</param>
        public MyDate(long ticks)
        {
            this.dt = new DateTime(ticks);
            parseAll();
        }

        /// <summary>
        /// Initialize the MyDate class using specified year, month, day, hour, minute and second.
        /// </summary>
        /// <param name="year">The year of the instance.</param>
        /// <param name="month">The month of the instance.</param>
        /// <param name="day">The day of the instance.</param>
        /// <param name="hr">The hour of the instance.</param>
        /// <param name="min">The minute of the instance.</param>
        /// <param name="sec">The second of the instance.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws when arguments 
        /// are negative or the final year exceeds 9999.</exception>
        public MyDate(int year, int month, int day, int hr, int min, int sec)
        {
            if (year < 1)
            {
                throw new ArgumentOutOfRangeException("year");
            }
            if(month == 0)
            {
                month = 1;
            }
            if(day == 0)
            {
                day = 1;
            }
            
            while(sec < 0)
            {
                sec += 60;
                min--;
            }
            
            while(min < 0)
            {
                min += 60;
                hr--;
            }

            while(hr < 0)
            {
                hr += 24;
                day--;
            }

            int overflow = 0;

            //sec
            if (sec > 59)
            {
                overflow = sec / 60;
                sec %= 60;
            }

            min += overflow;
            overflow = 0;

            //minute
            if (min > 59)
            {
                overflow = min / 60;
                min %= 60;
            }

            hr += overflow;
            overflow = 0;

            //hour
            if (hr > 23)
            {
                overflow = hr / 24;
                hr %= 24;
            }

            day += overflow;
            overflow = 0;
            //Console.WriteLine("after hrminsec: " + year + "/" + month + "/" + day + " " + hr + ":" + min + ":" + sec);
            
            //make month positive
            while(month < 1)
            {
                month += 12;
                year--;
            }

            //Console.WriteLine("after making month positive: " + year + "/" + month + "/" + day + " " + hr + ":" + min + ":" + sec);
            //make month <12
            month--;
            month %= 12;
            year += month / 12;

            //make month index 1
            month++;

            //Console.WriteLine("after making month lowest term: " + year + "/" + month + "/" + day + " " + hr + ":" + min + ":" + sec);

            //make day base 0;
            //day--;
            if (day < 0)
            {
                while (day < 0)
                {
                    month--;
                    if (month < 1)
                    {
                        month = 12;
                        year++;
                    }
                    //Console.WriteLine("DAys of " + month + ": " + GetDaysOfMonth(month, year));
                    day += GetDaysOfMonth(month, year); //because index 0

                }
                day++;
            }
            //Console.WriteLine("after making day positive: " + year + "/" + month + "/" + day + " " + hr + ":" + min + ":" + sec);

            //reduce days to its lowest form
            while (day > GetDaysOfMonth(month, year))
            {
                day -= GetDaysOfMonth(month, year);
                month++;
                if (month > 12)
                {
                    month = 1;
                    year++;
                }
            }
            
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("year");
            }

            DateTime dt00 = new DateTime(year, month, day, hr, min, sec);
            this.dt = dt00;
            parseAll();

        }

        /// <summary>
        /// Initialize the MyDate class with the current year, month and day 
        /// and with specified hour, minute and second.
        /// </summary>
        /// <param name="hr">The hour of the instance.</param>
        /// <param name="min">The minute of the instance.</param>
        /// <param name="sec">The second of the instance.</param>
        public MyDate(int hr, int min, int sec)
            : this(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hr, min, sec)
        {

        }

        /// <summary>
        /// Sets the properties of the instance with the set date from the constructor.
        /// </summary>
        private void parseAll()
        {
            year = Convert.ToInt32(dt.ToString("yyyy"));
            month = Convert.ToInt32(dt.ToString("MM"));
            day = Convert.ToInt32(dt.ToString("dd"));
            hour = Convert.ToInt32(dt.ToString("HH"));
            minute = Convert.ToInt32(dt.ToString("mm"));
            second = Convert.ToInt32(dt.ToString("ss"));
        }

        /// <summary>
        /// Gets if the year of this instance is a leap year.
        /// </summary>
        /// <returns>True if leap year.</returns>
        public bool IsLeapYear()
        {
            return HasLeapDay(year);
        }

        /// <summary>
        /// Gets the string representation of this instance.
        /// </summary>
        /// <returns>String with 12-hr format time.</returns>
        public string GetString()
        {
            return this.MonthShortName + " " + this.Day + ", "
                + this.Year + " " + String.Format("{0:00}:{1:00}:{2:00}",
                this.Hour12, this.Minute, this.Second) + " " + this.AmPm;
        }

        /// <summary>
        /// Use to determine if the specified year has a leap day.
        /// </summary>
        /// <param name="year">Year to be checked.</param>
        /// <returns>True if it has a leap day.</returns>
        public static bool HasLeapDay(int year)
        {
            return (year % 100 == 0 && year % 400 == 0) || (year % 100 != 0 && year % 4 == 0);
        }

        /// <summary>
        /// Gets the number of days of the specified month on the specified year.
        /// </summary>
        /// <param name="month">The month requested.</param>
        /// <param name="year">The year where the month is in.</param>
        /// <returns>The number of days.</returns>
        public static int GetDaysOfMonth(int month, int year)
        {
            switch (month)
            {
                case JAN:
                case MAR:
                case MAY:
                case JUL:
                case AUG:
                case OCT:
                case DEC:
                    return 31;
                case APR:
                case JUN:
                case SEP:
                case NOV:
                    return 30;
                case FEB:
                    return HasLeapDay(year) ? 29 : 28;
                    
            }
            if(month > DEC)
            {
                return GetDaysOfMonth(((month - 1) % 12) + 1, year + (month / 12));
            } else
            {
                if(month == 0)
                {
                    return GetDaysOfMonth(JAN);
                }       
                else
                {
                    month += 12;
                    if(month > -1)
                    {
                        return GetDaysOfMonth(month + 1, year++);
                    }
                    return GetDaysOfMonth(month, year++);
                }
            }
        }

        /// <summary>
        /// Gets the number of days in the specified month.
        /// </summary>
        /// <param name="month">The month requested.</param>
        /// <returns>Number of days in the specified month.</returns>
        public static int GetDaysOfMonth(int month)
        {
            return GetDaysOfMonth(month, 1);
        }


    }
}
