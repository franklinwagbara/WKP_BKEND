using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Net.Mime;
using System.Reflection;

using System.Threading;

using System.Data.SqlClient;
using System.Data;
using System.Text;
using Backend_UMR_Work_Program.Models;
using Backend_UMR_Work_Program.Services;
using Microsoft.Extensions.Options;

namespace Backend_UMR_Work_Program
{
    public class SendMailJob_div_rep : IJob
     {
        private string? systemdate_email, id, COMPANYNAME, chairperson, chairperson_email, scribe, scribe_email, presentation_date, presentation_time, meeting_room, days_to_go, systemdate, Check_Days_to_send_Email, officiating_names, officiating_emails, system_date, My_email_result;

        private string? rep_name, rep_email;

        TimeSpan ts_totalduration;
        private Connection mycon;
        private readonly AppSettings _appSettings;
        private readonly SmtpSettings _smtpSettings;

        public SendMailJob_div_rep(Connection connection, IOptions<SmtpSettings> smtpSettings, IOptions<AppSettings> appSettings)
        {
            mycon = connection;
            _smtpSettings = smtpSettings.Value;
            _appSettings = appSettings.Value;
        }

        public void Execute(IJobExecutionContext context)
        {
            string yeys = "YES";

            systemdate = DateTime.Now.ToString("MM/dd/yyyy HH:mm");

            string systemdate2 = DateTime.Now.ToString("MM/dd/yyyy HH:mm");

            systemdate_email = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");


            //if (systemdate == "08/15/2019 11:07")
            //{ }
          
            wp_check_ADMIN_DATETIME_PRESENTATION_Table_and_send_email_Divisional_Representative();

            }




        private void Work_Program_Email_Notification()
        {
            ////***************************************** Mailing to user that he has requested Space**********

            mails requester_mail = new mails();

            requester_mail.NES_subject = "Work Program Notification";

            requester_mail.Official_name = " <b> " + officiating_names + "  </b> ";

            requester_mail.NES_body = "You have been scheduled to officiate Work Program activity . <br/>  <br/> Please find Work Program details below.";

            requester_mail.Company_operator_name = COMPANYNAME;

            requester_mail.Chairperson = chairperson;

            requester_mail.Scribe = scribe;

            requester_mail.Presentation_date = presentation_date;

            requester_mail.Presentation_time = presentation_time;

            requester_mail.Days_to_go = Check_Days_to_send_Email + "Day(s)";

            requester_mail.Meeting_room = meeting_room;

            requester_mail.ToRecieved = officiating_emails;
            requester_mail.ToRecievedCC = "anthony.nwosu@brandonetech.com";

            //requester_mail.ToRecieved = "anthony.nwosu@brandonetech.com";
            //requester_mail.ToRecievedCC = "tonygentle2000@yahoo.com";
            //  requester_mail.Applink = "Click <a href=http://workprogram.azurewebsites.net/> HERE</a> to Action the request";

            requester_mail.NES_SendMail_Project_Team();

            My_email_result = requester_mail.My_email_result;

            string ichecker = "YES";




            ////***************************************************** END****************************************
        }


