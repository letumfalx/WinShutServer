namespace WinShutServer
{
    partial class ConfigFrame
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
            this.cb_startup = new System.Windows.Forms.CheckBox();
            this.cb_server = new System.Windows.Forms.CheckBox();
            this.cb_broadcast = new System.Windows.Forms.CheckBox();
            this.cb_restart = new System.Windows.Forms.CheckBox();
            this.cb_alert = new System.Windows.Forms.CheckBox();
            this.b_apply = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.r_always = new System.Windows.Forms.RadioButton();
            this.r_sometimes = new System.Windows.Forms.RadioButton();
            this.r_never = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // cb_startup
            // 
            this.cb_startup.AutoSize = true;
            this.cb_startup.Location = new System.Drawing.Point(10, 12);
            this.cb_startup.Name = "cb_startup";
            this.cb_startup.Size = new System.Drawing.Size(176, 17);
            this.cb_startup.TabIndex = 0;
            this.cb_startup.Text = "Run program on window startup";
            this.cb_startup.UseVisualStyleBackColor = true;
            // 
            // cb_server
            // 
            this.cb_server.AutoSize = true;
            this.cb_server.Location = new System.Drawing.Point(10, 35);
            this.cb_server.Name = "cb_server";
            this.cb_server.Size = new System.Drawing.Size(261, 17);
            this.cb_server.TabIndex = 1;
            this.cb_server.Text = "Run control server immediately on program startup";
            this.cb_server.UseVisualStyleBackColor = true;
            this.cb_server.CheckedChanged += new System.EventHandler(this.cb_server_CheckedChanged);
            // 
            // cb_broadcast
            // 
            this.cb_broadcast.AutoSize = true;
            this.cb_broadcast.Location = new System.Drawing.Point(26, 58);
            this.cb_broadcast.Name = "cb_broadcast";
            this.cb_broadcast.Size = new System.Drawing.Size(151, 17);
            this.cb_broadcast.TabIndex = 2;
            this.cb_broadcast.Text = "Also start broadcast server";
            this.cb_broadcast.UseVisualStyleBackColor = true;
            // 
            // cb_restart
            // 
            this.cb_restart.AutoSize = true;
            this.cb_restart.Location = new System.Drawing.Point(10, 81);
            this.cb_restart.Name = "cb_restart";
            this.cb_restart.Size = new System.Drawing.Size(197, 17);
            this.cb_restart.TabIndex = 3;
            this.cb_restart.Text = "Do not stop server on disconnection";
            this.cb_restart.UseVisualStyleBackColor = true;
            this.cb_restart.CheckedChanged += new System.EventHandler(this.cb_restart_CheckedChanged);
            // 
            // cb_alert
            // 
            this.cb_alert.AutoSize = true;
            this.cb_alert.Location = new System.Drawing.Point(10, 173);
            this.cb_alert.Name = "cb_alert";
            this.cb_alert.Size = new System.Drawing.Size(149, 17);
            this.cb_alert.TabIndex = 4;
            this.cb_alert.Text = "Enable notification dialogs";
            this.cb_alert.UseVisualStyleBackColor = true;
            // 
            // b_apply
            // 
            this.b_apply.Location = new System.Drawing.Point(111, 196);
            this.b_apply.Name = "b_apply";
            this.b_apply.Size = new System.Drawing.Size(75, 23);
            this.b_apply.TabIndex = 5;
            this.b_apply.Text = "Apply";
            this.b_apply.UseVisualStyleBackColor = true;
            this.b_apply.Click += new System.EventHandler(this.b_apply_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(196, 196);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 6;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // r_always
            // 
            this.r_always.AutoSize = true;
            this.r_always.Location = new System.Drawing.Point(26, 104);
            this.r_always.Name = "r_always";
            this.r_always.Size = new System.Drawing.Size(227, 17);
            this.r_always.TabIndex = 7;
            this.r_always.Text = "Always start broadcast when disconnected";
            this.r_always.UseVisualStyleBackColor = true;
            // 
            // r_sometimes
            // 
            this.r_sometimes.AutoSize = true;
            this.r_sometimes.Location = new System.Drawing.Point(26, 127);
            this.r_sometimes.Name = "r_sometimes";
            this.r_sometimes.Size = new System.Drawing.Size(264, 17);
            this.r_sometimes.TabIndex = 8;
            this.r_sometimes.Text = "Only start broadcast when it\'s UP upon connection";
            this.r_sometimes.UseVisualStyleBackColor = true;
            // 
            // r_never
            // 
            this.r_never.AutoSize = true;
            this.r_never.Location = new System.Drawing.Point(26, 150);
            this.r_never.Name = "r_never";
            this.r_never.Size = new System.Drawing.Size(226, 17);
            this.r_never.TabIndex = 9;
            this.r_never.Text = "Never start broadcast when disconnected ";
            this.r_never.UseVisualStyleBackColor = true;
            // 
            // ConfigFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 228);
            this.Controls.Add(this.r_never);
            this.Controls.Add(this.r_sometimes);
            this.Controls.Add(this.r_always);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_apply);
            this.Controls.Add(this.cb_alert);
            this.Controls.Add(this.cb_restart);
            this.Controls.Add(this.cb_broadcast);
            this.Controls.Add(this.cb_server);
            this.Controls.Add(this.cb_startup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.ConfigFrame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_startup;
        private System.Windows.Forms.CheckBox cb_server;
        private System.Windows.Forms.CheckBox cb_broadcast;
        private System.Windows.Forms.CheckBox cb_restart;
        private System.Windows.Forms.CheckBox cb_alert;
        private System.Windows.Forms.Button b_apply;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.RadioButton r_always;
        private System.Windows.Forms.RadioButton r_sometimes;
        private System.Windows.Forms.RadioButton r_never;
    }
}