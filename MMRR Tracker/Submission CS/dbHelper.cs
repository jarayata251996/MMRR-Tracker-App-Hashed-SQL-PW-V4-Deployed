using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MMRR_Tracker
{
    class dbHelper
    {

        public static void InsertLogsRecord(string connectionString, string phase, string user, string remarks)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
			{
				
				connection.Open();

                string query = "INSERT INTO [dbo].[MMRR_Logs] ([Phase], [User], [Remarks], [DateAndTime]) " +
                               "VALUES (@Phase, @User, @Remarks, @DateTime)";

                SqlCommand command = new SqlCommand(query, connection);
				command.CommandTimeout = 120; // timeout
				command.Parameters.AddWithValue("@Phase", phase);
                command.Parameters.AddWithValue("@User", user);
                command.Parameters.AddWithValue("@Remarks", remarks);
                command.Parameters.AddWithValue("@DateTime", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }

        public static List<string> autoCompleteItemsRoster(string connectionString, string columnnames, int columnindex)
        {
            List<string> list = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getAutocompleteItemsRosterTable", connection);
					command.CommandTimeout = 120; // timeout
					command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ColumnName", columnnames);

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string hldr = dataReader.GetValue(columnindex).ToString();
                        list.Add(hldr);
                    }
                    dataReader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
            
                throw ex;
            }
      
            return list;
        }


        public static List<string> autoCompleteItems(string connectionString, string columnnames, int columnindex)
        {
            List<string> list = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getAutocompleteItemsDecryptedView", connection);
					command.CommandTimeout = 120; // timeout
					command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ColumnName", columnnames);

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string hldr = dataReader.GetValue(columnindex).ToString();
                        list.Add(hldr);
                    }
                    dataReader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return list;
        }

        public static void UpdateRIDValue(string connectionString,string RID, string PrecedentedID, string AssignedOfficeLocation,
        string CaseStaffRequestDate, string ReferenceNumber, string TypeOfRecord, string Facility, string FacilityType,
        string VendorSubmissionDate, string MethodOfRequest, string Portal, string DateResubmitted,
        string LastTouchAgentName, string AssignedUser, string LastTouchGroup, string FacilityPhoneNumber, string Fax, string Email, string Mail,
        string Status, string CurrentStages, string CurrentStagesFinal, string CompleteDate, string Notes,
        string FutureFollowUpDate, string InvoicePaid, string Pharmacy,string isDone)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateRIDValue", connection);
				command.CommandTimeout = 120; // timeout
				command.CommandType = CommandType.StoredProcedure;

                // Set the parameter values
                command.Parameters.AddWithValue("@RID", RID);
                command.Parameters.AddWithValue("@PrecedentedID", PrecedentedID);
                command.Parameters.AddWithValue("@AssignedOfficeLocation", AssignedOfficeLocation);
                command.Parameters.AddWithValue("@CaseStaffRequestDate", CaseStaffRequestDate);
                command.Parameters.AddWithValue("@ReferenceNumber", ReferenceNumber);
                command.Parameters.AddWithValue("@TypeOfRecord", TypeOfRecord);
                command.Parameters.AddWithValue("@Facility", Facility);
                command.Parameters.AddWithValue("@FacilityType", FacilityType);
                command.Parameters.AddWithValue("@VendorSubmissionDate", VendorSubmissionDate);
                command.Parameters.AddWithValue("@MethodOfRequest", MethodOfRequest);
                command.Parameters.AddWithValue("@Portal", Portal);
                command.Parameters.AddWithValue("@DateResubmitted", DateResubmitted);
                command.Parameters.AddWithValue("@LastTouchAgentName", LastTouchAgentName);
                command.Parameters.AddWithValue("@AssignedUser", AssignedUser);
                command.Parameters.AddWithValue("@LastTouchGroup", LastTouchGroup);
                command.Parameters.AddWithValue("@FacilityPhoneNumber", FacilityPhoneNumber);
                command.Parameters.AddWithValue("@Fax", Fax);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Mail", Mail);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@CurrentStages", CurrentStages);
                command.Parameters.AddWithValue("@CurrentStagesFinal", CurrentStagesFinal);
                command.Parameters.AddWithValue("@CompleteDate", CompleteDate);
                command.Parameters.AddWithValue("@Notes", Notes);
                command.Parameters.AddWithValue("@FutureFollowUpDate", FutureFollowUpDate);
                command.Parameters.AddWithValue("@InvoicePaid", InvoicePaid);
                command.Parameters.AddWithValue("@Pharmacy", Pharmacy);
                command.Parameters.AddWithValue("@isDone", isDone);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


        public static DataTable getDataTable(string connectionString, string columnName, string searchValue, string requestDate, int isRequestDate, bool isExact, string stage)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                if (isExact == true)
                {

                    command = new SqlCommand("select_data_by_column_Exact", connection);
					command.CommandTimeout = 120; // timeout
					command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@column_name", columnName);
                    command.Parameters.AddWithValue("@search_value", searchValue);
                    command.Parameters.AddWithValue("@requestDateValue", requestDate);
                    command.Parameters.AddWithValue("@isRequestDate", isRequestDate);
                    command.Parameters.AddWithValue("@stage", stage);
                }
                else
                {
                    command = new SqlCommand("select_data_by_column", connection);
					command.CommandTimeout = 120; // timeout
					command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@column_name", columnName);
                    command.Parameters.AddWithValue("@search_value", "%" + searchValue + "%");
                    command.Parameters.AddWithValue("@requestDateValue", requestDate);
                    command.Parameters.AddWithValue("@isRequestDate", isRequestDate);
                    command.Parameters.AddWithValue("@stage", stage);
                }
               
             

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();
                adapter.Fill(dataTable);
                connection.Close();

                return dataTable;
            }
        }

        public static string getAssignedUser(string connectionString, string RID)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
              
                command = new SqlCommand("checkAssignedAgent", connection);
				command.CommandTimeout = 120; // timeout
				command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RID", RID);

                connection.Open();
                string name = (string)command.ExecuteScalar();
                connection.Close();
                return name;
            }
        }

        public static string updateAssignedUser(string connectionString, string RID, string updatedUser)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();

                command = new SqlCommand("UpdateAssignedUser", connection);
				command.CommandTimeout = 120; // timeout
				command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RID", RID);
                command.Parameters.AddWithValue("@AssignedUser", updatedUser);

                connection.Open();
                string name = (string)command.ExecuteScalar();
                connection.Close();
                return name;
            }
        }
		public static List<string> getDim(string connectionString, string spName)
		{
			List<string> facilityTypes = new List<string>();

			try
			{
				using (SqlConnection connection = new SqlConnection(connectionString))
				{
					using (SqlCommand command = new SqlCommand(spName, connection))
					{
						command.CommandTimeout = 120; // timeout
						command.CommandType = CommandType.StoredProcedure;
						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							while (reader.Read())
							{
								if (spName == "sp_GetFacilityTypes")
								{
									string type = reader.GetString(reader.GetOrdinal("Facility Type"));
									facilityTypes.Add(type);
								}
								else
								{
									string type = reader.GetString(reader.GetOrdinal("Portal"));
									facilityTypes.Add(type);
								}
								
							}
						}

						connection.Close();
					}
				}
			}
			catch { }

			return facilityTypes;
		}

	}
}
