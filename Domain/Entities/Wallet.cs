namespace ArtisanBackEnd.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public int UserId {get; set;}
        public User User {get; set;}
        public decimal WalletBalance {get; set;}
        
    }
}