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
    public partial class ConnectionFrame : Form
    {
        public ConnectionFrame()
        {
            InitializeComponent();
        }

        public void RunOnUIThread(Action func)
        {
            if (!IsDisposed)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        if (!IsDisposed)
                        {
                            func();
                        }
                    }));
                    return;
                }
                func();
            }
        }

        private void ConnectionFrame_Load(object sender, EventArgs e)
        {
            t_broadcast.Text = Utils.Broadcast.Running ? "Up" : "Down";
            t_broadcast.ForeColor = Utils.Broadcast.Running ? Color.Green : Color.Red;

            if(Utils.Server.IsRunning)
            {
                if(Utils.Server.IsConnected)
                {
                    t_server.Text = "Connected";
                    t_server.ForeColor = Color.LawnGreen;
                }
                else
                {
                    t_server.Text = "Up";
                    t_server.ForeColor = Color.Green;
                }
            }
            else
            {
                t_server.Text = "Down";
                t_server.ForeColor = Color.Red;
            }

            t_localip.Text = Utils.Globals.IpAddress;
            t_localhostname.Text = Utils.Globals.Hostname;
            t_portbc.Text = Utils.Broadcast.Port.ToString();
            t_portctrl.Text = Utils.Server.Port.ToString();

            if(Utils.Server.ClientEndpoint != null)
            {
                System.Net.IPEndPoint addr = (Utils.Server.ClientEndpoint as System.Net.IPEndPoint);
                if(addr != null)
                {
                    t_remoteip.Text = addr.Address.ToString();
                    t_remoteport.Text = addr.Port.ToString();
                    t_remotehostname.Text = System.Net.Dns.GetHostEntry(addr.Address)?.HostName;
                }
                else
                {
                    t_remoteip.Text = "N/A";
                    t_remoteport.Text = "N/A";
                    t_remotehostname.Text = "N/A";
                }
            }
            else
            {
                t_remoteip.Text = "N/A";
                t_remoteport.Text = "N/A";
                t_remotehostname.Text = "N/A";
            }

            b_bc_start.Enabled = !Utils.Broadcast.Running;
            b_bc_stop.Enabled = Utils.Broadcast.Running;

            b_ctrl_start.Enabled = !Utils.Server.IsRunning;
            b_ctrl_stop.Enabled = Utils.Server.IsRunning;
            b_disconnect.Enabled = Utils.Server.IsConnected;

            Utils.Server.Connecting += OnConnecting;
            Utils.Server.Connected += OnConnected;
            Utils.Server.Disconnect += OnDisconnect;
            Utils.Server.OnStop += OnStop;
            Utils.Server.Error += OnError;

            Utils.Broadcast.OnStart += OnBroadcastStart;
            Utils.Broadcast.OnStop += OnBroadcastStop;
            Utils.Broadcast.OnError += OnError;

        }

        private void OnConnecting(Utils.ConnectionEventArgs args)
        {
            RunOnUIThread(() => 
            {
                t_localip.Text = Utils.Globals.IpAddress;
                t_localhostname.Text = Utils.Globals.Hostname;
                t_server.Text = "Up";
                t_server.ForeColor = Color.Green;

                b_ctrl_start.Enabled = false;
                b_ctrl_stop.Enabled = true;
                b_disconnect.Enabled = false;
            });
        }

        private void OnConnected(Utils.ConnectionEventArgs args)
        {
            RunOnUIThread(() =>
            {
                t_remotehostname.Text = args.RemoteHostname;
                t_remoteip.Text = args.RemoteIPEndPoint.Address.ToString();
                t_remoteport.Text = args.RemoteIPEndPoint.Port.ToString();

                t_server.Text = "Connected";
                t_server.ForeColor = Color.LawnGreen;

                b_ctrl_start.Enabled = false;
                b_ctrl_stop.Enabled = true;
                b_disconnect.Enabled = true;

            });
        }

        private void OnDisconnect(Utils.ConnectionEventArgs args)
        {
            RunOnUIThread(() =>
            {
                t_remoteip.Text = "N/A";
                t_remoteport.Text = "N/A";
                t_remotehostname.Text = "N/A";
                b_ctrl_start.Enabled = true;
                b_ctrl_stop.Enabled = false;
                b_disconnect.Enabled = false;
            });
        }

        private void OnStop(Utils.ConnectionEventArgs args)
        {
            RunOnUIThread(() =>
            {
                t_remoteip.Text = "N/A";
                t_remoteport.Text = "N/A";
                t_remotehostname.Text = "N/A";

                t_server.Text = "Down";
                t_server.ForeColor = Color.Red;

                b_ctrl_start.Enabled = true;
                b_ctrl_stop.Enabled = false;
                b_disconnect.Enabled = false;
            });
        }

        private void OnError(string message)
        {
            OnStop(null);
        }

        private void OnBroadcastStart(Utils.ConnectionEventArgs args)
        {
            RunOnUIThread(() => 
            {
                t_localip.Text = Utils.Globals.IpAddress;
                t_localhostname.Text = Utils.Globals.Hostname;
                b_bc_start.Enabled = false;
                b_bc_stop.Enabled = true;
                t_broadcast.Text = "Up";
                t_broadcast.ForeColor = Color.Green;
            });
        }

        private void OnBroadcastStop(Utils.ConnectionEventArgs args)
        {
            RunOnUIThread(() =>
            {
                b_bc_start.Enabled = true;
                b_bc_stop.Enabled = false;
                t_broadcast.Text = "Down";
                t_broadcast.ForeColor = Color.Red;
            });
        }
        private void OnBroadcastError(string args)
        {
            OnBroadcastStop(null);
        }

        private void ConnectionFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.Server.Connecting -= OnConnecting;
            Utils.Server.Connected -= OnConnected;
            Utils.Server.Disconnect -= OnDisconnect;
            Utils.Server.OnStop -= OnStop;
            Utils.Server.Error -= OnError;

            Utils.Broadcast.OnStart -= OnBroadcastStart;
            Utils.Broadcast.OnStop -= OnBroadcastStop;
            Utils.Broadcast.OnError -= OnBroadcastError;

        }

        

        private void b_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void b_ctrl_start_Click(object sender, EventArgs e)
        {
            Utils.Server.Start();
        }

        private void b_ctrl_stop_Click(object sender, EventArgs e)
        {
            Utils.Server.Stop();
            if (Utils.Broadcast.Running) Utils.Broadcast.Stop();
        }

        private void b_bc_start_Click(object sender, EventArgs e)
        {
            if(!Utils.Server.IsConnected)
            {
                Utils.Broadcast.Start();
                if (!Utils.Server.IsRunning) Utils.Server.Start();
            }
            else
            {
                Utils.AlertBox.Show("Broadcast Error!", "Control server is already bound.", 15000);
            }
        }

        private void b_bc_stop_Click(object sender, EventArgs e)
        {
            Utils.Broadcast.Stop();
        }

        private void b_disconnect_Click(object sender, EventArgs e)
        {
            Utils.Server.Disconnection = true;
        }
    }
}
