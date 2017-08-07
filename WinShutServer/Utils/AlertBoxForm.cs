using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinShutServer.Utils
{
    public partial class AlertBoxForm : Form
    {

        private int timeout = 0;
        private int startTime = 0;

        public AlertBoxForm(string title, string content, int timeout)
        {
            InitializeComponent();
            l_title.Text = title;
            l_content.Text = content;
            Text = title;
            this.timeout = timeout;
            
        }

        public AlertBoxForm(string title, string content) : this(title, content, -1)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(timeout <= 0)
            {
                Close();
                return;
            }
            int sub = Environment.TickCount - startTime;
            timeout -= sub <= 0 ? 1 : sub;
            startTime = Environment.TickCount;

            int remain = (timeout / 1000) + 1;
            b_ok.Text = "OK (" + remain + ")";
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            timer.Stop();
            base.OnClosing(e);
        }

        private void AlertBoxForm_Load(object sender, EventArgs e)
        {
            if (this.timeout > -1)
            {
                timer.Interval = timeout >= 250 ? 250 : timeout;
                startTime = Environment.TickCount;
                timer.Start();
            }
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
