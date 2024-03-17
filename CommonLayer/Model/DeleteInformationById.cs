using System.ComponentModel.DataAnnotations;

namespace CrudApplication.CommonLayer.Model
{
    public class DeleteInformationByIdRequest
    {
        [Required(ErrorMessage = "User id is required")]
        public int UserId { get; set; }
    }

    public class DeleteInformationByIdResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
