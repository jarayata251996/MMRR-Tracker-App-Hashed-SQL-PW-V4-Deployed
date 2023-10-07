namespace MMRR_Tracker
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.enterButton = new System.Windows.Forms.Button();
            this.newWorkGroup = new System.Windows.Forms.ComboBox();
            this.empNumber_textBox = new System.Windows.Forms.TextBox();
            this.changePWgb = new System.Windows.Forms.Panel();
            this.useradmPane = new System.Windows.Forms.PictureBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.opchangePane = new System.Windows.Forms.PictureBox();
            this.mmchangePane = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.wgchange_pictureBox = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.userchange_pictureBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fadeIn = new System.Windows.Forms.Timer(this.components);
            this.changePWgb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useradmPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opchangePane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmchangePane)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wgchange_pictureBox)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userchange_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // enterButton
            // 
            this.enterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(155)))), ((int)(((byte)(207)))));
            this.enterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.enterButton.Location = new System.Drawing.Point(228, 479);
            this.enterButton.Margin = new System.Windows.Forms.Padding(4);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(223, 48);
            this.enterButton.TabIndex = 5;
            this.enterButton.Text = "CONFIRM";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click_1);
            // 
            // newWorkGroup
            // 
            this.newWorkGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.newWorkGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.newWorkGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newWorkGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newWorkGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.newWorkGroup.FormattingEnabled = true;
            this.newWorkGroup.Location = new System.Drawing.Point(68, 15);
            this.newWorkGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newWorkGroup.Name = "newWorkGroup";
            this.newWorkGroup.Size = new System.Drawing.Size(512, 33);
            this.newWorkGroup.TabIndex = 12;
            // 
            // empNumber_textBox
            // 
            this.empNumber_textBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.empNumber_textBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.empNumber_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.empNumber_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empNumber_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.empNumber_textBox.Location = new System.Drawing.Point(67, 20);
            this.empNumber_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.empNumber_textBox.Name = "empNumber_textBox";
            this.empNumber_textBox.Size = new System.Drawing.Size(512, 23);
            this.empNumber_textBox.TabIndex = 0;
            // 
            // changePWgb
            // 
            this.changePWgb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.changePWgb.Controls.Add(this.useradmPane);
            this.changePWgb.Controls.Add(this.xLabel);
            this.changePWgb.Controls.Add(this.opchangePane);
            this.changePWgb.Controls.Add(this.mmchangePane);
            this.changePWgb.Controls.Add(this.enterButton);
            this.changePWgb.Controls.Add(this.panel5);
            this.changePWgb.Controls.Add(this.label6);
            this.changePWgb.Location = new System.Drawing.Point(0, 0);
            this.changePWgb.Name = "changePWgb";
            this.changePWgb.Size = new System.Drawing.Size(669, 558);
            this.changePWgb.TabIndex = 46;
            // 
            // useradmPane
            // 
            this.useradmPane.Image = global::MMRR_Tracker.Properties.Resources.user_pen;
            this.useradmPane.Location = new System.Drawing.Point(268, 105);
            this.useradmPane.Name = "useradmPane";
            this.useradmPane.Size = new System.Drawing.Size(139, 128);
            this.useradmPane.TabIndex = 42;
            this.useradmPane.TabStop = false;
            // 
            // xLabel
            // 
            this.xLabel.BackColor = System.Drawing.Color.Transparent;
            this.xLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.xLabel.Location = new System.Drawing.Point(629, 5);
            this.xLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(35, 35);
            this.xLabel.TabIndex = 7;
            this.xLabel.Text = "X";
            this.xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel.Click += new System.EventHandler(this.xLabel_Click_1);
            // 
            // opchangePane
            // 
            this.opchangePane.Image = global::MMRR_Tracker.Properties.Resources.opLong4;
            this.opchangePane.Location = new System.Drawing.Point(22, 40);
            this.opchangePane.Name = "opchangePane";
            this.opchangePane.Size = new System.Drawing.Size(126, 28);
            this.opchangePane.TabIndex = 41;
            this.opchangePane.TabStop = false;
            this.opchangePane.Click += new System.EventHandler(this.opchangePane_Click);
            // 
            // mmchangePane
            // 
            this.mmchangePane.Image = global::MMRR_Tracker.Properties.Resources.Morgan___Morgan_Logo_svg;
            this.mmchangePane.Location = new System.Drawing.Point(521, 40);
            this.mmchangePane.Name = "mmchangePane";
            this.mmchangePane.Size = new System.Drawing.Size(126, 28);
            this.mmchangePane.TabIndex = 40;
            this.mmchangePane.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Location = new System.Drawing.Point(22, 292);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(625, 176);
            this.panel5.TabIndex = 39;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.newWorkGroup);
            this.panel6.Controls.Add(this.wgchange_pictureBox);
            this.panel6.Location = new System.Drawing.Point(16, 95);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(593, 63);
            this.panel6.TabIndex = 31;
            // 
            // wgchange_pictureBox
            // 
            this.wgchange_pictureBox.BackColor = System.Drawing.Color.White;
            this.wgchange_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wgchange_pictureBox.Image = global::MMRR_Tracker.Properties.Resources.users_alt;
            this.wgchange_pictureBox.Location = new System.Drawing.Point(15, 14);
            this.wgchange_pictureBox.Name = "wgchange_pictureBox";
            this.wgchange_pictureBox.Size = new System.Drawing.Size(42, 36);
            this.wgchange_pictureBox.TabIndex = 26;
            this.wgchange_pictureBox.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.userchange_pictureBox);
            this.panel7.Controls.Add(this.empNumber_textBox);
            this.panel7.Location = new System.Drawing.Point(17, 17);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(592, 63);
            this.panel7.TabIndex = 30;
            // 
            // userchange_pictureBox
            // 
            this.userchange_pictureBox.BackColor = System.Drawing.Color.White;
            this.userchange_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userchange_pictureBox.Image = global::MMRR_Tracker.Properties.Resources.userIcon;
            this.userchange_pictureBox.Location = new System.Drawing.Point(15, 14);
            this.userchange_pictureBox.Name = "userchange_pictureBox";
            this.userchange_pictureBox.Size = new System.Drawing.Size(42, 36);
            this.userchange_pictureBox.TabIndex = 25;
            this.userchange_pictureBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.label6.Location = new System.Drawing.Point(65, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(541, 49);
            this.label6.TabIndex = 38;
            this.label6.Text = "CHANGE AGENT INFORMATION";
            // 
            // fadeIn
            // 
            this.fadeIn.Enabled = true;
            this.fadeIn.Interval = 30;
            this.fadeIn.Tick += new System.EventHandler(this.fadeIn_Tick);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 558);
            this.Controls.Add(this.changePWgb);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChangePassword";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.changePWgb.ResumeLayout(false);
            this.changePWgb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useradmPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opchangePane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmchangePane)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wgchange_pictureBox)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userchange_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel changePWgb;
        public System.Windows.Forms.PictureBox useradmPane;
        public System.Windows.Forms.PictureBox opchangePane;
        public System.Windows.Forms.PictureBox mmchangePane;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.PictureBox wgchange_pictureBox;
        private System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.PictureBox userchange_pictureBox;
        private System.Windows.Forms.Label xLabel;
        public System.Windows.Forms.Button enterButton;
        public System.Windows.Forms.TextBox empNumber_textBox;
        public System.Windows.Forms.ComboBox newWorkGroup;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer fadeIn;
        public System.Windows.Forms.Panel panel5;
    }
}