using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Data.OracleClient;
using System.Data;

namespace Backend_UMR_Work_Program
{

    public class mails
    {


        private string SEVERITY, ASSIGNED_TO, REPORTTITLE, RESOLUTIONSTATUS, DATE_ASSIGNED, SN, SEVERITY_DURATION, SEVERITY_DURATION_BUFFER , email_result;

        private int days_left;


        public mails()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        private string usernamecandidate;
        public string Usernamecandidate
        {
            get { return usernamecandidate; }
            set { usernamecandidate = value; }
        }

        private string passwordcan;
        public string Passwordcan
        {
            get { return passwordcan; }
            set { passwordcan = value; }
        }

        private string Name;

        public string myName
        {
            get { return Name; }
            set { Name = value; }
        }

        private string Phoneno;

        public string MyPhoneno
        {
            get { return Phoneno; }
            set { Phoneno = value; }
        }

        private string MSIDN;

        public string MyMSIDN
        {
            get { return MSIDN; }
            set { MSIDN = value; }
        }

        private string myRole;

        public string MyRole
        {
            get { return myRole; }
            set { myRole = value; }
        }

        private string LM;
        public string Linemanager
        {
            get { return LM; }
            set { LM = value; }
        }

        System.Net.Mail.SmtpClient SmtpMail = new System.Net.Mail.SmtpClient();



        MailMessage message = new MailMessage();
        bool myStatus;

        private string myFromAddress = "no-reply@nuprc.gov.ng";
        public string FromAddress
        {
            get { return myFromAddress; }
            set { myFromAddress = value; }
        }

        private string mySubject;
        public string Subject
        {
            get { return mySubject; }
            set { mySubject = value; }
        }

        private string myMailBody;
        public string MailBody
        {
            get { return myMailBody; }
            set { myMailBody = value; }
        }


        //private string myToRecieved = "anthonnwo@mtnnigeria.net";
        //public string ToRecieved
        //{
        //    get { return myToRecieved; }
        //    set { myToRecieved = value; }
        //}

        private string myToRecieved;
        public string ToRecieved
        {
            get { return myToRecieved; }
            set { myToRecieved = value; }
        }

        private string myToRecievedCC; //= "yewanda@mtnnigeria.net";
        public string ToRecievedCC
        {
            get { return myToRecievedCC; }
            set { myToRecievedCC = value; }
        }

        private string myToRecievedBCC; //= "yewanda@mtnnigeria.net";
        public string ToRecievedBCC
        {
            get { return myToRecievedBCC; }
            set { myToRecievedBCC = value; }
        }

        private string myErrMsg;
        public string ErrMsg
        {
            get { return myErrMsg; }
            set { myErrMsg = value; }
        }

        private string MyJobtitle;
        public string Jobtitle
        {
            get { return MyJobtitle; }
            set { MyJobtitle = value; }

        }

        private string Email;
        public string Email_
        {
            get { return Email; }
            set { Email = value; }

        }

        private string Password;
        public string Password_
        {
            get { return Password; }
            set { Password = value; }

        }

        private string myusername;
        public string Myusername
        {
            get { return myusername; }
            set { myusername = value; }
        }

        private string location_reion_siteid;
        public string Location_reion_siteid
        {
            get { return location_reion_siteid; }
            set { location_reion_siteid = value; }
        }

        private string site_name;
        public string Site_name
        {
            get { return site_name; }
            set { site_name = value; }
        }
        private string approval_status;
        public string Approval_status
        {
            get { return approval_status; }
            set { approval_status = value; }
        }


        private string myfriendname;
        public string Friendname
        {
            get { return myfriendname; }
            set { myfriendname = value; }
        }

        private string myFirstname;
        public string Firstname
        {
            get { return myFirstname; }
            set { myFirstname = value; }
        }
        private string authorizedbyuname;
        public string Authorizedbyuname
        {
            get { return authorizedbyuname; }
            set { authorizedbyuname = value; }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private string purpose;
        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }

