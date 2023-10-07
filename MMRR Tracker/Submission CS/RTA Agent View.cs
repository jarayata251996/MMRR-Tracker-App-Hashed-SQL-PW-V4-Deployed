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
    public partial class RTA_Agent_View : Form
    {

        public string agentName_;
        public string completed_;

        private BackgroundWorker bgAll;
        private BackgroundWorker bgSubmitted;
        listViewReturnedDisplay listViewReturnedDisplay = new listViewReturnedDisplay();
        labelReturnedDisplay labelreturnedDisplay = new labelReturnedDisplay();
        public string connectionString = Connection.ConnectionString;


        public RTA_Agent_View(string agentName)
        {
            InitializeComponent();
            agentName_ = agentName;
            bgAll = new BackgroundWorker();
            bgAll.DoWork += bgAll_DoWork;
            bgAll.RunWorkerCompleted += bgAll_RunWorkerCompleted;
            bgSubmitted = new BackgroundWorker();
            bgSubmitted.DoWork += bgSubmitted_DoWork;
            bgSubmitted.RunWorkerCompleted += bgSubmitted_RunWorkerCompleted;
        }

        private void RTA_Agent_View_Load(object sender, EventArgs e)
        {
            fadeIn.Start();
            this.Text += " Detected Agent: " + agentName_;
            bgAll.RunWorkerAsync();

            label2.Text += " " + agentName_;
        }

        private void bgAll_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                PanelMain.Visible = false;
            }));
            e.Result = listViewReturnedDisplay.GetDataFromSqlServerViewCurrent(connectionString, agentName_);
        }
        private void bgAll_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable dataTable = (DataTable)e.Result;
            listViewReturnedDisplay.TransferDataToListView(dataTable, listView1);
            PanelMain.Visible = true;
        }

        private void bgSubmitted_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                PanelMain.Visible = false;
            }));
            e.Result = listViewReturnedDisplay.GetDataFromSqlServerViewLastTouch(connectionString, agentName_);
        }
        private void bgSubmitted_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable dataTable = (DataTable)e.Result;
            listViewReturnedDisplay.TransferDataToListView(dataTable, listView1);
            PanelMain.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bgAll.RunWorkerAsync();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bgSubmitted.RunWorkerAsync();
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
