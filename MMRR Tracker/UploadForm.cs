using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Threading;

namespace MMRR_Tracker
{
    public partial class UploadForm : Form
    {
        public UploadForm()
        {
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker2.WorkerSupportsCancellation = true;
        }

        string caseStaffReqDate, vendorSubmissionDate, dateResubmitted, completedDate, futureFollowupDate, timestampStart, timestampEnd;

        private async void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a File";
            openFileDialog.InitialDirectory = @"C:\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string filenameWithDirectory = GetFileNameWithDirectory(filePath);



                    string extension = Path.GetExtension(filenameWithDirectory);
                    string conString = "";
                    string sheetName = "";
                    switch (extension)
                    {
                        case ".xls":
                            conString = string.Format(DBHelper.Excel03ConString, filePath, "YES");
                            break;
                        case ".xlsx":
                            conString = string.Format(DBHelper.Excel07ConString, filePath, "YES");
                            break;
                    }
                    toolStripStatusLabel1.Text = "File Name: " + filePath;
                    importFile.Dispose();


                    using (OleDbConnection con = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            try
                            {
                                cmd.Connection = con;
                                con.Open();
                                DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                sheetName = dt.Rows[0]["Table_Name"].ToString();
                                con.Close();

                            }
                            catch (Exception exx)
                            {
                                MessageBox.Show(exx.ToString());
                            }
                         
                        }
                    }

