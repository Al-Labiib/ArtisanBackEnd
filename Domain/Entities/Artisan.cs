using ArtisanBackEnd.Domain.Enums;
namespace ArtisanBackEnd.Domain.Entities
{
    public class Artisan : BaseEntity
    {
        public int UserId {get; set;}
        public User User {get; set;}
        // public string UserName {get; set;}
        public JobCategory JobCategory {get; set;}
        public int WalletId {get; set;}
        public Wallet Wallet {get; set;}
        public string? ProfileImage {get; set;}
        public string? CertificateImage {get; set;}
        public string ArtisanNumber {get; set;}
        public ICollection<Contract> Contracts {get; set;}
        public ICollection<PayStackPayment> PayStackPayments {get; set;}
        public ICollection<InHousePayment> InHousePayments {get; set;}
        public ICollection<Dispute> Disputes {get; set;}
        public ICollection<JobPost> JobPosts {get; set;}
        public ICollection<Booking> Bookings {get; set;}
    }
}