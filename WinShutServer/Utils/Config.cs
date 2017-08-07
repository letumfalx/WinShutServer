using System;
using System.Collections;
using System.Collections.Generic;

namespace WinShutServer.Utils
{
    /// <summary>
    /// Contains configuration of the executables.
    /// </summary>
    static class Config
    {

        /// <summary>
        /// Stores the config file.
        /// </summary>
        private static FileManager file = null;

        /// <summary>
        /// Stores the path of the config file.
        /// </summary>
        private static string path = Environment.GetEnvironmentVariable("APPDATA") + @"\WinShutServer\config";

        /// <summary>
        /// Stores the map of the configs.
        /// </summary>
        private static Dictionary<string, string> configs = null;

        /// <summary>
        /// Gets the collection of keys.
        /// </summary>
        public static ICollection Keys
        {
            get
            {
                return configs.Keys;
            }
        }

        /// <summary>
        /// Gets the collection of values.
        /// </summary>
        public static ICollection Values
        {
            get
            {
                return configs.Values;
            }
        }

        /// <summary>
        /// Sets the path of the config file.
        /// </summary>
        /// <param name="path"></param>
        public static void SetFilePath(string path)
        {
            file = new FileManager(path);
        }

        /// <summary>
        /// Loads the file containing the configurations.
        /// </summary>
        public static void Init()
        {
            if(configs != null)
            {
                return;
            }
            configs = new Dictionary<string, string>();
            configs.Clear();
            
            if (file == null)
            {
                file = new FileManager(path);
            }

            file.ReloadLines();
            foreach (string line in file.Lines)
            {
                if (line.IndexOf('=') < 1)
                {
                    continue;
                }
                Log.Write(line.Trim(), Log.CONSOLE);
                string key = line.Substring(0, line.IndexOf("=")).Trim();
                string value = line.Substring(line.IndexOf("=") + 1);
                if (!configs.ContainsKey(key))
                {
                    configs.Add(key, value);
                }
            }
        }

        /// <summary>
        /// Sets a config with specified key and value.
        /// </summary>
        /// <param name="key">The config identifier.</param>
        /// <param name="value">The config value.</param>
        public static void Set(string key, string value)
        {
            Init();
            if (configs.ContainsKey(key))
            {
                configs[key] = value;
            } else
            {
                configs.Add(key, value);
            }

            file.ClearBuffer();
            string[] tmp = new List<string>(configs.Keys).ToArray();
            foreach (string str in tmp)
            {
                file.PrintLine(str + "=" + configs[str]);
            }
            file.Flush();
        }

        /// <summary>
        /// Sets a config with specified key and a boolean to determine it is set or reset.
        /// </summary>
        /// <param name="key">The config identifier.</param>
        /// <param name="value">True if set(1), false if not set(0).</param>
        public static void Set(string key, bool isSet)
        {
            Set(key, isSet ? "1" : "0");
        }

        /// <summary>
        /// Gets the value of the config with the specified key.
        /// </summary>
        /// <param name="key">The identifier of the config to search.</param>
        /// <returns>The value of the config.</returns>
        public static string Get(string key)
        {
            Init();
            return configs.ContainsKey(key) ? configs[key] : null;
        }

        public static bool IsSet(string key)
        {
            Init();
            return configs.ContainsKey(key) ? configs[key] == "1" ? true : false : false;
        }

        /// <summary>
        /// Checks if the config has the specified key.
        /// </summary>
        /// <param name="key">The identifier to be checked.</param>
        /// <returns>True if the config has the key.</returns>
        public static bool Contains(string key)
        {
            Init();
            return configs.ContainsKey(key);
        }

        /// <summary>
        /// Check if the specified key's value is the specified value.
        /// </summary>
        /// <param name="key">The identifier to be searched.</param>
        /// <param name="value">The value to be compared.</param>
        /// <returns>True if the found key's value is equal to the value specified.</returns>
        public static bool Equals(string key, string value)
        {
            Init();
            return configs.ContainsKey(key) ? configs[key] == value : false;
        }

    }
}
