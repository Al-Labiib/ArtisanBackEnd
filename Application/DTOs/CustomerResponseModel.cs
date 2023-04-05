using ArtisanBackEnd.Domain.Entities;
using ArtisanBackEnd.Domain.Enums;

namespace ArtisanBackEnd.Application.DTOs
{
    public class CustomerResponseModel : BaseResponse
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName {get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerNumber {get; set;}
        public string Email { get; set; }
        public Address Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfileImage { get; set; }
        
    }
}