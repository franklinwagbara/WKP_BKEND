using Backend_UMR_Work_Program.Models;
using System.Data;
using System.Data.SqlClient;

namespace Backend_UMR_Work_Program
{
    public class check_super_admin_role
    {
        private Connection cn2;
        public check_super_admin_role(Connection connection)
        {
            cn2 = connection;
        }

        public void Check_Super_Admin_Role() //
        {
            //Connection cn2 = new Connection();
            System.Data.SqlClient.SqlConnection cnn2 = new System.Data.SqlClient.SqlConnection();
            cnn2.ConnectionString = cn2.Myconnection;
            System.Data.SqlClient.SqlCommand cmd2 = new SqlCommand("Select * from ROLES_SUPER_ADMIN where  DELETED_STATUS IS NULL", cnn2);

            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = cnn2;
            try
            {
                cnn2.Open();
                SqlDataReader rd = cmd2.ExecuteReader();

                if (rd.Read())
                { }
                else
                {
                    // ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Hi", "alert('Access Denied !! You need Super Admin Right..'); ", true);
                    return;
                }

            }
            catch (Exception ex)
            {
                string ErrMsg = ex.Message;
                cnn2.Close();
                //STACK_TRACE = ex.StackTrace;
                //EXMESSAGE = ex.Message;
                //error_log();
            }
            finally
            {
                cnn2.Close();
            }
        }

    }
}