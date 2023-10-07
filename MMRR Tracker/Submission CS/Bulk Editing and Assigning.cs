using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace MMRR_Tracker.Submission_CS
{
    public partial class Bulk_Editing_and_Assigning : Form
    {
        public Bulk_Editing_and_Assigning()
        {
            InitializeComponent();
			this.KeyPreview = true;
		}
        List<List<string>> twoDListRidList = new List<List<string>>();
        public int checkbeginEdit = 0;
        public DataTable OriginalData;
        public List<string> ridList = new List<string>();

		public bool verified = false;

        private void Bulk_Editing_and_Assigning_Load(object sender, EventArgs e)
        {

		

			 
	
			fadeIn.Start();
            try
            {
                if (DBHelper.workGroup.Contains("RTA") || DBHelper.workGroup.Contains("Developer") || DBHelper.workGroup.Contains("Admin"))
                {
                    submitChangesToolStripMenuItem.Enabled = true;
                    submitAndUpdatToolStripMenuItem.Enabled = true;
                    toolStripStatusLabel3.Text = "Editor Mode: TRUE";
                }
                else
                {
                    dataGridView1.ReadOnly = true;
                    submitChangesToolStripMenuItem.Enabled = false;
                    submitAndUpdatToolStripMenuItem.Enabled = false;
                    toolStripStatusLabel3.Text = "Editor Mode: FALSE";
                }

                submissionFormArrays submissionFormArrays = new submissionFormArrays();
                foreach (string item in submissionFormArrays.searchList)
                {
                    searchToolStripMenuItem.DropDownItems.Add(item);
                }
                foreach (ToolStripMenuItem Item in searchToolStripMenuItem.DropDownItems)
                {
                    foreach (string item in submissionFormArrays.stages)
                    {
                        Item.DropDownItems.Add(item);
                    }
                }
                foreach (ToolStripMenuItem subItem in searchToolStripMenuItem.DropDownItems)
                {
                    foreach (ToolStripMenuItem subsubItem in subItem.DropDownItems)
                    {
                        subsubItem.Click += new EventHandler(MenuItem_Click);
                    }
                }
            }
            catch
            {

            }
          
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            var complete = "Search Via: " + item.OwnerItem.ToString() + " in " + item.Text + " Repository";
            searchFieldInbulk searchFieldInbulk = new searchFieldInbulk(complete, item.Text, item.OwnerItem.ToString());
            searchFieldInbulk.ShowDialog();
        }

    

		public void clearing()
		{
			dataGridView1.Rows.Clear();
			dataGridView1.Columns.Clear();
			OriginalData = null;
			ridList.Clear();
			verified = false;
			toolStripStatusLabel2.Text = "Records Edited: 0";
			toolStripStatusLabel1.Text = "Records Found: 0";
            twoDListRidList.Clear();



		}


        private async Task LongProcess(string text, DataGridViewTextBoxEditingControl textBox)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox.AutoCompleteCustomSource.Clear();
            var autoCompleteItems = await Task.Run(() => dbHelper.autoCompleteItems(Connection.ConnectionString, text, 0));

            BeginInvoke(new Action(() =>
            {
                textBox.AutoCompleteCustomSource.AddRange(autoCompleteItems.ToArray());
            }));

        }

        private async Task LongProcess_(string text, DataGridViewTextBoxEditingControl textBox)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox.AutoCompleteCustomSource.Clear();
            var autoCompleteItems = await Task.Run(() => dbHelper.autoCompleteItemsRoster(Connection.ConnectionString, text, 0).ToArray());

            BeginInvoke(new Action(() =>
            {
                textBox.AutoCompleteCustomSource.AddRange(autoCompleteItems.ToArray());
            }));

        }

        private async void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {

                    pictureBox1.Show();
                    await LongProcess("Precedented ID", textBox);
                    pictureBox1.Hide();

                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {
                    pictureBox1.Show();
                    await LongProcess("Assigned Office Location", textBox);
                    pictureBox1.Hide();
                }
            }
      

            else if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {
                    pictureBox1.Show();
                    await LongProcess("Reference Number", textBox);
                    pictureBox1.Hide();

                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex == 5)
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {
                    pictureBox1.Show();
                    await LongProcess( "Type of Record (Billing Statement, Abstract, Records)", textBox);
                    pictureBox1.Hide();

                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex == 6)
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {
                    pictureBox1.Show();
                    await LongProcess("Facility", textBox);
                    pictureBox1.Hide();

                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex == 7)
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {
                    pictureBox1.Show();
                    await LongProcess("Facility Type", textBox);
                    pictureBox1.Hide();

                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex == 9)
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {
              
                    pictureBox1.Show();
                    await LongProcess("Method of Request", textBox);
                    pictureBox1.Hide();

                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex == 10)
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {

                    pictureBox1.Show();
                    await LongProcess("Portal", textBox);
                    pictureBox1.Hide();
                }
            }



        
            else if (dataGridView1.CurrentCell.ColumnIndex == 13)
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {
                    pictureBox1.Show();
                    await LongProcess_("Full Name", textBox);
                    pictureBox1.Hide();

                }
            }

			else if (dataGridView1.CurrentCell.ColumnIndex == 17)
			{
				if (e.Control is DataGridViewTextBoxEditingControl textBox)
				{
					pictureBox1.Show();
					await LongProcess("Email", textBox);
					pictureBox1.Hide();

				}
			}
			else if (dataGridView1.CurrentCell.ColumnIndex == 18)
			{
				if (e.Control is DataGridViewTextBoxEditingControl textBox)
				{
					pictureBox1.Show();
					await LongProcess("Mail", textBox);
					pictureBox1.Hide();

				}
			}

			else if (dataGridView1.CurrentCell.ColumnIndex == 19)
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {
                    pictureBox1.Show();
                    await LongProcess("Status", textBox);
                    pictureBox1.Hide();
                }
            }
            else if (dataGridView1.CurrentCell.ColumnIndex == 20)
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {
                  

                    pictureBox1.Show();
                    await LongProcess("Current Stages", textBox);
                    pictureBox1.Hide();
                }
            }
            else
            {
                if (e.Control is DataGridViewTextBoxEditingControl textBox)
                {
                    textBox.AutoCompleteCustomSource.Clear();

                }
            }
        }
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
            return "";
        }


        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                string enteredText = e.FormattedValue.ToString();
                if (!IsValidValue(enteredText))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Invalid value entered.";
                    e.Cancel = true;
                }
            }
        }
        private bool IsValidValue(string enteredValue)
        {
            return true; 
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
			int[] nonEditableColumnIndices = { 0, 27, 28, 12, 14 };
			if (nonEditableColumnIndices.Contains(e.ColumnIndex))
			{
				e.Cancel = true;
				MessageBox.Show("Not editable column!");
			}

			verified = false;


		}

		public async Task LongProcess_(string connectionString, string parameter, string searchword, string datetime, int isRequestDate, bool isitAll, string stage)
		{



		
				var loadDttable = await Task.Run(() => dbHelper.getDataTable(connectionString, parameter, searchword, datetime, isRequestDate, isitAll, stage)).ConfigureAwait(false);

			this.dataGridView1.Invoke((Action)(() =>
				{
					this.toolStripStatusLabel1.Text = "Records Found: " + loadDttable.Rows.Count.ToString();
					this.OriginalData = loadDttable;
				
					dataGridView1.Rows.Clear();
					dataGridView1.Columns.Clear();

				
					foreach (DataColumn column in loadDttable.Columns)
					{
						dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
					}

					foreach (DataGridViewColumn column in dataGridView1.Columns)
					{
						column.SortMode = DataGridViewColumnSortMode.NotSortable;
					}

					const int chunkSize = 100; 
					int rowCount = loadDttable.Rows.Count;
					for (int i = 0; i < rowCount; i += chunkSize)
					{
						int remainingRows = rowCount - i;
						int rowsToAdd = Math.Min(chunkSize, remainingRows);

						for (int j = 0; j < rowsToAdd; j++)
						{
							DataRow row = loadDttable.Rows[i + j];
							dataGridView1.Rows.Add(row.ItemArray);
						}

					
						Application.DoEvents(); 
					}
				}));
			


		}

		private void submitChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
			int counter = 0;
            if(dataGridView1.Rows.Count > 0)
            {
                ridList.Clear();
                for (int rowIndex = 0; rowIndex < dataGridView1.Rows.Count; rowIndex++)
                {
                    bool rowChanged = false;
                    for (int columnIndex = 0; columnIndex < dataGridView1.Columns.Count; columnIndex++)
                    {
                        DataGridViewCell cell = dataGridView1.Rows[rowIndex].Cells[columnIndex];
                        object originalValue = OriginalData.Rows[rowIndex][columnIndex];
                        object newValue = cell.Value;

                        if (!Equals(originalValue, newValue))
                        {
                            cell.Style.BackColor = Color.LightGreen;
                            cell.Style.SelectionBackColor = Color.LightGreen;
                            rowChanged = true;
							counter = counter + 1;

						}
                        else
                        { }
                    }

                    if (rowChanged)
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                        ridList.Add(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
                    }
                    else
                    { }
                }
				toolStripStatusLabel2.Text = "Records Edited: "+ counter;
				verified = true;
			}
            else
            {
                MessageBox.Show("No data to validate!");
            }  
        }
        private void submitAndUpdatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && ridList.Count() > 0)
            {
                if (verified == true)
                {
                    //MessageBox.Show("Simulate success!");

                    var prompt = MessageBox.Show("Continue updating these information to DB?", "Please verify all the changes you have made!", MessageBoxButtons.YesNo);
                    if (prompt == DialogResult.Yes)
                    {

                        List<DataGridViewRow> matchingRows = new List<DataGridViewRow>();

                        foreach (string id in ridList)
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == id)
                                {
                                    matchingRows.Add(row);
                                    break;
                                }
                            }
                        }

                        foreach (DataGridViewRow row in matchingRows)
                        {
                            // string cellValue = row.Cells[i].Value != null ? row.Cells[i].Value.ToString() : "";
                            twoDListRidList.Add(new List<string>() {
                              row.Cells[0]?.Value?.ToString()??"",
                                row.Cells[1]?.Value?.ToString()??"",
                                row.Cells[2]?.Value?.ToString()??"",
                                row.Cells[3]?.Value?.ToString()??"",
                                row.Cells[4]?.Value?.ToString()??"",
                                row.Cells[5]?.Value?.ToString()??"",
                                row.Cells[6]?.Value?.ToString()??"",
                                row.Cells[7]?.Value?.ToString()??"",
                                row.Cells[8]?.Value?.ToString()??"",
                                row.Cells[9]?.Value?.ToString()??"",
                                row.Cells[10]?.Value?.ToString()??"",
                                row.Cells[11]?.Value?.ToString()??"",
                                row.Cells[12]?.Value?.ToString()??"",
                                row.Cells[13]?.Value?.ToString()??"",
                                row.Cells[14]?.Value?.ToString()??"",
                                row.Cells[15]?.Value?.ToString()??"",
                                row.Cells[16]?.Value?.ToString()??"",
                                row.Cells[17]?.Value?.ToString()??"",
                                row.Cells[18]?.Value?.ToString()??"",
                                row.Cells[19]?.Value?.ToString()??"",
                                row.Cells[20]?.Value?.ToString()??"",
                                row.Cells[21]?.Value?.ToString()??"",
                                row.Cells[22]?.Value?.ToString()??"",
                                row.Cells[23]?.Value?.ToString()??"",
                                row.Cells[24]?.Value?.ToString()??"",
                                row.Cells[25]?.Value?.ToString()??"",
                                row.Cells[26]?.Value?.ToString()??"",
                                row.Cells[29]?.Value?.ToString()??""
                                




                    });


                        }

                        backgroundWorker1.RunWorkerAsync(twoDListRidList);


                    }
                    else { }
                    //MessageBox.Show("Simulate Success!");
                }
                else
                {
                    MessageBox.Show("Changes detected, data needs to be verified!");
                }

            }
            else
            {
                MessageBox.Show("No data to submit!");
            }

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            this.Invoke(new Action(() =>
            {
                submitAndUpdatToolStripMenuItem.Enabled = false;
            }));
            List<List<string>> parameters = (List<List<string>>)e.Argument;

            List<string> stringListRID = new List<string>();
            foreach (List<string> s in parameters)
            {
                dbHelper.UpdateRIDValue(Connection.ConnectionString,s[0], s[1], s[2], s[3], s[4], s[5], s[6], s[7], s[8], s[9],
                   s[10], s[11], s[12], s[13], s[14], s[15], s[16], s[17], s[18], s[19],
                   s[20], s[21], s[22], s[23], s[24], s[25],s[26],s[27]);

           
                    int progress = (int)(((double)(parameters.IndexOf(s) + 1) / (double)dataGridView1.Rows.Count) * 100);
                    progress = Math.Min(progress, 100);
            
               
                backgroundWorker1.ReportProgress(progress);
                stringListRID.Add(s[0]);
            }
            string joinedString = string.Join(",", stringListRID);
            try
            {
                dbHelper.InsertLogsRecord(Connection.ConnectionString, "Edited a Record", DBHelper.fullName, "List of RID modified: " + joinedString);

            }
            catch
            {

            }
        


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
            submitAndUpdatToolStripMenuItem.Enabled = true;
            progressBar1.Value = 0;
			clearing();
            MessageBox.Show("Success!");
        }

     

		private void clearGridViewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			clearing();
			
		}

		private void instructionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string message = "You can choose any type of search in \"Search Via\" Tab.\n" +
				 "Once the search is complete, you can edit the loaded records in the view.\n" +
				 "If you start to type text or edit a record, it will start to load the suggestions in the backend.\n" +
				 "You can identify it by the loading animation in the Top-Right Corner of this forms.\n\n" +
				 "These are the columns that have suggestions dropdown:\n" +
				 "1. Precedented ID\n" +
				 "2. Assigned Office Location\n" +
				 "3. Reference Number\n" +
				 "4. Type of Record (Billing Statement, Abstract, Records)\n" +
				 "5. Facility\n" +
				 "6. Facility Type\n" +
				 "7. Method of Request\n" +
				 "8. Portal\n" +
				 "9. Full Name\n" +
				 "10. Email\n" +
				 "11. Mail\n" +
				 "12. Status\n" +
				 "13. Current Stages\n\n" +
				 "Please note that dates do not include suggestions. If you edit the dates, make sure you follow the \"M/d/yyyy\" format.\n" +
				 "If the date or month is only a single digit, it must not contain any \"0\" digit.\n\n" +
				 "DO'S: \"5/9/2023\".\n" +
				 "DON'T: \"05/09/2023\", \"5/09/2023\", and \"05/9/2023\".\n\n" +
				 "The reason why we do not recommend the other formatting is that it will not be recognized by the app since the application only standardizes for \"M/d/yyyy\" formatting.\n\n" +
				 "To save the edited records, you must follow this sequence:\n" +
				 "Click \"File\" > \"Verify Changes\".\n" +
				 "The app will then verify all the changes made by highlighting it. Yellow color indicates the row where a cell has been edited. Green Color indicates the exact cell that has been Edited.\n" +
				 "Now, if you are confident that there will be no more information needed to adjust, you may now proceed and save it.\n\n" +
				 "Click \"File\" > \"Submit and Update\".\n" +
				 "The reason for these 2 steps prior saving is to enforce the user to review the changes made before having it reflected to database is to avoid wrong inputs to our server."+ 
				 "ADDED Feature: Ctrl + D to fill down data at any highlighted cells in a column!";

			MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            StyleHelper_CS.ApplyStyleLoginOP360(this);
        }

		private void Bulk_Editing_and_Assigning_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.D)
			{
				DataGridViewSelectedCellCollection selectedCells = dataGridView1.SelectedCells;

				if (selectedCells.Count > 1 && AreAllSelectedCellsInSameColumn(selectedCells))
				{
					int topRowIndex = selectedCells.Cast<DataGridViewCell>().Min(c => c.RowIndex);
					object cellValue = selectedCells.Cast<DataGridViewCell>().FirstOrDefault(c => c.RowIndex == topRowIndex)?.Value;

					foreach (DataGridViewCell cell in selectedCells)
					{
						if (cell.RowIndex >= 0)
						{
							cell.Value = cellValue;
						}
					}
				}
				e.Handled = true;
			}
		}
		private bool AreAllSelectedCellsInSameColumn(DataGridViewSelectedCellCollection selectedCells)
		{
			if (selectedCells.Count > 0)
			{
				int columnIndex = selectedCells[0].ColumnIndex;
				return selectedCells.Cast<DataGridViewCell>().All(cell => cell.ColumnIndex == columnIndex);
			}

			return false;
		}

		private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.None;
			dataGridView1.AllowUserToOrderColumns = false;
		}

		private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.None;
			dataGridView1.AllowUserToOrderColumns = false;
		}

		public async void exportToolStripMenuItem_Click(object sender, EventArgs e)
		{

			MessageBox.Show("///");
		


			
		}
	}
}
