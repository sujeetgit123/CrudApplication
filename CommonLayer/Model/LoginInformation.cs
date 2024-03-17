using System.ComponentModel.DataAnnotations;

namespace CrudApplication.CommonLayer.Model
{
    public class LoginInformationRequest
    {
        [Required]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class LoginInformationResponse
    {
        public bool IsSuccess {  get; set; }

        public string Message { get; set; }

        public string? Token { get; set; }

        public ReadAllInformation? User {  get; set; }
    }
}
