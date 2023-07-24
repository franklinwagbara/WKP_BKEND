using System.Data;
using System.Data.SqlClient;
using Backend_UMR_Work_Program.Models;
using static Backend_UMR_Work_Program.Models.ViewModel;

namespace Backend_UMR_Work_Program.Models
{
    public class Presentation
    {
        private Connection mycon;
        private CompanyDetail details;
        public Presentation(Connection connection)
        {
            mycon = connection;
            details = new CompanyDetail();
        }

        // Fields used for CompanyDetails
        //string? CompanyName, CompanyEmail;
        //string? OPEN_DATE, CLOSE_DATE, my_open_date, my_close_date;
        //string? Address_of_Company, Contact_Person, Phone_No, Email_Address, Name_of_MD_CEO, Phone_NO_of_MD_CEO,
        //        Alternate_Contact_Person, Phone_No_alt, Email_Address_alt;
        //private string system_date, system_date_year, system_date_proposed_year;

        public CompanyDetail CompanyDetails(string companyName, string companyEmail, string CompanyId)
        {

            details.system_date = DateTime.Now.ToString();
            details.system_date_year = DateTime.Now.AddYears(0).ToString("yyyy");
            details.system_date_proposed_year = DateTime.Now.AddYears(1).ToString("yyyy");

            details.CompanyName = companyName;
            details.CompanyEmail = companyEmail;


            return_Open_and_Close_Date(CompanyId);

            return_COMPANY_INFO_ALT_CONTACT_PERSON(details.CompanyName, details.CompanyEmail);

            return_COMPANY_INFO_CONTACT_PERSON(details.CompanyName, details.CompanyEmail);

            return_COMPANY_INFO_CONTACT_PERSON_2(details.CompanyName, details.CompanyEmail);

            return details;
        }

        private void return_Open_and_Close_Date(string companyId)
        {

            //Connection mycon = new Connection();
            SqlConnection con = new SqlConnection(mycon.Myconnection);
            // SqlCommand spcmd = new SqlCommand("select * from Result_Student_Information where session = '" + DropDownList1.SelectedItem.Text + "' and Term = '" + DropDownList2.SelectedItem.Text + "' and  Admission_No = '" + DropDownList3.SelectedItem.Text + "' ", con);
            SqlCommand spcmd = new SqlCommand(" Select * from ADMIN_CONCESSIONS_INFORMATION  WHERE COMPANY_ID =  '" + companyId + "' and YEAR =  '" + details.system_date_year + "'   ", con);

            spcmd.CommandType = CommandType.Text;
            spcmd.Connection = con;

            try
            {
                con.Open();
                System.Data.SqlClient.SqlDataReader rd = spcmd.ExecuteReader();

                if (rd.Read())
                {
                    details.OPEN_DATE = DateTime.Parse(rd["OPEN_DATE"].ToString()).ToString("dd-MMM-yyyy");
                    details.CLOSE_DATE = DateTime.Parse(rd["CLOSE_DATE"].ToString()).ToString("dd-MMM-yyyy");

                    details.my_open_date = rd["OPEN_DATE"].ToString();
                    details.my_close_date = rd["CLOSE_DATE"].ToString();

                    DateTime start_date = DateTime.Parse(details.my_open_date);
                    DateTime End_date = DateTime.Parse(details.my_close_date);
                    DateTime current_system_date = DateTime.Parse(details.system_date);


                    if (current_system_date <= End_date)
                    {
                    }
                    else
                    {
                        // Response.Redirect("access_denied.aspx");
                    }

                }

            }
            catch (Exception ex)
            {
                string myMsgErr = ex.Message;
                con.Close();
            }

            finally
            {
                con.Close();
            }
        }

