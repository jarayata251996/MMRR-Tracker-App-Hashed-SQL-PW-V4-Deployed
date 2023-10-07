using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace MMRR_Tracker
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            StyleHelper.ApplyStyleLogin(this);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
			//MessageBox.Show(Connection.ConnectionString);
            this.AcceptButton = enterButton;
            fadeIn.Start();
            versionLabel.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            versionAdm_Label.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            DateTimeFormatInfo formatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
            string shortDateFormat = formatInfo.ShortDatePattern;

            if (shortDateFormat == "M/d/yyyy")
            {
                try
                {
                    this.TransparencyKey = Color.Magenta;
                    if (DBHelper.connection.State == ConnectionState.Closed)
                    {
                        DBHelper.connection.Open();
                    }

                    ntUsername_textBox.AutoCompleteCustomSource.Clear();
                    ntUsername_textBox.AutoCompleteCustomSource.AddRange(DBHelper.autoCompleteItemsRoster("NT Username", 0).ToArray());

                    userNT_textBox.AutoCompleteCustomSource.Clear();
                    userNT_textBox.AutoCompleteCustomSource.AddRange(DBHelper.autoCompleteItemsRoster("NT Username", 0).ToArray());

                    adminCredentialsGroup.BringToFront();
                    changePWgb.SendToBack();
                    changePWgb.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to establish connection! please contact IT for assistance!\n" + ex.ToString(), "MMRR App", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if(MessageBox.Show("Your computer date formatting does not meet the application requirement!, please contact IT for assistance!\n\nMachine Date Format: "+ shortDateFormat+"\nCorrect Date Format: M/d/yyyy", "MMRR App", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    MessageBox.Show("Closing application", "MMRR App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    Application.ExitThread();
                }
            }
        }
        public static string ReadFromFile(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            object[] parameters = (object[])e.Argument;
            string ntUsername_Param = (string)parameters[0];
            string password_Param = (string)parameters[1];
            

            adminCredentialsGroup.Invoke(new Action(() =>
            {
                adminCredentialsGroup.Hide();
            }));


            e.Result = DBHelper.ntLogin(ntUsername_Param, password_Param, "officepartners360.com");


        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (userNT_textBox.Text != "")
            {
                if (password_textBox.Text == "" || password_textBox.Text == "Password")
                {
                    MessageBox.Show("Password is required!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    adminCredentialsGroup.Show();
                    loadingScreen.Hide();
                    password_textBox.Text = "Password";
                    password_textBox.ForeColor = Color.Gray;
                    return;
                }
                else
                {
                    try
                    {
                        if ((int)e.Result == 1)
                        {
                            //MessageBox.Show(DBHelper.workGroup);
                            DBHelper.tryLogin(userNT_textBox.Text);
                            dbHelper.InsertLogsRecord(Connection.ConnectionString,"Logging-in" + " - " + Assembly.GetExecutingAssembly().GetName().Version.ToString() , DBHelper.fullName, "WorkGroup :" + DBHelper.workGroup);

                          
                            userNT_textBox.Text = "";
                            password_textBox.Text = "";

                            this.Hide();
                            adminCredentialsGroup.Show();
                            Form1 mainForm = new Form1();
                            mainForm.Show();
                          
                        }
                        else
                        {
                            var opt = MessageBox.Show("Invalid Credentials!", "MMRR Tracker",
                                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            if (opt == DialogResult.Retry)
                            {
                                adminCredentialsGroup.Show();
                                loadingScreen.Hide();
                                userNT_textBox.Text = "";
                                password_textBox.Text = "";
                            }
                            else
                            {  
                                this.Close();
                              
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        adminCredentialsGroup.Show();
                    }
                }
            }
            else
            {
                if (userNT_textBox.Text == "OP360 Username" || userNT_textBox.Text == "")
                {
                    MessageBox.Show("Username is required!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    adminCredentialsGroup.Show();
                    userNT_textBox.Text = "";
                }
                return;
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] parameters = (object[])e.Argument;
            string ntUsername_Param = (string)parameters[0];
            string password_Param = (string)parameters[1];


            adminCredentialsGroup.Invoke(new Action(() =>
            {
                adminCredentialsGroup.Hide();
            }));


            e.Result = DBHelper.ntLogin(ntUsername_Param, password_Param, "officepartners360.com");
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ntUsername_textBox.Text != "")
            {
                if (adminPW_textBox.Text == "" || adminPW_textBox.Text == "Password")
                {
                    MessageBox.Show("Password is required!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    adminCredentialsGroup.Show();
                    loadingScreen.Hide();
                    adminPW_textBox.Text = "Password";
                    adminPW_textBox.ForeColor = Color.Gray;
                    return;
                }
                else
                {
                    try
                    {
                        if (DBHelper.ntLogin(ntUsername_textBox.Text, adminPW_textBox.Text, "officepartners360.com") == 1)
                        {
                            //MessageBox.Show(DBHelper.workGroup);
                            DBHelper.tryLogin(ntUsername_textBox.Text);
                            dbHelper.InsertLogsRecord(Connection.ConnectionString, "Logging-in" + " - " + Assembly.GetExecutingAssembly().GetName().Version.ToString(), DBHelper.fullName, "WorkGroup :" + DBHelper.workGroup);
                            ntUsername_textBox.Text = "";
                            adminPW_textBox.Text = "";

                            if (DBHelper.workGroup == "Admin")
                            {
                                this.Hide();
                                adminCredentialsGroup.Show();
                                ChangePassword changePassword = new ChangePassword();
                                changePassword.Show();
                            }
                            else
                            {
                                var opt = MessageBox.Show("This user is not an admin!", "MMRR Tracker",
                                     MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                                if (opt == DialogResult.Retry)
                                {
                                    adminCredentialsGroup.Show();
                                    loadingScreen.Hide();
                                    ntUsername_textBox.Text = "";
                                    adminPW_textBox.Text = "";
                                }
                                else
                                {
                                    this.AcceptButton = enterButton;
                                    //changePWgb.SendToBack();
                                    //loadingScreen.SendToBack();
                                    //loadingScreen.Hide();
                                    //adminCredentialsGroup.Show();
                                    changePWgb.SendToBack();
                                    changePWgb.Visible = false;
                                    adminCredentialsGroup.BringToFront();
                                    adminCredentialsGroup.Show();

                                    //changePWgb.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            var opt = MessageBox.Show("Invalid Credentials!", "MMRR Tracker",
                                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            if (opt == DialogResult.Retry)
                            {
                                adminCredentialsGroup.Show();
                                loadingScreen.Hide();
                                ntUsername_textBox.Text = "";
                                adminPW_textBox.Text = "";
                            }
                            else
                            {
                                Application.Exit();
                                Application.ExitThread();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        adminCredentialsGroup.Show();
                    }
                }
            }
            else
            {
                if (ntUsername_textBox.Text == "OP360 Username" || ntUsername_textBox.Text == "")
                {
                    MessageBox.Show("Username is required!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ntUsername_textBox.Text = "OP360 Username";
                    ntUsername_textBox.ForeColor = Color.Gray;
                }
                return;
            }
        }

        private void xLabel_Click(object sender, EventArgs e)
        {
            var opt = MessageBox.Show("Exit application?", "MMRR Tracker",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opt == DialogResult.Yes)
            {
                try
                {
                    if (DBHelper.connection.State == ConnectionState.Open)
                    {
                        DBHelper.connection.Close();
                    }
                    Application.Exit();
                    Application.ExitThread();
                }
                catch
                {
                    MessageBox.Show("Connection Error!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                    Application.ExitThread();
                }
            }
        }

        private void changePW_Click(object sender, EventArgs e)
        {
            this.AcceptButton = enterAdminpw;
            Opacity = 0;
            fadeIn.Start();
            adminCredentialsGroup.SendToBack();
            loadingScreen.Hide();
            changePWgb.BringToFront();
            changePWgb.Visible = true;
        }

        private void showPW_Click(object sender, EventArgs e)
        {
            showPW.SendToBack();
            password_textBox.UseSystemPasswordChar = true;
            unshowPW.BringToFront();
        }

        private void unshowPW_Click(object sender, EventArgs e)
        {
            unshowPW.SendToBack();
            password_textBox.UseSystemPasswordChar = false;
            showPW.BringToFront();
        }

        private void showPWadm_Click(object sender, EventArgs e)
        {
            showPWadm.SendToBack();
            adminPW_textBox.UseSystemPasswordChar = true;
            unshowPWadm.BringToFront();
        }

        private void unshowPWadm_Click(object sender, EventArgs e)
        {
            unshowPWadm.SendToBack();
            adminPW_textBox.UseSystemPasswordChar = false;
            showPWadm.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.AcceptButton = enterButton;
            Opacity = 0;
            fadeIn.Start();
            changePWgb.SendToBack();
            changePWgb.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterNewUser regForm = new RegisterNewUser();
            regForm.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void opadmPane_Click(object sender, EventArgs e)
        {
            StyleHelper.ApplyStyleLoginOP360(this);
        }

        private void opPane_Click(object sender, EventArgs e)
        {
            StyleHelper.ApplyStyleLoginOP360(this);
        }

        private void password_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loadingScreen.Show();
                object[] parameters = new object[]
                {
                    userNT_textBox.Text,
                    password_textBox.Text
                };
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync(parameters);
                }
            }
        }

        private void adminPW_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loadingScreen.Show();
                object[] parameters = new object[]
                {
                    ntUsername_textBox.Text,
                    adminPW_textBox.Text
                };
                if (!backgroundWorker2.IsBusy)
                {
                    backgroundWorker2.RunWorkerAsync(parameters);
                }  
            }
        }

        private void enterAdminpw_Click(object sender, EventArgs e)
        {
            loadingScreen.Show();
            KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));
            adminPW_textBox_KeyPress(sender, arg);
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            loadingScreen.Show();
            KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));
            password_textBox_KeyPress(sender, arg);
        }

		private void button1_Click(object sender, EventArgs e)
		{
			//string jsonFilePath = @"E:\Latest MMRR Application\MMRR Tracker 05232023\MMRR Tracker\bin\Debug\appsettings.json";
		//string encryptedDirjason = System.IO.Path.GetDirectoryName(
		//System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Encrypted Connection String Json\appsettings.encrypted.json";
		////string encryptedFilePath = Path.Combine(outputDirectory, "appsettings.encrypted.json");

		////byte[] encryptionKey = Program_encryptor.GenerateRandomKey();
		////textBox1.Text = Convert.ToBase64String(encryptionKey);

		////Program_encryptor.EncryptJsonFile(jsonFilePath, encryptedFilePath, encryptionKey);

		////textBox1.Text = Convert.ToBase64String(encryptionKey);
		////MessageBox.Show("Success!"); 

		//// Generate the same encryption key used for encryption
		//	string base64Key = "8tamjC6ImOYawOccJIVBkZynlmMA7p/ce0nZa9zepUc=";
		//	byte[] encryptionKey = Convert.FromBase64String(base64Key);

		//	// Decrypt the JSON file
		//	string  decryptedJson = Program_decryptor.DecryptJsonFile(encryptedDirjason, encryptionKey);
		//	MessageBox.Show(decryptedJson.ToString());
		//	richTextBox1.Text = decryptedJson.ToString();
		//	MessageBox.Show(GetConnectionStringFromJson(decryptedJson.ToString(), "MyConnection"));
		//	MessageBox.Show(Connection.ConnectionString);



		}
		static string GetConnectionStringFromJson(string json, string connectionStringName)
		{
			try
			{
				using (JsonDocument doc = JsonDocument.Parse(json))
				{
					var root = doc.RootElement;

					if (root.TryGetProperty("ConnectionStrings", out var connectionStringsNode))
					{
						var connectionStrings = connectionStringsNode.EnumerateObject();

						foreach (var connStr in connectionStrings)
						{
							if (connStr.Name == connectionStringName)
							{
								return connStr.Value.GetString();
							}
						}
					}
				}

				return "Connection string not found.";
			}
			catch (Exception ex)
			{
				return "Error parsing JSON: " + ex.Message;
			}
		}

	}
}