                    using (OleDbConnection con = new OleDbConnection(conString))
                    {	try
						{
							using (OleDbCommand cmd = new OleDbCommand())
							{
								OleDbDataAdapter oda = new OleDbDataAdapter();
								if (migration_RadioButton.Checked == true)
								{
									cmd.CommandText = "SELECT * FROM [" + sheetName + "] ORDER BY [Case Staff Request Date] ASC, [Reference Number] ASC, [Facility] ASC";
								}
								else
								{
									cmd.CommandText = "SELECT * FROM [" + sheetName + "] ORDER BY [CaseStaffRequestDate] ASC, [ReferenceNumber] ASC, [Facility] ASC";
								}

								cmd.CommandType = CommandType.Text;
								cmd.Connection = con;
								con.Open();
								oda.SelectCommand = cmd;
								DataTable dt = new DataTable();
								oda.Fill(dt);
								con.Close();

								pictureBox1.Show();

								importButton.Enabled = false;
								resetImport.Enabled = false;
								confirmButton.Enabled = false;
								await LongProcess_(dt);
								confirmButton.Enabled = true;
								resetImport.Enabled = true;
								importButton.Enabled = true;

								pictureBox1.Hide();
							}
						}
						catch
						{
							MessageBox.Show("This file might be corrupted or not for this type of uploading in the Database!\nPlease contact Dev for more details!");
						}
                       
                    }
                }
                catch(IOException)
                {
                    MessageBox.Show("The selected file is currently open!", "MMRR App", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static string GetFileNameWithDirectory(string filePath)
        {
            string directory = System.IO.Path.GetDirectoryName(filePath);
            string filename = System.IO.Path.GetFileName(filePath);
            string filenameWithDirectory = System.IO.Path.Combine(directory, filename);
            return filenameWithDirectory;
        }



		public async Task LongProcess_(DataTable dt)
		{

			this.importDataDgv.Invoke((Action)(() =>
			{


				importDataDgv.Rows.Clear();
				importDataDgv.Columns.Clear();


				foreach (DataColumn column in dt.Columns)
				{
					importDataDgv.Columns.Add(column.ColumnName, column.ColumnName);
				}


				const int chunkSize = 100;
				int rowCount = dt.Rows.Count;
				for (int i = 0; i < rowCount; i += chunkSize)
				{
					int remainingRows = rowCount - i;
					int rowsToAdd = Math.Min(chunkSize, remainingRows);

					for (int j = 0; j < rowsToAdd; j++)
					{
						DataRow row = dt.Rows[i + j];
						importDataDgv.Rows.Add(row.ItemArray);
					}

					toolStripStatusLabel2.Text = "Row Count: " + importDataDgv.Rows.Count.ToString();
					Application.DoEvents();
				}
			}));
		}



		private void UploadForm_Load(object sender, EventArgs e)
        {
            fadeIn.Start();
            importDataDgv.Columns.Clear();
            if (DBHelper.connection.State == ConnectionState.Closed)
            {
                DBHelper.connection.Open();
            }
            if(DBHelper.workGroup.Contains("Developer"))
            {
                migration_RadioButton.Enabled = true;
                migration_RadioButton.Checked = true;
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (DBHelper.isMigratingStatus() > 0)
            {
                MessageBox.Show("You cannot import for the meantime, because " + DBHelper.fullName_isMigrating + " is currently importing data", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (importDataDgv.RowCount > 0)
                {
                    if (standard_RadioButton.Checked == true)
                    {
                        DBHelper.updateIsMigrating(DBHelper.fullName, "YES");
                        DataTable dt = new DataTable();
                        dt.Columns.AddRange(new DataColumn[8] {
                        new DataColumn("AssignedOfficeLocation", typeof(string)),
                        new DataColumn("CaseStaffRequestDate", typeof(string)),
                        new DataColumn("ReferenceNumber", typeof(string)),
                        new DataColumn("TypeofRecordBillingStatementAbstractRecords", typeof(string)),
                        new DataColumn("Facility", typeof(string)),
                        new DataColumn("VendorSubmissionDate", typeof(string)),
                        new DataColumn("Status", typeof(string)),
                        new DataColumn("CurrentStages", typeof(string))
                    });
                        try
                        {
                            backgroundWorker1.RunWorkerAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (migration_RadioButton.Checked == true)
                    {
                        DBHelper.updateIsMigrating(DBHelper.fullName, "YES");
                        DataTable dt = new DataTable();
                        dt.Columns.AddRange(new DataColumn[29] {
                        new DataColumn("PrecedentedID", typeof(string)),
                        new DataColumn("assignedOfficeLocation", typeof(string)),
                        new DataColumn("caseStaffRequestDate", typeof(string)),
                        new DataColumn("referenceNumber", typeof(string)),
                        new DataColumn("typeofRecord", typeof(string)),
                        new DataColumn("facility", typeof(string)),
                        new DataColumn("facilityType", typeof(string)),
                        new DataColumn("vendorSubmissionDate", typeof(string)),
                        new DataColumn("methodofRequest", typeof(string)),
                        new DataColumn("portal", typeof(string)),
                        new DataColumn("dateResubmitted", typeof(string)),
                        new DataColumn("lastTouchAgentName", typeof(string)),
                        new DataColumn("assignedAgent", typeof(string)),
                        new DataColumn("lastTouchGroup", typeof(string)),
                        new DataColumn("facilityPhoneNumber", typeof(string)),
                        new DataColumn("fax", typeof(string)),
                        new DataColumn("email", typeof(string)),
                        new DataColumn("mail", typeof(string)),
                        new DataColumn("status", typeof(string)),
                        new DataColumn("currentStages", typeof(string)),
                        new DataColumn("finalStages", typeof(string)),
                        new DataColumn("completeDate", typeof(string)),
                        new DataColumn("notes", typeof(string)),
                        new DataColumn("futureFollowUpDate", typeof(string)),
                        new DataColumn("invoicePaid", typeof(string)),
                        new DataColumn("pharmacy", typeof(string)),
                        new DataColumn("timeStampStart", typeof(string)),
                        new DataColumn("timeStampEnd", typeof(string)),
                        new DataColumn("isDone", typeof(string)),

                        });
                        try
                        {
                            backgroundWorker2.RunWorkerAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("No rows found!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            var opt = MessageBox.Show("Close upload data form?", "MMRR Tracker",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opt == DialogResult.Yes)
            {
                if (backgroundWorker1.IsBusy && backgroundWorker2.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                    backgroundWorker2.CancelAsync();
                    this.Close();
                }
                else if(backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                    this.Close();
                }
                else if(backgroundWorker2.IsBusy)
                {
                    backgroundWorker2.CancelAsync();
                    this.Close();
                }
                else
                {
                     this.Close();
                }
            }
        }

        private void repositoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            confirmButton.Enabled = true;
        }

        private void rosterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            confirmButton.Enabled = true;
        }
        int lx, ly;
        int sw, sh;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                confirmButton.Enabled = false;
            }));
            BackgroundWorker worker = sender as BackgroundWorker;
            importData(worker, importDataDgv);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            resetImport.Enabled = true;
            MessageBox.Show("Data successfully added!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            importDataDgv.DataSource = null;
            progressBar1.Value = 0;

            caseStaffReqDate = "";
            vendorSubmissionDate = "";
        }
        private void importData(BackgroundWorker worker, DataGridView importDataDgv)
        {
            foreach (DataGridViewRow row in importDataDgv.Rows)
            {
                //rowcnt++;
                //MessageBox.Show(rowcnt.ToString());
                MyDataModelForImporting.AssignedOfficeLocation = row.Cells[0].Value.ToString();
                MyDataModelForImporting.CaseStaffRequestDate = row.Cells[1].Value.ToString();
                MyDataModelForImporting.ReferenceNumber = row.Cells[2].Value.ToString();
                MyDataModelForImporting.TypeofRecordBillingStatementAbstractRecords = row.Cells[3].Value.ToString();
                MyDataModelForImporting.Facility = row.Cells[4].Value.ToString();
                MyDataModelForImporting.VendorSubmissionDate = row.Cells[5].Value.ToString();
                MyDataModelForImporting.Status = row.Cells[6].Value.ToString();
                MyDataModelForImporting.CurrentStages = row.Cells[7].Value.ToString();

                try
                {
                    caseStaffReqDate = DateTime.Parse(MyDataModelForImporting.CaseStaffRequestDate).ToShortDateString();
                }
                catch
                {
                    caseStaffReqDate = "";
                }

                try
                {
                    vendorSubmissionDate = DateTime.Parse(MyDataModelForImporting.VendorSubmissionDate).ToShortDateString();
                }
                catch
                {
                    vendorSubmissionDate = "";
                }

                DBHelper.importDatatoRepo(@MyDataModelForImporting.AssignedOfficeLocation, @caseStaffReqDate, @MyDataModelForImporting.ReferenceNumber, @MyDataModelForImporting.TypeofRecordBillingStatementAbstractRecords, @MyDataModelForImporting.Facility, @"", @vendorSubmissionDate, @"", @"", @"", @"", @"", @"", @"", @"", @"", @"", @MyDataModelForImporting.Status, @MyDataModelForImporting.CurrentStages, @"", @"", @"", @"", @"", @"", @"", @"", @"NO");

                int progress = (int)(((double)(importDataDgv.Rows.IndexOf(row) + 1) / (double)importDataDgv.Rows.Count) * 100);
                worker.ReportProgress(progress);
            }

            DBHelper.updateIsMigrating(DBHelper.fullName, "NO");
        }

        private void importData2(BackgroundWorker worker, DataGridView importDataDgv)
        {
            foreach (DataGridViewRow row in importDataDgv.Rows)
            {

                MyDataModelForImporting.PrecedentedID = row.Cells[0].Value.ToString();
                MyDataModelForImporting.AssignedOfficeLocation = row.Cells[1].Value.ToString();
                MyDataModelForImporting.CaseStaffRequestDate = row.Cells[2].Value.ToString();
                MyDataModelForImporting.ReferenceNumber = row.Cells[3].Value.ToString();
                MyDataModelForImporting.TypeofRecordBillingStatementAbstractRecords = row.Cells[4].Value.ToString();
                MyDataModelForImporting.Facility = row.Cells[5].Value.ToString();
                MyDataModelForImporting.FacilityType = row.Cells[6].Value.ToString();
                MyDataModelForImporting.VendorSubmissionDate = row.Cells[7].Value.ToString();
                MyDataModelForImporting.MethodofRequest = row.Cells[8].Value.ToString();
                MyDataModelForImporting.Portal = row.Cells[9].Value.ToString();
                MyDataModelForImporting.DateResubmitted = row.Cells[10].Value.ToString();
                MyDataModelForImporting.LastTouchAgentName = row.Cells[11].Value.ToString();
                MyDataModelForImporting.AssignedAgent = row.Cells[12].Value.ToString();
                MyDataModelForImporting.LastTouchGroup = row.Cells[13].Value.ToString();
                MyDataModelForImporting.FacilityPhoneNumber = row.Cells[14].Value.ToString();
                MyDataModelForImporting.Fax = row.Cells[15].Value.ToString();
                MyDataModelForImporting.Email = row.Cells[16].Value.ToString();
                MyDataModelForImporting.Mail = row.Cells[17].Value.ToString();
                MyDataModelForImporting.Status = row.Cells[18].Value.ToString();
                MyDataModelForImporting.CurrentStages = row.Cells[19].Value.ToString();
                MyDataModelForImporting.CurrentStagesFinalStages = row.Cells[20].Value.ToString();
                MyDataModelForImporting.CompleteDate = row.Cells[21].Value.ToString();
                MyDataModelForImporting.Notes = row.Cells[22].Value.ToString();
                MyDataModelForImporting.FutureFollowUpDate = row.Cells[23].Value.ToString();
                MyDataModelForImporting.InvoicePaid = row.Cells[24].Value.ToString();
                MyDataModelForImporting.Pharmacy = row.Cells[25].Value.ToString();
                MyDataModelForImporting.TimeStampStart = row.Cells[26].Value.ToString();
                MyDataModelForImporting.TimeStampEnd = row.Cells[27].Value.ToString();
                MyDataModelForImporting.isDone = row.Cells[28].Value.ToString();

                try
                {
                    caseStaffReqDate = DateTime.Parse(MyDataModelForImporting.CaseStaffRequestDate).ToShortDateString();
                }
                catch
                {
                    caseStaffReqDate = "";
                }

                try
                {
                    vendorSubmissionDate = DateTime.Parse(MyDataModelForImporting.VendorSubmissionDate).ToShortDateString();
                }
                catch
                {
                    vendorSubmissionDate = "";
                }

                try
                {
                    caseStaffReqDate = DateTime.Parse(MyDataModelForImporting.CaseStaffRequestDate).ToShortDateString();
                }
                catch
                {
                    caseStaffReqDate = "";
                }

                try
                {
                    dateResubmitted = DateTime.Parse(MyDataModelForImporting.DateResubmitted).ToShortDateString();
                }
                catch
                {
                    dateResubmitted = "";
                }

                try
                {
                    completedDate = DateTime.Parse(MyDataModelForImporting.CompleteDate).ToShortDateString();
                }
                catch
                {
                    completedDate = "";
                }

                try
                {
                    futureFollowupDate = DateTime.Parse(MyDataModelForImporting.FutureFollowUpDate).ToShortDateString();
                }
                catch
                {
                    futureFollowupDate = "";
                }



				try
				{
					timestampStart = DateTime.Parse(MyDataModelForImporting.TimeStampStart).ToString("M/d/yyyy h:mm:ss tt");
				}
				catch
				{
					timestampStart = "";
				}


				try
				{
					timestampEnd = DateTime.Parse(MyDataModelForImporting.TimeStampEnd).ToString("M/d/yyyy h:mm:ss tt");
				}
				catch
				{
					timestampEnd = "";
				}

				try
                {
                    DBHelper.importDatatoRepowithPrecID(MyDataModelForImporting.PrecedentedID, MyDataModelForImporting.AssignedOfficeLocation, caseStaffReqDate, MyDataModelForImporting.ReferenceNumber, MyDataModelForImporting.TypeofRecordBillingStatementAbstractRecords, MyDataModelForImporting.Facility, MyDataModelForImporting.FacilityType, vendorSubmissionDate, MyDataModelForImporting.MethodofRequest, MyDataModelForImporting.Portal, dateResubmitted, MyDataModelForImporting.LastTouchAgentName, MyDataModelForImporting.AssignedAgent, MyDataModelForImporting.LastTouchGroup, MyDataModelForImporting.FacilityPhoneNumber, MyDataModelForImporting.Fax, MyDataModelForImporting.Email, MyDataModelForImporting.Mail, MyDataModelForImporting.Status, MyDataModelForImporting.CurrentStages, MyDataModelForImporting.CurrentStagesFinalStages, completedDate, MyDataModelForImporting.Notes, futureFollowupDate, MyDataModelForImporting.InvoicePaid, MyDataModelForImporting.Pharmacy, timestampStart, timestampEnd, MyDataModelForImporting.isDone);
                    int progress = (int)(((double)(importDataDgv.Rows.IndexOf(row) + 1) / (double)importDataDgv.Rows.Count) * 100);
                    worker.ReportProgress(progress);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "MMRR App", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            DBHelper.updateIsMigrating(DBHelper.fullName, "NO");
        
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void resetImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
			importDataDgv.Rows.Clear();
			importDataDgv.Columns.Clear();
			toolStripStatusLabel1.Text = "File Name: ";
			toolStripStatusLabel2.Text = "Row Count: ";
		}

        private void migration_RadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

		private void toolStripStatusLabel1_Click(object sender, EventArgs e)
		{
            StyleHelper.ApplyStyleLoginOP360(this);
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

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                confirmButton.Enabled = false;
            }));
            BackgroundWorker worker = sender as BackgroundWorker;
            importData2(worker, importDataDgv);
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            resetImport.Enabled = true;

            MessageBox.Show("Data successfully added!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            importDataDgv.DataSource = null;
            progressBar1.Value = 0;

            caseStaffReqDate = "";
            vendorSubmissionDate = "";
            futureFollowupDate = "";
            completedDate = "";
            dateResubmitted = "";
        }

        private void UploadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the background worker is currently running
            if (backgroundWorker1.IsBusy)
            {
                // Cancel the background worker
                backgroundWorker1.CancelAsync();

                // Wait for the background worker to complete or be cancelled
                e.Cancel = true;
                while (backgroundWorker1.IsBusy)
                {
                    Application.DoEvents();
                }
            }
            // Check if the background worker is currently running
            if (backgroundWorker2.IsBusy)
            {
                // Cancel the background worker
                backgroundWorker2.CancelAsync();

                // Wait for the background worker to complete or be cancelled
                e.Cancel = true;
                while (backgroundWorker1.IsBusy)
                {
                    Application.DoEvents();
                }
            }
        }

        private void btn_maximize_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;

            btn_maximize.Visible = false;
            btn_normal.Visible = true;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        private void btn_normal_Click(object sender, EventArgs e)
        {
            btn_maximize.Visible = true;
            btn_normal.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }
    }
}