        private void Work_Program_Email_Notification_divisional_representative()
        {
            //////***************************************** Mailing to user that he has requested Space**********

            //mails requester_mail = new mails();

            //requester_mail.NES_subject = "Work Program Notification";

            //requester_mail.Official_name = " <b> " + officiating_names + "  </b> ";

            //requester_mail.NES_body = "You have been scheduled to officiate Work Program activity . <br/>  <br/> Please find Work Program details below.";

            //requester_mail.Company_operator_name = COMPANYNAME;

            ////requester_mail.Chairperson = chairperson;

            ////requester_mail.Scribe = scribe;

            //requester_mail.Presentation_date = presentation_date;

            //requester_mail.Presentation_time = presentation_time;

            //requester_mail.Days_to_go = Check_Days_to_send_Email + "Day(s)";

            //requester_mail.Meeting_room = meeting_room;

            //// requester_mail.ToRecieved = "anthony.nwosu@brandonetech.com , tonygentle2005@gmail.com"; "madaki.J.M" <madaki.J.M@dpr.gov.ng>

            //requester_mail.ToRecieved = officiating_emails;
            //requester_mail.ToRecievedCC = "akpagher.v.v@dpr.gov.ng , anthony.nwosu@brandonetech.com";

            ////  requester_mail.ToRecievedCC = "okoro.e.e@dpr.gov.ng , amadasu.e.e@dpr.gov.ng , akpomudjere.o.o@dpr.gov.ng , madaki.J.M@dpr.gov.ng , anthony.nwosu@brandonetech.com";

            ////requester_mail.ToRecieved = "anthony.nwosu@brandonetech.com";
            ////requester_mail.ToRecievedCC = "tonygentle2000@yahoo.com";

            ////  requester_mail.Applink = "Click <a href=http://workprogram.azurewebsites.net/> HERE</a> to Action the request";

            //requester_mail.NES_SendMail_Project_Team_divisional_representative();

            //My_email_result = requester_mail.My_email_result;

            //string ichecker = "YES";
            //////***************************************************** END****************************************
            ///


            // Start 

            string URLComment = "";
            string Applink = "Click <a href= https://workprogram.nuprc.gov.ng > HERE</a> to login to Work Program Application.";

            days_to_go = Check_Days_to_send_Email + "Day(s)";

            string subject = "Work Program Notification";

            string nes_body = "You have been scheduled to officiate Work Program activity . <br/>  <br/> Please find Work Program details below";

            //string company_operator_name = Session["CN"].ToString();
            //string company_rep_name = TextBox1.Text;
            //string Email = TextBox4.Text;
            //string Password = TextBox5.Text;
            //string Applink = "Click <a href= https://workprogram.nuprc.gov.ng > HERE</a> to login to Work Program Application. Please change password for security reasons";

            //string URLComment = "";



            string to = officiating_emails;// "anthony.nwosu@brandonetech.com"; //To address    
            string from = "no-reply@nuprc.gov.ng"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "<html><body>" + "<table width=100% border=0 bordercolor=#CCCCCC cellspacing=0 cellpadding=0>" +


                "<tr>" + "<td align=left valign=top>" + "<table width=100% border=0 cellspacing=0 cellpadding=0>"

                + "<tr>" + "<td align=left valign=top>" + "<span style=\"font-size: 33 px; font-family:Myriad Pro, Arial\">"

                + "<b>" + " Workprogam Notification " + "</b></span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top height=2 bgcolor=#FFFFFF>"

                + "&nbsp;" + "</td>" + "</tr>" + "<tr>" + "<td height=2 align=right valign=top bgcolor=#00a65a>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>"


                  + "<p>" + "</p>"  //  This will give a paragraph

                + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\">"

                 + "Dear " + officiating_names + ", <br>" + "</span>" + "</td>" + "</tr>" + "<tr>" + "<td align=left valign=top>" + "<p>" + "<span style=\"font-size: 13 px; color:#000000; font-family:Trebuchet MS, Myriad Pro, Arial\"> "


                   //+ "</p>" + " Notification of Request - see below details" + "</p>" + "<p>"

                   //  + "<p>" + " " + "<b>" + notification_header + "</b>" + "</p>" + "<p>"   Company_operator_name

                   + "<p>" + "  " + nes_body + "</p>"

                   + "<p>" + "<b>" + " Company Name : " + "</b> " + COMPANYNAME + "</p>"

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

            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("email-smtp.us-east-2.amazonaws.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("AKIAQCM2OPFBW35OSTFV", "BJIdfFWQCb/fdKYej/Mw6EfHK3QJ9XPJ9k6UwHLcjjsu");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(message);
                // client.Dispose();
            }

            catch (Exception ex)
            {
                throw ex;
            }


            // End



        }




