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
    public partial class RTA_Ticketing_Assignment_View : Form
    {
        listViewReturnedDisplay listViewReturnedDisplay = new listViewReturnedDisplay();
        public string connectionString = Connection.ConnectionString;

        private BackgroundWorker bgIntake;
        private BackgroundWorker bgPending;
        private BackgroundWorker bgCompleted;
        private BackgroundWorker bgAll;

        public class getMyDatax
        {
            public DataTable myDataModel { get; set; }
            public string error { get; set; }
        }

        public RTA_Ticketing_Assignment_View()
        {
            InitializeComponent();

            bgAll = new BackgroundWorker();
            bgAll.DoWork += bgAll_DoWork;
            bgAll.RunWorkerCompleted += bgAll_RunWorkerCompleted;


            bgIntake = new BackgroundWorker();
            bgIntake.DoWork += bgIntake_DoWork;
            bgIntake.RunWorkerCompleted += bgIntake_RunWorkerCompleted;

            bgPending = new BackgroundWorker();
            bgPending.DoWork += bgPending_DoWork;
            bgPending.RunWorkerCompleted += bgPending_RunWorkerCompleted;


            bgCompleted = new BackgroundWorker();
            bgCompleted.DoWork += bgCompleted_DoWork;
            bgCompleted.RunWorkerCompleted += bgCompleted_RunWorkerCompleted;
        }

        private void bgAll_DoWork(object sender, DoWorkEventArgs e)
        {
            getMyDatax getMyData = new getMyDatax();
            panelMain.Invoke(new Action(() =>
            {
                PanelHolder.Visible = false;

            }));
            e.Result  = listViewReturnedDisplay.GetDataFromSqlServer(connectionString);
           

        }

        private void bgAll_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {   
           

            if (e.Error != null)
            {
                MessageBox.Show("An error occurred: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("The operation was cancelled.");
            }
            else
            {
                DataTable dataTable = (DataTable)e.Result;
                listViewReturnedDisplay.TransferDataToList(dataTable, listView1);
                PanelHolder.Visible = true;
            }


        }

        private void bgIntake_DoWork(object sender, DoWorkEventArgs e)
        {
            getMyDatax getMyData = new getMyDatax();
            panelMain.Invoke(new Action(() =>
            {
                PanelHolder.Visible = false;

            }));
            e.Result = listViewReturnedDisplay.GetDataFromSqlServer(connectionString, "New", "");


        }

        private void bgIntake_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


            if (e.Error != null)
            {
                MessageBox.Show("An error occurred: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("The operation was cancelled.");
            }
            else
            {
                DataTable dataTable = (DataTable)e.Result;
                listViewReturnedDisplay.TransferDataToList(dataTable, listView1);
                PanelHolder.Visible = true;
            }


        }


        private void bgPending_DoWork(object sender, DoWorkEventArgs e)
        {
            getMyDatax getMyData = new getMyDatax();
            panelMain.Invoke(new Action(() =>
            {
                PanelHolder.Visible = false;

            }));
            e.Result = listViewReturnedDisplay.GetDataFromSqlServer(connectionString, "Pending", "");


        }

        private void bgPending_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("An error occurred: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("The operation was cancelled.");
            }
            else
            {
                DataTable dataTable = (DataTable)e.Result;
                listViewReturnedDisplay.TransferDataToList(dataTable, listView1);
                PanelHolder.Visible = true;
            }
        }


        private void bgCompleted_DoWork(object sender, DoWorkEventArgs e)
        {
            getMyDatax getMyData = new getMyDatax();
            panelMain.Invoke(new Action(() =>
            {
                PanelHolder.Visible = false;
            }));
            e.Result = listViewReturnedDisplay.GetDataFromSqlServer(connectionString, "Completed", "");
        }

        private void bgCompleted_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("An error occurred: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("The operation was cancelled.");
            }
            else
            {
                DataTable dataTable = (DataTable)e.Result;
                listViewReturnedDisplay.TransferDataToList(dataTable, listView1);
                PanelHolder.Visible = true;
            }
        }




        private void RTA_Ticketing_Assignment_View_Load(object sender, EventArgs e)
        {
            fadeIn.Start();
            bgAll.RunWorkerAsync();
        }

   

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            string rowString1 = "";
            foreach (ListViewItem item in items)
            {
                rowString1 += item.SubItems[0].Text + " "; 
            }
            RTA_Agent_View rTA_Agent_View = new RTA_Agent_View(rowString1);
            rTA_Agent_View.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            bgIntake.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            bgPending.RunWorkerAsync();
        }

        private void Completed_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            bgCompleted.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            listView1.Clear();
            bgAll.RunWorkerAsync();
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
    }
}
    

