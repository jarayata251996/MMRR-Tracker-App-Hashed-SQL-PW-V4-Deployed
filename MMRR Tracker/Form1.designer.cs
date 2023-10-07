
namespace MMRR_Tracker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.detectedGroup = new System.Windows.Forms.Label();
            this.first_button = new System.Windows.Forms.Button();
            this.second_button = new System.Windows.Forms.Button();
            this.third_button = new System.Windows.Forms.Button();
            this.powerBi = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.activityLogButton = new System.Windows.Forms.Button();
            this.rtaPivotView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.version_Label = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.btn_minimize = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.panelMain1 = new System.Windows.Forms.Panel();
            this.fadeIn = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            this.panelMain1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.panelMenu.Controls.Add(this.flowLayoutPanel1);
            this.panelMenu.Location = new System.Drawing.Point(0, 73);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(281, 940);
            this.panelMenu.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.first_button);
            this.flowLayoutPanel1.Controls.Add(this.second_button);
            this.flowLayoutPanel1.Controls.Add(this.third_button);
            this.flowLayoutPanel1.Controls.Add(this.powerBi);
            this.flowLayoutPanel1.Controls.Add(this.editButton);
            this.flowLayoutPanel1.Controls.Add(this.activityLogButton);
            this.flowLayoutPanel1.Controls.Add(this.rtaPivotView);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.version_Label);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(281, 940);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(13, 13);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pictureBox2.Size = new System.Drawing.Size(251, 89);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 210);
            this.panel1.TabIndex = 2;
            // 
            // detectedGroup
            // 
            this.detectedGroup.AutoSize = true;
            this.detectedGroup.BackColor = System.Drawing.Color.Transparent;
            this.detectedGroup.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detectedGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.detectedGroup.Location = new System.Drawing.Point(-2, -2);
            this.detectedGroup.Margin = new System.Windows.Forms.Padding(0);
            this.detectedGroup.Name = "detectedGroup";
            this.detectedGroup.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.detectedGroup.Size = new System.Drawing.Size(154, 47);
            this.detectedGroup.TabIndex = 11;
            this.detectedGroup.Text = "<User/Group>";
            this.detectedGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // first_button
            // 
            this.first_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(255)))), ((int)(((byte)(253)))));
            this.first_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.first_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.first_button.FlatAppearance.BorderSize = 0;
            this.first_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.first_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.first_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.first_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.first_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.first_button.Image = ((System.Drawing.Image)(resources.GetObject("first_button.Image")));
            this.first_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.first_button.Location = new System.Drawing.Point(3, 216);
            this.first_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.first_button.Name = "first_button";
            this.first_button.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.first_button.Size = new System.Drawing.Size(276, 74);
            this.first_button.TabIndex = 0;
            this.first_button.Text = "&Intake Group";
            this.first_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.first_button.UseVisualStyleBackColor = false;
            this.first_button.Click += new System.EventHandler(this.first_button_Click);
            // 
            // second_button
            // 
            this.second_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.second_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.second_button.FlatAppearance.BorderSize = 0;
            this.second_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.second_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.second_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.second_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.second_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.second_button.Image = ((System.Drawing.Image)(resources.GetObject("second_button.Image")));
            this.second_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.second_button.Location = new System.Drawing.Point(3, 294);
            this.second_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.second_button.Name = "second_button";
            this.second_button.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.second_button.Size = new System.Drawing.Size(276, 74);
            this.second_button.TabIndex = 1;
            this.second_button.Text = "&Pending Group";
            this.second_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.second_button.UseVisualStyleBackColor = true;
            this.second_button.Click += new System.EventHandler(this.second_button_Click);
            // 
            // third_button
            // 
            this.third_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.third_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.third_button.FlatAppearance.BorderSize = 0;
            this.third_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.third_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.third_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.third_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.third_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.third_button.Image = ((System.Drawing.Image)(resources.GetObject("third_button.Image")));
            this.third_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.third_button.Location = new System.Drawing.Point(3, 372);
            this.third_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.third_button.Name = "third_button";
            this.third_button.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.third_button.Size = new System.Drawing.Size(276, 74);
            this.third_button.TabIndex = 2;
            this.third_button.Text = "&Comp/Esca Group";
            this.third_button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.third_button.UseVisualStyleBackColor = true;
            this.third_button.Click += new System.EventHandler(this.third_button_Click);
            // 
            // powerBi
            // 
            this.powerBi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.powerBi.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.powerBi.FlatAppearance.BorderSize = 0;
            this.powerBi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.powerBi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.powerBi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.powerBi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.powerBi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.powerBi.Image = ((System.Drawing.Image)(resources.GetObject("powerBi.Image")));
            this.powerBi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.powerBi.Location = new System.Drawing.Point(3, 450);
            this.powerBi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.powerBi.Name = "powerBi";
            this.powerBi.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.powerBi.Size = new System.Drawing.Size(276, 74);
            this.powerBi.TabIndex = 7;
            this.powerBi.Text = "&PowerBI Report";
            this.powerBi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.powerBi.UseVisualStyleBackColor = true;
            this.powerBi.Click += new System.EventHandler(this.powerBi_Click);
            // 
            // editButton
            // 
            this.editButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editButton.FlatAppearance.BorderSize = 0;
            this.editButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.editButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.editButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.editButton.Image = ((System.Drawing.Image)(resources.GetObject("editButton.Image")));
            this.editButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editButton.Location = new System.Drawing.Point(3, 528);
            this.editButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editButton.Name = "editButton";
            this.editButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.editButton.Size = new System.Drawing.Size(276, 74);
            this.editButton.TabIndex = 6;
            this.editButton.Text = "&Search / Edit Records";
            this.editButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // activityLogButton
            // 
            this.activityLogButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activityLogButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.activityLogButton.FlatAppearance.BorderSize = 0;
            this.activityLogButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.activityLogButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.activityLogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activityLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.activityLogButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.activityLogButton.Image = ((System.Drawing.Image)(resources.GetObject("activityLogButton.Image")));
            this.activityLogButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.activityLogButton.Location = new System.Drawing.Point(3, 606);
            this.activityLogButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.activityLogButton.Name = "activityLogButton";
            this.activityLogButton.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.activityLogButton.Size = new System.Drawing.Size(276, 74);
            this.activityLogButton.TabIndex = 9;
            this.activityLogButton.Text = "&Import Data";
            this.activityLogButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.activityLogButton.UseVisualStyleBackColor = true;
            this.activityLogButton.Click += new System.EventHandler(this.activityLogButton_Click);
            // 
            // rtaPivotView
            // 
            this.rtaPivotView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rtaPivotView.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rtaPivotView.FlatAppearance.BorderSize = 0;
            this.rtaPivotView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.rtaPivotView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.rtaPivotView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rtaPivotView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.rtaPivotView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.rtaPivotView.Image = ((System.Drawing.Image)(resources.GetObject("rtaPivotView.Image")));
            this.rtaPivotView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rtaPivotView.Location = new System.Drawing.Point(3, 684);
            this.rtaPivotView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtaPivotView.Name = "rtaPivotView";
            this.rtaPivotView.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.rtaPivotView.Size = new System.Drawing.Size(276, 74);
            this.rtaPivotView.TabIndex = 10;
            this.rtaPivotView.Text = "&RTA Pivot View";
            this.rtaPivotView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rtaPivotView.UseVisualStyleBackColor = true;
            this.rtaPivotView.Click += new System.EventHandler(this.rtaPivotView_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.label1.Location = new System.Drawing.Point(0, 760);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.label1.Size = new System.Drawing.Size(262, 116);
            this.label1.TabIndex = 5;
            this.label1.Text = "Developer Information:\r\nOffice Partners 360\r\nBusiness Intelligence\r\nbidev@officep" +
    "artners360.com";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // version_Label
            // 
            this.version_Label.AutoSize = true;
            this.version_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version_Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.version_Label.Location = new System.Drawing.Point(3, 876);
            this.version_Label.Name = "version_Label";
            this.version_Label.Size = new System.Drawing.Size(74, 18);
            this.version_Label.TabIndex = 11;
            this.version_Label.Text = "<version>";
            this.version_Label.Click += new System.EventHandler(this.version_Label_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.panelTitle.Controls.Add(this.btn_minimize);
            this.panelTitle.Controls.Add(this.btn_close);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(281, 73);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseMove);
            // 
            // btn_minimize
            // 
            this.btn_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimize.Image = global::MMRR_Tracker.Properties.Resources.min;
            this.btn_minimize.Location = new System.Drawing.Point(191, 23);
            this.btn_minimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(29, 28);
            this.btn_minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_minimize.TabIndex = 2;
            this.btn_minimize.TabStop = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Image = global::MMRR_Tracker.Properties.Resources.close;
            this.btn_close.Location = new System.Drawing.Point(232, 19);
            this.btn_close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(32, 37);
            this.btn_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_close.TabIndex = 0;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panelMain1
            // 
            this.panelMain1.AutoSize = true;
            this.panelMain1.BackColor = System.Drawing.Color.Gray;
            this.panelMain1.Controls.Add(this.panelTitle);
            this.panelMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain1.Location = new System.Drawing.Point(0, 0);
            this.panelMain1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMain1.Name = "panelMain1";
            this.panelMain1.Size = new System.Drawing.Size(281, 1013);
            this.panelMain1.TabIndex = 0;
            // 
            // fadeIn
            // 
            this.fadeIn.Enabled = true;
            this.fadeIn.Interval = 30;
            this.fadeIn.Tick += new System.EventHandler(this.fadeIn_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(235)))), ((int)(((byte)(82)))), ((int)(((byte)(110)))));
            this.panel2.Controls.Add(this.detectedGroup);
            this.panel2.Location = new System.Drawing.Point(13, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 81);
            this.panel2.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(83)))), ((int)(((byte)(147)))));
            this.ClientSize = new System.Drawing.Size(281, 1013);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelMain1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MMRR Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            this.panelMain1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btn_minimize;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.Panel panelMain1;
        private System.Windows.Forms.Label detectedGroup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer fadeIn;
        private System.Windows.Forms.Label version_Label;
        public System.Windows.Forms.Panel panelTitle;
        public System.Windows.Forms.Button third_button;
        public System.Windows.Forms.Button second_button;
        public System.Windows.Forms.Button first_button;
        public System.Windows.Forms.Button editButton;
        public System.Windows.Forms.Button powerBi;
        public System.Windows.Forms.Button activityLogButton;
        public System.Windows.Forms.Button rtaPivotView;
        public System.Windows.Forms.Panel panel2;
    }
}