        private void wp_check_ADMIN_DATETIME_PRESENTATION_Table_and_send_email()
        {

            //Connection mycon = new Connection();
            SqlConnection con = new SqlConnection(mycon.Myconnection);

            SqlDataAdapter da = new SqlDataAdapter("Select * from ADMIN_DATETIME_PRESENTATION ", con);
            // SqlDataAdapter da = new SqlDataAdapter("Select * from ADMIN_DATETIME_PRESENTATION where id = 310", con);
            DataTable result = new DataTable();

            da.Fill(result);

            string countrecords = result.Rows.Count.ToString();

            int count_record = int.Parse(countrecords);
            for (int m = 0; m < count_record; m++)
            {
                try
                {
                    id = result.Rows[m]["id"].ToString(); // REPORT REF
                    COMPANYNAME = result.Rows[m]["COMPANYNAME"].ToString(); // 

                    chairperson = result.Rows[m]["CHAIRPERSON"].ToString(); // 
                    scribe = result.Rows[m]["SCRIBE"].ToString(); // 

                    chairperson_email = result.Rows[m]["CHAIRPERSONEMAIL"].ToString(); // 

                    scribe_email = result.Rows[m]["SCRIBEEMAIL"].ToString(); // 

                    //chairperson_email = "anthony.nwosu@brandonetech.com";

                    //scribe_email = "tonygentle2000@yahoo.com";


                    if (scribe_email == "")
                    {
                        scribe_email = "no_scribe_email@nuprc.gov.ng";
                    }

                    if (chairperson_email == "")
                    {
                        chairperson_email = "no_scribe_email@nuprc.gov.ng";
                    }

                    officiating_emails = chairperson_email + " , " + scribe_email;

                    presentation_date = result.Rows[m]["DATE_TIME_TEXT"].ToString(); // 
                    presentation_time = result.Rows[m]["wp_time"].ToString(); // 

                    officiating_names = chairperson + " " + " &" + " " + scribe;

                    meeting_room = result.Rows[m]["MEETINGROOM"].ToString(); // 
                                                                             //string days_to_go = result.Rows[m]["wp_date"].ToString(); // 

                    string wp_date = result.Rows[m]["wp_date"].ToString(); // 
                    DateTime wp_date_scheduled = System.Convert.ToDateTime(wp_date); // This Holds the value for the initiation date ...

                    string SystemDate_string = DateTime.Now.ToString("MM/dd/yyyy"); // DATE TIME

                    DateTime System_endDate = System.Convert.ToDateTime(SystemDate_string);

                    ts_totalduration = wp_date_scheduled.Subtract(System_endDate);

                    int weekends = 0;

                    //// The for is to check if the date for the work program has passed ... this mean the start date must me less than the end date
                    //for (DateTime tempDt = wp_date_scheduled; tempDt.Date < System_endDate.Date; tempDt = tempDt.AddDays(1))
                    //{
                    //    if (tempDt.DayOfWeek == DayOfWeek.Saturday || tempDt.DayOfWeek == DayOfWeek.Sunday)
                    //        weekends++;
                    //}


                    for (DateTime tempDt = System_endDate; tempDt.Date < wp_date_scheduled.Date; tempDt = tempDt.AddDays(1))
                    {
                        if (tempDt.DayOfWeek == DayOfWeek.Saturday || tempDt.DayOfWeek == DayOfWeek.Sunday)
                            weekends++;
                    }


                    ts_totalduration = ts_totalduration.Subtract(new TimeSpan(weekends, 0, 0, 0));

                    Check_Days_to_send_Email = ts_totalduration.Days.ToString();

                    if (Check_Days_to_send_Email == "7")
                    {
                        string Check1 = "Yes";

                        Work_Program_Email_Notification();
                        Update_EMAIL_INFORMATION();
                    }

                    if (Check_Days_to_send_Email == "3")
                    {
                        string Check2 = "Yes";

                        Work_Program_Email_Notification();
                        Update_EMAIL_INFORMATION();
                    }

                    if (Check_Days_to_send_Email == "1")
                    {
                        string Check3 = "Yes";

                        Work_Program_Email_Notification();
                        Update_EMAIL_INFORMATION();
                    }


                    string Check = "Yes";


                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    con.Close();
                }
                finally
                {
                    con.Close();
                }

            }
        }






