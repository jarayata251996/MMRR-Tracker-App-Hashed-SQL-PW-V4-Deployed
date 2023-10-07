using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MMRR_Tracker
{
    class updatingSqlSelecting
    {
        public static void UpdateRecord(string connectionString, string getRID)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateRecord", connection);
				command.CommandTimeout = 120; // timeout
				command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@getRID", getRID);
                command.Parameters.AddWithValue("@isDone", "YES");
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                
            }


        }
    }
}
