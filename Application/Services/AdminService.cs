using ArtisanBackEnd.Application.DTOs;
using ArtisanBackEnd.Application.Interfaces.Services;

namespace ArtisanBackEnd.Application.Services
{
    public class AdminService : IAdminService
    {
        public BaseResponse CreateAdmin(CreateAdminRequestModel request)
        {
            throw new NotImplementedException();
        }

        public AdminResponseModel GetAdminByEmailAndPassword(string email, string Password)
        {
            throw new NotImplementedException();
        }

        public AdminResponseModel GetAdminById(int adminId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UpdateAdmin(UpdateAdminRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}