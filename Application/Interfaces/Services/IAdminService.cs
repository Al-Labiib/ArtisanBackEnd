using ArtisanBackEnd.Application.DTOs;

namespace ArtisanBackEnd.Application.Interfaces.Services
{
    public interface IAdminService
    {
        BaseResponse CreateAdmin(CreateAdminRequestModel request);
        BaseResponse UpdateAdmin(UpdateAdminRequestModel request);
        AdminResponseModel GetAdminById(int adminId);
        AdminResponseModel GetAdminByEmailAndPassword(string email, string Password);
    }
}