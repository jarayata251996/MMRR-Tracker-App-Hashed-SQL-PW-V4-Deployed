using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MMRR_Tracker.Submission_CS
{
    public static class StyleHelper_CS
    {
        public static void ApplyStyleLoginOP360(searchFieldInbulk form)
        {
            form.PanelText.BackColor = Color.FromArgb(235, 82, 110); //op pink
            form.button2.BackColor = Color.FromArgb(71, 92, 229); //royal blue
        }

        public static void ApplyStyleLoginOP360(Bulk_Editing_and_Assigning form)
        {
            form.menuStrip1.BackColor = Color.FromArgb(235, 82, 110); //op pink
        }
    }
}

namespace MMRR_Tracker
{
    public static class StyleHelper
    {
        // Placeholder text for the TextBox
        //Login Placeholder
        private const string userPlaceholderText = "OP360 Username";
        private const string passPlaceholderText = "Password";

        //Register Placeholder
        private const string empIDPlaceholderText = "Employee ID";
        private const string ftpPlaceholderText = "FTP Email";
        private const string fnPlaceholderText = "Full Name";
        private const string wgPlaceholderText = "Work Group";
        private const string emailPlaceholderText = "Email";
        private const string ntPlaceholderText = "NT Username";

        //Change Agent Placeholder
        private const string empfnPlaceholderText = "Full Name";
        private const string newWgPlaceholderText = "New Work Group";

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        #region Login Style OP360
        public static void ApplyStyleLoginOP360(LoginForm form)
        {
            form.panel5.BackColor = Color.FromArgb(235, 82, 110); //op pink
            form.enterAdminpw.BackColor = Color.FromArgb(71, 92, 229); //royal blue
            form.enterButton.BackColor = Color.FromArgb(71, 92, 229); //royal blue
            form.panel3.BackColor = Color.FromArgb(235, 82, 110); //op pink
        }

        public static void ApplyStyleLoginOP360(ChangePassword form)
        {
            form.panel5.BackColor = Color.FromArgb(235, 82, 110); //op pink
            form.enterButton.BackColor = Color.FromArgb(71, 92, 229); //royal blue

        }

        public static void ApplyStyleLoginOP360(RegisterNewUser form)
        {
            form.panel5.BackColor = Color.FromArgb(235, 82, 110); //op pink
            form.enterButton.BackColor = Color.FromArgb(71, 92, 229); //royal blue
        }

        public static void ApplyStyleLoginOP360(UploadForm form)
        {
            form.panel2.BackColor = Color.FromArgb(235, 82, 110); //op pink
            form.importButton.BackColor = Color.FromArgb(71, 92, 229); //royal blue
            form.confirmButton.BackColor = Color.FromArgb(71, 92, 229); //royal blue
        }

        public static void ApplyStyleLoginOP360(Form1 form)
        {
            form.panelTitle.BackColor = Color.FromArgb(235, 82, 110); //op pink
            form.panel2.BackColor = Color.FromArgb(235, 82, 110); //op pink
        }

        public static void ApplyStyleLoginOP360(SubmissionForm form)
        {
            form.panel9.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel3.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel4.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel5.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel7.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel10.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel11.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel12.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel13.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel14.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel15.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel16.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel17.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel18.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel19.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel20.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel21.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel22.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel23.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel24.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel25.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel26.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel27.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel28.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel29.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel30.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel31.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel32.BackColor = Color.FromArgb(245, 150, 167); //op pink
            form.panel33.BackColor = Color.FromArgb(245, 150, 167); //op pink

            form.button1.BackColor = Color.FromArgb(136, 152, 255); //royal blue
            form.button2.BackColor = Color.FromArgb(136, 152, 255); //royal blue
            form.button3.BackColor = Color.FromArgb(136, 152, 255); //royal blue

            form.button1.ForeColor = Color.FromArgb(245, 245, 245); //royal blue
            form.button2.ForeColor = Color.FromArgb(245, 245, 245); //royal blue
            form.button3.ForeColor = Color.FromArgb(245, 245, 245); //royal blue
        }

