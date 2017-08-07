namespace WinShutServer.Utils
{
    partial class AlertBoxForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.l_title = new System.Windows.Forms.Label();
            this.l_content = new System.Windows.Forms.Label();
            this.b_ok = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.l_title);
            this.flowLayoutPanel1.Controls.Add(this.l_content);
            this.flowLayoutPanel1.Controls.Add(this.b_ok);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(616, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(93, 80);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // l_title
            // 
            this.l_title.AutoSize = true;
            this.l_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_title.Location = new System.Drawing.Point(5, 5);
            this.l_title.Margin = new System.Windows.Forms.Padding(5);
            this.l_title.MaximumSize = new System.Drawing.Size(606, 0);
            this.l_title.Name = "l_title";
            this.l_title.Size = new System.Drawing.Size(43, 20);
            this.l_title.TabIndex = 0;
            this.l_title.Text = "Title";
            // 
            // l_content
            // 
            this.l_content.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.l_content.AutoSize = true;
            this.l_content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_content.Location = new System.Drawing.Point(25, 30);
            this.l_content.Margin = new System.Windows.Forms.Padding(25, 0, 3, 5);
            this.l_content.MaximumSize = new System.Drawing.Size(586, 0);
            this.l_content.Name = "l_content";
            this.l_content.Size = new System.Drawing.Size(53, 16);
            this.l_content.TabIndex = 1;
            this.l_content.Text = "Content";
            // 
            // b_ok
            // 
            this.b_ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.b_ok.AutoSize = true;
            this.b_ok.Location = new System.Drawing.Point(3, 54);
            this.b_ok.MaximumSize = new System.Drawing.Size(300, 0);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 2;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AlertBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(115, 105);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 99999);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "AlertBoxForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Title";
            this.Load += new System.EventHandler(this.AlertBoxForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label l_title;
        private System.Windows.Forms.Label l_content;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Timer timer;
    }
}