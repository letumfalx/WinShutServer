using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinShutServer.Utils
{
    public static class AlertBox
    {

        /// <summary>
        /// The storage for the active AlertBoxForm.
        /// </summary>
        private static AlertBoxForm theBox = null;

        /// <summary>
        /// The thread where the active AlertBoxForm will run or is running.
        /// </summary>
        private static System.Threading.Thread th = null;

        /// <summary>
        /// Create a new AlertBoxForm with specified title and content.
        /// </summary>
        /// <param name="title">The title of the AlertBox.</param>
        /// <param name="content">The content of the AlertBox.</param>
        public static void Show(string title, string content)
        {
            Close();
            th = new System.Threading.Thread(() =>
            {
                theBox = new AlertBoxForm(title, content);
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.Run(theBox);
            });
            th.Start();
        }

        /// <summary>
        /// Create a new AlertBoxForm with specified title, content and timeout.
        /// </summary>
        /// <param name="title">The title of the AlertBox.</param>
        /// <param name="content">The content of the AlertBox.</param>
        /// <param name="timeout">The time in milliseconds before the AlertBox closes automatically.</param>
        public static void Show(string title, string content, int timeout)
        {
            Close();
            th = new System.Threading.Thread(() =>
            {
                theBox = new AlertBoxForm(title, content, timeout);
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.Run(theBox);
            });
            th.Start();
        }

        /// <summary>
        /// Closes the active alert box and stops its UI thread.
        /// </summary>
        public static void Close()
        {
            if (theBox != null)
            {
                if(theBox.InvokeRequired)
                {
                    theBox.Invoke(new Action(() => 
                    {
                        theBox.Close();
                        theBox = null;
                    }));
                }
                else
                {
                    theBox.Close();
                    theBox = null;
                }
                
            }

            if (th != null ? th.IsAlive : false) th.Abort();
        }

    }
}
