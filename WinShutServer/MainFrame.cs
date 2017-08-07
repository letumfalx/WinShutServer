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
    public partial class MainFrame : Form
    {
        private bool shown = true;

        public new bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                if(value)
                {
                    Show();
                    mi_gui.Text = "Hide GUI";
                }
                else
                {
                    mi_gui.Text = "Show GUI";
                    Hide();
                }
            }
        }

        private bool closing = false;

        public MainFrame(bool show)
        {
            InitializeComponent();
            this.shown = show;
        }

        public void RunOnUIThread(Action func)
        {
            if(!IsDisposed)
            {
                if(InvokeRequired)
                {
                    Invoke(new Action(() => 
                    {
                        if(!IsDisposed)
                        {
                            func();
                        }
                    }));
                    return;
                }
                func();
            }
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

            Utils.Log.SetLogBox(tb_log);

            mi_startup.Checked = Utils.Config.IsSet("startup");
            mi_broadcast.Checked = Utils.Config.IsSet("broadcast");
            mi_restart.Checked = Utils.Config.IsSet("restart");
            mi_server.Checked = Utils.Config.IsSet("server");
            mi_alert.Checked = Utils.Config.IsSet("alert");

            mi_broadcast.Enabled = mi_server.Checked;

            mi_rebroadcast.Enabled = mi_restart.Checked;
            mi_always.Checked = Utils.Config.Equals("rebroadcast", "0");
            mi_sometimes.Checked = Utils.Config.Equals("rebroadcast", "1");
            mi_never.Checked = !mi_always.Checked && !mi_sometimes.Checked;

            mi_broadcast_start.Enabled = !Utils.Broadcast.Running;
            mi_broadcast_stop.Enabled = !mi_broadcast_start.Enabled;

            mi_server_start.Enabled = !Utils.Server.IsRunning;
            mi_server_stop.Enabled = !mi_server_start.Enabled;
            mi_server_disconnect.Enabled = mi_server_stop.Enabled && Utils.Server.IsConnected;


            //for sequence change events
            Utils.Sequence.SequenceChange += (Utils.SequenceChangeEventArgs args) => 
            {
                RunOnUIThread(() =>
                {
                    t_sequence.Text = args.Sequence.ToString();
                    t_type.Text = args.Type.ToString();
                    switch (args.Type)
                    {
                        case Utils.SequenceType.Fast:
                            t_time.Text = "Immediately";
                            break;
                        case Utils.SequenceType.Timed:
                            t_time.Text =
                                new Utils.MyDate(DateTime.Now.Ticks + args.Millis * 10000).GetString();
                            break;
                        case Utils.SequenceType.Scheduled:
                            t_time.Text = args.Date.GetString();
                            break;
                        default:
                            t_time.Text = "N/A";
                            break;
                    }
                    t_sequence.ForeColor = Utils.Sequence.GetColor(args.Sequence);
                });
            };

            Utils.Broadcast.OnStart += (Utils.ConnectionEventArgs args) => 
            {
                RunOnUIThread(() => 
                {
                    t_broadcast.Text = "Up";
                    t_broadcast.ForeColor = Color.Green;
                    mi_broadcast_start.Enabled = false;
                    mi_broadcast_stop.Enabled = true;
                });
            };

            Utils.Broadcast.OnError += (string message) =>
            {
                RunOnUIThread(() => 
                {
                    t_broadcast.Text = "Down";
                    t_broadcast.ForeColor = Color.Red;
                    mi_broadcast_start.Enabled = true;
                    mi_broadcast_stop.Enabled = false;
                });
            };

            Utils.Broadcast.OnStop += (Utils.ConnectionEventArgs args) => 
            {
                RunOnUIThread(() =>
                {
                    t_broadcast.Text = "Down";
                    t_broadcast.ForeColor = Color.Red;

                    mi_broadcast_start.Enabled = true;
                    mi_broadcast_stop.Enabled = false;
                });
            };

            Utils.Server.Connecting += (Utils.ConnectionEventArgs args) =>
            {
                RunOnUIThread(() =>
                {
                    t_server.Text = "Up";
                    t_server.ForeColor = Color.Green;
                    t_host.Text = "Waiting for connection";
                    t_host.ForeColor = Color.GreenYellow;

                    mi_server_start.Enabled = false;
                    mi_server_stop.Enabled = true;
                    mi_server_disconnect.Enabled = false;

                });
            };

            Utils.Server.Connected += (Utils.ConnectionEventArgs args) =>
            {
                Utils.Broadcast.Stop();
                RunOnUIThread(() => 
                {
                    t_server.Text = "Up";
                    t_server.ForeColor = Color.Green;
                    
                    int h = args.RemoteHostname.Length;
                    int i = args.RemoteIPEndPoint.Address.ToString().Length;
                    t_host.Text = i > h ? args.RemoteHostname 
                            : args.RemoteIPEndPoint.Address.ToString();
                    t_host.ForeColor = Color.Green;
                    
                    mi_server_start.Enabled = false;
                    mi_server_stop.Enabled = true;
                    mi_server_disconnect.Enabled = true;
                });
            };

            Utils.Server.Disconnect += (Utils.ConnectionEventArgs args) => 
            {
                RunOnUIThread(() => 
                {
                    t_server.Text = "Down";
                    t_server.ForeColor = Color.Red;
                    t_host.Text = "No Controller";
                    t_host.ForeColor = Color.Red;

                    mi_server_start.Enabled = true;
                    mi_server_stop.Enabled = false;
                    mi_server_disconnect.Enabled = false;
                });
            };

            Utils.Server.Error += (string message) =>
            {
                RunOnUIThread(() => 
                {
                    t_server.Text = "Down";
                    t_server.ForeColor = Color.Red;
                    t_host.Text = "No Controller";
                    t_host.ForeColor = Color.Red;

                    mi_server_start.Enabled = true;
                    mi_server_stop.Enabled = false;
                    mi_server_disconnect.Enabled = false;
                });
            };

            Utils.Server.OnStop += (Utils.ConnectionEventArgs args) =>
            {
                RunOnUIThread(() =>
                {
                    t_server.Text = "Down";
                    t_server.ForeColor = Color.Red;
                    t_host.Text = "No Controller";
                    t_host.ForeColor = Color.Red;

                    mi_server_start.Enabled = true;
                    mi_server_stop.Enabled = false;
                    mi_server_disconnect.Enabled = false;
                });
            };

            Utils.Server.DataReceived += (Utils.DataEventArgs args) => 
            {
                if(args.Data.Key.Trim().ToLower() != "sequence")
                {
                    return;
                }

                try
                {
                    int _seq = Convert.ToInt16(args.Data.Values[0]);
                    int _type = Convert.ToInt16(args.Data.Values[1]);
                    int _hr = 0;
                    int _min = 0;
                    int _sec = 0;
                    if (_type > (int)Utils.SequenceType.Fast)
                    {
                        _hr = Convert.ToInt16(args.Data.Values[2]);
                        _min = Convert.ToInt16(args.Data.Values[3]);
                        _sec = Convert.ToInt16(args.Data.Values[4]);
                    }
                    Utils.Sequence.Requested = true;
                    switch((Utils.SequenceType)_type)
                    {
                        case Utils.SequenceType.Fast:
                            Utils.Sequence.Set(_seq);
                            break;
                        case Utils.SequenceType.Timed:
                            Utils.Sequence.Set(_seq, _hr, _min, _sec);
                            break;
                        case Utils.SequenceType.Scheduled:
                            Utils.MyDate md = new Utils.MyDate(_hr, _min, _sec);
                            if(md.Ticks <= DateTime.Now.Ticks)
                            {
                                md = new Utils.MyDate(
                                        md.Year,
                                        md.Month,
                                        md.Day + 1,
                                        md.Hour,
                                        md.Minute,
                                        md.Second
                                        );
                            }
                            Utils.Sequence.Set(_seq, md);
                            break;
                    }
                }
                catch(ArgumentOutOfRangeException)
                {
                    Utils.Log.Write("A stray sequence data received.", Utils.Log.CONSOLE);
                    return;
                }
            };
            
            if(Utils.Config.IsSet("server"))
            {
                Utils.Server.Start();
                if(Utils.Config.IsSet("broadcast"))
                {
                    Utils.Broadcast.Start();
                }
            }
        }

        private void b_exit_Click(object sender, EventArgs e)
        {
            AskOnClose();
        }

        private void MainFrame_Shown(object sender, EventArgs e)
        {
            Visible = shown;
        }

        private void b_config_Click(object sender, EventArgs e)
        {
            new ConfigFrame().ShowDialog(this);
        }

        private void b_sequence_Click(object sender, EventArgs e)
        {
            new SequenceFrame().ShowDialog(this);
        }

        private void b_connection_Click(object sender, EventArgs e)
        {
            
            new ConnectionFrame().ShowDialog(this);
        }

        private void b_hide_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !closing;
            AskOnClose();
        }

        private void AskOnClose()
        {
            if (!closing)
            {
                DialogResult dr = MessageBox.Show(
                    "Do you really want to exit?"
                    + Environment.NewLine + "All sequence set will be canceled.",
                    "Warning!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                    );
                if (dr == DialogResult.Yes)
                {
                    closing = true;
                    Program.Exit();
                }
            }
        }

        private void mi_gui_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
        }

        private void mi_exit_Click(object sender, EventArgs e)
        {
            AskOnClose();
        }

        private void mi_sequence_Click(object sender, EventArgs e)
        {
            b_sequence_Click(sender, e);
        }

        private void mi_connection_Click(object sender, EventArgs e)
        {
            b_connection_Click(sender, e);
        }

        private void mi_config_Click(object sender, EventArgs e)
        {
            b_config_Click(sender, e);
        }

        private void mi_startup_Click(object sender, EventArgs e)
        {
            mi_startup.Checked = !mi_startup.Checked;
            Utils.Config.Set("startup", mi_startup.Checked);
            if(mi_startup.Checked)
            {
                Utils.Startup.Set();
            }
            else
            {
                Utils.Startup.Remove();
            }
        }

        private void mi_server_Click(object sender, EventArgs e)
        {
            mi_server.Checked = !mi_server.Checked;
            Utils.Config.Set("server", mi_server.Checked);
            mi_broadcast.Enabled = mi_server.Checked;
            if (!mi_server.Checked)
            {
                mi_broadcast.Checked = false;
                Utils.Config.Set("broadcast", false);
            }
        }

        private void mi_broadcast_Click(object sender, EventArgs e)
        {
            mi_broadcast.Checked = !mi_broadcast.Checked;
            Utils.Config.Set("broadcast", mi_broadcast.Checked);
        }

        private void mi_alert_Click(object sender, EventArgs e)
        {
            mi_alert.Checked = !mi_alert.Checked;
            Utils.Config.Set("alert", mi_alert.Checked);
        }

        internal void UpdateConfig(
            bool startup,
            bool server,
            bool broadcast,
            bool restart,
            int rebroadcast,
            bool alert   
        ){
            mi_startup.Checked = startup;
            mi_server.Checked = server;
            mi_broadcast.Checked = broadcast;
            mi_restart.Checked = restart;
            mi_alert.Checked = alert;

            mi_always.Checked = false;
            mi_sometimes.Checked = false;
            mi_never.Checked = false;
            switch (rebroadcast)
            {
                case 0:
                    mi_always.Checked = true;
                    break;
                case 1:
                    mi_sometimes.Checked = true;
                    break;
                default:
                    mi_never.Checked = true;
                    break;
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Visible = !Visible;
            }
        }

        private void mi_restart_Click(object sender, EventArgs e)
        {
            mi_restart.Checked = !mi_restart.Checked;
            mi_rebroadcast.Enabled = mi_restart.Checked;
            Utils.Config.Set("restart", mi_restart.Checked);
            
        }

        private void mi_always_Click(object sender, EventArgs e)
        {
            mi_always.Checked = true;
            mi_sometimes.Checked = false;
            mi_never.Checked = false;

            Utils.Config.Set("rebroadcast", "0");

        }

        private void mi_sometimes_Click(object sender, EventArgs e)
        {
            mi_always.Checked = false;
            mi_sometimes.Checked = true;
            mi_never.Checked = false;

            Utils.Config.Set("rebroadcast", "1");
        }

        private void mi_never_Click(object sender, EventArgs e)
        {
            mi_always.Checked = false;
            mi_sometimes.Checked = false;
            mi_never.Checked = true;

            Utils.Config.Set("rebroadcast", "2");
        }

        private void mi_server_start_Click(object sender, EventArgs e)
        {
            Utils.Server.Start();
        }

        private void mi_server_stop_Click(object sender, EventArgs e)
        {
            Utils.Server.Stop();
            if(Utils.Broadcast.Running) Utils.Broadcast.Stop();
        }

        private void mi_server_disconnect_Click(object sender, EventArgs e)
        {
            Utils.Server.Disconnection = true;
        }

        private void mi_broadcast_start_Click(object sender, EventArgs e)
        {
            Utils.Broadcast.Start();
            if (!Utils.Server.IsRunning) Utils.Server.Start();
        }

        private void mi_broadcast_stop_Click(object sender, EventArgs e)
        {
            Utils.Broadcast.Stop();
        }
    }
}
