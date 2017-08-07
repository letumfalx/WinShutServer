using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinShutServer
{
    class Program
    {

        internal static MainFrame main;

        static void Main(string[] args)
        {
            Utils.Config.Init();
            Application.EnableVisualStyles();
            main = new MainFrame(!Utils.Config.Equals("startup", "1"));
            Application.Run(main);
        }

        internal static void Exit()
        {
            Utils.AlertBox.Close();
            main.Close();
            Utils.Broadcast.Dispose();
            Utils.Server.Dispose();
        }
    }
}
