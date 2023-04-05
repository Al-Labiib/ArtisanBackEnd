using ArtisanBackEnd.Domain.Enums;
namespace ArtisanBackEnd.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth {get; set;}
        public int AddressId {get;set;}
        public Address Address { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Rate> ? Ratings {get; set;}
        public Wallet Wallet {get; set;}
    }
}