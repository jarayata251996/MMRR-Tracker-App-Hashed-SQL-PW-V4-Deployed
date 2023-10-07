using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.DirectoryServices;
using System.IO;

namespace MMRR_Tracker
{
    class DBHelper
    {

        public static SqlConnection connection = new SqlConnection(Connection.ConnectionString);
        public static string Excel03ConString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"; 
        public static string Excel07ConString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        public static string fullName, workGroup, fullName_isMigrating;



        #region combobox items
        public static string[] intakeItems = new string[]
        {
            "INBOUND CALL",
            "Escalated - Invoice (New)",
            "Escalated - No roles (New)",
            "Escalated - No Signed HIPAA (New)",
            "Escalated - General Escalation (New)",
            "Escalated - Digital Signature not accepted (New)",
            "Escalated - Client Priority (New)"
        };

        public static string[] pendingItems = new string[]
        {
            "INBOUND CALL",
            "Escalated - Invoice (Pending)",
            "Escalated - No roles (Pending)",
            "Escalated - No Signed HIPAA (Pending)",
            "Escalated - General Escalation (Pending)",
            "Escalated - Digital Signature not accepted (Pending)",
            "Escalated - Client Priority (Pending)"
        };

        public static string[] completionItems = new string[]
        {
            "CORRESPONDENCE",
            "Escalated - Invoice",
            "Escalated - No roles",
            "Escalated - No Signed HIPAA",
            "Escalated - General Escalation",
            "Escalated - Digital Signature not accepted",
            "Escalated - Client Priority",
            "Escalated - Client Priority (Completion)"
        };
        #endregion