        private void return_COMPANY_INFO_CONTACT_PERSON(string companyName, string companyEmail)
        {

            // Connection mycon = new Connection();
            SqlConnection con = new SqlConnection(mycon.Myconnection);
            // SqlCommand spcmd = new SqlCommand("select * from Result_Student_Information where session = '" + DropDownList1.SelectedItem.Text + "' and Term = '" + DropDownList2.SelectedItem.Text + "' and  Admission_No = '" + DropDownList3.SelectedItem.Text + "'  WHERE OML_ID =  '" + Session["Consession_Id"].ToString() + "' and Year_of_WP =  '" + system_date_year + "'  ", con);
            SqlCommand spcmd = new SqlCommand(" Select * from ADMIN_COMPANY_DETAILS  WHERE COMPANY_NAME =  '" + companyName + "' and EMAIL =  '" + companyEmail + "' and  FLAG = 'CONTACT PERSON'  ", con);

            spcmd.CommandType = CommandType.Text;
            spcmd.Connection = con;


            try
            {
                con.Open();
                SqlDataReader rd = spcmd.ExecuteReader();

                if (rd.Read())
                {
                    details.Address_of_Company = rd["Address_of_Company"].ToString();

                    details.Contact_Person = rd["Contact_Person"].ToString();

                    details.Phone_No = rd["Phone_No"].ToString();

                    details.Email_Address = rd["Email_Address"].ToString();

                }



            }
            catch (Exception ex)
            {
                string myMsgErr = ex.Message;
                con.Close();
            }

            finally
            {
                con.Close();
            }
        }
        private void return_COMPANY_INFO_CONTACT_PERSON_2(string companyName, string companyEmail)
        {

            SqlConnection con = new SqlConnection(mycon.Myconnection);
            // SqlCommand spcmd = new SqlCommand("select * from Result_Student_Information where session = '" + DropDownList1.SelectedItem.Text + "' and Term = '" + DropDownList2.SelectedItem.Text + "' and  Admission_No = '" + DropDownList3.SelectedItem.Text + "'  WHERE OML_ID =  '" + Session["Consession_Id"].ToString() + "' and Year_of_WP =  '" + system_date_year + "'  ", con);
            SqlCommand spcmd = new SqlCommand(" Select * from ADMIN_COMPANY_DETAILS  WHERE COMPANY_NAME =  '" + companyName + "' and EMAIL =  '" + companyEmail + "' and  FLAG = 'ALT CONTACT PERSON'  ", con);

            spcmd.CommandType = CommandType.Text;
            spcmd.Connection = con;


            try
            {
                con.Open();
                System.Data.SqlClient.SqlDataReader rd = spcmd.ExecuteReader();

                if (rd.Read())
                {
                    details.Address_of_Company = rd["Address_of_Company"].ToString(); //

                    details.Name_of_MD_CEO = rd["Name_of_MD_CEO"].ToString(); //

                    details.Phone_NO_of_MD_CEO = rd["Phone_NO_of_MD_CEO"].ToString(); //

                    details.Contact_Person = rd["Contact_Person"].ToString(); //

                    details.Phone_No = rd["Phone_No"].ToString(); //

                    details.Email_Address = rd["Email_Address"].ToString(); //

                }
            }
            catch (Exception ex)
            {
                string myMsgErr = ex.Message;
                con.Close();
            }

            finally
            {
                con.Close();
            }
        }




        private void return_COMPANY_INFO_ALT_CONTACT_PERSON(string companyName, string companyEmail)
        {

            //Connection mycon = new Connection();
            SqlConnection con = new SqlConnection(mycon.Myconnection);
            // SqlCommand spcmd = new SqlCommand("select * from Result_Student_Information where session = '" + DropDownList1.SelectedItem.Text + "' and Term = '" + DropDownList2.SelectedItem.Text + "' and  Admission_No = '" + DropDownList3.SelectedItem.Text + "'  WHERE OML_ID =  '" + Session["Consession_Id"].ToString() + "' and Year_of_WP =  '" + system_date_year + "'  ", con);
            SqlCommand spcmd = new SqlCommand(" Select * from ADMIN_COMPANY_DETAILS  WHERE COMPANY_NAME =  '" + companyName + "' and EMAIL =  '" + companyEmail + "' and  FLAG = 'ALT CONTACT PERSON'  ", con);

            spcmd.CommandType = CommandType.Text;
            spcmd.Connection = con;


            try
            {
                con.Open();
                System.Data.SqlClient.SqlDataReader rd = spcmd.ExecuteReader();

                if (rd.Read())
                {
                    details.Address_of_Company = rd["Address_of_Company"].ToString();

                    details.Name_of_MD_CEO = rd["Name_of_MD_CEO"].ToString();

                    details.Phone_NO_of_MD_CEO = rd["Phone_NO_of_MD_CEO"].ToString();

                    details.Alternate_Contact_Person = rd["Alternate_Contact_Person"].ToString();

                    details.Phone_No_alt = rd["Phone_No_alt"].ToString();

                    details.Email_Address_alt = rd["Email_Address_alt"].ToString();

                }

            }
            catch (Exception ex)
            {
                string myMsgErr = ex.Message;
                con.Close();
            }

            finally
            {
                con.Close();
            }
        }

        public void Insert_Company_Details_Contact_Person(string companyName, string companyEmail, string Address_of_Company,
                                                           string Name_of_MD_CEO, string Phone_NO_of_MD_CEO, string Contact_Person,
                                                           string Phone_No, string Email_Address)
        {
            // TextBox1.Text = TextBox1.Text.ToUpper();           
            //Connection cn = new Connection();
            System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(mycon.Myconnection);
            //cnn.ConnectionString = cn.Myconnection;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            try
            {
                details.system_date = DateTime.Now.ToString();
                cnn.Open();


                string query = "INSERT INTO dbo.ADMIN_COMPANY_DETAILS (COMPANY_NAME,EMAIL ,Address_of_Company, Name_of_MD_CEO ,Phone_NO_of_MD_CEO, Contact_Person , Phone_No , Email_Address ,Created_by, Date_Created , FLAG   )"

                + " VALUES ( '" + companyName + "' ,  '" + companyEmail + "'  ,'" + Address_of_Company + "'  ,'" + Name_of_MD_CEO + "'  ,'" + Phone_NO_of_MD_CEO + "'  ,'" + Contact_Person + "'  ,'" + Phone_No + "'  ,'" + Email_Address + "'  ,  '" + companyName + "' , '" + details.system_date + "' , 'CONTACT PERSON' )";


                cmd = new SqlCommand(query, cnn); cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string myMsgErr = ex.Message;

                string myMsgErr2 = ex.StackTrace;

                cnn.Close();
            }
            finally
            {
                cnn.Close();
            }

        }




