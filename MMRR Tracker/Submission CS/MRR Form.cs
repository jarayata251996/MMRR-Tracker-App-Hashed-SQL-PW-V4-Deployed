using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;


namespace MMRR_Tracker
{
    public partial class SubmissionForm : Form
    {
        public string connectionString = Connection.ConnectionString; 
        submissionFormArrays sForm = new submissionFormArrays();
        requiredObjects requiredObjects = new requiredObjects();
        Dictionary<Control, bool> tocheckPriorSending = new Dictionary<Control, bool>();
        listViewReturnedDisplay listViewReturnedDisplay = new listViewReturnedDisplay();
        labelReturnedDisplay labelreturnedDisplay = new labelReturnedDisplay();
        
        private BackgroundWorker bgWorkerFetch;
        private BackgroundWorker bgWorkerSave;
        private BackgroundWorker bgWorkerViewCurrent;
        private BackgroundWorker bgWorkerViewSubmitted;
		public int determineiffaciRequired = 1;
        bool originalCheckedState;

        public class getSetLabelCount
        {   



            public string finished { get; set; }
            public string notfinished { get; set; }
            public DataTable gridDisplay { get; set; }
            public string escaInvoiceCount { get; set; }
            public string escaNoRoles { get; set; }
            public string noSignedHipaa { get; set; }
            public string escaGeneralEsca { get; set; }
            public string escaDigitalSignature { get; set; }
            public string escaClientPriority { get; set; }
        }

      
        public class getMyData
        {
            public MyDataModel myDataModel { get; set; }
            public string error { get; set; }
        }
       
        public string startTime;
        public string endTime;
        public string fromGroup;
        public string fromUser;
        public string getRID;
        public string statusSelectorStr;
        public string recordTypeStr;
        public string requestedDateStr;
        public string matterNumberSearching;
        public string RIDtb;
        public string ifReassigned = "no";
        public string ifGrab = "no";

        List<string> stringList = new List<string>();
        public bool phone_ = false;
        public bool fax_ = false;


        public SubmissionForm(string userName, string group)
        {
            InitializeComponent();
            CenterControl(pictureBox1);
            fromGroup = group;
            fromUser = userName;


            bgWorkerFetch = new BackgroundWorker();
            bgWorkerFetch.DoWork += bgWorkerFetch_DoWork;
            bgWorkerFetch.RunWorkerCompleted += bgWorkerFetch_RunWorkerCompleted;

            bgWorkerSave = new BackgroundWorker();
            bgWorkerSave.DoWork += bgWorkerSave_DoWork;
            bgWorkerSave.RunWorkerCompleted += bgWorkerSave_RunWorkerCompleted;

            bgWorkerViewCurrent = new BackgroundWorker();
            bgWorkerViewCurrent.DoWork += bgWorkerViewCurrent_DoWork;
            bgWorkerViewCurrent.RunWorkerCompleted += bgWorkerViewCurrent_RunWorkerCompleted;

            bgWorkerViewSubmitted = new BackgroundWorker();
            bgWorkerViewSubmitted.DoWork += bgWorkerViewSubmitted_DoWork;
            bgWorkerViewSubmitted.RunWorkerCompleted += bgWorkerViewSubmitted_RunWorkerCompleted;
        }

        private void bgWorkerFetch_DoWork(object sender, DoWorkEventArgs e)
        {
            getMyData getMyData = new getMyData();
            string columnName = e.Argument as string;
            try
                    {
                        startTime = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");
                        submissionFormMain submissionForm = new submissionFormMain(connectionString);
                        string userId = fromUser;

                        if (fromGroup == "Completion" || fromGroup == "Escalation")
                        {
                            getMyData.myDataModel = submissionForm.GetDataByUserIdCompEsca(userId, matterNumberSearching, recordTypeStr, requestedDateStr, requestDateCB.Checked, returnStatus(fromGroup), RIDtb);
                        }
                        else
                        {
                            getMyData.myDataModel = submissionForm.GetDataByUserId(userId, statusSelectorStr, recordTypeStr, requestedDateStr, requestDateCB.Checked, returnStatus(fromGroup), columnName);
                        }
                    }
                    catch (Exception Ex)
                    {
                        getMyData.error = Ex.ToString();
                    }
            try
            {
                //dbHelper.InsertLogsRecord(Connection.ConnectionString, "Fetched Record", fromUser, "RID - " + getMyData.myDataModel.RID + " Matter: " + getMyData.myDataModel.ReferenceNumber);
            }
            catch
            {
                
            }
            
            e.Result = getMyData;
        }

        private void bgWorkerFetch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            getMyData getMyData = e.Result as getMyData;
            clearObjects();

