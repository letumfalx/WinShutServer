namespace WinShutServer
{
    partial class SequenceFrame
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
            this.gb_seq = new System.Windows.Forms.GroupBox();
            this.rs_lockuser = new System.Windows.Forms.RadioButton();
            this.rs_logoff = new System.Windows.Forms.RadioButton();
            this.rs_hibernate = new System.Windows.Forms.RadioButton();
            this.rs_sleep = new System.Windows.Forms.RadioButton();
            this.rs_restart = new System.Windows.Forms.RadioButton();
            this.rs_shutdown = new System.Windows.Forms.RadioButton();
            this.gb_type = new System.Windows.Forms.GroupBox();
            this.rt_scheduled = new System.Windows.Forms.RadioButton();
            this.rt_timed = new System.Windows.Forms.RadioButton();
            this.rt_fast = new System.Windows.Forms.RadioButton();
            this.n_hour = new System.Windows.Forms.NumericUpDown();
            this.n_minute = new System.Windows.Forms.NumericUpDown();
            this.n_second = new System.Windows.Forms.NumericUpDown();
            this.gb_time = new System.Windows.Forms.GroupBox();
            this.l_sec = new System.Windows.Forms.Label();
            this.l_min = new System.Windows.Forms.Label();
            this.l_hr = new System.Windows.Forms.Label();
            this.l_label = new System.Windows.Forms.Label();
            this.l_current = new System.Windows.Forms.Label();
            this.b_set = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.b_close = new System.Windows.Forms.Button();
            this.gb_seq.SuspendLayout();
            this.gb_type.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_second)).BeginInit();
            this.gb_time.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_seq
            // 
            this.gb_seq.Controls.Add(this.rs_lockuser);
            this.gb_seq.Controls.Add(this.rs_logoff);
            this.gb_seq.Controls.Add(this.rs_hibernate);
            this.gb_seq.Controls.Add(this.rs_sleep);
            this.gb_seq.Controls.Add(this.rs_restart);
            this.gb_seq.Controls.Add(this.rs_shutdown);
            this.gb_seq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_seq.Location = new System.Drawing.Point(13, 12);
            this.gb_seq.Name = "gb_seq";
            this.gb_seq.Size = new System.Drawing.Size(234, 90);
            this.gb_seq.TabIndex = 0;
            this.gb_seq.TabStop = false;
            this.gb_seq.Text = "What to do?";
            // 
            // rs_lockuser
            // 
            this.rs_lockuser.AutoSize = true;
            this.rs_lockuser.Location = new System.Drawing.Point(125, 65);
            this.rs_lockuser.Name = "rs_lockuser";
            this.rs_lockuser.Size = new System.Drawing.Size(80, 19);
            this.rs_lockuser.TabIndex = 5;
            this.rs_lockuser.TabStop = true;
            this.rs_lockuser.Text = "Lock User";
            this.rs_lockuser.UseVisualStyleBackColor = true;
            // 
            // rs_logoff
            // 
            this.rs_logoff.AutoSize = true;
            this.rs_logoff.Location = new System.Drawing.Point(125, 43);
            this.rs_logoff.Name = "rs_logoff";
            this.rs_logoff.Size = new System.Drawing.Size(64, 19);
            this.rs_logoff.TabIndex = 4;
            this.rs_logoff.TabStop = true;
            this.rs_logoff.Text = "Log Off";
            this.rs_logoff.UseVisualStyleBackColor = true;
            // 
            // rs_hibernate
            // 
            this.rs_hibernate.AutoSize = true;
            this.rs_hibernate.Location = new System.Drawing.Point(125, 20);
            this.rs_hibernate.Name = "rs_hibernate";
            this.rs_hibernate.Size = new System.Drawing.Size(79, 19);
            this.rs_hibernate.TabIndex = 3;
            this.rs_hibernate.TabStop = true;
            this.rs_hibernate.Text = "Hibernate";
            this.rs_hibernate.UseVisualStyleBackColor = true;
            // 
            // rs_sleep
            // 
            this.rs_sleep.AutoSize = true;
            this.rs_sleep.Location = new System.Drawing.Point(17, 65);
            this.rs_sleep.Name = "rs_sleep";
            this.rs_sleep.Size = new System.Drawing.Size(57, 19);
            this.rs_sleep.TabIndex = 2;
            this.rs_sleep.TabStop = true;
            this.rs_sleep.Text = "Sleep";
            this.rs_sleep.UseVisualStyleBackColor = true;
            // 
            // rs_restart
            // 
            this.rs_restart.AutoSize = true;
            this.rs_restart.Location = new System.Drawing.Point(17, 43);
            this.rs_restart.Name = "rs_restart";
            this.rs_restart.Size = new System.Drawing.Size(64, 19);
            this.rs_restart.TabIndex = 1;
            this.rs_restart.TabStop = true;
            this.rs_restart.Text = "Restart";
            this.rs_restart.UseVisualStyleBackColor = true;
            // 
            // rs_shutdown
            // 
            this.rs_shutdown.AutoSize = true;
            this.rs_shutdown.Location = new System.Drawing.Point(17, 21);
            this.rs_shutdown.Name = "rs_shutdown";
            this.rs_shutdown.Size = new System.Drawing.Size(80, 19);
            this.rs_shutdown.TabIndex = 0;
            this.rs_shutdown.TabStop = true;
            this.rs_shutdown.Text = "Shutdown";
            this.rs_shutdown.UseVisualStyleBackColor = true;
            // 
            // gb_type
            // 
            this.gb_type.Controls.Add(this.rt_scheduled);
            this.gb_type.Controls.Add(this.rt_timed);
            this.gb_type.Controls.Add(this.rt_fast);
            this.gb_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_type.Location = new System.Drawing.Point(13, 109);
            this.gb_type.Name = "gb_type";
            this.gb_type.Size = new System.Drawing.Size(234, 47);
            this.gb_type.TabIndex = 1;
            this.gb_type.TabStop = false;
            this.gb_type.Text = "How?";
            // 
            // rt_scheduled
            // 
            this.rt_scheduled.AutoSize = true;
            this.rt_scheduled.Location = new System.Drawing.Point(146, 20);
            this.rt_scheduled.Name = "rt_scheduled";
            this.rt_scheduled.Size = new System.Drawing.Size(84, 19);
            this.rt_scheduled.TabIndex = 2;
            this.rt_scheduled.TabStop = true;
            this.rt_scheduled.Text = "Scheduled";
            this.rt_scheduled.UseVisualStyleBackColor = true;
            this.rt_scheduled.CheckedChanged += new System.EventHandler(this.rt_scheduled_CheckedChanged);
            // 
            // rt_timed
            // 
            this.rt_timed.AutoSize = true;
            this.rt_timed.Location = new System.Drawing.Point(75, 20);
            this.rt_timed.Name = "rt_timed";
            this.rt_timed.Size = new System.Drawing.Size(60, 19);
            this.rt_timed.TabIndex = 1;
            this.rt_timed.TabStop = true;
            this.rt_timed.Text = "Timed";
            this.rt_timed.UseVisualStyleBackColor = true;
            this.rt_timed.CheckedChanged += new System.EventHandler(this.rt_timed_CheckedChanged);
            // 
            // rt_fast
            // 
            this.rt_fast.AutoSize = true;
            this.rt_fast.Location = new System.Drawing.Point(17, 20);
            this.rt_fast.Name = "rt_fast";
            this.rt_fast.Size = new System.Drawing.Size(48, 19);
            this.rt_fast.TabIndex = 0;
            this.rt_fast.TabStop = true;
            this.rt_fast.Text = "Fast";
            this.rt_fast.UseVisualStyleBackColor = true;
            this.rt_fast.CheckedChanged += new System.EventHandler(this.rt_fast_CheckedChanged);
            // 
            // n_hour
            // 
            this.n_hour.Location = new System.Drawing.Point(39, 19);
            this.n_hour.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.n_hour.Name = "n_hour";
            this.n_hour.Size = new System.Drawing.Size(40, 20);
            this.n_hour.TabIndex = 2;
            // 
            // n_minute
            // 
            this.n_minute.Location = new System.Drawing.Point(114, 19);
            this.n_minute.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.n_minute.Name = "n_minute";
            this.n_minute.Size = new System.Drawing.Size(40, 20);
            this.n_minute.TabIndex = 3;
            // 
            // n_second
            // 
            this.n_second.Location = new System.Drawing.Point(188, 20);
            this.n_second.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.n_second.Name = "n_second";
            this.n_second.Size = new System.Drawing.Size(40, 20);
            this.n_second.TabIndex = 4;
            // 
            // gb_time
            // 
            this.gb_time.Controls.Add(this.l_sec);
            this.gb_time.Controls.Add(this.l_min);
            this.gb_time.Controls.Add(this.l_hr);
            this.gb_time.Controls.Add(this.n_hour);
            this.gb_time.Controls.Add(this.n_second);
            this.gb_time.Controls.Add(this.n_minute);
            this.gb_time.Location = new System.Drawing.Point(13, 163);
            this.gb_time.Name = "gb_time";
            this.gb_time.Size = new System.Drawing.Size(234, 50);
            this.gb_time.TabIndex = 5;
            this.gb_time.TabStop = false;
            this.gb_time.Text = "Do after/on:";
            // 
            // l_sec
            // 
            this.l_sec.AutoSize = true;
            this.l_sec.Location = new System.Drawing.Point(168, 23);
            this.l_sec.Name = "l_sec";
            this.l_sec.Size = new System.Drawing.Size(17, 13);
            this.l_sec.TabIndex = 7;
            this.l_sec.Text = "S:";
            // 
            // l_min
            // 
            this.l_min.AutoSize = true;
            this.l_min.Location = new System.Drawing.Point(93, 22);
            this.l_min.Name = "l_min";
            this.l_min.Size = new System.Drawing.Size(19, 13);
            this.l_min.TabIndex = 6;
            this.l_min.Text = "M:";
            // 
            // l_hr
            // 
            this.l_hr.AutoSize = true;
            this.l_hr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_hr.Location = new System.Drawing.Point(14, 19);
            this.l_hr.Name = "l_hr";
            this.l_hr.Size = new System.Drawing.Size(19, 15);
            this.l_hr.TabIndex = 5;
            this.l_hr.Text = "H:";
            // 
            // l_label
            // 
            this.l_label.AutoSize = true;
            this.l_label.Location = new System.Drawing.Point(12, 230);
            this.l_label.Name = "l_label";
            this.l_label.Size = new System.Drawing.Size(44, 13);
            this.l_label.TabIndex = 6;
            this.l_label.Text = "Current:";
            // 
            // l_current
            // 
            this.l_current.AutoSize = true;
            this.l_current.Location = new System.Drawing.Point(33, 253);
            this.l_current.MaximumSize = new System.Drawing.Size(75, 0);
            this.l_current.Name = "l_current";
            this.l_current.Size = new System.Drawing.Size(61, 26);
            this.l_current.TabIndex = 7;
            this.l_current.Text = "Scheduled Lock User";
            // 
            // b_set
            // 
            this.b_set.Location = new System.Drawing.Point(138, 220);
            this.b_set.Name = "b_set";
            this.b_set.Size = new System.Drawing.Size(107, 23);
            this.b_set.TabIndex = 8;
            this.b_set.Text = "Set";
            this.b_set.UseVisualStyleBackColor = true;
            this.b_set.Click += new System.EventHandler(this.b_set_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(138, 248);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(107, 23);
            this.b_cancel.TabIndex = 9;
            this.b_cancel.Text = "Cancel Current";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // b_close
            // 
            this.b_close.Location = new System.Drawing.Point(138, 278);
            this.b_close.Name = "b_close";
            this.b_close.Size = new System.Drawing.Size(107, 23);
            this.b_close.TabIndex = 10;
            this.b_close.Text = "Close";
            this.b_close.UseVisualStyleBackColor = true;
            this.b_close.Click += new System.EventHandler(this.b_close_Click);
            // 
            // SequenceFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 311);
            this.Controls.Add(this.b_close);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_set);
            this.Controls.Add(this.l_current);
            this.Controls.Add(this.l_label);
            this.Controls.Add(this.gb_time);
            this.Controls.Add(this.gb_type);
            this.Controls.Add(this.gb_seq);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SequenceFrame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Sequence";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SequenceFrame_FormClosing);
            this.Load += new System.EventHandler(this.SequenceFrame_Load);
            this.gb_seq.ResumeLayout(false);
            this.gb_seq.PerformLayout();
            this.gb_type.ResumeLayout(false);
            this.gb_type.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_second)).EndInit();
            this.gb_time.ResumeLayout(false);
            this.gb_time.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_seq;
        private System.Windows.Forms.RadioButton rs_lockuser;
        private System.Windows.Forms.RadioButton rs_logoff;
        private System.Windows.Forms.RadioButton rs_hibernate;
        private System.Windows.Forms.RadioButton rs_sleep;
        private System.Windows.Forms.RadioButton rs_restart;
        private System.Windows.Forms.RadioButton rs_shutdown;
        private System.Windows.Forms.GroupBox gb_type;
        private System.Windows.Forms.RadioButton rt_scheduled;
        private System.Windows.Forms.RadioButton rt_timed;
        private System.Windows.Forms.RadioButton rt_fast;
        private System.Windows.Forms.NumericUpDown n_hour;
        private System.Windows.Forms.NumericUpDown n_minute;
        private System.Windows.Forms.NumericUpDown n_second;
        private System.Windows.Forms.GroupBox gb_time;
        private System.Windows.Forms.Label l_min;
        private System.Windows.Forms.Label l_hr;
        private System.Windows.Forms.Label l_sec;
        private System.Windows.Forms.Label l_label;
        private System.Windows.Forms.Label l_current;
        private System.Windows.Forms.Button b_set;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Button b_close;
    }
}