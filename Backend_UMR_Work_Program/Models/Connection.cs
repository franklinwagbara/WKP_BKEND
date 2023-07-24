namespace Backend_UMR_Work_Program.Models
{
    public class Connection
    {
        public Connection(IConfiguration configuration)
        {
            //
            // TODO: Add constructor logic here
            // Please note that the "[ConnectionString]" in bracket could be any name. its the connection name in the webconfig file
            //connecting = ConfigurationManager.ConnectionStrings["FAQapplication"].ConnectionString;
            connecting = configuration["Data:Wkpconnect:ConnectionString"];

            //connecting = ConfigurationManager.ConnectionStrings["App_ConnectionString"].ConnectionString;



        }

        private string? connecting;

        public string? Myconnection
        {
            get { return connecting; }
            set { connecting = value; }
        }
    }
}
