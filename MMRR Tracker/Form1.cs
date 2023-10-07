using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Data.SqlClient;

namespace MMRR_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Height = Screen.PrimaryScreen.WorkingArea.Size.Height;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fadeIn.Start();
            if(DBHelper.connection.State == ConnectionState.Closed){
                DBHelper.connection.Open();
            }
            panelMenu.Visible = true;
            detectedGroup.Text = DBHelper.fullName + "\n" + DBHelper.workGroup + "\n";
            version_Label.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //MessageBox.Show(Size.ToString());
            //this.Size = new Size(1685, 807);
        }

        #region DesigningForm
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //Main panel sizing
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.Invalidate();
        }
        //SizingGrip
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Application.OpenForms["Form1"].Close();
        }
   
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        //for Main panel
        //private void CallingForms<formname>() where formname : Form, new()
        //{
        //    Form forms;
        //    forms = panelMain.Controls.OfType<formname>().FirstOrDefault();

        //    if (forms == null)
        //    {
        //        forms = new formname();
        //        forms.TopLevel = false;
        //        forms.FormBorderStyle = FormBorderStyle.None;//pede icomment for different approach
        //        forms.Dock = DockStyle.Fill;//pede icomment for different approach
        //        forms.WindowState = FormWindowState.Maximized;
        //        panelMain.Controls.Add(forms);
        //        panelMain.Tag = forms;
        //        forms.Show();
        //        forms.BringToFront();
        //        forms.FormClosed += new FormClosedEventHandler(CloseForms);
        //    }
        //    else
        //    {
        //        forms.BringToFront();
        //    }
        //}

        private void first_button_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SubmissionForm"] == null)
            {
                if (DBHelper.workGroup.Contains("Intake") || DBHelper.workGroup.Contains("Developer"))
                {
                    //these codes switches the colors of the buttons when clicked.
                    first_button.BackColor = Color.FromArgb(183, 153, 255);
                    second_button.BackColor = Color.FromArgb(230, 255, 253);
                    third_button.BackColor = Color.FromArgb(230, 255, 253);
                    powerBi.BackColor = Color.FromArgb(230, 255, 253);
                    editButton.BackColor = Color.FromArgb(230, 255, 253);
                    activityLogButton.BackColor = Color.FromArgb(230, 255, 253);
                    rtaPivotView.BackColor = Color.FromArgb(230, 255, 253);

                    SubmissionForm submission = new SubmissionForm(DBHelper.fullName, DBHelper.workGroup);
                    submission.Show();
                }
                else
                {
                    MessageBox.Show("You are not allowed to this tracker!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void second_button_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SubmissionForm"] == null)
            {
                if (DBHelper.workGroup.Contains("Pending") || DBHelper.workGroup.Contains("Developer"))
                {
                    //these codes switches the colors of the buttons when clicked.
                    first_button.BackColor = Color.FromArgb(230, 255, 253);
                    second_button.BackColor = Color.FromArgb(183, 153, 255);
                    third_button.BackColor = Color.FromArgb(230, 255, 253);
                    powerBi.BackColor = Color.FromArgb(230, 255, 253);
                    editButton.BackColor = Color.FromArgb(230, 255, 253);
                    activityLogButton.BackColor = Color.FromArgb(230, 255, 253);
                    rtaPivotView.BackColor = Color.FromArgb(230, 255, 253);

                    SubmissionForm submission = new SubmissionForm(DBHelper.fullName, DBHelper.workGroup);
                    submission.Show();
                }
                else
                {
                    MessageBox.Show("You are not allowed to this tracker!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void powerBi_Click(object sender, EventArgs e)
        {
            //these codes switches the colors of the buttons when clicked.
            first_button.BackColor = Color.FromArgb(230, 255, 253);
            second_button.BackColor = Color.FromArgb(230, 255, 253);
            third_button.BackColor = Color.FromArgb(230, 255, 253);
            powerBi.BackColor = Color.FromArgb(183, 153, 255);
            editButton.BackColor = Color.FromArgb(230, 255, 253);
            activityLogButton.BackColor = Color.FromArgb(230, 255, 253);
            rtaPivotView.BackColor = Color.FromArgb(230, 255, 253);

            ProcessStartInfo sInfo1 = new ProcessStartInfo("https://app.powerbi.com/view?r=eyJrIjoiNjRmNzkwMzQtNzA3Mi00NTcyLTgxZTYtNTRhNDVmYzRjZTdkIiwidCI6IjExYmJmNDIwLWI2MjAtNDM3OS1iMjBiLTUyMWI0ZGU1Mjg3ZSIsImMiOjF9");
            Process.Start(sInfo1);            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo2 = new ProcessStartInfo("https://www.op360.com/philippines/");
            Process.Start(sInfo2);
        }

        private void activityLogButton_Click(object sender, EventArgs e)
        {
                if (Application.OpenForms["UploadForm"] == null)
                {
                    if (DBHelper.workGroup.Contains("RTA") || DBHelper.workGroup.Contains("Developer"))
                    {
                        //these codes switches the colors of the buttons when clicked.
                        first_button.BackColor = Color.FromArgb(230, 255, 253);
                        second_button.BackColor = Color.FromArgb(230, 255, 253);
                        third_button.BackColor = Color.FromArgb(230, 255, 253);
                        powerBi.BackColor = Color.FromArgb(230, 255, 253);
                        editButton.BackColor = Color.FromArgb(230, 255, 253);
                        activityLogButton.BackColor = Color.FromArgb(183, 153, 255);
                        rtaPivotView.BackColor = Color.FromArgb(230, 255, 253);

                    UploadForm uploadForm = new UploadForm();
                        uploadForm.Show();
                    }
                    else
                    {
                    MessageBox.Show("You are not allowed to this feature!", "MMRR App", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            if (panelMenu.Visible == true)
            {
                panelMenu.Visible = false;
            }
            else
            {
                panelMenu.Visible = true;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["Bulk_Editing_and_Assigning"] == null)
            {
                //these codes switches the colors of the buttons when clicked.
                first_button.BackColor = Color.FromArgb(230, 255, 253);
                second_button.BackColor = Color.FromArgb(230, 255, 253);
                third_button.BackColor = Color.FromArgb(230, 255, 253);
                powerBi.BackColor = Color.FromArgb(230, 255, 253);
                editButton.BackColor = Color.FromArgb(183, 153, 255);
                activityLogButton.BackColor = Color.FromArgb(230, 255, 253);
                rtaPivotView.BackColor = Color.FromArgb(230, 255, 253);

                Submission_CS.Bulk_Editing_and_Assigning editRecords = new Submission_CS.Bulk_Editing_and_Assigning();
                editRecords.Show();
            }
        }

        private void rtaPivotView_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["RTA_Ticketing_Assignment_View"] == null)
            {
                if (DBHelper.workGroup.Contains("RTA") || DBHelper.workGroup.Contains("Developer") || DBHelper.workGroup.Contains("Admin"))
                {
                    //these codes switches the colors of the buttons when clicked.
                    first_button.BackColor = Color.FromArgb(230, 255, 253);
                    second_button.BackColor = Color.FromArgb(230, 255, 253);
                    third_button.BackColor = Color.FromArgb(230, 255, 253);
                    powerBi.BackColor = Color.FromArgb(230, 255, 253);
                    editButton.BackColor = Color.FromArgb(230, 255, 253);
                    activityLogButton.BackColor = Color.FromArgb(230, 255, 253);
                    rtaPivotView.BackColor = Color.FromArgb(183, 153, 255);

                    RTA_Ticketing_Assignment_View rtaView = new RTA_Ticketing_Assignment_View();
                    rtaView.Show();
                }
                else
                {
                    MessageBox.Show("You are not allowed to this feature!", "MMRR App", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void fadeIn_Tick(object sender, EventArgs e)
        {
            if (Opacity < 1)
            {
                Opacity += 0.05;
            }
            else
            {
                fadeIn.Enabled = false;
            }
        }

        private void version_Label_Click(object sender, EventArgs e)
        {
            StyleHelper.ApplyStyleLoginOP360(this);
        }

        private void third_button_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["SubmissionForm"] == null)
            {
                if (DBHelper.workGroup.Contains("Completion") || DBHelper.workGroup.Contains("Developer") || DBHelper.workGroup.Contains("Escalation"))
                {
                    //these codes switches the colors of the buttons when clicked.
                    first_button.BackColor = Color.FromArgb(230, 255, 253);
                    second_button.BackColor = Color.FromArgb(230, 255, 253);
                    third_button.BackColor = Color.FromArgb(183, 153, 255);
                    powerBi.BackColor = Color.FromArgb(230, 255, 253);
                    editButton.BackColor = Color.FromArgb(230, 255, 253);
                    activityLogButton.BackColor = Color.FromArgb(230, 255, 253);
                    rtaPivotView.BackColor = Color.FromArgb(230, 255, 253);

                    SubmissionForm submission = new SubmissionForm(DBHelper.fullName, DBHelper.workGroup);
                    submission.Show();
                }
                else
                {
                    MessageBox.Show("You are not allowed to this tracker!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            //if(Application.OpenForms["FirstForm"] == null)
            //{
            //    first_button.BackColor = Color.FromArgb(4, 41, 68);
            //}
            //if (Application.OpenForms["SecondForm"] == null)
            //{
            //    second_button.BackColor = Color.FromArgb(4, 41, 68);
            //}
            //if (Application.OpenForms["ThirdForm"] == null)
            //{
            //    button1.BackColor = Color.FromArgb(4, 41, 68);
            //}
        }
    }
}