        //public static void ApplyStyleLoginOP360(RTA_Ticketing_Assignment_View form)
        //{
        //    form.flowLayoutPanel1.BackColor = Color.FromArgb(235, 82, 110); //op pink
        //    form.button1.BackColor = Color.FromArgb(71, 92, 229); //royal blue
        //    form.button2.BackColor = Color.FromArgb(71, 92, 229); //royal blue
        //    form.button3.BackColor = Color.FromArgb(71, 92, 229); //royal blue
        //    form.Completed.BackColor = Color.FromArgb(71, 92, 229); //royal blue
        //}
        #endregion

        #region Login Style
        public static void ApplyStyleLogin(LoginForm form)
        {
            //form.adminCredentialsGroup.BackColor = Color.FromArgb(74, 196, 181);
            //form.changePWgb.BackColor = Color.FromArgb(74, 196, 181);

            //placeholder for admin user textbox
            form.ntUsername_textBox.ForeColor = Color.Gray;
            form.ntUsername_textBox.Text = userPlaceholderText;
            form.ntUsername_textBox.Enter += UserNT_textBox_Enter;
            form.ntUsername_textBox.Leave += UserNT_textBox_Leave;

            //placeholder for admin password textbox
            form.adminPW_textBox.ForeColor = Color.Gray;
            form.adminPW_textBox.Text = passPlaceholderText;
            form.adminPW_textBox.Enter += Password_textBox_Enter;
            form.adminPW_textBox.Leave += Password_textBox_Leave;

            //placeholder for user textbox
            form.userNT_textBox.Text = userPlaceholderText;
            form.userNT_textBox.ForeColor = Color.Gray;
            form.userNT_textBox.Enter += UserNT_textBox_Enter;
            form.userNT_textBox.Leave += UserNT_textBox_Leave;

            //placeholder for password textbox
            form.password_textBox.Text = passPlaceholderText;
            form.password_textBox.ForeColor = Color.Gray;
            form.password_textBox.Enter += Password_textBox_Enter;
            form.password_textBox.Leave += Password_textBox_Leave;

            //show.unshow picturebox
            form.unshowPW.SizeMode = PictureBoxSizeMode.StretchImage;
            form.showPW.SizeMode = PictureBoxSizeMode.StretchImage;
            form.unshowPWadm.SizeMode = PictureBoxSizeMode.StretchImage;
            form.showPWadm.SizeMode = PictureBoxSizeMode.StretchImage;

            //label picturebox
            form.user_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            form.pass_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            form.useradm_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            form.passadm_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            //logo picturebox
            form.opPane.SizeMode = PictureBoxSizeMode.StretchImage;
            form.mmPane.SizeMode = PictureBoxSizeMode.StretchImage;
            form.userPane.SizeMode = PictureBoxSizeMode.StretchImage;

            //logo adm picturebox
            form.opadmPane.SizeMode = PictureBoxSizeMode.StretchImage;
            form.mmadmPane.SizeMode = PictureBoxSizeMode.StretchImage;
            form.useradmPane.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        

        //Username
        private static void UserNT_textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == userPlaceholderText)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.FromArgb(56,56,56);
            }
        }

        private static void UserNT_textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = userPlaceholderText;
                textBox.ForeColor = Color.Gray;
            }
        }

        //Password
        private static void Password_textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == passPlaceholderText)
            {
                textBox.Text = string.Empty;
                textBox.UseSystemPasswordChar = true;
                textBox.ForeColor = Color.FromArgb(56, 56, 56);
            }
        }

        private static void Password_textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = passPlaceholderText;
                textBox.UseSystemPasswordChar = false;
                textBox.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region Register Agent Style

        public static void ApplyStyleRegister(RegisterNewUser form)
        {
            form.empID.ForeColor = Color.Gray;
            form.empID.Text = "Employee ID";
            form.empID.Enter += empID_Enter;
            form.empID.Leave += empID_Leave;

            form.ftpEmail.ForeColor = Color.Gray;
            form.ftpEmail.Text = "FTP Email";
            form.ftpEmail.Enter += ftpEmail_Enter;
            form.ftpEmail.Leave += ftpEmail_Leave;

            form.fullName.ForeColor = Color.Gray;
            form.fullName.Text = "Full Name";
            form.fullName.Enter += fullName_Enter;
            form.fullName.Leave += fullName_Leave;

            form.newWorkGroup.ForeColor = Color.Gray;
            form.newWorkGroup.Text = "Work Group";
            form.newWorkGroup.Enter += newWorkGroup_Enter;
            form.newWorkGroup.Leave += newWorkGroup_Leave;

            form.opEmail.ForeColor = Color.Gray;
            form.opEmail.Text = "Email";
            form.opEmail.Enter += opEmail_Enter;
            form.opEmail.Leave += opEmail_Leave;

            form.ntUsername.ForeColor = Color.Gray;
            form.ntUsername.Text = "NT Username";
            form.ntUsername.Enter += ntUsername_Enter;
            form.ntUsername.Leave += ntUsername_Leave;

            //logo add user picturebox
            form.opaddPane.SizeMode = PictureBoxSizeMode.StretchImage;
            form.mmaddPane.SizeMode = PictureBoxSizeMode.StretchImage;
            form.adduserPane.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //Emp ID
        private static void empID_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == empIDPlaceholderText)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.FromArgb(56, 56, 56);
            }
        }

        private static void empID_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = empIDPlaceholderText;
                textBox.ForeColor = Color.Gray;
            }
        }

        //FTP Email
        private static void ftpEmail_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == ftpPlaceholderText)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.FromArgb(56, 56, 56);
            }
        }

        private static void ftpEmail_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = ftpPlaceholderText;
                textBox.ForeColor = Color.Gray;
            }
        }
        //Full Name
        private static void fullName_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == fnPlaceholderText)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.FromArgb(56, 56, 56);
            }
        }

        private static void fullName_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = fnPlaceholderText;
                textBox.ForeColor = Color.Gray;
            }
        }

        //Work Group
        private static void newWorkGroup_Enter(object sender, EventArgs e)
        {
            ComboBox comboText = (ComboBox)sender;
            if (comboText.Text == wgPlaceholderText)
            {
                comboText.Text = string.Empty;
                comboText.ForeColor = Color.FromArgb(56, 56, 56);
            }
        }

        private static void newWorkGroup_Leave(object sender, EventArgs e)
        {
            ComboBox comboText = (ComboBox)sender;
            if (string.IsNullOrWhiteSpace(comboText.Text))
            {
                comboText.Text = wgPlaceholderText;
                comboText.ForeColor = Color.Gray;
            }
        }

        //Email
        private static void opEmail_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == emailPlaceholderText)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.FromArgb(56, 56, 56);
            }
        }

        private static void opEmail_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = emailPlaceholderText;
                textBox.ForeColor = Color.Gray;
            }
        }

        //NT Username
        private static void ntUsername_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == ntPlaceholderText)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.FromArgb(56, 56, 56);
            }
        }

        private static void ntUsername_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = ntPlaceholderText;
                textBox.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region Change Agent Information
        public static void ApplyStyleChangeAgent(ChangePassword form)
        {
            //placeholder for full name textbox
            form.empNumber_textBox.ForeColor = Color.Gray;
            form.empNumber_textBox.Text = empfnPlaceholderText;
            form.empNumber_textBox.Enter += empFullname_Enter;
            form.empNumber_textBox.Leave += empFullname_Leave;

            //placeholder for work group drop down
            form.newWorkGroup.ForeColor = Color.Gray;
            form.newWorkGroup.Text = newWgPlaceholderText;
            form.newWorkGroup.Enter += wgchange_Enter;
            form.newWorkGroup.Leave += wgchange_Leave;

            form.userchange_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            form.wgchange_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            //logo picturebox
            form.opchangePane.SizeMode = PictureBoxSizeMode.StretchImage;
            form.mmchangePane.SizeMode = PictureBoxSizeMode.StretchImage;
            form.useradmPane.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        // Full name
        private static void empFullname_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == empfnPlaceholderText)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.FromArgb(56, 56, 56);
            }
        }

        private static void empFullname_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = empfnPlaceholderText;
                textBox.ForeColor = Color.Gray;
            }
        }

        //New Work Group
        private static void wgchange_Enter(object sender, EventArgs e)
        {
            ComboBox comboText = (ComboBox)sender;
            if (comboText.Text == newWgPlaceholderText)
            {
                comboText.Text = string.Empty;
                comboText.ForeColor = Color.FromArgb(56, 56, 56);
            }
        }

        private static void wgchange_Leave(object sender, EventArgs e)
        {
            ComboBox comboText = (ComboBox)sender;
            if (string.IsNullOrWhiteSpace(comboText.Text))
            {
                comboText.Text = newWgPlaceholderText;
                comboText.ForeColor = Color.Gray;
            }
        }
        #endregion
    }
}