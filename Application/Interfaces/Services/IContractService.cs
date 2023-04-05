using ArtisanBackEnd.Application.DTOs;

namespace ArtisanBackEnd.Application.Interfaces.Services
{
    public interface IContractService
    {
        BaseResponse CreateContract(CreateContractRequestModel request);
        ContractResponseModel GetContractById(int id);
        BaseResponse UpdateContract(int id, UpdateContractRequestModel request);
        IList<ContractResponseModel> GetContracts();
        BaseResponse DeleteContract(int id);
        BaseResponse PayForContract (int id);
    }
}