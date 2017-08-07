using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShutServer.Utils
{
    static class Startup
    {

        /// <summary>
        /// Stores the path of the executable.
        /// </summary>
        private static string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

        /// <summary>
        /// Stores the name of the executable.
        /// </summary>
        private static string appName = "WinShutServer";

        /// <summary>
        /// Gets the current status of the executable to the windows startup.
        /// </summary>
        public static bool IsOnStartup
        {
            get
            {
                try
                {
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    string key = rk.GetValue(appName).ToString();
                    if(key == null)
                    {
                        return false;
                    }
                    return true;
                } catch(Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Adds the executable to window startup.
        /// </summary>
        /// <returns>True if successfully added to startup.</returns>
        public static bool Set()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            try
            {
                rk.SetValue(appName, "\"" + path + "\"");
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Removes the executable to the windows startup
        /// </summary>
        /// <returns>True if successful.</returns>
        public static bool Remove()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            try
            {
                rk.DeleteValue(appName, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        

    }
}
