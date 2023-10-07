namespace MMRR_Tracker
{
    partial class RegisterNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterNewUser));
            this.changePWgb = new System.Windows.Forms.Panel();
            this.xLabel = new System.Windows.Forms.Label();
            this.enterButton = new System.Windows.Forms.Button();
            this.adduserPane = new System.Windows.Forms.PictureBox();
            this.opaddPane = new System.Windows.Forms.PictureBox();
            this.mmaddPane = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.newWorkGroup = new System.Windows.Forms.ComboBox();
            this.empID = new System.Windows.Forms.TextBox();
            this.fullName = new System.Windows.Forms.TextBox();
            this.opEmail = new System.Windows.Forms.TextBox();
            this.ftpEmail = new System.Windows.Forms.TextBox();
            this.ntUsername = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fadeIn = new System.Windows.Forms.Timer(this.components);
            this.changePWgb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adduserPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opaddPane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmaddPane)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // changePWgb
            // 
            this.changePWgb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.changePWgb.Controls.Add(this.xLabel);
            this.changePWgb.Controls.Add(this.enterButton);
            this.changePWgb.Controls.Add(this.adduserPane);
            this.changePWgb.Controls.Add(this.opaddPane);
            this.changePWgb.Controls.Add(this.mmaddPane);
            this.changePWgb.Controls.Add(this.panel5);
            this.changePWgb.Controls.Add(this.label10);
            this.changePWgb.Location = new System.Drawing.Point(0, 0);
            this.changePWgb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.changePWgb.Name = "changePWgb";
            this.changePWgb.Size = new System.Drawing.Size(757, 639);
            this.changePWgb.TabIndex = 46;
            // 
            // xLabel
            // 
            this.xLabel.BackColor = System.Drawing.Color.Transparent;
            this.xLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.xLabel.Location = new System.Drawing.Point(723, 2);
            this.xLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(35, 30);
            this.xLabel.TabIndex = 16;
            this.xLabel.Text = "X";
            this.xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xLabel.Click += new System.EventHandler(this.xLabel_Click);
            // 
            // enterButton
            // 
            this.enterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(155)))), ((int)(((byte)(207)))));
            this.enterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.enterButton.Location = new System.Drawing.Point(267, 569);
            this.enterButton.Margin = new System.Windows.Forms.Padding(4);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(220, 48);
            this.enterButton.TabIndex = 17;
            this.enterButton.Text = "CONFIRM";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // adduserPane
            // 
            this.adduserPane.Image = global::MMRR_Tracker.Properties.Resources.user_add;
            this.adduserPane.Location = new System.Drawing.Point(315, 78);
            this.adduserPane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adduserPane.Name = "adduserPane";
            this.adduserPane.Size = new System.Drawing.Size(139, 128);
            this.adduserPane.TabIndex = 42;
            this.adduserPane.TabStop = false;
            // 
            // opaddPane
            // 
            this.opaddPane.Image = global::MMRR_Tracker.Properties.Resources.opLong4;
            this.opaddPane.Location = new System.Drawing.Point(21, 36);
            this.opaddPane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.opaddPane.Name = "opaddPane";
            this.opaddPane.Size = new System.Drawing.Size(125, 28);
            this.opaddPane.TabIndex = 41;
            this.opaddPane.TabStop = false;
            this.opaddPane.Click += new System.EventHandler(this.opaddPane_Click);
            // 
            // mmaddPane
            // 
            this.mmaddPane.Image = global::MMRR_Tracker.Properties.Resources.Morgan___Morgan_Logo_svg;
            this.mmaddPane.Location = new System.Drawing.Point(607, 37);
            this.mmaddPane.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mmaddPane.Name = "mmaddPane";
            this.mmaddPane.Size = new System.Drawing.Size(125, 28);
            this.mmaddPane.TabIndex = 40;
            this.mmaddPane.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.panel5.Controls.Add(this.newWorkGroup);
            this.panel5.Controls.Add(this.empID);
            this.panel5.Controls.Add(this.fullName);
            this.panel5.Controls.Add(this.opEmail);
            this.panel5.Controls.Add(this.ftpEmail);
            this.panel5.Controls.Add(this.ntUsername);
            this.panel5.Location = new System.Drawing.Point(21, 279);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(711, 270);
            this.panel5.TabIndex = 39;
            // 
            // newWorkGroup
            // 
            this.newWorkGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.newWorkGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newWorkGroup.FormattingEnabled = true;
            this.newWorkGroup.Location = new System.Drawing.Point(367, 114);
            this.newWorkGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newWorkGroup.Name = "newWorkGroup";
            this.newWorkGroup.Size = new System.Drawing.Size(320, 37);
            this.newWorkGroup.TabIndex = 19;
            // 
            // empID
            // 
            this.empID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.empID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.empID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empID.Location = new System.Drawing.Point(24, 39);
            this.empID.Margin = new System.Windows.Forms.Padding(4);
            this.empID.Name = "empID";
            this.empID.Size = new System.Drawing.Size(320, 34);
            this.empID.TabIndex = 3;
            this.empID.TextChanged += new System.EventHandler(this.empID_TextChanged);
            this.empID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.empID_KeyPress);
            // 
            // fullName
            // 
            this.fullName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.fullName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.fullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullName.Location = new System.Drawing.Point(24, 118);
            this.fullName.Margin = new System.Windows.Forms.Padding(4);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(320, 34);
            this.fullName.TabIndex = 5;
            // 
            // opEmail
            // 
            this.opEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.opEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.opEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opEmail.Location = new System.Drawing.Point(24, 194);
            this.opEmail.Margin = new System.Windows.Forms.Padding(4);
            this.opEmail.Name = "opEmail";
            this.opEmail.Size = new System.Drawing.Size(320, 34);
            this.opEmail.TabIndex = 7;
            // 
            // ftpEmail
            // 
            this.ftpEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ftpEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ftpEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ftpEmail.Location = new System.Drawing.Point(367, 39);
            this.ftpEmail.Margin = new System.Windows.Forms.Padding(4);
            this.ftpEmail.Name = "ftpEmail";
            this.ftpEmail.Size = new System.Drawing.Size(320, 34);
            this.ftpEmail.TabIndex = 9;
            // 
            // ntUsername
            // 
            this.ntUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ntUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ntUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntUsername.Location = new System.Drawing.Point(367, 194);
            this.ntUsername.Margin = new System.Windows.Forms.Padding(4);
            this.ntUsername.Name = "ntUsername";
            this.ntUsername.Size = new System.Drawing.Size(320, 34);
            this.ntUsername.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.label10.Location = new System.Drawing.Point(183, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(413, 49);
            this.label10.TabIndex = 38;
            this.label10.Text = "New Agent Information";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.changePWgb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 639);
            this.panel1.TabIndex = 0;
            // 
            // fadeIn
            // 
            this.fadeIn.Enabled = true;
            this.fadeIn.Interval = 30;
            this.fadeIn.Tick += new System.EventHandler(this.fadeIn_Tick);
            // 
            // RegisterNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 639);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RegisterNewUser";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register New User";
            this.Load += new System.EventHandler(this.RegisterNewUser_Load);
            this.changePWgb.ResumeLayout(false);
            this.changePWgb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adduserPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opaddPane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmaddPane)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel changePWgb;
        private System.Windows.Forms.Label xLabel;
        public System.Windows.Forms.PictureBox adduserPane;
        public System.Windows.Forms.PictureBox opaddPane;
        public System.Windows.Forms.PictureBox mmaddPane;
        public System.Windows.Forms.ComboBox newWorkGroup;
        public System.Windows.Forms.TextBox empID;
        public System.Windows.Forms.TextBox fullName;
        public System.Windows.Forms.TextBox opEmail;
        public System.Windows.Forms.TextBox ftpEmail;
        public System.Windows.Forms.TextBox ntUsername;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer fadeIn;
        public System.Windows.Forms.Button enterButton;
        public System.Windows.Forms.Panel panel5;
    }
}