            if (getMyData.myDataModel != null)
            {
                if (getMyData.myDataModel.AssignedAgent != "" && getMyData.myDataModel.AssignedAgent != fromUser)
                {
                    DialogResult result = MessageBox.Show("Please advise the owner " + getMyData.myDataModel.AssignedAgent + " that you will grab this ticket. " 
                        , "Confirm Ticket Grab?", MessageBoxButtons.YesNo);
                   
                    if (result == DialogResult.Yes) 
                    {
                      
                        dbHelper.updateAssignedUser(connectionString, getMyData.myDataModel.RID, fromUser);

                        //currentStagesFinalDropDown.Items.Clear();
                       // currentStagesFinalDropDown.Items.AddRange(sForm.grabList);


                        getRID = getMyData.myDataModel.RID;
                        if (getMyData.myDataModel.PrecedentedID != null) precededentIdTextBox.Text = getMyData.myDataModel.PrecedentedID;
                        if (getMyData.myDataModel.AssignedOfficeLocation != null) assignedOfficeLocationTextBox.Text = getMyData.myDataModel.AssignedOfficeLocation;
                        if (getMyData.myDataModel.CaseStaffRequestDate != null)
                            try { caseStaffRequestTB.Text = DateTime.Parse(getMyData.myDataModel.CaseStaffRequestDate).ToShortDateString(); }
                            catch { caseStaffRequestTB.Text = getMyData.myDataModel.CaseStaffRequestDate; }

                        if (getMyData.myDataModel.ReferenceNumber != null) referenceNumberTextBox.Text = getMyData.myDataModel.ReferenceNumber;

                        if (getMyData.myDataModel.TypeofRecord != null) typeOfRecordTextBox.Text = getMyData.myDataModel.TypeofRecord;
                        if (getMyData.myDataModel.Facility != null) facilityTextBox.Text = getMyData.myDataModel.Facility;
                        if (getMyData.myDataModel.FacilityType != null) facilityType.Text = getMyData.myDataModel.FacilityType;

                        if (getMyData.myDataModel.VendorSubmissionDate != null)
                            try { vendorSubmissionTB.Text = DateTime.Parse(getMyData.myDataModel.VendorSubmissionDate).ToShortDateString(); }
                            catch { vendorSubmissionTB.Text = getMyData.myDataModel.VendorSubmissionDate; }

                        if (getMyData.myDataModel.MethodofRequest != null) methodOfRequestTextBox.Text = getMyData.myDataModel.MethodofRequest;
                        if (getMyData.myDataModel.Portal != null) portalTextBox.Text = getMyData.myDataModel.Portal;
                        if (getMyData.myDataModel.DateResubmitted != null)
                            try { dateResubmittedTB.Text = DateTime.Parse(getMyData.myDataModel.DateResubmitted).ToShortDateString(); }
                            catch { dateResubmittedTB.Text = getMyData.myDataModel.DateResubmitted; };

                        if (getMyData.myDataModel.LastTouchAgentName != null) lastTouchAgentNameTextBox.Text = getMyData.myDataModel.LastTouchAgentName;
                        if (getMyData.myDataModel.AssignedAgent != null) assignedAgentTextBox.Text = fromUser;
                        if (getMyData.myDataModel.LastTouchGroup != null) lastTouchGroupTextBox.Text = getMyData.myDataModel.LastTouchGroup;
                        if (getMyData.myDataModel.FacilityPhoneNumber != null) facilityPhoneNumberNumericUpDown.Text = getMyData.myDataModel.FacilityPhoneNumber;
                        if (getMyData.myDataModel.Fax != null) faxNumericUpDown.Text = getMyData.myDataModel.Fax;
                        if (getMyData.myDataModel.Email != null) emailTextBox.Text = getMyData.myDataModel.Email;
                        if (getMyData.myDataModel.Mail != null) mailTextBox.Text = getMyData.myDataModel.Mail;
                        if (getMyData.myDataModel.Status != null) statusTextBox.Text = getMyData.myDataModel.Status;
                        if (getMyData.myDataModel.CurrentStages != null) currentStagesTextBox.Text = getMyData.myDataModel.CurrentStages;
                        if (getMyData.myDataModel.CurrentStagesFinalStages != null) currentStagesFinalDropDown.Text = getMyData.myDataModel.CurrentStagesFinalStages;
                        if (getMyData.myDataModel.CompleteDate != null)
                            try { completeDateTB.Text = DateTime.Parse(getMyData.myDataModel.CompleteDate).ToShortDateString(); }
                            catch { completeDateTB.Text = getMyData.myDataModel.CompleteDate; };

                        if (getMyData.myDataModel.Notes != null) notesTextBox.Text = "";
                        if (getMyData.myDataModel.FutureFollowUpDate != null)
                            try { futureFollowUpTB.Text = DateTime.Parse(getMyData.myDataModel.FutureFollowUpDate).ToShortDateString(); }
                            catch { futureFollowUpTB.Text = getMyData.myDataModel.FutureFollowUpDate; };

                        if (getMyData.myDataModel.InvoicePaid != null) invoicePaidTextBox.Text = getMyData.myDataModel.InvoicePaid;
                        if (getMyData.myDataModel.Pharmacy != null) pharmacyTextBox.Text = getMyData.myDataModel.Pharmacy;
 
                        MainPanelHolder.Visible = true;

                        button1.Enabled = false;
                        button2.Enabled = true;
                        flowLayoutPanel2.Enabled = true;
                       
                        MessageBox.Show("Success Fetching!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //doNothing
                    }
                }
                else
                {

                

                        getRID = getMyData.myDataModel.RID;
                    if (getMyData.myDataModel.PrecedentedID != null) precededentIdTextBox.Text = getMyData.myDataModel.PrecedentedID;
                    if (getMyData.myDataModel.AssignedOfficeLocation != null) assignedOfficeLocationTextBox.Text = getMyData.myDataModel.AssignedOfficeLocation;
                    if (getMyData.myDataModel.CaseStaffRequestDate != null)
                        try { caseStaffRequestTB.Text = DateTime.Parse(getMyData.myDataModel.CaseStaffRequestDate).ToShortDateString(); }
                        catch { caseStaffRequestTB.Text = getMyData.myDataModel.CaseStaffRequestDate; }

                    if (getMyData.myDataModel.ReferenceNumber != null) referenceNumberTextBox.Text = getMyData.myDataModel.ReferenceNumber;

                    if (getMyData.myDataModel.TypeofRecord != null) typeOfRecordTextBox.Text = getMyData.myDataModel.TypeofRecord;
                    if (getMyData.myDataModel.Facility != null) facilityTextBox.Text = getMyData.myDataModel.Facility;
                    if (getMyData.myDataModel.FacilityType != null) facilityType.Text = getMyData.myDataModel.FacilityType;

                    if (getMyData.myDataModel.VendorSubmissionDate != null)
                        try { vendorSubmissionTB.Text = DateTime.Parse(getMyData.myDataModel.VendorSubmissionDate).ToShortDateString(); }
                        catch { vendorSubmissionTB.Text = getMyData.myDataModel.VendorSubmissionDate; }

                    if (getMyData.myDataModel.MethodofRequest != null) methodOfRequestTextBox.Text = getMyData.myDataModel.MethodofRequest;
                    if (getMyData.myDataModel.Portal != null) portalTextBox.Text = getMyData.myDataModel.Portal;
                    if (getMyData.myDataModel.DateResubmitted != null)
                        try { dateResubmittedTB.Text = DateTime.Parse(getMyData.myDataModel.DateResubmitted).ToShortDateString(); }
                        catch { dateResubmittedTB.Text = getMyData.myDataModel.DateResubmitted; };

                    if (getMyData.myDataModel.LastTouchAgentName != null) lastTouchAgentNameTextBox.Text = getMyData.myDataModel.LastTouchAgentName;
                    if (getMyData.myDataModel.AssignedAgent != null) assignedAgentTextBox.Text = getMyData.myDataModel.AssignedAgent;
                    if (getMyData.myDataModel.LastTouchGroup != null) lastTouchGroupTextBox.Text = getMyData.myDataModel.LastTouchGroup;
                    if (getMyData.myDataModel.FacilityPhoneNumber != null) facilityPhoneNumberNumericUpDown.Text = getMyData.myDataModel.FacilityPhoneNumber;
                    if (getMyData.myDataModel.Fax != null) faxNumericUpDown.Text = getMyData.myDataModel.Fax;
                    if (getMyData.myDataModel.Email != null) emailTextBox.Text = getMyData.myDataModel.Email;
                    if (getMyData.myDataModel.Mail != null) mailTextBox.Text = getMyData.myDataModel.Mail;
                    if (getMyData.myDataModel.Status != null) statusTextBox.Text = getMyData.myDataModel.Status;
                    if (getMyData.myDataModel.CurrentStages != null) currentStagesTextBox.Text = getMyData.myDataModel.CurrentStages;
                    if (getMyData.myDataModel.CurrentStagesFinalStages != null) currentStagesFinalDropDown.Text = getMyData.myDataModel.CurrentStagesFinalStages;
                    if (getMyData.myDataModel.CompleteDate != null)
                        try { completeDateTB.Text = DateTime.Parse(getMyData.myDataModel.CompleteDate).ToShortDateString(); }
                        catch { completeDateTB.Text = getMyData.myDataModel.CompleteDate; };

                    if (getMyData.myDataModel.Notes != null) notesTextBox.Text = "";
                    if (getMyData.myDataModel.FutureFollowUpDate != null)
                        try { futureFollowUpTB.Text = DateTime.Parse(getMyData.myDataModel.FutureFollowUpDate).ToShortDateString(); }
                        catch { futureFollowUpTB.Text = getMyData.myDataModel.FutureFollowUpDate; };

                    if (getMyData.myDataModel.InvoicePaid != null) invoicePaidTextBox.Text = getMyData.myDataModel.InvoicePaid;
                    if (getMyData.myDataModel.Pharmacy != null) pharmacyTextBox.Text = getMyData.myDataModel.Pharmacy;

                    MainPanelHolder.Visible = true;

                    button1.Enabled = false;
                    button2.Enabled = true;
                    flowLayoutPanel2.Enabled = true;

                    if (getMyData.myDataModel.AssignedAgent == "" && (fromGroup == "Completion" || fromGroup == "Escalation"))
                    {

                       // MessageBox.Show("pasok sa spec condition");
                        //currentStagesFinalDropDown.Items.Clear();
                        //currentStagesFinalDropDown.Items.AddRange(sForm.grabList);
                        dbHelper.updateAssignedUser(connectionString, getMyData.myDataModel.RID, fromUser);
                        assignedAgentTextBox.Text = fromUser;

                        MessageBox.Show("Unassigned ticket has been successfully assigned to current User!");
                    }
                    MessageBox.Show("Success Fetching!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                   
            }
            else
            {
                clearObjects();
                MessageBox.Show("No data to fetch!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
   
          
        }

        private void bgWorkerViewCurrent_DoWork(object sender, DoWorkEventArgs e)
        {
            MainPanelHolder.Invoke(new Action(() =>
            { 
                MainPanelHolder.Visible = false;  

            }));

            getSetLabelCount getSetLabelCount = new getSetLabelCount();

            getSetLabelCount.escaInvoiceCount = labelreturnedDisplay.getEscaNotifCount(connectionString, fromUser, "Escalated - Invoice").ToString();
            getSetLabelCount.escaNoRoles = labelreturnedDisplay.getEscaNotifCount(connectionString, fromUser, "Escalated - No roles").ToString();
            getSetLabelCount.noSignedHipaa = labelreturnedDisplay.getEscaNotifCount(connectionString, fromUser, "Escalated - No Signed HIPAA").ToString();
            getSetLabelCount.escaGeneralEsca = labelreturnedDisplay.getEscaNotifCount(connectionString, fromUser, "Escalated - General Escalation").ToString();
            getSetLabelCount.escaDigitalSignature = labelreturnedDisplay.getEscaNotifCount(connectionString, fromUser, "Escalated - Digital Signature not accepted").ToString();
            getSetLabelCount.escaClientPriority = labelreturnedDisplay.getEscaNotifCount(connectionString, fromUser, "Escalated - Client Priority").ToString();

          
            getSetLabelCount.notfinished = labelreturnedDisplay.GetRowCount(connectionString, fromUser, returnStatus(fromGroup), "NO").ToString();
            getSetLabelCount.finished = labelreturnedDisplay.GetRowCount(connectionString, fromUser, returnStatus(fromGroup), "YES").ToString();
            getSetLabelCount.gridDisplay = listViewReturnedDisplay.GetDataFromSqlServerViewCurrent(connectionString, fromUser);

            e.Result = getSetLabelCount;
            e.Result = getSetLabelCount;

        }

        private void bgWorkerViewCurrent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            getSetLabelCount getSetLabelCount = e.Result as getSetLabelCount;
            completedCount.Text = getSetLabelCount.finished;
            pendingCount.Text = getSetLabelCount.notfinished;

            escaInvoice.Text = getSetLabelCount.escaInvoiceCount;
            escaNoRoles.Text = getSetLabelCount.escaNoRoles;
            escaNoAssignedHipaa.Text = getSetLabelCount.noSignedHipaa;
            escaGeneralEsca.Text = getSetLabelCount.escaGeneralEsca;
            escaDigiSig.Text = getSetLabelCount.escaDigitalSignature;
            escaClientPrio.Text = getSetLabelCount.escaClientPriority;

            listViewReturnedDisplay.TransferDataToListView(getSetLabelCount.gridDisplay, listView1);
            MainPanelHolder.Visible = true;
			toolStripStatusLabel1.Text = "Row Count: " + listView1.Items.Count.ToString();


		}



        private void bgWorkerViewSubmitted_DoWork(object sender, DoWorkEventArgs e)
        {

            MainPanelHolder.Invoke(new Action(() =>
            {
                MainPanelHolder.Visible = false;

            }));
            getSetLabelCount getSetLabelCount = new getSetLabelCount();

            getSetLabelCount.gridDisplay = listViewReturnedDisplay.GetDataFromSqlServerViewLastTouch(connectionString, fromUser);
            e.Result = getSetLabelCount;

        }

        private void bgWorkerViewSubmitted_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            getSetLabelCount getSetLabelCount = e.Result as getSetLabelCount;
            listViewReturnedDisplay.TransferDataToListViewPrevious(getSetLabelCount.gridDisplay, listView1);
            MainPanelHolder.Visible = true;
			toolStripStatusLabel1.Text = "Row Count: " + listView1.Items.Count.ToString();
		}


        private void bgWorkerSave_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] parameters = (object[])e.Argument;


            //MessageBox.Show(ifReassigned);
            if(ifReassigned=="yes")
            {
                try
                {
                    MainPanelHolder.Invoke(new Action(() =>
                    {
                        MainPanelHolder.Visible = false;
                       // MessageBox.Show("pasok1");
                    }));

                        string connectionString = (string)parameters[0]; //connectionString,	1
                        string unprecedentedID = (string)parameters[1]; //precededentIdTextBox.Text, //precedentedID	2
                        string assignedOfficeLocation = (string)parameters[2]; //assignedOfficeLocationTextBox.Text,//assignedOfficeLocation	3
                        string caseStaffRequestDate = (string)parameters[3];// caseStaffRequestTB.Text,//caseStaffRequestDate	4
                        string referenceNumber = (string)parameters[4];// referenceNumberTextBox.Text,//referenceNumber	6
                        string typeofRecord = (string)parameters[5];// typeOfRecordTextBox.Text,//typeofRecord	9
                        string facility = (string)parameters[6]; //facilityTextBox.Text,//facility	10
                        string facilityType = (string)parameters[7]; //facilityType.Text,//facilityType	11
                        string vendorSubmissionDate = (string)parameters[8]; //vendorSubmissionTB.Text,//vendorSubmissionDate	14
                        string methodofRequest = (string)parameters[9];// methodOfRequestTextBox.Text,//methodofRequest	15
                        string portal = (string)parameters[10]; //portalTextBox.Text,//portal	16
                        string dateResubmitted = (string)parameters[11]; //dateResubmittedTB.Text,//dateResubmitted	17
                        string assignedAgentName = (string)parameters[12];// assignedAgentTextBox.Text,//lastTouchAgentName	18
                        string lastTouchAgentName = (string)parameters[13];//"",//assignedAgent	19
                        string lastTouchGroup = (string)parameters[14];// fromGroup,//lastTouchGroup	20
                        string facilityPhoneNumber = (string)parameters[15]; //vfacilityPhoneNumberNumericUpDown.Text,//facilityPhoneNumber	21
                        string fax = (string)parameters[16];// faxNumericUpDown.Text,//fax	22
                        string email = (string)parameters[17];// emailTextBox.Text,//email	23
                        string mail = (string)parameters[18];// mailTextBox.Text,//mail	24
                        string status = (string)parameters[19]; //checkStatus(currentStagesFinalDropDown.Text),//status	25
                        string currentStages = (string)parameters[20];// currentStagesFinalDropDown.Text,//currentStages	26
                        string finalStages = (string)parameters[21]; //"",//currentStages(FinalStages)	27
                        string completeDate = (string)parameters[22];// completeDateTB.Text,//completeDate	28
                        string notes = (string)parameters[23];// notesTextBox.Text,//notes	29
                        string futureFollowUpDate = (string)parameters[24];// futureFollowUpTB.Text,//futureFollowUpDate	30
                        string invoicePaid = (string)parameters[25]; //invoicePaidTextBox.Text,//invoicePaid	31
                        string pharmacy = (string)parameters[26];// pharmacyTextBox.Text,//pharmacy	32
                        string timeStampStart = (string)parameters[27];//startTime,//timeStampStart	34
                        string timeStampEnd = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");// endTime,//timeStampEnd	35
                        string getRID = (string)parameters[30];// getRID    37

                        sendingSql.sendData(
                            connectionString,
                            unprecedentedID,
                            assignedOfficeLocation,
                            caseStaffRequestDate,
                            referenceNumber,
                            typeofRecord,
                            facility,
                            facilityType,
                            vendorSubmissionDate,
                            methodofRequest,
                            portal,
                            dateResubmitted,
                            lastTouchAgentName,
                            assignedAgentName,
                            lastTouchGroup,
                            facilityPhoneNumber,
                            fax,
                            email,
                            mail,
                            status,
                            currentStages,
                            finalStages,
                            completeDate,
                            notes,
                            futureFollowUpDate,
                            invoicePaid,
                            pharmacy,
                            timeStampStart,
                            timeStampEnd,
                            "NO");
                    try
                    {
                       // dbHelper.InsertLogsRecord(Connection.ConnectionString, "Saving Record", fromUser, "Matter: " + referenceNumber + " Assigned Office Location: " + assignedOfficeLocation + " Facility: " + facility + " Faci Type: " + facilityType + " Record type: " + typeofRecord + " Notes: " + notes + " Status: " + status + " Current Stage: " + currentStages);
                    }
                    catch
                    {

                    }
                   
                    updatingSqlSelecting.UpdateRecord(connectionString, getRID);
                        e.Result = "Success Saving!";
                }
                catch (Exception EX)
                {
                    e.Result = EX.ToString();
                }
            }
            else
            {
                string actualAssigned = "";
                actualAssigned = dbHelper.getAssignedUser((string)parameters[0], (string)parameters[30]);
                //MessageBox.Show(actualAssigned);
                try
                {
                    MainPanelHolder.Invoke(new Action(() =>
                    {
                        MainPanelHolder.Visible = false;
                      //  MessageBox.Show("pasok3");
                    }));




                    if (fromUser == actualAssigned)
                    {
                        string connectionString = (string)parameters[0]; //connectionString,	1
                        string unprecedentedID = (string)parameters[1]; //precededentIdTextBox.Text, //precedentedID	2
                        string assignedOfficeLocation = (string)parameters[2]; //assignedOfficeLocationTextBox.Text,//assignedOfficeLocation	3
                        string caseStaffRequestDate = (string)parameters[3];// caseStaffRequestTB.Text,//caseStaffRequestDate	4
                        string referenceNumber = (string)parameters[4];// referenceNumberTextBox.Text,//referenceNumber	6
                        string typeofRecord = (string)parameters[5];// typeOfRecordTextBox.Text,//typeofRecord	9
                        string facility = (string)parameters[6]; //facilityTextBox.Text,//facility	10
                        string facilityType = (string)parameters[7]; //facilityType.Text,//facilityType	11
                        string vendorSubmissionDate = (string)parameters[8]; //vendorSubmissionTB.Text,//vendorSubmissionDate	14
                        string methodofRequest = (string)parameters[9];// methodOfRequestTextBox.Text,//methodofRequest	15
                        string portal = (string)parameters[10]; //portalTextBox.Text,//portal	16
                        string dateResubmitted = (string)parameters[11]; //dateResubmittedTB.Text,//dateResubmitted	17
                        string assignedAgentName = (string)parameters[12];// assignedAgentTextBox.Text,//lastTouchAgentName	18
                        string lastTouchAgentName = (string)parameters[13];//"",//assignedAgent	19
                        string lastTouchGroup = (string)parameters[14];// fromGroup,//lastTouchGroup	20
                        string facilityPhoneNumber = (string)parameters[15]; //vfacilityPhoneNumberNumericUpDown.Text,//facilityPhoneNumber	21
                        string fax = (string)parameters[16];// faxNumericUpDown.Text,//fax	22
                        string email = (string)parameters[17];// emailTextBox.Text,//email	23
                        string mail = (string)parameters[18];// mailTextBox.Text,//mail	24
                        string status = (string)parameters[19]; //checkStatus(currentStagesFinalDropDown.Text),//status	25
                        string currentStages = (string)parameters[20];// currentStagesFinalDropDown.Text,//currentStages	26
                        string finalStages = (string)parameters[21]; //"",//currentStages(FinalStages)	27
                        string completeDate = (string)parameters[22];// completeDateTB.Text,//completeDate	28
                        string notes = (string)parameters[23];// notesTextBox.Text,//notes	29
                        string futureFollowUpDate = (string)parameters[24];// futureFollowUpTB.Text,//futureFollowUpDate	30
                        string invoicePaid = (string)parameters[25]; //invoicePaidTextBox.Text,//invoicePaid	31
                        string pharmacy = (string)parameters[26];// pharmacyTextBox.Text,//pharmacy	32
                        string timeStampStart = (string)parameters[27];//startTime,//timeStampStart	34
                        string timeStampEnd = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss tt");// endTime,//timeStampEnd	35
                        string getRID = (string)parameters[30];// getRID    37

                        sendingSql.sendData(
                            connectionString,
                            unprecedentedID,
                            assignedOfficeLocation,
                            caseStaffRequestDate,
                            referenceNumber,
                            typeofRecord,
                            facility,
                            facilityType,
                            vendorSubmissionDate,
                            methodofRequest,
                            portal,
                            dateResubmitted,
                            assignedAgentName,
                            "",
                            lastTouchGroup,
                            facilityPhoneNumber,
                            fax,
                            email,
                            mail,
                            status,
                            currentStages,
                            finalStages,
                            completeDate,
                            notes,
                            futureFollowUpDate,
                            invoicePaid,
                            pharmacy,
                            timeStampStart,
                            timeStampEnd,
                            "NO");

                        //dbHelper.InsertLogsRecord(Connection.ConnectionString, "Saving Record", fromUser, "Matter: " + referenceNumber + " Assigned Office Location: " + assignedOfficeLocation + " Facility: " + facility + " Faci Type: " + facilityType + " Record type: " + typeofRecord + " Notes: " + notes + " Status: " + status + " Current Stage: " + currentStages);

                        updatingSqlSelecting.UpdateRecord(connectionString, getRID);


                        e.Result = "Success Saving!";
                    }
                    else
                    {
                        e.Result = actualAssigned;
                    }


                }
                catch (Exception EX)
                {
                    e.Result = EX.ToString();
                }
            }

      
        }

