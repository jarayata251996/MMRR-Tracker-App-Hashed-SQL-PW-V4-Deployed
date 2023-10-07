using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMRR_Tracker
{
    public partial class RegisterNewUser : Form
    {
        public RegisterNewUser()
        {
            InitializeComponent();
            StyleHelper.ApplyStyleRegister(this);
        }

        private void RegisterNewUser_Load(object sender, EventArgs e)
        {
            if (DBHelper.connection.State == ConnectionState.Closed)
            {
                DBHelper.connection.Open();
            }

            newWorkGroup.Items.Clear();
            newWorkGroup.Items.AddRange(DBHelper.comboboxItems("dim_WorkGroup", "[Work Group Name]", 0).ToArray());
        }

        private void xLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (empID.Text != "" && fullName.Text != "" && opEmail.Text != "" && ftpEmail.Text != "" && newWorkGroup.Text != "" && ntUsername.Text != "")
            {
                if (empID.Text == "Employee ID" || fullName.Text == "Full Name" || opEmail.Text == "Email" || ftpEmail.Text == "FTP Email" || newWorkGroup.Text == "Work Group" || ntUsername.Text == "NT Username")
                {
                    MessageBox.Show("Must fill all the fields!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    LoginForm loginForm = new LoginForm();
                    DBHelper.registerUser(empID.Text, fullName.Text, opEmail.Text, ftpEmail.Text, newWorkGroup.Text, ntUsername.Text, this, loginForm);
                }  
            }
            else
            {
                MessageBox.Show("Must fill all the fields!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void empID_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void empID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void opaddPane_Click(object sender, EventArgs e)
        {
            StyleHelper.ApplyStyleLoginOP360(this);
        }
    }
}
