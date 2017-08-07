namespace WinShutServer
{
    partial class ConnectionFrame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.l_server = new System.Windows.Forms.Label();
            this.l_broadcast = new System.Windows.Forms.Label();
            this.t_server = new System.Windows.Forms.Label();
            this.t_broadcast = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gp_status = new System.Windows.Forms.GroupBox();
            this.gp_local = new System.Windows.Forms.GroupBox();
            this.t_portbc = new System.Windows.Forms.Label();
            this.t_portctrl = new System.Windows.Forms.Label();
            this.t_localhostname = new System.Windows.Forms.Label();
            this.t_localip = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gp_remote = new System.Windows.Forms.GroupBox();
            this.t_remoteport = new System.Windows.Forms.Label();
            this.t_remotehostname = new System.Windows.Forms.Label();
            this.t_remoteip = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gp_broadcast = new System.Windows.Forms.GroupBox();
            this.b_bc_stop = new System.Windows.Forms.Button();
            this.b_bc_start = new System.Windows.Forms.Button();
            this.gp_control = new System.Windows.Forms.GroupBox();
            this.b_disconnect = new System.Windows.Forms.Button();
            this.b_ctrl_stop = new System.Windows.Forms.Button();
            this.b_ctrl_start = new System.Windows.Forms.Button();
            this.b_close = new System.Windows.Forms.Button();
            this.gp_status.SuspendLayout();
            this.gp_local.SuspendLayout();
            this.gp_remote.SuspendLayout();
            this.gp_broadcast.SuspendLayout();
            this.gp_control.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_server
            // 
            this.l_server.AutoSize = true;
            this.l_server.Location = new System.Drawing.Point(22, 26);
            this.l_server.Name = "l_server";
            this.l_server.Size = new System.Drawing.Size(49, 15);
            this.l_server.TabIndex = 0;
            this.l_server.Text = "Control:";
            // 
            // l_broadcast
            // 
            this.l_broadcast.AutoSize = true;
            this.l_broadcast.Location = new System.Drawing.Point(6, 46);
            this.l_broadcast.Name = "l_broadcast";
            this.l_broadcast.Size = new System.Drawing.Size(65, 15);
            this.l_broadcast.TabIndex = 1;
            this.l_broadcast.Text = "Broadcast:";
            // 
            // t_server
            // 
            this.t_server.AutoSize = true;
            this.t_server.ForeColor = System.Drawing.Color.Red;
            this.t_server.Location = new System.Drawing.Point(79, 26);
            this.t_server.Name = "t_server";
            this.t_server.Size = new System.Drawing.Size(39, 15);
            this.t_server.TabIndex = 2;
            this.t_server.Text = "Down";
            // 
            // t_broadcast
            // 
            this.t_broadcast.AutoSize = true;
            this.t_broadcast.ForeColor = System.Drawing.Color.Red;
            this.t_broadcast.Location = new System.Drawing.Point(80, 46);
            this.t_broadcast.Name = "t_broadcast";
            this.t_broadcast.Size = new System.Drawing.Size(39, 15);
            this.t_broadcast.TabIndex = 3;
            this.t_broadcast.Text = "Down";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Control Port:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Broadcast Port:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "IP Address:";
            // 
            // gp_status
            // 
            this.gp_status.Controls.Add(this.l_server);
            this.gp_status.Controls.Add(this.l_broadcast);
            this.gp_status.Controls.Add(this.t_server);
            this.gp_status.Controls.Add(this.t_broadcast);
            this.gp_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_status.Location = new System.Drawing.Point(13, 4);
            this.gp_status.Name = "gp_status";
            this.gp_status.Size = new System.Drawing.Size(246, 76);
            this.gp_status.TabIndex = 12;
            this.gp_status.TabStop = false;
            this.gp_status.Text = "Status";
            // 
            // gp_local
            // 
            this.gp_local.Controls.Add(this.t_portbc);
            this.gp_local.Controls.Add(this.t_portctrl);
            this.gp_local.Controls.Add(this.t_localhostname);
            this.gp_local.Controls.Add(this.t_localip);
            this.gp_local.Controls.Add(this.label2);
            this.gp_local.Controls.Add(this.label1);
            this.gp_local.Controls.Add(this.label6);
            this.gp_local.Controls.Add(this.label7);
            this.gp_local.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_local.Location = new System.Drawing.Point(12, 81);
            this.gp_local.Name = "gp_local";
            this.gp_local.Size = new System.Drawing.Size(246, 116);
            this.gp_local.TabIndex = 13;
            this.gp_local.TabStop = false;
            this.gp_local.Text = "Local Endpoint";
            // 
            // t_portbc
            // 
            this.t_portbc.AutoSize = true;
            this.t_portbc.Location = new System.Drawing.Point(105, 91);
            this.t_portbc.Name = "t_portbc";
            this.t_portbc.Size = new System.Drawing.Size(42, 15);
            this.t_portbc.TabIndex = 11;
            this.t_portbc.Text = "12206";
            // 
            // t_portctrl
            // 
            this.t_portctrl.AutoSize = true;
            this.t_portctrl.Location = new System.Drawing.Point(105, 67);
            this.t_portctrl.Name = "t_portctrl";
            this.t_portctrl.Size = new System.Drawing.Size(42, 15);
            this.t_portctrl.TabIndex = 10;
            this.t_portctrl.Text = "12207";
            // 
            // t_localhostname
            // 
            this.t_localhostname.AutoSize = true;
            this.t_localhostname.Location = new System.Drawing.Point(105, 41);
            this.t_localhostname.Name = "t_localhostname";
            this.t_localhostname.Size = new System.Drawing.Size(56, 15);
            this.t_localhostname.TabIndex = 9;
            this.t_localhostname.Text = "localhost";
            // 
            // t_localip
            // 
            this.t_localip.AutoSize = true;
            this.t_localip.Location = new System.Drawing.Point(105, 19);
            this.t_localip.Name = "t_localip";
            this.t_localip.Size = new System.Drawing.Size(58, 15);
            this.t_localip.TabIndex = 8;
            this.t_localip.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hostname:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // gp_remote
            // 
            this.gp_remote.Controls.Add(this.t_remoteport);
            this.gp_remote.Controls.Add(this.t_remotehostname);
            this.gp_remote.Controls.Add(this.t_remoteip);
            this.gp_remote.Controls.Add(this.label4);
            this.gp_remote.Controls.Add(this.label3);
            this.gp_remote.Controls.Add(this.label8);
            this.gp_remote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_remote.Location = new System.Drawing.Point(12, 197);
            this.gp_remote.Name = "gp_remote";
            this.gp_remote.Size = new System.Drawing.Size(246, 93);
            this.gp_remote.TabIndex = 14;
            this.gp_remote.TabStop = false;
            this.gp_remote.Text = "Remote Endpoint";
            // 
            // t_remoteport
            // 
            this.t_remoteport.AutoSize = true;
            this.t_remoteport.Location = new System.Drawing.Point(94, 67);
            this.t_remoteport.Name = "t_remoteport";
            this.t_remoteport.Size = new System.Drawing.Size(42, 15);
            this.t_remoteport.TabIndex = 13;
            this.t_remoteport.Text = "49999";
            // 
            // t_remotehostname
            // 
            this.t_remotehostname.AutoSize = true;
            this.t_remotehostname.Location = new System.Drawing.Point(91, 45);
            this.t_remotehostname.Name = "t_remotehostname";
            this.t_remotehostname.Size = new System.Drawing.Size(56, 15);
            this.t_remotehostname.TabIndex = 12;
            this.t_remotehostname.Text = "localhost";
            // 
            // t_remoteip
            // 
            this.t_remoteip.AutoSize = true;
            this.t_remoteip.Location = new System.Drawing.Point(88, 23);
            this.t_remoteip.Name = "t_remoteip";
            this.t_remoteip.Size = new System.Drawing.Size(58, 15);
            this.t_remoteip.TabIndex = 11;
            this.t_remoteip.Text = "127.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Client Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hostname:";
            // 
            // gp_broadcast
            // 
            this.gp_broadcast.Controls.Add(this.b_bc_stop);
            this.gp_broadcast.Controls.Add(this.b_bc_start);
            this.gp_broadcast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_broadcast.Location = new System.Drawing.Point(12, 291);
            this.gp_broadcast.Name = "gp_broadcast";
            this.gp_broadcast.Size = new System.Drawing.Size(246, 54);
            this.gp_broadcast.TabIndex = 15;
            this.gp_broadcast.TabStop = false;
            this.gp_broadcast.Text = "Broadcast";
            // 
            // b_bc_stop
            // 
            this.b_bc_stop.Location = new System.Drawing.Point(125, 20);
            this.b_bc_stop.Name = "b_bc_stop";
            this.b_bc_stop.Size = new System.Drawing.Size(75, 23);
            this.b_bc_stop.TabIndex = 2;
            this.b_bc_stop.Text = "Stop";
            this.b_bc_stop.UseVisualStyleBackColor = true;
            this.b_bc_stop.Click += new System.EventHandler(this.b_bc_stop_Click);
            // 
            // b_bc_start
            // 
            this.b_bc_start.Location = new System.Drawing.Point(44, 20);
            this.b_bc_start.Name = "b_bc_start";
            this.b_bc_start.Size = new System.Drawing.Size(75, 23);
            this.b_bc_start.TabIndex = 1;
            this.b_bc_start.Text = "Start";
            this.b_bc_start.UseVisualStyleBackColor = true;
            this.b_bc_start.Click += new System.EventHandler(this.b_bc_start_Click);
            // 
            // gp_control
            // 
            this.gp_control.Controls.Add(this.b_disconnect);
            this.gp_control.Controls.Add(this.b_ctrl_stop);
            this.gp_control.Controls.Add(this.b_ctrl_start);
            this.gp_control.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gp_control.Location = new System.Drawing.Point(13, 345);
            this.gp_control.Name = "gp_control";
            this.gp_control.Size = new System.Drawing.Size(245, 52);
            this.gp_control.TabIndex = 16;
            this.gp_control.TabStop = false;
            this.gp_control.Text = "Control Server";
            // 
            // b_disconnect
            // 
            this.b_disconnect.Location = new System.Drawing.Point(157, 21);
            this.b_disconnect.Name = "b_disconnect";
            this.b_disconnect.Size = new System.Drawing.Size(82, 23);
            this.b_disconnect.TabIndex = 3;
            this.b_disconnect.Text = "Disconnect";
            this.b_disconnect.UseVisualStyleBackColor = true;
            this.b_disconnect.Click += new System.EventHandler(this.b_disconnect_Click);
            // 
            // b_ctrl_stop
            // 
            this.b_ctrl_stop.Location = new System.Drawing.Point(82, 21);
            this.b_ctrl_stop.Name = "b_ctrl_stop";
            this.b_ctrl_stop.Size = new System.Drawing.Size(75, 23);
            this.b_ctrl_stop.TabIndex = 2;
            this.b_ctrl_stop.Text = "Stop";
            this.b_ctrl_stop.UseVisualStyleBackColor = true;
            this.b_ctrl_stop.Click += new System.EventHandler(this.b_ctrl_stop_Click);
            // 
            // b_ctrl_start
            // 
            this.b_ctrl_start.Location = new System.Drawing.Point(6, 21);
            this.b_ctrl_start.Name = "b_ctrl_start";
            this.b_ctrl_start.Size = new System.Drawing.Size(75, 23);
            this.b_ctrl_start.TabIndex = 1;
            this.b_ctrl_start.Text = "Start";
            this.b_ctrl_start.UseVisualStyleBackColor = true;
            this.b_ctrl_start.Click += new System.EventHandler(this.b_ctrl_start_Click);
            // 
            // b_close
            // 
            this.b_close.Location = new System.Drawing.Point(177, 403);
            this.b_close.Name = "b_close";
            this.b_close.Size = new System.Drawing.Size(75, 23);
            this.b_close.TabIndex = 4;
            this.b_close.Text = "Close";
            this.b_close.UseVisualStyleBackColor = true;
            this.b_close.Click += new System.EventHandler(this.b_close_Click);
            // 
            // ConnectionFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 435);
            this.Controls.Add(this.b_close);
            this.Controls.Add(this.gp_control);
            this.Controls.Add(this.gp_broadcast);
            this.Controls.Add(this.gp_remote);
            this.Controls.Add(this.gp_local);
            this.Controls.Add(this.gp_status);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionFrame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Connection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionFrame_FormClosing);
            this.Load += new System.EventHandler(this.ConnectionFrame_Load);
            this.gp_status.ResumeLayout(false);
            this.gp_status.PerformLayout();
            this.gp_local.ResumeLayout(false);
            this.gp_local.PerformLayout();
            this.gp_remote.ResumeLayout(false);
            this.gp_remote.PerformLayout();
            this.gp_broadcast.ResumeLayout(false);
            this.gp_control.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l_server;
        private System.Windows.Forms.Label l_broadcast;
        private System.Windows.Forms.Label t_server;
        private System.Windows.Forms.Label t_broadcast;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gp_status;
        private System.Windows.Forms.GroupBox gp_local;
        private System.Windows.Forms.GroupBox gp_remote;
        private System.Windows.Forms.Label t_portbc;
        private System.Windows.Forms.Label t_portctrl;
        private System.Windows.Forms.Label t_localhostname;
        private System.Windows.Forms.Label t_localip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label t_remoteport;
        private System.Windows.Forms.Label t_remotehostname;
        private System.Windows.Forms.Label t_remoteip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gp_broadcast;
        private System.Windows.Forms.Button b_bc_stop;
        private System.Windows.Forms.Button b_bc_start;
        private System.Windows.Forms.GroupBox gp_control;
        private System.Windows.Forms.Button b_ctrl_stop;
        private System.Windows.Forms.Button b_ctrl_start;
        private System.Windows.Forms.Button b_disconnect;
        private System.Windows.Forms.Button b_close;
    }
}