        private string details;
        public string Details // List of report measured....
        {
            get { return details; }
            set { details = value; }
        }

        private string myRef;

        public string MyRef
        {
            get { return myRef; }
            set { myRef = value; }
        }

        private string reportowneruname;

        public string Reportowneruname
        {
            get { return reportowneruname; }
            set { reportowneruname = value; }
        }

        //public string BuildMailAddress(string uname)
        //{
        //    //return uname + "@mtnnigeria.net";
        //    return uname;

        //}
        private string report_title;

        public string Report_Title
        {
            get { return report_title; }
            set { report_title = value; }
        }

        private string resolution_status;

        public string Resolution_Status
        {
            get { return resolution_status; }
            set { resolution_status = value; }
        }

        private string resolution_details;

        public string Resolution_Details
        {
            get { return resolution_details; }
            set { resolution_details = value; }
        }

        private string report_path;

        public string Report_Path
        {
            get { return report_path; }
            set { report_path = value; }
        }

        private string report_recipients;

        public string Report_Recipients
        {
            get { return report_recipients; }
            set { report_recipients = value; }
        }

        private string resolved_by;

        public string Resolved_By
        {
            get { return resolved_by; }
            set { resolved_by = value; }
        }

        private string switch_name;

        public string Switch_name
        {
            get { return switch_name; }
            set { switch_name = value; }
        }

        private string rack_name;

        public string Rack_name
        {
            get { return rack_name; }
            set { rack_name = value; }
        }

        private string no_of_U;

        public string No_of_U
        {
            get { return no_of_U; }
            set { no_of_U = value; }
        }

        private string room_name;

        public string Room_name
        {
            get { return room_name; }
            set { room_name = value; }
        }

        private string rack_size;

        public string Rack_size
        {
            get { return rack_size; }
            set { rack_size = value; }
        }

        private string urlcomment;

        public string URLComment
        {
            get { return urlcomment; }
            set { urlcomment = value; }
        }

        private string applink;

        public string Applink
        {
            get { return applink; }
            set { applink = value; }
        }

        private string notification_header;

        public string Notification_header
        {
            get { return notification_header; }
            set { notification_header = value; }
        }

        private string tx_email_subject;

        public string Tx_email_subject
        {
            get { return tx_email_subject; }
            set { tx_email_subject = value; }
        }

        private string project_lead_name;

        public string Project_lead_name
        {
            get { return project_lead_name; }
            set { project_lead_name = value; }
        }

        private string project_mnanagers_comment;

        public string Project_mnanagers_comment
        {
            get { return project_mnanagers_comment; }
            set { project_mnanagers_comment = value; }
        }

        private string nes_subject;

        public string NES_subject
        {
            get { return nes_subject; }
            set { nes_subject = value; }
        }

        private string nes_body;

        public string NES_body
        {
            get { return nes_body; }
            set { nes_body = value; }
        }

        private string nes_header;

        public string NES_header
        {
            get { return nes_header; }
            set { nes_header = value; }
        }

        private string nes_project_id;

        public string NES_project_id
        {
            get { return nes_project_id; }
            set { nes_project_id = value; }
        }

        private string nes_rework;
        public string NES_rework
        {
            get { return nes_rework; }
            set { nes_rework = value; }
        }

        private string email_test;
        public string Email_test
        {
            get { return email_test; }
            set { email_test = value; }
        }

        private string concession_held;
        public string Concession_held
        {
            get { return concession_held; }
            set { concession_held = value; }
        }

        private string email_Step_5;
        public string Email_Step_5
        {
            get { return email_Step_5; }
            set { email_Step_5 = value; }
        }

        private string company_rep_name;
        public string Company_rep_name
        {
            get { return company_rep_name; }
            set { company_rep_name = value; }
        }

        private System.Net.Mail.Attachment attachment;
        public System.Net.Mail.Attachment Attachment
        {
            get { return attachment; }
            set { attachment = value; }
        }
        // System.Net.Mail.Attachment attachment;

