using ArtisanBackEnd.Domain.Entities;

namespace ArtisanBackEnd.Application.DTOs
{
    public class UpdateCustomerRequestModel
    {
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public string ProfileImage { get; set; }
    }
}