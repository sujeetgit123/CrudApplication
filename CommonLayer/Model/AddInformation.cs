using System.ComponentModel.DataAnnotations;

namespace CrudApplication.CommonLayer.Model
{
    public class AddInformationRequest
    {
        public readonly string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        [Required(ErrorMessage = "User name is required")]
        public string UserName {  get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "provide a valid email.")]
        public string EmailId { get; set; }

        [Required]
        [RegularExpression(@"[\d]", ErrorMessage = "Provide a valid mobile number.")]
        public string MobileNumber { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please provide salary greater than 1.")]
        public int Salary { get; set; }

        [Required]
        public string Gender { get; set; }
    }

    public class AddInformationResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
