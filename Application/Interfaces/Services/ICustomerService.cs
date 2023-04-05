using ArtisanBackEnd.Application.DTOs;

namespace ArtisanBackEnd.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        BaseResponse CreateCustomer(CreateCustomerRequestModel request);
        BaseResponse UpdateCustomer(int id, UpdateCustomerRequestModel request);
        BaseResponse UpdatePassword(int id, UpdatePasswordRequestModel password);
        public CustomerResponseModel GetCustomerById(int id);
        public CustomerResponseModel GetCustomerByCustomerNumber(string customerNumber);
        public IList<CustomerResponseModel> GetCustomers();
        BaseResponse DeleteCustomer(int id);
    }
}