        #region inRoster
        public static int inRoster(string ntUsernname)
        {
            int isInRoster = 0;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("checkIfInRoster", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ntusername", ntUsernname);
                isInRoster = Convert.ToInt32(sqlCommand.ExecuteScalar());
                //var dataReader = sqlCommand.ExecuteReader();
                //while (dataReader.Read())
                //{
                //    isInRoster = 1;
                //}
                //dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isInRoster;
        }
        #endregion

        #region ActiveDirectoryLogin
        public static int ntLogin(string username, string password, string domainName)
        {
            int isLogin = 0;
            if (inRoster(username) > 0)
            {
                DirectoryEntry entry = new DirectoryEntry($"LDAP://{domainName}", username, password);
                try
                {
                    // Authenticate the user's credentials
                    object nativeObject = entry.NativeObject;

                    // Retrieve the user's display name
                    DirectorySearcher searcher = new DirectorySearcher(entry);
                    searcher.Filter = $"(&(objectClass=user)(sAMAccountName={username}))";
                    SearchResult result = searcher.FindOne();
                    string displayName = result.Properties["displayName"][0].ToString();

                    isLogin = 1;
                }
                catch
                {
                    MessageBox.Show("You are using wrong credentials that can lead your account to be LOCKED OUT", "MMRR App", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //MessageBox.Show(ex.ToString());
                    isLogin = 0;
                }
            }
            else if(username != "OP360 Username")
            {
                MessageBox.Show("This NT Username: " + username + " is not yet registered to the application", "MMRR App", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return isLogin;
        }
        #endregion

        #region GetWorkgroup And FullName
        public static int tryLogin(string username)
        {
            int userFound = 0;
            SqlCommand sqlCommand = new SqlCommand("tryLogin", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = username;
            var dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                userFound += 1;
                fullName = dataReader["Full Name"].ToString();
                workGroup = dataReader["Work Group"].ToString();
            }
            dataReader.Close();
            return userFound;
        }
        #endregion

        #region isMigrating
        public static int isMigratingStatus()
        {
            int isMigrating = 0;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("checkIfMigrating", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                isMigrating = Convert.ToInt32(sqlCommand.ExecuteScalar());
                var dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    fullName_isMigrating = "";
                    fullName_isMigrating = dataReader["Full Name"].ToString();
                }
                dataReader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isMigrating;
        }

        public static void updateIsMigrating(string migratorFname, string isMigrating)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("triggerMigrating", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MigratorName", migratorFname);
                sqlCommand.Parameters.AddWithValue("@isMigrating", isMigrating);
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region dataFetching
        public static void filterDataToDgvEditForm(string repositoryType, string filterTypeCol, string filterTypeValue, string datePicked, string caseStaffReqDatePicked, DataGridView dataGridView, DateTimePicker datePickerForCaseStaff, CheckBox checkBoxForCaseStaff)
        {
            dataGridView.Columns.Clear();
            try
            {
                if (filterTypeCol == "Vendor Submission Date" ||
                    filterTypeCol == "Date Resubmitted" || filterTypeCol == "Complete Date" || filterTypeCol == "Future Follow Up Date")
                {
                    if (checkBoxForCaseStaff.Checked == true)
                    {
                        SqlCommand command = new SqlCommand("selectAllBaseOnRepotypeandReqDate", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@status", repositoryType);
                        command.Parameters.AddWithValue("@requestDate", caseStaffReqDatePicked);
                        command.Parameters.AddWithValue("@ColumnName", filterTypeCol);
                        command.Parameters.AddWithValue("@datePicked", datePicked);
                        SqlDataAdapter da1 = new SqlDataAdapter();
                        da1.SelectCommand = command;
                        DataSet ds1 = new DataSet();
                        
                        da1.Fill(ds1, "MMRR_Repo");
                        dataGridView.DataSource = ds1.Tables["MMRR_Repo"].DefaultView;
                    }
                    else
                    {
                        SqlCommand command = new SqlCommand("selectAllBaseOnRepotypeandReqDateWithoutCaseReqDate", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@status", repositoryType);
                        command.Parameters.AddWithValue("@ColumnName", filterTypeCol);
                        command.Parameters.AddWithValue("@datePicked", datePicked);
                        SqlDataAdapter da1 = new SqlDataAdapter();
                        da1.SelectCommand = command;
                        DataSet ds1 = new DataSet();

                        da1.Fill(ds1, "MMRR_Repo");
                        dataGridView.DataSource = ds1.Tables["MMRR_Repo"].DefaultView;

                        //SqlDataAdapter da2 = new SqlDataAdapter(@"SELECT * FROM [dbo].[Repository] WHERE Status = '" + repositoryType + "' AND [" + filterTypeCol + "] = '" + datePicked + "'", connection);
                        //DataSet ds2 = new DataSet();
                        //da2.Fill(ds2, "Repository");
                        //dataGridView.DataSource = ds2.Tables["Repository"].DefaultView;
                    }
                }
                else if (checkBoxForCaseStaff.Checked == true)
                {
                    SqlCommand command = new SqlCommand("selectAllBaseOnRepotypeWithReqDatefilterVal", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@status", repositoryType);
                    command.Parameters.AddWithValue("@requestDate", caseStaffReqDatePicked);
                    command.Parameters.AddWithValue("@ColumnName", filterTypeCol);
                    command.Parameters.AddWithValue("@filterVal", filterTypeValue);
                    SqlDataAdapter da1 = new SqlDataAdapter();
                    da1.SelectCommand = command;
                    DataSet ds1 = new DataSet();

                    da1.Fill(ds1, "MMRR_Repo");
                    dataGridView.DataSource = ds1.Tables["MMRR_Repo"].DefaultView;


                    //SqlDataAdapter da3 = new SqlDataAdapter(@"SELECT * FROM [dbo].[Repository] WHERE Status = '" + repositoryType + "' AND [" + filterTypeCol + "] = '" + filterTypeValue + "' AND [Case Staff Request Date] = '" + caseStaffReqDatePicked + "'", connection);
                    //DataSet ds3 = new DataSet();
                    //da3.Fill(ds3, "Repository");
                    //dataGridView.DataSource = ds3.Tables["Repository"].DefaultView;
                }
                else
                {
                    SqlCommand command = new SqlCommand("selectAllBaseOnRepotypeFilterVal", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@status", repositoryType);
                    command.Parameters.AddWithValue("@ColumnName", filterTypeCol);
                    command.Parameters.AddWithValue("@filterVal", filterTypeValue);
                    SqlDataAdapter da1 = new SqlDataAdapter();
                    da1.SelectCommand = command;
                    DataSet ds1 = new DataSet();

                    da1.Fill(ds1, "MMRR_Repo");
                    dataGridView.DataSource = ds1.Tables["MMRR_Repo"].DefaultView;



                    //SqlDataAdapter da4 = new SqlDataAdapter(@"SELECT * FROM [dbo].[Repository] WHERE Status = '" + repositoryType + "' AND [" + filterTypeCol + "] = '" + filterTypeValue + "'", connection);
                    //DataSet ds4 = new DataSet();
                    //da4.Fill(ds4, "Repository");
                    //dataGridView.DataSource = ds4.Tables["Repository"].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
        #endregion

        #region autoComplete List
        public static List<string> autoCompleteItemsRepo(string columnnames, int columnindex)
        {
            List<string> list = new List<string>();
            try
            {
                SqlCommand command = new SqlCommand("getAutocompleteItemsMainTable", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ColumnName", SqlDbType.NVarChar).Value = columnnames;

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string hldr = dataReader.GetValue(columnindex).ToString();
                    list.Add(hldr);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            return list;
        }

        public static List<string> autoCompleteItemsRoster(string columnnames, int columnindex)
        {
            List<string> list = new List<string>();
            try
            {
                SqlCommand command = new SqlCommand("getAutocompleteItemsRosterTable", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ColumnName", columnnames);

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string hldr = dataReader.GetValue(columnindex).ToString();
                    list.Add(hldr);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            return list;
        }
        #endregion

        #region Update Records
        public static void updateRecords(string assignedAgent, string isDone, string currentStages, string rid, Form editRecordsFormPhase1)
        {
            try
            {
                //if (DBHelper.workGroup.Contains("RTA"))
                //{
                //    SqlCommand sqlCommand = new SqlCommand("UPDATE [dbo].[Repository] SET [Assigned Agent] = '" + assignedAgent + "', [isDone] = '" + isDone + "' WHERE [Precedented ID] = '" + precedentedID + "' AND [RID] = '" + rid + "'", connection);
                //    sqlCommand.ExecuteNonQuery();
                //    MessageBox.Show("Data Updated Successfully!", "MMRR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    editRecordsFormPhase1.Hide();
                //}
                //else if (DBHelper.workGroup.Contains("Escalation"))
                //{
                //    SqlCommand sqlCommand = new SqlCommand("UPDATE [dbo].[Repository] SET [Notes] = '" + notes + "', [Current Stages] = '" + currentStages + "' WHERE [Precedented ID] = '" + precedentedID + "' AND [RID] = '" + rid + "'", connection);
                //    sqlCommand.ExecuteNonQuery();
                //    MessageBox.Show("Data Updated Successfully!", "MMRR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    editRecordsFormPhase1.Hide();
                //}

                if (DBHelper.workGroup.Contains("RTA") || DBHelper.workGroup.Contains("Developer"))
                {
                    SqlCommand sqlCommand = new SqlCommand("rtaAssigningAndDataEditing", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@AssignedAgent", assignedAgent);
                    sqlCommand.Parameters.AddWithValue("@IsDone", isDone);
                    sqlCommand.Parameters.AddWithValue("@CurrentStages", currentStages);
                    sqlCommand.Parameters.AddWithValue("@RID", rid);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Data Updated Successfully!", "MMRR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    editRecordsFormPhase1.Hide();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region updateWG
        public static void updateAgentPW(string userName, string newWorkGroup, Form changePWForm, Form loginForm)
        {
            if (userName != "" && newWorkGroup !="")
            {
                if (userName == "Full Name" || newWorkGroup == "New Work Group")
                {
                    MessageBox.Show("Must fill all the fields!", "MMRR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand(@"UPDATE [dbo].[Roster] SET [Work Group] = '" + newWorkGroup + "' WHERE [Full Name] = '" + userName + "'", connection);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Information updated successfully!", "MMRR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        changePWForm.Hide();
                        loginForm.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "MMRR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Must fill all the fields!", "MMRR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region comboboxItemsfromDB
        public static List<string> comboboxItems(string tablename, string columnnames, int columnindex)
        {
            List<string> list = new List<string>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT " + columnnames + " FROM " + tablename + "", connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string hldr = dataReader.GetValue(columnindex).ToString();
                    list.Add(hldr);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            return list;
        }
        #endregion

        #region registerNewUser
        public static void registerUser(string employeeID, string fullName, string emailOP360, string emailFTP, string workGroup, string ntUsername, Form regForm, Form loginForm)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("registerUser", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@EmpID", SqlDbType.NVarChar).Value = employeeID;
                sqlCommand.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = fullName;
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = emailOP360;
                sqlCommand.Parameters.Add("@FTPEmail", SqlDbType.NVarChar).Value = emailFTP;
                sqlCommand.Parameters.Add("@WorkGroup", SqlDbType.NVarChar).Value = workGroup;
                sqlCommand.Parameters.Add("@NTUserName", SqlDbType.NVarChar).Value = ntUsername;
                sqlCommand.ExecuteNonQuery();

                MessageBox.Show("User successfully added!", "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                regForm.Hide();
                loginForm.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MMRR Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region importDatatoRepo

        public static void importDatatoRepo(string assignedOfficeLocation, string caseStaffRequestDate, string referenceNumber, string typeofRecord, string facility, string facilityType, string vendorSubmissionDate, string methodofRequest, string portal, string dateResubmitted, string lastTouchAgentName, string assignedAgent, string lastTouchGroup, string facilityPhoneNumber, string fax, string email, string mail, string status, string currentStages, string finalStages, string completeDate, string notes, string futureFollowUpDate, string invoicePaid, string pharmacy, string timeStampStart, string timeStampEnd, string isDone)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sendDataMaxRID", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@assignedOfficeLocation", assignedOfficeLocation);
                sqlCommand.Parameters.AddWithValue("@caseStaffRequestDate", caseStaffRequestDate);
                sqlCommand.Parameters.AddWithValue("@referenceNumber", referenceNumber);
                sqlCommand.Parameters.AddWithValue("@typeofRecord", typeofRecord);
                sqlCommand.Parameters.AddWithValue("@facility", facility);
                sqlCommand.Parameters.AddWithValue("@facilityType", facilityType);
                sqlCommand.Parameters.AddWithValue("@vendorSubmissionDate", vendorSubmissionDate);
                sqlCommand.Parameters.AddWithValue("@methodofRequest", methodofRequest);
                sqlCommand.Parameters.AddWithValue("@portal", portal);
                sqlCommand.Parameters.AddWithValue("@dateResubmitted", dateResubmitted);
                sqlCommand.Parameters.AddWithValue("@lastTouchAgentName", lastTouchAgentName);
                sqlCommand.Parameters.AddWithValue("@assignedAgent", assignedAgent);
                sqlCommand.Parameters.AddWithValue("@lastTouchGroup", lastTouchGroup);
                sqlCommand.Parameters.AddWithValue("@facilityPhoneNumber", facilityPhoneNumber);
                sqlCommand.Parameters.AddWithValue("@fax", fax);
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@mail", mail);
                sqlCommand.Parameters.AddWithValue("@status", status);
                sqlCommand.Parameters.AddWithValue("@currentStages", currentStages);
                sqlCommand.Parameters.AddWithValue("@finalStages", finalStages);
                sqlCommand.Parameters.AddWithValue("@completeDate", completeDate);
                sqlCommand.Parameters.AddWithValue("@notes", notes);
                sqlCommand.Parameters.AddWithValue("@futureFollowUpDate", futureFollowUpDate);
                sqlCommand.Parameters.AddWithValue("@invoicePaid", invoicePaid);
                sqlCommand.Parameters.AddWithValue("@pharmacy", pharmacy);
                sqlCommand.Parameters.AddWithValue("@timeStampStart", timeStampStart);
                sqlCommand.Parameters.AddWithValue("@timeStampEnd", timeStampEnd);
                sqlCommand.Parameters.AddWithValue("@isDone", isDone);
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MMRR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void importDatatoRepowithPrecID(string PrecedentedID, string assignedOfficeLocation, string caseStaffRequestDate, string referenceNumber, string typeofRecord, string facility, string facilityType, string vendorSubmissionDate, string methodofRequest, string portal, string dateResubmitted, string lastTouchAgentName, string assignedAgent, string lastTouchGroup, string facilityPhoneNumber, string fax, string email, string mail, string status, string currentStages, string finalStages, string completeDate, string notes, string futureFollowUpDate, string invoicePaid, string pharmacy, string timeStampStart, string timeStampEnd, string isDone)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("sendDataWithPredentedID", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@precedentedID", PrecedentedID);
                sqlCommand.Parameters.AddWithValue("@assignedOfficeLocation", assignedOfficeLocation);
                sqlCommand.Parameters.AddWithValue("@caseStaffRequestDate", caseStaffRequestDate);
                sqlCommand.Parameters.AddWithValue("@referenceNumber", referenceNumber);
                sqlCommand.Parameters.AddWithValue("@typeofRecord", typeofRecord);
                sqlCommand.Parameters.AddWithValue("@facility", facility);
                sqlCommand.Parameters.AddWithValue("@facilityType", facilityType);
                sqlCommand.Parameters.AddWithValue("@vendorSubmissionDate", vendorSubmissionDate);
                sqlCommand.Parameters.AddWithValue("@methodofRequest", methodofRequest);
                sqlCommand.Parameters.AddWithValue("@portal", portal);
                sqlCommand.Parameters.AddWithValue("@dateResubmitted", dateResubmitted);
                sqlCommand.Parameters.AddWithValue("@lastTouchAgentName", lastTouchAgentName);
                sqlCommand.Parameters.AddWithValue("@assignedAgent", assignedAgent);
                sqlCommand.Parameters.AddWithValue("@lastTouchGroup", lastTouchGroup);
                sqlCommand.Parameters.AddWithValue("@facilityPhoneNumber", facilityPhoneNumber);
                sqlCommand.Parameters.AddWithValue("@fax", fax);
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@mail", mail);
                sqlCommand.Parameters.AddWithValue("@status", status);
                sqlCommand.Parameters.AddWithValue("@currentStages", currentStages);
                sqlCommand.Parameters.AddWithValue("@finalStages", finalStages);
                sqlCommand.Parameters.AddWithValue("@completeDate", completeDate);
                sqlCommand.Parameters.AddWithValue("@notes", notes);
                sqlCommand.Parameters.AddWithValue("@futureFollowUpDate", futureFollowUpDate);
                sqlCommand.Parameters.AddWithValue("@invoicePaid", invoicePaid);
                sqlCommand.Parameters.AddWithValue("@pharmacy", pharmacy);
                sqlCommand.Parameters.AddWithValue("@timeStampStart", timeStampStart);
                sqlCommand.Parameters.AddWithValue("@timeStampEnd", timeStampEnd);
                sqlCommand.Parameters.AddWithValue("@isDone", isDone);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MMRR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }

    public class MyDataModel2
    {
        public static string RID { get; set; }
        public static string PrecedentedID { get; set; }
        public static string AssignedOfficeLocation { get; set; }
        public static string CaseStaffRequestDate { get; set; }
        public static string RequestedByWhom {get; set;}
        public static string ReferenceNumber { get; set; }
        public static string ClientNameLastFirst { get; set; }
        public static string ClientDateofBirth { get; set; }
        public static string TypeofRecordBillingStatementAbstractRecords { get; set; }
        public static string Facility { get; set; }
        public static string FacilityType { get; set; }
        public static string StartDate { get; set; }
        public static string EndDate { get; set; }
        public static string VendorSubmissionDate { get; set; }
        public static string MethodofRequest { get; set; }
        public static string Portal { get; set; }
        public static string DateResubmitted { get; set; }
        public static string LastTouchAgentName { get; set; }
        public static string AssignedAgent { get; set; }
        public static string LastTouchGroup { get; set; }
        public static string FacilityPhoneNumber { get; set; }
        public static string Fax { get; set; }
        public static string Email { get; set; }
        public static string Mail { get; set; }
        public static string Status { get; set; }
        public static string CurrentStages { get; set; }
        public static string CurrentStagesFinalStages { get; set; }
        public static string CompleteDate { get; set; }
        public static string Notes { get; set; }
        public static string FutureFollowUpDate { get; set; }
        public static string InvoicePaid { get; set; }
        public static string Pharmacy { get; set; }
        public static string ParentOfficeAutomatedFromLitify { get; set; }
        public static string TimeStampStart { get; set; }
        public static string TimeStampEnd { get; set; }
        public static string isDone { get; set; }
    }

    public class MyDataModelForImporting
    {
        public static string PrecedentedID { get; set; }
        public static string AssignedOfficeLocation { get; set; }
        public static string CaseStaffRequestDate { get; set; }
        public static string ReferenceNumber { get; set; }
        public static string TypeofRecordBillingStatementAbstractRecords { get; set; }
        public static string Facility { get; set; }
        public static string FacilityType { get; set; }
        public static string VendorSubmissionDate { get; set; }
        public static string MethodofRequest { get; set; }
        public static string Portal { get; set; }
        public static string DateResubmitted { get; set; }
        public static string LastTouchAgentName { get; set; }
        public static string AssignedAgent { get; set; }
        public static string LastTouchGroup { get; set; }
        public static string FacilityPhoneNumber { get; set; }
        public static string Fax { get; set; }
        public static string Email { get; set; }
        public static string Mail { get; set; }
        public static string Status { get; set; }
        public static string CurrentStages { get; set; }
        public static string CurrentStagesFinalStages { get; set; }
        public static string CompleteDate { get; set; }
        public static string Notes { get; set; }
        public static string FutureFollowUpDate { get; set; }
        public static string InvoicePaid { get; set; }
        public static string Pharmacy { get; set; }
        public static string TimeStampStart { get; set; }
        public static string TimeStampEnd { get; set; }
        public static string isDone { get; set; }
    }
}