        private string companyname;
        public string CompanyNAme
        {
            get { return companyname; }
            set { companyname = value; }
        }

        private string chairperson;
        public string Chairperson
        {
            get { return chairperson; }
            set { chairperson = value; }
        }

        private string scribe;
        public string Scribe
        {
            get { return scribe; }
            set { scribe = value; }
        }

        private string presentation_date;
        public string Presentation_date
        {
            get { return presentation_date; }
            set { presentation_date = value; }
        }

        private string presentation_time;
        public string Presentation_time
        {
            get { return presentation_time; }
            set { presentation_time = value; }
        }

        private string days_to_go;
        public string Days_to_go
        {
            get { return days_to_go; }
            set { days_to_go = value; }
        }

        private string official_name;
        public string Official_name
        {
            get { return official_name; }
            set { official_name = value; }
        }

        private string company_operator_name;
        public string Company_operator_name
        {
            get { return company_operator_name; }
            set { company_operator_name = value; }
        }

        private string companycode;
        public string companycode_
        {
            get { return companycode; }
            set { companycode = value; }
        }
        private string uniqueid;
        public string uniqueid_
        {
            get { return uniqueid; }
            set { uniqueid = value; }
        }

        private string meeting_room;
        public string Meeting_room
        {
            get { return meeting_room; }
            set { meeting_room = value; }
        }

        private string my_email_result;
        public string My_email_result
        {
            get { return my_email_result; }
            set { my_email_result = value; }
        }

        public void NES_SendMail_Project_Team_stakeholder_initiate()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);


            //if (fuAttachment.HasFile)
            //{
            //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
            //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
            //}


            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;
            message.Attachments.Add(attachment);
           

            ///// build the body of the mail and subject
            message.CC.Add(ToRecievedCC);
           // message.Attachments.Add(

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = nes_subject; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Dear " + project_lead_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                 //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"

                   + "<p>" + "  " + nes_body + "</p>"

                   + "<p>" + " " + nes_project_id + "</p>"

                   + "<p>" + " " + project_mnanagers_comment + "</p>"

                   + "<p>" + " " + nes_rework + "</p>"


                   //+ "<p>" + " . " + Rack_name + "</p>"


                   //+ "<p>" + " . " + Rack_size + "</p>"


                   //+ "<p>" + " . " + No_of_U + "</p>"

                   //  + "<p>" + " . " + approval_status + "</p>"


                   //   + "<p>" + " " + URLComment + "</p>"

                      + Applink + "<p>" + " Kindly contact NES Team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                  //+ "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to login and view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br>" + " " + "<br>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

