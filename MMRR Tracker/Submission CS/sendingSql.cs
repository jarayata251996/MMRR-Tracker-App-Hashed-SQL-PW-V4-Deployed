using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MMRR_Tracker
{
    class sendingSql
    {


        public static void sendData(string connectionString,
             string precedentedID,
             string assignedOfficeLocation,
             string caseStaffRequestDate,
             string referenceNumber,
             string typeofRecord,
             string facility,
             string facilityType,
             string vendorSubmissionDate,
             string methodofRequest,
             string portal,
             string dateResubmitted,
             string lastTouchAgentName,
             string assignedAgent,
             string lastTouchGroup,
             string facilityPhoneNumber,
             string fax,
             string email,
             string mail,
             string status,
             string currentStages,
             string finalStages,
             string completeDate,
             string notes,
             string futureFollowUpDate,
             string invoicePaid,
             string pharmacy,
             string timeStampStart,
             string timeStampEnd,
             string isDone

            )
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
               
                SqlCommand command = new SqlCommand("sendData", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;           
                command.Parameters.AddWithValue("@precedentedID", precedentedID);
                command.Parameters.AddWithValue("@assignedOfficeLocation", assignedOfficeLocation);
                command.Parameters.AddWithValue("@caseStaffRequestDate", caseStaffRequestDate);
                command.Parameters.AddWithValue("@referenceNumber", referenceNumber);
                command.Parameters.AddWithValue("@typeofRecord", typeofRecord);
                command.Parameters.AddWithValue("@facility", facility);
                command.Parameters.AddWithValue("@facilityType", facilityType);
                command.Parameters.AddWithValue("@vendorSubmissionDate", vendorSubmissionDate);
                command.Parameters.AddWithValue("@methodofRequest", methodofRequest);
                command.Parameters.AddWithValue("@portal", portal);
                command.Parameters.AddWithValue("@dateResubmitted", dateResubmitted);
                command.Parameters.AddWithValue("@lastTouchAgentName", lastTouchAgentName);
                command.Parameters.AddWithValue("@assignedAgent", assignedAgent);
                command.Parameters.AddWithValue("@lastTouchGroup", lastTouchGroup);
                command.Parameters.AddWithValue("@facilityPhoneNumber", facilityPhoneNumber);
                command.Parameters.AddWithValue("@fax", fax);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@mail", mail);
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@currentStages", currentStages);
                command.Parameters.AddWithValue("@finalStages", finalStages);
                command.Parameters.AddWithValue("@completeDate", completeDate);
                command.Parameters.AddWithValue("@notes", notes);
                command.Parameters.AddWithValue("@futureFollowUpDate", futureFollowUpDate);
                command.Parameters.AddWithValue("@invoicePaid", invoicePaid);
                command.Parameters.AddWithValue("@pharmacy", pharmacy);
                command.Parameters.AddWithValue("@timeStampStart", timeStampStart);
                command.Parameters.AddWithValue("@timeStampEnd", timeStampEnd);
                command.Parameters.AddWithValue("@isDone", isDone);

                command.ExecuteNonQuery();
                connection.Close();


            }

          

        }
    }
}
