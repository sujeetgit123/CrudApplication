using CrudApplication.CommonLayer.Model;
using CrudApplication.RepositoryLayer;
using System.Text.RegularExpressions;

namespace CrudApplication.ServiceLayer
{
    public class CrudApplicationSL : ICrudApplicationSL
    {
        //public readonly string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
        //                        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        //public readonly string phoneRegex = @"[\d]";

        public readonly ICrudApplicationRL _crudApplicationRL;
        public CrudApplicationSL(ICrudApplicationRL crudApplicationRL) 
        {
            _crudApplicationRL = crudApplicationRL;
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            //AddInformationResponse response = new AddInformationResponse();
            //
            //if (string.IsNullOrEmpty(request.UserName))
            //{
            //    response.IsSuccess = false;
            //    response.Message = "user name is required.";
            //    return response;
            //}

            //if (string.IsNullOrEmpty(request.MobileNumber))
            //{
            //    response.IsSuccess = false;
            //    response.Message = "mobile number is required.";
            //    return response;

            //} else if (!Regex.IsMatch(request.MobileNumber, phoneRegex))
            //{
            //    response.IsSuccess = false;
            //    response.Message = "please provide a valid mobile number.";
            //    return response;
            //}

            //if (string.IsNullOrEmpty(request.Gender))
            //{
            //    response.IsSuccess = false;
            //    response.Message = "gender is required.";
            //    return response;
            //}

            //if (string.IsNullOrEmpty(request.EmailId))
            //{
            //    response.IsSuccess = false;
            //    response.Message = "emailId is required.";
            //    return response;
            //} else if (!Regex.IsMatch(request.EmailId, emailRegex))
            //{
            //    response.IsSuccess = false;
            //    response.Message = "Please provide valid email Id.";
            //    return response;
            //}

            //if (request.Salary <= 0)
            //{
            //    response.IsSuccess = false;
            //    response.Message = "Salary is required and greater than 0.";
            //    return response;
            //}


            return await _crudApplicationRL.AddInformation(request);
        }
        public async Task<LoginInformationResponse> GetUserInformation(LoginInformationRequest request)
        {
            return await _crudApplicationRL.GetUserInformation(request);
        }


        public async Task<UpdateAllInformationByIdResponse> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            return await _crudApplicationRL.UpdateAllInformationById(request);
        }
        
        public async Task<DeleteInformationByIdResponse> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            return await _crudApplicationRL.DeleteInformationById(request);
        }

        public async Task<ReadAllInformationResponse> ReadAllInformation()
        {
            ReadAllInformationResponse response = new ReadAllInformationResponse();
            return await _crudApplicationRL.ReadAllInformation();
        }
    }
}
