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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
            StyleHelper.ApplyStyleChangeAgent(this);
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            fadeIn.Start();
            if (DBHelper.connection.State == ConnectionState.Closed)
            {
                DBHelper.connection.Open();
            }

            empNumber_textBox.AutoCompleteCustomSource.Clear();
            empNumber_textBox.AutoCompleteCustomSource.AddRange(DBHelper.autoCompleteItemsRoster("Full Name", 0).ToArray());

            newWorkGroup.Items.Clear();
            newWorkGroup.Items.AddRange(DBHelper.comboboxItems("dim_WorkGroup", "[Work Group Name]", 0).ToArray());
        }

        private void enterButton_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show(empNumber_textBox.Text);
            LoginForm loginForm = new LoginForm();
            DBHelper.updateAgentPW(empNumber_textBox.Text, newWorkGroup.Text, this, loginForm);
        }

        private void xLabel_Click_1(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
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

        private void opchangePane_Click(object sender, EventArgs e)
        {
            StyleHelper.ApplyStyleLoginOP360(this);
        }
    }
}
