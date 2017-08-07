namespace WinShutServer
{
    partial class MainFrame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
            this.l_title = new System.Windows.Forms.Label();
            this.i_title = new System.Windows.Forms.Panel();
            this.b_config = new System.Windows.Forms.Button();
            this.b_sequence = new System.Windows.Forms.Button();
            this.b_connection = new System.Windows.Forms.Button();
            this.b_hide = new System.Windows.Forms.Button();
            this.b_exit = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.RichTextBox();
            this.gb_sequence = new System.Windows.Forms.GroupBox();
            this.t_time = new System.Windows.Forms.Label();
            this.l_time = new System.Windows.Forms.Label();
            this.t_type = new System.Windows.Forms.Label();
            this.l_type = new System.Windows.Forms.Label();
            this.t_sequence = new System.Windows.Forms.Label();
            this.l_seq = new System.Windows.Forms.Label();
            this.gb_controller = new System.Windows.Forms.GroupBox();
            this.t_host = new System.Windows.Forms.Label();
            this.t_broadcast = new System.Windows.Forms.Label();
            this.l_broadcast = new System.Windows.Forms.Label();
            this.t_server = new System.Windows.Forms.Label();
            this.l_server = new System.Windows.Forms.Label();
            this.l_host = new System.Windows.Forms.Label();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mi_gui = new System.Windows.Forms.ToolStripMenuItem();
            this.sep0 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_config = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_startup = new System.Windows.Forms.ToolStripMenuItem();
            this.sep02 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_server = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_broadcast = new System.Windows.Forms.ToolStripMenuItem();
            this.sep03 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_restart = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_rebroadcast = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_always = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_sometimes = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_never = new System.Windows.Forms.ToolStripMenuItem();
            this.sep04 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_alert = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_sequence = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_connection = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_server_start = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_server_stop = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_server_disconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.sep005 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_broadcast_start = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_broadcast_stop = new System.Windows.Forms.ToolStripMenuItem();
            this.sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_sequence.SuspendLayout();
            this.gb_controller.SuspendLayout();
            this.trayIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.Location = new System.Drawing.Point(150, 15);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(129, 20);
            this.l_title.TabIndex = 0;
            this.l_title.Text = "WinShutServer";
            // 
            // i_title
            // 
            this.i_title.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("i_title.BackgroundImage")));
            this.i_title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.i_title.Location = new System.Drawing.Point(108, 9);
            this.i_title.Name = "i_title";
            this.i_title.Size = new System.Drawing.Size(33, 31);
            this.i_title.TabIndex = 1;
            // 
            // b_config
            // 
            this.b_config.Location = new System.Drawing.Point(248, 53);
            this.b_config.Name = "b_config";
            this.b_config.Size = new System.Drawing.Size(124, 23);
            this.b_config.TabIndex = 2;
            this.b_config.Text = "Configuration";
            this.b_config.UseVisualStyleBackColor = true;
            this.b_config.Click += new System.EventHandler(this.b_config_Click);
            // 
            // b_sequence
            // 
            this.b_sequence.Location = new System.Drawing.Point(248, 84);
            this.b_sequence.Name = "b_sequence";
            this.b_sequence.Size = new System.Drawing.Size(124, 23);
            this.b_sequence.TabIndex = 3;
            this.b_sequence.Text = "Set Sequence";
            this.b_sequence.UseVisualStyleBackColor = true;
            this.b_sequence.Click += new System.EventHandler(this.b_sequence_Click);
            // 
            // b_connection
            // 
            this.b_connection.Location = new System.Drawing.Point(248, 116);
            this.b_connection.Name = "b_connection";
            this.b_connection.Size = new System.Drawing.Size(124, 23);
            this.b_connection.TabIndex = 4;
            this.b_connection.Text = "Manage Connection";
            this.b_connection.UseVisualStyleBackColor = true;
            this.b_connection.Click += new System.EventHandler(this.b_connection_Click);
            // 
            // b_hide
            // 
            this.b_hide.Location = new System.Drawing.Point(248, 149);
            this.b_hide.Name = "b_hide";
            this.b_hide.Size = new System.Drawing.Size(124, 23);
            this.b_hide.TabIndex = 5;
            this.b_hide.Text = "Hide";
            this.b_hide.UseVisualStyleBackColor = true;
            this.b_hide.Click += new System.EventHandler(this.b_hide_Click);
            // 
            // b_exit
            // 
            this.b_exit.Location = new System.Drawing.Point(248, 181);
            this.b_exit.Name = "b_exit";
            this.b_exit.Size = new System.Drawing.Size(124, 23);
            this.b_exit.TabIndex = 6;
            this.b_exit.Text = "Exit";
            this.b_exit.UseVisualStyleBackColor = true;
            this.b_exit.Click += new System.EventHandler(this.b_exit_Click);
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(13, 210);
            this.tb_log.Name = "tb_log";
            this.tb_log.ReadOnly = true;
            this.tb_log.Size = new System.Drawing.Size(359, 139);
            this.tb_log.TabIndex = 7;
            this.tb_log.TabStop = false;
            this.tb_log.Text = "";
            // 
            // gb_sequence
            // 
            this.gb_sequence.Controls.Add(this.t_time);
            this.gb_sequence.Controls.Add(this.l_time);
            this.gb_sequence.Controls.Add(this.t_type);
            this.gb_sequence.Controls.Add(this.l_type);
            this.gb_sequence.Controls.Add(this.t_sequence);
            this.gb_sequence.Controls.Add(this.l_seq);
            this.gb_sequence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_sequence.Location = new System.Drawing.Point(13, 46);
            this.gb_sequence.Name = "gb_sequence";
            this.gb_sequence.Size = new System.Drawing.Size(229, 87);
            this.gb_sequence.TabIndex = 8;
            this.gb_sequence.TabStop = false;
            this.gb_sequence.Text = "Sequence Status";
            // 
            // t_time
            // 
            this.t_time.AutoSize = true;
            this.t_time.Location = new System.Drawing.Point(85, 63);
            this.t_time.Name = "t_time";
            this.t_time.Size = new System.Drawing.Size(26, 15);
            this.t_time.TabIndex = 5;
            this.t_time.Text = "N/A";
            // 
            // l_time
            // 
            this.l_time.AutoSize = true;
            this.l_time.Location = new System.Drawing.Point(12, 63);
            this.l_time.Name = "l_time";
            this.l_time.Size = new System.Drawing.Size(67, 15);
            this.l_time.TabIndex = 4;
            this.l_time.Text = "Execute at:";
            // 
            // t_type
            // 
            this.t_type.AutoSize = true;
            this.t_type.Location = new System.Drawing.Point(85, 44);
            this.t_type.Name = "t_type";
            this.t_type.Size = new System.Drawing.Size(37, 15);
            this.t_type.TabIndex = 3;
            this.t_type.Text = "None";
            // 
            // l_type
            // 
            this.l_type.AutoSize = true;
            this.l_type.Location = new System.Drawing.Point(43, 44);
            this.l_type.Name = "l_type";
            this.l_type.Size = new System.Drawing.Size(36, 15);
            this.l_type.TabIndex = 2;
            this.l_type.Text = "Type:";
            // 
            // t_sequence
            // 
            this.t_sequence.AutoSize = true;
            this.t_sequence.Location = new System.Drawing.Point(84, 23);
            this.t_sequence.Name = "t_sequence";
            this.t_sequence.Size = new System.Drawing.Size(78, 15);
            this.t_sequence.TabIndex = 1;
            this.t_sequence.Text = "NoShutdown";
            // 
            // l_seq
            // 
            this.l_seq.AutoSize = true;
            this.l_seq.Location = new System.Drawing.Point(12, 23);
            this.l_seq.Name = "l_seq";
            this.l_seq.Size = new System.Drawing.Size(66, 15);
            this.l_seq.TabIndex = 0;
            this.l_seq.Text = "Sequence:";
            // 
            // gb_controller
            // 
            this.gb_controller.Controls.Add(this.t_host);
            this.gb_controller.Controls.Add(this.t_broadcast);
            this.gb_controller.Controls.Add(this.l_broadcast);
            this.gb_controller.Controls.Add(this.t_server);
            this.gb_controller.Controls.Add(this.l_server);
            this.gb_controller.Controls.Add(this.l_host);
            this.gb_controller.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_controller.Location = new System.Drawing.Point(13, 139);
            this.gb_controller.Name = "gb_controller";
            this.gb_controller.Size = new System.Drawing.Size(229, 65);
            this.gb_controller.TabIndex = 9;
            this.gb_controller.TabStop = false;
            this.gb_controller.Text = "Controller";
            // 
            // t_host
            // 
            this.t_host.AutoSize = true;
            this.t_host.ForeColor = System.Drawing.Color.Red;
            this.t_host.Location = new System.Drawing.Point(99, 20);
            this.t_host.Name = "t_host";
            this.t_host.Size = new System.Drawing.Size(79, 15);
            this.t_host.TabIndex = 5;
            this.t_host.Text = "No Controller";
            // 
            // t_broadcast
            // 
            this.t_broadcast.AutoSize = true;
            this.t_broadcast.ForeColor = System.Drawing.Color.Red;
            this.t_broadcast.Location = new System.Drawing.Point(180, 42);
            this.t_broadcast.Name = "t_broadcast";
            this.t_broadcast.Size = new System.Drawing.Size(39, 15);
            this.t_broadcast.TabIndex = 4;
            this.t_broadcast.Text = "Down";
            // 
            // l_broadcast
            // 
            this.l_broadcast.AutoSize = true;
            this.l_broadcast.Location = new System.Drawing.Point(114, 42);
            this.l_broadcast.Name = "l_broadcast";
            this.l_broadcast.Size = new System.Drawing.Size(65, 15);
            this.l_broadcast.TabIndex = 3;
            this.l_broadcast.Text = "Broadcast:";
            // 
            // t_server
            // 
            this.t_server.AutoSize = true;
            this.t_server.ForeColor = System.Drawing.Color.Red;
            this.t_server.Location = new System.Drawing.Point(64, 41);
            this.t_server.Name = "t_server";
            this.t_server.Size = new System.Drawing.Size(39, 15);
            this.t_server.TabIndex = 2;
            this.t_server.Text = "Down";
            // 
            // l_server
            // 
            this.l_server.AutoSize = true;
            this.l_server.Location = new System.Drawing.Point(17, 41);
            this.l_server.Name = "l_server";
            this.l_server.Size = new System.Drawing.Size(45, 15);
            this.l_server.TabIndex = 1;
            this.l_server.Text = "Server:";
            // 
            // l_host
            // 
            this.l_host.AutoSize = true;
            this.l_host.Location = new System.Drawing.Point(15, 20);
            this.l_host.Name = "l_host";
            this.l_host.Size = new System.Drawing.Size(81, 15);
            this.l_host.TabIndex = 0;
            this.l_host.Text = "Hostname/IP:";
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "WinShutServer";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_gui,
            this.sep0,
            this.mi_config,
            this.mi_sequence,
            this.mi_connection,
            this.sep1,
            this.mi_exit});
            this.trayIconMenu.Name = "trayIconMenu";
            this.trayIconMenu.Size = new System.Drawing.Size(183, 148);
            // 
            // mi_gui
            // 
            this.mi_gui.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mi_gui.Name = "mi_gui";
            this.mi_gui.Size = new System.Drawing.Size(182, 22);
            this.mi_gui.Text = "Show GUI";
            this.mi_gui.Click += new System.EventHandler(this.mi_gui_Click);
            // 
            // sep0
            // 
            this.sep0.Name = "sep0";
            this.sep0.Size = new System.Drawing.Size(179, 6);
            // 
            // mi_config
            // 
            this.mi_config.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_startup,
            this.sep02,
            this.mi_server,
            this.mi_broadcast,
            this.sep03,
            this.mi_restart,
            this.mi_rebroadcast,
            this.sep04,
            this.mi_alert});
            this.mi_config.Name = "mi_config";
            this.mi_config.Size = new System.Drawing.Size(182, 22);
            this.mi_config.Text = "Configuration";
            // 
            // mi_startup
            // 
            this.mi_startup.Name = "mi_startup";
            this.mi_startup.Size = new System.Drawing.Size(345, 22);
            this.mi_startup.Text = "Run program on windows startup";
            this.mi_startup.Click += new System.EventHandler(this.mi_startup_Click);
            // 
            // sep02
            // 
            this.sep02.Name = "sep02";
            this.sep02.Size = new System.Drawing.Size(342, 6);
            // 
            // mi_server
            // 
            this.mi_server.Name = "mi_server";
            this.mi_server.Size = new System.Drawing.Size(345, 22);
            this.mi_server.Text = "Run control server immediately on program startup";
            this.mi_server.Click += new System.EventHandler(this.mi_server_Click);
            // 
            // mi_broadcast
            // 
            this.mi_broadcast.Enabled = false;
            this.mi_broadcast.Name = "mi_broadcast";
            this.mi_broadcast.Size = new System.Drawing.Size(345, 22);
            this.mi_broadcast.Text = "Broadcast immediately on program startup";
            this.mi_broadcast.Click += new System.EventHandler(this.mi_broadcast_Click);
            // 
            // sep03
            // 
            this.sep03.Name = "sep03";
            this.sep03.Size = new System.Drawing.Size(342, 6);
            // 
            // mi_restart
            // 
            this.mi_restart.Name = "mi_restart";
            this.mi_restart.Size = new System.Drawing.Size(345, 22);
            this.mi_restart.Text = "Do not stop control server on disconnection";
            this.mi_restart.Click += new System.EventHandler(this.mi_restart_Click);
            // 
            // mi_rebroadcast
            // 
            this.mi_rebroadcast.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_always,
            this.mi_sometimes,
            this.mi_never});
            this.mi_rebroadcast.Enabled = false;
            this.mi_rebroadcast.Name = "mi_rebroadcast";
            this.mi_rebroadcast.Size = new System.Drawing.Size(345, 22);
            this.mi_rebroadcast.Text = "Broadcast on disconnection";
            // 
            // mi_always
            // 
            this.mi_always.Name = "mi_always";
            this.mi_always.Size = new System.Drawing.Size(342, 22);
            this.mi_always.Text = "Always start broadcast when disconnected";
            this.mi_always.Click += new System.EventHandler(this.mi_always_Click);
            // 
            // mi_sometimes
            // 
            this.mi_sometimes.Name = "mi_sometimes";
            this.mi_sometimes.Size = new System.Drawing.Size(342, 22);
            this.mi_sometimes.Text = "Only start broadcast when it\'s UP upon connection";
            this.mi_sometimes.Click += new System.EventHandler(this.mi_sometimes_Click);
            // 
            // mi_never
            // 
            this.mi_never.Name = "mi_never";
            this.mi_never.Size = new System.Drawing.Size(342, 22);
            this.mi_never.Text = "Never start broadcast when disconnected ";
            this.mi_never.Click += new System.EventHandler(this.mi_never_Click);
            // 
            // sep04
            // 
            this.sep04.Name = "sep04";
            this.sep04.Size = new System.Drawing.Size(342, 6);
            // 
            // mi_alert
            // 
            this.mi_alert.Name = "mi_alert";
            this.mi_alert.Size = new System.Drawing.Size(345, 22);
            this.mi_alert.Text = "Show notification alerts";
            this.mi_alert.Click += new System.EventHandler(this.mi_alert_Click);
            // 
            // mi_sequence
            // 
            this.mi_sequence.Name = "mi_sequence";
            this.mi_sequence.Size = new System.Drawing.Size(182, 22);
            this.mi_sequence.Text = "Set Sequence";
            this.mi_sequence.Click += new System.EventHandler(this.mi_sequence_Click);
            // 
            // mi_connection
            // 
            this.mi_connection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_server_start,
            this.mi_server_stop,
            this.mi_server_disconnect,
            this.sep005,
            this.mi_broadcast_start,
            this.mi_broadcast_stop});
            this.mi_connection.Name = "mi_connection";
            this.mi_connection.Size = new System.Drawing.Size(182, 22);
            this.mi_connection.Text = "Manage Connection";
            // 
            // mi_server_start
            // 
            this.mi_server_start.Name = "mi_server_start";
            this.mi_server_start.Size = new System.Drawing.Size(176, 22);
            this.mi_server_start.Text = "Start Control Server";
            this.mi_server_start.Click += new System.EventHandler(this.mi_server_start_Click);
            // 
            // mi_server_stop
            // 
            this.mi_server_stop.Name = "mi_server_stop";
            this.mi_server_stop.Size = new System.Drawing.Size(176, 22);
            this.mi_server_stop.Text = "Stop Control Server";
            this.mi_server_stop.Click += new System.EventHandler(this.mi_server_stop_Click);
            // 
            // mi_server_disconnect
            // 
            this.mi_server_disconnect.Name = "mi_server_disconnect";
            this.mi_server_disconnect.Size = new System.Drawing.Size(176, 22);
            this.mi_server_disconnect.Text = "Disconnect";
            this.mi_server_disconnect.Click += new System.EventHandler(this.mi_server_disconnect_Click);
            // 
            // sep005
            // 
            this.sep005.Name = "sep005";
            this.sep005.Size = new System.Drawing.Size(173, 6);
            // 
            // mi_broadcast_start
            // 
            this.mi_broadcast_start.Name = "mi_broadcast_start";
            this.mi_broadcast_start.Size = new System.Drawing.Size(176, 22);
            this.mi_broadcast_start.Text = "Start Broadcast";
            this.mi_broadcast_start.Click += new System.EventHandler(this.mi_broadcast_start_Click);
            // 
            // mi_broadcast_stop
            // 
            this.mi_broadcast_stop.Name = "mi_broadcast_stop";
            this.mi_broadcast_stop.Size = new System.Drawing.Size(176, 22);
            this.mi_broadcast_stop.Text = "Stop Broadcast";
            this.mi_broadcast_stop.Click += new System.EventHandler(this.mi_broadcast_stop_Click);
            // 
            // sep1
            // 
            this.sep1.Name = "sep1";
            this.sep1.Size = new System.Drawing.Size(179, 6);
            // 
            // mi_exit
            // 
            this.mi_exit.Name = "mi_exit";
            this.mi_exit.Size = new System.Drawing.Size(182, 22);
            this.mi_exit.Text = "Exit";
            this.mi_exit.Click += new System.EventHandler(this.mi_exit_Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.gb_controller);
            this.Controls.Add(this.gb_sequence);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.b_exit);
            this.Controls.Add(this.b_hide);
            this.Controls.Add(this.b_connection);
            this.Controls.Add(this.b_sequence);
            this.Controls.Add(this.b_config);
            this.Controls.Add(this.i_title);
            this.Controls.Add(this.l_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinShutServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrame_FormClosing);
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.Shown += new System.EventHandler(this.MainFrame_Shown);
            this.gb_sequence.ResumeLayout(false);
            this.gb_sequence.PerformLayout();
            this.gb_controller.ResumeLayout(false);
            this.gb_controller.PerformLayout();
            this.trayIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Panel i_title;
        private System.Windows.Forms.Button b_config;
        private System.Windows.Forms.Button b_sequence;
        private System.Windows.Forms.Button b_connection;
        private System.Windows.Forms.Button b_hide;
        private System.Windows.Forms.Button b_exit;
        private System.Windows.Forms.RichTextBox tb_log;
        private System.Windows.Forms.GroupBox gb_sequence;
        private System.Windows.Forms.Label t_time;
        private System.Windows.Forms.Label l_time;
        private System.Windows.Forms.Label t_type;
        private System.Windows.Forms.Label l_type;
        private System.Windows.Forms.Label t_sequence;
        private System.Windows.Forms.Label l_seq;
        private System.Windows.Forms.GroupBox gb_controller;
        private System.Windows.Forms.Label t_host;
        private System.Windows.Forms.Label t_broadcast;
        private System.Windows.Forms.Label l_broadcast;
        private System.Windows.Forms.Label t_server;
        private System.Windows.Forms.Label l_server;
        private System.Windows.Forms.Label l_host;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem mi_gui;
        private System.Windows.Forms.ToolStripSeparator sep0;
        private System.Windows.Forms.ToolStripMenuItem mi_config;
        private System.Windows.Forms.ToolStripMenuItem mi_sequence;
        private System.Windows.Forms.ToolStripMenuItem mi_connection;
        private System.Windows.Forms.ToolStripSeparator sep1;
        private System.Windows.Forms.ToolStripMenuItem mi_exit;
        private System.Windows.Forms.ToolStripMenuItem mi_startup;
        private System.Windows.Forms.ToolStripMenuItem mi_server;
        private System.Windows.Forms.ToolStripMenuItem mi_broadcast;
        private System.Windows.Forms.ToolStripMenuItem mi_restart;
        private System.Windows.Forms.ToolStripMenuItem mi_alert;
        private System.Windows.Forms.ToolStripMenuItem mi_rebroadcast;
        private System.Windows.Forms.ToolStripMenuItem mi_always;
        private System.Windows.Forms.ToolStripMenuItem mi_sometimes;
        private System.Windows.Forms.ToolStripMenuItem mi_never;
        private System.Windows.Forms.ToolStripSeparator sep02;
        private System.Windows.Forms.ToolStripSeparator sep03;
        private System.Windows.Forms.ToolStripSeparator sep04;
        private System.Windows.Forms.ToolStripMenuItem mi_server_start;
        private System.Windows.Forms.ToolStripMenuItem mi_server_stop;
        private System.Windows.Forms.ToolStripMenuItem mi_server_disconnect;
        private System.Windows.Forms.ToolStripSeparator sep005;
        private System.Windows.Forms.ToolStripMenuItem mi_broadcast_start;
        private System.Windows.Forms.ToolStripMenuItem mi_broadcast_stop;
    }
}