                string myMsgErr = ex.Message;
            }
            finally
            {
                // con.Close();
            }


        }

        public void NES_SendMail_Project_Team()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            message.CC.Add(ToRecievedCC);
  
            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = nes_subject; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy"; + "<br>" +
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workprogam Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

             
                  + "<p>" + "</p>"  //  This will give a paragraph

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Dear " + official_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                   //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                   //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"   Company_operator_name

                   + "<p>" + "  " + nes_body + "</p>"

                   + "<p>" + "<b>" + " Company Name : " + "</b> " + company_operator_name + "</p>"

                   + "<p>" + "<b>" + " Chairman : " + "</b> " + chairperson + "</p>"

                   + "<p>" + "<b>" + " Scribe : " + "</b> " + scribe + "</p>"
                   
                   + "<p>" + "<b>" + " Presentation Date : " + "</b> " +  presentation_date + "</p>"

                   + "<p>" + "<b>" + " Presentation Time : " + "</b> " +  presentation_time + "</p>"

                   + "<p>" + "<b>" + " Meeting Room : " + "</b> " + meeting_room + "</p>"

                   + "<p>" + "<b>" + " Days Before WP : " + "</b> " + days_to_go + "</p>"

                     //   + "<p>" + " . " + approval_status + "</p>"

                       + "<p>" + " " + URLComment + "</p>"

                      + Applink + "<p>" + " Please contact Work Program Team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"

                      + Applink + "<p>" + " Thank you " + "</p>" + "</span>"
                      
                      + "</p>" + "<p>"  + "</b></span>" + "</p>"

                 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

                 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


                + "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>" 
                

                + "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2021 Powered by NUPRC Work Program Team" 

                + "</span>"
            
                                
                + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
         

            try
            {
                SmtpMail.Send(message);

                email_test = "E-Mail.";

                my_email_result = "Successful";
            }
            catch (Exception ex)
            {

                string myMsgErr = ex.Message;

                email_test = "E-Mail_";
                my_email_result = "Failed";
            }
            finally
            {
                // con.Close();
            }


        }

        public void SendMail_Notification_to_Companies()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = nes_subject; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy"; + "<br>" +
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Work Programme Data Upload Reminder " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


                  + "<p>" + "</p>"  //  This will give a paragraph

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Dear " + company_operator_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                   + "<p>" + "  " + nes_body + "</p>"                

                   + "<p>" + "<b>" + " Upload Days Left : " + "</b> " + days_to_go + "</p>"

                       //   + "<p>" + " . " + approval_status + "</p>"

                       + "<p>" + " " + URLComment + "</p>"

                      + Applink + "<p>" + " Please contact Work Program Team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"

                      + Applink + "<p>" + " Thank you " + "</p>" + "</span>"

                      + "</p>" + "<p>" + "</b></span>" + "</p>"

                 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

                 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


                + "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>"


                + "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2021 Powered by NUPRC Work Program Team"

                + "</span>"


                + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";


            try
            {
                SmtpMail.Send(message);

                email_test = "E-Mail.";

                my_email_result = "Successful";
            }
            catch (Exception ex)
            {

                string myMsgErr = ex.Message;

                email_test = "E-Mail_";
                my_email_result = "Failed";
            }
            finally
            {
                // con.Close();
            }


        }

        public void NES_SendMail_Project_Team_divisional_representative()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = nes_subject; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy"; + "<br>" +
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workprogam Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


                  + "<p>" + "</p>"  //  This will give a paragraph

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Dear " + official_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                   //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                   //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"   Company_operator_name

                   + "<p>" + "  " + nes_body + "</p>"

                   + "<p>" + "<b>" + " Company Name : " + "</b> " + company_operator_name + "</p>"

                   //+ "<p>" + "<b>" + " Chairman : " + "</b> " + chairperson + "</p>"

                   //+ "<p>" + "<b>" + " Scribe : " + "</b> " + scribe + "</p>"

                   + "<p>" + "<b>" + " Presentation Date : " + "</b> " + presentation_date + "</p>"

                   + "<p>" + "<b>" + " Presentation Time : " + "</b> " + presentation_time + "</p>"

                   + "<p>" + "<b>" + " Meeting Room : " + "</b> " + meeting_room + "</p>"

                   + "<p>" + "<b>" + " Days Before WP : " + "</b> " + days_to_go + "</p>"

                       //   + "<p>" + " . " + approval_status + "</p>"

                       + "<p>" + " " + URLComment + "</p>"

                      + Applink + "<p>" + " Please contact Work Program Team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"

                      + Applink + "<p>" + " Thank you " + "</p>" + "</span>"

                      + "</p>" + "<p>" + "</b></span>" + "</p>"

                 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

                 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


                + "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>"


                + "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2021 Powered by NUPRC Work Program Team"

                + "</span>"


                + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";


            try
            {
                SmtpMail.Send(message);

                email_test = "E-Mail.";

                my_email_result = "Successful";
            }
            catch (Exception ex)
            {

                string myMsgErr = ex.Message;

                email_test = "E-Mail_";
                my_email_result = "Failed";
            }
            finally
            {
                // con.Close();
            }


        }

        public void WP_SendMail_On_Data_Window_Extension()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = nes_subject; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy"; + "<br>" +
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workprogam Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


                  + "<p>" + "</p>"  //  This will give a paragraph

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Dear " + official_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                   //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                   //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"   Company_operator_name

                   + "<p>" + "  " + nes_body + "</p>"

                       //+ "<p>" + " " + URLComment + "</p>"

                      + Applink + "<p>" + " Please contact Work Programme Team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"

                      + Applink + "<p>" + " Thank you " + "</p>" + "</span>"

                      + "</p>" + "<p>" + "</b></span>" + "</p>"

                 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

                 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


                + "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>"


                + "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2021 Powered by NUPRC Work Program Team"

                + "</span>"


                + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";


            try
            {
                SmtpMail.Send(message);

                email_test = "E-Mail.";

                my_email_result = "Successful";
            }
            catch (Exception ex)
            {

                string myMsgErr = ex.Message;

                email_test = "E-Mail_";
                my_email_result = "Failed";
            }
            finally
            {
                // con.Close();
            }


        }

        public void NES_SendMail_When_Concession_information_is_completed()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = nes_subject; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy"; + "<br>" +
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workprogam Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


                  + "<p>" + "</p>"  //  This will give a paragraph

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Hello " + company_rep_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                   //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                   //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"   Company_operator_name

                   + "<p>" + "  " + nes_body + "</p>"

                   + "<p>" + "<b>" + " Company Name : " + "</b> " + company_operator_name + "</p>"

                   + "<p>" + "<b>" + " Concession Held : " + "</b> " + concession_held + "</p>"

                   //+ "<p>" + "<b>" + " Scribe : " + "</b> " + scribe + "</p>"

                   //+ "<p>" + "<b>" + " Presentation Date : " + "</b> " + presentation_date + "</p>"

                   //+ "<p>" + "<b>" + " Presentation Time : " + "</b> " + presentation_time + "</p>"

                   //+ "<p>" + "<b>" + " Meeting Room : " + "</b> " + meeting_room + "</p>"

                   //+ "<p>" + "<b>" + " Days Before WP : " + "</b> " + days_to_go + "</p>"

                   //    //   + "<p>" + " . " + approval_status + "</p>"

                       + "<p>" + " " + Applink + "</p>"

                      + URLComment + "<p>" + " Please contact Work Program Team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"

                      + URLComment + "<p>" + " Thank you " + "</p>" + "</span>"

                      + "</p>" + "<p>" + "</b></span>" + "</p>"

                 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

                 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


                + "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>"


                + "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2021 Powered by NUPRC Work Program Team"

                + "</span>"


                + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";


            try
            {
                SmtpMail.Send(message);

                email_test = "E-Mail.";

                my_email_result = "Successful";
            }
            catch (Exception ex)
            {

                string myMsgErr = ex.Message;

                email_test = "E-Mail_";
                my_email_result = "Failed";
            }
            finally
            {
                // con.Close();
            }


        }

        public void NES_SendMail_password_changed()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //  message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = nes_subject; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy"; + "<br>" +
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workprogam Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


                  + "<p>" + "</p>"  //  This will give a paragraph

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Hello " + company_rep_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                   //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                   //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"   Company_operator_name

                   + "<p>" + "  " + nes_body + "</p>"

                   + "<p>" + "<b>" + " Password : " + "</b> " + company_operator_name + "</p>"
                                      
                       + "<p>" + " " + Applink + "</p>"

                      + URLComment + "<p>" + " Please contact NUPRC Work Programme Team for  any help. " + "</p>" + "</span>" + "</p>" + "<p>"

                      + URLComment + "<p>" + " Thank you " + "</p>" + "</span>"

                      + "</p>" + "<p>" + "</b></span>" + "</p>"

                 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

                 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


                + "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>"


                + "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2021 Powered by NUPRC Work Program Team"

                + "</span>"


                + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";


            try
            {
                SmtpMail.Send(message);

                email_test = "E-Mail.";

                my_email_result = "Successful";
            }
            catch (Exception ex)
            {

                string myMsgErr = ex.Message;

                email_test = "E-Mail_";
                my_email_result = "Failed";
            }
            finally
            {
                // con.Close();
            }


        }

        public void SendMail_for_Profile()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //  message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = nes_subject; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy"; + "<br>" +
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workprogam Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


                  + "<p>" + "</p>"  //  This will give a paragraph

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Hello " + company_rep_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                   //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                   //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"   Company_operator_name

                   + "<p>" + "  " + nes_body + "</p>"

                   + "<p>" + "<b>" + " Company Name : " + "</b> " + company_operator_name + "</p>"
                   + "<p>" + "<b>" + " Company Code : " + "</b> " + companycode + "</p>"
                   + "<p>" + "<b>" + " Unique ID : " + "</b> " + uniqueid + "</p>"

                       + "<p>" + " " + Applink + "</p>"

                      + URLComment + "<p>" + " Please contact NUPRC Work Programme Team for any help. " + "</p>" + "</span>" + "</p>" + "<p>"

                      + URLComment + "<p>" + " Thank you " + "</p>" + "</span>"

                      + "</p>" + "<p>" + "</b></span>" + "</p>"

                 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

                 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


                + "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>"


                + "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2021 Powered by NUPRC Work Program Team"

                + "</span>"


                + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";

            try
            {
                SmtpMail.Send(message);

                email_test = "E-Mail.";

                my_email_result = "Successful";
            }
            catch (Exception ex)
            {
                string myMsgErr = ex.Message;

                email_test = "E-Mail_";
                my_email_result = "Failed";
            }
            finally
            {
                // con.Close();
            }


        }

        public void SendMail_Login_Credentials()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //  message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = nes_subject; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy"; + "<br>" +
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workprogam Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


                  + "<p>" + "</p>"  //  This will give a paragraph

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Dear " + company_rep_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                   //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                   //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"   Company_operator_name

                   + "<p>" + "  " + nes_body + "</p>"

                   + "<p>" + "<b>" + " Company Name : " + "</b> " + company_operator_name + "</p>"
                   + "<p>" + "<b>" + " Login Email : " + "</b> " + Email + "</p>"
                   + "<p>" + "<b>" + " Password : " + "</b> " + Password + "</p>"

                       + "<p>" + " " + Applink + "</p>"

                      + URLComment + "<p>" + " Please contact NUPRC Work Programme Team for any help. " + "</p>" + "</span>" + "</p>" + "<p>"

                      + URLComment + "<p>" + " Thank you " + "</p>" + "</span>"

                      + "</p>" + "<p>" + "</b></span>" + "</p>"

                 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

                 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


                + "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>"


                + "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2021 Powered by NUPRC Work Program Team"

                + "</span>"


                + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";


            try
            {
                SmtpMail.Send(message);

                email_test = "E-Mail.";

                my_email_result = "Successful";
            }
            catch (Exception ex)
            {

                string myMsgErr = ex.Message;

                email_test = "E-Mail_";
                my_email_result = "Failed";
            }
            finally
            {
                // con.Close();
            }


        }

        public void SendMail_Error_Logs()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //  message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = nes_subject; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy"; + "<br>" +
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workprogam Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


                  + "<p>" + "</p>"  //  This will give a paragraph

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Hello " + company_rep_name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                   //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                   //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"   Company_operator_name

                   + "<p>" + " Error Log Message : " + nes_body + "</p>"

                   + "<p>" + "<b>" + " Query String (Error) : " + "</b> " + company_operator_name + "</p>"

                       + "<p>" + " " + Applink + "</p>"

                      + URLComment + "<p>" + " Please contact Work Program Team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"

                      + URLComment + "<p>" + " Thank you " + "</p>" + "</span>"

                      + "</p>" + "<p>" + "</b></span>" + "</p>"

                 //  + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>" + " " + "<br>"

                 + "<p><span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">" + " " + "<br>"


                + "Note: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=3 align=left valign=top  bgcolor=#00a65a>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=11  bgcolor=#FFFFFF>"


                + "<span style=\"font-size: 11px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2021 Powered by NUPRC Work Program Team"

                + "</span>"


                + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";


            try
            {
                SmtpMail.Send(message);

                email_test = "E-Mail.";

                my_email_result = "Successful";
            }
            catch (Exception ex)
            {

                string myMsgErr = ex.Message;

                email_test = "E-Mail_";
                my_email_result = "Failed";
            }
            finally
            {
                // con.Close();
            }


        }

        public void SendMail_Requester()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = tx_email_subject; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                   + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"

                   + "<p>" + " . " + myRef + "</p>"

                    + "<p>" + " . " + Switch_name + "</p>"

                   + "<p>" + " . " + Room_name + "</p>"


                   + "<p>" + " . " + Rack_name + "</p>"


                   + "<p>" + " . " + Rack_size + "</p>"


                   + "<p>" + " . " + No_of_U + "</p>"

                     + "<p>" + " . " + approval_status + "</p>"


                      + "<p>" + " " + URLComment + "</p>"

                      + Applink + "<p>" + " Kindly contact Transmission Core Planning Team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                  //+ "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to login and view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "Transmission Core Planning Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2018 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

                string myMsgErr = ex.Message;
            }
            finally
            {
                // con.Close();
            }


        }

        public void SendMail_from_manager_to_Requester()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + " Manager Notification of Request - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Description : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Item Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to login and view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.
            }
            finally
            {
                //log report
            }
        }

        public void SendMail_linemanger_to_LINE_MANAGER_new()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + " Manager Notification of Request - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                       + "<p>" + " Description : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Item Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to login and view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.
            }
            finally
            {
                //log report
            }
        }

        public void SendMail_Requester_LINE_MANAGER()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "Notification of Request - see below details" + "</p>" + "<p>"


                  + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to respond to request " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

                string myMsgErr = ex.Message;
            }
            finally
            {
                // con.Close();
            }

        }

        public void SendMail_linemanger_to_LINE_MANAGER()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + " Manager Notification Response - see below details" + "</p>" + "<p>"

                  + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

                string myMsgErr = ex.Message;
            }
            finally
            {
                // con.Close();
            }
        }

        public void SendMail_tcp_guys_to_requester()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + " TCP Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_NID_guys_to_requester()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + " NID Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_ess_guys_to_requester()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + " ESS Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_ess_guys_to_requester()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "ESS Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_ess_guys_to_requester_manager()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "ESS Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_ess_guys_to_ess_guys()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello ESS Team, <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "ESS Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_ess_guys_to_tcpguys_and_txcore_manager()
        {
            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello TCP Team & Line Manager, <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "ESS Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"

                     + "</p>" + " Please note : Approval is required from TX CORE Manager for NID to Action" + "</p>" + "<p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_tcp_guys_to_LINE_MANAGER()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + " TCP Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_NID_guys_to_LINE_MANAGER()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + " NID Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_ess_guys_to_LINE_MANAGER()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + Name + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + " NID Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_tcp_guys_to_tcp_team()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " Transmission Core Planning Team " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "Notification Response - see below details.." + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status or respond " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_ess_guys_to_tcp_team()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " TCP Team " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "ESS TEAM Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status or respond " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_TXCOREMANAGER_to_tcp_team()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " TCP Team " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "TCP MANAGER Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status or respond " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_TXCOREMANAGER_to_NID_team()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " NID Team " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "TCP MANAGER Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status or respond " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_NID_to_STAKEHOLDER()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " All " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + " Notification to all Stakeholders - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status or respond " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_TCP_to_STAKEHOLDER()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " All " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + " Notification to all Stakeholders : Allocation of Space- see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status or respond " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_tcp_guys_to_ess_team()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " ESS Team " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_ess_guys_to_ess_team()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " ESS Team " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_from_TXCOREMANAGER_to_ess_team()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " ESS Team " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "TX CORE MANAGER Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_to_tcp_manager()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " TCP Manager " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

        public void SendMail_to_nid_team()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;

            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " NID Manager " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.
            }
            finally
            {
                //log report
            }
        }

        public void SendMail_to_all_stakeholders()
        {

            MailAddress fromAddress = new MailAddress(FromAddress);

            message.To.Clear();
            message.To.Add(ToRecieved);
            message.From = fromAddress;

            ///// build the body of the mail and subject
            //// message.CC.Add(ToRecievedCC);

            //message.CC.Clear();
            //string strEmailCc = System.Configuration.ConfigurationManager.AppSettings["EmailCC"];
            //int i = 0;
            //string[] myToRecievedCC = strEmailCc.Split(',');
            //for (i = 0; i < myToRecievedCC.Length; i++)
            //{
            //    message.CC.Add(myToRecievedCC[i]);
            //}

            //message.Subject = Subject;
            message.Subject = location_reion_siteid; // Document Name

            message.IsBodyHtml = true;
            //message.Body = "dear " + Firstname + " " + Surname + " Toooooooooooooooonnnnnnnnnnyyyyyyyyy";
            message.Body = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workflow Notification" + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#FACD58>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"


                 + "Hello " + " All " + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                  + "</p>" + "Notification Response - see below details" + "</p>" + "<p>"

                   + "<p>" + " Ref Id : " + "<b>" + myRef + "</b>" + "</p>"

                      + "<p>" + " Location : " + "<b>" + location_reion_siteid + "</b>" + "</p>"

                   + "<p>" + " Site Name : " + site_name + "</p>"


                   + "<p>" + " Approval Status : " + approval_status + "</p>"


                  + "Click <a href=http://ojtssapp1/nes_workflow/login.aspx> HERE</a> to view status " + "<p>" + " Kindly contact TCP team for further clarification " + "</p>" + "</span>" + "</p>" + "<p>"


                + "</b></span>" + "</p>" + "<p><span style=\"font-size: 6 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">" + "Thank you." + "<br><br> " + "TCP Team" + "<br><br><b>"

                + "NOTE: This email Message is auto-generated, Please do not reply to the email address" + "</b></p>" + "</td>" + "</tr>" + "<tr>" + "<td height=5 align=left valign=top  bgcolor=#FACD58>"

                + "</td>" + "</tr>" + "<tr>" + "<td align=center valign=middle height=15  bgcolor=#FFFFFF>" + "<span style=\"font-size: 13px; color:#000000; font-family:Verdana,Helvetica, sans-serif\">"

                + "&copy;" + " 2017 Powered by Technical Systems Support Team (TSS)" + "</span>" + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body>";
            //message.Body = MailBody;

            //message.Body = "<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>Hello" + Firstname + " " + Surname + "Congratulation, you have registered and can log in anytime with the following details.<b>Username :" + UserName + " ;</b><b>Password:" + UserName + " </br>Note: This email message is auto generated,Please donot reply";
            //message.Body="<html xmlns='http://www.w3.org/1999/xhtml'><style type='text/css'><!-- .style1 {font-family: 'Myriad Pro'} .style2 {font-family: 'Myriad Pro'; font-size: 24px; }--></style><body><p class='style2'>Cornea Job Site</p><hr><p class='style1'>" + salutation + "Your expense claim <b>" + ReferenceId + "</b> of <b>" + CurrencyCode + string.Format("{0:N}", Amount) + "</b> has been processed. <br/>Kindly pick up your " + ModeofPayment + " from the finance cash office.</p><p>Regards,</p><strong>Business Support  Unit/Finance</strong></body></html>";

            try
            {
                SmtpMail.Send(message);
            }
            catch (Exception ex)
            {
                // mailer fail.

            }
            finally
            {
                //log report
            }
        }

    }
}