        private void wp_check_ADMIN_DATETIME_PRESENTATION_Table_and_send_email_Divisional_Representative()
        {

            //Connection mycon = new Connection();
            SqlConnection con = new SqlConnection(mycon.Myconnection);

            SqlDataAdapter da = new SqlDataAdapter("Select * from ADMIN_DIVISIONAL_REPS_PRESENTATION  WHERE EMAIL_REMARK = 'ACTIVE' ", con);

            // SqlDataAdapter da = new SqlDataAdapter("Select * from ADMIN_DATETIME_PRESENTATION where id = 310", con);
            DataTable result = new DataTable();

            da.Fill(result);

            string countrecords = result.Rows.Count.ToString();

            int count_record = int.Parse(countrecords);
            for (int m = 0; m < count_record; m++)
            {
                try
                {
                    id = result.Rows[m]["id"].ToString(); // REPORT REF
                    COMPANYNAME = result.Rows[m]["COMPANYNAME"].ToString(); // 

                    //chairperson = result.Rows[m]["CHAIRPERSON"].ToString(); // 
                    //scribe = result.Rows[m]["SCRIBE"].ToString(); // 

                    rep_name = result.Rows[m]["REPRESENTATIVE"].ToString(); // 

                    rep_email = result.Rows[m]["REPRESENTATIVE_EMAIL"].ToString(); // 

                    //chairperson_email = "anthony.nwosu@brandonetech.com";

                    //scribe_email = "tonygentle2000@yahoo.com";


                    if (rep_email == "")
                    {
                        rep_email = "no_scribe_email@nuprc.gov.ng";
                    }

                    officiating_emails = rep_email;

                    presentation_date = result.Rows[m]["DATE_TIME_TEXT"].ToString(); // 
                    presentation_time = result.Rows[m]["wp_time"].ToString(); // 

                    officiating_names = rep_name;

                    meeting_room = result.Rows[m]["MEETINGROOM"].ToString(); // 
                                                                             //string days_to_go = result.Rows[m]["wp_date"].ToString(); // 

                    string wp_date = result.Rows[m]["wp_date"].ToString(); // 
                    DateTime wp_date_scheduled = System.Convert.ToDateTime(wp_date); // This Holds the value for the initiation date ...

                    string SystemDate_string = DateTime.Now.ToString("MM/dd/yyyy"); // DATE TIME

                    DateTime System_endDate = System.Convert.ToDateTime(SystemDate_string);

                    ts_totalduration = wp_date_scheduled.Subtract(System_endDate);

                    int weekends = 0;

                    //// The for is to check if the date for the work program has passed ... this mean the start date must me less than the end date
                    //for (DateTime tempDt = wp_date_scheduled; tempDt.Date < System_endDate.Date; tempDt = tempDt.AddDays(1))
                    //{
                    //    if (tempDt.DayOfWeek == DayOfWeek.Saturday || tempDt.DayOfWeek == DayOfWeek.Sunday)
                    //        weekends++;
                    //}


                    for (DateTime tempDt = System_endDate; tempDt.Date < wp_date_scheduled.Date; tempDt = tempDt.AddDays(1))
                    {
                        if (tempDt.DayOfWeek == DayOfWeek.Saturday || tempDt.DayOfWeek == DayOfWeek.Sunday)
                            weekends++;
                    }


                    ts_totalduration = ts_totalduration.Subtract(new TimeSpan(weekends, 0, 0, 0));

                    Check_Days_to_send_Email = ts_totalduration.Days.ToString();

                    if (Check_Days_to_send_Email == "7")
                    {
                        string Check1 = "Yes";

                        Work_Program_Email_Notification_divisional_representative();
                        Update_EMAIL_INFORMATION__Divisional_Representative();
                    }

                    if (Check_Days_to_send_Email == "3")
                    {
                        string Check2 = "Yes";

                        Work_Program_Email_Notification_divisional_representative();
                        Update_EMAIL_INFORMATION__Divisional_Representative();
                    }

                    if (Check_Days_to_send_Email == "1")
                    {
                        string Check3 = "Yes";

                        Work_Program_Email_Notification_divisional_representative();
                        Update_EMAIL_INFORMATION__Divisional_Representative();
                    }


                    string Check = "Yes";


                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    con.Close();
                }
                finally
                {
                    con.Close();
                }

            }
        }




