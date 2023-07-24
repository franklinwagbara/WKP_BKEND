using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend_UMR_Work_Program
{
    public class nes_project_classes
    {

        public string id { get; set; }
        public string companyname { get; set; }
        public string companyemail { get; set; }
        public string meetingroom { get; set; }
        public string chairperson { get; set; }
        public string scribe { get; set; }
        public string status { get; set; }
        public string presented { get; set; }
        public string datetimepresentation { get; set; }
        public string year { get; set; }

        public string Submitted { get; set; }
      
        




        //public string id { get; set; }
        public string Admission_no { get; set; }
        public string Stud_firstname { get; set; }
        public string Stud_middlename { get; set; }
        public string Stud_lastname { get; set; }
        public string Stud_class { get; set; }
        public string Stud_gender { get; set; }
        public string Stud_Religion { get; set; }
        public string Stud_state { get; set; }
        public string Stud_nationality { get; set; }
        public string Stud_Address { get; set; }
        public string Title { get; set; }
        public string parent_firstname { get; set; }
        public string parent_middlename { get; set; }
        public string parent_lastname { get; set; }
        public string parent_Address { get; set; }
        public string parent_email { get; set; }
        public string parent_Phone_no { get; set; }
        public string Created_by { get; set; }
        public string Updated_by { get; set; }
        public string Date_Created { get; set; }
        public string Date_Updated { get; set; }
        public string DOB { get; set; }
        public string Stud_Picture { get; set; }




        public int SN_Type_of_SS { get; set; }
        public string Type_of_Stakeholder_SS { get; set; }
        public string Type_of_Services_SS { get; set; }


        public int SN_Type_of_service { get; set; }
        public string Type_of_service { get; set; }

        public int SN_Type_of_status { get; set; }
        public string Type_of_status  { get; set; }

        public int SN_Type_of_FREQUENCY { get; set; }
        public string Type_of_FREQUENCY { get; set; }

        public int SN_Type_of_TERMINALEQUIPMENT { get; set; }
        public string Type_of_TERMINALEQUIPMENT { get; set; }

        public int SN_Type_of_Segments { get; set; }
        public string Type_of_Segments { get; set; }

        public int SN_Type_of_Vendors { get; set; }
        public string Type_of_Vendors { get; set; }

         public int SN_Type_of_PROJECT { get; set; }
        public string Type_of_PROJECT { get; set; }

         public int SN_Type_of_WIP_STAGES { get; set; }
        public string Type_of_WIP_STAGES { get; set; }

         public int SN_Type_of_STAKEHOLDERS { get; set; }
        public string Type_of_STAKEHOLDERS { get; set; }

         public int SN_Type_of_MEDIUM { get; set; }
        public string Type_of_MEDIUM { get; set; }

         public int SN_Type_of_TERMINATION { get; set; }
        public string Type_of_TERMINATION { get; set; }

        public int SN_Type_of_REGION { get; set; }
        public string Type_of_REGION{ get; set; }
        public string Type_of_SUBREGION { get; set; }

        
        public int SN_Type_NES_PROJECT_TEAM { get; set; }
        public string Type_of_NES_PROJECT_TEAM{ get; set; }

        public int SN_Type_NES_ADMIN_TEAM { get; set; }
        public string Type_of_NES_ADMIN_TEAM { get; set; }

        public int SN_Type_of_NES_SOLUTION_TEAM { get; set; }
        public string Type_of_NES_SOLUTION_TEAM { get; set; }



        public int SN { get; set; }
        public string coordinator_username { get; set; }
        public string coordinator_email { get; set; }
        public string coordinator_name { get; set; }
        public string current_status { get; set; }
        public string project_id { get; set; }
        public string managers_comment { get; set; }
        public string uploded_email { get; set; }

        public string PROJECT_DESIGN_MANAGER { get; set; }
         public string SOLUTIONS_ENGINEER { get; set; }
         public string SERVICE_DESCRIPTION { get; set; }
         public string Design_Report { get; set; } // Report uploded by Design engineer


         public int design_SN { get; set; }
         public string design_status { get; set; }
         public string design_project_id { get; set; }
         public string design_Start_time { get; set; }
         public string design_end_time { get; set; }
         public string design_duration { get; set; }
         public string design_total_duration { get; set; }
         public string design_stakeholder { get; set; }
         public string design_services { get; set; }

         public string design_COMMENTS { get; set; }
         public string design_createdby { get; set; }

        public double Values { get; set; }
        public string Date { get; set; }




        public int Project_SN { get; set; }
        public string Project_PROJECT_ID { get; set; }
        public string Project_CURRENT_STATUS { get; set; }
        public string Project_SERVICE_DESCRIPTION { get; set; }
        public string Project_CUSTOMER { get; set; }
        public string Project_TYPE_OF_SERVICE { get; set; }
        public string Project_TYPE_OF_PROJECT { get; set; }
        public string Project_JOB_ORDER_ID { get; set; }
        public string Project_COORDINATOR_NAME { get; set; }
        public string Project_COORDINATOR_EMAIL { get; set; }
        public string Project_STATUS { get; set; }
        public string Project_WIP_STAGES { get; set; }
        public string Project_PRESENT_UPDATE { get; set; }
        public string Project_MANAGERS_COMMENT { get; set; }
        public string Project_UPLOADED_EMAIL { get; set; }
        public string Project_T_NUMBER { get; set; }
        public string Project_X_NUMBER { get; set; }
        public string Project_TX_MEDIUM { get; set; }
        public string Project_FREQUENCY { get; set; }
        public string Project_TERMINATION_TYPE { get; set; }
        public string Project_TERMINAL_EQUIPMENT { get; set; }
        public string Project_EMRF { get; set; }
        public string Project_PLANNED_WORK_REF { get; set; }
        public string Project_NRR { get; set; }
        public string Project_MRR { get; set; }
        public string Project_NRR_MRR { get; set; }
        public string Project_REGION { get; set; }
        public string Project_STATE { get; set; }
        public string Project_SERVICE_LOCATION_ADDRESS { get; set; }
        public string Project_SEGMENTS { get; set; }
        public string Project_VENDOR { get; set; }
        public string Project_ACCOUNT_PARTNER { get; set; }
        public string Project_SOLUTIONS_ENGINEER { get; set; }
        public string Project_PROJECT_CORDINATOR { get; set; }
        public string Project_COORDINATOR_USERNAME { get; set; }
        public string Project_PROJECT_SOLUTION_MANAGER { get; set; }
        public string Project_PROJECT_DESIGN_MANAGER { get; set; }
        public string Project_PROJECT_FLAG { get; set; }
        public string Project_SOLUTION_DESIGN_FLAG { get; set; }
        public string Project_DESIGN_ENGINEER_COMMENT { get; set; }
        public string Project_DESIGN_REPORT { get; set; }
        public string Project_DESIGN_FLAG { get; set; }
        public string Project_PROJECT_LEAD_FLAG { get; set; }
        public string Project_JOB_COMPLETION_UPLOAD { get; set; }

        
        public string Project_start_date { get; set; }
        public string Design_Due_date { get; set; }
        public string Project_due_date { get; set; }
        public string Design_completed_date { get; set; }
        public string Project_completed_date { get; set; }
        public string Customer_sign_off_date { get; set; }
		
	


        public string Project_order_id { get; set; }

        public string Project_DESIGN_ON_OFF { get; set; }

        public string count_no { get; set; }

        public string stakeholder_email { get; set; }

        public string sub_roles { get; set; }


    }
}