        private void bgWorkerSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(ifReassigned == "yes")
            {
       
                panel1.Enabled = true;
                panel6.Visible = false;
                flowLayoutPanel2.Enabled = true;
                panel39.Enabled = true;
            }
           // MessageBox.Show(e.Result.ToString() + ifReassigned + ifGrab);

            if (e.Result.ToString() == "Success Saving!")
            {
                button2.Enabled = false;
                button1.Enabled = true;
                clearObjects();
                MainPanelHolder.Visible = true;

                //bgWorkerViewCurrent.RunWorkerAsync();
                MessageBox.Show(e.Result.ToString());
            }
            else
            {
                MainPanelHolder.Visible = true;

				string yourString = "The timeout period elapsed prior to completion of the operation or the server is not responding";

				if (yourString.Contains("The timeout period elapsed prior to completion of the operation or the server is not responding"))
				{
					MessageBox.Show("Contact IT for Network problem or add additional RAM or computing power for the Server!");
				}
				else
				{
					DialogResult result = MessageBox.Show("This matter number is already Re-assigned or Grab by " + e.Result.ToString() + "! You can no longer save this information.\nYou can verify this" +
						" in search engine in Main Menu! Hit 'OK' to Clear.", "Alert-Please Read!", MessageBoxButtons.OK, MessageBoxIcon.Question);
					if (result == DialogResult.OK)
					{
						button2.Enabled = false;
						button1.Enabled = true;
						clearObjects();



					}

				}


		

            }
            currentStagesFinalDropDown.Items.Clear();
            if (fromGroup == "Intake")
            {
                currentStagesFinalDropDown.Items.AddRange(sForm.finalOutputIntake); requiredObjects.ChangeControlsBackgroundColors(requiredControlsIntake(), ColorTranslator.FromHtml("#b3ffda"));
            }
            else if (fromGroup == "Pending")
            {
             
                currentStagesFinalDropDown.Items.AddRange(sForm.finalOutputPending); requiredObjects.ChangeControlsBackgroundColors(requiredControlsPending(), ColorTranslator.FromHtml("#b3ffda"));
            }
            else if (fromGroup == "Completion")
            {
                currentStagesFinalDropDown.Items.AddRange(sForm.grabList); requiredObjects.ChangeControlsBackgroundColors(requiredControlsCompleted(), ColorTranslator.FromHtml("#b3ffda"));
            }
            else if (fromGroup == "Escalation")
            {
                currentStagesFinalDropDown.Items.AddRange(sForm.grabList); requiredObjects.ChangeControlsBackgroundColors(requiredControlsCompleted(), ColorTranslator.FromHtml("#b3ffda"));
            }
            else { }

        }

