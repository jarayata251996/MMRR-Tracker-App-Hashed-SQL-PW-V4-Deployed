namespace MMRR_Tracker
{
    partial class LoginForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.loadingScreen = new System.Windows.Forms.PictureBox();
			this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
			this.adminCredentialsGroup = new System.Windows.Forms.Panel();
			this.changePWgb = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.useradmPane = new System.Windows.Forms.PictureBox();
			this.opadmPane = new System.Windows.Forms.PictureBox();
			this.mmadmPane = new System.Windows.Forms.PictureBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.enterAdminpw = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.unshowPWadm = new System.Windows.Forms.PictureBox();
			this.showPWadm = new System.Windows.Forms.PictureBox();
			this.passadm_pictureBox = new System.Windows.Forms.PictureBox();
			this.adminPW_textBox = new System.Windows.Forms.TextBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.useradm_pictureBox = new System.Windows.Forms.PictureBox();
			this.ntUsername_textBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.versionAdm_Label = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.xLabel = new System.Windows.Forms.Label();
			this.userPane = new System.Windows.Forms.PictureBox();
			this.opPane = new System.Windows.Forms.PictureBox();
			this.mmPane = new System.Windows.Forms.PictureBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.changePW = new System.Windows.Forms.Button();
			this.enterButton = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.unshowPW = new System.Windows.Forms.PictureBox();
			this.showPW = new System.Windows.Forms.PictureBox();
			this.pass_pictureBox = new System.Windows.Forms.PictureBox();
			this.password_textBox = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.user_pictureBox = new System.Windows.Forms.PictureBox();
			this.userNT_textBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.fadeIn = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.loadingScreen)).BeginInit();
			this.adminCredentialsGroup.SuspendLayout();
			this.changePWgb.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.useradmPane)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.opadmPane)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mmadmPane)).BeginInit();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.unshowPWadm)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.showPWadm)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.passadm_pictureBox)).BeginInit();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.useradm_pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.userPane)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.opPane)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mmPane)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.unshowPW)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.showPW)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pass_pictureBox)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.user_pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// loadingScreen
			// 
			this.loadingScreen.Image = ((System.Drawing.Image)(resources.GetObject("loadingScreen.Image")));
			this.loadingScreen.Location = new System.Drawing.Point(103, 115);
			this.loadingScreen.Name = "loadingScreen";
			this.loadingScreen.Size = new System.Drawing.Size(288, 288);
			this.loadingScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.loadingScreen.TabIndex = 15;
			this.loadingScreen.TabStop = false;
			// 
			// backgroundWorker2
			// 
			this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
			this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
			// 
			// adminCredentialsGroup
			// 
			this.adminCredentialsGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
			this.adminCredentialsGroup.Controls.Add(this.linkLabel1);
			this.adminCredentialsGroup.Controls.Add(this.xLabel);
			this.adminCredentialsGroup.Controls.Add(this.userPane);
			this.adminCredentialsGroup.Controls.Add(this.opPane);
			this.adminCredentialsGroup.Controls.Add(this.mmPane);
			this.adminCredentialsGroup.Controls.Add(this.panel3);
			this.adminCredentialsGroup.Controls.Add(this.label3);
			this.adminCredentialsGroup.Controls.Add(this.versionLabel);
			this.adminCredentialsGroup.Controls.Add(this.changePWgb);
			this.adminCredentialsGroup.Location = new System.Drawing.Point(0, 0);
			this.adminCredentialsGroup.Margin = new System.Windows.Forms.Padding(2);
			this.adminCredentialsGroup.Name = "adminCredentialsGroup";
			this.adminCredentialsGroup.Size = new System.Drawing.Size(428, 488);
			this.adminCredentialsGroup.TabIndex = 16;
			// 
			// changePWgb
			// 
			this.changePWgb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
			this.changePWgb.Controls.Add(this.label1);
			this.changePWgb.Controls.Add(this.useradmPane);
			this.changePWgb.Controls.Add(this.opadmPane);
			this.changePWgb.Controls.Add(this.mmadmPane);
			this.changePWgb.Controls.Add(this.panel5);
			this.changePWgb.Controls.Add(this.label2);
			this.changePWgb.Controls.Add(this.versionAdm_Label);
			this.changePWgb.Location = new System.Drawing.Point(0, 0);
			this.changePWgb.Margin = new System.Windows.Forms.Padding(2);
			this.changePWgb.Name = "changePWgb";
			this.changePWgb.Size = new System.Drawing.Size(428, 488);
			this.changePWgb.TabIndex = 45;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
			this.label1.Location = new System.Drawing.Point(400, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 28);
			this.label1.TabIndex = 43;
			this.label1.Text = "X";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// useradmPane
			// 
			this.useradmPane.Image = global::MMRR_Tracker.Properties.Resources.useradm;
			this.useradmPane.Location = new System.Drawing.Point(164, 63);
			this.useradmPane.Margin = new System.Windows.Forms.Padding(2);
			this.useradmPane.Name = "useradmPane";
			this.useradmPane.Size = new System.Drawing.Size(104, 104);
			this.useradmPane.TabIndex = 42;
			this.useradmPane.TabStop = false;
			// 
			// opadmPane
			// 
			this.opadmPane.Image = global::MMRR_Tracker.Properties.Resources.opLong4;
			this.opadmPane.Location = new System.Drawing.Point(16, 29);
			this.opadmPane.Margin = new System.Windows.Forms.Padding(2);
			this.opadmPane.Name = "opadmPane";
			this.opadmPane.Size = new System.Drawing.Size(94, 23);
			this.opadmPane.TabIndex = 41;
			this.opadmPane.TabStop = false;
			this.opadmPane.Click += new System.EventHandler(this.opadmPane_Click);
			// 
			// mmadmPane
			// 
			this.mmadmPane.Image = global::MMRR_Tracker.Properties.Resources.Morgan___Morgan_Logo_svg;
			this.mmadmPane.Location = new System.Drawing.Point(318, 29);
			this.mmadmPane.Margin = new System.Windows.Forms.Padding(2);
			this.mmadmPane.Name = "mmadmPane";
			this.mmadmPane.Size = new System.Drawing.Size(94, 23);
			this.mmadmPane.TabIndex = 40;
			this.mmadmPane.TabStop = false;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.panel5.Controls.Add(this.enterAdminpw);
			this.panel5.Controls.Add(this.panel6);
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Location = new System.Drawing.Point(16, 227);
			this.panel5.Margin = new System.Windows.Forms.Padding(2);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(396, 192);
			this.panel5.TabIndex = 39;
			// 
			// enterAdminpw
			// 
			this.enterAdminpw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(155)))), ((int)(((byte)(207)))));
			this.enterAdminpw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.enterAdminpw.Cursor = System.Windows.Forms.Cursors.Hand;
			this.enterAdminpw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.enterAdminpw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.enterAdminpw.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.enterAdminpw.Location = new System.Drawing.Point(204, 140);
			this.enterAdminpw.Name = "enterAdminpw";
			this.enterAdminpw.Size = new System.Drawing.Size(182, 40);
			this.enterAdminpw.TabIndex = 39;
			this.enterAdminpw.Text = "CONFIRM";
			this.enterAdminpw.UseVisualStyleBackColor = false;
			this.enterAdminpw.Click += new System.EventHandler(this.enterAdminpw_Click);
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.White;
			this.panel6.Controls.Add(this.unshowPWadm);
			this.panel6.Controls.Add(this.showPWadm);
			this.panel6.Controls.Add(this.passadm_pictureBox);
			this.panel6.Controls.Add(this.adminPW_textBox);
			this.panel6.Location = new System.Drawing.Point(12, 77);
			this.panel6.Margin = new System.Windows.Forms.Padding(2);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(374, 51);
			this.panel6.TabIndex = 31;
			// 
			// unshowPWadm
			// 
			this.unshowPWadm.BackColor = System.Drawing.Color.White;
			this.unshowPWadm.Cursor = System.Windows.Forms.Cursors.Hand;
			this.unshowPWadm.Image = global::MMRR_Tracker.Properties.Resources.showKeyIcon;
			this.unshowPWadm.Location = new System.Drawing.Point(339, 15);
			this.unshowPWadm.Margin = new System.Windows.Forms.Padding(2);
			this.unshowPWadm.Name = "unshowPWadm";
			this.unshowPWadm.Size = new System.Drawing.Size(22, 24);
			this.unshowPWadm.TabIndex = 28;
			this.unshowPWadm.TabStop = false;
			this.unshowPWadm.Click += new System.EventHandler(this.unshowPWadm_Click);
			// 
			// showPWadm
			// 
			this.showPWadm.BackColor = System.Drawing.Color.White;
			this.showPWadm.Cursor = System.Windows.Forms.Cursors.Hand;
			this.showPWadm.Image = global::MMRR_Tracker.Properties.Resources.unshowKeyIcon;
			this.showPWadm.Location = new System.Drawing.Point(339, 15);
			this.showPWadm.Margin = new System.Windows.Forms.Padding(2);
			this.showPWadm.Name = "showPWadm";
			this.showPWadm.Size = new System.Drawing.Size(22, 24);
			this.showPWadm.TabIndex = 27;
			this.showPWadm.TabStop = false;
			this.showPWadm.Click += new System.EventHandler(this.showPWadm_Click);
			// 
			// passadm_pictureBox
			// 
			this.passadm_pictureBox.BackColor = System.Drawing.Color.White;
			this.passadm_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.passadm_pictureBox.Image = global::MMRR_Tracker.Properties.Resources.lockIcon;
			this.passadm_pictureBox.Location = new System.Drawing.Point(11, 11);
			this.passadm_pictureBox.Margin = new System.Windows.Forms.Padding(2);
			this.passadm_pictureBox.Name = "passadm_pictureBox";
			this.passadm_pictureBox.Size = new System.Drawing.Size(32, 29);
			this.passadm_pictureBox.TabIndex = 26;
			this.passadm_pictureBox.TabStop = false;
			// 
			// adminPW_textBox
			// 
			this.adminPW_textBox.BackColor = System.Drawing.Color.White;
			this.adminPW_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.adminPW_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.adminPW_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
			this.adminPW_textBox.Location = new System.Drawing.Point(66, 14);
			this.adminPW_textBox.Margin = new System.Windows.Forms.Padding(2);
			this.adminPW_textBox.Name = "adminPW_textBox";
			this.adminPW_textBox.Size = new System.Drawing.Size(268, 25);
			this.adminPW_textBox.TabIndex = 25;
			this.adminPW_textBox.UseSystemPasswordChar = true;
			this.adminPW_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.adminPW_textBox_KeyPress);
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.White;
			this.panel7.Controls.Add(this.useradm_pictureBox);
			this.panel7.Controls.Add(this.ntUsername_textBox);
			this.panel7.Location = new System.Drawing.Point(12, 14);
			this.panel7.Margin = new System.Windows.Forms.Padding(2);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(374, 51);
			this.panel7.TabIndex = 30;
			// 
			// useradm_pictureBox
			// 
			this.useradm_pictureBox.BackColor = System.Drawing.Color.White;
			this.useradm_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.useradm_pictureBox.Image = global::MMRR_Tracker.Properties.Resources.userIcon;
			this.useradm_pictureBox.Location = new System.Drawing.Point(11, 11);
			this.useradm_pictureBox.Margin = new System.Windows.Forms.Padding(2);
			this.useradm_pictureBox.Name = "useradm_pictureBox";
			this.useradm_pictureBox.Size = new System.Drawing.Size(32, 29);
			this.useradm_pictureBox.TabIndex = 25;
			this.useradm_pictureBox.TabStop = false;
			// 
			// ntUsername_textBox
			// 
			this.ntUsername_textBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.ntUsername_textBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.ntUsername_textBox.BackColor = System.Drawing.Color.White;
			this.ntUsername_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ntUsername_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ntUsername_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
			this.ntUsername_textBox.Location = new System.Drawing.Point(66, 14);
			this.ntUsername_textBox.Name = "ntUsername_textBox";
			this.ntUsername_textBox.Size = new System.Drawing.Size(268, 25);
			this.ntUsername_textBox.TabIndex = 24;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
			this.label2.Location = new System.Drawing.Point(124, 169);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(206, 39);
			this.label2.TabIndex = 38;
			this.label2.Text = "ADMIN LOGIN";
			// 
			// versionAdm_Label
			// 
			this.versionAdm_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.versionAdm_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
			this.versionAdm_Label.Location = new System.Drawing.Point(344, 466);
			this.versionAdm_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.versionAdm_Label.Name = "versionAdm_Label";
			this.versionAdm_Label.Size = new System.Drawing.Size(82, 20);
			this.versionAdm_Label.TabIndex = 36;
			this.versionAdm_Label.Text = "<version>";
			this.versionAdm_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkLabel1.Location = new System.Drawing.Point(14, 466);
			this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(108, 17);
			this.linkLabel1.TabIndex = 44;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "I am new user";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// xLabel
			// 
			this.xLabel.BackColor = System.Drawing.Color.Transparent;
			this.xLabel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.xLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
			this.xLabel.Location = new System.Drawing.Point(400, 1);
			this.xLabel.Name = "xLabel";
			this.xLabel.Size = new System.Drawing.Size(28, 28);
			this.xLabel.TabIndex = 43;
			this.xLabel.Text = "X";
			this.xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.xLabel.Click += new System.EventHandler(this.xLabel_Click);
			// 
			// userPane
			// 
			this.userPane.Image = global::MMRR_Tracker.Properties.Resources.user1;
			this.userPane.Location = new System.Drawing.Point(165, 63);
			this.userPane.Margin = new System.Windows.Forms.Padding(2);
			this.userPane.Name = "userPane";
			this.userPane.Size = new System.Drawing.Size(104, 104);
			this.userPane.TabIndex = 42;
			this.userPane.TabStop = false;
			// 
			// opPane
			// 
			this.opPane.Image = global::MMRR_Tracker.Properties.Resources.opLong4;
			this.opPane.Location = new System.Drawing.Point(16, 29);
			this.opPane.Margin = new System.Windows.Forms.Padding(2);
			this.opPane.Name = "opPane";
			this.opPane.Size = new System.Drawing.Size(94, 23);
			this.opPane.TabIndex = 41;
			this.opPane.TabStop = false;
			this.opPane.Click += new System.EventHandler(this.opPane_Click);
			// 
			// mmPane
			// 
			this.mmPane.Image = global::MMRR_Tracker.Properties.Resources.Morgan___Morgan_Logo_svg;
			this.mmPane.Location = new System.Drawing.Point(318, 29);
			this.mmPane.Margin = new System.Windows.Forms.Padding(2);
			this.mmPane.Name = "mmPane";
			this.mmPane.Size = new System.Drawing.Size(94, 23);
			this.mmPane.TabIndex = 40;
			this.mmPane.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
			this.panel3.Controls.Add(this.changePW);
			this.panel3.Controls.Add(this.enterButton);
			this.panel3.Controls.Add(this.panel2);
			this.panel3.Controls.Add(this.panel1);
			this.panel3.Location = new System.Drawing.Point(16, 227);
			this.panel3.Margin = new System.Windows.Forms.Padding(2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(396, 192);
			this.panel3.TabIndex = 39;
			// 
			// changePW
			// 
			this.changePW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
			this.changePW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.changePW.Cursor = System.Windows.Forms.Cursors.Hand;
			this.changePW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.changePW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.changePW.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
			this.changePW.Location = new System.Drawing.Point(12, 140);
			this.changePW.Name = "changePW";
			this.changePW.Size = new System.Drawing.Size(182, 40);
			this.changePW.TabIndex = 40;
			this.changePW.Text = "ADMIN CONTROL";
			this.changePW.UseVisualStyleBackColor = false;
			this.changePW.Click += new System.EventHandler(this.changePW_Click);
			// 
			// enterButton
			// 
			this.enterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(155)))), ((int)(((byte)(207)))));
			this.enterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.enterButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.enterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.enterButton.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.enterButton.Location = new System.Drawing.Point(204, 140);
			this.enterButton.Name = "enterButton";
			this.enterButton.Size = new System.Drawing.Size(182, 40);
			this.enterButton.TabIndex = 39;
			this.enterButton.Text = "LOGIN";
			this.enterButton.UseVisualStyleBackColor = false;
			this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.unshowPW);
			this.panel2.Controls.Add(this.showPW);
			this.panel2.Controls.Add(this.pass_pictureBox);
			this.panel2.Controls.Add(this.password_textBox);
			this.panel2.Location = new System.Drawing.Point(12, 77);
			this.panel2.Margin = new System.Windows.Forms.Padding(2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(374, 51);
			this.panel2.TabIndex = 31;
			// 
			// unshowPW
			// 
			this.unshowPW.BackColor = System.Drawing.Color.White;
			this.unshowPW.Cursor = System.Windows.Forms.Cursors.Hand;
			this.unshowPW.Image = global::MMRR_Tracker.Properties.Resources.showKeyIcon;
			this.unshowPW.Location = new System.Drawing.Point(339, 15);
			this.unshowPW.Margin = new System.Windows.Forms.Padding(2);
			this.unshowPW.Name = "unshowPW";
			this.unshowPW.Size = new System.Drawing.Size(22, 24);
			this.unshowPW.TabIndex = 28;
			this.unshowPW.TabStop = false;
			this.unshowPW.Click += new System.EventHandler(this.unshowPW_Click);
			// 
			// showPW
			// 
			this.showPW.BackColor = System.Drawing.Color.White;
			this.showPW.Cursor = System.Windows.Forms.Cursors.Hand;
			this.showPW.Image = global::MMRR_Tracker.Properties.Resources.unshowKeyIcon;
			this.showPW.Location = new System.Drawing.Point(339, 15);
			this.showPW.Margin = new System.Windows.Forms.Padding(2);
			this.showPW.Name = "showPW";
			this.showPW.Size = new System.Drawing.Size(22, 24);
			this.showPW.TabIndex = 27;
			this.showPW.TabStop = false;
			this.showPW.Click += new System.EventHandler(this.showPW_Click);
			// 
			// pass_pictureBox
			// 
			this.pass_pictureBox.BackColor = System.Drawing.Color.White;
			this.pass_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pass_pictureBox.Image = global::MMRR_Tracker.Properties.Resources.lockIcon;
			this.pass_pictureBox.Location = new System.Drawing.Point(11, 11);
			this.pass_pictureBox.Margin = new System.Windows.Forms.Padding(2);
			this.pass_pictureBox.Name = "pass_pictureBox";
			this.pass_pictureBox.Size = new System.Drawing.Size(32, 29);
			this.pass_pictureBox.TabIndex = 26;
			this.pass_pictureBox.TabStop = false;
			// 
			// password_textBox
			// 
			this.password_textBox.BackColor = System.Drawing.Color.White;
			this.password_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.password_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.password_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
			this.password_textBox.Location = new System.Drawing.Point(66, 14);
			this.password_textBox.Margin = new System.Windows.Forms.Padding(2);
			this.password_textBox.Name = "password_textBox";
			this.password_textBox.Size = new System.Drawing.Size(268, 25);
			this.password_textBox.TabIndex = 25;
			this.password_textBox.UseSystemPasswordChar = true;
			this.password_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.password_textBox_KeyPress);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.user_pictureBox);
			this.panel1.Controls.Add(this.userNT_textBox);
			this.panel1.Location = new System.Drawing.Point(12, 14);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(374, 51);
			this.panel1.TabIndex = 30;
			// 
			// user_pictureBox
			// 
			this.user_pictureBox.BackColor = System.Drawing.Color.White;
			this.user_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.user_pictureBox.Image = global::MMRR_Tracker.Properties.Resources.userIcon;
			this.user_pictureBox.Location = new System.Drawing.Point(11, 11);
			this.user_pictureBox.Margin = new System.Windows.Forms.Padding(2);
			this.user_pictureBox.Name = "user_pictureBox";
			this.user_pictureBox.Size = new System.Drawing.Size(32, 29);
			this.user_pictureBox.TabIndex = 25;
			this.user_pictureBox.TabStop = false;
			// 
			// userNT_textBox
			// 
			this.userNT_textBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.userNT_textBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.userNT_textBox.BackColor = System.Drawing.Color.White;
			this.userNT_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.userNT_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.userNT_textBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
			this.userNT_textBox.Location = new System.Drawing.Point(66, 14);
			this.userNT_textBox.Name = "userNT_textBox";
			this.userNT_textBox.Size = new System.Drawing.Size(268, 25);
			this.userNT_textBox.TabIndex = 24;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label3.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
			this.label3.Location = new System.Drawing.Point(124, 169);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(201, 39);
			this.label3.TabIndex = 38;
			this.label3.Text = "AGENT LOGIN";
			// 
			// versionLabel
			// 
			this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
			this.versionLabel.Location = new System.Drawing.Point(344, 466);
			this.versionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(82, 20);
			this.versionLabel.TabIndex = 36;
			this.versionLabel.Text = "<version>";
			this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// fadeIn
			// 
			this.fadeIn.Enabled = true;
			this.fadeIn.Interval = 30;
			this.fadeIn.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Magenta;
			this.ClientSize = new System.Drawing.Size(428, 488);
			this.Controls.Add(this.adminCredentialsGroup);
			this.Controls.Add(this.loadingScreen);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoginForm";
			this.Opacity = 0D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MMRR Tracker";
			this.Load += new System.EventHandler(this.LoginForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.loadingScreen)).EndInit();
			this.adminCredentialsGroup.ResumeLayout(false);
			this.adminCredentialsGroup.PerformLayout();
			this.changePWgb.ResumeLayout(false);
			this.changePWgb.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.useradmPane)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.opadmPane)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mmadmPane)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.unshowPWadm)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.showPWadm)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.passadm_pictureBox)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.useradm_pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.userPane)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.opPane)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mmPane)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.unshowPW)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.showPW)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pass_pictureBox)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.user_pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox loadingScreen;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Panel adminCredentialsGroup;
        private System.Windows.Forms.Label xLabel;
        public System.Windows.Forms.PictureBox userPane;
        public System.Windows.Forms.PictureBox opPane;
        public System.Windows.Forms.PictureBox mmPane;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.PictureBox unshowPW;
        public System.Windows.Forms.PictureBox showPW;
        public System.Windows.Forms.PictureBox pass_pictureBox;
        public System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox user_pictureBox;
        public System.Windows.Forms.TextBox userNT_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label versionLabel;
        public System.Windows.Forms.Button enterButton;
        public System.Windows.Forms.Button changePW;
        private System.Windows.Forms.Panel changePWgb;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox useradmPane;
        public System.Windows.Forms.PictureBox opadmPane;
        public System.Windows.Forms.PictureBox mmadmPane;
        public System.Windows.Forms.Button enterAdminpw;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.PictureBox unshowPWadm;
        public System.Windows.Forms.PictureBox showPWadm;
        public System.Windows.Forms.PictureBox passadm_pictureBox;
        public System.Windows.Forms.TextBox adminPW_textBox;
        private System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.PictureBox useradm_pictureBox;
        public System.Windows.Forms.TextBox ntUsername_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label versionAdm_Label;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Timer fadeIn;
        public System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Panel panel3;
	}
}