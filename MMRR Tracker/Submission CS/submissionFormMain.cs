using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace MMRR_Tracker
{
    class submissionFormMain
    {
        private string connectionString;

        public submissionFormMain(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public MyDataModel GetDataByUserId(string userId, string statusSelectorFilter, string recordTypeFilter, string requestDateFilter, bool isRequestDate, string fromWhere ,string colName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
				command.CommandTimeout = 120; // timeout

				// MessageBox.Show(fromWhere + " " + recordTypeFilter + " " + statusSelectorFilter + " " + requestDateFilter);

				if (statusSelectorFilter != "Default" && recordTypeFilter == "Default")
                {
                  // MessageBox.Show(colName);

                    if (isRequestDate == true)
                    {
                        command = new SqlCommand("firstConditionWithRequestDate", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@fromWhere", fromWhere);
                        command.Parameters.AddWithValue("@statusSelectorFilter", statusSelectorFilter);
                        command.Parameters.AddWithValue("@requestDate", requestDateFilter);
                        command.Parameters.AddWithValue("@ColumnName", colName);
                    }
                    else
                    {
                        command = new SqlCommand("firstCondition", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@fromWhere", fromWhere);
                        command.Parameters.AddWithValue("@statusSelectorFilter", statusSelectorFilter);
                    }

                   
                }
                else if (recordTypeFilter != "Default" && statusSelectorFilter == "Default")
                {
                    recordTypeFilter = "%" + recordTypeFilter + "%";
                   // MessageBox.Show("Pasok 2");
                    if (isRequestDate == true)
                    {
                        command = new SqlCommand("secondConditionWithRequestDate", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@fromWhere", fromWhere);
                        command.Parameters.AddWithValue("@recordTypeFilter", recordTypeFilter);
                        command.Parameters.AddWithValue("@requestDate", requestDateFilter);
                        command.Parameters.AddWithValue("@ColumnName", colName);
                    }
                    else
                    {
                        command = new SqlCommand("secondCondition", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@fromWhere", fromWhere);
                        command.Parameters.AddWithValue("@recordTypeFilter", recordTypeFilter);
                    }

                   
                }
                else if(statusSelectorFilter != "Default" && recordTypeFilter != "Default")
                {
                 //  MessageBox.Show("Pasok 3");

                    if (isRequestDate == true)
                    {
                        command = new SqlCommand("thirdConditionWithRequestDate", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@recordTypeFilter", recordTypeFilter);
                        command.Parameters.AddWithValue("@fromWhere", fromWhere);
                        command.Parameters.AddWithValue("@statusSelectorFilter", statusSelectorFilter);
                        command.Parameters.AddWithValue("@requestDate", requestDateFilter);
                        command.Parameters.AddWithValue("@ColumnName", colName);
                    }
                    else
                    {
                        command = new SqlCommand("thirdCondition", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@recordTypeFilter", recordTypeFilter);
                        command.Parameters.AddWithValue("@fromWhere", fromWhere);
                        command.Parameters.AddWithValue("@statusSelectorFilter", statusSelectorFilter);
                        command.Parameters.AddWithValue("@ColumnName", colName);
                    }

                    
                }
                else
                {
                   // MessageBox.Show("Pasok 4");

                    if (isRequestDate == true)
                    {
                        command = new SqlCommand("fourthConditionWithRequestDate", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@fromWhere", fromWhere);
                        command.Parameters.AddWithValue("@requestDate", requestDateFilter);
                        command.Parameters.AddWithValue("@ColumnName", colName);
                    }
                    else
                    {
                       
                        command = new SqlCommand("fourthCondition", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@fromWhere", fromWhere);
                    }



                }
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MyDataModel data = new MyDataModel();
                    data.RID = reader["RID"].ToString();
                    data.PrecedentedID = reader["Precedented ID"].ToString();
                    data.AssignedOfficeLocation = reader["Assigned Office Location"].ToString();
                    data.CaseStaffRequestDate = reader["Case Staff Request Date"].ToString();
                    data.ReferenceNumber = reader["Reference Number"].ToString();
                    data.TypeofRecord = reader["Type of Record (Billing Statement, Abstract, Records)"].ToString();
                    data.Facility = reader["Facility"].ToString();
                    data.FacilityType = reader["Facility Type"].ToString();
                    data.VendorSubmissionDate = reader["Vendor Submission Date"].ToString();
                    data.MethodofRequest = reader["Method of Request"].ToString();
                    data.Portal = reader["Portal"].ToString();
                    data.DateResubmitted = reader["Date Resubmitted"].ToString();
                    data.LastTouchAgentName = reader["Last Touch Agent Name"].ToString();
                    data.AssignedAgent = reader["Assigned Agent"].ToString();
                    data.LastTouchGroup = reader["Last Touch Group"].ToString();
                    data.FacilityPhoneNumber = reader["Facility Phone Number"].ToString();
                    data.Fax = reader["Fax"].ToString();
                    data.Email = reader["Email"].ToString();
                    data.Mail = reader["Mail"].ToString();
                    data.Status = reader["Status"].ToString();
                    data.CurrentStages = reader["Current Stages"].ToString();
                    data.CurrentStagesFinalStages = reader["Current Stages (Final Stages)"].ToString();
                    data.CompleteDate = reader["Complete Date"].ToString();
                    data.Notes = reader["Notes"].ToString();
                    data.FutureFollowUpDate = reader["Future Follow Up Date"].ToString();
                    data.InvoicePaid = reader["Invoice Paid"].ToString();
                    data.Pharmacy = reader["Pharmacy"].ToString();
                    data.isDone = reader["isDone"].ToString();
                    connection.Close();
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }

        public MyDataModel GetDataByUserIdCompEsca(string userId, string matterNumber, string recordTypeFilter, string requestDateFilter, bool isRequestDate, string fromWhere, string RID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
				command.CommandTimeout = 120; // timeout

				// MessageBox.Show(fromWhere + " " + recordTypeFilter  + " " + requestDateFilter);
				if (recordTypeFilter == "Default")
                {
                    if (isRequestDate == true)
                    {
                       // MessageBox.Show("Pasok1" + requestDateFilter);
                        command = new SqlCommand("escaCompletefirstConditionWithRequestDate", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@matterNumber", matterNumber);
                        command.Parameters.AddWithValue("@requestDate", requestDateFilter);
                        command.Parameters.AddWithValue("@RID", RID);
                    }
                    else
                    {
                      //  MessageBox.Show("Pasok2");
                        command = new SqlCommand("escaCompletefirstCondition", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@matterNumber", matterNumber);
                        command.Parameters.AddWithValue("@RID", RID);
                    }
                }
                else if (recordTypeFilter != "Default")
                {
                    if (isRequestDate == true)
                    {
                        //MessageBox.Show("Pasok3");
                        command = new SqlCommand("escaCompletefirstConditionWithRequestDatewithRecordType", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@matterNumber", matterNumber);
                        command.Parameters.AddWithValue("@requestDate", requestDateFilter);
                        command.Parameters.AddWithValue("@recordType", "%" + recordTypeFilter + "%");
                        command.Parameters.AddWithValue("@RID", RID);
                    }
                    else
                    {
                      //  MessageBox.Show("Pasok4");
                        command = new SqlCommand("escaCompletefirstConditionwithRecordType", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@matterNumber", matterNumber);
                        command.Parameters.AddWithValue("@recordType", "%" + recordTypeFilter + "%");
                        command.Parameters.AddWithValue("@RID", RID);
                    }
                }
                else
                {

                }

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MyDataModel data = new MyDataModel();
                    data.RID = reader["RID"].ToString();
                    data.PrecedentedID = reader["Precedented ID"].ToString();
                    data.AssignedOfficeLocation = reader["Assigned Office Location"].ToString();
                    data.CaseStaffRequestDate = reader["Case Staff Request Date"].ToString();
                    data.ReferenceNumber = reader["Reference Number"].ToString();
                    data.TypeofRecord = reader["Type of Record (Billing Statement, Abstract, Records)"].ToString();
                    data.Facility = reader["Facility"].ToString();
                    data.FacilityType = reader["Facility Type"].ToString();
                    data.VendorSubmissionDate = reader["Vendor Submission Date"].ToString();
                    data.MethodofRequest = reader["Method of Request"].ToString();
                    data.Portal = reader["Portal"].ToString();
                    data.DateResubmitted = reader["Date Resubmitted"].ToString();
                    data.LastTouchAgentName = reader["Last Touch Agent Name"].ToString();
                    data.AssignedAgent = reader["Assigned Agent"].ToString();
                    data.LastTouchGroup = reader["Last Touch Group"].ToString();
                    data.FacilityPhoneNumber = reader["Facility Phone Number"].ToString();
                    data.Fax = reader["Fax"].ToString();
                    data.Email = reader["Email"].ToString();
                    data.Mail = reader["Mail"].ToString();
                    data.Status = reader["Status"].ToString();
                    data.CurrentStages = reader["Current Stages"].ToString();
                    data.CurrentStagesFinalStages = reader["Current Stages (Final Stages)"].ToString();
                    data.CompleteDate = reader["Complete Date"].ToString();
                    data.Notes = reader["Notes"].ToString();
                    data.FutureFollowUpDate = reader["Future Follow Up Date"].ToString();
                    data.InvoicePaid = reader["Invoice Paid"].ToString();
                    data.Pharmacy = reader["Pharmacy"].ToString();
                    data.isDone = reader["isDone"].ToString();
                    connection.Close();
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }

    }
    public class MyDataModel
    {
        public string RID { get; set; }
        public string PrecedentedID { get; set; }
        public string AssignedOfficeLocation { get; set; }
        public string CaseStaffRequestDate { get; set; }
        public string ReferenceNumber { get; set; }
        public string TypeofRecord { get; set; }
        public string Facility { get; set; }
        public string FacilityType { get; set; }
        public string VendorSubmissionDate { get; set; }
        public string MethodofRequest { get; set; }
        public string Portal { get; set; }
        public string DateResubmitted { get; set; }
        public string LastTouchAgentName { get; set; }
        public string AssignedAgent { get; set; }
        public string LastTouchGroup { get; set; }
        public string FacilityPhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Mail { get; set; }
        public string Status { get; set; }
        public string CurrentStages { get; set; }
        public string CurrentStagesFinalStages{ get; set; }
        public string CompleteDate { get; set; }
        public string Notes { get; set; }
        public string FutureFollowUpDate { get; set; }
        public string InvoicePaid { get; set; }
        public string Pharmacy { get; set; }
        public string isDone { get; set; }
    }
}
