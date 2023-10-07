using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRR_Tracker
{
    class submissionFormArrays
    {
        public string[] intakeItems = new string[]
        {
            "Default",
            "INBOUND CALL",
            "Escalated - Invoice (New)",
            "Escalated - No roles (New)",
            "Escalated - No Signed HIPAA (New)",
            "Escalated - General Escalation (New)",
            "Escalated - Digital Signature not accepted (New)",
            "Escalated - Client Priority (New)"
        };

        public string[] pendingItems = new string[]
        {
            "Default",
            "INBOUND CALL",
            "Escalated - Invoice (Pending)",
            "Escalated - No roles (Pending)",
            "Escalated - No Signed HIPAA (Pending)",
            "Escalated - General Escalation (Pending)",
            "Escalated - Digital Signature not accepted (Pending)",
            "Escalated - Client Priority (Pending)"
        };


        public string[] moreItems = new string[]
        {
            "Default",
            "CORRESPONDENCE",
            "Escalated - Invoice",
            "Escalated - No roles",
            "Escalated - No Signed HIPAA",
            "Escalated - General Escalation",
            "Escalated - Digital Signature not accepted",
            "Escalated - Client Priority",
            "Escalated - Client Priority (Completion)"
        };

        public string[] recordType = new string[]
        {
            "Default",
            "Abstract",
            "Bills",
            "Records"

        };

        public string[] isDone = new string[]
        {
            "NO",
            "YES"

        };

        public string[] portal = new string[]
        {
            "N/A",
            "American Retrievals Court",
            "BISCOM TRANSIT",
            "CHANGE HEALTHCARE",
            "Chart Request",
            "Chartpro",
            "Chartswap",
            "Docufree",
            "ENGUARD",
            "Invoices",
            "KAISER PERMANENTE",
            "MIGHTY",
            "Mimecast",
            "MRO",
            "NRR",
            "PATIENT FIRST",
            "Providerflow Support",
            "ReleasePoint completed",
            "ReleasePoint suspended",
            "ReleasePoint",
            "RRS",
            "SECURESHARE PROOFPOINT",
            "Smart Request",
            "UPSTREAM REHABILITATION",
            "XeBee",
            "ZIX Message Center User",
			"Complete Care",
			"Compex Legal",
			"CASEworks",
			"MRC"

		};

        public string[] facilityType = new string[]
        {
            "N/A",
            "Assisted Living Facility",
            "Chiropractic Office",
            "EMS",
            "ER Physician Billing Agent",
            "Freestanding ER",
            "Home Health Agency",
            "Hospital",
            "Hospital Billing Agent",
            "Imaging/Radiology Center",
            "Laboratory Facility",
            "Nursing Home",
            "Orthopedic Office",
            "Outpatient Clinic",
            "Outpatient Surgical Center",
            "Pain Management Office",
            "Pharmacy",
            "Physical Therapy Provider",
            "Radiology Billing Agent",
            "Rehabilitation Facility",
            "Urgent Care"
          


        };

        public string[] invoicePaid = new string[]
        {
            "N/A",
            "NO",
            "YES"

        };

        public string[] pharmacy = new string[]
      {

          "N/A",
            "NO",
            "YES"

      };

        public string[] finalOutputIntake = new string[]
       {
            "Pending - In-Progress",
            "Pending For Completion",
            "Completed - Patient Not Found",
            "Completed - Cancelled Request",
            "Completed - Duplicate Request",
            "Completed - Records Received",
            "Escalated - Invoice",
            "Escalated - No Roles",
            "Escalated - No Signed HIPAA",
            "Escalated - General Escalation",
            "Escalated - Digital Signature not accepted"

       };

        public string[] finalOutputPending = new string[]
        {
            "Pending - In-Progress",
            "Pending For Completion",
            "Completed - Patient Not Found",
            "Completed - Cancelled Request",
            "Completed - Duplicate Request",
            "Completed - Records Received",
            "Escalated - Invoice",
            "Escalated - No Roles",
            "Escalated - No Signed HIPAA",
            "Escalated - General Escalation",
            "Escalated - Digital Signature not accepted"

        };

        public string[] finalOutputCompleted = new string[]
        {
            "Pending - In-Progress",
            "Pending For Completion",
            "Escalated - Client Priority (Completion)",
            "Escalated - Invoice (New)",
            "Escalated - No roles (New)",
            "Escalated - No Signed HIPAA (New)",
            "Escalated - General Escalation (New)",
            "Escalated - Digital Signature not accepted (New)",
            "Escalated - Client Priority (New)",
            "Escalated - Invoice (Pending)",
            "Escalated - No roles (Pending)",
            "Escalated - No Signed HIPAA (Pending)",
            "Escalated - General Escalation (Pending)",
            "Escalated - Digital Signature not accepted (Pending)",
            "Escalated - Client Priority (Pending)",
            "Completed - Records Received",
            "Completed - Patient Not Found",
            "Completed - Cancelled Request",
            "Completed - Duplicate Request",
            "Escalated - Invoice",
            "Escalated - No roles",
            "Escalated - No Signed HIPAA",
            "Escalated - General Escalation",
            "Escalated - Digital Signature not accepted"


        };


        public string[] grabList = new string[]
        {
            "New - Untouched",
            "Pending - In-Progress",
            "Pending For Completion",
            "Escalated - Client Priority (Completion)",
            "Escalated - Invoice (New)",
            "Escalated - No roles (New)",
            "Escalated - No Signed HIPAA (New)",
            "Escalated - General Escalation (New)",
            "Escalated - Digital Signature not accepted (New)",
            "Escalated - Client Priority (New)",
            "Escalated - Invoice (Pending)",
            "Escalated - No roles (Pending)",
            "Escalated - No Signed HIPAA (Pending)",
            "Escalated - General Escalation (Pending)",
            "Escalated - Digital Signature not accepted (Pending)",
            "Escalated - Client Priority (Pending)",
            "Completed - Records Received",
            "Completed - Patient Not Found",
            "Completed - Cancelled Request",
            "Completed - Duplicate Request",
            "Escalated - Invoice",
            "Escalated - No roles",
            "Escalated - No Signed HIPAA",
            "Escalated - General Escalation",
            "Escalated - Digital Signature not accepted"

        };

        public string[] methodofRequest = new string[]
        {
           "N/A",
           "Fax",
           "Email",
           "Mail",
           "Portal"

        };

        public string[] searchList = new string[]
       {
            "RID",
            "Precedented ID",
            "Assigned Office Location",
            "Case Staff Request Date",
            "Reference Number",
            "Type of Record (Billing Statement, Abstract, Records)",
            "Facility",
            "Facility Type",
            "Vendor Submission Date",
            "Method of Request",
            "Portal",
            "Date Resubmitted",
            "Last Touch Agent Name",
            "Assigned Agent",
            "Last Touch Group",
            "Facility Phone Number",
            "Fax",
            "Email",
            "Mail",
            "Status",
            "Current Stages",
            "Complete Date",
            "Notes",
            "Future Follow Up Date",
            "Invoice Paid",
            "Pharmacy"
       };

        public string[] stages = new string[]
        {
                "ALL",
                "Intake",
                "Pending",
                "Completion",
                "Escalation"

        };


    }
}
