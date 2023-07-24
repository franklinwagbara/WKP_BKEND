using Microsoft.AspNetCore.Mvc;

namespace Backend_UMR_Work_Program.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        [HttpPost]
        public void WriteLog(string msg)
        {
            if ((msg.ToString().Contains("Thread was being aborted") || msg.ToString().Contains("An error has occurred while establishing a connection to the server")))

            {

                // 'do nothing

            }

            else

            {

                try

                {

                    string _path;

                    _path = "App_Logs\\ErrorLog.txt";

                    string path = Path.Combine("../\\", _path);

                    System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true);

                    // writer.WriteLine(msg + " " + New FINSMS_BLL().NigerianDate() & " " & New FINSMS_BLL().NigerianTime())

                    // writer.WriteLine((((msg + (" " + " ")) + new SSC_BLL()) + " @ " + NigerianTime()));

                    writer.WriteLine(msg);

                    writer.Close();

                }

                catch (Exception ex)

                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
