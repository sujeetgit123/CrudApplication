using CrudApplication.CommonLayer.Model;

namespace CrudApplication.RepositoryLayer
{
    public interface ICrudApplicationRL
    {
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);
     
        public Task<LoginInformationResponse> GetUserInformation(LoginInformationRequest request);

        public Task<UpdateAllInformationByIdResponse> UpdateAllInformationById(UpdateAllInformationByIdRequest request);
        
        public Task<DeleteInformationByIdResponse> DeleteInformationById(DeleteInformationByIdRequest request);
     
        public Task<ReadAllInformationResponse> ReadAllInformation();
    }
}
