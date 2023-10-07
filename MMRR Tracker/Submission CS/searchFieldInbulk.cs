using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMRR_Tracker.Submission_CS
{
    public partial class searchFieldInbulk : Form
    {
        public string completeSourceDisp_;
        public string stage_;
        public string parameter_;
        public bool isDate = false;
        dbHelper dbHelper = new dbHelper();
        public bool includeRequestDate;
	

		public string returnStatus(string input)
        {
            if (input == "Intake")
            {

                return "New";
            }
            else if (input == "Pending")
            {
                return input;
            }
            else if (input == "Completion")
            {
                return "Completed";
            }
            else if (input.Contains("Escalation"))
            {
                return "Escalated";
            }
            else if(input == "ALL")
            {
                return input;
            }
            return "";
        }

        public searchFieldInbulk(string completeSourceDisp, string stage, string parameter)
        {
            InitializeComponent();
            completeSourceDisp_ = completeSourceDisp;
            stage_ = returnStatus(stage);
            parameter_ = parameter;
        }

        private void searchFieldInbulk_Load(object sender, EventArgs e)
        {
            fadeIn.Start();
            radioButton1.Checked = true;
            label2.Text = parameter_;
            this.Text = completeSourceDisp_;

            if (parameter_.Contains("Date"))
            {
                if (parameter_.Contains("Case Staff Request Date"))
                {
                    checkBox2.Visible = false;
                    dateTimePicker2.Visible = false;
                }
                dateTimePicker5.Show();
                label2.Location = new Point(16,40);
                textBox2.Hide();
                isDate = true;
            }   

        }


		

		

		private async void button2_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(stage_);

            if (isDate == false)
            {

                Bulk_Editing_and_Assigning otherForm = null;
			
				foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Bulk_Editing_and_Assigning))
                    {
                        otherForm = (Bulk_Editing_and_Assigning)form;
                        break;
                    }
                } 


                if (otherForm != null)
                {
					// MessageBox.Show("1");
					
					if (includeRequestDate == true)
                    {
						
                        if (radioButton1.Checked == true)
                        {

							pictureBox1.Visible = true;
							await otherForm.LongProcess_(Connection.ConnectionString, parameter_, textBox2.Text, dateTimePicker2.Text, 1, true, stage_);
							pictureBox1.Visible = false;
							//MessageBox.Show("Success Loading Records!");

						}
                        if (radioButton2.Checked == true)
                        {
							pictureBox1.Visible = true;
							await otherForm.LongProcess_(Connection.ConnectionString, parameter_, textBox2.Text, dateTimePicker2.Text, 1, false, stage_);
							pictureBox1.Visible = false;
							//MessageBox.Show("Success Loading Records!");
						}
                    }
                    else
                    {
                        if (radioButton1.Checked == true)
                        {

							pictureBox1.Visible = true;
							await otherForm.LongProcess_(Connection.ConnectionString, parameter_, textBox2.Text, dateTimePicker2.Text, 0, true, stage_);
							pictureBox1.Visible = false;
							//MessageBox.Show("Success Loading Records!");
						}
                        if (radioButton2.Checked == true)
                        {
							pictureBox1.Visible = true;
							await otherForm.LongProcess_(Connection.ConnectionString, parameter_, textBox2.Text, dateTimePicker2.Text, 0, false, stage_);
							pictureBox1.Visible = false;
							//MessageBox.Show("Success Loading Records!");
						}
					
					}


                }
                else
                { }
            }
            else
            {
                Bulk_Editing_and_Assigning otherForm = null;
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Bulk_Editing_and_Assigning))
                    {
                        otherForm = (Bulk_Editing_and_Assigning)form;
                        break;
                    }
                }

                if (otherForm != null)
                {
                   // MessageBox.Show("2");
                
				
					if (includeRequestDate == true)
                    {
						if (radioButton1.Checked == true)
						{
							pictureBox1.Visible = true;
						    await otherForm.LongProcess_(Connection.ConnectionString, parameter_, dateTimePicker5.Text, dateTimePicker2.Text, 1, true, stage_);
							pictureBox1.Visible = false;
							//MessageBox.Show("Success Loading Records!");
						}
                        if (radioButton2.Checked == true)
						{
							pictureBox1.Visible = true;
							await otherForm.LongProcess_(Connection.ConnectionString, parameter_, dateTimePicker5.Text, dateTimePicker2.Text, 1, false, stage_);
							pictureBox1.Visible = false;
							//MessageBox.Show("Success Loading Records!");
						}
                    }
                    else
                    {
                        if (radioButton1.Checked == true)
						{
							pictureBox1.Visible = true;
							await otherForm.LongProcess_(Connection.ConnectionString, parameter_, dateTimePicker5.Text, dateTimePicker2.Text, 0, true, stage_);
							pictureBox1.Visible = false;
							//MessageBox.Show("Success Loading Records!");
						}
                        if (radioButton2.Checked == true)
						{
							pictureBox1.Visible = true;
						    await otherForm.LongProcess_(Connection.ConnectionString, parameter_, dateTimePicker5.Text, dateTimePicker2.Text, 0, false, stage_);
							pictureBox1.Visible = false;
							//MessageBox.Show("Success Loading Records!");
						}
					
					}

                }
                else
                { }
            }


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                includeRequestDate = true;
            }
            else
            {
                includeRequestDate = false;
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

        private void label2_Click(object sender, EventArgs e)
        {
            StyleHelper_CS.ApplyStyleLoginOP360(this);
        }
    }
}
