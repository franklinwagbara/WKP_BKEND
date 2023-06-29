using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Backend_UMR_Work_Program
{

    public class general_error_log
    {

        string otp, holder, msg, error_msg, system_date , myMsgErr , query_error_variable;
        Random random;
        int meme;


        public void call_general_error_log(Exception ex, string name , string query_error)
        {

           // int   meme = int.Parse(TextBox1.Text) + int.Parse(TextBox2.Text);

            system_date = DateTime.Now.ToString();
            DateTime sysdate = DateTime.Parse(system_date);
            system_date = sysdate.ToString("dd-MMM-yyyy hh:ss:tt");

            error_msg = system_date + " " + "Name" + " : " + name + "=> " + "Ex_Message" + " = " + ex.Message + " " + " . " + "Stack_Trace" + " = " + ex.StackTrace + " " + " . " + "InnerException" + " = " + ex.InnerException + " " + " . " + "Query Error " + " = " + query_error;

            query_error_variable = query_error;

            Error_logs insert_logs = new Error_logs();

            insert_logs.WriteLog(error_msg);

            Work_Program_Email_Notification_Error_Log();
            
        }



        private void Work_Program_Email_Notification_Error_Log()
        {          
            // Start 

            string subject = "Work Programme Error Log Notification";

            //string nes_body = "See Login Credentials Below";

            //string company_operator_name = Session["CN"].ToString();
            //string company_rep_name = TextBox1.Text;
            //string Email = TextBox4.Text;
            //string Password = TextBox5.Text;
            string Applink = "Click <a href= https://workprogram.nuprc.gov.ng > HERE</a> to login to Work Program Application. Please change password for security reasons";

            string URLComment = "";

            string to = "anthony.nwosu@brandonetech.com";// "anthony.nwosu@brandonetech.com"; //To address    
            string from = "no-reply@nuprc.gov.ng"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Work Program Error Log Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


                  + "<p>" + "</p>"  //  This will give a paragraph

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Hello " + to + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                   //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                   //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"   Company_operator_name

                   + "<p>" + " Error Log Message : " + error_msg + "</p>"

                   + "<p>" + "<b>" + " Query String (Error) : " + "</b> " + query_error_variable + "</p>"

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


                + "</td> " + "</tr>" + "</table>" + "</td>" + "</tr>" + "</table>" + "</html></body";

            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("email-smtp.us-east-2.amazonaws.com", 25); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("AKIAQCM2OPFBSV5LH3U7", "BJIdfFWQCb/fdKYej/Mw6EfHK3QJ9XPJ9k6UwHLcjjsu");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }


            // End



        }





    }
}