using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinShutServer
{
    public partial class ConfigFrame : Form
    {
        public ConfigFrame()
        {
            InitializeComponent();
        }

        private void ConfigFrame_Load(object sender, EventArgs e)
        {
            cb_alert.Checked = Utils.Config.Equals("alert", "1");
            cb_broadcast.Checked = Utils.Config.Equals("broadcast", "1");
            cb_server.Checked = Utils.Config.Equals("server", "1");
            cb_restart.Checked = Utils.Config.Equals("restart", "1");
            cb_startup.Checked = Utils.Config.Equals("startup", "1");

            r_always.Enabled = cb_restart.Checked;
            r_never.Enabled = cb_restart.Checked;
            r_sometimes.Enabled = cb_restart.Checked;

            switch(Utils.Config.Get("rebroadcast"))
            {
                case "0":
                    r_always.Checked = true;
                    break;
                case "1":
                    r_sometimes.Checked = true;
                    break;
                default:
                    r_never.Checked = true;
                    break;
            }
        }

        private void cb_server_CheckedChanged(object sender, EventArgs e)
        {
            cb_broadcast.Enabled = cb_server.Checked;
            if (!cb_server.Checked) cb_broadcast.Checked = false;
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void b_apply_Click(object sender, EventArgs e)
        {
            Utils.Config.Set("alert", cb_alert.Checked);
            Utils.Config.Set("broadcast", cb_broadcast.Checked);
            Utils.Config.Set("restart", cb_restart.Checked);
            Utils.Config.Set("server", cb_server.Checked);
            Utils.Config.Set("startup", cb_startup.Checked);

            int rebroadcast;
            if(r_always.Checked)
            {
                Utils.Config.Set("rebroadcast", "0");
                rebroadcast = 0;
            }
            else if (r_sometimes.Checked)
            {
                Utils.Config.Set("rebroadcast", "1");
                rebroadcast = 1;
            }
            else
            {
                Utils.Config.Set("rebroadcast", "2");
                rebroadcast = 2;
            }

            if (cb_startup.Checked) Utils.Startup.Set();
            else Utils.Startup.Remove();

            Program.main.UpdateConfig(
                cb_startup.Checked,
                cb_server.Checked,
                cb_broadcast.Checked,
                cb_restart.Checked,
                rebroadcast,
                cb_alert.Checked);
            Utils.Log.Write("Config has been updated.");
            MessageBox.Show("Successfully applied the configurations.");
        }

        private void cb_restart_CheckedChanged(object sender, EventArgs e)
        {
            r_always.Enabled = cb_restart.Checked;
            r_never.Enabled = cb_restart.Checked;
            r_sometimes.Enabled = cb_restart.Checked;
        }
    }
}
