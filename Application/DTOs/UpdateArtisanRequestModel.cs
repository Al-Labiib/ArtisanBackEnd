using ArtisanBackEnd.Domain.Entities;
using ArtisanBackEnd.Domain.Enums;

namespace ArtisanBackEnd.Application.DTOs
{
    public class UpdateArtisanRequestModel
    {
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public string? ProfileImage { get; set; }
        public JobCategory JobCategory {get; set;}
    }
}