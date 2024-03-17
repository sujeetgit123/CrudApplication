namespace CrudApplication.CommonUtility
{
    public class SqlQueries
    {
        public static IConfiguration _configuration = new ConfigurationBuilder().AddXmlFile("SqlQueries.xml", true, true).Build();
        
        public static string AddInformation { get { return _configuration["AddInformation"]; } }

        public static string GetUserInformation { get { return _configuration["GetUserInformation"]; } }

        public static string UpdateAllInformationById { get { return _configuration["UpdateAllInformationById"]; } }
        
        public static string DeleteInformationById { get { return _configuration["DeleteInformationById"]; } }

        public static string ReadAllInformation { get { return _configuration["ReadAllInformation"]; } }
    }
}