        private void Update_EMAIL_INFORMATION()
        {
            system_date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"); // DATE TIME
            //Connection mycon = new Connection();
            SqlConnection con = new SqlConnection(mycon.Myconnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();

            try
            {
                string email_days_to_go = Check_Days_to_send_Email + "Day(s)";

                cmd.CommandText = "Update ADMIN_DATETIME_PRESENTATION  SET  LAST_RUN_DATE = '" + systemdate_email + "' , EMAIL_REMARK = '" + My_email_result + "' , DAYS_TO_GO = '" + email_days_to_go + "'   WHERE  Id  = '" + id + "' ";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string myMsgErr = ex.Message;
                con.Close();
            }
            finally
            {
                con.Close();
                //  Response.Redirect("tx_view_status_installation.aspx");
            }
        }



        private void Update_EMAIL_INFORMATION__Divisional_Representative()
        {
            system_date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"); // DATE TIME
            //Connection mycon = new Connection();
            SqlConnection con = new SqlConnection(mycon.Myconnection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();

            try
            {
                string email_days_to_go = Check_Days_to_send_Email + "Day(s)";

                cmd.CommandText = "Update ADMIN_DIVISIONAL_REPS_PRESENTATION  SET  LAST_RUN_DATE = '" + systemdate_email + "' ,  DAYS_TO_GO = '" + email_days_to_go + "'   WHERE  Id  = '" + id + "' ";
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string myMsgErr = ex.Message;
                con.Close();
            }
            finally
            {
                con.Close();
                //  Response.Redirect("tx_view_status_installation.aspx");
            }
        }




        private void SendMail()
        {
            // put your send mail logic here
        }

        public void SendMailDNPlus(string ToName, string FromName, string FromAddress, string To, string ToCC, string RequestStatus, string AdditionalMailData, string AdditionalMailData2, string DNStatusColor, string SubjectDNPlus, string MessageCSSDNPlus, string MessageDNPlus)
        {
            Random rnd = new Random();
            int bannerLoc = rnd.Next(1, 12);
            bannerLoc = 1;

            MailAddress from = new MailAddress(FromAddress, FromName);

            MailMessage message = new MailMessage();
            message.From = from;

            string[] _tos = To.Split('~');
            foreach (string _to in _tos)
            {
                MailAddress to = new MailAddress(_to);

                if (!to.Equals(""))
                    message.To.Add(to);
            }

            if (!ToCC.Equals(string.Empty))
            {
                string[] ccs = ToCC.Split('~');
                foreach (string cc in ccs)
                {
                    MailAddress copy = new MailAddress(cc);

                    if (!cc.Equals(""))
                        message.CC.Add(copy);
                }
            }

            string escalatedTo = "";
            string aManager = "";
            string anEngineer = "";
            string status = "";
            string intro = "";
            string color = "";
            string footCaption = "";
            string footLink = "";

            switch (RequestStatus.ToLower())
            {
                case "approver":
                    intro = AdditionalMailData;
                    escalatedTo = AdditionalMailData2;
                    status = "";
                    color = DNStatusColor;
                    footCaption = "To Login, ";
                    footLink = "<a href=\"{requestPath}\">Click Here! &raquo;</a>";

                    if (SubjectDNPlus.Trim().ToLower().Contains("disapproved"))
                    {
                        RequestStatus = "Disapproved";
                        color = "#900";
                    }
                    else if (SubjectDNPlus.Trim().ToLower().Contains("completed"))
                    {
                        RequestStatus = "Completed";
                        color = "#5cb85c";
                    }
                    else
                    {
                        RequestStatus = "Pending other approval(s)";
                        color = "#EE9A00";
                    }
                    break;
            }

            string requestPath = "http://ojtssapp1/disn/Account/Login.aspx";

            message.Subject = SubjectDNPlus;

            string messageCSS = MessageCSSDNPlus;
            string messageBody = MessageDNPlus.Replace("{ToName}", ToName).Replace("{intro}", intro).Replace("{EscalatedTo}", escalatedTo).Replace("{requestStatus}", RequestStatus).Replace("{requestPath}", requestPath).Replace("{copy}", DateTime.Now.Year.ToString()).Replace("{fontcolor}", color);
            //QS_BLL.WriteLog(message.Body);

            //HttpContext context = HttpContext.Current;
            //string filePath = Path.GetFullPath(".");
            //var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string dir1 = Directory.GetCurrentDirectory();
            string imgDir = AppDomain.CurrentDomain.BaseDirectory;
            //string dir3 = Environment.CurrentDirectory;
            //string dir4 = this.GetType().Assembly.Location;


            string? imgLocation = _appSettings.Location;
            string imgPath = imgDir + "\\" + imgLocation;
            string logo = "\\logo.png";
            string path = Path.Combine(imgDir, imgLocation);
            Console.WriteLine(path + logo);

            message.AlternateViews.Add(getEmbeddedImage(messageCSS, messageBody, path + logo, path + "\\" + bannerLoc + ".jpg"));
            message.IsBodyHtml = true;

            try
            {
                //SmtpSection section = (SmtpSection)ConfigurationManager.GetSection("mailSettings/smtp_1");
                SmtpClient sc = new SmtpClient();

                if (_smtpSettings.Server != null)
                {
                    sc.Host = _smtpSettings.Server;
                    sc.Port = _smtpSettings.Port;

                    sc.EnableSsl = false;
                    //QS_BLL.WriteLog("Sending Notification to: " + createdBy + ": " + to);

                    //SendAsynEmail(sc, message);
                    sc.Send(message);

                    //insertMailStatus(ToRecieved, SEVERITY, "Mail Sent Successfully", REPORTTITLE, "The Email was sent successfully");
                }
                else
                {
                    throw new Exception("Mail Section missing or null in the app.config file");
                }
            }
            catch (Exception ex)
            {
                //QS_BLL.WriteLog("Send Email Failed: " + ex.Message + ": " + ex.StackTrace);
                return;
            }
            finally
            {
                //log report
            }
        }

        public AlternateView getEmbeddedImage(string htmlCSS, string htmlBody, string filePath1 = "", string filePath2 = "")
        {
            LinkedResource res1 = new LinkedResource(filePath1);
            res1.ContentId = Guid.NewGuid().ToString();

            LinkedResource res2 = new LinkedResource(filePath2);
            res2.ContentId = Guid.NewGuid().ToString();

            htmlBody = htmlBody.Replace("{0}", res1.ContentId).Replace("{1}", res2.ContentId);//@"<img src='cid:" + res.ContentId + @"'/>";
            htmlBody = htmlBody.Replace("{css}", htmlCSS);

            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res1);
            alternateView.LinkedResources.Add(res2);

            return alternateView;
        }

        Task IJob.Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}