namespace CrudApplication.CommonLayer.Model
{
    public class ReadAllInformationResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public List<ReadAllInformation> readAllInformation { get; set; }
    }

    public class ReadAllInformation
    {
        public int id { get; set; }

        public string UserName { get; set; }

        public string MobileNumber { get; set; }

        public string EmailId { get; set; }

        public string Gender { get; set; }

        public int Salary { get; set; }

        public bool isActive { get; set; }
    }
}