        private void CenterControl(Control control)
        {
            control.Left = (this.ClientSize.Width - control.Width) / 2;
            control.Top = (this.ClientSize.Height - control.Height) / 2;
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
            else if(input == "Completion")
            {
                return "Completed";
            }
            else if(input.Contains("Escalation"))
            {
                return "Escalated";
            }
            return "";
        }


        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            ComboBox combo = sender as ComboBox;

            if (e.Index >= 0 && combo != null)
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                Brush brush = new SolidBrush(e.ForeColor);
                e.Graphics.DrawString(combo.Items[e.Index].ToString(), e.Font, brush, e.Bounds, sf);

                brush.Dispose();
            }

            e.DrawFocusRectangle();
        }

        public Control[] requiredControlsFaxMailEmailFaci()
        {
            Control[] myControls = new Control[] { this.methodOfRequestTextBox, 
                this.faxNumericUpDown, this.emailTextBox, this.mailTextBox
            };
            return myControls;
        }


        public Control[] requiredControlsIntake()
        {
            Control[] myControls = new Control[] {this.facilityPhoneNumberNumericUpDown, this.methodOfRequestTextBox, this.facilityType,  
                this.currentStagesFinalDropDown, this.notesTextBox, this.futureFollowUpTB, this.pharmacyTextBox
            };
            return myControls;
        }

		public Control[] requiredControlsIntake_noFaci()
		{
			Control[] myControls = new Control[] { this.methodOfRequestTextBox, this.facilityType,
				this.currentStagesFinalDropDown, this.notesTextBox, this.futureFollowUpTB, this.pharmacyTextBox
			};
			return myControls;
		}


		public Control[] requiredControlsPending()
        {
            Control[] myControls = new Control[] {this.facilityPhoneNumberNumericUpDown,
                this.methodOfRequestTextBox, this.currentStagesFinalDropDown, this.notesTextBox, this.futureFollowUpTB
            };
            return myControls; 
        }

		public Control[] requiredControlsPending_noFaci()
		{
			Control[] myControls = new Control[] {
				this.methodOfRequestTextBox, this.currentStagesFinalDropDown, this.notesTextBox, this.futureFollowUpTB
			};
			return myControls;
		}



		public Control[] requiredControlsCompleted()
        {
            Control[] myControls = new Control[] { this.currentStagesFinalDropDown, this.notesTextBox, this.invoicePaidTextBox, this.futureFollowUpTB
            };
            return myControls;
        }

		void combobox_MouseWheel(object sender, MouseEventArgs e)
		{
			((HandledMouseEventArgs)e).Handled = true;
		}


		private async Task LongProcessGetFaci()
		{
			BeginInvoke(new Action(() =>
			{
				facilityType.Items.AddRange(dbHelper.getDim(connectionString, "sp_GetFacilityTypes").ToArray());
				facilityType.SelectedIndex = 0;
			}));
			
		}
		private async Task LongProcessGetPortal()
		{
			BeginInvoke(new Action(() =>
			{
				portalTextBox.Items.AddRange(dbHelper.getDim(connectionString, "sp_GetPortals").ToArray());
				portalTextBox.SelectedIndex = 0;
			}));
			
		}

	
		private async void SubmissionForm_Load(object sender, EventArgs e)
        {
            fadeIn.Start();
			invoicePaidTextBox.MouseWheel += new MouseEventHandler(combobox_MouseWheel);
			pharmacyTextBox.MouseWheel += new MouseEventHandler(combobox_MouseWheel);
            panel6.Hide(); 
	
			bgWorkerViewCurrent.RunWorkerAsync();

            assignedAgentEsca.AutoCompleteCustomSource.Clear();
            assignedAgentEsca.AutoCompleteCustomSource.AddRange(dbHelper.autoCompleteItemsRoster(connectionString,"Full Name", 0).ToArray());

            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            DisableComboBoxesScroll(facilityType, methodOfRequestTextBox, portalTextBox, currentStagesFinalDropDown);

            if(fromGroup == "Completion" || fromGroup == "Escalation")
            {
               
                statusSelector.Hide();
                label27.Enabled = false;
                recordType.Enabled = false;
                requestDateCB.Enabled = false;
                requestDateCal.Enabled = false;
                checkBox1.Enabled = false;
                matterNumberSearch.Show();
                ridTB.Show();
                label3.Text = "Matter Number: ";
                label10.Visible = true;
                ridTB.Text = "RID";
                ridTB.ForeColor = SystemColors.GrayText; // set the color of the placeholder text
            }
            else if(fromGroup == "Pending")
            {
                vendorSubmissionTB.Enabled = false;
                vendorSubmissionDatePicker.Enabled = false;

                matterNumberSearch.Visible = false;
                ridTB.Visible = false;
				linkLabel2.Show();
			}
            else
            {
                matterNumberSearch.Visible = false;
                ridTB.Visible = false;
				linkLabel2.Show();
			}


            // Set the form's size and location
            this.Location = new Point(0, 0);
            this.Size = new Size(screenWidth, screenHeight);
            this.WindowState = FormWindowState.Maximized;
          
            this.Text = "Detected User: " + fromUser + " - Detected Group: " + fromGroup;

            flowLayoutPanel2.Enabled = false;
            button2.Enabled = false;

            notesTextBox.SelectionStart = notesTextBox.Text.Length;
            notesTextBox.ScrollToCaret();
       
          
            recordType.Items.AddRange(sForm.recordType);
            recordType.SelectedIndex = 0;



			await LongProcessGetFaci();
			await LongProcessGetPortal();
			methodOfRequestTextBox.Items.AddRange(sForm.methodofRequest);
            methodOfRequestTextBox.SelectedIndex = 0; 


      

		

			pharmacyTextBox.Items.AddRange(sForm.pharmacy);

            if (fromGroup == "Intake")
            {
                statusSelector.Items.AddRange(sForm.intakeItems);
                statusSelector.SelectedIndex = 0;
                currentStagesFinalDropDown.Items.AddRange(sForm.finalOutputIntake); requiredObjects.ChangeControlsBackgroundColors(requiredControlsIntake(), ColorTranslator.FromHtml("#b3ffda"));
            }
            else if (fromGroup == "Pending")
            {
                statusSelector.Items.AddRange(sForm.pendingItems);
                statusSelector.SelectedIndex = 0;
                currentStagesFinalDropDown.Items.AddRange(sForm.finalOutputPending); requiredObjects.ChangeControlsBackgroundColors(requiredControlsPending(), ColorTranslator.FromHtml("#b3ffda"));
            }
            else if (fromGroup == "Completion")
            {
                statusSelector.Items.AddRange(sForm.moreItems);
                statusSelector.SelectedIndex = 0;
                currentStagesFinalDropDown.Items.AddRange(sForm.grabList); requiredObjects.ChangeControlsBackgroundColors(requiredControlsCompleted(), ColorTranslator.FromHtml("#b3ffda"));
            }
            else if (fromGroup == "Escalation")
            {
                statusSelector.Items.AddRange(sForm.moreItems);
                statusSelector.SelectedIndex = 0;
                currentStagesFinalDropDown.Items.AddRange(sForm.grabList); requiredObjects.ChangeControlsBackgroundColors(requiredControlsCompleted(), ColorTranslator.FromHtml("#b3ffda"));
            }
            else { }
            invoicePaidTextBox.Items.AddRange(sForm.invoicePaid);
            invoicePaidTextBox.SelectedIndex = 0;
        }

     

        private void clearObjects()
        {


            methodOfRequestTextBox.SelectedIndex = -1;
            portalTextBox.SelectedIndex = -1;
            facilityType.SelectedIndex = -1;
            currentStagesFinalDropDown.SelectedIndex = -1;
            invoicePaidTextBox.SelectedIndex = -1;
            pharmacyTextBox.SelectedIndex = -1;

            precededentIdTextBox.Text = "";
            assignedOfficeLocationTextBox.Text = "";
            caseStaffRequestTB.Text = "";
            referenceNumberTextBox.Text = "";
            typeOfRecordTextBox.Text = "";
            facilityTextBox.Text = "";
            vendorSubmissionTB.Text = "";
            vendorSubmissionDatePicker.Text = DateTime.Now.ToString("M/dd/yyyy");
            dateResubmittedTB.Text = "";
            dateResubmittedPicker.Text = DateTime.Now.ToString("M/dd/yyyy");
            lastTouchAgentNameTextBox.Text = "";
            assignedAgentTextBox.Text = "";
            lastTouchGroupTextBox.Text = "";
            facilityPhoneNumberNumericUpDown.Text = "";
            faxNumericUpDown.Text = "";
            emailTextBox.Text = "";
            mailTextBox.Text = "";
            statusTextBox.Text = "";
            currentStagesTextBox.Text = "";
            currentStagesFinalDropDown.Text = "";
            completeDateTB.Text = "";
            completeDatePicker.Text = DateTime.Now.ToString("M/dd/yyyy");
            notesTextBox.Text = "";
            futureFollowUpDatePicker.Text = DateTime.Now.ToString("M/dd/yyyy");
            futureFollowUpTB.Text = "";
            invoicePaidTextBox.Text = "";
            pharmacyTextBox.Text = "";
            matterNumberSearch.Text = "";
            ridTB.Text = "";
			determineiffaciRequired = 1;
	        
			if(fromGroup == "Intake")
			{
				revertcolor(flowLayoutPanel2, SystemColors.Window, "vendorSubmissionTB");
			}


		}
  
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (requestDateCB.Text.Contains("Request Date:"))
                {
                    bgWorkerFetch.RunWorkerAsync("Case Staff Request Date");
                }
                else
                {
                    bgWorkerFetch.RunWorkerAsync("Future Follow Up Date");
                }
            }
            catch { }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearObjects();
            restoreColor(flowLayoutPanel2);
            this.requestDateCB.Checked = false;
            this.statusSelector.SelectedIndex = 0;
            this.recordType.SelectedIndex = 0;
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void completeDatePicker_ValueChanged(object sender, EventArgs e)
        {
            completeDateTB.Text = completeDatePicker.Value.ToShortDateString();
        }

        public void methodOfRequestTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(methodOfRequestTextBox.Text == "N/A")
            {
                portalTextBox.Text = "N/A";
                requiredObjects.ChangeControlsBackgroundColors(requiredControlsFaxMailEmailFaci(), ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(methodOfRequestTextBox, ColorTranslator.FromHtml("#FFFFFF"));
            }
            else if (methodOfRequestTextBox.Text == "Fax")
            {
                portalTextBox.Text = "N/A";
                requiredObjects.ChangeControlsBackgroundColor(portalTextBox, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(faxNumericUpDown, ColorTranslator.FromHtml("#b3ffda"));
                requiredObjects.ChangeControlsBackgroundColor(emailTextBox, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(mailTextBox, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(methodOfRequestTextBox, ColorTranslator.FromHtml("#b3ffda"));
                fax_ = true;
                phone_ = false;
            }
            else if (methodOfRequestTextBox.Text == "Email")
            {
                portalTextBox.Text = "N/A";
                requiredObjects.ChangeControlsBackgroundColor(portalTextBox, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(faxNumericUpDown, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(emailTextBox, ColorTranslator.FromHtml("#b3ffda"));
                requiredObjects.ChangeControlsBackgroundColor(mailTextBox, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(methodOfRequestTextBox, ColorTranslator.FromHtml("#b3ffda"));
                fax_ = false;
                phone_ = false;
            }
            else if (methodOfRequestTextBox.Text == "Mail")
            {
                portalTextBox.Text = "N/A";
                requiredObjects.ChangeControlsBackgroundColor(portalTextBox, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(faxNumericUpDown, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(emailTextBox, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(mailTextBox, ColorTranslator.FromHtml("#b3ffda"));
                requiredObjects.ChangeControlsBackgroundColor(methodOfRequestTextBox, ColorTranslator.FromHtml("#b3ffda"));
                fax_ = false;
                phone_ = false;
            }
            else if (methodOfRequestTextBox.Text == "Portal")
            {


                portalTextBox.Text = "N/A";

                requiredObjects.ChangeControlsBackgroundColor(portalTextBox, ColorTranslator.FromHtml("#b3ffda"));
                requiredObjects.ChangeControlsBackgroundColor(faxNumericUpDown, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(emailTextBox, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(mailTextBox, ColorTranslator.FromHtml("#FFFFFF"));
                requiredObjects.ChangeControlsBackgroundColor(methodOfRequestTextBox, ColorTranslator.FromHtml("#b3ffda"));


                portalTextBox.Enabled = true;
                //facilityPhoneNumberNumericUpDown.Enabled = false;
                fax_ = false;
                phone_ = false;
            }


        }

        private void currentStagesFinalDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

			
            if (currentStagesFinalDropDown.Text == "Completed - Records Received" || currentStagesFinalDropDown.Text == "Completed - Patient Not Found" || currentStagesFinalDropDown.Text == "Completed - Cancelled Request" || currentStagesFinalDropDown.Text == "Completed - Duplicate Request")
            {
              
                requiredObjects.ChangeControlsBackgroundColor(completeDateTB, ColorTranslator.FromHtml("#b3ffda"));
            }
            else
            {
                requiredObjects.ChangeControlsBackgroundColor(completeDateTB, ColorTranslator.FromHtml("#FFFFFF"));
            }

			if(fromGroup == "Intake" && currentStagesFinalDropDown.Text == "Pending - In-Progress")
			{
				requiredObjects.ChangeControlsBackgroundColor(vendorSubmissionTB, ColorTranslator.FromHtml("#b3ffda"));
			}

        }

        private void dateResubmittedPicker_ValueChanged_1(object sender, EventArgs e)
        {
            dateResubmittedTB.Text = dateResubmittedPicker.Value.ToShortDateString();
        }

        private void vendorSubmissionDatePicker_ValueChanged(object sender, EventArgs e)
        {
            vendorSubmissionTB.Text = vendorSubmissionDatePicker.Text;
        }

        private void futureFollowUpDatePicker_ValueChanged(object sender, EventArgs e)
        {
            futureFollowUpTB.Text = futureFollowUpDatePicker.Text;
        }


        private static string checkStatus(string input)
        {
            Dictionary<string, string> map = new Dictionary<string, string>
            {
                {"New - Untouched", "New"},
                {"Pending - In-Progress", "Pending"},
                {"Pending For Completion", "Completed"},
                {"Completed - Patient Not Found", "Completed"},
                {"Completed - Cancelled Request", "Completed"},
                {"Completed - Duplicate Request", "Completed"},
                {"Completed - Records Received", "Completed"},
                {"Escalated - Invoice", "Escalated"},
                {"Escalated - No Roles", "Escalated"},
                {"Escalated - No Signed HIPAA", "Escalated"},
                {"Escalated - General Escalation", "Escalated"},
                {"Escalated - Digital Signature not accepted", "Escalated"},
                {"Escalated - Client Priority (Completion)", "Completed"},
                {"Escalated - Invoice (New)", "New"},
                {"Escalated - No roles (New)", "New"},
                {"Escalated - No Signed HIPAA (New)", "New"},
                {"Escalated - General Escalation (New)", "New"},
                {"Escalated - Digital Signature not accepted (New)", "New"},
                {"Escalated - Client Priority (New)", "New"},
                {"Escalated - Invoice (Pending)", "Pending"},
                {"Escalated - No roles (Pending)", "Pending"},
                {"Escalated - No Signed HIPAA (Pending)", "Pending"},
                {"Escalated - General Escalation (Pending)", "Pending"},
                {"Escalated - Digital Signature not accepted (Pending)", "Pending"},
                {"Escalated - Client Priority (Pending)", "Pending"},
            };
            if (map.TryGetValue(input, out string output))
            {
                return output;
            }
            return "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

               // MessageBox.Show(assignedAgentEsca.Text);
                object[] parameters = new object[]
                {

                                connectionString,
                                precededentIdTextBox.Text, //precedentedID
                                assignedOfficeLocationTextBox.Text,//assignedOfficeLocation
                                caseStaffRequestTB.Text,//caseStaffRequestDate
                                referenceNumberTextBox.Text,//referenceNumber
                                typeOfRecordTextBox.Text,//typeofRecord
                                facilityTextBox.Text,//facility
                                facilityType.Text,//facilityType
                                vendorSubmissionTB.Text,//vendorSubmissionDate
                                methodOfRequestTextBox.Text,//methodofRequest
                                portalTextBox.Text,//portal
                                dateResubmittedTB.Text,//dateResubmitted
                                assignedAgentEsca.Text,//lastTouchAgentName
                                fromUser,//assignedAgent
                                fromGroup,//lastTouchGroup
                                facilityPhoneNumberNumericUpDown.Text,//facilityPhoneNumber
                                faxNumericUpDown.Text,//fax
                                emailTextBox.Text,//email
                                mailTextBox.Text,//mail
                                checkStatus(currentStagesFinalDropDown.Text),//status
                                currentStagesFinalDropDown.Text,//currentStages
                                "",//currentStages(FinalStages)
                                completeDateTB.Text,//completeDate
                                notesTextBox.Text,//notes
                                futureFollowUpTB.Text,//futureFollowUpDate
                                invoicePaidTextBox.Text,//invoicePaid
                                pharmacyTextBox.Text,//pharmacy
                                startTime,//timeStampStart
                                endTime,//timeStampEnd
                                "NO",
                                 getRID//change to getRID before deployment
                };



                try
                {

                    bgWorkerSave.RunWorkerAsync(parameters);
                    bgWorkerViewCurrent.RunWorkerAsync();
                }
                catch
                {

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            try
            {
                restoreColor(flowLayoutPanel2);




                stringList.Clear();
                if (checkColorToRequire(flowLayoutPanel2) == true)
                {

                   // MessageBox.Show(currentStagesFinalDropDown.SelectedItem.ToString());

                    if ((currentStagesFinalDropDown.SelectedItem.ToString() != "Completed - Duplicate Request" && currentStagesFinalDropDown.SelectedItem.ToString() != "Completed - Cancelled Request" && currentStagesFinalDropDown.SelectedItem.ToString() != "Completed - Records Received" && currentStagesFinalDropDown.SelectedItem.ToString() != "Completed - Patient Not Found")==true)
                    { 
                            if ((fromGroup == "Escalation" || fromGroup == "Completion") && MessageBox.Show("Do you want to re-assign this ticket to another agent?", "MMRR App", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                              
                             
                                ifReassigned = "yes";
                                panel1.Enabled = false;
                                panel6.Visible = true;
                                flowLayoutPanel2.Enabled = false;
                                 panel39.Enabled = false;

                            }
                            else
                            {
                                var dialogResult = MessageBox.Show("Continue Saving the record?", "MMR App", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.OK)
                                {
                                    ifReassigned = "no";
                                    try
                                    {


                                        object[] parameters = new object[]
                                        {

                                            connectionString,
                                            precededentIdTextBox.Text, //precedentedID
                                            assignedOfficeLocationTextBox.Text,//assignedOfficeLocation
                                            caseStaffRequestTB.Text,//caseStaffRequestDate
                                            referenceNumberTextBox.Text,//referenceNumber
                                            typeOfRecordTextBox.Text,//typeofRecord
                                            facilityTextBox.Text,//facility
                                            facilityType.Text,//facilityType
                                            vendorSubmissionTB.Text,//vendorSubmissionDate
                                            methodOfRequestTextBox.Text,//methodofRequest
                                            portalTextBox.Text,//portal
                                            dateResubmittedTB.Text,//dateResubmitted
                                            assignedAgentTextBox.Text,//lastTouchAgentName
                                            "",//assignedAgent
                                            fromGroup,//lastTouchGroup
                                            facilityPhoneNumberNumericUpDown.Text,//facilityPhoneNumber
                                            faxNumericUpDown.Text,//fax
                                            emailTextBox.Text,//email
                                            mailTextBox.Text,//mail
                                            checkStatus(currentStagesFinalDropDown.Text),//status
                                            currentStagesFinalDropDown.Text,//currentStages
                                            "",//currentStages(FinalStages)
                                            completeDateTB.Text,//completeDate
                                            notesTextBox.Text,//notes
                                            futureFollowUpTB.Text,//futureFollowUpDate
                                            invoicePaidTextBox.Text,//invoicePaid
                                            pharmacyTextBox.Text,//pharmacy
                                            startTime,//timeStampStart
                                            endTime,//timeStampEnd
                                            "NO",
                                             getRID//change to getRID before deployment
                                        };


                                        try
                                        {

                                            bgWorkerSave.RunWorkerAsync(parameters);
                                            bgWorkerViewCurrent.RunWorkerAsync();
                                        }
                                        catch
                                        {

                                        }


                                    }
                                    catch (Exception ex)
                                    {

                                        MessageBox.Show(ex.ToString());
                                    }
                            }
                            else
                            {
                                //do nothing
                            }
                        }
                    }
                    else
                    {

                        var dialogResult = MessageBox.Show("Continue Saving the record?", "MMR App", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.OK)
                        {
                            ifReassigned = "no";
                            try
                            {


                                object[] parameters = new object[]
                                {

                                    connectionString,
                                    precededentIdTextBox.Text, //precedentedID
                                    assignedOfficeLocationTextBox.Text,//assignedOfficeLocation
                                    caseStaffRequestTB.Text,//caseStaffRequestDate
                                    referenceNumberTextBox.Text,//referenceNumber
                                    typeOfRecordTextBox.Text,//typeofRecord
                                    facilityTextBox.Text,//facility
                                    facilityType.Text,//facilityType
                                    vendorSubmissionTB.Text,//vendorSubmissionDate
                                    methodOfRequestTextBox.Text,//methodofRequest
                                    portalTextBox.Text,//portal
                                    dateResubmittedTB.Text,//dateResubmitted
                                    assignedAgentTextBox.Text,//lastTouchAgentName
                                    "",//assignedAgent
                                    fromGroup,//lastTouchGroup
                                    facilityPhoneNumberNumericUpDown.Text,//facilityPhoneNumber
                                    faxNumericUpDown.Text,//fax
                                    emailTextBox.Text,//email
                                    mailTextBox.Text,//mail
                                    checkStatus(currentStagesFinalDropDown.Text),//status
                                    currentStagesFinalDropDown.Text,//currentStages
                                    "",//currentStages(FinalStages)
                                    completeDateTB.Text,//completeDate
                                    notesTextBox.Text,//notes
                                    futureFollowUpTB.Text,//futureFollowUpDate
                                    invoicePaidTextBox.Text,//invoicePaid
                                    pharmacyTextBox.Text,//pharmacy
                                    startTime,//timeStampStart
                                    endTime,//timeStampEnd
                                    "NO",
                                     getRID//change to getRID before deployment
                                };



                                try
                                {

                                    bgWorkerSave.RunWorkerAsync(parameters);
                                    bgWorkerViewCurrent.RunWorkerAsync();
                                }
                                catch
                                {

                                }


                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.ToString());
                            }
                        }
                        else
                        {
                            //do nothing
                        }


                    }



                }
                else
                {
                    MessageBox.Show("Please complete fields highlighted in Red!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
         
           
               
        
           

        }

        public void restoreColor(Control parentControl)
        {

         
            foreach (Control childControl in parentControl.Controls)
            {
                if (childControl.Parent.BackColor == Color.LightPink)
                {
                    childControl.Parent.BackColor = ColorTranslator.FromHtml("#aee2ff");
                }
                restoreColor(childControl);
            }
           
         
        }

        private bool checkColorToRequire(Control parentControl)
        {
            foreach (Control childControl in parentControl.Controls)
            {
                if (childControl.BackColor == ColorTranslator.FromHtml("#b3ffda"))
                {

                    if(determineiffaciRequired ==1)
					{
						if (childControl.Name == "facilityPhoneNumberNumericUpDown")
						{
							if (childControl.Text.Length != 10) 

							{
								childControl.Parent.BackColor = Color.LightPink;
								stringList.Add("False");
							}
                        else
                        {
								stringList.Add("True");
							}
						}
					}
                   

                    if (childControl.Name == "faxNumericUpDown" && childControl.BackColor == ColorTranslator.FromHtml("#b3ffda"))
                    {
                        if (childControl.Text.Length != 10)
                        {
                            childControl.Parent.BackColor = Color.LightPink;
                            stringList.Add("False");
                        }
                        else
                        {
                            stringList.Add("True");
                        }
                    }

                    if (childControl.Text == "")
                    {
                        childControl.Parent.BackColor = Color.LightPink;
                        stringList.Add("False");
                    }
                    else
                    {
                        stringList.Add("True");
                    }
                }
                checkColorToRequire(childControl);
            }
            if(stringList.Contains("False"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void facilityPhoneNumberNumericUpDown_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
         
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       
        }


        private void SubmissionForm_Resize(object sender, EventArgs e)
        {
            CenterControl(pictureBox1);
        }

        private void statusSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            statusSelectorStr = statusSelector.SelectedItem.ToString();
           
        }

        private void recordType_SelectedIndexChanged(object sender, EventArgs e)
        {
            recordTypeStr = recordType.SelectedItem.ToString();
           
        }

        private void requestDateCal_ValueChanged(object sender, EventArgs e)
        {
            requestedDateStr = requestDateCal.Text;
        }

        private void DisableComboBoxesScroll(params ComboBox[] comboBoxes)
        {
            foreach (ComboBox comboBox in comboBoxes)
            {
                comboBox.MouseWheel += new MouseEventHandler(ComboBox_MouseWheel);
            }
        }

        private void ComboBox_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        private void matterNumberSearch_TextChanged(object sender, EventArgs e)
        {
            matterNumberSearching = matterNumberSearch.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RIDtb = ridTB.Text; //flag
        }

        private void ridTB_Enter(object sender, EventArgs e)
        {
            if (ridTB.Text == "RID")
            {
                ridTB.Text = "";
                ridTB.ForeColor = SystemColors.WindowText; // restore the color of the text
            }
        }

        private void ridTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ridTB.Text))
            {
                ridTB.Text = "RID";
                ridTB.ForeColor = SystemColors.GrayText; // set the color of the placeholder text
            }
        }

        private void currentStagesFinalDropDown_Click(object sender, EventArgs e)
        {
         
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.C && fromGroup == "Escalation" || fromGroup == "Completion")
                {
                    // Get the selected items
                    var selectedItems = listView1.SelectedItems;

                    // Copy the items to the clipboard
                    var sb = new StringBuilder();
                    foreach (ListViewItem item in selectedItems)
                    {
                        foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        {
                            sb.Append(subItem.Text);
                            sb.Append("\t");
                        }
                        sb.AppendLine();
                    }
                    Clipboard.SetText(sb.ToString());
                    string clipboardText = Clipboard.GetText();
                    string[] items = clipboardText.Split('\t');
                    string firstItem = items[0];
                    string fifthItem = items[4];

                    // Display the values
                    ridTB.Text = firstItem;
                    matterNumberSearch.Text =  fifthItem;

                    // Mark the event as handled
                    e.Handled = true;
                    MessageBox.Show("Successfully copied!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {

            }
            // Check if the user pressed Ctrl+C
           
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            try
            {
                // Check if the cell is selected
                // Check if the cell belongs to the selected row and column
                if (e.Item.Selected && e.ColumnIndex == 1)
                {
                    // Draw the background of the cell in a different color
                    e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                }

                // Draw the text of the cell
                e.DrawText();
            }
            catch
            {

            }
          
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
          

            if (Application.OpenForms["Bulk_Editing_and_Assigning"] == null)
            {
                Submission_CS.Bulk_Editing_and_Assigning bulk_Editing_And_Assigning = new Submission_CS.Bulk_Editing_and_Assigning();
                //bulk editRecords = new EditRecordsForm();
                bulk_Editing_And_Assigning.Show();
            }
            else
            {
                MessageBox.Show("Already running at the background!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab.Text == "View Submitted")
            {
                bgWorkerViewSubmitted.RunWorkerAsync();
               
            }
            else if(tabControl1.SelectedTab.Text == "View Current")
            {
                bgWorkerViewCurrent.RunWorkerAsync();
              
            }
        }

		private void notesTextBox_TextChanged(object sender, EventArgs e)
		{
			label14.Text = "(" + notesTextBox.TextLength.ToString() + "/" + "3000)";
		}

		private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var dialog = MessageBox.Show("Are you sure that there is no facility phone number?", "Information", MessageBoxButtons.YesNo);

			if(dialog == DialogResult.Yes)
			{
				determineiffaciRequired = 0;
			

				revertcolor(flowLayoutPanel2, SystemColors.Window, "facilityPhoneNumberNumericUpDown");
                MessageBox.Show("Success!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

		}
		private void revertcolor(Control control, Color systemColors, string controlName)
		{
			foreach (Control childControl in control.Controls)
			{


				if (childControl.Name == controlName)
				{
					childControl.BackColor = systemColors;
					childControl.Text = "";
					break;
				}

				revertcolor(childControl, systemColors, controlName);
			}
		}

		private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
		{

            try
            {
                Clipboard.SetText(referenceNumberTextBox.Text);
                MessageBox.Show("Success copying " + referenceNumberTextBox.Text + "!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Value Cannot be null!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
		}

        private void requestDateCB_CheckedChanged(object sender, EventArgs e)
        {

            // Update the originalCheckedState whenever the checked state changes
            originalCheckedState = requestDateCB.Checked;
            
        }

        private void requestDateCB_Click(object sender, EventArgs e)
        {


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (requestDateCB.Text == "Follow-up Date: ")
            {
                requestDateCB.Text = "Request Date: ";
                requestDateCB.Checked = originalCheckedState;

            }
            else
            {
                requestDateCB.Text = "Follow-up Date: ";
                requestDateCB.Checked = originalCheckedState;

            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel39.Enabled = true;
            panel1.Enabled = true;
            flowLayoutPanel2.Enabled = true;

         
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
            //StyleHelper.ApplyStyleLoginOP360(this);
        }

		private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{

		}

		private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Clipboard.SetText(methodOfRequestTextBox.Text);
				MessageBox.Show("Success copying " + methodOfRequestTextBox.Text + "!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch
			{
				MessageBox.Show("Value Cannot be null!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Clipboard.SetText(currentStagesFinalDropDown.Text);
				MessageBox.Show("Success copying " + currentStagesFinalDropDown.Text + "!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch
			{
				MessageBox.Show("Value Cannot be null!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Clipboard.SetText(notesTextBox.Text);
				MessageBox.Show("Success copying " + notesTextBox.Text + "!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch
			{
				MessageBox.Show("Value Cannot be null!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{

			try
			{
				Clipboard.SetText(futureFollowUpTB.Text);
				MessageBox.Show("Success copying " + futureFollowUpTB.Text + "!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch
			{
				MessageBox.Show("Value Cannot be null!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
