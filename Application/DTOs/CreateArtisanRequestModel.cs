using ArtisanBackEnd.Domain.Entities;
using ArtisanBackEnd.Domain.Enums;

namespace ArtisanBackEnd.Application.DTOs
{
    public class CreateArtisanRequestModel
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NumberLine {get; set;}
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string LocalGovernment {get; set;}
        public DateTime DateOfBirth { get; set; }
        public JobCategory jobCategory {get; set;}
        public string? ProfileImage { get; set; }
        public string? CertificateImage {get; set;}
        public string UserName {get; set;}
    }
}