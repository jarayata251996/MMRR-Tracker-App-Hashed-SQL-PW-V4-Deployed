using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace MMRR_Tracker
{
    class labelReturnedDisplay
    {
        public int GetRowCount(string connectionString, string user, string group, string isdone)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                if (isdone == "NO")
                {
                    command = new SqlCommand("getNoCount", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@assignedUser", user);
                    command.Parameters.AddWithValue("@status", group);
                    command.Parameters.AddWithValue("@isDone", isdone);
                }
                else
                {
                    command = new SqlCommand("getYesCount", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@assignedUser", user);
                }

               
                connection.Open();
                int count = (int)command.ExecuteScalar();
                connection.Close();
                return count;
            }
        }

        public int getEscaNotifCount(string connectionString, string user, string currentStage)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                    command = new SqlCommand("getEscaNotifCount", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@assignedUser", user);
                    command.Parameters.AddWithValue("@currentStage", currentStage);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    connection.Close();
                    return count;
            }
        }




    }
}