        private void Insert_Company_Details_Alt_Contact_Person(string companyName, string companyEmail, string Address_of_Company, string Name_of_MD_CEO, string Phone_NO_of_MD_CEO, string Contact_Person, string Phone_No, string Email_Address, string Created_by, string Date_Created)
        {
            System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection();
            //cnn.ConnectionString = cn.Myconnection;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            try
            {
                details.system_date = DateTime.Now.ToString();
                cnn.Open();


                // string query = "INSERT INTO dbo.ADMIN_COMPANY_DETAILS (COMPANY_NAME,EMAIL ,Address_of_Company, Name_of_MD_CEO ,Phone_NO_of_MD_CEO,  Alternate_Contact_Person , Phone_No_alt ,  Email_Address_alt ,Created_by, Date_Created ,FLAG  )"

                string query = "INSERT INTO dbo.ADMIN_COMPANY_DETAILS (COMPANY_NAME,EMAIL ,Address_of_Company, Name_of_MD_CEO ,Phone_NO_of_MD_CEO, Contact_Person , Phone_No , Email_Address ,Created_by, Date_Created , FLAG   )"


            + " VALUES ( '" + companyName + "' ,  '" + companyEmail + "'  ,'" + Address_of_Company + "'  ,'" + Name_of_MD_CEO + "'  ,'" + Phone_NO_of_MD_CEO + "'  ,'" + Contact_Person + "'  ,'" + Phone_No + "'  ,'" + Email_Address + "'  ,  '" + companyName + "' , '" + Date_Created + "' , 'CONTACT PERSON' )";


                cmd = new SqlCommand(query, cnn); cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string myMsgErr = ex.Message;

                string myMsgErr2 = ex.StackTrace;

                cnn.Close();
            }
            finally
            {
                cnn.Close();
            }

        }






        private void isAutheticate(string companyName, string companyEmail) // Pass the Isauthentication into access for username and password
        {
            //Connection mycon = new Connection();
            SqlConnection con = new SqlConnection(mycon.Myconnection);

            SqlCommand cmd = new SqlCommand("select * from ADMIN_COMPANY_DETAILS where COMPANY_NAME = '" + companyName + "' and EMAIL =   '" + companyEmail + "'  ", con);
            // OracleCommand cmd = new OracleCommand("select * from TXRMS_USERS where username = '" + uname + "' and password  = '" + pword + "'  ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();

                System.Data.SqlClient.SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    // Session["CompanyName"] = rd["Email"].ToString();

                    Delete_Company_Details(details.CompanyName, details.CompanyEmail);


                    Insert_Company_Details_Contact_Person(details.CompanyName, details.CompanyEmail, details.Address_of_Company, details.Name_of_MD_CEO, details.Phone_NO_of_MD_CEO, details.Contact_Person, details.Phone_No, details.Email_Address);

                    Insert_Company_Details_Alt_Contact_Person(details.CompanyName, details.CompanyEmail, details.Address_of_Company, details.Name_of_MD_CEO, details.Phone_NO_of_MD_CEO, details.Contact_Person, details.Phone_No, details.Email_Address, details.CompanyName, details.system_date);

                    string strMsg = " Company details Updated";

                    //Response.Write("<script>alert('" + strMsg + "')</script>");
                }
                else
                {
                    Insert_Company_Details_Contact_Person(details.CompanyName, details.CompanyEmail, details.Address_of_Company, details.Name_of_MD_CEO, details.Phone_NO_of_MD_CEO, details.Contact_Person, details.Phone_No, details.Email_Address);

                    Insert_Company_Details_Alt_Contact_Person(details.CompanyName, details.CompanyEmail, details.Address_of_Company, details.Name_of_MD_CEO, details.Phone_NO_of_MD_CEO, details.Contact_Person, details.Phone_No, details.Email_Address, details.CompanyName, details.system_date);

                    string strMsg = " Company details Submitted";
                    //Response.Write("<script>alert('" + strMsg + "')</script>");
                }

            }
            catch (Exception ex)
            {
                //myStatus = false;
                string ErrMsg = ex.Message;
                con.Close();
            }
            finally
            {
                con.Close();
            }
            //  return myStatus;

        }

        private void Delete_Company_Details(string companyName, string companyEmail)
        {
            //Connection cn = new Connection();
            System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection();
            //cnn.ConnectionString = cn.Myconnection;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;

            try
            {
                cnn.Open();
                string query = "DELETE FROM ADMIN_COMPANY_DETAILS where COMPANY_NAME = '" + companyName + "' and  EMAIL = '" + companyEmail + "'  ";
                cmd = new SqlCommand(query, cnn); cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string myMsgErr = ex.Message; string myMsgErr2 = ex.StackTrace;

                cnn.Close();
            }
            finally
            {
                cnn.Close();
            }

        }
    }
}
